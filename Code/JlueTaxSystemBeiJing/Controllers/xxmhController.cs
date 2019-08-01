using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using JlueTaxSystemBeiJing.Code;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJing.Controllers
{
    public class xxmhController : Controller
    {
        YsbqcSetting set { get; set; }

        Service service { get; set; }

        string action { get { return RouteData.Values["action"].ToString(); } }

        JObject retJobj { get; set; }

        JArray retJarr { get; set; }

        JValue retJval { get; set; }

        string retStr { get; set; }

        ContentResult cr { get; set; }

        ActionResult ar { get; set; }

        List<string> param { get; set; }

        public xxmhController(YsbqcSetting _set, Service _ser)
        {
            set = _set;
            service = _ser;
            param = new List<string>();
        }

        [Route("xxmh/html/index_login.html")]
        public ActionResult index_login()
        {
            string questionId = Request.QueryString["questionId"];
            string userquestionId = Request.QueryString["userquestionId"];
            string companyId = Request.QueryString["companyId"];
            string classId = Request.QueryString["classid"];
            string courseId = Request.QueryString["courseid"];
            string userId = Request.QueryString["userid"];
            string Name = Request.QueryString["Name"];

            if (!string.IsNullOrEmpty(questionId))
            {
                JObject jo = new JObject();
                jo["questionId"] = questionId;
                jo["userquestionId"] = userquestionId;
                jo["companyId"] = companyId;
                jo["classId"] = classId;
                jo["courseId"] = courseId;
                jo["userId"] = userId;
                jo["Name"] = Name;

                YsbqcSetting.insertCache(jo);

                string split;
                split = "/";
                string path = AppDomain.CurrentDomain.BaseDirectory + split + "Log";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string fileFullPath = path + split + "Session.json";
                StringBuilder str = new StringBuilder();
                str.Append(JsonConvert.SerializeObject(jo));
                StreamWriter sw;
                sw = System.IO.File.CreateText(fileFullPath);
                sw.WriteLine(str.ToString());
                sw.Close();
            }

            return View();
        }

        [Route("xxmh/viewsControlController/getGolobalTitle.do")]
        public string getGolobalTitle()
        {
            param.Add(action);
            retStr = set.GetJsonString(param);
            return retStr;
        }

        [Route("xxmh/viewsControlController/getShowGdsbz.do")]
        public string getShowGdsbz()
        {
            param.Add(action);
            retStr = set.GetJsonString(param);
            return retStr;
        }

        [Route("xxmh/portalSer/checkLogin.do")]
        public ActionResult checkLogin()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            ar = set.JsonResult(retJobj);
            return ar;
        }

        [Route("xxmh/bj/tzgg/query.do")]
        public JObject query()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            return retJobj;
        }

        [Route("xxmh/sycdController/getCd.do")]
        public JObject getCd()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            service.setHeadNsrxx(retJobj);
            service.formatCd(retJobj);
            return retJobj;
        }

        [Route("xxmh/myCenterController/getDbsx.do")]
        public JObject getDbsx()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            return retJobj;
        }

        [Route("xxmh/myCenterController/getSstx.do")]
        public JObject getSstx()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            return retJobj;
        }

        [Route("xxmh/myCenterController/getTzgg.do")]
        public JObject getTzgg()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            return retJobj;
        }

        [Route("xxmh/cygnController/getCygncdDetail.do")]
        public JArray getCygncdDetail()
        {
            param.Add(action);
            retJarr = set.GetJsonArray(param);
            return retJarr;
        }

        [Route("xxmh/portalSer/getRootMenu.do")]
        public string getRootMenu()
        {
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            service.setHeadNsrxx(retJobj);
            retStr = set.JsonToString(retJobj);
            return retStr;
        }

        [Route("xxmh/portalSer/getSubMenus.do")]
        public string getSubMenus(string m1)
        {
            param.Add(action);
            param.Add(m1);
            retStr = set.GetJsonString(param);
            return retStr;
        }

        [Route("xxmh/mlogController/addLog.do")]
        public string addLog()
        {
            param.Add(action);
            retStr = set.GetJsonString(param);
            return retStr;
        }

    }
}