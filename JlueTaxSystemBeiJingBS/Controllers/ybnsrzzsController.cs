using JlueTaxSystemBeiJingBS.Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/biz/sbzs/ybnsrzzs")]
    public class ybnsrzzsController : Controller
    {
        GDTXBeiJingUserYSBQC ysbqc;
        IYsbqcSetting set;
        public ybnsrzzsController(IYsbqcSetting _is)
        {
            this.set = _is;
            ysbqc = _is.getUserYSBQC(this.GetType());
        }

        [Route("begin")]
        public void begin()
        {
            string reset = Request["reset"];
            if (reset == "Y")
            {
                GTXMethod.DeleteUserReportData(ysbqc.Id.ToString(), ysbqc.ywbm);
                GTXMethod.UpdateSBSE(ysbqc.Id.ToString(), "");
            }
            string str = System.IO.File.ReadAllText(Server.MapPath("begin.html"));
            Response.ContentType = "text/html;charset=UTF-8";
            Response.Write(str);
        }

        [Route("xFormula")]
        public JArray xFormula()
        {
            JArray re_json = new JArray();
            string str = System.IO.File.ReadAllText(Server.MapPath("xFormula.json"));
            re_json = JsonConvert.DeserializeObject<JArray>(str);
            return re_json;
        }

        [Route("xSheets")]
        public JArray xSheets()
        {
            JArray re_json = new JArray();
            string str = System.IO.File.ReadAllText(Server.MapPath("xSheets.json"));
            re_json = JsonConvert.DeserializeObject<JArray>(str);
            return re_json;
        }

        [Route("xInitData")]
        public JObject xInitData()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("xInitData.init.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            GTXResult gr = GTXMethod.GetUserReportData(ysbqc.Id.ToString(), ysbqc.ywbm);
            if (gr.IsSuccess)
            {
                List<GDTXBeiJingUserYSBQCReportData> dataList = JsonConvert.DeserializeObject<List<GDTXBeiJingUserYSBQCReportData>>(gr.Data.ToString());
                if (dataList.Count > 0)
                {
                    byte[] outputb = Convert.FromBase64String(dataList[0].DataValue);
                    string dataValue = Encoding.Default.GetString(outputb);
                    re_json["body"] = dataValue;
                }
                else
                {
                    JObject re_json_body = JObject.Parse(re_json["body"].Value<string>());
                    JObject zzsybnsrsbInitData = (JObject)re_json_body["qcs"]["initData"]["zzsybnsrsbInitData"];
                    zzsybnsrsbInitData["sbrq"] = ysbqc.HappenDate;
                    zzsybnsrsbInitData["sssq"]["rqQ"] = ysbqc.SKSSQQ;
                    zzsybnsrsbInitData["sssq"]["rqZ"] = ysbqc.SKSSQZ;

                    JObject nsrjbxx = (JObject)re_json_body["qcs"]["initData"]["nsrjbxx"];
                    set.getNsrxx(ref nsrjbxx);

                    set.getYbnsrzzsBnlj(ref zzsybnsrsbInitData);
                    re_json["body"] = new JValue(JsonConvert.SerializeObject(re_json_body));
                }
            }

            return re_json;
        }

        [Route("xTempSave")]
        public JObject xTempSave()
        {
            JObject re_json = new JObject();
            string str = System.IO.File.ReadAllText(Server.MapPath("xTempSave.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            string _query_string_ = "{" + Request["_query_string_"] + "}";
            string ywbm = JObject.Parse(_query_string_)["ywbm"].Value<string>();

            string inputData = HttpUtility.UrlDecode(Request.Form["formData"], Encoding.GetEncoding("utf-8"));
            JObject input_jo = JsonConvert.DeserializeObject<JObject>(inputData);

            GTXResult saveresult = set.SaveUserYSBQCReportData(input_jo, ysbqc.Id.ToString(), ysbqc.ywbm);
            if (saveresult.IsSuccess)
            {
                set.UpdateYsbqcSBSE(ysbqc.Id.ToString(), input_jo, ywbm);
                re_json["returnFlag"] = "Y";
            }
            else
            {
                re_json["returnFlag"] = "N";
            }

            return re_json;
        }

        [Route("make")]
        public System.Web.Mvc.ActionResult make()
        {
            ViewBag.text = set.make(ysbqc.Id.ToString());
            return View();
        }

    }
}