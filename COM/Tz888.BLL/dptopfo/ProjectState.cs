using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

using Tz888.Model.Info;
using Tz888.IDAL.Info;
using Tz888.DBUtility;

namespace Tz888.BLL
{
    public class ProjectState
    {
        string ProjectPath = ConfigurationManager.AppSettings["ProjectPath"].ToString(); //融资静态页面存放路径
        string ZqTerm = ConfigurationManager.AppSettings["ZqTerm"].ToString(); //债权融资模版存放位置
        string GqTerm = ConfigurationManager.AppSettings["GqTerm"].ToString();//股权融资模版存放位置
        private const string ProjectPicPath = "http://images.topfo.com/";      //图片路径

        Tz888.SQLServerDAL.Info.ProjectInfoDAL dal = new Tz888.SQLServerDAL.Info.ProjectInfoDAL();

        public ProjectState()
       {

       }

       #region 融资静态页面生成
       public  void ProjectZqHtml(string InfoID,string ProjectName,string ComAbout,string CountryCode,string ProvinceID,
            string CItyID,string CountyID,string IndustryBID,string CapitalTotal,string iZqYqjjdwqk,
                string iZqXmyxqs, string PublishT, string ComBrief, string ManageTeamAbout,string DisplayTitle,string KeyWord,
            string Descript, int num, string lated, string MainPoint,string FixPriceID)
       {
           ProjectSetModel TheProject = new ProjectSetModel();
          string style = "display:none";
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
           #region 图片属性
           TheProject = this.objGetProjectInfoByInfoID(long.Parse(InfoID.Trim()));
           string NameTotal = TheProject.ProjectInfoModel.CapitalName.Trim();
           if (NameTotal == "0")
               NameTotal = "暂未填写";
           ArrayList arrListPic = new ArrayList();
           ArrayList arrListDoc = new ArrayList();
           if (TheProject.InfoResourceModels != null)
           {
               foreach (Tz888.Model.Info.InfoResourceModel objModelResource in TheProject.InfoResourceModels)
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
               Pic1_r = "<li id=\"tab_tophome_1\" class=\"on\"><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + " target=\"_blank\"  onmousemove=\"startIndex=1;setTab('tophome',1,1,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + ProjectPicPath.Trim() + Pic1_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
               p1 = "<div id=\"con_tophome_1\"  ><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + " target=\"_blank\"   onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "  alt=\"3\" /></a></div>";
               //Pic1_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic1_s.Trim() + "\" target=\"_blank\"><img src=\"http://www.topfo.com/V4/img/chakan.jpg\"></a></li>";
           }

           if (arrListPic.Count > 1)
           {
               string[] sPicTemp = (string[])arrListPic[1];
               Pic2 = sPicTemp[0];
               Pic2_c = sPicTemp[1];
               //Pic2_s = Common.GetMiniPic(Pic2);
               Pic2_s = Pic2;
               Pic2_r = "<li id=\"tab_tophome_2\" class=\"out\"><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "   onmousemove=\"startIndex=2;setTab('tophome',2,2,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + ProjectPicPath.Trim() + Pic2_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
               p2 = "<div id=\"con_tophome_2\" class=\"hidecontent\" ><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + " target=\"_blank\"   onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + ProjectPicPath.Trim() + Pic2_s.Trim() + "  alt=\"3\" /></a></div>";

           }
           if (arrListPic.Count > 2)
           {
               string[] sPicTemp = (string[])arrListPic[2];
               Pic3 = sPicTemp[0];
               Pic3_c = sPicTemp[1];
               //Pic3_s = Common.GetMiniPic(Pic3);
               Pic3_s = Pic3;
               Pic3_r = "<li id=\"tab_tophome_3\" class=\"out\"><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "   onmousemove=\"startIndex=6;setTab('tophome',3,3,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + ProjectPicPath.Trim() + Pic3_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
               p3 = "<div id=\"con_tophome_3\"  class=\"hidecontent\"><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "   onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + ProjectPicPath.Trim() + Pic3_s.Trim() + "  alt=\"3\" /></a></div>";
               //Pic3_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic3_s.Trim() + "\" target=\"_blank\"><img src=\"http://www.topfo.com/V4/img/chakan.jpg\"></a></li>";
           }
           if (arrListPic.Count > 3)
           {
               string[] sPicTemp = (string[])arrListPic[3];
               Pic4 = sPicTemp[0];
               Pic4_c = sPicTemp[1];
               //Pic4_s = Common.GetMiniPic(Pic4);
               Pic4_s = Pic4;
               Pic4_r = "<li id=\"tab_tophome_4\" class=\"out\"><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "  onmousemove=\"startIndex=4;setTab('tophome',4,4,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + ProjectPicPath.Trim() + Pic4_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
               p4 = "<div id=\"con_tophome_4\"  class=\"hidecontent\"><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "   onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + ProjectPicPath.Trim() + Pic4_s.Trim() + "  alt=\"3\" /></a></div>";

               //Pic4_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic4_s.Trim() + "\" target=\"_blank\"><img src=\"http://www.topfo.com/V4/img/chakan.jpg\"></a></li>";
           }
           if (arrListPic.Count > 4)
           {
               string[] sPicTemp = (string[])arrListPic[4];
               Pic5 = sPicTemp[0];
               Pic5_c = sPicTemp[1];
               //Pic5_s = Common.GetMiniPic(Pic5);
               Pic5_s = Pic5;
               Pic5_r = "<li id=\"tab_tophome_5\" class=\"out\"><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "   onmousemove=\"startIndex=5;setTab('tophome',5,5,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + ProjectPicPath.Trim() + Pic5_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
               p5 = "<div id=\"con_tophome_5\"  class=\"hidecontent\"><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "   onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + ProjectPicPath.Trim() + Pic5_s.Trim() + "  alt=\"3\" /></a></div>";

               //Pic5_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic5_s.Trim() + "\" target=\"_blank\"><img src=\"http://www.topfo.com/V4/img/chakan.jpg\"></a></li>";
           }
           if (arrListPic.Count > 5)
           {
               string[] sPicTemp = (string[])arrListPic[5];
               Pic6 = sPicTemp[0];
               Pic6_c = sPicTemp[1];
               //Pic6_s = Common.GetMiniPic(Pic6);
               Pic6_s = Pic6;
               Pic6_r = "<li id=\"tab_tophome_6\" class=\"out\"><a href=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "   onmousemove=\"startIndex=6;setTab('tophome',6,6,'out','on');\" onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.SOSO_2'});\"><img src=" + ProjectPicPath.Trim() + Pic6_s.Trim() + " class=\"tab_img\" alt=\"4\"/></a></li>";
               p6 = "<div id=\"con_tophome_5\"  class=\"hidecontent\"><ahref=" + ProjectPicPath.Trim() + Pic1_s.Trim() + "  onclick=\"javascript:pgvSendClick({hottag:'KF.SERVICE.INDEX.STUDY_1'});\"><img  src=" + ProjectPicPath.Trim() + Pic6_s.Trim() + "  alt=\"3\" /></a></div>";

               //Pic6_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic6_s.Trim() + "\" target=\"_blank\"><img src=\"http://www.topfo.com/V4/img/chakan.jpg\"></a></li>";
           }

         
           #endregion
           string TempFileName = "";
           if (num == 1)//为债权融资
           {
               TempFileName = ZqTerm.ToString();
           }
           else if (num == 2)//股权融资$MainPoint$
           {
               TempFileName = GqTerm.ToString();
           }
           string Tem = GZS.BLL.Compage.Reader(TempFileName); //读取模板内容
           #region 替换模版
           string TempSoure = Tem;
           TempSoure = TempSoure.Replace("$ProjectName$", ProjectName);
           TempSoure = TempSoure.Replace("$ComAbout$", ComAbout);
           TempSoure = TempSoure.Replace("$CountryCode$", CountryCode);
           TempSoure = TempSoure.Replace("$ProvinceID$", ProvinceID);
           TempSoure = TempSoure.Replace("$CItyID$", CItyID);
           TempSoure = TempSoure.Replace("$CountyID$", CountyID);
           TempSoure = TempSoure.Replace("$IndustryBID$", IndustryBID);

           TempSoure = TempSoure.Replace("$CapitalTotal$", CapitalTotal);
           TempSoure = TempSoure.Replace("$iZqYqjjdwqk$", iZqYqjjdwqk);
           TempSoure = TempSoure.Replace("$iZqXmyxqs$", iZqXmyxqs);
           TempSoure = TempSoure.Replace("$PublishT$", PublishT);
           TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);
           TempSoure = TempSoure.Replace("$KeyWord$", KeyWord);
           TempSoure = TempSoure.Replace("$Descript$", Descript);
           TempSoure = TempSoure.Replace("$InfoID$", InfoID);
           TempSoure = TempSoure.Replace("$ComBrief$", ComBrief);
           TempSoure = TempSoure.Replace("$ManageTeamAbout$", ManageTeamAbout);

           TempSoure = TempSoure.Replace("$lated$", lated);
           TempSoure = TempSoure.Replace("$MainPoint$", MainPoint);
           TempSoure = TempSoure.Replace("$FixPriceID$", FixPriceID);
           TempSoure = TempSoure.Replace("$Pic$", Pic1_r);
           TempSoure = TempSoure.Replace("$NameToal$", NameTotal);
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

               TempSoure = TempSoure.Replace("$tupian$",tupian);
           }
           else
           {
               string tupian = "display:block";

               TempSoure = TempSoure.Replace("$tupian$", tupian);

           }

           
           if (ManageTeamAbout == "")
           {
               TempSoure = TempSoure.Replace("$tudui$", style);
           }
           else
           {
               TempSoure = TempSoure.Replace("$tudui$", "display:block");
           }
           #endregion
           string sql = "select HtmlFile from MainInfoTab  where InfoID=@InfoID";
           SqlParameter[] para ={ 
               new SqlParameter("@InfoID",SqlDbType.VarChar,100)
           };
           para[0].Value = InfoID;
           string htmlFile = Tz888.DBUtility.DbHelperSQL.GetSingle(sql,para).ToString();
           string[] html = htmlFile.Split('/');
           string[] ht = html[2].Split('_');
           string wenjian = ProjectPath + html[1].ToString();
           if (Directory.Exists(wenjian) == false)
           {
               Directory.CreateDirectory(wenjian);
           }
           string htmlpaths = wenjian + "\\" +ht[0].ToString()+ "_" + InfoID + ".shtml";
           GZS.BLL.Compage.Writer(htmlpaths, TempSoure);
       }
       #endregion

       #region 通过InfoID获取一个信息实体
       /// <summary>
       /// 通过InfoID获取一个Project的信息实体
       /// </summary>
       /// <returns></returns>
       public ProjectSetModel objGetProjectInfoByInfoID(long InfoID)
       {

           ProjectSetModel TheProjectInfo = new ProjectSetModel();
           TheProjectInfo = dal.GetIntegrityModel(InfoID);
           return TheProjectInfo;
       }
       #endregion
       /// <summary>
        /// 根据编号查询所对应的信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public ProjectState SelProjectM(string InfoID)
        {
            ProjectState page = new ProjectState();
            StringBuilder sb = new StringBuilder();
            string sql = "select a.InfoID, a.ProjectName,a.ComAbout,a.CountryCode,a.ProvinceID,a.CityID,a.CountyID,"
                + " a.IndustryBID,a.CooperationDemandType,a.CapitalTotal,a.iZqYqjjdwqk,a.iZqXmyxqs,b.PublishT,a.ComBrief,a.ManageTeamAbout,"
                + " b.DisplayTitle,b.KeyWord,b.Descript,b.AuditingStatus,b.FixPriceID,b.MainPointCount from ProjectInfoTab as a inner join MainInfoTab as b on a.InfoID=b.InfoID where a.InfoID=@InfoID";
            SqlParameter[] para ={ 
                new SqlParameter("@InfoID",SqlDbType.VarChar,30)
            };
            para[0].Value = InfoID;
            DataSet ds = DbHelperSQL.Query(sql,para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
               
                page.Id = ds.Tables[0].Rows[0]["InfoID"].ToString().Trim();//编号 0
                page.ProjectName = ds.Tables[0].Rows[0]["ProjectName"].ToString().Trim();//项目标题 1
                page.ComAbout = ds.Tables[0].Rows[0]["ComAbout"].ToString().Trim();//项目内容 2
                page.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString().Trim();//所对应国家 3
                page.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString().Trim();//所对应省名称 4
                page.CityID = ds.Tables[0].Rows[0]["CityID"].ToString().Trim();//所对应城市名称 5
                page.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString().Trim();//所对应城市下的名称 6
                page.IndustryBID = ds.Tables[0].Rows[0]["IndustryBID"].ToString().Trim();//所对应行业名称 7
                page.CooperationDemandType = ds.Tables[0].Rows[0]["CooperationDemandType"].ToString().Trim();//对应融资类型 8
                page.CapitalTotal = ds.Tables[0].Rows[0]["CapitalTotal"].ToString().Trim();//对应资本上限 9
                page.iZqYqjjdwqk = ds.Tables[0].Rows[0]["iZqYqjjdwqk"].ToString().Trim();//还款保证 10
                page.iZqXmyxqs = ds.Tables[0].Rows[0]["iZqXmyxqs"].ToString().Trim();//有效期 11
                page.publishT = ds.Tables[0].Rows[0]["PublishT"].ToString().Trim();//发布日期 12
                page.comBrief = ds.Tables[0].Rows[0]["ComBrief"].ToString().Trim();//资金使用计划 13
                page.ManageTeamAbout = ds.Tables[0].Rows[0]["ManageTeamAbout"].ToString().Trim();//管理团队 14
                page.DisplayTitle = ds.Tables[0].Rows[0]["DisplayTitle"].ToString().Trim();//网页标题 15
                page.KeyWord = ds.Tables[0].Rows[0]["KeyWord"].ToString().Trim();//网页关键字 16 
                page.Descript = ds.Tables[0].Rows[0]["Descript"].ToString().Trim();//网页描述 17
                page.AuditingStatus = ds.Tables[0].Rows[0]["AuditingStatus"].ToString().Trim();//审核状态 18
                page.FixPriceID = ds.Tables[0].Rows[0]["FixPriceID"].ToString().Trim();//收费资源 19
                page.MainPointCount=ds.Tables[0].Rows[0]["MainPointCount"].ToString().Trim();//收费多少钱 20

            }
            return page;
        }
        /// <summary>
        /// 查找所有InfoID
        /// </summary>
        /// <returns></returns>
        public string SelProjectAll()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select a.InfoID from ProjectInfoTab as a inner join MainInfoTab as b on a.InfoID=b.InfoID";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append(""+row["InfoID"].ToString()+",");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 根据行业查找相关的信息
        /// </summary>
        /// <param name="infoId"></param>
        public string  SelIndustryLated(string Industry)
        {
            Visit.VisitInfoBLL visit=new Tz888.BLL.Visit.VisitInfoBLL();
            StringBuilder sb = new StringBuilder();
            string sql = "select a.ProjectName,a.CapitalTotal,a.ProvinceID,a.CountyID,a.CityID,a.IndustryBID,a.iZqYqjjdwqk,b.HtmlFile "
                + " from ProjectInfoTab as a inner join MainInfoTab as b on a.InfoID=b.InfoID where b.AuditingStatus=1 and a.IndustryBID like ''+@Industry+'%' order by a.InfoID desc";
            SqlParameter[] para ={ 
               new SqlParameter("@Industry",SqlDbType.VarChar,100)
            };
            para[0].Value = Industry;
            DataSet ds = DbHelperSQL.Query(sql,para);
            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tab1\">");
            sb.Append("<tr><td class=\"xiangguanxinxi\">资金标题</td><td class=\"xiangguanxinxi\">可接收资本金额(万元)</td>");
            sb.Append("<td class=\"xiangguanxinxi\">所在地域</td><td class=\"xiangguanxinxi\">所在行业</td>");
            sb.Append("<td class=\"xiangguanxinxi\">还款保证</td></tr>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 5 ? 5 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string sdt = "";//还款保证
                    if (Convert.ToString(row["iZqYqjjdwqk"]) == "" || Convert.ToString(row["iZqYqjjdwqk"])  == null || Convert.ToString(row["iZqYqjjdwqk"]) == "0")
                    {
                        sdt = "暂无";
                    }
                    else if (Convert.ToString(row["iZqYqjjdwqk"]) == "1")
                    {
                        sdt = "担保";
                    }
                    else if (Convert.ToString(row["iZqYqjjdwqk"]) == "2")
                    {
                        sdt = "抵押";
                    }
                    else if (Convert.ToString(row["iZqYqjjdwqk"]) == "3")
                    {
                        sdt = "信用";
                    }
                    sb.Append("<tr><td style=\"height: 28px\"><a href='http://www.topfo.com/"+row["HtmlFile"].ToString()+"'title='"+row["ProjectName"].ToString()+"'target=\"_blank\">" +StrLength(row["ProjectName"].ToString()) + "</a></td><td style=\"height: 28px\">" + row["CapitalTotal"].ToString() + "</td>");
                    sb.Append("<td style=\"height: 28px\">"+visit.SelProvince(row["ProvinceID"].ToString().Trim())+" "+visit.SelCounty(row["CountyID"].ToString().Trim())+" "+visit.SelCityID(row["CityID"].ToString().Trim())+"</td>");
                    sb.Append("<td style=\"height: 28px\">" + SelIndustryName(Industry) + "</td><td style=\"height: 28px\">" + sdt + "</td></tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// 根据资源收费来查找信息
        /// </summary>
        /// <returns></returns>
        public string SelMainPoint()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 6 a.Title,a.HtmlFile from MainInfoTab as a inner join ProjectInfoTab as b on a.InfoID=b.InfoID where a.AuditingStatus=1  order by a.MainPointCount desc";
            DataSet ds = DbHelperSQL.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 6 ? 6 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<li>·<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' title='" + row["Title"].ToString() + "' target=\"_blank\">" + StrLength (row["Title"].ToString())+ "</a></li>");
                }
            }
            sb.Append("<ul>");
            return sb.ToString();
        }

        /// <summary>
        /// 将行业编号翻译成名字
        /// </summary>
        /// <param name="IndustryBID"></param>
        /// <returns></returns>
        public string SelIndustryName(string IndustryBID)
        {
            string name = "";
            if (IndustryBID.IndexOf(",") != 1)
            {
               
                if (IndustryBID != "" || IndustryBID != null)
                {
                    string sql = "select IndustryBName from SetIndustryBTab where IndustryBID=@IndustryBID";
                    SqlParameter[] para ={ 
                   new SqlParameter("@IndustryBID",SqlDbType.VarChar,40)
               };
                    para[0].Value = IndustryBID;
                    name = Convert.ToString(DbHelperSQL.GetSingle(sql, para));
                }
            }   
          
            else
            {

                string[] num = IndustryBID.Split(',');
                for (int i = 0; i < num.Length - 1; i++)
                {
                    string sql = "SELECT * FROM SetIndustryBTab where IndustryBID =@IndustryBID";
                    SqlParameter[] para ={
                new SqlParameter("@IndustryBID",SqlDbType.VarChar,20)};
                    para[0].Value = num[i];
                    DataSet ds = DbHelperSQL.Query(sql, para);
                    if (ds.Tables[0].Rows.Count > 0)
                    {


                        name = ds.Tables[0].Rows[0]["IndustryBName"].ToString() + " ";

                    }
                    else
                    {
                        return null;
                    }

                }
            }

            return name;
        }
        /// <summary>
        /// 将项目有限期翻译
        /// </summary>
        /// <param name="DictID"></param>
        /// <returns></returns>
        public string SelDictName(string DictID)
        { 
           string name="";
           if (DictID != null || DictID != "")
           {
               string sql = "select cDictName from DictTab where cDictType='xmyxqxx' and iDictValue=@DictID";
               SqlParameter[] para ={ 
                   new SqlParameter("@DictID",SqlDbType.VarChar,20)
               };
               para[0].Value = DictID;
               name = Convert.ToString(DbHelperSQL.GetSingle(sql,para)); 
           }
           return name;
        }
        /// <summary>
        /// 判断htmlFile是否存在
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
        public string SelHtmlFile(string infoID)
        {
            string name = "";
            string sql = "select HtmlFile from MainInfoTab where InfoID=@infoID";
            SqlParameter[] para ={ 
               new SqlParameter("@infoID",SqlDbType.VarChar,100)
            };
            para[0].Value = infoID;
            name =Convert.ToString(DbHelperSQL.GetSingle(sql,para));
            return name;
        }
        #region 截取字符串的个数
        protected string StrLength(string title)
        {
            if (title.Length > 20)
            {
                title = title.Substring(0, 20) + "...";
            }
            return title;
        }
        #endregion


        #region 属性封装
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string comAbout;

        public string ComAbout
        {
            get { return comAbout; }
            set { comAbout = value; }
        }
        private string countryCode;

        public string CountryCode
        {
            get { return countryCode; }
            set { countryCode = value; }
        }
        private string provinceID;

        public string ProvinceID
        {
            get { return provinceID; }
            set { provinceID = value; }
        }
        private string cityID;

        public string CityID
        {
            get { return cityID; }
            set { cityID = value; }
        }
        private string countyID;

        public string CountyID
        {
            get { return countyID; }
            set { countyID = value; }
        }
        private string industryBID;

        public string IndustryBID
        {
            get { return industryBID; }
            set { industryBID = value; }
        }
        private string cooperationDemandType;

        public string CooperationDemandType
        {
            get { return cooperationDemandType; }
            set { cooperationDemandType = value; }
        }
        private string capitalTotal;

        public string CapitalTotal
        {
            get { return capitalTotal; }
            set { capitalTotal = value; }
        }
        private string iZqYqjjdwqk;

        public string IZqYqjjdwqk
        {
            get { return iZqYqjjdwqk; }
            set { iZqYqjjdwqk = value; }
        }
        private string iZqXmyxqs;

        public string IZqXmyxqs
        {
            get { return iZqXmyxqs; }
            set { iZqXmyxqs = value; }
        }
        private string publishT;

        public string PublishT
        {
            get { return publishT; }
            set { publishT = value; }
        }
        private string comBrief;

        public string ComBrief
        {
            get { return comBrief; }
            set { comBrief = value; }
        }
        private string manageTeamAbout;

        public string ManageTeamAbout
        {
            get { return manageTeamAbout; }
            set { manageTeamAbout = value; }
        }
        private string displayTitle;

        public string DisplayTitle
        {
            get { return displayTitle; }
            set { displayTitle = value; }
        }
        private string keyWord;

        public string KeyWord
        {
            get { return keyWord; }
            set { keyWord = value; }
        }
        private string descript;

        public string Descript
        {
            get { return descript; }
            set { descript = value; }
        }
        private string auditingStatus;

        public string AuditingStatus
        {
            get { return auditingStatus; }
            set { auditingStatus = value; }
        }
        private string fixPriceID;

        public string FixPriceID
        {
            get { return fixPriceID; }
            set { fixPriceID = value; }
        }
        private string mainPointCount;

        public string MainPointCount
        {
            get { return mainPointCount; }
            set { mainPointCount = value; }
        }
        
        #endregion
    }
}
