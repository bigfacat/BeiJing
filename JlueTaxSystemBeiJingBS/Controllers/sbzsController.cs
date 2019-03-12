using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/biz/sbzs")]
    public class sbzsController : Controller
    {
        [Route("ybnsrzzs")]
        public ActionResult ybnsrzzs(string ybsb)
        {
            if (ybsb == "Y")
            {
                return View("FunctionNotOpen");
            }
            return View();
        }

        [Route("lhfjssb")]
        public void lhfjssb()
        {
            string str = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "sbzs-cjpt-web/biz/sbzs/lhfjssb.html");
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

    }
}