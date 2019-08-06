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
using System.Web.Routing;

namespace JlueTaxSystemBeiJing.Code
{
    public class ActionFilter : IActionFilter
    {
        //
        // 摘要: 
        //     在执行操作方法之前调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string action = filterContext.RouteData.GetRequiredString("action");
            if (action == "QuestionMain" || action == "index_login")
            {
                return;
            }
            string split = "/";
            string userId = YsbqcSetting.getSession().userId;
            string path = AppDomain.CurrentDomain.BaseDirectory + split + "Log" + split + userId;
            string fileFullPath = path + split + "Session.json";
            if (!System.IO.File.Exists(fileFullPath))
            {
                return;
            }
            string str = System.IO.File.ReadAllText(fileFullPath);
            JObject jo = JsonConvert.DeserializeObject<JObject>(str);
            YsbqcSetting.insertSession(jo);
        }

        // 摘要: 
        //     在执行操作方法后调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}
