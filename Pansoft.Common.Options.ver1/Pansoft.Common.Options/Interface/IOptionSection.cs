using System;

namespace Pansoft.Common.Options
{
	/// <summary>
	/// 选项节属性接口
	/// </summary>
	/// <remarks>
	///	形如下面的XML节表示一个选项节：
	///		<code>
	///			&lt;app my="myProperty"&gt;myValue&lt;/app&gt;
	///		</code>
	///	此时，<c>Name="app"</c>，Value的值为"myValue"，Property的值为"myProperty"
	/// </remarks>
	public interface IOptionSection : ICloneable
	{
		/// <summary>
		/// 当前选项节属性是否只读
		/// </summary>
		bool ReadOnly { get; }

		/// <summary>
		/// 选项节的属性个数
		/// </summary>
		int Count { get; }

		/// <summary>
		/// 获取属性值(根据属性名)
		/// </summary>
		/// <param name="propertyName">属性名</param>
		IOptionValue this[string propertyName] { get; }

		/// <summary>
		/// 获取属性值(根据属性索引)
		/// </summary>
		/// <param name="propertyIndex">属性索引</param>
		IOptionValue this[int propertyIndex] { get; }

		/// <summary>
		/// 尝试获取某属性值
		/// </summary>
		/// <param name="propertyName">属性名</param>
		/// <returns>属性值</returns>
		string TryGetPropertyValue(string propertyName);

		/// <summary>
		/// 尝试获取某属性值并转换成指定类型
		/// </summary>
		/// <typeparam name="T">转换成指定的类型</typeparam>
		/// <param name="propertyName">属性名</param>
		/// <returns>指定类型的实例</returns>
		T TryGetPropertyValue<T>(string propertyName);

		/// <summary>
		/// 尝试获取某属性值并转换成指定类型
		/// </summary>
		/// <typeparam name="T">转换成指定的类型</typeparam>
		/// <param name="propertyName">属性名</param>
		/// <param name="defaultValue">缺省值</param>
		/// <returns>指定类型的实例</returns>
		T TryGetPropertyValue<T>(string propertyName, T defaultValue);

		/// <summary>
		/// 克隆属性
		/// </summary>
		/// <param name="readonly">是否只读</param>
		/// <param name="deep">是否深度复制</param>
		/// <returns>ISettingProperty</returns>
        IOptionSection Clone(bool @readonly, bool deep);
	}
}