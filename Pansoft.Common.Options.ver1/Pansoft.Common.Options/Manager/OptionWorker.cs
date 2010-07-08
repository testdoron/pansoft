using System;
using Gean;
namespace Pansoft.Common.Options
{
    /// <summary>
    /// 整个框架的选项管理器
    /// </summary>
    /// <remarks>
    /// 在应用程序中可以这么使用：<c>OptionWorker.Option["选项节名"]</c><br />
    /// </remarks>
    public class OptionWorker : IOptionManager, IFactory//, CoreModule
    {
        #region constructor

        static OptionWorker()
        {
            //Framework.Init();
        }

        private OptionWorker()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        #endregion

        #region private members

        private object lockObject = new object();
        private OptionManagerCollection optionManagerCollection = new OptionManagerCollection();

        private IOptionManager GetOptionManager(string optionFile, bool monitor)
        {
            IOptionManager optionManager = optionManagerCollection[optionFile];
            lock (lockObject)
            {
                if (optionManager == null)
                {
                    optionManager = CreateOptionManager(optionFile, monitor);
                    optionManagerCollection.Add(optionFile, optionManager);
                }
            }
            return optionManager;
        }

        private IOptionManager CreateOptionManager(string optionFile, bool monitor)
        {
            OptionAttribute[] optionAttributes = OptionAttribute.GetOptionAttributeFromAssembly(null);
            IOptionManager createdObject = null;
            if (optionAttributes != null && optionAttributes.Length > 0)
            {
                OptionAttribute optionAttribute = optionAttributes[0];
                for (int i = 1; i < optionAttributes.Length; i++)
                {
                    if (optionAttributes[i].Priority > optionAttribute.Priority)
                    {
                        optionAttribute = optionAttributes[i];
                    }
                }
                Type type = optionAttribute.RealType;
                if (type == null)
                {
                    try
                    {
                        type = UtilityType.CreateType(this.GetType().Assembly, optionAttribute.TypeName, true);
                    }
                    catch (Exception e)
                    {
                        throw new OptionException("类型载入错误：" + e.Message, e);
                    }
                }
                try
                {
                    createdObject = (IOptionManager)UtilityType.CreateObject(this.GetType().Assembly, type.FullName, typeof(IOptionManager), true);
                    createdObject.Initializes(optionFile, monitor);
                }
                catch (Exception e)
                {
                    throw new OptionException(e.Message, e);
                }
            }
            return createdObject;
        }

        #endregion

        #region static members

        private static OptionWorker instance = new OptionWorker();
        private static IOptionManager globalConfigManager;

        private static IOptionManager GlobalConfigManager
        {
            get
            {
                if (globalConfigManager == null)
                {
                    globalConfigManager = Current.GetOptionManager(null, false);
                }
                return globalConfigManager;
            }
        }

        /// <summary>
        /// OptionWorker的唯一实例，提供给框架使用
        /// </summary>
        public static OptionWorker Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new OptionWorker();
                }
                return instance;
            }
        }

        /// <summary>
        /// 重新载入相关选项信息
        /// </summary>
        public static void Reset()
        {
            Current.optionManagerCollection.Clear();
            globalConfigManager = null;
        }

        #endregion

        #region IOptionManager members

        void IOptionManager.Initializes(string optionFile, bool monitor) { }

        /// <summary>
        /// 重新载入相关选项信息
        /// </summary>
        void IOptionManager.Reset()
        {
            GlobalConfigManager.Reset();
        }

        IOption IOptionManager.Option
        {
            get { return GlobalConfigManager.Option; }
        }

        /// <summary>
        /// 获得选项节
        /// </summary>
        /// <param name="xpath">选项节的XPath，如果为<c>null</c>，则返回根选项节</param>
        /// <returns><see cref="IOption"/></returns>
        IOption IOptionManager.GetOption(string xpath)
        {
            return GlobalConfigManager.GetOption(xpath);
        }

        #endregion

        #region override module members

        ///// <summary>
        ///// 初始化模块
        ///// </summary>
        ///// <param name="framework">IFramework</param>
        ///// <param name="setting">对应的选项节</param>
        //public override void Init(IFramework framework, IOption setting)
        //{
        //    if (setting != null)
        //    {
        //        base.Init(framework, setting);
        //    }
        //}

        ///// <summary>
        ///// 获取本模块的事例（可以是单例模式也可以是多例模式）
        ///// </summary>
        ///// <returns>IModule</returns>
        //public override IModule GetInstance()
        //{
        //    return Current;
        //}

        #endregion

        #region IFactory members

        object IFactory.GetManager(params object[] parameters)
        {
            string optionFile = null;
            bool monitor = true;
            if (parameters != null)
            {
                if (parameters.Length > 0)
                {
                    optionFile = (string)parameters[0];
                }
                if (parameters.Length > 1)
                {
                    monitor = (bool)parameters[1];
                }
            }
            return this.GetOptionManager(optionFile, monitor);
        }

        #endregion
    }
}