using System.Collections.Generic;

namespace com.pan.csharp.Utility
{
    public interface IDataTree
    {
        object Select(string key);
        object Parent { get; set; }
        bool HasChildren { get; }
        IList<IItem> Items { get; set; }
    }
}
