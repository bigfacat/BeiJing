using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/biz/sbqc")]
    public class sbqcController : Controller
    {
        [Route("sbqc_aqsb")]
        public string sbqc_aqsb()
        {
            string str = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "sbzs-cjpt-web/biz/sbqc/sbqc_aqsb.html");
            return str;
        }

        [Route("sbqc_qtsb")]
        public string sbqc_qtsb()
        {
            string str = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "sbzs-cjpt-web/biz/sbqc/sbqc_qtsb.html");
            return str;
        }

    }
}