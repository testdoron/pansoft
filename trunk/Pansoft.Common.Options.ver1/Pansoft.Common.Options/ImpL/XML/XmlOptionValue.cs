using System.Web;
using System.Xml;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// ѡ��ֵ��ʹ��XMLʵ��<see cref="OptionValue"/>
    /// </summary>
    public class XmlOptionValue : OptionValue
    {
        #region constructor

        /// <summary>
        /// ʹ��name/value����ʽ��ʼ��
        /// </summary>
        /// <param name="name">ѡ��ֵ��</param>
        /// <param name="value">ѡ��ֵ</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        public XmlOptionValue(string name, string @value, bool @readonly) : base(name, @value, @readonly) { }

        /// <summary>
        /// ʹ��XmlNode��ʼ��
        /// </summary>
        /// <param name="xmlNode">XmlNode</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        public XmlOptionValue(XmlNode xmlNode, bool @readonly)
            : base(null, null, @readonly)
        {
            this.Name = xmlNode.Name;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Text)
                {
                    this.Value = node.Value;
                    break;
                }
            }
        }

        #endregion

        /// <summary>
        /// ����ѡ��ֵʵ��
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
        /// ת�����ַ�����ʽ
        /// </summary>
        /// <returns>�ַ���</returns>
        public override string ToString()
        {
            return this.Name + " >>> " + this.Value;//string.Format("{0}=\"{1}\"", this.Name, HttpUtility.HtmlAttributeEncode(this.Value));
        }
    }
}