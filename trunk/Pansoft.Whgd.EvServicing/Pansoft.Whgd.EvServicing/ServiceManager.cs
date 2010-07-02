using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Gean;
using Gean.SimpleLogger;

namespace Pansoft.Whgd.EvServicing
{
    public static class ServiceManager
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceManager.SetApplicationDataPath();//设置应用程序的数据存储路径
            string logFullPath = ApplicationDataPath + @"\Log\Log" + DateTime.Now.ToShortDateString() + ".log";
            _loggerWriter = SimpleLoggerWriter.InitializeComponent(logFullPath);

            string optionsFullPath = ApplicationDataPath + @"\" + Application.ProductName + ".option";
            Options.Initializes(optionsFullPath);

            SqlService.Instance.initializeService();

            Application.Run(new MainForm());
        }

        private static void SetApplicationDataPath()
        {
            //系统的应用程序数据路径
            string appDataPath = Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            //本程序的数据路径
            string selfPath = @"Pansoft\" + Application.ProductName;
            //合成路径
            ApplicationDataPath = Path.Combine(appDataPath, selfPath);

            if (!Directory.Exists(ApplicationDataPath))
            {
                Directory.CreateDirectory(ApplicationDataPath);
                Directory.CreateDirectory(ApplicationDataPath + @"\Log");
            }
            
        }

        public static string ApplicationDataPath { get; set; }
        public static Options OptionService { get { return Options.Instance; } }
        public static SqlService SqlService { get { return SqlService.Instance; } }
        public static SimpleLoggerWriter Logger { get { return _loggerWriter; } }
        private static SimpleLoggerWriter _loggerWriter;
    }
}
