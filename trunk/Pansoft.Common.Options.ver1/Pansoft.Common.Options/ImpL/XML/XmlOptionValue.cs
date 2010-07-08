using System.Web;
using System.Xml;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// 选项值，使用XML实现<see cref="OptionValue"/>
    /// </summary>
    public class XmlOptionValue : OptionValue
    {
        #region constructor

        /// <summary>
        /// 使用name/value的形式初始化
        /// </summary>
        /// <param name="name">选项值名</param>
        /// <param name="value">选项值</param>
        /// <param name="readonly">是否只读</param>
        public XmlOptionValue(string name, string @value, bool @readonly) : base(name, @value, @readonly) { }

        /// <summary>
        /// 使用XmlNode初始化
        /// </summary>
        /// <param name="xmlNode">XmlNode</param>
        /// <param name="readonly">是否只读</param>
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
        /// 创建选项值实例
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
        /// 转换成字符串格式
        /// </summary>
        /// <returns>字符串</returns>
        public override string ToString()
        {
            return this.Name + " >>> " + this.Value;//string.Format("{0}=\"{1}\"", this.Name, HttpUtility.HtmlAttributeEncode(this.Value));
        }
    }
}