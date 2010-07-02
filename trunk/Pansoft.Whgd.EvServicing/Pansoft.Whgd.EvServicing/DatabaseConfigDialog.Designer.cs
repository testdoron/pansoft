namespace Pansoft.Whgd.EvServicing
{
    partial class DatabaseConfigDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resetButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._connTestRueltLabel = new System.Windows.Forms.Label();
            this._connTestButton = new System.Windows.Forms.Button();
            this._dbNameTextBox = new System.Windows.Forms.TextBox();
            this._dbUserTextBox = new System.Windows.Forms.TextBox();
            this._dbPwdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._dbIpTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._dbPortTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this._sqlListBox = new System.Windows.Forms.ListBox();
            this._testConnStringTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this._branchComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._timerIntervalNUDBox = new System.Windows.Forms.NumericUpDown();
            this._allBranchCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timerIntervalNUDBox)).BeginInit();
            this.SuspendLayout();
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(278, 261);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(76, 29);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "重置";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(196, 261);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(76, 29);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "保存";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(360, 261);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 29);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(424, 243);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._connTestRueltLabel);
            this.tabPage1.Controls.Add(this._connTestButton);
            this.tabPage1.Controls.Add(this._dbNameTextBox);
            this.tabPage1.Controls.Add(this._dbUserTextBox);
            this.tabPage1.Controls.Add(this._dbPwdTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this._dbIpTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this._dbPortTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(416, 217);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据库配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _connTestRueltLabel
            // 
            this._connTestRueltLabel.AutoSize = true;
            this._connTestRueltLabel.Location = new System.Drawing.Point(140, 167);
            this._connTestRueltLabel.Name = "_connTestRueltLabel";
            this._connTestRueltLabel.Size = new System.Drawing.Size(0, 13);
            this._connTestRueltLabel.TabIndex = 13;
            this._connTestRueltLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _connTestButton
            // 
            this._connTestButton.Location = new System.Drawing.Point(268, 161);
            this._connTestButton.Name = "_connTestButton";
            this._connTestButton.Size = new System.Drawing.Size(79, 25);
            this._connTestButton.TabIndex = 12;
            this._connTestButton.Text = "连接测试";
            this._connTestButton.UseVisualStyleBackColor = true;
            this._connTestButton.Click += new System.EventHandler(this._connTestButton_Click);
            // 
            // _dbNameTextBox
            // 
            this._dbNameTextBox.Location = new System.Drawing.Point(173, 74);
            this._dbNameTextBox.Name = "_dbNameTextBox";
            this._dbNameTextBox.Size = new System.Drawing.Size(174, 21);
            this._dbNameTextBox.TabIndex = 10;
            this._dbNameTextBox.Text = "CQHist430";
            // 
            // _dbUserTextBox
            // 
            this._dbUserTextBox.Location = new System.Drawing.Point(173, 101);
            this._dbUserTextBox.Name = "_dbUserTextBox";
            this._dbUserTextBox.Size = new System.Drawing.Size(174, 21);
            this._dbUserTextBox.TabIndex = 10;
            this._dbUserTextBox.Text = "sa";
            // 
            // _dbPwdTextBox
            // 
            this._dbPwdTextBox.Location = new System.Drawing.Point(173, 128);
            this._dbPwdTextBox.Name = "_dbPwdTextBox";
            this._dbPwdTextBox.Size = new System.Drawing.Size(174, 21);
            this._dbPwdTextBox.TabIndex = 11;
            this._dbPwdTextBox.Text = "sa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "数据库服务器IP地址:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据库密码:";
            // 
            // _dbIpTextBox
            // 
            this._dbIpTextBox.Location = new System.Drawing.Point(173, 20);
            this._dbIpTextBox.Name = "_dbIpTextBox";
            this._dbIpTextBox.Size = new System.Drawing.Size(174, 21);
            this._dbIpTextBox.TabIndex = 5;
            this._dbIpTextBox.Text = "192.168.2.58";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "数据库:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "数据库服务器端口:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "数据库用户名:";
            // 
            // _dbPortTextBox
            // 
            this._dbPortTextBox.Location = new System.Drawing.Point(173, 47);
            this._dbPortTextBox.Name = "_dbPortTextBox";
            this._dbPortTextBox.Size = new System.Drawing.Size(174, 21);
            this._dbPortTextBox.TabIndex = 9;
            this._dbPortTextBox.Text = "1433";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this._sqlListBox);
            this.tabPage2.Controls.Add(this._testConnStringTextBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(416, 217);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "维护项";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(227, 184);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "上移";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(270, 184);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "下移";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(313, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(356, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "增加";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _sqlListBox
            // 
            this._sqlListBox.FormattingEnabled = true;
            this._sqlListBox.Items.AddRange(new object[] {
            "update dbo.CQ_Cmn_History set commentResult = 1 where  (serialCode)%10<>9 and cou" +
                "nterServed=1 and commentResult =0 and customerStatus>2 and startTime>\'{0}\' and b" +
                "ranchno like \'{1}\'"});
            this._sqlListBox.Location = new System.Drawing.Point(21, 84);
            this._sqlListBox.Name = "_sqlListBox";
            this._sqlListBox.Size = new System.Drawing.Size(376, 95);
            this._sqlListBox.TabIndex = 2;
            // 
            // _testConnStringTextBox
            // 
            this._testConnStringTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this._testConnStringTextBox.Location = new System.Drawing.Point(21, 28);
            this._testConnStringTextBox.Multiline = true;
            this._testConnStringTextBox.Name = "_testConnStringTextBox";
            this._testConnStringTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._testConnStringTextBox.Size = new System.Drawing.Size(376, 37);
            this._testConnStringTextBox.TabIndex = 1;
            this._testConnStringTextBox.Text = "select top 1 commentResult,counterServed,customerStatus,startTime from CQ_Cmn_His" +
                "tory";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "维护子项:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "数据库测试:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this._allBranchCheckBox);
            this.tabPage3.Controls.Add(this._branchComboBox);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this._timerIntervalNUDBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(416, 217);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "维护配置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // _branchComboBox
            // 
            this._branchComboBox.FormattingEnabled = true;
            this._branchComboBox.Location = new System.Drawing.Point(182, 48);
            this._branchComboBox.Name = "_branchComboBox";
            this._branchComboBox.Size = new System.Drawing.Size(121, 21);
            this._branchComboBox.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(117, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "指定机构:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "维护间隔(分钟):";
            // 
            // _timerIntervalNUDBox
            // 
            this._timerIntervalNUDBox.Location = new System.Drawing.Point(182, 20);
            this._timerIntervalNUDBox.Name = "_timerIntervalNUDBox";
            this._timerIntervalNUDBox.Size = new System.Drawing.Size(120, 21);
            this._timerIntervalNUDBox.TabIndex = 0;
            this._timerIntervalNUDBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // _allBranchCheckBox
            // 
            this._allBranchCheckBox.AutoSize = true;
            this._allBranchCheckBox.Location = new System.Drawing.Point(182, 71);
            this._allBranchCheckBox.Name = "_allBranchCheckBox";
            this._allBranchCheckBox.Size = new System.Drawing.Size(74, 17);
            this._allBranchCheckBox.TabIndex = 3;
            this._allBranchCheckBox.Text = "全部机构";
            this._allBranchCheckBox.UseVisualStyleBackColor = true;
            this._allBranchCheckBox.CheckedChanged += new System.EventHandler(this._allBranchCheckBox_CheckedChanged);
            // 
            // DatabaseConfigDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(450, 302);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.resetButton);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseConfigDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选项";
            this.Load += new System.EventHandler(this.DatabaseConfigDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timerIntervalNUDBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox _dbUserTextBox;
        private System.Windows.Forms.TextBox _dbPwdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _dbIpTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _dbPortTextBox;
        private System.Windows.Forms.TextBox _dbNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _connTestButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox _testConnStringTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label _connTestRueltLabel;
        private System.Windows.Forms.ListBox _sqlListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown _timerIntervalNUDBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _branchComboBox;
        private System.Windows.Forms.CheckBox _allBranchCheckBox;

    }
}