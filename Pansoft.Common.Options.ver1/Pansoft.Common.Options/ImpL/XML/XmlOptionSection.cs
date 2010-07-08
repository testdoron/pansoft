using System.Text;
using System.Xml;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// 使用XML实现选项节属性：<see cref="OptionSection"/>
    /// </summary>
    public class XmlOptionSection : OptionSection
    {
        #region constructor

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="properties">属性集合</param>
        /// <param name="readonly">是否只读</param>
        protected XmlOptionSection(OptionValueCollection properties, bool @readonly) : base(properties, @readonly) { }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="readonly">是否只读</param>
        public XmlOptionSection(bool @readonly) : base(new OptionValueCollection(), @readonly) { }

        /// <summary>
        /// 使用XmlNode初始化
        /// </summary>
        /// <param name="xmlNode">XmlNode</param>
        /// <param name="readonly">是否只读</param>
        public XmlOptionSection(XmlNode xmlNode, bool @readonly)
            : this(@readonly)
        {
            this.InitData(xmlNode, @readonly);
        }

        #endregion

        #region private members

        /// <summary>
        /// 初始化XML结点
        /// </summary>
        private void InitData(XmlNode xmlNode, bool @readonly)
        {
            foreach (XmlNode attribute in xmlNode.Attributes)
            {
                string name = attribute.Name;
                string @value = attribute.Value;
                _optionValues.Set(new XmlOptionValue(name, @value, @readonly));
            }
        }

        #endregion

        /// <summary>
        /// 创建选项属性实例
        /// </summary>
        /// <param name="properties">属性集合</param>
        /// <param name="readonly">是否只读</param>
        /// <returns>OptionSection</returns>
        protected override OptionSection CreateOptionSection(OptionValueCollection properties, bool @readonly)
        {
            return new XmlOptionSection(properties, @readonly);
        }

        /// <summary>
        /// 创建选项值
        /// </summary>
        /// <param name="name">选项值名</param>
        /// <param name="value">选项值</param>
        /// <param name="readonly">是否只读</param>
        /// <returns>SettingValue</returns>
        protected override OptionValue CreateOptionValue(string name, string value, bool @readonly)
        {
            return new XmlOptionValue(name, value, @readonly);
        }

        /// <summary>
        /// 转换成字符串格式
        /// </summary>
        /// <returns>字符串</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (OptionValue value in _optionValues.Values)
            {
                sb.AppendFormat(" {0}", value);
            }
            if (sb.Length > 0)
            {
                sb.Remove(0, 1);
            }
            return sb.ToString();
        }
    }
}