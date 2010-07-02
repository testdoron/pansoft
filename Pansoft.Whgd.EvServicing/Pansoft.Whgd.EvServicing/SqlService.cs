using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Collections;
using Gean.SimpleLogger;

namespace Pansoft.Whgd.EvServicing
{
    public class SqlService : IService
    {
        #region 单件实例

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlService"/> class.
        /// </summary>
        private SqlService()
        {
            _lastDoTime = DateTime.Now;
        }

        /// <summary>
        /// 获得一个本类型的单件实例.
        /// </summary>
        /// <value>The instance.</value>
        public static SqlService Instance
        {
            get { return Singleton.Instance; }
        }

        private class Singleton
        {
            static Singleton()
            {
                Instance = new SqlService();
            }

            internal static readonly SqlService Instance = null;
        }

        #endregion

        private System.Timers.Timer _timer = null;

        public void initializeService()
        {
            object timer;
            if (ServiceManager.OptionService.TryGetOptionValue("TimerInterval", out timer))
            {
                _timer = new System.Timers.Timer(1000 * 60 * int.Parse((String)timer));
            }
            else
            {
                _timer = new System.Timers.Timer(1000 * 60 * 5);
            }
            
            this.SqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            object text = new object();
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvIp", out text))
            {
                this.SqlConnectionStringBuilder.DataSource = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvPort", out text))
            {
                this.SqlConnectionStringBuilder.DataSource = this.SqlConnectionStringBuilder.DataSource + "," + (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvPwd", out text))
            {
                this.SqlConnectionStringBuilder.Password = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvDbName", out text))
            {
                this.SqlConnectionStringBuilder.InitialCatalog = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvUser", out text))
            {
                this.SqlConnectionStringBuilder.UserID = (string)text;
            }
            this.SqlConnectionStringBuilder.ConnectTimeout = 5;
        }

        public void startService()
        {
            object obj = ServiceManager.OptionService.GetOptionValue("EvServicingSqlList");
            //ServiceManager.Logger.Write(SimpleLoggerLevel.Info, obj);
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Start();
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            object obj = ServiceManager.OptionService.GetOptionValue("EvServicingSqlList");

            foreach (var item in ServiceManager.OptionService.GetOptionValue("EvServicingSqlList") as IEnumerable)
            {
                string brachNo = ServiceManager.OptionService.GetOptionValue("BranchNo").ToString();
                string sql = String.Format((String)item, _lastDoTime.ToString(), brachNo);
                int i = SqlHelper.ExecuteNonQuery
                    (
                        SqlConnectionStringBuilder.ConnectionString,
                        CommandType.Text,
                        sql
                    );
                //ServiceManager.Logger.Write(SimpleLoggerLevel.Info, sql);
                ServiceManager.Logger.Write(SimpleLoggerLevel.Info, i + " 条记录被更新.");
            }
            _lastDoTime = DateTime.Now;
        }

        public void stopService()
        {
            _timer.Stop();
        }

        public void reloadService()
        {
            _timer.Stop();
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true;
            _timer.Start();
            ServiceManager.Logger.Write(SimpleLoggerLevel.Info, _timer + "启动...");
        }

        public SqlConnectionStringBuilder SqlConnectionStringBuilder { get; set; }

        public bool TestConn()
        {
            DataSet ds = null;
            try
            {
                ds = SqlHelper.ExecuteDataset
                    (
                        SqlConnectionStringBuilder.ConnectionString,
                        CommandType.Text,
                        (String)ServiceManager.OptionService.GetOptionValue("DbTestConnString")
                    );
            }
            catch//一切的错误信息都可以证明数据库连接是失败的
            {
                ServiceManager.Logger.Write(SimpleLoggerLevel.Info, "连接数据库失败.请点击<选项>配置数据库选项。");
                return false;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private DateTime _lastDoTime;
    }
}
