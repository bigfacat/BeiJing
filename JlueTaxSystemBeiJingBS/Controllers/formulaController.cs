using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/formula")]
    public class formulaController : ApiController
    {
        [Route("exttbsm.do")]
        public string exttbsm()
        {
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("exttbsm.json"));
            return str;
        }

    }
}
