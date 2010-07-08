using System.Collections.Generic;
using Gean;
namespace Pansoft.Common.Options
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
        /// <param name="setting">ѡ���</param>
        /// <returns>ѡ���</returns>
        public virtual Option Add(Option setting)
        {
            this.Add(setting.Name, setting);
            return setting;
        }

        /// <summary>
        /// ���/�滻ѡ��ڣ�����������滻��
        /// </summary>
        /// <param name="setting">ѡ���</param>
        public virtual Option Set(Option setting)
        {
            Converting.StringToEnum<OptionOperatorEnum>("");
            this.Set(setting.Name, setting);
            return setting;
        }

        /// <summary>
        /// ��ȸ��Ƽ���
        /// </summary>
        /// <returns>���ƺ�ļ���</returns>
        public virtual OptionCollection Clone()
        {
            OptionCollection collection = new OptionCollection(this.UniqueKey);
            foreach (Option setting in this.Values)
            {
                collection.Add(setting.Clone()).Parent = setting.Parent;
            }
            return collection;
        }
    }
}