using System;
using System.Collections.Generic;
using System.Text;

namespace com.pan.csharp.Utility
{
    /// <summary>
    /// 一个描述数据集合接口
    /// </summary>
    public interface IDataArray
    {
        Object Select(String key);
    }
}
