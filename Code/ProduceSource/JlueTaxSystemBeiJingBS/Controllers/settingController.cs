using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JlueTaxSystemBeiJingBS.Code;
using System.IO;
using System.Web;
using System.Text;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/setting")]
    public class settingController : ApiController
    {
        IYsbqcSetting set;
        public settingController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("mainSetting.do")]
        public JValue mainSetting(string ywbm)
        {
            JObject re_json = new JObject();
            string str = File.ReadAllText(HttpContext.Current.Server.MapPath("mainSetting." + ywbm + ".json"));
            re_json = JObject.Parse(JsonConvert.DeserializeObject<JValue>(str).Value<string>());

            GDTXBeiJingUserYSBQC ysbqc = set.getUserYSBQC(ywbm);

            GTXResult gr = GTXMethod.GetUserReportData(ysbqc.Id.ToString(), ywbm);
            if (gr.IsSuccess)
            {
                List<GDTXBeiJingUserYSBQCReportData> dataList = JsonConvert.DeserializeObject<List<GDTXBeiJingUserYSBQCReportData>>(gr.Data.ToString());
                if (dataList.Count > 0)
                {
                    byte[] outputb = Convert.FromBase64String(dataList[0].DataValue);
                    string dataValue = Encoding.Default.GetString(outputb);
                    re_json["body"] = dataValue;
                }
            }

            return new JValue(JsonConvert.SerializeObject(re_json));
        }

        [Route("saveData.do")]
        public JValue saveData(string ywbm, [FromBody]string obj)
        {
            JObject re_json = new JObject();

            GDTXBeiJingUserYSBQC ysbqc = set.getUserYSBQC(ywbm);

            GTXResult saveresult = set.SaveUserYSBQCReportData(obj, ysbqc.Id.ToString(), ywbm);
            if (saveresult.IsSuccess)
            {
                re_json["returnFlag"] = "Y";
            }
            else
            {
                re_json["returnFlag"] = "N";
            }

            return new JValue(JsonConvert.SerializeObject(re_json));
        }

    }
}