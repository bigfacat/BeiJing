using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JlueTaxSystemBeiJingBS.Code;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/biz/setting")]
    public class ybnsrzzsxbszController : Controller
    {
        IYsbqcSetting ysbqcSetting;
        public ybnsrzzsxbszController(IYsbqcSetting _ysbqcSetting)
        {
            this.ysbqcSetting = _ysbqcSetting;
        }

        [Route("ybnsrzzsxbsz")]
        public void ybnsrzzsxbsz()
        {
            string str = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "sbzs-cjpt-web/biz/setting/ybnsrzzsxbsz.htm");
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }
    }
}