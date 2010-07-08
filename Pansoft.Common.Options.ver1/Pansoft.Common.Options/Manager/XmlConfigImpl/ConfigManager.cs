using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using Pansoft.Common.Options;
using System.IO;

[assembly: Option(RealType = typeof(OptionManager), Priority = 1000)]
[assembly: OptionFile("res://HTB.DevFx.Option.htb.devfx.config", typeof(OptionManager), 0)]
namespace Pansoft.Common.Options
{
    /// <summary>
    /// ʹ��XMLʵ��ѡ��������ӿ�
    /// </summary>
    /// <remarks>
    /// �����ָ��ѡ���ļ����������˳��Ѱ��ѡ���ļ���
    /// <list type="number">
    ///		<item>
    ///			<description>
    ///				������Ŀ¼Ѱ����Ϊhtb.devfx.config��ѡ���ļ���
    ///				<code>
    ///					"./",
    ///					"./../",
    ///					"./../../",
    ///					"./../../../",
    ///					"./../Optionuration/",
    ///					"./../../Optionuration/",
    ///					"./../../../Optionuration/",
    ///					Environment.CurrentDirectory + "/",
    ///					AppDomain.CurrentDomain.SetupInformation.ApplicationBase
    ///				</code>
    ///			</description>
    ///		</item>
    ///		<item>
    ///			<description>
    ///				���û�ҵ����������<see cref="HTB.DevFx.Option.DevFxOptionAttribute"/>ָ����ѡ���ļ�
    ///			</description>
    ///		</item>
    ///		<item>
    ///			<description>
    ///				���û�ҵ����������web/app.config�е����½�ָ��λ�õ�ѡ���ļ���
    ///				<code>
    ///					&lt;appSettings&gt;
    ///						&lt;add key="htb.devfx.config" value="..\configFiles\htb.devfx.config" /&gt;
    ///					&lt;/appSettings&gt;
    ///				</code>
    ///				����keyֵָ��Ϊ��htb.devfx.config����valueΪѡ���ļ����Ӧ�ó����Ŀ¼����Ե�ַ
    ///			</description>
    ///		</item>
    ///		<item>
    ///			<description>
    ///				�����û�ҵ������׳��쳣
    ///			</description>
    ///		</item>
    /// </list>
    /// </remarks>
    internal class XmlOptionManager : OptionManager
    {
        #region constructor

        /// <summary>
        /// ���캯��
        /// </summary>
        public XmlOptionManager() : this(null, false) { }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="configFile">ָ��ѡ���ļ���ַ</param>
        /// <param name="monitor">�Ƿ����ѡ���ļ�</param>
        public XmlOptionManager(string configFile, bool monitor) : base(configFile, monitor) { }

        #endregion

        #region IOption Members

        /// <summary>
        /// �˹������������ѡ��
        /// </summary>
        public override IOption Option
        {
            get
            {
                if (!this.initialized)
                {
                    throw new OptionException("ѡ�������û�б���ȷ��ʼ��");
                }
                return this.setting;
            }
        }

        /// <summary>
        /// ��ʼ�����ṩ����ܵ��ã����й������ĳ�ʼ����������������ѡ���ļ��ȵ�
        /// </summary>
        /// <param name="configFile">ѡ���ļ���Ϣ</param>
        /// <param name="monitor">�Ƿ�Ҫ���Ӵ�ѡ��ı仯</param>
        /// <remarks>
        ///	����<paramref name="monitor" />��ʾ������ѡ���ļ��仯���Ը���ѡ����Ϣ
        /// </remarks>
        public override void Initializes(string configFile, bool monitor)
        {
            if (!this.initialized)
            {
                base.Initializes(configFile, monitor);
                this.InitData(configFile);
            }
        }

        /// <summary>
        /// �����������ѡ����Ϣ
        /// </summary>
        public override void Reset()
        {
            if (this.initialized)
            {
                this.InitSetting();
            }
        }

        #endregion

        #region private members

        private IOption setting = null;

        internal const string DEFAULT_CONFIG_FILE = "htb.devfx.config";
        internal const string DEFAULT_CONFIG_FILE_PATTERN = "htb.devfx.*.config";

        /// <summary>
        /// ��ʼ��ѡ�������
        /// </summary>
        /// <param name="configFile">ѡ���ļ���ַ</param>
        private void InitData(string configFile)
        {
            if (configFile == null)
            {
                configFile = this.FindOptionFile();
            }
            configFile = Path.GetFullPath(configFile);
            this.configFile = configFile;
            this.InitSetting();
        }

        /// <summary>
        /// ������ʼ��ѡ���
        /// </summary>
        private void InitSetting()
        {
            bool init = false;
            if (this.configFile != null)
            {
                try
                {
                    this.setting = OptionHelper.CreateFromXmlFile(configFile);
                    init = true;
                }
                catch (OptionException) { }
            }
            if (!init)
            {
                XmlNode configNode = (XmlNode)ConfigurationManager.GetSection("htb.devfx");
                if (configNode != null)
                {
                    try
                    {
                        this.setting = OptionHelper.CreateFromXmlNode(configNode);
                        init = true;
                    }
                    catch (OptionException) { }
                }
            }
            OptionFileAttribute[] configFileAttributes;
            if (!init)
            {
                configFileAttributes = OptionFileAttribute.GetOptionFileAttributeFromAssembly(null);
                if (configFileAttributes != null && configFileAttributes.Length > 0)
                {
                    for (int i = 0; i < configFileAttributes.Length; i++)
                    {
                        if (configFileAttributes[i].OptionIndex == 0)
                        {
                            string configFile = configFileAttributes[i].OptionFile;
                            Type fileInType = configFileAttributes[i].GetFileInType();
                            this.setting = OptionHelper.CreateFromXmlSource(configFile, fileInType);
                            init = true;
                            break;
                        }
                    }
                }
            }
            if (!init)
            {
                throw new OptionException("ѡ���ļ�û�ҵ�");
            }
            configFileAttributes = OptionFileAttribute.GetOptionFileAttributeFromAssembly(null);
            if (configFileAttributes != null && configFileAttributes.Length > 0)
            {
                SortedList<int, OptionFileAttribute> sortedOptionFiles = new SortedList<int, OptionFileAttribute>();
                string indexList = string.Empty;
                for (int i = 0; i < configFileAttributes.Length; i++)
                {
                    if (configFileAttributes[i].OptionIndex != 0)
                    {
                        indexList += configFileAttributes[i].OptionIndex + ", ";
                        if (sortedOptionFiles.ContainsKey(configFileAttributes[i].OptionIndex))
                        {
                            throw new OptionException(string.Format("������ʹ��OptionFileAttribute�������������µ�˳��� {0}�����޸�˳��Ŷ�������±������", indexList));
                        }
                        sortedOptionFiles.Add(configFileAttributes[i].OptionIndex, configFileAttributes[i]);
                    }
                }
                for (int i = 0; i < sortedOptionFiles.Count; i++)
                {
                    OptionFileAttribute configFile = sortedOptionFiles.Values[i];
                    Option option = (Option)OptionHelper.CreateFromXmlSource(configFile.OptionFile, configFile.GetFileInType());
                    this.setting.Merge(option);
                }
            }
            string[] files = OptionHelper.SearchOptionFileWithPattern(DEFAULT_CONFIG_FILE_PATTERN, null);
            foreach (string file in files)
            {
                Option configSetting = (Option)OptionHelper.CreateFromXmlFile(file);
                this.setting.Merge(configSetting);
            }
        }

        /// <summary>
        /// ����ѡ���ļ���ַ
        /// </summary>
        /// <returns>ѡ���ļ���ַ</returns>
        private string FindOptionFile()
        {
            string fileName = OptionHelper.SearchOptionFile(DEFAULT_CONFIG_FILE, null);
            if (fileName != null)
            {
                return fileName;
            }

            OptionAttribute[] configAttributes = OptionAttribute.GetOptionAttributeFromAssembly(null);
            if (configAttributes != null && configAttributes.Length > 0)
            {
                for (int i = 0; i < configAttributes.Length; i++)
                {
                    fileName = OptionHelper.SearchOptionFile(configAttributes[i].OptionFile, null);
                    if (fileName != null)
                    {
                        return fileName;
                    }
                }
            }

            fileName = ConfigurationManager.AppSettings[DEFAULT_CONFIG_FILE];
            fileName = OptionHelper.SearchOptionFile(fileName, null);

            return fileName;
        }

        #endregion
    }
}