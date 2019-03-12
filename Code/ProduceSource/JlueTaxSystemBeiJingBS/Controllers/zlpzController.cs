using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("zlpz-cjpt-web/zlpz")]
    public class zlpzController : Controller
    {
        [Route("viewOrDownloadPdfFile.do")]
        public ActionResult viewOrDownloadPdfFile()
        {
            return View("FunctionNotOpen");
        }

        [Route("openPdfshow.do")]
        public ActionResult openPdfshow()
        {
            return View("FunctionNotOpen");
        }

    }
}