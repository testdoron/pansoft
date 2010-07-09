using System;
using System.Collections.Generic;
using System.Text;

namespace Pansoft.Whgd.EvServicing
{
    public interface IService
    {
        /// <summary>
        /// 初始化服务
        /// </summary>
        void initializeService();

        /// <summary>
        /// 启动服务
        /// </summary>
        /// 启动服务
        void startService();

        /// <summary>
        /// 停止服务
        /// </summary>
        void stopService();

        /// <summary>
        /// 重置服务
        /// </summary>
        void reloadService();
    }
}
