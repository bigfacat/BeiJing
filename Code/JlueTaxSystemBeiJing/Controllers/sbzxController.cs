using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using JlueTaxSystemBeiJing.Code;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJing.Controllers
{
    public class sbzxController : Controller
    {
        YsbqcSetting set { get; set; }

        string action { get { return RouteData.Values["action"].ToString(); } }

        JObject retJobj { get; set; }

        List<string> param { get; set; }

        public sbzxController(YsbqcSetting _set)
        {
            set = _set;
            param = new List<string>();
        }

        [Route("sbzx-cjpt-web/ywzt/getYsData.do")]
        public JObject getYsData()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            return retJobj;
        }

    }
}