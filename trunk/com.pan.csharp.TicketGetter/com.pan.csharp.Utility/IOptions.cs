using System;
using System.Collections.Generic;
using System.Text;

namespace com.pan.csharp.Utility
{
    public interface IOptions
    {
        string Get(string key);
        IDataArray GetArray(string key);
        IDataTree GetTree(string key);
    }
}
