using System;

namespace Pansoft.Common.Options
{
    /// <summary>
    /// ѡ��ڽӿ�
    /// </summary>
    /// <remarks>
    /// ���������XML�ڱ�ʾһ��ѡ��ڣ�
    /// <code>
    /// &lt;app my="myProperty"&gt;myValue&lt;/app&gt;
    /// </code>
    /// ��ʱ��<c>Name="app"</c>��Value��ֵΪ"myValue"��Property��ֵΪ"myProperty"
    /// </remarks>
	public interface IOption : ICloneable
	{
		/// <summary>
		/// ��ǰѡ����Ƿ�ֻ��
		/// </summary>
		bool ReadOnly { get; }

		/// <summary>
		/// ��ѡ��ڵ���
		/// </summary>
		string Name { get; }

		/// <summary>
		/// ��ѡ���ʵ������
		/// </summary>
		string OptionName { get; }

		/// <summary>
		/// ��ѡ��ڵ���/ֵ
		/// </summary>
		IOptionValue Value { get; }

		/// <summary>
		/// ������ѡ��ڵĸ�ѡ���
		/// </summary>
		IOption Parent { get; }

		/// <summary>
		/// ��ѡ��ڰ�������ѡ�����Ŀ
		/// </summary>
		int Children { get; }

		/// <summary>
		/// ѡ�������
		/// </summary>
        IOptionSection OptionSection { get; }

        /// <summary>
        /// ��ȡ��ѡ���
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// ��������ڣ�������<c>null</c>
        /// </remarks>
		IOption this[string childOptionName] { get; }

        /// <summary>
        /// ��ȡ��ѡ���
        /// </summary>
        /// <value></value>
        /// <remarks>
        /// ��������ڣ�������null
        /// </remarks>
		IOption this[int childOptionIndex] { get; }

        /// <summary>
        /// ��ȡ������ѡ���
        /// </summary>
        /// <returns>ѡ�������</returns>
		IOption[] GetChildOptions();

        /// <summary>
        /// ��XPath��ʽ��ȡѡ���
        /// </summary>
        /// <param name="xpath">XPath</param>
        /// <returns>ѡ���</returns>
        /// <remarks>
        /// XPathΪ����XML��XPath������<c>framework/modules"</c><br/>
        /// �������ͬ��ѡ��ڣ��򷵻ص�һ��ѡ���
        /// </remarks>
		IOption GetChildOption(string xpath);

        /// <summary>
        /// ���༶��ʽ��ȡѡ���
        /// </summary>
        /// <param name="optionName">Name of the option.</param>
        /// <returns>ѡ���</returns>
        /// <remarks>
        /// �༶��ѡ�����������������ѡ�
        /// <code>
        /// &lt;app1&gt;
        /// &lt;app2&gt;
        /// &lt;app3&gt;&lt;/app3&gt;
        /// &lt;/app2&gt;
        /// &lt;/app1&gt;
        /// </code>
        /// ��˳���룬����<c>GetChildSetting("app1", "app2", "app3")</c>����ʱ������Ϊ<c>app3</c>��ѡ���
        /// </remarks>
		IOption GetChildOption(params string[] optionName);

        /// <summary>
        /// ��ȡ��ѡ���
        /// </summary>
        /// <returns>ѡ���</returns>
		IOption GetRootOption();

        /// <summary>
        /// �ϲ�ѡ���
        /// </summary>
        /// <param name="option">The option.</param>
		void Merge(IOption option);

		/// <summary>
		/// ��¡��ѡ���
		/// </summary>
		/// <param name="readonly">�Ƿ�ֻ��</param>
		/// <param name="deep">�Ƿ����εĿ�¡</param>
		/// <returns>ѡ���</returns>
		IOption Clone(bool @readonly, bool deep);
	}
}
