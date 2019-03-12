using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("yyzxn-cjpt-web/yyzx/qjss")]
    public class qjssController : Controller
    {
        [Route("showQjssPage.do")]
        public ActionResult showQjssPage()
        {
            return View("FunctionNotOpen");
        }
    }
}