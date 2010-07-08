using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pansoft.Common.Interface
{
    public delegate void PortDataReceivedEventHandler(object sender, PortDataReceivedEventArgs e);
    public class PortDataReceivedEventArgs : EventArgs
    {

    }
}
