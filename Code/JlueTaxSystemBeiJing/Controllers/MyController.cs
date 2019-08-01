using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JlueTaxSystemBeiJing.Code;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJing.Controllers
{
    public class MyController : Controller
    {
        YsbqcSetting set { get; set; }

        public MyController(YsbqcSetting _set)
        {
            set = _set;
        }

        [Route("zlpz-cjpt-web/view/ssws/viewAttachment.jsp")]
        public ActionResult viewAttachment()
        {
            return View(YsbqcSetting.functionNotOpen);
        }

        [Route("zlpz-cjpt-web/zlpz/viewOrDownloadPdfFile.do")]
        public ActionResult viewOrDownloadPdfFile()
        {
            return View(YsbqcSetting.functionNotOpen);
        }

        [Route("portalExt/controller/menu")]
        public ActionResult menu()
        {
            return View(YsbqcSetting.functionNotOpen);
        }

        [Route("yyzxn-cjpt-web/yyzx/qjss/showQjssPage.do")]
        public ActionResult showQjssPage()
        {
            return View(YsbqcSetting.functionNotOpen);
        }

        [Route("zyywn-cjpt-web/tzgg/preZcfg.do")]
        public ActionResult preZcfg()
        {
            return View(YsbqcSetting.functionNotOpen);
        }

    }
}