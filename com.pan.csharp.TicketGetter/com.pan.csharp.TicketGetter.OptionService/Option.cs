using System;
using System.Xml;
using com.pan.csharp.Utility;
using NLog;

namespace com.pan.csharp.TicketGetter.OptionService
{
    public sealed class Option : IOptions
    {
        private static Logger logger = LogManager.GetCurrentClassLogger(); 

        Option()
        {
        }

        /// <summary>
        /// 单建模式获取该类型的实例化。（线程安全，延迟实例）
        /// </summary>
        public static Option Instance
        {
            get { return Nested.Instance; }
        }
        
        /// <summary>
        /// 仅供单建模式使用的内部类型
        /// </summary>
        private class Nested
        {
            static Nested() { }
            internal static readonly Option Instance = new Option();
        }

        private static XmlDocument _Document = null;

        public string Get(string key)
        {
            throw new NotImplementedException();
        }

        public IDataArray GetArray(string key)
        {
            throw new NotImplementedException();
        }

        public IDataTree GetTree(string key)
        {
            throw new NotImplementedException();
        }

    }
}

