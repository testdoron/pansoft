using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Gean.SimpleLogger;

namespace Pansoft.Whgd.EvServicing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            ServiceManager.Logger.LogWritedEvent += new Gean.SimpleLogger.SimpleLoggerWriter.LogWritedEventHandler(Logger_LogWritedEvent);

            Thread thread = new Thread(CrossThreadFlush);
            thread.IsBackground = true;
            thread.Start();

            InitializeComponent();

            _versionLabel.Text = Application.ProductName + " v" + Application.ProductVersion + "R";
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!ServiceManager.OptionService.HasOption)
            {
                DatabaseConfigDialog dialog = new DatabaseConfigDialog();
                dialog.ShowDialog(this);
            }
            else
            {
                try
                {
                    Thread.Sleep(10 * 1000);
                    _logListBox.Items.Clear();
                    ServiceManager.Logger.Write(Gean.SimpleLogger.SimpleLoggerLevel.Info, "启动服务");
                    ServiceManager.SqlService.startService();
                }
                catch (Exception)
                {
                    ServiceManager.Logger.Write(SimpleLoggerLevel.Info, "未能启动服务，请手动启动服务。");
                }
            }
        }


        private delegate void FlushClient();//代理

        private void CrossThreadFlush()
        {
            while (true)
            {
                //将sleep和无限循环放在等待异步的外面
                Thread.Sleep(50);
                ThreadFunction();
            }
        }
        private void ThreadFunction()
        {
            if (_logListBox.InvokeRequired)//等待异步
            {
                try
                {
                    FlushClient fc = new FlushClient(ThreadFunction);
                    this.Invoke(fc);//通过代理调用刷新方法
                }
                catch { }
            }
            else
            {
                if (_logList.Count <= 0)
                {
                    return;
                }
                if (_logListBox.Items.Count * _logListBox.ItemHeight > _logListBox.Height)
                {
                    _logListBox.Items.Clear();
                }
                _logListBox.BeginUpdate();
                _logListBox.Items.Add(_logList.Dequeue());
                _logListBox.EndUpdate();
            }
        }

        private System.Timers.Timer _logTimers = new System.Timers.Timer(50);
        private Queue<string> _logList = new Queue<string>();

        void Logger_LogWritedEvent(object sender, Gean.SimpleLogger.SimpleLoggerWriter.LogWritedEventArgs e)
        {
            _logList.Enqueue(e.LogString);
        }

        private void _configButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DatabaseConfigDialog dialog = new DatabaseConfigDialog();
            this.Cursor = Cursors.Default;
            dialog.ShowDialog(this);
        }

        private void _stopButton_Click(object sender, EventArgs e)
        {
            ServiceManager.SqlService.stopService();
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            ServiceManager.SqlService.stopService();
            this.Close();
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            _logListBox.Items.Clear();
            ServiceManager.Logger.Write(Gean.SimpleLogger.SimpleLoggerLevel.Info, "启动服务");
            ServiceManager.SqlService.startService();
        }
    }


}
