using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using JlueTaxSystemBeiJing.Code;
using JlueTaxSystemBeiJing.Models;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJing.Controllers
{
    public class tycxController : Controller
    {
        YsbqcSetting set { get; set; }

        Service service { get; set; }

        string action { get { return RouteData.Values["action"].ToString(); } }

        JObject retJobj { get; set; }

        JArray retJarr { get; set; }

        JValue retJval { get; set; }

        string retStr { get; set; }

        ContentResult cr { get; set; }

        List<string> param { get; set; }

        Model m { get; set; }

        public tycxController(YsbqcSetting _set, Service _ser)
        {
            set = _set;
            service = _ser;
            param = new List<string>();
        }

        [Route("tycx-cjpt-web/viewsControlController/getCxShowGdsbz.do")]
        public string getCxShowGdsbz()
        {
            param.Add(action);
            retStr = set.GetJsonString(param);
            return retStr;
        }

        [Route("tycx-cjpt-web/cxpt/query.do")]
        public JObject query()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            service.query(retJobj);
            return retJobj;
        }

        [Route("tycx-cjpt-web/cxpt/4thLvlFunTabsInit.do")]
        public ActionResult _4thLvlFunTabsInit()
        {
            param.Add("4thLvlFunTabsInit");
            cr = set.GetHtml(param);
            return cr;
        }

        [Route("tycx-cjpt-web/view/sscx/yhscx/sbzscx/sbxxcx/sbxxcx.jsp")]
        public ActionResult sbxxcx()
        {
            m = service.getModel(Ywbm.lhfjssb.ToString());
            return View(m);
        }

    }
}