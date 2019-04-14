using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.BLL
{
   public class PageBLL
    {
     private static  PageStatic2 statedal = new PageStatic2();
       private static Tz888.BLL.zx.PageStatic stataidal = new Tz888.BLL.zx.PageStatic();
       private static ProjectState project = new ProjectState();
       public PageBLL()
       {

       }
       #region
       /// <summary>
       /// 成功案例静态页面显示
       /// </summary>
       /// <param name="NewsID">编号</param>
       /// <param name="title">标题</param>
       /// <param name="publishT">时间</param>
       /// <param name="Content">详细内容</param>
       public void StaticHtml(int NewsID, string InfoID, string title, string publishT, string laiyuan, string zuozhe, string Content, string TypeID)
       {
           statedal.StaticHtml(NewsID,InfoID,title,publishT,laiyuan,zuozhe,Content,TypeID);
       }
       public void ModifyHtmlFile(int infoId)
       {
            statedal.ModifyHtmlFile(infoId);
       }
        /// <summary>
       /// 根据ID查询成功案例信息
       /// </summary>
       public  PageStatic2 cgyl(int infoId)
       {
           return  statedal.cgyl(infoId);
       }
       
       /// <summary>
       /// 根据ID查询新闻资讯信息
       /// </summary>
       public Tz888.BLL.zx.PageStatic NewsIdAll(int infoId)
       {
           return stataidal.NewsIdAll(infoId);
       }
       /// <summary>
       /// 根据类型查看所有信息
       /// </summary>
       public string SetType(string type)
       {
           return stataidal.SetType(type);
       }
       /// <summary>
       /// 新闻静态页面显示
       /// </summary>
       /// <param name="NewsID">编号</param>
       /// <param name="title">标题</param>
       /// <param name="publishT">时间</param>
       /// <param name="Content">详细内容</param>
       public void  NewsStaticHtml(int NewsID, string title, string publishT, string Content)
       {
           stataidal.StaticHtml(NewsID, title, publishT, Content);
       }
       public void NewsModifyHtmlFile(int infoId)
       {
           stataidal.ModifyHtmlFile(infoId);
       }

       /// <summary>
       /// 查询所有成功案例信息
       /// </summary>
       public string selInfoId()
       {
           return statedal.selInfoId();
       }
       /// <summary>
       /// 根据编号区间查询所对于的编号
       /// </summary>
       public string selInfoIdRegion(int beginfo, int endinfo)
       {
           return statedal.selInfoIdRegion(beginfo,endinfo);
       }

       public  string ZFZS(int auId, string TypeId, string proId, string Industry)
       {
           string com = ""; 
           com = statedal.XShi(auId, TypeId, proId, Industry);
           return com;
       }

       public  string huiyuan(long TypeId)
       {
           string com = "";
           com = statedal.QTZY(TypeId);
           return com;
       }

       public  string ZXun(int auId, string Industry)
       {
           string com = "";
           com = statedal.XGZX(auId,Industry);
           return com;
       }

       public PageStatic2 SJInfo(int infoId)
       {
           return statedal.SJInfo(infoId);
       }
       #endregion

       public void ProjectZqHtml(string InfoID, string ProjectName, string ComAbout, string CountryCode, string ProvinceID,
            string CItyID, string CountyID, string IndustryBID, string CapitalTotal, string iZqYqjjdwqk,
                string iZqXmyxqs, string PublishT, string ComBrief, string ManageTeamAbout, string DisplayTitle, string KeyWord,
            string Descript, int num, string lated, string MainPoint, string FixPriceID)
       {
           project.ProjectZqHtml(InfoID, ProjectName, ComAbout, CountryCode, ProvinceID, CItyID, CountyID, IndustryBID, CapitalTotal, iZqYqjjdwqk,
               iZqXmyxqs, PublishT, ComBrief, ManageTeamAbout,DisplayTitle,KeyWord,Descript,num,lated,MainPoint,FixPriceID);
       }

       public ProjectState SelProjectM(string InfoID)
       {
           return project.SelProjectM(InfoID);
       }
       public string SelProjectAll()
       {
           return project.SelProjectAll();
       }
       /// <summary>
        /// 根据行业查找相关的信息
        /// </summary>
        /// <param name="infoId"></param>
       public string SelIndustryLated(string Industry)
       {
           return project.SelIndustryLated(Industry);
       }
       /// <summary>
        /// 判断htmlFile是否存在
        /// </summary>
        /// <param name="infoID"></param>
        /// <returns></returns>
       public string SelHtmlFile(string infoID)
       {
           return project.SelHtmlFile(infoID);
       }
        /// <summary>
        /// 根据资源收费来查找信息
        /// </summary>
        /// <returns></returns>
       public string SelMainPoint()
       {
           return project.SelMainPoint();
       }
       /// <summary>
        /// 将行业编号翻译成名字
        /// </summary>
        /// <returns></returns>
       public string SelIndustryName(string IndustryBID)
       {
           return project.SelIndustryName(IndustryBID);
       }
       /// <summary>
        /// 将项目有限期翻译
        /// </summary>
        /// <returns></returns>
       public string SelDictName(string DictID)
       {
           return project.SelDictName(DictID);
       }
   }
}
