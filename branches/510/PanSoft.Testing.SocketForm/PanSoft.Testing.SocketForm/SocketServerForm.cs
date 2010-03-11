using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gean.Net;

namespace PanSoft.Testing.SocketForm
{
    public partial class SocketServerForm : Form
    {
        public SocketServerForm()
        {
            InitializeComponent();
            this.Size = new Size(900, 700);
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            SocketServer server = SocketServer.Instance;
            server.Start();
        }


    }
}
