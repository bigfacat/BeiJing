using JlueTaxSystemBeiJingBS.Code;
using JlueTaxSystemBeiJingBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("tycx-cjpt-web/view")]
    public class viewController : Controller
    {
        IYsbqcSetting set;
        public viewController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("sscx/yhscx/sbzscx/sbxxcx/sbxxcx.jsp")]
        public System.Web.Mvc.ActionResult sbxxcx()
        {
            GDTXDate gd = set.getGDTXDate();
            return View(gd);
        }

        [Route("sscx/yhscx/sbzscx/yqwsbcx/yqwsbcx.jsp")]
        public System.Web.Mvc.ActionResult yqwsbcx()
        {
            return View("FunctionNotOpen");
        }

    }
}