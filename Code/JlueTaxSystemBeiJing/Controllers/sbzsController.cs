using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;
using JlueTaxSystemBeiJing.Code;
using Newtonsoft.Json.Schema;
using System.Web;
using JlueTaxSystemBeiJing.Models;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJing.Controllers
{
    public class sbzsController : Controller
    {
        YsbqcSetting set { get; set; }

        Service service { get; set; }

        HttpRequestBase req { get { return Request; } }

        string action { get { return RouteData.Values["action"].ToString(); } }

        JToken retJtok { get; set; }

        JObject retJobj { get; set; }

        JArray retJarr { get; set; }

        JValue retJval { get; set; }

        string retStr { get; set; }

        ContentResult cr { get; set; }

        ActionResult ar { get; set; }

        List<string> param { get; set; }

        Model m { get; set; }

        public sbzsController(YsbqcSetting _set, Service _ser)
        {
            set = _set;
            service = _ser;
            param = new List<string>();
        }

        [Route("sbzs-cjpt-web/jyxx/updateJyxx.do")]
        public JValue updateJyxx()
        {
            param.Add(action);
            retJtok = set.GetJsonValue(param);
            retJval = set.JTokenToJValue(retJtok);
            return retJval;
        }

        [Route("sbzs-cjpt-web/setting/mainSetting.do")]
        public async Task<ActionResult> mainSetting(string ywbm)
        {
            param.Add(action);
            param.Add(ywbm);
            retJtok = set.GetJsonValue(param);
            await service.mainSetting(ywbm.ToLower(), retJtok);
            ar = set.ValueResult(retJtok);
            return ar;
        }

        [Route("sbzs-cjpt-web/setting/saveData.do")]
        public async Task<ActionResult> saveData(string ywbm)
        {
            StreamReader sr = new StreamReader(Request.InputStream);
            JValue obj = new JValue(sr.ReadToEnd());
            await service.SaveDataService(ywbm.ToLower(), obj);
            param.Add(action);
            param.Add(ywbm);
            retJtok = set.GetJsonValue(param);
            ar = set.ValueResult(retJtok);
            return ar;
        }

        [Route("sbzs-cjpt-web/attachmentSb/{act}.do")]
        public ActionResult attachmentSb(string act)
        {
            param.Add(act);
            cr = set.GetHtml(param);
            return cr;
        }

        [Route("sbzs-cjpt-web/sbxxcx/sbxxcx.do")]
        public ActionResult sbxxcx()
        {
            m = service.getModel(Ywbm.lhfjssb.ToString());
            return View(m);
        }

        [Route("sbzs-cjpt-web/sbxxcx/openPdf.do")]
        public string openPdf()
        {
            param.Add(action);
            retStr = set.GetJsonString(param);
            return retStr;
        }

        [Route("sbzs-cjpt-web/sbxxcx/getSbxxcx.do")]
        public ActionResult getSbxxcx()
        {
            param.Add(action);
            retJtok = set.GetJsonValue(param);
            service.getSbxxcx((JObject)retJtok);
            ar = set.ValueResult(retJtok);
            return ar;
        }

        [Route("sbzs-cjpt-web/save/saveYsqbw.do")]
        public async Task<JObject> saveYsqbw()
        {
            string ywbm = req.Form["ywbm"];
            string inputData = HttpUtility.UrlDecode(req.Form["saveData"], Encoding.UTF8);
            JObject input_jo = JsonConvert.DeserializeObject<JObject>(inputData);
            param.Add(action);
            retJobj = set.GetJsonObject(param);
            await service.SaveDataService(ywbm, input_jo);
            return retJobj;
        }

        [Route("sbzs-cjpt-web/sb/gotoSbresult.do")]
        public ActionResult gotoSbresult()
        {
            int ysqxxid = int.Parse(req.Form["ysqxxid"]);
            service.UpdateSBZT(ysqxxid, SBZT.YSB);
            Model m = service.getModel(ysqxxid);
            m.msg = service.getSBCGMessage(ysqxxid);
            return View(m);
        }

        [Route("sbzs-cjpt-web/zsjs/qjsk.do")]
        public ActionResult qjsk()
        {
            return View(YsbqcSetting.functionNotOpen);
        }

    }
}