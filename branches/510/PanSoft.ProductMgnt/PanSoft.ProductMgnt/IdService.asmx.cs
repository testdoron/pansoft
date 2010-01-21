using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Gean;
using System.Security.Cryptography;

namespace PanSoft.ProductMgnt
{
    /// <summary>
    /// IdService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://server/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class IdService : WebService
    {
        IDGenerator idg = new IDGenerator();

        /// <summary>
        /// 获取一个全局Id
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetId()
        {
            return idg.Generate();
        }

        /// <summary>
        /// 获取一组指定数量的ID
        /// </summary>
        /// <param name="count">指定数量</param>
        /// <returns></returns>
        [WebMethod]
        public string[] GetIdArray(int count)
        {
            List<string> strs = new List<string>();
            for (int i = 0; i < count; i++)
            {
                strs.Add(idg.Generate());
            }
            return strs.ToArray();
        }

    }
}
