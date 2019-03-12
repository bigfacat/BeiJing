using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("xxmh/html")]
    public class htmlController : Controller
    {
        [Route("cygn.html")]
        public ActionResult verifyWtmenu()
        {
            return View("FunctionNotOpen");
        }
    }
}