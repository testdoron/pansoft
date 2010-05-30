using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace com.pan.csharp.TicketGetter.OptionService
{
    public sealed class OptionService
    {
        OptionService()
        {
        }

        /// <summary>
        /// 单建模式获取该类型的实例化。（线程安全，延迟实例）
        /// </summary>
        public static OptionService Instance
        {
            get { return Nested.Instance; }
        }
        
        /// <summary>
        /// 仅供单建模式使用的内部类型
        /// </summary>
        class Nested
        {
            static Nested() { }
            internal static readonly OptionService Instance = new OptionService();
        }

        private static XmlDocument _Document = null;
    }
}

