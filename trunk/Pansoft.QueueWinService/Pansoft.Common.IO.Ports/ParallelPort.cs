using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Management;
using Pansoft.Common.Interface;
using JH.CommBase;

namespace Pansoft.Common.IO.Ports
{
    /// <summary>
    /// 一个并口类。在.net类库中只有串口类。本类作为补充。另外，并口的特性是不容易实现读取并口的数据，在本类型中依靠第三该类库(Inpout32.dll)实现了对并口数据的读取。
    /// </summary>
    public class ParallelPort : IPort, IDisposable
    {
        #region Inpout32.dll相关

        /* Inpout32.dll是一个非常全面的可以操作并口的类文件
         * The outstanding feature of Inpout32.dll is , it can work with all the windows versions 
         * without any modification in user code or the DLL itself. This tutorial describes how 
         * it is achieved, what programming methods used, what are the APIs used, etc.... 
         * The Dll will check the operating system version when functions are called, and if the 
         * operating system is WIN9X, the DLL will use _inp() and _outp functions for reading/writing 
         * the parallel port. On the other hand, if the operating system is WIN NT, 2000 or XP, 
         * it will install a kernel mode driver and talk to parallel port through that driver. 
         * The user code will not be aware of the OS version on which it is running. This DLL can 
         * be used in WIN NT clone operating systems as if it is WIN9X. The flow chart of the 
         * program is given below.
         * 介绍：http://www.cnblogs.com/thunderdanky/articles/795010.html
         * 来源：http://www.logix4u.net/inpout32.htm
         */

        [DllImport("Inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(uint adress, int value);

        [DllImport("Inpout32.dll", EntryPoint = "Inp32")]
        public static extern int Input(uint adress);

        #endregion

        #region IPort 成员

        /// <summary>
        /// 获取一个端口的ID，当端口较多时，由初始化时外部指定
        /// </summary>
        /// <value>The id.</value>
        public string Id { get; private set; }

        /// <summary>
        /// 获取一个端口是否被打开
        /// </summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        public bool IsOpen { get; private set; }

        /// <summary>
        /// 获取一个端口的名称，当端口较多时，由初始化时外部指定
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        private int _iHandle;
        private bool _isWork;
        /// <summary>
        /// 向端口写入指定的数据
        /// </summary>
        /// <param name="Data">指定的数据</param>
        /// <returns></returns>
        public bool WriteData(byte[] Data)
        {
            //for (int i = 0; i < Data.Length; i++)
            //    Output(BasePort, Data[i]); 这里原来也想用inpout32实现，但是从字节到int转换比较麻烦，试了几次没达到效果
            //return true;

            if (_iHandle != -1)
            {
                Win32Com.OVERLAPPED x = new Win32Com.OVERLAPPED();
                int i = 0;
                Win32Com.WriteFile(_iHandle, Data, Data.Length, ref i, ref x);
                return true;
            }
            else
            {
                //不能连接到打印机;
                return false;
            }
        }

        /// <summary>
        /// 用inpout32读状态
        /// </summary>
        /// <param name="Len"></param>
        /// <returns></returns>
        public byte[] ReadData(int Len)
        {
            byte[] result;//= new byte[Len];
            result = new byte[Len];
            for (int i = 0; i < result.Length; i++)
                result[i] = (byte)Input(BasePort + 1);
            return result;
        }

        /// <summary>
        /// 打开端口
        /// </summary>
        public void Open()
        {
            _iHandle = Win32Com.CreateFile(Name, 0x40000000, 0, 0, 3, 0, 0);
            if (_iHandle != -1)
            {
                this.IsOpen = true;
            }
            else
            {
                this.IsOpen = false;
            }

            this.IsOpen = true;
            _isWork = true;
            //开一个线程检测状态口状态
            new System.Threading.Thread(new System.Threading.ThreadStart(ReadState)).Start();
        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        public void Close()
        {
            this.IsOpen = !Win32Com.CloseHandle(_iHandle);
            _isWork = false;
        }

        /// <summary>
        /// 端口基址
        /// </summary>
        private uint BasePort { get; set; }
        internal ParallelPort(String portName)
        {
            this.Name = portName;
            _iHandle = -1;

            ///用WQL查询串口基址
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_ParallelPort.DeviceID='" + this.Name + "'}");
            //最佳的WQL是ASSOCIATORS OF {Win32_ParallelPort.DeviceID='" + this.Name  + "'} WHERE ASSCICLASS = Win32_PortResource
            //但是不知道为什么不返回结果，所以做一个简单的遍历
            foreach (var i in searcher.Get())
            {
                if (i.ClassPath.ClassName == "Win32_PortResource")
                {
                    //得到串口基址 大多数是0x378H
                    this.BasePort = System.Convert.ToUInt32(i.Properties["StartingAddress"].Value.ToString());
                    break;
                }
            }
            if (BasePort == 0)
                throw new Exception("不是有效端口");
            IsOpen = false;
        }

        /// <summary>
        /// 当端口状态发生改变时发生
        /// </summary>
        public event PortStateChangedEventHandler PortStateChangedEvent;
        /// <summary>
        /// 当端口数据读取完成时发生
        /// </summary>
        public event PortDataReceivedEventHandler PortDataReceivedEvent;

        /// <summary>
        /// 检测线程，当状态改变时，引发事件
        /// </summary>
        private void ReadState()
        {
            _flag = 0;
            int lastRead = _flag;
            while (_isWork)
            {
                lastRead = _flag;
                _flag = Input(BasePort + 1);
                if (_flag != lastRead)
                {
                    if (this.PortStateChangedEvent != null)
                    {
                        this.PortStateChangedEvent(this, new PortStateChangedEventArgs(_flag));
                    }
                }
                System.Threading.Thread.Sleep(200);
            }
        }
        private int _flag;
        #endregion

        public void Update()
        {
            _flag = 0;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            this.Close();
        }

        #endregion

        #region IPort 成员

        #endregion
    }
}
