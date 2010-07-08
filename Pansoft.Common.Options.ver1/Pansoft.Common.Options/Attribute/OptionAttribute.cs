using System;
using System.Reflection;
using Gean;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// ѡ��Ԫ����
    /// </summary>
    /// <remarks>
    /// ����ṩѡ���ļ���ַ��ѡ���������һ�ַ�ʽ<br />
    /// �÷�����Ӧ�ó������������Ԫ���ԣ�ע��Priority�������1000����������
    ///		<code>
    ///			[assembly: Option(RealType=typeof(Pansoft.Common.Options.OptionManager), Priority = 1000)]
    ///		</code>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class OptionAttribute : Attribute
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public OptionAttribute() { }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="optionFile">ָ��ѡ���ļ���ַ</param>
        public OptionAttribute(string optionFile)
        {
            this._optionFile = optionFile;
        }

        private string _optionFile = null;
        private int _priority = 0;
        private Type _realType = null;
        private string _typeName = null;

        /// <summary>
        /// ��ȡ/����ѡ���ļ�
        /// </summary>
        public string OptionFile
        {
            get { return this._optionFile; }
            set { this._optionFile = value; }
        }

        /// <summary>
        /// ��ȡ/���ô�ѡ������ȼ�
        /// </summary>
        public int Priority
        {
            get { return this._priority; }
            set { this._priority = value; }
        }

        /// <summary>
        /// ��ȡ/���ô�ѡ���Ӧ��ѡ�����������
        /// </summary>
        public Type RealType
        {
            get { return this._realType; }
            set { this._realType = value; }
        }

        /// <summary>
        /// ��ȡ/���ô�ѡ���������������
        /// </summary>
        public string TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        /// <summary>
        /// �ӳ����л��ѡ��Ԫ����
        /// </summary>
        /// <param name="assemblies">���򼯣����Ϊnull����ӵ�ǰӦ�ó������л�ȡ����������г���</param>
        /// <returns>�ҵ���ѡ��Ԫ���Ե�����</returns>
        public static OptionAttribute[] GetOptionAttributeFromAssembly(Assembly[] assemblies)
        {
            return UtilityType.GetAttributeFromAssembly<OptionAttribute>(assemblies);
        }
    }
}