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
    [RoutePrefix("sbzs-cjpt-web/nssb/zzsybnsr/sffx")]
    public class sffxController : ApiController
    {
        [Route("getData.do")]
        public JObject getData()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("getData.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            return re_json;
        }

    }
}
