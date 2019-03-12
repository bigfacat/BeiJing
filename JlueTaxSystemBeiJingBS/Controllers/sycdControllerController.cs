using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JlueTaxSystemBeiJingBS.Code;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("xxmh/sycdController")]
    public class sycdControllerController : ApiController
    {
        IYsbqcSetting set;
        public sycdControllerController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("getCd.do")]
        [HttpPost]
        public JObject getCd()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("getCd.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);
            set.getHeadNsrxx(ref re_json);
            set.formatCd(ref re_json);
            return re_json;
        }

    }
}
