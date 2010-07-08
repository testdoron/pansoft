using System;
using System.Reflection;
using Gean;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// ѡ���ļ�����
    /// </summary>
    /// <remarks>
    /// ����ṩѡ���ļ��ϲ���һ�ַ�ʽ<br />
    /// �÷�����Ӧ�ó������������Ԫ���ԣ�ע��OptionIndex���벻С��1000����������
    ///		<code>
    ///			[assembly: DevFxOptionFile(OptionFile="res://HTB.DevFx.Option.htb.devfx.config", OptionIndex = 1000)]
    ///		</code>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class OptionFileAttribute : Attribute
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="configFile">ָ��ѡ���ļ���ַ</param>
        /// <param name="fileInType">�����������Դ��ָ������Դ���ڵ�<see cref="Assembly"/></param>
        public OptionFileAttribute(string configFile, Type fileInType)
        {
            this.configFile = configFile;
            this.fileInType = fileInType;
        }

        internal OptionFileAttribute(string configFile, Type fileInType, int mergeIndex)
            : this(configFile, fileInType)
        {
            this.configIndex = mergeIndex;
        }

        private string configFile = null;
        private int configIndex = 1000;
        private Type fileInType = null;
        private string fileInTypeName = null;

        /// <summary>
        /// ��ȡ/����ѡ���ļ�������Ӳ���ļ������������ǰ׺
        /// </summary>
        /// <remarks>
        /// ������Դ��res:// <br />
        /// HTTP��Դ��http://
        /// </remarks>
        public string OptionFile
        {
            get { return this.configFile; }
            set { this.configFile = value; }
        }

        /// <summary>
        /// ��ȡ/���ô�ѡ��ϲ�ʱ��˳��
        /// </summary>
        public int OptionIndex
        {
            get { return this.configIndex; }
            set
            {
                if (value < 1000)
                {
                    throw new OptionException("ѡ���ļ�˳����С��1000");
                }
                this.configIndex = value;
            }
        }

        /// <summary>
        /// ��ȡ/���ô���Դ���ڵ�<see cref="Assembly"/>
        /// </summary>
        public Type FileInType
        {
            get { return this.fileInType; }
            set { this.fileInType = value; }
        }

        /// <summary>
        /// ��ȡ/���ô���Դ���ڵ�<see cref="Assembly"/>����
        /// </summary>
        public string FileInTypeName
        {
            get { return this.fileInTypeName; }
            set { this.fileInTypeName = value; }
        }

        /// <summary>
        /// ��ȡ����Դ���ڵ�<see cref="Assembly"/>
        /// </summary>
        /// <returns>Type</returns>
        public Type GetFileInType()
        {
            if (this.fileInType == null)
            {
                this.fileInType = UtilityType.CreateType(this.GetType().Assembly, this.fileInTypeName, false);
            }
            return this.fileInType;
        }

        /// <summary>
        /// �ӳ����л��Ԫ����
        /// </summary>
        /// <param name="assemblies">���򼯣����Ϊnull����ӵ�ǰӦ�ó������л�ȡ����������г���</param>
        /// <returns>�ҵ���Ԫ���Ե�����</returns>
        public static OptionFileAttribute[] GetOptionFileAttributeFromAssembly(Assembly[] assemblies)
        {
            return UtilityType.GetAttributeFromAssembly<OptionFileAttribute>(assemblies);
        }
    }
}