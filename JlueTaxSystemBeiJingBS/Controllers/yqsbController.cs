using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/biz/yqsb")]
    public class yqsbController : Controller
    {
        [Route("yqsbqc")]
        public ActionResult yqsbqc()
        {
            return View("FunctionNotOpen");
        }
    }
}