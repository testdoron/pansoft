using System;
using Gean;

namespace Pansoft.Common.Options
{
    /// <summary>
    ///  ѡ������Ե�ʵ��
    /// </summary>
    public abstract class OptionSection : IOptionSection
    {
        /// <summary>
        /// �������췽��
        /// </summary>
        /// <param name="properties">���Լ���</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        protected OptionSection(OptionValueCollection optionValues, bool readonlyFlag)
        {
            _optionValues = optionValues;
            _readonly = readonlyFlag;
        }

        /// <summary>
        /// �Ƿ�ֻ��
        /// </summary>
        protected bool _readonly;

        /// <summary>
        /// ���Լ���
        /// </summary>
        protected OptionValueCollection _optionValues;

        /// <summary>
        /// ����ѡ������ʵ��
        /// </summary>
        /// <param name="properties">���Լ���</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>OptionProperty</returns>
        protected abstract OptionSection CreateOptionSection(OptionValueCollection properties, bool @readonly);

        /// <summary>
        /// ����ѡ������ʵ��
        /// </summary>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>OptionProperty</returns>
        protected virtual OptionSection CreateOptionSection(bool @readonly)
        {
            return this.CreateOptionSection(new OptionValueCollection(), @readonly);
        }

        /// <summary>
        /// ����ѡ��ֵ
        /// </summary>
        /// <param name="name">ѡ��ֵ��</param>
        /// <param name="value">ѡ��ֵ</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>OptionValue</returns>
        protected abstract OptionValue CreateOptionValue(string name, string value, bool @readonly);

        /// <summary>
        /// ��ǰѡ��������Ƿ�ֻ��
        /// </summary>
        public virtual bool ReadOnly
        {
            get { return this._readonly; }
        }

        /// <summary>
        /// ѡ��ڵ����Ը���
        /// </summary>
        public virtual int Count
        {
            get { return this._optionValues.Count; }
        }

        /// <summary>
        /// ��ȡ/��������ֵ(����������)
        /// </summary>
        /// <param name="propertyName">������</param>
        public virtual OptionValue this[string propertyName]
        {
            get { return this._optionValues[propertyName]; }
            set
            {
                if (this.ReadOnly)
                {
                    throw new OptionException("ѡ������ֻ��");
                }
                this._optionValues.Set(propertyName, value);
            }
        }

        /// <summary>
        /// ��ȡ����ֵ(������������)
        /// </summary>
        /// <param name="propertyIndex">��������</param>
        public virtual OptionValue this[int propertyIndex]
        {
            get { return this._optionValues[propertyIndex]; }
        }

        /// <summary>
        /// ���Ի�ȡĳ����ֵ
        /// </summary>
        /// <param name="propertyName">������</param>
        /// <returns>����ֵ</returns>
        public virtual string TryGetPropertyValue(string propertyName)
        {
            OptionValue value = this._optionValues[propertyName];
            if (value != null)
            {
                return value.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ���Ի�ȡĳ����ֵ��ת����ָ������
        /// </summary>
        /// <typeparam name="T">ת����ָ��������</typeparam>
        /// <param name="propertyName">������</param>
        /// <returns>ָ�����͵�ʵ��</returns>
        public virtual T TryGetPropertyValue<T>(string propertyName)
        {
            return this.TryGetPropertyValue<T>(propertyName, default(T));
        }

        /// <summary>
        /// ���Ի�ȡĳ����ֵ��ת����ָ������
        /// </summary>
        /// <typeparam name="T">ת����ָ��������</typeparam>
        /// <param name="propertyName">������</param>
        /// <param name="defaultValue">ȱʡֵ</param>
        /// <returns>ָ�����͵�ʵ��</returns>
        public virtual T TryGetPropertyValue<T>(string propertyName, T defaultValue)
        {
            OptionValue value = this._optionValues[propertyName];
            if (value != null)
            {
                return (value as IConverting).TryToObject<T>(defaultValue);
            }
            else
            {
                return defaultValue;
            }
        }

        internal virtual OptionSection Merge(OptionSection property)
        {
            foreach (string key in property._optionValues.Keys)
            {
                switch (key)
                {
                    case Option.OptionFilePropertyName:
                    case Option.OptionNodePropertyName:
                        break;
                    default:
                        this._optionValues.Set(property[key].Clone());
                        break;
                }
            }
            return this;
        }

        #region Clone

        /// <summary>
        /// ��¡ѡ������
        /// </summary>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <param name="deep">�Ƿ���ȸ���</param>
        /// <returns>OptionProperty</returns>
        public virtual OptionSection Clone(bool @readonly, bool deep)
        {
            OptionSection property = this.CreateOptionSection(@readonly);
            if (deep)
            {
                foreach (OptionValue settingValue in this._optionValues.Values)
                {
                    property._optionValues.Add(settingValue.Clone(@readonly));
                }
            }
            else
            {
                property._optionValues = this._optionValues;
            }
            return property;
        }

        #endregion Clone

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return this.Clone(this.ReadOnly, true);
        }

        #endregion

        #region IOptionProperty Members

        bool IOptionSection.ReadOnly
        {
            get { return this.ReadOnly; }
        }

        int IOptionSection.Count
        {
            get { return this.Count; }
        }

        IOptionValue IOptionSection.this[string propertyName]
        {
            get { return this[propertyName]; }
        }

        IOptionValue IOptionSection.this[int propertyIndex]
        {
            get { return this[propertyIndex]; }
        }

        IOptionSection IOptionSection.Clone(bool @readonly, bool deep)
        {
            return this.Clone(@readonly, deep);
        }

        string IOptionSection.TryGetPropertyValue(string propertyName)
        {
            return this.TryGetPropertyValue(propertyName);
        }

        T IOptionSection.TryGetPropertyValue<T>(string propertyName)
        {
            return this.TryGetPropertyValue<T>(propertyName);
        }

        T IOptionSection.TryGetPropertyValue<T>(string propertyName, T defaultValue)
        {
            return this.TryGetPropertyValue<T>(propertyName, defaultValue);
        }

        #endregion
    }
}