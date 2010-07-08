using System;

namespace Pansoft.Common.Options
{
	/// <summary>
	/// ѡ������Խӿ�
	/// </summary>
	/// <remarks>
	///	���������XML�ڱ�ʾһ��ѡ��ڣ�
	///		<code>
	///			&lt;app my="myProperty"&gt;myValue&lt;/app&gt;
	///		</code>
	///	��ʱ��<c>Name="app"</c>��Value��ֵΪ"myValue"��Property��ֵΪ"myProperty"
	/// </remarks>
	public interface IOptionSection : ICloneable
	{
		/// <summary>
		/// ��ǰѡ��������Ƿ�ֻ��
		/// </summary>
		bool ReadOnly { get; }

		/// <summary>
		/// ѡ��ڵ����Ը���
		/// </summary>
		int Count { get; }

		/// <summary>
		/// ��ȡ����ֵ(����������)
		/// </summary>
		/// <param name="propertyName">������</param>
		IOptionValue this[string propertyName] { get; }

		/// <summary>
		/// ��ȡ����ֵ(������������)
		/// </summary>
		/// <param name="propertyIndex">��������</param>
		IOptionValue this[int propertyIndex] { get; }

		/// <summary>
		/// ���Ի�ȡĳ����ֵ
		/// </summary>
		/// <param name="propertyName">������</param>
		/// <returns>����ֵ</returns>
		string TryGetPropertyValue(string propertyName);

		/// <summary>
		/// ���Ի�ȡĳ����ֵ��ת����ָ������
		/// </summary>
		/// <typeparam name="T">ת����ָ��������</typeparam>
		/// <param name="propertyName">������</param>
		/// <returns>ָ�����͵�ʵ��</returns>
		T TryGetPropertyValue<T>(string propertyName);

		/// <summary>
		/// ���Ի�ȡĳ����ֵ��ת����ָ������
		/// </summary>
		/// <typeparam name="T">ת����ָ��������</typeparam>
		/// <param name="propertyName">������</param>
		/// <param name="defaultValue">ȱʡֵ</param>
		/// <returns>ָ�����͵�ʵ��</returns>
		T TryGetPropertyValue<T>(string propertyName, T defaultValue);

		/// <summary>
		/// ��¡����
		/// </summary>
		/// <param name="readonly">�Ƿ�ֻ��</param>
		/// <param name="deep">�Ƿ���ȸ���</param>
		/// <returns>ISettingProperty</returns>
        IOptionSection Clone(bool @readonly, bool deep);
	}
}