using JlueTaxSystemBeiJingBS.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JlueTaxSystemBeiJingBS.Code
{
    public interface IYsbqcSetting
    {
        string ysbzt { get; set; }
        string wsbzt { get; set; }

        GDTXBeiJingUserYSBQC getUserYSBQC(Type controller);

        GDTXBeiJingUserYSBQC getUserYSBQC(string dm);

        List<GDTXBeiJingUserYSBQC> getYsbUserYSBQC();

        GTXResult SaveUserYSBQCReportData(JToken json, string userYsbqcId, string reportCode);

        GTXResult SaveUserYSBQCReportData(string strJson, string userYsbqcId, string reportCode);

        string make(string userYsbqcId);

        void UpdateYsbqcSBSE(string userYSBQCId, JToken input_jo, string ywbm);

        JArray getsbzfmx(string sbblxDm);

        void sbZfSubmit(string yzpzzlDm);

        void getNsrxx(ref JObject in_jo);

        void getHeadNsrxx(ref JObject in_jo);

        void getYbnsrzzsBnlj(ref JObject in_jo);

        JArray aqsb_getSbqcList();

        GDTXDate getGDTXDate();

        void formatCd(ref JObject in_jo);
    }
}
