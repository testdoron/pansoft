namespace Pansoft.Common.Options
{
	/// <summary>
	/// ѡ��������ӿ�
	/// </summary>
	public interface IOptionManager
	{
        /// <summary>
        /// �˹������������ѡ��
        /// </summary>
        /// <value>The option.</value>
		IOption Option { get; }

        /// <summary>
        /// ���ѡ���
        /// </summary>
        /// <param name="xpath">ѡ��ڵ�XPath�����Ϊ<c>null</c>���򷵻ظ�ѡ���</param>
        /// <returns><see cref="IOption"/></returns>
        IOption GetOption(string xpath);

        /// <summary>
        /// ��ʼ�����ṩ��ģ����ã����й������ĳ�ʼ����������������ѡ���ļ��ȵ�
        /// </summary>
        /// <param name="optionFile">ѡ���ļ���Ϣ</param>
        /// <param name="monitor">�Ƿ�Ҫ���Ӵ�ѡ��ı仯</param>
        /// <remarks>
        /// ����<paramref name="monitor"/>��ʾ������ѡ���ļ��仯���Ը���ѡ����Ϣ
        /// </remarks>
        void Initializes(string optionFile, bool monitor);

		/// <summary>
		/// �����������ѡ����Ϣ
		/// </summary>
		void Reset();
	}
}
