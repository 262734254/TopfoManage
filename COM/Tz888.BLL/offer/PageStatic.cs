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
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["TZAppPath"].ToString(); //Ͷ������ҳ����λ��
        string Merchant = ConfigurationManager.AppSettings["TzMerchantTem"].ToString(); //Ͷ��ģ����λ��
   
        private const string CapitalPicPath = "http://images.topfo.com/";           //ͼƬ·��



        #region Ͷ��ģ�澲̬ҳ��
        /// <summary>
        ///Ͷ��ģ�澲̬ҳ��
        /// </summary>
        /// <param name="NewsID">���</param>
        /// <param name="title">����</param>
        /// <param name="publishT">ʱ��</param>
        /// <param name="Content">��ϸ����</param>
      public int StaticHtml(int infoID, string title, string publishT, string AreaName, string Content, string IndustryCarveOutID, string CooperationTypeName, string Money, string validateID, string MerchantNameTotal, string Idstuny, string pic, string IsVip, string KeyWord, string DisplayTitle, string Descript, string Register)
        {
            try
            {
                Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();
                Tz888.Model.Info.V124.CapitalSetModel model = new Tz888.Model.Info.V124.CapitalSetModel();
                model = bll.GetIntegrityModel(infoID);
                #region ͼƬ����
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
                #region ͼƬ��װ  
                ArrayList arrListPic = new ArrayList();
                ArrayList arrListDoc = new ArrayList();
                if (model.InfoResourceModels != null)
                {
                    foreach (Tz888.Model.Info.InfoResourceModel objModelResource in model.InfoResourceModels)
                    {
                        //ResourceType 0:�����ĵ� 1��ͼƬ 2����Ƶ
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
                    Register = "��̸";
                }
                if (AreaName == "")
                {
                    AreaName = "ȫ��";
                }
                string TempFileName = Merchant.ToString();
                string Tem = Compage.Reader(TempFileName); //��ȡģ������
                #region �滻ģ��
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$infoID$", Convert.ToString(infoID));
                TempSoure = TempSoure.Replace("$title$", title);//����
                TempSoure = TempSoure.Replace("$publishT$", publishT);//ʱ��
                TempSoure = TempSoure.Replace("$AreaName$", AreaName);//����
                TempSoure = TempSoure.Replace("$Content$", Content);//����
                TempSoure = TempSoure.Replace("$IndustryCarveOutID$", IndustryCarveOutID);//��ҵ               
                TempSoure = TempSoure.Replace("$State$", CooperationTypeName);//Ͷ�ʷ�ʽ
                TempSoure = TempSoure.Replace("$Money$", Money);//�շ���Դ
                TempSoure = TempSoure.Replace("$validateID$", validateID);//��Ч��
                TempSoure = TempSoure.Replace("$MerchantNameTotal$", MerchantNameTotal);//Ͷ�ʽ��        
                TempSoure = TempSoure.Replace("$XianXi$", Idstuny);//��ϸ��Ϣ
                //TempSoure = TempSoure.Replace("$pic$", pic);//ͼƬ   //��ʱ����
                TempSoure = TempSoure.Replace("$Register$", Register);//Ͷ�ʻر���         
                TempSoure = TempSoure.Replace("$ZhongDa$", IsVip);//�ش�Ͷ����Ŀ                       
                TempSoure = TempSoure.Replace("$KeyWord$", KeyWord);//��ҳ�ؼ���
                TempSoure = TempSoure.Replace("$Descript$", Descript);//��ҳ����
                TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);//��ҳ����
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

        #region ͨ��InfoID��ȡһ����Ϣʵ��
        /// <summary>
        /// ͨ��InfoID��ȡһ��Merchant����Ϣʵ��
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
                    case "3": ValidateTerm = "3����"; break;
                    case "6": ValidateTerm = "6����"; break;
                    case "36": ValidateTerm = "3��"; break;
                    case "60": ValidateTerm = "5��"; break;
                    case "12": ValidateTerm = "1��"; break;
                    case "14": ValidateTerm = "2��"; break;
                    case "24": ValidateTerm = "2��"; break;
                }
                page.ValidateID = ValidateTerm;
            }
            else
            {
                page.ValidateID = "����";
            }

            if (model.MainInfoModel.MainPointCount.ToString().Trim() == "0")
            {
                page.Money = "����ԴΪ�����Դ";
            }
            else
            {
                page.Money = model.MainInfoModel.MainPointCount.ToString().Trim()+"Ԫ";
            }
            //������ʽ
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
                                   page.CooperationTypeName +="  "+ "�ʽ���";
                                   break;
                               case "11":
                                   page.CooperationTypeName += "  " + "ֱ��Ͷ��";
                                   break;
                               case "2":
                                   page.CooperationTypeName += "  " + "��ȨͶ��";
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

            //Ͷ������
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
                page.AreaName = "����";
            }
            page.Are = model.CapitalInfoModel.IndustryBID.Trim();

            //��������ҵ
            page.IndustryCarveOutID = "";
            foreach (string sTempIndustry in model.CapitalInfoModel.IndustryBName)
            {
                page.IndustryCarveOutID += sTempIndustry.Trim() + " ";
            }
            page.MerchantNameTotal = model.CapitalInfoModel.CapitalName.Trim();
            if (page.MerchantNameTotal == "0")
                page.MerchantNameTotal = "����";
            page.Keword = model.MainInfoModel.KeyWord;
            page.Descript = model.MainInfoModel.Descript;
            page.DisplayTitles = model.MainInfoModel.DisplayTitle;
            page.Register = model.CapitalInfoModel.RegisteredCapital.ToString().Trim()+"%";
            if (page.Register == "" && page.Register == "%")
            {
                page.Register = "����";
            }
        

            return page;

        }
        #endregion
        #region ���Է�װ
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
        /// ��Ͷ��
        /// </summary>
        public string MerchantNameTotal
        {
            get { return merchantNameTotal; }
            set { merchantNameTotal = value; }
        }
        private string areaName;

        /// <summary>
        /// ����
        /// </summary>
        public string AreaName
        {
            get { return areaName; }
            set { areaName = value; }
        }
        private string _title;
        /// <summary>
        /// ����
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
        private string validateID;//��Ч��

        public string ValidateID
        {
            get { return validateID; }
            set { validateID = value; }
        }
        private string investObject;//��������

        public string InvestObject
        {
            get { return investObject; }
            set { investObject = value; }
        }
        private string capitalID;//Ͷ�ʽ��

        public string CapitalID
        {
            get { return capitalID; }
            set { capitalID = value; }
        }
        private string industryCarveOutID; //��ҵ��ҵ���

        public string IndustryCarveOutID
        {
            get { return industryCarveOutID; }
            set { industryCarveOutID = value; }
        }
        private string provinceID;  //ʡ

        public string ProvinceID
        {
            get { return provinceID; }
            set { provinceID = value; }
        }
        private string investReturn;//�ر���ʽ

        public string InvestReturn
        {
            get { return investReturn; }
            set { investReturn = value; }
        }
        private string comName;//��λ����

        public string ComName
        {
            get { return comName; }
            set { comName = value; }
        }
        private string linkMan;//��ϵ��

        public string LinkMan
        {
            get { return linkMan; }
            set { linkMan = value; }
        }
        private string tel;//�绰

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string address;//��ַ

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string postCode;//�ʱ�

        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }
        private string email;//����

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string webSite;//��վ

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

      #region ȥ��HTML���
      public string ThrowHtml(string sStr)
      {
          //ʹ��������ʽ�滻
          //Regex x = new Regex("<(.[^>]*)>");
          sStr = Regex.Replace(sStr, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
          sStr = Regex.Replace(sStr, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);

          return sStr;
      }
      #endregion
        #region ��ȡʡ����
        /// <summary>
        /// ����ID��ȡʡ����
        /// </summary>
        /// <returns></returns>
        public string ProvinceSelect(string ProvinceID)
        {
            string Name = "";
            if (ProvinceID == "")
            {
                Name = "ȫ��";
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
                Name = "��δ��д";
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
        #region �������ʽ��
        /// <summary>
        /// �������ʽ��
        /// </summary>
        private string  BindSetCapital(string Capital)
        {
            string Name = "";
            if (Capital == "")
            {
                Name = "����";
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
        #region ��ȡ��ҳ
        /// <summary>
        /// ����ID��ȡ��ҳ
        /// </summary>
        /// <returns></returns>
        public string IndustryClassListSelect(string IndustryBID)
        {
            string[] a = IndustryBID.Split(',');
            string Name = "";
            if (a[0] == "")
            {
                Name = "������ҵ";
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
        #region ��ȡ�ַ����ĸ���
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
        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
      private string BindDemandType(string DemandType)
        {

            string Name = "";
            if (DemandType.ToString().Trim() == "")
            {
                Name = "����";
                return Name;
            }
            else
            {
                string[] a = DemandType.Split(',');

                if (a[0] == "")
                {
                    Name = "����";
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
                        return "����";
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
        #region ������ҳ��ѯ�����Ϣ
        /// <summary>
        /// ������ҳ��ѯ�����Ϣ
        /// </summary>
        /// <returns></returns>
        public string SelectLndus(string ProvinceID)
        {
            string[] a = ProvinceID.Split(',');
            string Name = "";
            if (a[0] == "")
            {
                Name = "������ҵ";
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
            sb.Append("<tr><td class=\"xiangguanxinxi\">�ʽ����</td><td class=\"xiangguanxinxi\">�ܽ��</td><td class=\"xiangguanxinxi\">Ͷ�ʷ�ʽ</td>");
            sb.Append("<td class=\"xiangguanxinxi\">������ҵ</td><td class=\"xiangguanxinxi\">��Ч��</td></tr>");
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
