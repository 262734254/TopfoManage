using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Tz888.IDAL.offer;
using Tz888.Model.offer;
using Tz888.DALFactory;
using System.Reflection;
using Tz888.Model.Info;
using Tz888.IDAL.Info;
namespace Tz888.BLL.offer
{
  public  class PageStatic
    {

        private readonly ICapitalInfoService dal = DataAccess.CreateInfo_CapitalInfoService();
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["TZAppPath"].ToString(); //投资生成页面存放位置
        string Merchant = ConfigurationManager.AppSettings["TzMerchantTem"].ToString(); //投资模版存放位置
   
        private const string CapitalPicPath = "http://images.topfo.com/";           //图片路径



        #region 投资模版静态页面
        /// <summary>
        ///投资模版静态页面
        /// </summary>
        /// <param name="NewsID">编号</param>
        /// <param name="title">标题</param>
        /// <param name="publishT">时间</param>
        /// <param name="Content">详细内容</param>
      public int StaticHtml(int infoID, string title, string publishT, string AreaName, string Content, string IndustryCarveOutID, string CooperationTypeName, string Money, string validateID, string MerchantNameTotal, string Idstuny, string pic, string IsVip, string KeyWord, string DisplayTitle, string Descript, string Register)
        {
            try
            {
                Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();
                Tz888.Model.Info.V124.CapitalSetModel model = new Tz888.Model.Info.V124.CapitalSetModel();
                model = bll.GetIntegrityModel(infoID);
                #region 图片属性
                string Pic1 = "";
                string Pic1_c = "";
                string Pic1_s = "";
                string Pic1_r = "";
                string Pic2 = "";
                string Pic2_c = "";
                string Pic2_s = "";
                string Pic2_r = "";
                string Pic3 = "";
                string Pic3_c = "";
                string Pic3_s = "";
                string Pic3_r = "";
                string Pic4 = "";
                string Pic4_c = "";
                string Pic4_s = "";
                string Pic4_r = "";
                string Pic5 = "";
                string Pic5_c = "";
                string Pic5_s = "";
                string Pic5_r = "";
                string Pic6 = "";
                string Pic6_c = "";
                string Pic6_s = "";
                string Pic6_r = "";
                string p1 = "";
                string p2 = "";
                string p3 = "";
                string p4 = "";
                string p5 = "";
                string p6 = "";
                #endregion
                #region 图片封装  
                ArrayList arrListPic = new ArrayList();
                ArrayList arrListDoc = new ArrayList();
                if (model.InfoResourceModels != null)
                {
                    foreach (Tz888.Model.Info.InfoResourceModel objModelResource in model.InfoResourceModels)
                    {
                        //ResourceType 0:其他文档 1：图片 2：视频
                        if (objModelResource.ResourceType.ToString().Trim() == "1")
                        {
                            string[] arTempPic = new string[2];
                            arTempPic[0] = objModelResource.ResourceAddr.Trim();
                            arTempPic[1] = objModelResource.ResourceName.Trim();
                            arrListPic.Add(arTempPic);
                        }
                        if (objModelResource.ResourceType.ToString().Trim() == "0")
                        {
                            string[] arTempDoc = new string[2];
                            arTempDoc[0] = objModelResource.ResourceAddr.Trim();
                            arTempDoc[1] = objModelResource.ResourceName.Trim();
                            arrListDoc.Add(arTempDoc);
                        }
                    }
                }
                if (arrListPic.Count > 0)
                {
                    string[] sPicTemp = (string[])arrListPic[0];
                    Pic1 = sPicTemp[0];
                    Pic1_c = sPicTemp[1];
                    //Pic1_s = Common.GetMiniPic(Pic1);
                    Pic1_s = Pic1;
                    Pic1_r = "<li id=\"tab_tophome_1\" class=\"on\"><a href=" + CapitalPicPath.Trim() + Pic1_s.Trim() +" target=\"_blank\"   onmousemove=\"startIndex=1;setTab('tophome',1,1,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + CapitalPicPath.Trim() + Pic1_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
                    p1 = "<div id=\"con_tophome_1\"  ><a href=" + CapitalPicPath.Trim() + Pic1_s.Trim() + " target=\"_blank\"  onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + CapitalPicPath.Trim() + Pic1_s.Trim() + "  alt=\"3\" /></a></div>";
                }

                if (arrListPic.Count > 1)
                {
                    string[] sPicTemp = (string[])arrListPic[1];
                    Pic2 = sPicTemp[0];
                    Pic2_c = sPicTemp[1];
                    //Pic2_s = Common.GetMiniPic(Pic2);
                    Pic2_s = Pic2;
                  Pic2_r = "<li id=\"tab_tophome_2\" class=\"out\"><a href=" + CapitalPicPath.Trim() + Pic2_s.Trim() +" target=\"_blank\"   onmousemove=\"startIndex=2;setTab('tophome',2,2,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + CapitalPicPath.Trim() + Pic2_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
                  p2 = "<div id=\"con_tophome_2\"  class=\"hidecontent\"><a href=" + CapitalPicPath.Trim() + Pic2_s.Trim() + " target=\"_blank\"  onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + CapitalPicPath.Trim() + Pic2_s.Trim() + "  alt=\"3\" /></a></div>";
                }
                if (arrListPic.Count > 2)
                {
                    string[] sPicTemp = (string[])arrListPic[2];
                    Pic3 = sPicTemp[0];
                    Pic3_c = sPicTemp[1];
                    //Pic3_s = Common.GetMiniPic(Pic3);
                    Pic3_s = Pic3;
                    Pic3_r = "<li id=\"tab_tophome_3\" class=\"out\"><a href=" + CapitalPicPath.Trim() + Pic3_s.Trim() + " target=\"_blank\"   onmousemove=\"startIndex=3;setTab('tophome',3,3,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + CapitalPicPath.Trim() + Pic3_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
                    p3 = "<div id=\"con_tophome_3\"  class=\"hidecontent\"><a href=" + CapitalPicPath.Trim() + Pic3_s.Trim() + " target=\"_blank\"  onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + CapitalPicPath.Trim() + Pic3_s.Trim() + "  alt=\"3\" /></a></div>";
                }
                if (arrListPic.Count > 3)
                {
                    string[] sPicTemp = (string[])arrListPic[3];
                    Pic4 = sPicTemp[0];
                    Pic4_c = sPicTemp[1];
                    //Pic4_s = Common.GetMiniPic(Pic4);
                    Pic4_s = Pic4;
                    Pic4_r = "<li id=\"tab_tophome_4\" class=\"out\"><a href=" + CapitalPicPath.Trim() + Pic4_s.Trim() + " target=\"_blank\"   onmousemove=\"startIndex=4;setTab('tophome',4,4,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + CapitalPicPath.Trim() + Pic4_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
                    p4 = "<div id=\"con_tophome_4\"  class=\"hidecontent\"><a href=" + CapitalPicPath.Trim() + Pic4_s.Trim() + " target=\"_blank\"  onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + CapitalPicPath.Trim() + Pic4_s.Trim() + "  alt=\"3\" /></a></div>";
                }
                if (arrListPic.Count > 4)
                {
                    string[] sPicTemp = (string[])arrListPic[4];
                    Pic5 = sPicTemp[0];
                    Pic5_c = sPicTemp[1];
                    //Pic5_s = Common.GetMiniPic(Pic5);
                    Pic5_s = Pic5;
                    Pic5_r = "<li id=\"tab_tophome_5\" class=\"out\"><a href=" + CapitalPicPath.Trim() + Pic5_s.Trim() + " target=\"_blank\"   onmousemove=\"startIndex=45;setTab('tophome',5,5,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + CapitalPicPath.Trim() + Pic5_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
                    p5 = "<div id=\"con_tophome_5\"  class=\"hidecontent\"><a href=" + CapitalPicPath.Trim() + Pic5_s.Trim() + " target=\"_blank\"  onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + CapitalPicPath.Trim() + Pic5_s.Trim() + "  alt=\"3\" /></a></div>";
                }
                if (arrListPic.Count > 5)
                {
                    string[] sPicTemp = (string[])arrListPic[5];
                    Pic6 = sPicTemp[0];
                    Pic6_c = sPicTemp[1];
                    //Pic6_s = Common.GetMiniPic(Pic6);
                    Pic6_s = Pic6;
                    Pic6_r = "<li id=\"tab_tophome_5\" class=\"out\"><a href=" + CapitalPicPath.Trim() + Pic6_s.Trim() + " target=\"_blank\"   onmousemove=\"startIndex=45;setTab('tophome'6,6,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + CapitalPicPath.Trim() + Pic6_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
                    p6 = "<div id=\"con_tophome_5\"  class=\"hidecontent\"><a href=" + CapitalPicPath.Trim() + Pic6_s.Trim() + " target=\"_blank\"  onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + CapitalPicPath.Trim() + Pic6_s.Trim() + "  alt=\"3\" /></a></div>";
                }


                #endregion
                if (Register == "%")
                {
                    Register = "面谈";
                }
                if (AreaName == "")
                {
                    AreaName = "全国";
                }
                string TempFileName = Merchant.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                #region 替换模版
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$infoID$", Convert.ToString(infoID));
                TempSoure = TempSoure.Replace("$title$", title);//标题
                TempSoure = TempSoure.Replace("$publishT$", publishT);//时间
                TempSoure = TempSoure.Replace("$AreaName$", AreaName);//区域
                TempSoure = TempSoure.Replace("$Content$", Content);//内容
                TempSoure = TempSoure.Replace("$IndustryCarveOutID$", IndustryCarveOutID);//行业               
                TempSoure = TempSoure.Replace("$State$", CooperationTypeName);//投资方式
                TempSoure = TempSoure.Replace("$Money$", Money);//收费资源
                TempSoure = TempSoure.Replace("$validateID$", validateID);//有效期
                TempSoure = TempSoure.Replace("$MerchantNameTotal$", MerchantNameTotal);//投资金额        
                TempSoure = TempSoure.Replace("$XianXi$", Idstuny);//详细信息
                //TempSoure = TempSoure.Replace("$pic$", pic);//图片   //暂时不用
                TempSoure = TempSoure.Replace("$Register$", Register);//投资回报率         
                TempSoure = TempSoure.Replace("$ZhongDa$", IsVip);//重大投资项目                       
                TempSoure = TempSoure.Replace("$KeyWord$", KeyWord);//网页关键字
                TempSoure = TempSoure.Replace("$Descript$", Descript);//网页描述
                TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);//网页标题
                TempSoure = TempSoure.Replace("#@TmpFeild-Pic1#", Pic1_r);
                TempSoure = TempSoure.Replace("#@TmpFeild-Pic2#", Pic2_r);
                TempSoure = TempSoure.Replace("#@TmpFeild-Pic3#", Pic3_r);
                TempSoure = TempSoure.Replace("#@TmpFeild-Pic4#", Pic4_r);
                TempSoure = TempSoure.Replace("#@TmpFeild-Pic5#", Pic5_r);
                TempSoure = TempSoure.Replace("#@TmpFeild-Pic6#", Pic6_r);
                TempSoure = TempSoure.Replace("#@p1@#", p1);
                TempSoure = TempSoure.Replace("#@p2@#", p2);
                TempSoure = TempSoure.Replace("#@p3@#", p3);
                TempSoure = TempSoure.Replace("#@p4@#", p4);
                TempSoure = TempSoure.Replace("#@p5@#", p5);
                TempSoure = TempSoure.Replace("#@p6@#", p6);
                if (arrListPic.Count == 0)
                {
                    string tupian = "display:none";

                    TempSoure = TempSoure.Replace("$tupian$", tupian);
                }
                else
                {
                    string tupian = "display:block";

                    TempSoure = TempSoure.Replace("$tupian$", tupian);

                }


                #endregion
                #region
                string inPathTo = "/Capital";

                string sql1 = "select a.HtmlFile from MainInfoTab as a inner join CapitalInfoTab as b on a.InfoID=b.InfoID where a.InfoID=" + infoID + "";
                string htmlFile = Tz888.DBUtility.DbHelperSQL.GetSingle(sql1).ToString();
                string[] html = htmlFile.Split('/');
                string[] nn = html[2].Split('_');
                string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + html[1].Replace("Capital", "");
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);
                }

                string htmlpaths = wenjian + inPathTo + cc + "_" + infoID + ".shtml";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }
                #endregion
        }

        public int ModifyHtmlFile(int infoId)
        {

            try
            {
                string inPathTo = "/Capital";
                string sql1 = "select a.HtmlFile from MainInfoTab as a inner join CapitalInfoTab as b on a.InfoID=b.InfoID where a.InfoID=" + infoId + "";
                string htmlFile = Tz888.DBUtility.DbHelperSQL.GetSingle(sql1).ToString();
                if (htmlFile != "")
                {
                    string[] html = htmlFile.Split('/');
                    string htmlcc = html[1].Replace("Capital", "");
                    string[] nn = html[2].Split('_');
                    string cc = nn[0].Substring(nn[0].Length - 8);
                    //string arry = "F:/Topfo/tzWeb/tz/" + htmlcc + inPathTo + cc + "_" + infoId + ".shtml";
                    //string arrylist = arry.Replace("F:/Topfo/tzWeb/", "");

                    string arry = "J:/Topfo/tzWeb/Capital/" + htmlcc + inPathTo + cc + "_" + infoId + ".shtml";
                    string arrylist = arry.Replace("J:/Topfo/tzWeb/", "");
                    string sql = "update MainInfoTab set HtmlFile='" + arrylist + "' where InfoID=" + infoId + "";
                    Tz888.DBUtility.DbHelperSQL.ExecuteSql(sql);
                }
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region 通过InfoID获取一个信息实体
        /// <summary>
        /// 通过InfoID获取一个Merchant的信息实体
        /// </summary>
        /// <returns></returns>
        public PageStatic objGetMerchantInfoByInfoID(long InfoID)
        {
           
            PageStatic page = new PageStatic();
            CapitalSetModel theCapital = new CapitalSetModel();
            Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();
            Tz888.Model.Info.V124.CapitalSetModel model = new Tz888.Model.Info.V124.CapitalSetModel();
            model = bll.GetIntegrityModel(InfoID);

            page.Title = model.MainInfoModel.Title.ToString().Trim();
            page.PublishT = model.MainInfoModel.publishT.ToShortDateString();
            page.Hit = Convert.ToString(model.MainInfoModel.Hit);
            page.Content = ThrowHtml(model.CapitalInfoModel.ComAbout);
            page._auditingStatus = Convert.ToInt32(model.MainInfoModel.AuditingStatus);
           
            if (model.MainInfoModel.ValidateTerm.ToString().Trim() != null)
            {
                string ValidateTerm = "";
                switch (model.MainInfoModel.ValidateTerm.ToString().Trim())
                {
                    case "3": ValidateTerm = "3个月"; break;
                    case "6": ValidateTerm = "6个月"; break;
                    case "36": ValidateTerm = "3年"; break;
                    case "60": ValidateTerm = "5年"; break;
                    case "12": ValidateTerm = "1年"; break;
                    case "14": ValidateTerm = "2年"; break;
                    case "24": ValidateTerm = "2年"; break;
                }
                page.ValidateID = ValidateTerm;
            }
            else
            {
                page.ValidateID = "暂无";
            }

            if (model.MainInfoModel.MainPointCount.ToString().Trim() == "0")
            {
                page.Money = "该资源为免费资源";
            }
            else
            {
                page.Money = model.MainInfoModel.MainPointCount.ToString().Trim()+"元";
            }
            //合作方式
           page.CooperationTypeName = "";
           if (model.CapitalInfoModel.CooperationDemandType != null)
           {
               string[] str = model.CapitalInfoModel.CooperationDemandType.Split(new char[] { ',' });//11,2,1
     
                   string[] strchild = str;
                   for (int j = 0; j < strchild.Length - 1; j++)
                   {
                       if (!string.IsNullOrEmpty(strchild[j].ToString()))
                       {
                           switch (strchild[j].ToString())
                           {
                               case "1":
                                   page.CooperationTypeName +="  "+ "资金借贷";
                                   break;
                               case "11":
                                   page.CooperationTypeName += "  " + "直接投资";
                                   break;
                               case "2":
                                   page.CooperationTypeName += "  " + "股权投资";
                                   break;

                               default:
                                   break;
                           }
                       }
                   }
               
           }
            //foreach (string sCoopTypeName in model.CapitalInfoModel.CooperationDemandTypeName)
            //{
            //    page.CooperationTypeName +=" " + sCoopTypeName.Trim();
            //}

            //投资区域
           page.AreaName = "";
            if (model.CapitalInfoAreaModels != null)
            {
                foreach (Tz888.Model.Info.CapitalInfoAreaModel tempCIAM in model.CapitalInfoAreaModels)
                {
                    //if (!string.IsNullOrEmpty(tempCIAM.CountryName))
                    //{
                    //    page.AreaName = tempCIAM.CountryName.Trim();
                    //}
                    if (!string.IsNullOrEmpty(tempCIAM.ProvinceName))
                    {
                        page.AreaName += " " + tempCIAM.ProvinceName.Trim();
                    }
                    if (!string.IsNullOrEmpty(tempCIAM.CityName))
                    {
                        page.AreaName += " " + tempCIAM.CityName.Trim();
                    }
                    if (!string.IsNullOrEmpty(tempCIAM.CountyName))
                    {
                        page.AreaName += " " + tempCIAM.CountyName.Trim();
                    }
                   //if (!string.IsNullOrEmpty(page.AreaName))
                   //    page.AreaName += "<br />";
                }
            }
            else
            {
                page.AreaName = "不限";
            }
            page.Are = model.CapitalInfoModel.IndustryBID.Trim();

            //所属于行业
            page.IndustryCarveOutID = "";
            foreach (string sTempIndustry in model.CapitalInfoModel.IndustryBName)
            {
                page.IndustryCarveOutID += sTempIndustry.Trim() + " ";
            }
            page.MerchantNameTotal = model.CapitalInfoModel.CapitalName.Trim();
            if (page.MerchantNameTotal == "0")
                page.MerchantNameTotal = "暂无";
            page.Keword = model.MainInfoModel.KeyWord;
            page.Descript = model.MainInfoModel.Descript;
            page.DisplayTitles = model.MainInfoModel.DisplayTitle;
            page.Register = model.CapitalInfoModel.RegisteredCapital.ToString().Trim()+"%";
            if (page.Register == "" && page.Register == "%")
            {
                page.Register = "暂无";
            }
        

            return page;

        }
        #endregion
        #region 属性封装
        private string pic;

        public string Pic
        {
            get { return pic; }
            set { pic = value; }
        }
      private string cooperationTypeName;

      public string CooperationTypeName
        {
            get { return cooperationTypeName; }
            set { cooperationTypeName = value; }
        }
        private string money;

        public string Money
        {
            get { return money; }
            set { money = value; }
        }
        private string keword;

        public string Keword
        {
            get { return keword; }
            set { keword = value; }
        }
        private string displayTitles;

        public string DisplayTitles
        {
            get { return displayTitles; }
            set { displayTitles = value; }
        }
        private string descript;

        public string Descript
        {
            get { return descript; }
            set { descript = value; }
        }

        private string merchantNameTotal;
        /// <summary>
        /// 总投资
        /// </summary>
        public string MerchantNameTotal
        {
            get { return merchantNameTotal; }
            set { merchantNameTotal = value; }
        }
        private string areaName;

        /// <summary>
        /// 区域
        /// </summary>
        public string AreaName
        {
            get { return areaName; }
            set { areaName = value; }
        }
        private string _title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _publishT;

        public string PublishT
        {
            get { return _publishT; }
            set { _publishT = value; }
        }
        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private int _auditingStatus;

        public int AuditingStatus
        {
            get { return _auditingStatus; }
            set { _auditingStatus = value; }
        }
        private string hit;

        public string Hit
        {
            get { return hit; }
            set { hit = value; }
        }
        private string validateID;//有效期

        public string ValidateID
        {
            get { return validateID; }
            set { validateID = value; }
        }
        private string investObject;//合作对象

        public string InvestObject
        {
            get { return investObject; }
            set { investObject = value; }
        }
        private string capitalID;//投资金额

        public string CapitalID
        {
            get { return capitalID; }
            set { capitalID = value; }
        }
        private string industryCarveOutID; //创业行业类别

        public string IndustryCarveOutID
        {
            get { return industryCarveOutID; }
            set { industryCarveOutID = value; }
        }
        private string provinceID;  //省

        public string ProvinceID
        {
            get { return provinceID; }
            set { provinceID = value; }
        }
        private string investReturn;//回报形式

        public string InvestReturn
        {
            get { return investReturn; }
            set { investReturn = value; }
        }
        private string comName;//单位名称

        public string ComName
        {
            get { return comName; }
            set { comName = value; }
        }
        private string linkMan;//联系人

        public string LinkMan
        {
            get { return linkMan; }
            set { linkMan = value; }
        }
        private string tel;//电话

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string address;//地址

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string postCode;//邮编

        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }
        private string email;//邮箱

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string webSite;//网站

        public string WebSite
        {
            get { return webSite; }
            set { webSite = value; }
        }
        private string keyWord;

        public string KeyWord
        {
            get { return keyWord; }
            set { keyWord = value; }
        }
        private string carveOutInfoType;

        private string are;

        public string Are
        {
            get { return are; }
            set { are = value; }
        }
        public string CarveOutInfoType
        {
            get { return carveOutInfoType; }
            set { carveOutInfoType = value; }
        }
        private string register;

        public string Register
        {
            get { return register; }
            set { register = value; }
        }

        #endregion

      #region 去除HTML标记
      public string ThrowHtml(string sStr)
      {
          //使用正则表达式替换
          //Regex x = new Regex("<(.[^>]*)>");
          sStr = Regex.Replace(sStr, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
          sStr = Regex.Replace(sStr, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);

          return sStr;
      }
      #endregion
        #region 获取省名称
        /// <summary>
        /// 根据ID获取省名称
        /// </summary>
        /// <returns></returns>
        public string ProvinceSelect(string ProvinceID)
        {
            string Name = "";
            if (ProvinceID == "")
            {
                Name = "全国";
                return Name;
            }
            string sql = "SELECT *FROM SetProvinceTab where ProvinceID =@ProvinceID";
            SqlParameter[] para ={
            new SqlParameter("@ProvinceID",SqlDbType.Int,20)};
            para[0].Value = ProvinceID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Name = ds.Tables[0].Rows[0]["ProvinceName"].ToString();
                return Name;
            }

            else
            {
                return null;
            }


        }
        #endregion
        public string dicttab(string valid)
        {
            string Name = "";
            if (ProvinceID == "")
            {
                Name = "暂未填写";
                return Name;
            }
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable ds = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
            if (ds.Rows.Count > 0)
            {
                Name = ds.Rows[0]["cdictname"].ToString();
                return Name;
            }


            else
            {
                return null;
            }
        }
        #region 设置融资金额
        /// <summary>
        /// 设置融资金额
        /// </summary>
        private string  BindSetCapital(string Capital)
        {
            string Name = "";
            if (Capital == "")
            {
                Name = "暂无";
                return Name;
            }
            string sql = "SELECT CapitalID, CapitalName FROM SetCapitalTab where CapitalID =@Capital";
            SqlParameter[] para ={
            new SqlParameter("@Capital",SqlDbType.Int,20)};
            para[0].Value = Capital;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Name = ds.Tables[0].Rows[0]["CapitalName"].ToString();
                return Name;
            }

            else
            {
                return null;
            }
        }
        #endregion
        #region 获取行页
        /// <summary>
        /// 根据ID获取行页
        /// </summary>
        /// <returns></returns>
        public string IndustryClassListSelect(string IndustryBID)
        {
            string[] a = IndustryBID.Split(',');
            string Name = "";
            if (a[0] == "")
            {
                Name = "暂无行业";
                return Name;
            }

            //string sql = "SELECT *FROM SetIndustryBTab where IndustryBID = '" + a[0] +"'";
            string sql = "SELECT *FROM SetIndustryBTab where IndustryBID =@IndustryBID";
            SqlParameter[] para ={
            new SqlParameter("@IndustryBID",SqlDbType.VarChar,20)};
            para[0].Value = a[0];
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {


                Name = ds.Tables[0].Rows[0]["IndustryBName"].ToString();
                return Name;
            }
            else
            {
                return null;
            }


        }
        #endregion
        #region 截取字符串的个数
        protected string StrLength(object title)
        {
            string name = "";
            name = title.ToString();
            if (name.Length > 16)
            {
                name = name.Substring(0, 16) + "...";
            }
            return name;
        }
        #endregion
        #region 设置类型
        /// <summary>
        /// 设置类型
        /// </summary>
      private string BindDemandType(string DemandType)
        {

            string Name = "";
            if (DemandType.ToString().Trim() == "")
            {
                Name = "暂无";
                return Name;
            }
            else
            {
                string[] a = DemandType.Split(',');

                if (a[0] == "")
                {
                    Name = "暂无";
                    return Name;
                }
                string sql = "SELECT * FROM SetCooperationDemandTypeTab Where InfoType ='Capital' and CooperationDemandTypeID= '" + a[0] + "'";
                SqlParameter[] para ={
            new SqlParameter("@DemandType",SqlDbType.Int,20)};
                para[0].Value = a[0]; ;
                DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Name = ds.Tables[0].Rows[0]["CooperationDemandName"].ToString();
                    if (Name == "")
                    {
                        return "暂无";
                    }
                    else
                    {
                        return Name;
                    }
                }

                else
                {
                    return null;
                }
            }
        }
          #endregion
        #region 根据行页查询相关信息
        /// <summary>
        /// 根据行页查询相关信息
        /// </summary>
        /// <returns></returns>
        public string SelectLndus(string ProvinceID)
        {
            string[] a = ProvinceID.Split(',');
            string Name = "";
            if (a[0] == "")
            {
                Name = "暂无行业";
                return Name;
            }


            StringBuilder sb = new StringBuilder();
            string sql = "SELECT top 6    dbo.MainInfoTab.Title, dbo.MainInfoTab.HtmlFile, dbo.CapitalInfoTab.CooperationDemandType, dbo.MainInfoTab.ValidateTerm,"
                           + " dbo.CapitalInfoTab.IndustryBID,CapitalInfoTab.CapitalID FROM   dbo.MainInfoTab INNER JOIN"
                           +"  dbo.CapitalInfoTab ON dbo.MainInfoTab.InfoID = dbo.CapitalInfoTab.InfoID"
                           + " where MainInfoTab.AuditingStatus=1 and CapitalInfoTab.industryBID like'%" + a[0] + "%' order by MainInfoTab.publishT desc";
            SqlParameter[] para ={
            new SqlParameter("@ProvinceID",SqlDbType.VarChar,20)};
            para[0].Value = a[0]; ;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tab1\">");
            sb.Append("<tr><td class=\"xiangguanxinxi\">资金标题</td><td class=\"xiangguanxinxi\">总金额</td><td class=\"xiangguanxinxi\">投资方式</td>");
            sb.Append("<td class=\"xiangguanxinxi\">所在行业</td><td class=\"xiangguanxinxi\">有效期</td></tr>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<tr><td><a href='http://www.topfo.com/" + row["HtmlFile"].ToString().Trim() + "'>" + StrLength(row["Title"].ToString()) + "</a></td><td> " +BindSetCapital( row["CapitalID"].ToString()) + "</td><td>" +BindDemandType(row["CooperationDemandType"].ToString()) + "</td><td>" + IndustryClassListSelect(row["IndustryBID"].ToString()) + "</td><td>" + dicttab(row["ValidateTerm"].ToString()) + "</td></tr>");
                }
            }
          
          
         
            sb.Append("</table>");
            return sb.ToString();

        }
        #endregion
   
      
     
    }
}
