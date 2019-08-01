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
    public class nssbController : Controller
    {
        YsbqcSetting set { get; set; }

        Service service { get; set; }

        string action { get { return RouteData.Values["action"].ToString(); } }

        JToken retJtok { get; set; }

        JObject retJobj { get; set; }

        JArray retJarr { get; set; }

        JValue retJval { get; set; }

        string retStr { get; set; }

        ContentResult cr { get; set; }

        ActionResult ar { get; set; }

        Model m { get; set; }

        List<string> param { get; set; }

        public nssbController( YsbqcSetting _set,Service _ser)
        {
            set = _set;
            service = _ser;
            param = new List<string>();
        }

        [Route("sbzs-cjpt-web/nssb/zzsybnsr/sffx/getData.do")]
        public JObject getData()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            return retJobj;
        }

        [Route("sbzs-cjpt-web/nssb/getOtherData.do")]
        public JValue getOtherData()
        {
            param.Add(action);
            retJval = set.GetXmlValue(param);
            return retJval;
        }

        [Route("sbzs-cjpt-web/nssb/jscwbbSbqx.do")]
        public ActionResult jscwbbSbqx()
        {
            param.Add(action);
            retJtok = set.GetJsonValue(param);
            ar = set.ValueResult(retJtok);
            return ar;
        }

        [Route("sbzs-cjpt-web/nssb/sbzf/sbzf.do")]
        public ActionResult sbzf()
        {
            param.Add(action);
            cr = set.GetHtml(param);
            return cr;
        }

        [Route("sbzs-cjpt-web/nssb/sbzf/getSsqz.do")]
        public string getSsqz()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            service.getSsqz(retJobj);
            retStr = set.JsonToString(retJobj);
            return retStr;
        }

        [Route("sbzs-cjpt-web/nssb/sbzf/getsbzf.do")]
        public ActionResult getsbzf()
        {
            param.Add(action);
            retJtok = set.GetJsonValue(param);
            service.getsbzf(retJtok);
            ar = set.ValueResult(retJtok);
            //retJval = set.JTokenToJValue(retJtok);
            return ar;
        }

        [Route("sbzs-cjpt-web/nssb/jySbgzOrzf.do")]
        public ActionResult jySbgzOrzf()
        {
            param.Add(action);
            retJtok = set.GetJsonValue(param);
            ar = set.ValueResult(retJtok);
            return ar;
        }

        [Route("sbzs-cjpt-web/nssb/sbzf/getSbqx.do")]
        public string getSbqx()
        {
            param.Add(action);
            retStr = set.GetJsonString(param);
            return retStr;
        }

        [Route("sbzs-cjpt-web/nssb/sbzf/sbzfmx.do")]
        public ActionResult sbzfmx(int pzxh)
        {
            m = service.getModel(pzxh);
            return View(m);
        }

        [Route("sbzs-cjpt-web/nssb/sbzf/getsbzfmx.do")]
        public string getsbzfmx(int pzxh)
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            service.getsbzfmx(pzxh, retJobj);
            return set.JsonToString(retJobj);
        }

        [Route("sbzs-cjpt-web/nssb/sbzf/sbZfSubmit.do")]
        public string sbZfSubmit()
        {
            JObject reqParamsJSON = JObject.Parse(Request.Form["reqParamsJSON"]);
            string pzxh = reqParamsJSON["pzxh"].ToString();
            service.sbZfSubmit(int.Parse(pzxh));
            param.Add(action);
            retStr = set.GetJsonString(param);
            return retStr;
        }

    }
}