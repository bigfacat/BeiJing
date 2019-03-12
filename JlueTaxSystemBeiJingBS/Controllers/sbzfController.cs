using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JlueTaxSystemBeiJingBS.Code;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/nssb/sbzf")]
    public class sbzfController : Controller
    {
        IYsbqcSetting set;
        public sbzfController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("sbzf.do")]
        public void sbzf()
        {
            string str = System.IO.File.ReadAllText(Server.MapPath("sbzf.html"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("getSsqz.do")]
        public JObject getSsqz()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("getSsqz.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);
            GDTXBeiJingUserYSBQC qc = set.getUserYSBQC(typeof(ybnsrzzsController));
            re_json["sbrqq"] = qc.SBQX.Substring(0, 8) + "01";
            re_json["sbrqz"] = qc.SBQX;
            return re_json;
        }

        [Route("getsbzf.do")]
        public string getsbzf()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("getsbzf.json"));
            re_json = JObject.Parse(JsonConvert.DeserializeObject<JValue>(str).Value<string>());
            JArray sbzfList = new JArray();
            List<GDTXBeiJingUserYSBQC> ysbqclist = set.getYsbUserYSBQC();
            foreach (GDTXBeiJingUserYSBQC item in ysbqclist)
            {
                JObject item_jo = new JObject();
                item_jo["yzpzzlmc"] = item.TaskName;
                item_jo["sbrq"] = item.HappenDate;
                item_jo["skssqq"] = item.SKSSQQ;
                item_jo["skssqz"] = item.SKSSQZ;
                item_jo["ybtse"] = item.SBSE;
                item_jo["sbqdzf"] = "Y";
                item_jo["sbfsDm"] = "32";
                item_jo["pzxh"] = "10011119000006167259";
                item_jo["gdslxDm"] = "2";
                item_jo["yzpzzlDm"] = item.yzpzzlDm;
                item_jo["zsxmDm"] = item.ZSXM;
                item_jo["zsxmmc"] = item.ZSXM;
                item_jo["sbfsmc"] = "网络申报";
                sbzfList.Add(item_jo);
            }
            re_json["sbzfList"] = sbzfList;
            JValue jv = new JValue(JsonConvert.SerializeObject(re_json));
            Response.ContentType = "text/plain;charset=UTF-8";
            return JsonConvert.SerializeObject(jv);
        }

        [Route("getSbqx.do")]
        public string getSbqx()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("getSbqx.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            return str;
        }

        [Route("sbzfmx.do")]
        public System.Web.Mvc.ActionResult sbzfmx(string sbblxDm)
        {
            ViewBag.sbblxDm = sbblxDm;
            return View();
        }

        [Route("getsbzfmx.do")]
        public string getsbzfmx(string sbblxDm)
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("getsbzfmx." + sbblxDm + ".json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);
            re_json["sbzfMxList"] = set.getsbzfmx(sbblxDm);
            return JsonConvert.SerializeObject(re_json);
        }

        [Route("sbZfSubmit.do")]
        public string sbZfSubmit(string reqParamsJSON)
        {
            string yzpzzlDm = JObject.Parse(reqParamsJSON)["yzpzzlDm"].Value<string>();
            JObject re_json = new JObject();
            set.sbZfSubmit(yzpzzlDm);
            re_json["code"] = 200;
            re_json["msg"] = "作废成功";
            JValue re_jv = new JValue(JsonConvert.SerializeObject(re_json));
            Response.ContentType = "application/json;charset=UTF-8";
            return JsonConvert.SerializeObject(re_jv);
        }

    }
}