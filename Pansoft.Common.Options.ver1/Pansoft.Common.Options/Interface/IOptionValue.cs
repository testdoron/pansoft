using System;
using Gean;

namespace Pansoft.Common.Options
{
	/// <summary>
	/// ѡ��ֵ�ӿ�
	/// </summary>
	/// <remarks>
	///	���������XML�ڱ�ʾһ��ѡ��ڣ�
	///		<code>
	///			&lt;app my="myProperty"&gt;myValue&lt;/app&gt;
	///		</code>
	///	��ʱ��<c>Name="app"</c>��Value��ֵΪ"myValue"��Property��ֵΪ"myProperty"
	/// </remarks>
	public interface IOptionValue : ICloneable, IConverting
	{
		/// <summary>
		/// ��ǰѡ��ֵ�Ƿ�ֻ��
		/// </summary>
		bool ReadOnly { get; }

		/// <summary>
		/// ѡ��ֵ��
		/// </summary>
		string Name { get; }

		/// <summary>
		/// ѡ��ֵ
		/// </summary>
		string Value { get; }

		/// <summary>
		///  ��¡ѡ��ֵ
		/// </summary>
		/// <param name="readonly">�Ƿ�ֻ��</param>
		/// <returns>ISettingValue</returns>
		IOptionValue Clone(bool @readonly);
	}
}