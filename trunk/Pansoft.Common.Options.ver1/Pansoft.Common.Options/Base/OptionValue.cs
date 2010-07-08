using System;
using Gean;


namespace Pansoft.Common.Options
{
    /// <summary>
    /// ѡ��ֵ��ʵ�֣��ṩһЩȱʡ��ʵ��
    /// </summary>
    public abstract class OptionValue : Converting, IOptionValue
    {
        /// <summary>
        /// �������췽��
        /// </summary>
        /// <param name="name">ѡ��ֵ��</param>
        /// <param name="value">ѡ��ֵ</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        protected OptionValue(string name, string value, bool @readonly)
        {
            this._name = name;
            this._value = @value;
            this._readonly = @readonly;
        }

        /// <summary>
        /// ѡ��ֵ��
        /// </summary>
        protected string _name;

        /// <summary>
        /// ѡ��ֵ
        /// </summary>
        protected string _value;

        /// <summary>
        /// �Ƿ�ֻ��
        /// </summary>
        protected bool _readonly;

        /// <summary>
        /// ��ת����ֵ
        /// </summary>
        protected override string ConvertingValue
        {
            get { return this.Value; }
        }

        /// <summary>
        /// ����ѡ��ֵʵ��
        /// </summary>
        /// <param name="name">ѡ��ֵ��</param>
        /// <param name="value">ѡ��ֵ</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>SettingValue</returns>
        protected abstract OptionValue CreateOptionValue(string name, string value, bool @readonly);

        /// <summary>
        /// ѡ��ֵ��
        /// </summary>
        public virtual string Name
        {
            get { return this._name; }
            set
            {
                if (this.ReadOnly)
                {
                    throw new OptionException("ѡ��ֵֻ��");
                }
                else
                {
                    this._name = value;
                }
            }
        }

        /// <summary>
        /// ѡ��ֵ
        /// </summary>
        public virtual string Value
        {
            get { return this._value; }
            set
            {
                if (this.ReadOnly)
                {
                    throw new OptionException("ѡ��ֵֻ��");
                }
                else
                {
                    this._value = value;
                }
            }
        }

        /// <summary>
        /// ��ǰѡ��ֵ�Ƿ�ֻ��
        /// </summary>
        public virtual bool ReadOnly
        {
            get { return this._readonly; }
        }

        internal virtual void SetName(string name)
        {
            this._name = name;
        }

        #region Clone

        /// <summary>
        /// ��¡ѡ��ֵ
        /// </summary>
        /// <returns>SettingValue</returns>
        public virtual OptionValue Clone()
        {
            return this.Clone(this.ReadOnly);
        }

        /// <summary>
        /// ��¡ѡ��ֵ
        /// </summary>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>SettingValue</returns>
        public virtual OptionValue Clone(bool @readonly)
        {
            return this.CreateOptionValue(this.Name, this.Value, @readonly);
        }

        #endregion Clone

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        IOptionValue IOptionValue.Clone(bool @readonly)
        {
            return this.Clone();
        }

        #endregion

        #region ISettingValue Members

        bool IOptionValue.ReadOnly
        {
            get { return this.ReadOnly; }
        }

        string IOptionValue.Name
        {
            get { return this.Name; }
        }

        string IOptionValue.Value
        {
            get { return this.Value; }
        }

        #endregion
    }
}
