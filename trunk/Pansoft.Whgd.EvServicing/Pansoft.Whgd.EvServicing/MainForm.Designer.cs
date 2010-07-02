namespace Pansoft.Whgd.EvServicing
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._versionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._closeButton = new System.Windows.Forms.Button();
            this._stopButton = new System.Windows.Forms.Button();
            this._startButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._logListBox = new System.Windows.Forms.ListBox();
            this._configButton = new System.Windows.Forms.Button();
            this._statusStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._versionLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 385);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(702, 22);
            this._statusStrip.TabIndex = 0;
            // 
            // _versionLabel
            // 
            this._versionLabel.Name = "_versionLabel";
            this._versionLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // _closeButton
            // 
            this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._closeButton.Location = new System.Drawing.Point(595, 333);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(95, 40);
            this._closeButton.TabIndex = 3;
            this._closeButton.Text = "关闭";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
            // 
            // _stopButton
            // 
            this._stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._stopButton.Location = new System.Drawing.Point(595, 231);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(95, 40);
            this._stopButton.TabIndex = 1;
            this._stopButton.Text = "关闭服务";
            this._stopButton.UseVisualStyleBackColor = true;
            this._stopButton.Click += new System.EventHandler(this._stopButton_Click);
            // 
            // _startButton
            // 
            this._startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._startButton.Location = new System.Drawing.Point(595, 188);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(95, 40);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "启动服务";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(577, 361);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._logListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(569, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "日志";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _logListBox
            // 
            this._logListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logListBox.FormattingEnabled = true;
            this._logListBox.Location = new System.Drawing.Point(3, 3);
            this._logListBox.Name = "_logListBox";
            this._logListBox.Size = new System.Drawing.Size(563, 329);
            this._logListBox.TabIndex = 0;
            // 
            // _configButton
            // 
            this._configButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._configButton.Location = new System.Drawing.Point(595, 290);
            this._configButton.Name = "_configButton";
            this._configButton.Size = new System.Drawing.Size(95, 40);
            this._configButton.TabIndex = 2;
            this._configButton.Text = "选项";
            this._configButton.UseVisualStyleBackColor = true;
            this._configButton.Click += new System.EventHandler(this._configButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 407);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this._startButton);
            this.Controls.Add(this._configButton);
            this.Controls.Add(this._stopButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._statusStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "评价保护服务";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _versionLabel;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _stopButton;
        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox _logListBox;
        private System.Windows.Forms.Button _configButton;
    }
}

