using System;
namespace Pansoft.Common.Interface
{
    /// <summary>
    /// 一个描述与端口类型（如串口，并口）无关的抽象的端口接口
    /// </summary>
    public interface IPort
    {
        /// <summary>
        /// 获取一个端口的ID，当端口较多时，由初始化时外部指定
        /// </summary>
        /// <value>The id.</value>
        string Id { get; }
        /// <summary>
        /// 获取一个端口的名称，当端口较多时，由初始化时外部指定
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }
        /// <summary>
        /// 获取一个端口是否被打开
        /// </summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        bool IsOpen { get; }
        /// <summary>
        /// 打开端口
        /// </summary>
        void Open();
        /// <summary>
        /// 关闭端口
        /// </summary>
        void Close();
        /// <summary>
        /// 从端口读取数据
        /// </summary>
        /// <param name="Len">The len.</param>
        /// <returns></returns>
        byte[] ReadData(int Len);
        /// <summary>
        /// 向端口写入指定的数据
        /// </summary>
        /// <param name="Data">指定的数据</param>
        /// <returns></returns>
        bool WriteData(byte[] Data);

        /// <summary>
        /// 当端口状态发生改变时发生
        /// </summary>
        event PortStateChangedEventHandler PortStateChangedEvent;
        /// <summary>
        /// 当端口数据读取完成时发生
        /// </summary>
        event PortDataReceivedEventHandler PortDataReceivedEvent;
    }
}
