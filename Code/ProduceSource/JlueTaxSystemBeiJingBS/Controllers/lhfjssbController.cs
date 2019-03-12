using JlueTaxSystemBeiJingBS.Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/biz/sbzs/lhfjssb")]
    public class lhfjssbController : Controller
    {
        GDTXBeiJingUserYSBQC ysbqc;
        IYsbqcSetting set;
        public lhfjssbController(IYsbqcSetting _is)
        {
            this.set = _is;
            ysbqc = _is.getUserYSBQC(this.GetType());
        }

        [Route("begin")]
        public void begin()
        {
            string reset = System.Web.HttpContext.Current.Request["reset"];

            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("begin.html"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("xFormula")]
        public JArray xFormula()
        {
            JArray re_json = new JArray();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("xFormula.json"));
            re_json = JsonConvert.DeserializeObject<JArray>(str);
            return re_json;
        }

        [Route("xSheets")]
        public JArray xSheets()
        {
            JArray re_json = new JArray();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("xSheets.json"));
            re_json = JsonConvert.DeserializeObject<JArray>(str);
            return re_json;
        }

        [Route("xInitData")]
        public JObject xInitData()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("xInitData.init.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);
            JObject re_json_body = JObject.Parse(re_json["body"].Value<string>());

            JObject nsrjbxx = (JObject)re_json_body["qcs"]["initData"]["nsrjbxx"];
            set.getNsrxx(ref nsrjbxx);

            JObject fjssbInitData = (JObject)re_json_body["qcs"]["initData"]["fjssbInitData"];
            nsrjbxx["tbrq"] = ysbqc.HappenDate;
            fjssbInitData["sssq"]["rqQ"] = ysbqc.SKSSQQ;
            fjssbInitData["sssq"]["rqZ"] = ysbqc.SKSSQZ;

            re_json["body"] = new JValue(JsonConvert.SerializeObject(re_json_body));
            return re_json;
        }

        [Route("make")]
        public System.Web.Mvc.ActionResult make()
        {
            ViewBag.text = set.make(ysbqc.Id.ToString());
            return View();
        }
    }
}