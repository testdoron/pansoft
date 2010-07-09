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

        private System.Threading.Timer _SqlTimer = null;

        public void initializeService()
        {
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

        private void SetTimer()
        {
            object timer;
            if (ServiceManager.OptionService.TryGetOptionValue("TimerInterval", out timer))
            {
                _SqlTimer = new System.Threading.Timer(
                    new System.Threading.TimerCallback(SqlTimerRunMethod),
                    this,
                    100,
                    1000 * 60 * int.Parse((String)timer)
                    );
            }
            else
            {
                _SqlTimer = new System.Threading.Timer(
                    new System.Threading.TimerCallback(SqlTimerRunMethod),
                    this,
                    0,
                    1000 * 60 * 5
                    );
            }
        }

        private bool _startFlag = false;
        public void startService()
        {
            if (!_startFlag)
            {
                SetTimer();
                _startFlag = true;
            }
        }

        void SqlTimerRunMethod(object o)
        {
            bool isComplate = false;
            foreach (var item in ServiceManager.OptionService.GetOptionValue("EvServicingSqlList") as IEnumerable)
            {
                string brachNo = ServiceManager.OptionService.GetOptionValue("BranchNo").ToString();
                string sql = String.Format((String)item, _lastDoTime.ToString(), brachNo);
                int i = 0;
                try
                {
                    i = SqlHelper.ExecuteNonQuery
                         (
                             SqlConnectionStringBuilder.ConnectionString,
                             CommandType.Text,
                             sql
                         );
                    isComplate = true;
                }
                catch (Exception e)
                {
                    ServiceManager.Logger.Write(SimpleLoggerLevel.Info, "服务时。连接数据库失败.请点击<选项>配置数据库选项。");
                }
                ServiceManager.Logger.Write(SimpleLoggerLevel.Info, i + " 条记录被更新.");
            }
            if (isComplate)
            {
                _lastDoTime = DateTime.Now;
            }
            isComplate = false;
        }

        public void stopService()
        {
            _SqlTimer.Dispose();
            _startFlag = false;
        }

        public void reloadService()
        {
            this.stopService();
            this.SetTimer();

            ServiceManager.Logger.Write(SimpleLoggerLevel.Info, _SqlTimer + "启动...");
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
                ServiceManager.Logger.Write(SimpleLoggerLevel.Info, "测试时。连接数据库失败.请点击<选项>配置数据库选项。");
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
