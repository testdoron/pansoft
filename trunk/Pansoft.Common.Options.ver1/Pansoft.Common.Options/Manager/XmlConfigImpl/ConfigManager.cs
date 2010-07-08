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
    /// 使用XML实现选项管理器接口
    /// </summary>
    /// <remarks>
    /// 如果不指定选项文件，则从下面顺序寻找选项文件：
    /// <list type="number">
    ///		<item>
    ///			<description>
    ///				在以下目录寻找名为htb.devfx.config的选项文件：
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
    ///				如果没找到，则查找由<see cref="HTB.DevFx.Option.DevFxOptionAttribute"/>指定的选项文件
    ///			</description>
    ///		</item>
    ///		<item>
    ///			<description>
    ///				如果没找到，则查找由web/app.config中的如下节指定位置的选项文件：
    ///				<code>
    ///					&lt;appSettings&gt;
    ///						&lt;add key="htb.devfx.config" value="..\configFiles\htb.devfx.config" /&gt;
    ///					&lt;/appSettings&gt;
    ///				</code>
    ///				其中key值指定为“htb.devfx.config”，value为选项文件相对应用程序根目录的相对地址
    ///			</description>
    ///		</item>
    ///		<item>
    ///			<description>
    ///				如果还没找到，则抛出异常
    ///			</description>
    ///		</item>
    /// </list>
    /// </remarks>
    internal class XmlOptionManager : OptionManager
    {
        #region constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public XmlOptionManager() : this(null, false) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configFile">指定选项文件地址</param>
        /// <param name="monitor">是否监视选项文件</param>
        public XmlOptionManager(string configFile, bool monitor) : base(configFile, monitor) { }

        #endregion

        #region IOption Members

        /// <summary>
        /// 此管理器所管理的选项
        /// </summary>
        public override IOption Option
        {
            get
            {
                if (!this.initialized)
                {
                    throw new OptionException("选项管理器没有被正确初始化");
                }
                return this.setting;
            }
        }

        /// <summary>
        /// 初始化，提供给框架调用，进行管理器的初始化工作，比如载入选项文件等等
        /// </summary>
        /// <param name="configFile">选项文件信息</param>
        /// <param name="monitor">是否要监视此选项的变化</param>
        /// <remarks>
        ///	参数<paramref name="monitor" />表示，监视选项文件变化，以更新选项信息
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
        /// 重新载入相关选项信息
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
        /// 初始化选项节数据
        /// </summary>
        /// <param name="configFile">选项文件地址</param>
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
        /// 分析初始化选项节
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
                throw new OptionException("选项文件没找到");
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
                            throw new OptionException(string.Format("在所有使用OptionFileAttribute定义中已有如下的顺序号 {0}，请修改顺序号定义后重新编译代码", indexList));
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
        /// 查找选项文件地址
        /// </summary>
        /// <returns>选项文件地址</returns>
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