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




namespace Tz888.BLL
{
   public class PageStatic2
    {
       
       string MerchantTmpPathTo = ConfigurationManager.AppSettings["CasesAppPath"].ToString(); //成功案例生成页面存放位置
       string CasesTem = ConfigurationManager.AppSettings["CasesTem"].ToString(); //其他成功案例模版存放位置
       string CasesCapital = ConfigurationManager.AppSettings["CasesCapital"].ToString();//投资成功案例模版存放位置
       string CasesMerchant = ConfigurationManager.AppSettings["CasesMerchant"].ToString();//政府招商成功案例模版存放位置
       string CasesProject = ConfigurationManager.AppSettings["CasesProject"].ToString();//融资成功案例模版存放位置

       string SJPath = ConfigurationManager.AppSettings["SjAppPath"].ToString(); //成功案例生成页面存放位置

       public PageStatic2()
       {

       }
       #region 成功案例模块
       #region 成功案例静态页面生成
       /// <summary>
       /// 成功案例静态页面生成
       /// </summary>
       /// <param name="NewsID">编号</param>
       /// <param name="title">标题</param>
       /// <param name="publishT">时间</param>
       /// <param name="Content">详细内容</param>
       public  void StaticHtml(int NewsID,string InfoID, string title, string publishT,string laiyuan,string zuozhe, string Content,string TypeID)
       {
           string TempFileName="";
           string keep = "<a target='_blank' href='http://member.topfo.com/helper/CollectingInfo.aspx?infoid="+NewsID+"'>收藏本页</a>";
           if (TypeID == "01")
           {
               TempFileName = CasesMerchant.ToString();
           }
           else if (TypeID == "02")
           {
               TempFileName = CasesProject.ToString();
           }
           else if (TypeID == "08")
           {
               TempFileName = CasesCapital.ToString();
           }
           else
           {
               TempFileName = CasesTem.ToString();
           }

           
           string Tem = Compage.Reader(TempFileName); //读取模板内容
           #region 替换模版
           string TempSoure = Tem;
           TempSoure = TempSoure.Replace("$title$", title);
           TempSoure = TempSoure.Replace("$publishT$", publishT);
           TempSoure = TempSoure.Replace("$Content$", Content);
           TempSoure = TempSoure.Replace("$keep$", keep);
           TempSoure = TempSoure.Replace("$InfoID$", InfoID);
           TempSoure = TempSoure.Replace("$laiyuan$", laiyuan);
           TempSoure = TempSoure.Replace("$zuozhe$", zuozhe);
           #endregion

           string inPathTo = "Cases";

           string sql1 = "select a.HtmlFile from MainInfoTab as a inner join CasesInfoTab as b on a.InfoID=b.InfoID where a.InfoID=" + NewsID + "";
           string htmlFile = Tz888.DBUtility.DbHelperSQL.GetSingle(sql1).ToString();
           string[] html = htmlFile.Split('/');
           string[] nn = html[2].Split('_');
           string cc = nn[0].Substring(nn[0].Length - 8);

           string wenjian = MerchantTmpPathTo + html[1].Replace("Cases", ""); 
           if (Directory.Exists(wenjian) == false)
           {
               Directory.CreateDirectory(wenjian);
           }
           
           string htmlpaths = wenjian +"\\"+ inPathTo + cc + "_" + NewsID + ".shtml";
           Compage.Writer(htmlpaths, TempSoure);
       }
       #endregion

       #region 修改静态页面所对应的时间
       /// <summary>
       /// 修改静态页面所对应的时间
       /// </summary>
       /// <param name="infoId"></param>
       public void ModifyHtmlFile(int infoId)
       {

           string inPathTo = "/Cases";
           string sql1 = "select a.HtmlFile from MainInfoTab as a inner join CasesInfoTab as b on a.InfoID=b.InfoID where a.InfoID=" + infoId + "";
           string htmlFile = Tz888.DBUtility.DbHelperSQL.GetSingle(sql1).ToString();
           if (htmlFile != "")
           {
               string[] html = htmlFile.Split('/');
               string htmlcc = html[1].Replace("Cases", "");
               string[] nn = html[2].Split('_');
               string cc = nn[0].Substring(nn[0].Length - 8);
               //string arrylist = html[0].ToString() + "/" + htmlcc + inPathTo + cc + "_" + infoId + ".shtml";
               string arry = MerchantTmpPathTo + htmlcc + inPathTo + cc + "_" + infoId + ".shtml"; // "F:/topfo/News/Caseshtml/" + htmlcc + inPathTo + cc + "_" + infoId + ".shtml";
               string arrylist = arry.Replace(MerchantTmpPathTo, "Caseshtml/");
               string sql = "update MainInfoTab set HtmlFile='" + arrylist + "' where InfoID=" + infoId + "";
               Tz888.DBUtility.DbHelperSQL.ExecuteSql(sql);
           }
       }
       #endregion

       /// <summary>
       /// 根据ID查询成功案例信息
       /// </summary>
       public PageStatic2 cgyl(int infoId)
       {
           PageStatic2 page = new PageStatic2();
           string sql = "select a.title,a.publishT,a.AuditingStatus,b.[Content],b.CasesTypeID,c.ShortTitle,c.ShortContent "
               +" from MainInfoTab as a inner join CasesInfoTab as b on a.InfoID=b.InfoID inner join "
               +" ShortInfoTab as c on a.InfoID=c.InfoID where a.InfoID=@infoId";
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
               page.AuditingStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["AuditingStatus"].ToString());
               page.CasesTypeID = ds.Tables[0].Rows[0]["CasesTypeID"].ToString().Trim();
               page.Laiyuan = ds.Tables[0].Rows[0]["ShortTitle"].ToString().Trim();
               page.Zuozhe = ds.Tables[0].Rows[0]["ShortContent"].ToString().Trim();
           }
           return page;
       }
       /// <summary>
       /// 查询所有成功案例信息
       /// </summary>
       public string selInfoId()
       {
           StringBuilder builder = new StringBuilder();
           string sql = "select a.InfoID from MainInfoTab as a inner join CasesInfoTab as b on a.InfoID=b.InfoID order by a.publishT desc";
           DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
           if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   DataRow row = ds.Tables[0].Rows[i];
                   builder.Append("" + row["InfoID"].ToString() + ",");
               }

           }
           return builder.ToString();
       }
       /// <summary>
       /// 根据编号区间查询所对于的编号
       /// </summary>
       public string selInfoIdRegion(int beginfo, int endinfo)
       {
           StringBuilder builder = new StringBuilder();
           string sql = "select a.InfoID from MainInfoTab as a inner join CasesInfoTab as b on a.InfoID=b.InfoID where a.InfoID <=@endinfo and a.InfoID>=@beginfo order by a.publishT desc";
           SqlParameter[] para ={
                new SqlParameter("@beginfo",SqlDbType.Int,8),
               new SqlParameter("@endinfo",SqlDbType.Int,8)
           };
           para[0].Value = beginfo;
           para[1].Value = endinfo;
           DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
           if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   DataRow row = ds.Tables[0].Rows[i];
                   builder.Append("" + row["InfoID"].ToString() + ",");
               }

           }
           return builder.ToString();
       }
       #endregion
       #region 商机静态页面生成
       /// <summary>
       /// 根据ID查询商机信息
       /// </summary>
       public PageStatic2 SJInfo(int infoId)
       {
           PageStatic2 page = new PageStatic2();
           string sql = "select a.title,a.publishT,a.AuditingStatus,b.[Content],b.ProvinceID,b.CountyID,"
               +"b.IndustryOpportunityID,b.OpportunityType,a.ValidateTerm,b.Analysis,b.Flow,b.Request "
               +"from MainInfoTab as a inner join OpportunityInfoTab as b on a.InfoID=b.InfoID where a.InfoID=@infoId";
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
               page.AuditingStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["AuditingStatus"].ToString());
               page.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
               page.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
               page.IndustryOpportunityID = ds.Tables[0].Rows[0]["IndustryOpportunityID"].ToString();
               page.OpportunityType = ds.Tables[0].Rows[0]["OpportunityType"].ToString();
               page.ValidateTerm = ds.Tables[0].Rows[0]["ValidateTerm"].ToString();
               page.Analysis = ds.Tables[0].Rows[0]["Analysis"].ToString();
               page.Flow = ds.Tables[0].Rows[0]["Flow"].ToString();
               page.Request = ds.Tables[0].Rows[0]["Request"].ToString();
           }
           return page;
       }
       #endregion

       #region 老版
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
                       name += "<li><span class=\"l\">·<a href='www.topfo.com/'"+row["HtmlFile"]+" target=\"_blank\">" + row["Title"].ToString() + "</a></span><span class=\"r f_gray\">" + beg + "</span></li>";
                   }
               }
               else
               {
                   name += "<li><span class=\"l\">·暂无类似资源</span>";
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
                       name += "<li><span class=\"l\">·<a href='www.topfo.com/'" + row["HtmlFile"] + " target=\"_blank\">" + row["Title"].ToString() + "</a></span><span class=\"r f_gray\">" + beg + "</span></li>";
                   }
               }
               else
               {
                   name += "<li><span class=\"l\">·暂无类似资源</span>";
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
                       name += "<li><span class=\"l\">·<a href='www.topfo.com/'" + row["HtmlFile"] + " target=\"_blank\">" + row["Title"].ToString() + "</a></span><span class=\"r f_gray\">" + beg + "</span></li>";
                   }
               }
               else
               {
                   name += "<li><span class=\"l\">·暂无类似资源</span>";
               }
           }
           return name;
       }

       public  string QTZY(long TypeId)
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
                   name += "<li><span class=\"l\">·<a href='www.topfo.com/'" + row["HtmlFile"] + " target=\"_blank\">" + row["Title"].ToString() + "</a></span><span class=\"r f_gray\">" + beg + "</span></li>";
               }
           }
           else
           {
               name += "<li><span class=\"l\">·暂无会员发布的其它资源</span>";
           }
           return name;
       }

       public  string XGZX(int auId, string Industry)
       {
           string name="";
           string sql = "select top 6 a.Title ,a.HtmlFile from MainInfoTab as a ,MerchantInfoTab as b where a.InfoID=b.InfoID and a.AuditingStatus=1 and b.IndustryClassList like'%" + Industry + "%' order by a.publishT desc";
           DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
           if (ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   DataRow row = ds.Tables[0].Rows[i];
                   name += "<li><span class=\"l\">·<a href=" + row["HtmlFile"] + " target=\"_blank\">" + row["Title"].ToString() + "</a></span></li>";
               }
           }
           return name;
       }
       #endregion

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

       private string _provinceID;

       public string ProvinceID
       {
           get { return _provinceID; }
           set { _provinceID = value; }
       }

       private string _countyID;

       public string CountyID
       {
           get { return _countyID; }
           set { _countyID = value; }
       }

       private string _industryOpportunityID;

       public string IndustryOpportunityID
       {
           get { return _industryOpportunityID; }
           set { _industryOpportunityID = value; }
       }

       private string _opportunityType;

       public string OpportunityType
       {
           get { return _opportunityType; }
           set { _opportunityType = value; }
       }

       private string _validateTerm;

       public string ValidateTerm
       {
           get { return _validateTerm; }
           set { _validateTerm = value; }
       }

       private string _analysis;

       public string Analysis
       {
           get { return _analysis; }
           set { _analysis = value; }
       }

       private string _flow;

       public string Flow
       {
           get { return _flow; }
           set { _flow = value; }
       }

       private string _request;

       public string Request
       {
           get { return _request; }
           set { _request = value; }
       }

       private string _casesTypeID;

       public string CasesTypeID
       {
           get { return _casesTypeID; }
           set { _casesTypeID = value; }
       }

       private string _laiyuan;

       public string Laiyuan
       {
           get { return _laiyuan; }
           set { _laiyuan = value; }
       }

       private string _zuozhe;

       public string Zuozhe
       {
           get { return _zuozhe; }
           set { _zuozhe = value; }
       }

    }
}
