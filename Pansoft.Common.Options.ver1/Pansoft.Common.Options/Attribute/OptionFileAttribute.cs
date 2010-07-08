using System;
using System.Reflection;
using Gean;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// 选项文件属性
    /// </summary>
    /// <remarks>
    /// 这个提供选项文件合并的一种方式<br />
    /// 用法，在应用程序中添加如下元属性，注意OptionIndex必须不小于1000才能起作用
    ///		<code>
    ///			[assembly: DevFxOptionFile(OptionFile="res://HTB.DevFx.Option.htb.devfx.config", OptionIndex = 1000)]
    ///		</code>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class OptionFileAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configFile">指定选项文件地址</param>
        /// <param name="fileInType">如果是内置资源，指定此资源所在的<see cref="Assembly"/></param>
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
        /// 获取/设置选项文件，除了硬盘文件，其他必需加前缀
        /// </summary>
        /// <remarks>
        /// 内置资源：res:// <br />
        /// HTTP资源：http://
        /// </remarks>
        public string OptionFile
        {
            get { return this.configFile; }
            set { this.configFile = value; }
        }

        /// <summary>
        /// 获取/设置此选项合并时的顺序
        /// </summary>
        public int OptionIndex
        {
            get { return this.configIndex; }
            set
            {
                if (value < 1000)
                {
                    throw new OptionException("选项文件顺序不能小于1000");
                }
                this.configIndex = value;
            }
        }

        /// <summary>
        /// 获取/设置此资源所在的<see cref="Assembly"/>
        /// </summary>
        public Type FileInType
        {
            get { return this.fileInType; }
            set { this.fileInType = value; }
        }

        /// <summary>
        /// 获取/设置此资源所在的<see cref="Assembly"/>名称
        /// </summary>
        public string FileInTypeName
        {
            get { return this.fileInTypeName; }
            set { this.fileInTypeName = value; }
        }

        /// <summary>
        /// 获取此资源所在的<see cref="Assembly"/>
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
        /// 从程序集中获得元属性
        /// </summary>
        /// <param name="assemblies">程序集，如果为null，则从当前应用程序域中获取所载入的所有程序集</param>
        /// <returns>找到的元属性的数组</returns>
        public static OptionFileAttribute[] GetOptionFileAttributeFromAssembly(Assembly[] assemblies)
        {
            return UtilityType.GetAttributeFromAssembly<OptionFileAttribute>(assemblies);
        }
    }
}