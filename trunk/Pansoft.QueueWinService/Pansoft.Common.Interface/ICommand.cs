using System;
using System.Collections.Generic;
using System.Text;

namespace Pansoft.Common.Interface
{
    /// <summary>
    /// 一个描述逻辑链中单个处理环节的接口
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 返回该接口的拥有者
        /// </summary>
        object Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets 该环节是否是起始环节
        /// </summary>
        /// <value><c>true</c> if this instance is root; otherwise, <c>false</c>.</value>
        bool IsRoot { get; set; }

        /// <summary>
        /// 执行处理逻辑
        /// </summary>
        void Run();

        /// <summary>
        /// 当该接口的拥有者发生改变时发生
        /// </summary>
        event EventHandler OwnerChanged;
    }
}
