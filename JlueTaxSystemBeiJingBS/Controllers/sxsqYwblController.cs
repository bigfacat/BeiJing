using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sxsq-cjpt-web/sxsqYwbl")]
    public class sxsqYwblController : Controller
    {
        [Route("verifyWtmenu.do")]
        public ActionResult verifyWtmenu()
        {
            return View("FunctionNotOpen");
        }
    }
}