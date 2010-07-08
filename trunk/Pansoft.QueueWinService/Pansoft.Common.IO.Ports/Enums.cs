using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pansoft.Common.IO.Ports
{
    public class IOPortsEnums
    {
        /// <summary>
        /// 当数据传输时的连接模式
        /// </summary>
        public enum TransportMode
        {
            /// <summary>
            /// Http
            /// </summary>
            Http,
            /// <summary>
            /// Ftp
            /// </summary>
            Ftp,
            /// <summary>
            /// WebService
            /// </summary>
            WebService,
            /// <summary>
            /// Socket
            /// </summary>
            Socket,
            /// <summary>
            /// SerialPort(串口)
            /// </summary>
            SerialPort,
            /// <summary>
            /// ParallelPort(并口)
            /// </summary>
            ParallelPort,
            /// <summary>
            /// PS2(键盘口)
            /// </summary>
            PS2,
            /// <summary>
            /// USB
            /// </summary>
            USB,
            /// <summary>
            /// Bluetooth(蓝牙)
            /// </summary>
            Bluetooth,
            /// <summary>
            /// IEEE(火线)
            /// </summary>
            IEEE
        }
    }
}
