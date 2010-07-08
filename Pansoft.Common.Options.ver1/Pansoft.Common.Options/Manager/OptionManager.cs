namespace Pansoft.Common.Options
{
    /// <summary>
    /// 选项管理器的抽象实现
    /// </summary>
    public abstract class OptionManager : IOptionManager
    {
        #region constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        protected OptionManager()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configFile">选项文件信息</param>
        /// <param name="monitor">是否要监视选项文件</param>
        protected OptionManager(string configFile, bool monitor)
        {
            this.Initializes(configFile, monitor);
        }

        #endregion

        #region protected fields

        /// <summary>
        /// 选项文件信息
        /// </summary>
        protected string configFile;
        /// <summary>
        /// 是否要监视选项文件
        /// </summary>
        protected bool monitor;
        /// <summary>
        /// 管理器是否已初始化
        /// </summary>
        protected bool initialized;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configFile">选项文件信息</param>
        /// <param name="monitor">是否要监视此选项的变化</param>
        /// <remarks>
        ///	参数<paramref name="monitor" />表示，监视选项文件变化，以更新选项信息
        /// </remarks>
        protected virtual void OnInit(string configFile, bool monitor)
        {
            this.configFile = configFile;
            this.monitor = monitor;
        }

        #endregion

        #region IConfigManager Members

        /// <summary>
        /// 此管理器所管理的选项
        /// </summary>
        public abstract IOption Option { get; }

        /// <summary>
        /// 初始化，提供给框架调用，进行管理器的初始化工作，比如载入选项文件等等
        /// </summary>
        /// <param name="configFile">选项文件信息</param>
        /// <param name="monitor">是否要监视此选项的变化</param>
        /// <remarks>
        /// 参数<paramref name="monitor"/>表示，监视选项文件变化，以更新选项信息
        /// </remarks>
        public virtual void Initializes(string configFile, bool monitor)
        {
            if (!this.initialized)
            {
                this.OnInit(configFile, monitor);
                this.initialized = true;
            }
        }

        /// <summary>
        /// 获得选项节
        /// </summary>
        /// <param name="xpath">选项节的XPath，如果为<c>null</c>，则返回根选项节</param>
        /// <returns><see cref="IConfigSetting"/></returns>
        public virtual IOption GetOption(string xpath)
        {
            return this.Option.GetChildOption(xpath);
        }

        /// <summary>
        /// 重新载入相关选项信息
        /// </summary>
        public abstract void Reset();

        #endregion
    }
}
