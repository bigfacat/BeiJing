using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Text;
using JlueTaxSystemBeiJingBS.Code;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("tycx-cjpt-web/cxpt")]
    public class cxptController : ApiController
    {
        IYsbqcSetting set;
        public cxptController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("query.do")]
        [HttpGet]
        public JObject query(string gdslxDm)
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("query.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);
            JArray ysbxx = new JArray();
            if (gdslxDm == "1")
            {
                List<GDTXBeiJingUserYSBQC> ysbqclist = set.getYsbUserYSBQC();
                foreach (GDTXBeiJingUserYSBQC item in ysbqclist)
                {
                    JObject item_jo = new JObject();
                    item_jo["gdslx"] = "国地税";
                    item_jo["zsxmmc"] = item.ZSXM;
                    item_jo["zspmmc"] = item.ZSXM;
                    item_jo["dzbzdszlmc"] = item.TaskName;
                    item_jo["sbrq_1"] = item.HappenDate;
                    item_jo["sbqx"] = item.SBQX;
                    item_jo["skssqq"] = item.SKSSQQ;
                    item_jo["skssqz"] = item.SKSSQZ;
                    item_jo["ysx"] = "";
                    item_jo["ynse"] = "";
                    item_jo["jmse"] = "";
                    item_jo["yjse"] = "";
                    item_jo["ybtse"] = item.SBSE;
                    ysbxx.Add(item_jo);
                }
                re_json["taxML"]["body"]["taxML"]["ysbxxList"]["ysbxx"] = ysbxx;
            }
            return re_json;
        }

        [Route("4thLvlFunTabsInit.do")]
        [HttpGet]
        public HttpResponseMessage _4thLvlFunTabsInit()
        {
            string str = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("4thLvlFunTabsInit.html"));

            return new HttpResponseMessage()
            {
                Content = new StringContent(str, Encoding.UTF8, "text/html")
            };
        }

    }
}
