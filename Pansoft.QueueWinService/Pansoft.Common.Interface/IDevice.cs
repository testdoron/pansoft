using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pansoft.Common.Interface
{
    /// <summary>
    /// 一个描述设备信息的基础接口
    /// </summary>
    public interface IDevice
    {
        /// <summary>
        /// 返回设备ID
        /// </summary>
        /// <value>The id.</value>
        Int16 Id { get; }
        /// <summary>
        /// 返回设备名(描述性质)
        /// </summary>
        /// <value>The name.</value>
        String Name { get; }
        /// <summary>
        /// 返回或设置设备的状态信息
        /// </summary>
        /// <value>The state.</value>
        IState State { get; set; }
    }
}
