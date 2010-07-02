using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gean;
using Microsoft.ApplicationBlocks.Data;

namespace Pansoft.Whgd.EvServicing
{
    public partial class DatabaseConfigDialog : Form
    {
        public DatabaseConfigDialog()
        {
            InitializeComponent();
            if (ServiceManager.OptionService.HasOption)
            {
                DataSet ds = this.GetBranch();
                if (ds != null)
                {
                    _branchComboBox.DataSource = ds.Tables[0];
                    _branchComboBox.DisplayMember = "BranchName";
                    _branchComboBox.ValueMember = "branchno";
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!ServiceManager.OptionService.HasOption)
            {
                this.OptionSave();
            }
        }

        private void DatabaseConfigDialog_Load(object sender, EventArgs e)
        {
            object text = new object();
            if (ServiceManager.OptionService.TryGetOptionValue("TimerInterval", out text))
            {
                _timerIntervalNUDBox.Text = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvIp", out text))
            {
                _dbIpTextBox.Text = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvPort", out text))
            {
                _dbPortTextBox.Text = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvPwd", out text))
            {
                _dbPwdTextBox.Text = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvDbName", out text))
            {
                _dbNameTextBox.Text = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbSrvUser", out text))
            {
                _dbUserTextBox.Text = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("DbTestConnString", out text))
            {
                _testConnStringTextBox.Text = (string)text;
            }
            if (ServiceManager.OptionService.TryGetOptionValue("BranchNo", out text))
            {
                if ("%".Equals(text))
                {
                    _allBranchCheckBox.Checked = true;
                }
            }
        }

        private DataSet GetBranch()
        {
            try
            {
                string sql = "select BranchName,branchno from dbo.CQ_Cmn_Branch where subcenterno<>0 and branchno <>0";
                return SqlHelper.ExecuteDataset(
                    ServiceManager.SqlService.SqlConnectionStringBuilder.ConnectionString,
                    CommandType.Text,
                    sql);
            }
            catch
            {
                ServiceManager.Logger.Write(Gean.SimpleLogger.SimpleLoggerLevel.Error, "数据库执行查询错误，请检查数据库是否能够连接.");
                return null;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            OptionSave();
        }

        private void OptionSave()
        {
            ServiceManager.OptionService.SetOption("TimerInterval", _timerIntervalNUDBox.Text.Trim());
            ServiceManager.OptionService.SetOption("DbSrvIp", _dbIpTextBox.Text.Trim());
            ServiceManager.OptionService.SetOption("DbSrvPort", _dbPortTextBox.Text.Trim());
            ServiceManager.OptionService.SetOption("DbSrvDbName", _dbNameTextBox.Text.Trim());
            ServiceManager.OptionService.SetOption("DbSrvPwd", _dbPwdTextBox.Text.Trim());
            ServiceManager.OptionService.SetOption("DbSrvUser", _dbUserTextBox.Text.Trim());
            ServiceManager.OptionService.SetOption("DbTestConnString", _testConnStringTextBox.Text.Trim());
            List<string> evServicingSqlList = new List<string>();
            foreach (var item in _sqlListBox.Items)
            {
                evServicingSqlList.Add(item.ToString());
            }
            ServiceManager.OptionService.SetOption("EvServicingSqlList", evServicingSqlList);

            //保存机构选择
            string branchNo = string.Empty;
            if (_allBranchCheckBox.Checked || _branchComboBox.DataSource == null)
            {
                branchNo = "%";
            }
            else
            {
                branchNo = _branchComboBox.SelectedValue.ToString();
            }
            ServiceManager.OptionService.SetOption("BranchNo", branchNo);

            ServiceManager.OptionService.Save();
            ServiceManager.SqlService.initializeService();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            _dbIpTextBox.Clear();
            _dbPortTextBox.Clear();
            _dbPwdTextBox.Clear();
            _dbUserTextBox.Clear();
            _dbNameTextBox.Clear();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _connTestButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ServiceManager.SqlService.SqlConnectionStringBuilder.ToString());
            this.Cursor = Cursors.WaitCursor;
            if (ServiceManager.SqlService.TestConn())
            {
                _connTestRueltLabel.Text = "数据库连接测试成功.";
            }
            else
            {
                _connTestRueltLabel.Text = "数据库连接测试失败.";
            }
            this.Cursor = Cursors.Default;
        }

        private void _allBranchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _branchComboBox.Enabled = !_allBranchCheckBox.Checked;
        }
    }
}
