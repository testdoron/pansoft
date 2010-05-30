using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.pan.csharp.TicketGetter.OptionForm
{
    public partial class OptionForm : Form
    {
        private OptionForm()
        {
            InitializeComponent();
        }

        private static OptionForm _OptionForm = null;

        public static OptionForm Instance()
        {
            if (_OptionForm == null)
            {
                _OptionForm = new OptionForm();
            }
            return _OptionForm;
        }
    }
}
