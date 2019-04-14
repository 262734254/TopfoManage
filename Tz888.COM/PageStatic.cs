using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.COM
{
   public class PageStatic
    {
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["CasesAppPath"].ToString(); //�ɹ�����ģ����λ��

       public PageStatic()
       { 
       
       }


       public void CreateStaticPageHtml(int NewsID,string infoID,string DisplayTitle, string MerchantType,
           string CooperationDemandType, string IndustryControl, string ZoneSelectControl, string CapitalTotal,
           string CapitalCurrency, string MerchantTotal, string MerchantCurrency,string PublishT,string ValiditeTerm, string ZoneAbout,
           string EconomicIndicators, string InvestmentEnvironment, string ProjectStatus, string Market, string Benefit,string zfzs,
           string zbzy,string qyxm,string qtzy,string xgzx,
           string CompanyName, string Undertaker, string Name, string Position, string CountryCode, string StateCode,
           string TelNum, string Email, string Address,string Infom )
       {
           StringBuilder str = new StringBuilder();
           #region ģ���ַ
           //ģ��ҳ���ַ
           // string Tempath = ConfigurationManager.AppSettings["Templatepath"].ToString();
           //��̬ҳ���ַ
           // string htmlpath = ConfigurationManager.AppSettings["Htmppath"].ToString();
           //string Name1 = "/temV1.html"; //ģ��ҳ���ַ
           #endregion
          // string TempFileName = ApplicationRootPath + MerchantTmpPath + Name1;//�ļ���ַ
          string TempFileName = "E:/TopfoManage/WEB/Template/temV1.html"; //ģ��ҳ���ַ
           string Tem = Compage.Reader(TempFileName); //��ȡģ������
           #region �滻ģ��
           string TempSoure = Tem;
           TempSoure = TempSoure.Replace("$infoID$", infoID);
           TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);
           TempSoure = TempSoure.Replace("$MerchantType$", MerchantType);
           TempSoure = TempSoure.Replace("$CooperationDemandType$", CooperationDemandType);
           TempSoure = TempSoure.Replace("$IndustryControl$", IndustryControl);
           TempSoure = TempSoure.Replace("$ZoneSelectControl$", ZoneSelectControl);
           TempSoure = TempSoure.Replace("$CapitalTotal$", CapitalTotal);
           TempSoure = TempSoure.Replace("$CapitalCurrency$", CapitalCurrency);
           TempSoure = TempSoure.Replace("$MerchantTotal$", MerchantTotal);
           TempSoure = TempSoure.Replace("$MerchantCurrency$", MerchantCurrency);
           TempSoure = TempSoure.Replace("$PublishT$", PublishT);
           TempSoure = TempSoure.Replace("$ValiditeTerm$", ValiditeTerm);
           TempSoure = TempSoure.Replace("$ZoneAbout$", ZoneAbout);
           TempSoure = TempSoure.Replace("$EconomicIndicators$", EconomicIndicators);
           TempSoure = TempSoure.Replace("$InvestmentEnvironment$", InvestmentEnvironment);
           TempSoure = TempSoure.Replace("$ProjectStatus$", ProjectStatus);
           TempSoure = TempSoure.Replace("$Market$", Market);
           TempSoure = TempSoure.Replace("$Benefit$", Benefit);
           TempSoure = TempSoure.Replace("$zfzs$", zfzs);
           TempSoure = TempSoure.Replace("$zbzy$", zbzy);
           TempSoure = TempSoure.Replace("$qyxm$", qyxm);
           TempSoure = TempSoure.Replace("$qtzy$", qtzy);
           TempSoure = TempSoure.Replace("$xgzx$", xgzx);
           TempSoure = TempSoure.Replace("$CompanyName$", CompanyName);
           TempSoure = TempSoure.Replace("$Undertaker$", Undertaker);
           TempSoure = TempSoure.Replace("$Name$", Name);
           TempSoure = TempSoure.Replace("$Position$", Position);
           TempSoure = TempSoure.Replace("$CountryCode$", CountryCode);
           TempSoure = TempSoure.Replace("$StateCode$", StateCode);
           TempSoure = TempSoure.Replace("$TelNum$", TelNum);
           TempSoure = TempSoure.Replace("$Email$", Email);
           TempSoure = TempSoure.Replace("$Address$", Address);
           TempSoure = TempSoure.Replace("$Infom$", Infom);
           #endregion
           #region
           string inPath = "E:/Merchant/";
            string fileNamehtml = DateTime.Now.ToString("yyyyMMdd"); //�ļ�����
            string htmlpaths = inPath + fileNamehtml + "_" + NewsID + ".shtml";
           Compage.Writer(htmlpaths, TempSoure);
           #endregion
       }
       /// <summary>
       /// �ɹ�������̬ҳ����ʾ
       /// </summary>
       /// <param name="NewsID">���</param>
       /// <param name="title">����</param>
       /// <param name="publishT">ʱ��</param>
       /// <param name="Content">��ϸ����</param>
       public void StaticHtml(int NewsID, string title, string publishT, string Content)
       {
           string TempFileName = "E:/TopfoManage/WEB/Template/XQYE.html"; //ģ��ҳ���ַ
           string Tem = Compage.Reader(TempFileName); //��ȡģ������
           #region �滻ģ��
           string TempSoure = Tem;
           TempSoure = TempSoure.Replace("$title$", title);
           TempSoure = TempSoure.Replace("$publishT$", publishT);
           TempSoure = TempSoure.Replace("$Content$", Content);

           #endregion
           #region
          // string inPath = "E:/cgyl/";
           string fileNamehtml = DateTime.Now.ToString("yyyyMMdd"); //�ļ�����
           string htmlpaths = MerchantTmpPathTo + fileNamehtml + "_" + NewsID + ".shtml";
           Compage.Writer(htmlpaths, TempSoure);
           #endregion
       }
       /// <summary>
       /// ����ID��ѯ�ɹ�������Ϣ
       /// </summary>
       public PageStatic cgyl(int infoId)
       {
           PageStatic page = new PageStatic();
           string sql = "select a.title,a.publishT,a.AuditingStatus,b.[Content] from MainInfoTab as a inner join CasesInfoTab as b on a.InfoID=b.InfoID where a.InfoID=@infoId";
           SqlParameter[] para ={
            new SqlParameter("@infoId",SqlDbType.Int,8)
           };
           para[0].Value = infoId;
           DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
           if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
           {
                page.Title = ds.Tables[0].Rows[0]["title"].ToString();
                page.PublishT = Convert.ToDateTime(ds.Tables[0].Rows[0]["publishT"].ToString());
                page.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                page._auditingStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["AuditingStatus"].ToString());
              
           }
           return page;
       }

       public  string XShi(int auId, string TypeId, string proId, string Industry)
       {

           string name = "";
           if (TypeId == "Merchant")
           {
               string sql = "select top 6 a.Title,a.HtmlFile,a.publishT from MainInfoTab as a ,MerchantInfoTab as b where a.InfoID=b.InfoID and a.AuditingStatus=1 and InfoTypeID='" + TypeId + "' and b.ProvinceID='" + proId + "' and b.IndustryClassList like'%" + Industry + "%' order by a.publishT desc";
              DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
               if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
               {
                   for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                   {
                       DataRow row = ds.Tables[0].Rows[i];
                       DateTime time = Convert.ToDateTime(row["publishT"]);
                       string beg = time.ToShortDateString().ToString();
                       name += "<li><span class=\"l\">��<a href='www.topfo.com/'"+row["HtmlFile"]+" target=\"_blank\">" + row["Title"].ToString() + "</a></span><span class=\"r f_gray\">" + beg + "</span></li>";
                   }
               }
               else
               {
                   name += "<li><span class=\"l\">������������Դ</span>";
               }
           }
           else if (TypeId == "Capital")
           {
               string sql = "select top 6 a.Title,a.HtmlFile,a.publishT from MainInfoTab as a ,MerchantInfoTab as b where a.InfoID=b.InfoID and a.AuditingStatus=1 and a.InfoTypeID='" + TypeId + "' and b.ProvinceID='" + proId + "' and b.IndustryClassList like'%" + Industry + "%' order by a.publishT desc";
               DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
               if (ds.Tables[0].Rows.Count > 0)
               {
                   for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                   {
                       DataRow row = ds.Tables[0].Rows[i];
                       DateTime time = Convert.ToDateTime(row["publishT"]);
                       string beg = time.ToShortDateString().ToString();
                       name += "<li><span class=\"l\">��<a href='www.topfo.com/'" + row["HtmlFile"] + " target=\"_blank\">" + row["Title"].ToString() + "</a></span><span class=\"r f_gray\">" + beg + "</span></li>";
                   }
               }
               else
               {
                   name += "<li><span class=\"l\">������������Դ</span>";
               }
           }
           else if (TypeId == "Project")
           {
               string sql = "select top 6 a.Title,a.HtmlFile,a.publishT from MainInfoTab as a ,MerchantInfoTab as b where a.InfoID=b.InfoID and a.AuditingStatus=1 and a.InfoTypeID='" + TypeId + "' and b.ProvinceID='" + proId + "' and b.IndustryClassList like'%" + Industry + "%' order by a.publishT desc";
               DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
               if (ds.Tables[0].Rows.Count > 0)
               {
                   for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                   {
                       DataRow row = ds.Tables[0].Rows[i];
                       DateTime time = Convert.ToDateTime(row["publishT"]);
                       string beg = time.ToShortDateString().ToString();
                       name += "<li><span class=\"l\">��<a href='www.topfo.com/'" + row["HtmlFile"] + " target=\"_blank\">" + row["Title"].ToString() + "</a></span><span class=\"r f_gray\">" + beg + "</span></li>";
                   }
               }
               else
               {
                   name += "<li><span class=\"l\">������������Դ</span>";
               }
           }
           return name;
       }

       public string QTZY(long TypeId)
       {
           string name = "";
           string sql = "select top 6 b.Title,b.HtmlFile,b.publishT from MerchantInfoTab as a, MainInfoTab as b where a.InfoID =b.InfoID and b.LoginName in(select LoginName from MainInfoTab where InfoID=" + TypeId + ") order by b.publishT desc";
           DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   DataRow row = ds.Tables[0].Rows[i];
                   DateTime time = Convert.ToDateTime(row["publishT"]);
                   string beg = time.ToShortDateString().ToString();
                   name += "<li><span class=\"l\">��<a href='www.topfo.com/'" + row["HtmlFile"] + " target=\"_blank\">" + row["Title"].ToString() + "</a></span><span class=\"r f_gray\">" + beg + "</span></li>";
               }
           }
           else
           {
               name += "<li><span class=\"l\">�����޻�Ա������������Դ</span>";
           }
           return name;
       }

       public string XGZX(int auId, string Industry)
       {
           string name="";
           string sql = "select top 6 a.Title ,a.HtmlFile from MainInfoTab as a ,MerchantInfoTab as b where a.InfoID=b.InfoID and a.AuditingStatus=1 and b.IndustryClassList like'%" + Industry + "%' order by a.publishT desc";
           DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   DataRow row = ds.Tables[0].Rows[i];
                   name += "<li><span class=\"l\">��<a href=" + row["HtmlFile"] + " target=\"_blank\">" + row["Title"].ToString() + "</a></span></li>";
               }
           }
           return name;
       }

       private string _title;

       public  string Title
       {
           get { return _title; }
           set { _title = value; }
       }
       private DateTime _publishT;

       public  DateTime PublishT
       {
           get { return _publishT; }
           set { _publishT = value; }
       }
       private string _Content;

       public  string Content
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
    }
}
