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
    [RoutePrefix("xxmh/portalSer")]
    public class portalSerController : ApiController
    {
        IYsbqcSetting set;
        public portalSerController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("checkLogin.do")]
        public JObject checkLogin()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("checkLogin.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            return re_json;
        }

        [Route("getSubMenus.do")]
        public string getSubMenus(string m1)
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("getSubMenus." + m1 + ".json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            return JsonConvert.SerializeObject(re_json, Formatting.None);
        }

        [Route("getRootMenu.do")]
        public string getRootMenu()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("getRootMenu.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);
            set.getHeadNsrxx(ref re_json);
            return JsonConvert.SerializeObject(re_json, Formatting.None);
        }

    }
}
