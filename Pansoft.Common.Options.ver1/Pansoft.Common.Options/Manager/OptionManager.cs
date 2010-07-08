namespace Pansoft.Common.Options
{
    /// <summary>
    /// ѡ��������ĳ���ʵ��
    /// </summary>
    public abstract class OptionManager : IOptionManager
    {
        #region constructor

        /// <summary>
        /// ���캯��
        /// </summary>
        protected OptionManager()
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="configFile">ѡ���ļ���Ϣ</param>
        /// <param name="monitor">�Ƿ�Ҫ����ѡ���ļ�</param>
        protected OptionManager(string configFile, bool monitor)
        {
            this.Initializes(configFile, monitor);
        }

        #endregion

        #region protected fields

        /// <summary>
        /// ѡ���ļ���Ϣ
        /// </summary>
        protected string configFile;
        /// <summary>
        /// �Ƿ�Ҫ����ѡ���ļ�
        /// </summary>
        protected bool monitor;
        /// <summary>
        /// �������Ƿ��ѳ�ʼ��
        /// </summary>
        protected bool initialized;

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="configFile">ѡ���ļ���Ϣ</param>
        /// <param name="monitor">�Ƿ�Ҫ���Ӵ�ѡ��ı仯</param>
        /// <remarks>
        ///	����<paramref name="monitor" />��ʾ������ѡ���ļ��仯���Ը���ѡ����Ϣ
        /// </remarks>
        protected virtual void OnInit(string configFile, bool monitor)
        {
            this.configFile = configFile;
            this.monitor = monitor;
        }

        #endregion

        #region IConfigManager Members

        /// <summary>
        /// �˹������������ѡ��
        /// </summary>
        public abstract IOption Option { get; }

        /// <summary>
        /// ��ʼ�����ṩ����ܵ��ã����й������ĳ�ʼ����������������ѡ���ļ��ȵ�
        /// </summary>
        /// <param name="configFile">ѡ���ļ���Ϣ</param>
        /// <param name="monitor">�Ƿ�Ҫ���Ӵ�ѡ��ı仯</param>
        /// <remarks>
        /// ����<paramref name="monitor"/>��ʾ������ѡ���ļ��仯���Ը���ѡ����Ϣ
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
        /// ���ѡ���
        /// </summary>
        /// <param name="xpath">ѡ��ڵ�XPath�����Ϊ<c>null</c>���򷵻ظ�ѡ���</param>
        /// <returns><see cref="IConfigSetting"/></returns>
        public virtual IOption GetOption(string xpath)
        {
            return this.Option.GetChildOption(xpath);
        }

        /// <summary>
        /// �����������ѡ����Ϣ
        /// </summary>
        public abstract void Reset();

        #endregion
    }
}
