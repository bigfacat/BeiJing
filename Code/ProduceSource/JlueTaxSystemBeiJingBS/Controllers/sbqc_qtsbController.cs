using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JlueTaxSystemBeiJingBS.Models;
using JlueTaxSystemBeiJingBS.Code;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/biz/sbqc/sbqc_qtsb")]
    public class sbqc_qtsbController : Controller
    {
        IYsbqcSetting set;
        public sbqc_qtsbController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("setting")]
        public System.Web.Mvc.ActionResult setting()
        {
            GDTXDate gd = set.getGDTXDate();
            return View(gd);
        }

        [Route("setting/doWord.jsp")]
        public void doWord()
        {
            string str = System.IO.File.ReadAllText(Server.MapPath("doWord.jsp"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("setting/lhQtsbbs.jsp")]
        public void lhQtsbbs()
        {
            string str = System.IO.File.ReadAllText(Server.MapPath("lhQtsbbs.jsp"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("enterQtsb")]
        public JObject enterQtsb()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("enterQtsb.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);
            re_json["qtsbList"][0]["skssqQ"] = "2018-12-01";
            re_json["qtsbList"][0]["skssqZ"] = "2018-12-31";
            return re_json;
        }

        [Route("sburlControl")]
        public string sburlControl(string sbywbm)
        {
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("sburlControl." + sbywbm + ".json"));
            return str;
        }

    }
}