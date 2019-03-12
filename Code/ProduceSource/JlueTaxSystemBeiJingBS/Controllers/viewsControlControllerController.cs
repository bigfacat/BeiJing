using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    public class viewsControlControllerController : ApiController
    {
        [Route("xxmh/viewsControlController/getShowGdsbz.do")]
        [HttpPost]
        public string getShowGdsbz()
        {
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("getShowGdsbz.json"));
            return str;
        }

        [Route("xxmh/viewsControlController/getGolobalTitle.do")]
        [HttpPost]
        public string getGolobalTitle()
        {
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("getGolobalTitle.json"));
            return str;
        }

        [Route("tycx-cjpt-web/viewsControlController/getCxShowGdsbz.do")]
        [HttpPost]
        public string getCxShowGdsbz()
        {
            string str = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("getCxShowGdsbz.json"));
            return str;
        }

    }
}
