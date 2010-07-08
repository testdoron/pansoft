using System;
using System.Reflection;
using Gean;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// 选项元属性
    /// </summary>
    /// <remarks>
    /// 这个提供选项文件地址和选项管理器的一种方式<br />
    /// 用法，在应用程序中添加如下元属性，注意Priority必须大于1000才能起作用
    ///		<code>
    ///			[assembly: Option(RealType=typeof(Pansoft.Common.Options.OptionManager), Priority = 1000)]
    ///		</code>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class OptionAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public OptionAttribute() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="optionFile">指定选项文件地址</param>
        public OptionAttribute(string optionFile)
        {
            this._optionFile = optionFile;
        }

        private string _optionFile = null;
        private int _priority = 0;
        private Type _realType = null;
        private string _typeName = null;

        /// <summary>
        /// 获取/设置选项文件
        /// </summary>
        public string OptionFile
        {
            get { return this._optionFile; }
            set { this._optionFile = value; }
        }

        /// <summary>
        /// 获取/设置此选项的优先级
        /// </summary>
        public int Priority
        {
            get { return this._priority; }
            set { this._priority = value; }
        }

        /// <summary>
        /// 获取/设置此选项对应的选项管理器类型
        /// </summary>
        public Type RealType
        {
            get { return this._realType; }
            set { this._realType = value; }
        }

        /// <summary>
        /// 获取/设置此选项管理器的类型名
        /// </summary>
        public string TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        /// <summary>
        /// 从程序集中获得选项元属性
        /// </summary>
        /// <param name="assemblies">程序集，如果为null，则从当前应用程序域中获取所载入的所有程序集</param>
        /// <returns>找到的选项元属性的数组</returns>
        public static OptionAttribute[] GetOptionAttributeFromAssembly(Assembly[] assemblies)
        {
            return UtilityType.GetAttributeFromAssembly<OptionAttribute>(assemblies);
        }
    }
}