using System;
using Gean.Exceptions;

namespace Pansoft.Common.Options
{
	/// <summary>
	/// ѡ���쳣
	/// </summary>
	/// <remarks>
	/// ��ѡ�����棬�ܷ��ֵ��쳣�����װ�ɴ����ʵ��
	/// </remarks>
	[Serializable]
	public class OptionException : GeanException
	{
		/// <summary>
		/// ���캯��
		/// </summary>
		public OptionException() : base() {
		}

		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="message">�쳣��Ϣ</param>
		/// <param name="innerException">�ڲ��쳣</param>
		public OptionException(string message, Exception innerException)
			: base(message, innerException) {
		}

		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="message">�쳣��Ϣ</param>
		public OptionException(string message)
			: base(message) {
		}

		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="errorNo">�쳣���</param>
		/// <param name="message">�쳣��Ϣ</param>
		public OptionException(int errorNo, string message)
			: base(errorNo, message) {
		}

		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="errorNo">�쳣���</param>
		/// <param name="message">�쳣��Ϣ</param>
		/// <param name="innerException">�ڲ��쳣</param>
		public OptionException(int errorNo, string message, Exception innerException)
			: base(errorNo, message, innerException) {
		}

	}
}
