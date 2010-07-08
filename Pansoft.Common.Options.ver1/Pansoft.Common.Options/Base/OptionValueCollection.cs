using System.Collections.Generic;
using Gean;
namespace Pansoft.Common.Options
{
    /// <summary>
    /// ѡ��ֵ����
    /// </summary>
    public class OptionValueCollection : IndexCollection<OptionValue>
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public OptionValueCollection() : base(true) { }

        /// <summary>
        /// ���ѡ��ֵ
        /// </summary>
        /// <param name="value">ѡ��ֵ</param>
        /// <returns>ѡ��ֵ</returns>
        public virtual OptionValue Add(OptionValue value)
        {
            this.Add(value.Name, value);
            return value;
        }

        /// <summary>
        /// ���/�滻ѡ��ֵ������������滻��
        /// </summary>
        /// <param name="value">ѡ��ֵ</param>
        public virtual void Set(OptionValue value)
        {
            this.Set(value.Name, value);
        }
    }
}