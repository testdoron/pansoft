using System.Collections.Generic;
using Gean;
namespace Pansoft.CQMS.Options
{
    /// <summary>
    /// ѡ��ڼ���
    /// </summary>
    public class OptionCollection : IndexCollection<Option>
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="uniqueKey">��ֵ�Ƿ�Ψһ</param>
        public OptionCollection(bool uniqueKey) : base(uniqueKey) { }

        /// <summary>
        /// ���ѡ���
        /// </summary>
        /// <param name="option">ѡ���</param>
        /// <returns>ѡ���</returns>
        public virtual Option Add(Option option)
        {
            this.Add(option.Name, option);
            return option;
        }

        /// <summary>
        /// ���/�滻ѡ��ڣ�����������滻��
        /// </summary>
        /// <param name="option">ѡ���</param>
        public virtual Option Set(Option option)
        {
            this.Set(option.Name, option);
            return option;
        }

        /// <summary>
        /// ��ȸ��Ƽ���
        /// </summary>
        /// <returns>���ƺ�ļ���</returns>
        public virtual OptionCollection Clone()
        {
            OptionCollection collection = new OptionCollection(this.UniqueKey);
            foreach (Option option in this.Values)
            {
                collection.Add(option.Clone());
            }
            return collection;
        }
    }
}