using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JlueTaxSystemBeiJingBS.Code;
using JlueTaxSystemBeiJingBS.Models;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/biz/sbqc/sbqc_aqsb")]
    public class sbqc_aqsbController : Controller
    {
        IYsbqcSetting set;
        public sbqc_aqsbController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("setting")]
        public System.Web.Mvc.ActionResult setting()
        {
            GDTXDate gd = set.getGDTXDate();
            return View(gd);
        }

        [Route("setting/doHead.jsp")]
        public void doHead()
        {
            string str = System.IO.File.ReadAllText(Server.MapPath("doHead.jsp"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("setting/lhSbbbs.jsp")]
        public void lhSbbbs()
        {
            string str = System.IO.File.ReadAllText(Server.MapPath("lhSbbbs.jsp"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("setting/lhSbbbsKz.jsp")]
        public void lhSbbbsKz()
        {
            string str = System.IO.File.ReadAllText(Server.MapPath("lhSbbbsKz.jsp"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("setting/lhCwbbbsKz.jsp")]
        public void lhCwbbbsKz()
        {
            string str = System.IO.File.ReadAllText(Server.MapPath("lhCwbbbsKz.jsp"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("setting/doWord.jsp")]
        public void doWord()
        {
            string str = System.IO.File.ReadAllText(Server.MapPath("doWord.jsp"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("enterSbqc")]
        public JObject enterSbqc()
        {
            System.Threading.Thread.Sleep(100);

            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("enterSbqc.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);
            re_json["sbqcList"] = set.aqsb_getSbqcList();
            return re_json;
        }

        [Route("refreshSbqc")]
        public JObject refreshSbqc(string type)
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("refreshSbqc." + type + ".json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);
            re_json["sbqcList"] = set.aqsb_getSbqcList();
            return re_json;
        }

        [Route("sbqxControl")]
        public string sbqxControl(string type)
        {
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("sbqxControl." + type + ".json"));
            return str;
        }

        [Route("sburlControl")]
        public string sburlControl(string sbywbm)
        {
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("sburlControl." + sbywbm + ".json"));
            return str;
        }

        [Route("cburlControl")]
        public JObject cburlControl(string sbywbm)
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("cburlControl." + sbywbm + ".json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            return re_json;
        }

    }
}