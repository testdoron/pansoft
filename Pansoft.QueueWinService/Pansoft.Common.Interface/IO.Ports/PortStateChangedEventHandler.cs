using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pansoft.Common.Interface
{
    public delegate void PortStateChangedEventHandler(object sender, PortStateChangedEventArgs e);
    public class PortStateChangedEventArgs : EventArgs
    {
        public PortStateChangedEventArgs(int statusByte)
        {
            this.PortStatusByte = statusByte;
        }
        public int PortStatusByte { get; private set; }
    }
}
