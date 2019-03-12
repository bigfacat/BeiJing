using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("portalExt/controller")]
    public class controllerController : Controller
    {
        [Route("menu")]
        public ActionResult menu()
        {
            return View("FunctionNotOpen");
        }
    }
}