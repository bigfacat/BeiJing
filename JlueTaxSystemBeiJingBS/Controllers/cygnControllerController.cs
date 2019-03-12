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
    [RoutePrefix("xxmh/cygnController")]
    public class cygnControllerController : ApiController
    {
        [Route("getCygncdDetail.do")]
        [HttpPost]
        public JArray getCygncdDetail()
        {
            JArray re_json = new JArray();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("getCygncdDetail.json"));
            re_json = JsonConvert.DeserializeObject<JArray>(str);

            return re_json;
        }

    }
}
