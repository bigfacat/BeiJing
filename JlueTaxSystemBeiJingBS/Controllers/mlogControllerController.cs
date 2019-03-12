using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("xxmh/mlogController")]
    public class mlogControllerController : ApiController
    {
        [Route("addLog.do")]
        public JObject addLog()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("addLog.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            return re_json;
        }

    }
}
