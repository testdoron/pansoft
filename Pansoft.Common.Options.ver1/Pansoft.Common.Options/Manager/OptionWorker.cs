using System;
using Gean;
namespace Pansoft.Common.Options
{
    /// <summary>
    /// ������ܵ�ѡ�������
    /// </summary>
    /// <remarks>
    /// ��Ӧ�ó����п�����ôʹ�ã�<c>OptionWorker.Option["ѡ�����"]</c><br />
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
                        throw new OptionException("�����������" + e.Message, e);
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
        /// OptionWorker��Ψһʵ�����ṩ�����ʹ��
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
        /// �����������ѡ����Ϣ
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
        /// �����������ѡ����Ϣ
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
        /// ���ѡ���
        /// </summary>
        /// <param name="xpath">ѡ��ڵ�XPath�����Ϊ<c>null</c>���򷵻ظ�ѡ���</param>
        /// <returns><see cref="IOption"/></returns>
        IOption IOptionManager.GetOption(string xpath)
        {
            return GlobalConfigManager.GetOption(xpath);
        }

        #endregion

        #region override module members

        ///// <summary>
        ///// ��ʼ��ģ��
        ///// </summary>
        ///// <param name="framework">IFramework</param>
        ///// <param name="setting">��Ӧ��ѡ���</param>
        //public override void Init(IFramework framework, IOption setting)
        //{
        //    if (setting != null)
        //    {
        //        base.Init(framework, setting);
        //    }
        //}

        ///// <summary>
        ///// ��ȡ��ģ��������������ǵ���ģʽҲ�����Ƕ���ģʽ��
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