using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using System.Web.Caching;
using System.Web;

namespace JlueTaxSystemBeiJing.Code
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string split;
            split = "/";
            string path = AppDomain.CurrentDomain.BaseDirectory + split + "Log";
            string fileFullPath = path + split + "Session.json";
            if (!System.IO.File.Exists(fileFullPath))
            {
                return;
            }
            string str = System.IO.File.ReadAllText(fileFullPath);
            JObject jo = JsonConvert.DeserializeObject<JObject>(str);
            YsbqcSetting.insertCache(jo);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}
