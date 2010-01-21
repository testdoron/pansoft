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
        [WebMethod]
        public string GetId()
        {
            return idg.Generate();
        }

        [WebMethod]
        public string GetIdName(string name, int count)
        {
            return idg.Generate() + " | " + name + " | " + count.ToString();
        }

        [WebMethod]
        public string[] GetArray(int count)
        {
            List<string> strs = new List<string>();
            for (int i = 0; i < count; i++)
            {
                strs.Add(idg.Generate());
            }
            return strs.ToArray();
        }

        [WebMethod]
        public MyClass[] GetMyClass(int count)
        {
            List<MyClass> strs = new List<MyClass>();
            for (int i = 0; i < count; i++)
            {
                strs.Add(new MyClass(idg.Generate(), (i + 2976734) * i));
            }
            return strs.ToArray();
        }

        public class MyClass
        {
            IDGenerator idg = new IDGenerator();

            public MyClass()
            {
                this.ID = idg.Generate();
                this.Arg = DateTime.Now.Ticks;
                this.CurrTime = DateTime.Now;
                this.Guid = Guid.NewGuid();
            }
            public MyClass(string id, int arg)
            {
                this.ID = id;
                this.Arg = arg;
                this.CurrTime = DateTime.Now;
                this.Guid = Guid.NewGuid();
            }

            public string ID { get; set; }
            public long Arg { get; set; }
            public DateTime CurrTime { get; set; }
            public Guid Guid { get; set; }
        }

    }
}
