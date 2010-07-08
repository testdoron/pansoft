using System;
using System.Text;
using Gean;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// ѡ��ڵ�ʵ��
    /// </summary>
    public abstract class Option : IOption
    {
        #region static fields

        /// <summary>
        /// ѡ��������ļ�������
        /// </summary>
        public const string OptionFilePropertyName = "optionFile";
        /// <summary>
        /// ѡ��������ļ��Ľڵ���
        /// </summary>
        public const string OptionNodePropertyName = "optionNode";
        /// <summary>
        /// ѡ���ʵ�����Ƶ�������
        /// </summary>
        public const string OptionNamePropertyName = "name";

        #endregion static fields

        #region constructor

        /// <summary>
        /// �������췽��
        /// </summary>
        protected Option()
        {
        }

        #endregion constructor

        #region fields

        /// <summary>
        /// �Ƿ�ֻ��
        /// </summary>
        private bool @readonly;
        /// <summary>
        /// ��ѡ���ʵ������
        /// </summary>
        private string settingName;
        /// <summary>
        /// ѡ��ֵ
        /// </summary>
        protected OptionValue value;
        /// <summary>
        /// ��ѡ���
        /// </summary>
        protected Option parent;
        /// <summary>
        /// ѡ������
        /// </summary>
        protected OptionSection property;
        /// <summary>
        /// ��ѡ���
        /// </summary>
        protected OptionCollection childSettings;
        /// <summary>
        /// ѡ��������
        /// </summary>
        protected OptionCollection operatorSettings;

        #endregion fields

        #region abstract methods

        /// <summary>
        /// ����ѡ��ʵ��
        /// </summary>
        /// <returns></returns>
        protected abstract Option CreateOption();

        /// <summary>
        /// ����ѡ��ֵ
        /// </summary>
        /// <param name="name">ѡ��ֵ��</param>
        /// <param name="value">ѡ��ֵ</param>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>SettingValue</returns>
        protected abstract OptionValue CreateOptionValue(string name, string value, bool @readonly);

        /// <summary>
        /// ����ѡ��ڵ�ʵ��
        /// </summary>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <returns>SettingProperty</returns>
        protected abstract OptionSection CreateOptionSection(bool @readonly);

        /// <summary>
        /// ת�����ַ���
        /// </summary>
        /// <param name="sb"><see cref="StringBuilder"/></param>
        /// <param name="layerIndex">�������</param>
        protected abstract void ToString(StringBuilder sb, int layerIndex);

        #endregion abstract methods

        #region members

        /// <summary>
        /// ����ѡ���ʵ��
        /// </summary>
        /// <param name="setting">�����Ƶ�ѡ���</param>
        /// <param name="deep">�Ƿ���ȸ���</param>
        /// <returns>ѡ���</returns>
        protected virtual Option CreateOptionSetting(Option setting, bool deep)
        {
            Option newSetting = this.CreateOption();
            newSetting.@readonly = setting.ReadOnly;
            newSetting.settingName = setting.settingName;
            if (deep)
            {
                newSetting.value = setting.Value.Clone();
                newSetting.property = setting.Property.Clone(this.@readonly, deep);
                newSetting.childSettings = setting.childSettings.Clone();
                newSetting.operatorSettings = setting.operatorSettings.Clone();
            }
            else
            {
                newSetting.value = setting.Value;
                newSetting.property = setting.Property;
                newSetting.childSettings = setting.childSettings;
                newSetting.operatorSettings = setting.operatorSettings;
            }
            return newSetting;
        }

        /// <summary>
        /// ��ǰѡ����Ƿ�ֻ��
        /// </summary>
        public virtual bool ReadOnly
        {
            get { return this.@readonly; }
            protected set { this.@readonly = value; }
        }

        /// <summary>
        /// ��ѡ��ڵ���
        /// </summary>
        public virtual string Name
        {
            get { return this.Value.Name; }
        }

        /// <summary>
        /// ��ѡ���ʵ������
        /// </summary>
        public virtual string SettingName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.settingName))
                {
                    return this.settingName;
                }
                else
                {
                    return this.Name;
                }
            }
            protected set { this.settingName = value; }
        }

        /// <summary>
        /// ��ѡ��ڵ���/ֵ
        /// </summary>
        public virtual OptionValue Value
        {
            get { return this.value; }
            set
            {
                if (this.ReadOnly)
                {
                    throw new OptionException("ѡ���ֻ��");
                }
                this.value = value;
            }
        }

        /// <summary>
        /// ������ѡ��ڵĸ�ѡ���
        /// </summary>
        public virtual Option Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        /// <summary>
        /// ��ѡ��ڰ�������ѡ�����Ŀ
        /// </summary>
        public virtual int Children
        {
            get { return this.childSettings.Count; }
        }

        /// <summary>
        /// ѡ�������
        /// </summary>
        public virtual OptionSection Property
        {
            get { return this.property; }
            set
            {
                if (this.ReadOnly)
                {
                    throw new OptionException("ѡ���ֻ��");
                }
                this.property = value;
            }
        }

        /// <summary>
        /// ��ȡ��ѡ���ļ�
        /// </summary>
        public virtual string OptionFile
        {
            get { return this.Property.TryGetPropertyValue(OptionFilePropertyName); }
        }

        /// <summary>
        /// ��ȡ��ѡ������ļ��еĽڵ�
        /// </summary>
        public virtual string OptionNode
        {
            get { return this.Property.TryGetPropertyValue(OptionNodePropertyName); }
        }

        /// <summary>
        /// �˽��Ƿ�Ϊѡ�������
        /// </summary>
        protected virtual OptionOperatorEnum SettingOperator
        {
            get { return Converting.StringToEnum<OptionOperatorEnum>(this.SettingName); }
        }

        /// <summary>
        /// ��ȡ/������ѡ���
        /// </summary>
        /// <param name="childSettingName">��ѡ�����</param>
        /// <remarks>
        /// ��������ڣ�������<c>null</c><br />
        /// �������ʱ������ͬ�Ľڣ����滻
        /// </remarks>
        public virtual Option this[string childSettingName]
        {
            get { return this.childSettings[childSettingName]; }
        }

        /// <summary>
        /// ��ȡ��ѡ���
        /// </summary>
        /// <param name="childSettingIndex">��ѡ���˳��</param>
        /// <remarks>
        /// ��������ڣ�������null
        /// </remarks>
        public virtual Option this[int childSettingIndex]
        {
            get { return this.childSettings[childSettingIndex]; }
        }

        /// <summary>
        /// ��ȡ������ѡ���
        /// </summary>
        /// <returns>ѡ�������</returns>
        public virtual Option[] GetChildSettings()
        {
            return this.childSettings.CopyToArray();
        }

        /// <summary>
        /// ��XPath��ʽ��ȡѡ���
        /// </summary>
        /// <param name="xpath">XPath</param>
        /// <returns>ѡ���</returns>
        /// <remarks>
        /// XPathΪ����XML��XPath������<c>framework/modules/module"</c><br />
        /// �������ͬ��ѡ��ڣ��򷵻ص�һ��ѡ���
        /// </remarks>
        public virtual Option GetChildSetting(string xpath)
        {
            string[] settingName = null;
            if (xpath != null)
            {
                if (xpath.StartsWith("/"))
                {
                    xpath = xpath.Substring(1);
                }
                settingName = xpath.Split('/');
            }
            return this.GetChildSetting(settingName);
        }

        /// <summary>
        /// ���༶��ʽ��ȡѡ���
        /// </summary>
        /// <param name="settingName">�༶��ѡ�����</param>
        /// <returns>ѡ���</returns>
        /// <remarks>
        /// �༶��ѡ�����������������ѡ�
        ///		<code>
        ///			&lt;app1&gt;
        ///				&lt;app2&gt;
        ///					&lt;app3&gt;&lt;/app3&gt;
        ///				&lt;/app2&gt;
        ///			&lt;/app1&gt;
        ///		</code>
        ///	��˳���룬����<c>GetChildSetting("app1", "app2", "app3")</c>����ʱ������Ϊ<c>app3</c>��ѡ���<br />
        /// "."��ʾ��ǰѡ��ڣ�".."��ʾ�ϼ�ѡ���
        /// </remarks>
        public virtual Option GetChildSetting(params string[] settingName)
        {
            Option setting = this;
            if (settingName != null && settingName.Length > 0)
            {
                for (int i = 0; setting != null && i < settingName.Length; i++)
                {
                    string name = settingName[i];
                    switch (name)
                    {
                        case ".":
                        case null:
                            break;
                        case "..":
                            setting = setting.parent;
                            break;
                        default:
                            setting = setting[name];
                            break;
                    }
                }
            }
            return setting;
        }

        /// <summary>
        /// ��¡��ѡ���
        /// </summary>
        /// <param name="readonly">�Ƿ�ֻ��</param>
        /// <param name="deep">�Ƿ����εĿ�¡</param>
        /// <returns>ѡ���</returns>
        public virtual Option Clone(bool @readonly, bool deep)
        {
            Option setting = this.CreateOptionSetting(this, deep);
            setting.@readonly = @readonly;
            return setting;
        }

        /// <summary>
        /// ��¡��ѡ���
        /// </summary>
        /// <returns>ѡ���</returns>
        public virtual Option Clone()
        {
            return this.Clone(this.ReadOnly, true);
        }

        /// <summary>
        /// �ϲ�ѡ���
        /// </summary>
        /// <param name="setting">�豻�ϲ���ѡ���</param>
        /// <returns>�ϲ����ѡ���</returns>
        public virtual Option Merge(Option setting)
        {
            if (setting == null || string.Compare(this.Name, setting.Name, true) != 0)
            {
                return this;
            }
            this.Property.Merge(setting.Property);
            this.value = setting.Value.Clone(this.ReadOnly);

            foreach (Option optionSetting in setting.operatorSettings.Values)
            {
                this.operatorSettings.Add(optionSetting).Parent = this;
            }

            Compile(this, setting.operatorSettings);
            return this;
        }

        /// <summary>
        /// ���뱾ѡ��ڣ���ִ��һЩѡ���������ѡ�������ѡ�����ִ�б�������ſ���ʹ��
        /// </summary>
        /// <param name="current">��ǰѡ���</param>
        /// <param name="settings">ѡ�������</param>
        /// <returns>������ѡ���</returns>
        protected static Option Compile(Option current, OptionCollection settings)
        {
            OptionCollection currentSettings = current.childSettings;
            if (settings.Count > 0)
            {
                for (int i = 0; i < settings.Count; i++)
                {
                    Option setting = settings[i];
                    switch (setting.SettingOperator)
                    {
                        case OptionOperatorEnum.Add:
                            if (currentSettings.Contains(setting.Name))
                            {
                                throw new OptionException(string.Format("�Ѵ�����ѡ��� {0}", setting.Name));
                            }
                            else
                            {
                                currentSettings.Add(setting).Parent = current;
                            }
                            break;
                        case OptionOperatorEnum.Remove:
                            currentSettings.Remove(setting.Name);
                            break;
                        case OptionOperatorEnum.Move:
                            Option moveSetting = currentSettings[setting.Name];
                            if (moveSetting != null)
                            {
                                currentSettings.Remove(moveSetting.Name);
                                currentSettings.Add(moveSetting);
                            }
                            break;
                        case OptionOperatorEnum.Clear:
                            currentSettings.Clear();
                            break;
                        case OptionOperatorEnum.Update:
                            if (currentSettings.Contains(setting.Name))
                            {
                                currentSettings[setting.Name].Merge(setting);
                            }
                            break;
                        case OptionOperatorEnum.Set:
                            if (currentSettings.Contains(setting.Name))
                            {
                                currentSettings[setting.Name].Merge(setting);
                            }
                            else
                            {
                                currentSettings.Add(setting).Parent = current;
                            }
                            break;
                        default:
                            if (currentSettings.Contains(setting.Name))
                            {
                                currentSettings[setting.Name].Merge(setting);
                            }
                            else
                            {
                                currentSettings.Add(setting).Parent = current;
                            }
                            break;
                    }
                }
            }
            return current;
        }

        /// <summary>
        /// ��ȡ��ѡ���
        /// </summary>
        /// <returns>ѡ���</returns>
        public virtual Option GetRootSetting()
        {
            Option root = this;
            while (root.parent != null)
            {
                root = root.parent;
            }
            return root;
        }

        /// <summary>
        /// ת�����ַ�����ʽ
        /// </summary>
        /// <returns>�ַ���</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.ToString(sb, 0);
            return sb.ToString();
        }

        #endregion members

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return this.Clone(this.ReadOnly, true);
        }

        #endregion

        #region IOptionSetting Members

        bool IOption.ReadOnly
        {
            get { return this.ReadOnly; }
        }

        string IOption.Name
        {
            get { return this.Name; }
        }

        string IOption.OptionName
        {
            get { return this.SettingName; }
        }

        IOptionValue IOption.Value
        {
            get { return this.Value; }
        }

        IOption IOption.Parent
        {
            get { return this.Parent; }
        }

        int IOption.Children
        {
            get { return this.Children; }
        }

        IOptionSection IOption.OptionSection
        {
            get { return this.Property; }
        }

        IOption IOption.this[string childSettingName]
        {
            get { return this[childSettingName]; }
        }

        IOption IOption.this[int childSettingIndex]
        {
            get { return this[childSettingIndex]; }
        }

        IOption[] IOption.GetChildOptions()
        {
            return this.GetChildSettings();
        }

        IOption IOption.GetChildOption(string xpath)
        {
            return this.GetChildSetting(xpath);
        }

        IOption IOption.GetChildOption(params string[] settingName)
        {
            return this.GetChildSetting(settingName);
        }

        IOption IOption.Clone(bool @readonly, bool deep)
        {
            return this.Clone(@readonly, deep);
        }

        IOption IOption.GetRootOption()
        {
            return this.GetRootSetting();
        }

        void IOption.Merge(IOption setting)
        {
            this.Merge((Option)setting);
        }

        #endregion
    }
}