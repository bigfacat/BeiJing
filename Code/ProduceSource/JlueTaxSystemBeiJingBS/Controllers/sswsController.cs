using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("zlpz-cjpt-web/view/ssws")]
    public class sswsController : Controller
    {
        [Route("viewAttachment.jsp")]
        public ActionResult viewAttachment()
        {
            return View("FunctionNotOpen");
        }
    }
}