using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pansoft.Common.Interface
{
    public interface IDriver
    {
        IDevice Owner { get; }
        void DataTransport();
    }
}
