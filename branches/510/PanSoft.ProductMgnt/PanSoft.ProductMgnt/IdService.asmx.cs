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
    public class IdService : System.Web.Services.WebService
    {
        IDGenerator idg = new IDGenerator();
        [WebMethod]
        public string GetId()
        {
            return idg.Generate();
        }
    }

    class MyId : IDGenerator
    {
        public MyId()
        {
            ECDsaCng sn = new ECDsaCng();
            CngKey key;
        }
    }
}
