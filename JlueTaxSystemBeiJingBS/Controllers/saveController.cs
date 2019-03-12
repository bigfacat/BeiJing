using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JlueTaxSystemBeiJingBS.Code;
using System.Web;
using System.IO;
using System.Text;

namespace JlueTaxSystemBeiJingBS.Controllers
{
    [RoutePrefix("sbzs-cjpt-web/save")]
    public class saveController : ApiController
    {
        IYsbqcSetting set;
        public saveController(IYsbqcSetting _is)
        {
            this.set = _is;
        }

        [Route("saveYsqbw.do")]
        public JObject saveYsqbw()
        {
            string ywbm = HttpContext.Current.Request["ywbm"];

            JObject re_json = new JObject();
            string str = File.ReadAllText(HttpContext.Current.Server.MapPath("saveYsqbw.json"));
            re_json = JsonConvert.DeserializeObject<JObject>(str);

            string inputData = HttpUtility.UrlDecode(HttpContext.Current.Request.Form["saveData"], Encoding.GetEncoding("utf-8"));
            JObject input_jo = JsonConvert.DeserializeObject<JObject>(inputData);

            GDTXBeiJingUserYSBQC ysbqc = set.getUserYSBQC(ywbm);
            GTXResult saveresult = set.SaveUserYSBQCReportData(input_jo, ysbqc.Id.ToString(), ywbm);
            if (saveresult.IsSuccess)
            {
                set.UpdateYsbqcSBSE(ysbqc.Id.ToString(), input_jo, ywbm);
            }
            else
            {
            }

            return re_json;
        }

    }
}
