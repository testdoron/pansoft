using System.Text;
using System.Xml;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// ʹ��XMLʵ��ѡ������ԣ�<see cref="OptionSection"/>
    /// </summary>
    public class XmlOptionSection : OptionSection
    {
        #region constructor

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="properties">���Լ���</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        protected XmlOptionSection(OptionValueCollection properties, bool @readonly) : base(properties, @readonly) { }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        public XmlOptionSection(bool @readonly) : base(new OptionValueCollection(), @readonly) { }

        /// <summary>
        /// ʹ��XmlNode��ʼ��
        /// </summary>
        /// <param name="xmlNode">XmlNode</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        public XmlOptionSection(XmlNode xmlNode, bool @readonly)
            : this(@readonly)
        {
            this.InitData(xmlNode, @readonly);
        }

        #endregion

        #region private members

        /// <summary>
        /// ��ʼ��XML���
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
        /// ����ѡ������ʵ��
        /// </summary>
        /// <param name="properties">���Լ���</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>OptionSection</returns>
        protected override OptionSection CreateOptionSection(OptionValueCollection properties, bool @readonly)
        {
            return new XmlOptionSection(properties, @readonly);
        }

        /// <summary>
        /// ����ѡ��ֵ
        /// </summary>
        /// <param name="name">ѡ��ֵ��</param>
        /// <param name="value">ѡ��ֵ</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>SettingValue</returns>
        protected override OptionValue CreateOptionValue(string name, string value, bool @readonly)
        {
            return new XmlOptionValue(name, value, @readonly);
        }

        /// <summary>
        /// ת�����ַ�����ʽ
        /// </summary>
        /// <returns>�ַ���</returns>
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