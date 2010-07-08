using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// XML方式实现选项 <see cref="XmlOption"/>
    /// </summary>
    public class XmlOption : Option
    {
        #region constructor

        /// <summary>
        /// 构造方法
        /// </summary>
        protected XmlOption() { }

        #endregion

        /// <summary>
        /// 创建选项实例
        /// </summary>
        /// <returns></returns>
        protected override Option CreateOption()
        {
            return new XmlOption();
        }

        /// <summary>
        /// 创建选项值
        /// </summary>
        /// <param name="name">选项值名</param>
        /// <param name="value">选项值</param>
        /// <param name="readonly">是否只读</param>
        /// <returns>OptionValue</returns>
        protected override OptionValue CreateOptionValue(string name, string value, bool @readonly)
        {
            return new XmlOptionValue(name, value, @readonly);
        }

        /// <summary>
        /// 创建选项属性实例
        /// </summary>
        /// <param name="readonly">是否只读</param>
        /// <returns>OptionSection</returns>
        protected override OptionSection CreateOptionSection(bool @readonly)
        {
            return new XmlOptionSection(@readonly);
        }

        /// <summary>
        /// 转换成字符串
        /// </summary>
        /// <param name="sb"><see cref="StringBuilder"/></param>
        /// <param name="layerIndex">所处层次</param>
        protected override void ToString(StringBuilder sb, int layerIndex)
        {
            string layerString = new string('\t', layerIndex);
            sb.AppendFormat("{0}<{1}", layerString, this.SettingName);
            if (this.Property.Count > 0)
            {
                sb.AppendFormat(" {0}", this.Property);
            }
            if (this.childSettings.Count > 0)
            {
                sb.AppendFormat(">{0}\r\n", HttpUtility.HtmlAttributeEncode(this.Value.Value));
                foreach (XmlOption setting in this.childSettings.Values)
                {
                    setting.ToString(sb, layerIndex + 1);
                }
                sb.AppendFormat("{0}</{1}>\r\n", layerString, this.SettingName);
            }
            else
            {
                if (this.Value.Value != null)
                {
                    sb.AppendFormat(">{0}</{1}>\r\n", HttpUtility.HtmlAttributeEncode(this.Value.Value), this.SettingName);
                }
                else
                {
                    sb.AppendLine(" />");
                }
            }
        }

        /// <summary>
        /// 创建选项
        /// </summary>
        /// <param name="parent">父选项节</param>
        /// <param name="xmlNode">XML节</param>
        /// <param name="readonly">是否只读</param>
        /// <param name="searchPath">XML搜索目录列表</param>
        /// <param name="configFiles">如果有子选项文件，则添加到此列表</param>
        internal static XmlOption Create(XmlOption parent, XmlNode xmlNode, bool @readonly, string[] searchPath, List<string> configFiles)
        {
            if (xmlNode.NodeType != XmlNodeType.Element)
            {
                throw new OptionException("解析到非法元素");
            }

            if (searchPath == null || searchPath.Length <= 0)
            {
                searchPath = OptionHelper.OptionFileDefaultSearchPath;
            }
            XmlOption setting = new XmlOption();
            setting.parent = parent;
            setting.ReadOnly = @readonly;
            setting.property = new XmlOptionSection(xmlNode, @readonly);
            setting.childSettings = new OptionCollection(true);
            setting.operatorSettings = new OptionCollection(false);
            setting.value = new XmlOptionValue(xmlNode, @readonly);
            setting.SettingName = setting.Name;
            OptionOperatorEnum settingOperator = setting.SettingOperator;
            if (settingOperator != 0 && settingOperator != OptionOperatorEnum.Clear)
            {
                string newName = setting.Property.TryGetPropertyValue(OptionNamePropertyName);
                if (string.IsNullOrEmpty(newName))
                {
                    throw new OptionException("选项命令未定义属性：" + OptionNamePropertyName);
                }
                setting.value.SetName(newName);
            }

            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.NodeType != XmlNodeType.Element)
                {
                    continue;
                }
                XmlOption childSetting = Create(setting, node, @readonly, searchPath, configFiles);
                setting.operatorSettings.Add(childSetting);
            }
            Compile(setting, setting.operatorSettings);

            string configFile = setting.OptionFile;
            string configNode = setting.OptionNode;
            if (!string.IsNullOrEmpty(configFile))
            {
                configFile = OptionHelper.SearchOptionFile(configFile, searchPath);
                if (!string.IsNullOrEmpty(configFile))
                {
                    if (string.IsNullOrEmpty(configNode))
                    {
                        configNode = "/";
                    }
                    XmlNode newNode = OptionHelper.LoadXmlNodeFromFile(configFile, configNode, false);
                    if (newNode != null)
                    {
                        if (configFiles != null)
                        {
                            configFiles.Add(configFile);
                        }
                        setting.Merge(Create(parent, newNode, @readonly, searchPath, configFiles));
                    }
                }
            }
            return setting;
        }

        /// <summary>
        /// 创建选项
        /// </summary>
        /// <param name="fileName">XML文件</param>
        /// <param name="readonly">是否只读</param>
        /// <param name="searchPath">XML搜索目录列表</param>
        /// <param name="configFiles">如果有子选项文件，则添加到此列表</param>
        /// <returns>选项节</returns>
        internal static XmlOption Create(string fileName, bool @readonly, string[] searchPath, List<string> configFiles)
        {
            fileName = OptionHelper.SearchOptionFile(fileName, searchPath);
            if (string.IsNullOrEmpty(fileName))
            {
                return null;
            }
            XmlNode xmlNode = OptionHelper.LoadXmlNodeFromFile(fileName, "/", false);
            if (xmlNode == null)
            {
                return null;
            }
            if (searchPath == null || searchPath.Length <= 0)
            {
                searchPath = OptionHelper.OptionFileDefaultSearchPath;
            }
            string[] newSearchPath = new string[searchPath.Length + 1];
            newSearchPath[0] = Path.GetDirectoryName(fileName);
            searchPath.CopyTo(newSearchPath, 1);
            return Create(null, xmlNode, @readonly, newSearchPath, configFiles);
        }

        /// <summary>
        /// 创建选项
        /// </summary>
        /// <param name="fileName">XML文件</param>
        /// <param name="readonly">是否只读</param>
        /// <returns>选项节</returns>
        internal static XmlOption Create(string fileName, bool @readonly)
        {
            return Create(fileName, @readonly, OptionHelper.OptionFileDefaultSearchPath, null);
        }

        /// <summary>
        /// 创建选项
        /// </summary>
        /// <param name="fileName">XML文件</param>
        /// <returns>选项节</returns>
        internal static XmlOption Create(string fileName)
        {
            return Create(fileName, true);
        }
    }
}