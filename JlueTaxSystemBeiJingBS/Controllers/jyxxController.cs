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
    [RoutePrefix("sbzs-cjpt-web/jyxx")]
    public class jyxxController : ApiController
    {
        [Route("updateJyxx.do")]
        public JValue updateJyxx()
        {
            JValue re_json = new JValue("");
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("updateJyxx.json"));
            re_json = JsonConvert.DeserializeObject<JValue>(str);

            return re_json;
        }

    }
}
