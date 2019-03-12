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
    [RoutePrefix("sbzs-cjpt-web/biz/yqsb/yqsbqc")]
    public class yqsbqcController : ApiController
    {
        [Route("enterYqsbUrl")]
        [AcceptVerbs("Get", "Post")]
        public JObject enterYqsbUrl(string sbywbm)
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("enterYqsbUrl." + sbywbm + ".json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            return re_json;
        }

    }
}
