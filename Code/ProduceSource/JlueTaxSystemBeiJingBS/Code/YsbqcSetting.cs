using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using JlueTaxSystemBeiJingBS.Models;
using JlueTaxSystemBeiJingBS.Controllers;

namespace JlueTaxSystemBeiJingBS.Code
{
    public class YsbqcSetting : IYsbqcSetting
    {
        public string ysbzt
        {
            get
            {
                return "已申报";
            }
            set { }
        }
        public string wsbzt
        {
            get { return "未申报"; }
            set { }
        }

       public GDTXBeiJingUserYSBQC getUserYSBQC(Type controller)
       {
           string s = controller.Name;
           s = s.Substring(0, s.IndexOf("Controller"));
           GTXResult resultq = GTXMethod.GetBeiJingYSBQC();
           if (resultq.IsSuccess)
           {
               List<GDTXBeiJingUserYSBQC> ysbqclist = JsonConvert.DeserializeObject<List<GDTXBeiJingUserYSBQC>>(resultq.Data.ToString());

               ysbqclist = ysbqclist.Where(a => a.ywbm.ToUpper() == s.ToUpper() || a.BDDM.ToUpper() == s.ToUpper()).ToList();
               return ysbqclist[0];
           }
           else
           {
               //return new GDTXBeiJingUserYSBQC();
               return null;
           }
       }

       public GDTXBeiJingUserYSBQC getUserYSBQC(string dm)
       {
           string s = dm.ToUpper();
           switch (s)
           {
               case "YBNSRZZSXBSZ":
                   s = "YBNSRZZS";
                   break;
           }
           GTXResult resultq = GTXMethod.GetBeiJingYSBQC();
           if (resultq.IsSuccess)
           {
               List<GDTXBeiJingUserYSBQC> ysbqclist = JsonConvert.DeserializeObject<List<GDTXBeiJingUserYSBQC>>(resultq.Data.ToString());

               ysbqclist = ysbqclist.Where(a => a.ywbm.ToUpper() == s || a.BDDM.ToUpper() == s || a.yzpzzlDm == s.ToUpper() || a.sbblxDm.ToUpper() == s).ToList();
               return ysbqclist[0];
           }
           else
           {
               return null;
           }
       }

       public List<GDTXBeiJingUserYSBQC> getYsbUserYSBQC()
       {
           GTXResult resultq = GTXMethod.GetBeiJingYSBQC();
           if (resultq.IsSuccess)
           {
               List<GDTXBeiJingUserYSBQC> ysbqclist = JsonConvert.DeserializeObject<List<GDTXBeiJingUserYSBQC>>(resultq.Data.ToString());

               ysbqclist = ysbqclist.Where(a => a.SBZT == "已申报").ToList();
               return ysbqclist;
           }
           else
           {
               return null;
           }
       }

       public GTXResult SaveUserYSBQCReportData(JToken json, string userYsbqcId, string reportCode)
       {
           List<GTXNameValue> nameList = new List<GTXNameValue>();
           GTXNameValue nv = new GTXNameValue();
           nv.key = "data";
           byte[] bytes = Encoding.Default.GetBytes(JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.None));
           string _result = HttpUtility.UrlEncode(Convert.ToBase64String(bytes));
           nv.value = _result;
           nameList.Add(nv);
           GTXResult saveresult = GTXMethod.SaveUserReportData(JsonConvert.SerializeObject(nameList), userYsbqcId, reportCode);
           return saveresult;
       }

       public GTXResult SaveUserYSBQCReportData(string strJson, string userYsbqcId, string reportCode)
       {
           List<GTXNameValue> nameList = new List<GTXNameValue>();
           GTXNameValue nv = new GTXNameValue();
           nv.key = "data";
           byte[] bytes = Encoding.Default.GetBytes(strJson);
           string _result = HttpUtility.UrlEncode(Convert.ToBase64String(bytes));
           nv.value = _result;
           nameList.Add(nv);
           GTXResult saveresult = GTXMethod.SaveUserReportData(JsonConvert.SerializeObject(nameList), userYsbqcId, reportCode);
           return saveresult;
       }

       public string make(string userYsbqcId)
       {
           string msg = "";
           GTXResult gr = GTXMethod.UpdateYSBQC(userYsbqcId, "已申报");
           if (gr.IsSuccess == true)
           {
               msg = "申报成功";
           }
           else
           {
               msg = "申报失败";
           }
           return msg;
       }

       public void UpdateYsbqcSBSE(string userYSBQCId, JToken input_jo, string ywbm)
       {
           string sbse = "";
           string s = ywbm.ToUpper();
           switch (s)
           {
               case "YBNSRZZS":
                   sbse = input_jo["zzsybsbSbbdxxVO"]["zzssyyybnsr_zb"]["zbGrid"]["zbGridlbVO"][0]["bqybtse"].ToString();
                   break;
               case "LHFJSSB":
                   sbse = input_jo.SelectToken("fjsSbbdxxVO.fjssbb.sbxxGrid.bqybtsehj").ToString();
                   break;
           }
           GTXMethod.UpdateSBSE(userYSBQCId, sbse);
       }

       public JArray getsbzfmx(string sbblxDm)
       {
           JArray out_ja = new JArray();
           JObject data_json = new JObject();
           GDTXBeiJingUserYSBQC item = getUserYSBQC(sbblxDm);

           GTXResult gr = GTXMethod.GetUserReportData(item.Id.ToString(), item.ywbm);
           if (gr.IsSuccess)
           {
               List<GDTXBeiJingUserYSBQCReportData> dataList = JsonConvert.DeserializeObject<List<GDTXBeiJingUserYSBQCReportData>>(gr.Data.ToString());
               if (dataList.Count > 0)
               {
                   byte[] outputb = Convert.FromBase64String(dataList[0].DataValue);
                   string dataValue = Encoding.Default.GetString(outputb);
                   data_json = JsonConvert.DeserializeObject<JObject>(dataValue);
               }
           }

           JObject jo = new JObject();
           JObject jo2 = new JObject();
           JObject jo3 = new JObject();
           switch (item.ywbm.ToLower())
           {
               case "ybnsrzzs":
                   jo.Add("zsxmDm", "10101");
                   jo.Add("skssqq", item.SKSSQQ);
                   jo.Add("gdslxDm", "1");
                   jo.Add("sl1", "0.06");
                   jo.Add("pzxh", "10011119000006167259");
                   jo.Add("pzmxxh", "1");
                   jo.Add("zspmmc", "咨询服务");
                   jo.Add("ybtse", "0");
                   jo.Add("ynse", "");
                   jo.Add("skssqz", item.SKSSQZ);
                   jo.Add("zsxmmc", "增值税");
                   jo.Add("zspmDm", "101016703");
                   out_ja.Add(jo);
                   jo2 = (JObject)jo.DeepClone();
                   jo2["sl1"] = "0.16";
                   jo2["pzmxxh"] = "2";
                   jo2["zspmmc"] = "商业(17%)";
                   jo2["zspmDm"] = "101014001";
                   jo2["ybtse"] = item.SBSE;
                   out_ja.Add(jo2);
                   break;
               case "lhfjssb":
                   JToken sbxxGridlbVO = data_json.SelectToken("fjsSbbdxxVO.fjssbb.sbxxGrid.sbxxGridlbVO");

                   jo.Add("zsxmDm", "10109");
                   jo.Add("skssqq", item.SKSSQQ);
                   jo.Add("gdslxDm", "2");
                   jo.Add("sl1", "0.07");
                   jo.Add("pzxh", "10021119000009000150");
                   jo.Add("pzmxxh", "1");
                   jo.Add("zspmmc", "市区（增值税附征）");
                   jo.Add("skssqz", item.SKSSQZ);
                   jo.Add("zsxmmc", "城市维护建设税");
                   jo.Add("zspmDm", "101090101");
                   JToken bqybtse = sbxxGridlbVO.Where(a => a["zspmDm"].Value<string>() == jo["zspmDm"].Value<string>()).ToList<JToken>()[0]["bqybtse"];
                   JToken bqynsfe = sbxxGridlbVO.Where(a => a["zspmDm"].Value<string>() == jo["zspmDm"].Value<string>()).ToList<JToken>()[0]["bqynsfe"];
                   jo.Add("ybtse", bqybtse.Value<string>());
                   jo.Add("ynse", bqynsfe.Value<string>());
                   out_ja.Add(jo);

                   jo2 = (JObject)jo.DeepClone();
                   jo2["zsxmDm"] = "30203";
                   jo2["sl1"] = "0.03";
                   jo2["pzmxxh"] = "2";
                   jo2["zspmmc"] = "增值税教育费附加";
                   jo2["zsxmmc"] = "教育费附加";
                   jo2["zspmDm"] = "302030100";
                   bqybtse = sbxxGridlbVO.Where(a => a["zspmDm"].Value<string>() == jo2["zspmDm"].Value<string>()).ToList<JToken>()[0]["bqybtse"];
                   bqynsfe = sbxxGridlbVO.Where(a => a["zspmDm"].Value<string>() == jo2["zspmDm"].Value<string>()).ToList<JToken>()[0]["bqynsfe"];
                   jo2["ybtse"] = bqybtse.Value<string>();
                   jo2["ynse"] = bqynsfe.Value<string>();
                   out_ja.Add(jo2);

                   jo3 = (JObject)jo.DeepClone();
                   jo3["zsxmDm"] = "30216";
                   jo3["sl1"] = "0.02";
                   jo3["pzmxxh"] = "3";
                   jo3["zspmmc"] = "增值税地方教育附加";
                   jo3["zsxmmc"] = "地方教育附加";
                   jo3["zspmDm"] = "302160100";
                   bqybtse = sbxxGridlbVO.Where(a => a["zspmDm"].Value<string>() == jo3["zspmDm"].Value<string>()).ToList<JToken>()[0]["bqybtse"];
                   bqynsfe = sbxxGridlbVO.Where(a => a["zspmDm"].Value<string>() == jo3["zspmDm"].Value<string>()).ToList<JToken>()[0]["bqynsfe"];
                   jo3["ybtse"] = bqybtse.Value<string>();
                   jo3["ynse"] = bqynsfe.Value<string>();
                   out_ja.Add(jo3);
                   break;
           }
           return out_ja;
       }

       public void sbZfSubmit(string yzpzzlDm)
       {
           GDTXBeiJingUserYSBQC ysbqc = this.getUserYSBQC(yzpzzlDm);
           GTXMethod.UpdateYSBQC(ysbqc.Id.ToString(), "未申报");
           GTXMethod.UpdateSBSE(ysbqc.Id.ToString(), "");
           GTXMethod.DeleteUserReportData(ysbqc.Id.ToString(), ysbqc.ywbm);
       }

       public void getNsrxx(ref JObject in_jo)
       {
           GTXResult gr1 = GTXMethod.GetCompany();
           if (gr1.IsSuccess)
           {
               JObject jo = new JObject();
               jo = JsonConvert.DeserializeObject<JObject>(gr1.Data.ToString());
               if (jo.HasValues)
               {
                   JObject data_jo = jo;
                   in_jo["nsrmc"] = data_jo["NSRMC"];
                   in_jo["nsrsbh"] = data_jo["NSRSBH"];
                   in_jo["djzclxMc"] = data_jo["DJZCLX"];
                   in_jo["zcdz"] = data_jo["ZCDZ"];
                   in_jo["jydz"] = data_jo["SCJYDZ"];
                   in_jo["dhhm"] = data_jo["LXDH"];
                   in_jo["sshy"] = data_jo["GBHY"];
                   in_jo["hymc"] = data_jo["GBHY"];
                   in_jo["zgswskfjmc"] = data_jo["ZGDSSWJFJMC"];
               }
           }

           GTXResult gr2 = GTXMethod.GetCompanyPerson();
           if (gr2.IsSuccess)
           {
               JArray ja = new JArray();
               ja = JsonConvert.DeserializeObject<JArray>(gr2.Data.ToString());
               if (ja.Count > 0)
               {
                   JObject data_jo = (JObject)ja[0];
                   in_jo["frxm"] = data_jo["Name"];
                   in_jo["fddbrsfzjhm"] = data_jo["IDCardNum"];
               }
           }
       }

       public void getHeadNsrxx(ref JObject in_jo)
       {
           GTXResult gr1 = GTXMethod.GetCompany();
           if (gr1.IsSuccess)
           {
               JObject jo = new JObject();
               jo = JsonConvert.DeserializeObject<JObject>(gr1.Data.ToString());
               if (jo.HasValues)
               {
                   JObject data_jo = jo;
                   in_jo["yhqymc"] = data_jo["NSRMC"];
                   in_jo["userName"] = data_jo["NSRSBH"];
               }
           }
       }

       public void getYbnsrzzsBnlj(ref JObject in_jo)
       {
           string Name = HttpContext.Current.Session["Name"].ToString();
           XmlDocument doc = new XmlDocument();
           doc.LoadXml(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "industry.xml"));
           JToken industry = JsonConvert.DeserializeObject<JToken>(JsonConvert.SerializeXmlNode(doc));
           industry = industry.SelectToken("root.industry").Where(a => a["name"].ToString() == Name).ToList()[0];
           JObject zzsybnsrsbInitData_jo = JObject.Parse(File.ReadAllText(HttpContext.Current.Server.MapPath("zzsybnsrsbInitData." + industry["value"] + ".json")));
           in_jo.Merge(zzsybnsrsbInitData_jo, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
       }

       public JArray aqsb_getSbqcList()
       {
           JArray out_ja = new JArray();
           GTXResult resultq = GTXMethod.GetBeiJingYSBQC();
           if (resultq.IsSuccess)
           {
               List<GDTXBeiJingUserYSBQC> ysbqclist = JsonConvert.DeserializeObject<List<GDTXBeiJingUserYSBQC>>(resultq.Data.ToString());
               foreach (GDTXBeiJingUserYSBQC item in ysbqclist)
               {
                   JObject jo = new JObject();
                   if (item.SBZT == this.ysbzt)
                   {
                       jo.Add("sbztDm", "210");
                       jo.Add("sbrq", item.HappenDate);
                   }
                   else
                   {
                       jo.Add("sbztDm", "");
                       jo.Add("sbrq", "");
                   }
                   switch (item.ywbm.ToLower())
                   {
                       case "ybnsrzzs":
                           jo.Add("zsxmDm", "10101");
                           jo.Add("jkztDm", "");
                           jo.Add("gdslxDm", "1");
                           jo.Add("nsqxDm", "06");
                           jo.Add("zsxmMc", "增值税(适用于一般纳税)");
                           jo.Add("skssqQ", item.SKSSQQ);
                           jo.Add("yxcfsb", "");
                           jo.Add("url", item.Url);
                           jo.Add("lastzs", "Y");
                           jo.Add("yzpzzlDm", item.yzpzzlDm);
                           jo.Add("sbqx", item.SBQX);
                           jo.Add("skssqZ", item.SKSSQZ);
                           jo.Add("sbywbm", "YBNSRZZS");
                           jo.Add("uuid", "81D580E9A9D4793DE053674A0C845287");
                           jo.Add("zspmMc", "");
                           jo.Add("zspmDm", "101016703");
                           out_ja.Add(jo);
                           break;
                       case "lhfjssb":
                           jo.Add("zsxmDm", "30216");
                           jo.Add("jkztDm", "");
                           jo.Add("gdslxDm", "2");
                           jo.Add("nsqxDm", "06");
                           jo.Add("zsxmMc", "地方教育附加");
                           jo.Add("skssqQ", item.SKSSQQ);
                           jo.Add("yxcfsb", "");
                           jo.Add("url", item.Url);
                           jo.Add("yzpzzlDm", item.yzpzzlDm);
                           jo.Add("sbqx", item.SBQX);
                           jo.Add("skssqZ", item.SKSSQZ);
                           jo.Add("sbywbm", "LHFJSSB");
                           jo.Add("uuid", "81ADAE383B5F7212E053684A0C84486E");
                           jo.Add("zspmMc", "增值税地方教育附加");
                           jo.Add("zspmDm", "302160100");
                           out_ja.Add(jo);
                           JObject jo2 = (JObject)jo.DeepClone();
                           jo2["zsxmDm"] = "30203";
                           jo2["zsxmMc"] = "教育费附加";
                           jo2["zspmMc"] = "增值税教育费附加";
                           jo2["zspmDm"] = "302030100";
                           out_ja.Add(jo2);
                           JObject jo3 = (JObject)jo.DeepClone();
                           jo3["zsxmDm"] = "10109";
                           jo3["zsxmMc"] = "城市维护建设税";
                           jo3["zspmMc"] = "市区（增值税附征）";
                           jo3["zspmDm"] = "101090101";
                           out_ja.Add(jo3);
                           break;
                       default:
                           break;
                   }
               }
           }
           return out_ja;
       }

       public GDTXDate getGDTXDate()
       {
           GDTXDate gd = new GDTXDate();
           GDTXBeiJingUserYSBQC qc = getUserYSBQC(typeof(ybnsrzzsController));
           gd.sbrqq = qc.HappenDate.Substring(0, 8) + "01";
           gd.sbrqz = qc.SBQX;
           gd.sbNd = qc.HappenDate.Substring(0, 4);
           gd.sbYf = qc.HappenDate.Substring(5, 2);
           return gd;
       }

       public void formatCd(ref JObject in_jo)
       {
           JToken ja = in_jo.SelectToken("menus.yhGncds[1].yhGncds");
           IEnumerable<JToken> yhGncds = ja.Where(a => a["cdmc"].ToString() != "公众服务");
           //JArray.FromObject();
           foreach (JObject jo in yhGncds)
           {
               JToken ja2 = jo["yhGncds"];
               IEnumerable<JToken> ijt = ja2.Where(a => a["cdmc"].ToString() != "税费申报及缴纳" && a["cdmc"].ToString() != "申报信息查询");
               foreach (JObject jo2 in ijt)
               {
                   JToken jp = jo2.Property("realUrl");
                   if (jp != null)
                   {
                       jp.Remove();
                   }
               }
           }

           JToken jt = ja.Where(a => a["cdmc"].ToString() == "公众服务").First();
           foreach (JObject jo in jt["yhGncds"])
           {
               foreach (JObject jo2 in jo["yhGncds"])
               {
                   JToken jp = jo2.Property("realUrl");
                   if (jp != null)
                   {
                       jp.Remove();
                   }
               }
           }
       }

    }
}