using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("zyywn-cjpt-web/tzgg")]
    public class tzggController : Controller
    {
        [Route("syTzgg.do")]
        public JObject syTzgg()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("syTzgg.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            return re_json;
        }

        [Route("preZngg.do")]
        public ActionResult preZngg()
        {
            return View("FunctionNotOpen");
        }

    }
}