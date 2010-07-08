using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// XML��ʽʵ��ѡ�� <see cref="XmlOption"/>
    /// </summary>
    public class XmlOption : Option
    {
        #region constructor

        /// <summary>
        /// ���췽��
        /// </summary>
        protected XmlOption() { }

        #endregion

        /// <summary>
        /// ����ѡ��ʵ��
        /// </summary>
        /// <returns></returns>
        protected override Option CreateOption()
        {
            return new XmlOption();
        }

        /// <summary>
        /// ����ѡ��ֵ
        /// </summary>
        /// <param name="name">ѡ��ֵ��</param>
        /// <param name="value">ѡ��ֵ</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>OptionValue</returns>
        protected override OptionValue CreateOptionValue(string name, string value, bool @readonly)
        {
            return new XmlOptionValue(name, value, @readonly);
        }

        /// <summary>
        /// ����ѡ������ʵ��
        /// </summary>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>OptionSection</returns>
        protected override OptionSection CreateOptionSection(bool @readonly)
        {
            return new XmlOptionSection(@readonly);
        }

        /// <summary>
        /// ת�����ַ���
        /// </summary>
        /// <param name="sb"><see cref="StringBuilder"/></param>
        /// <param name="layerIndex">�������</param>
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
        /// ����ѡ��
        /// </summary>
        /// <param name="parent">��ѡ���</param>
        /// <param name="xmlNode">XML��</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <param name="searchPath">XML����Ŀ¼�б�</param>
        /// <param name="configFiles">�������ѡ���ļ�������ӵ����б�</param>
        internal static XmlOption Create(XmlOption parent, XmlNode xmlNode, bool @readonly, string[] searchPath, List<string> configFiles)
        {
            if (xmlNode.NodeType != XmlNodeType.Element)
            {
                throw new OptionException("�������Ƿ�Ԫ��");
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
                    throw new OptionException("ѡ������δ�������ԣ�" + OptionNamePropertyName);
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
        /// ����ѡ��
        /// </summary>
        /// <param name="fileName">XML�ļ�</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <param name="searchPath">XML����Ŀ¼�б�</param>
        /// <param name="configFiles">�������ѡ���ļ�������ӵ����б�</param>
        /// <returns>ѡ���</returns>
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
        /// ����ѡ��
        /// </summary>
        /// <param name="fileName">XML�ļ�</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>ѡ���</returns>
        internal static XmlOption Create(string fileName, bool @readonly)
        {
            return Create(fileName, @readonly, OptionHelper.OptionFileDefaultSearchPath, null);
        }

        /// <summary>
        /// ����ѡ��
        /// </summary>
        /// <param name="fileName">XML�ļ�</param>
        /// <returns>ѡ���</returns>
        internal static XmlOption Create(string fileName)
        {
            return Create(fileName, true);
        }
    }
}