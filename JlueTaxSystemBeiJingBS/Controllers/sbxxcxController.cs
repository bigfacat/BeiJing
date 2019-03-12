using JlueTaxSystemBeiJingBS.Code;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using JlueTaxSystemBeiJingBS.Models;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/sbxxcx")]
    public class sbxxcxController : Controller
    {
        IYsbqcSetting set;
        public sbxxcxController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("sbxxcx.do")]
        public System.Web.Mvc.ActionResult sbxxcx()
        {
            GDTXDate gd = set.getGDTXDate();
            return View(gd);
        }

        [Route("getSbxxcx.do")]
        public void getSbxxcx()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("getSbxxcx.json"));
            re_json = JObject.Parse(JsonConvert.DeserializeObject<JValue>(str).Value<string>());
            JArray sbList = new JArray();
            List<GDTXBeiJingUserYSBQC> ysbqclist = set.getYsbUserYSBQC();
            foreach (GDTXBeiJingUserYSBQC item in ysbqclist)
            {
                JObject item_jo = new JObject();
                item_jo["id"] = "EAD5D43EFFFFFF8A169783ECF841A023";
                item_jo["pzxh"] = "10011119000006167259";
                item_jo["gdslxDm"] = "2";
                item_jo["showType"] = "2";
                item_jo["ywbm"] = item.ywbm.ToUpper();
                item_jo["version"] = "1";
                item_jo["sbzfbz"] = "N";
                item_jo["ywbmmc"] = item.TaskName;
                item_jo["zsxmmc"] = item.ZSXM;
                item_jo["sbrq"] = item.HappenDate;
                item_jo["ssqq"] = item.SKSSQQ;
                item_jo["ssqz"] = item.SKSSQZ;
                item_jo["ybtse"] = item.SBSE;
                sbList.Add(item_jo);
            }
            re_json["sbList"] = sbList;

            JValue jv = new JValue(JsonConvert.SerializeObject(re_json));
            Response.ContentType = "application/json;charset=UTF-8";
            Response.Write(JsonConvert.SerializeObject(jv));
        }

        [Route("openPdf.do")]
        public string openPdf()
        {
            string str = System.IO.File.ReadAllText(Server.MapPath("openPdf.json"));
            return str;
        }

    }
}