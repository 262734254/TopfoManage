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

namespace Tz888.BLL.zx
{

    public class PageStatic
    {
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["NewsAppPath"].ToString(); //成功案例生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["NewsTem"].ToString(); //成功案例模版存放位置
        /// <summary>
        /// 根据ID查询新闻资讯信息
        /// </summary>
        public PageStatic NewsIdAll(int infoId)
        {
            PageStatic page = new PageStatic();
            string sql = "select a.title,a.publishT,a.AuditingStatus, a.Hit,b.[Content] from MainInfoTab as a inner join NewsTab as b on a.InfoID=b.InfoID where a.InfoID=@infoId";
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
                page.Hit = Convert.ToString(ds.Tables[0].Rows[0]["Hit"].ToString());

            }
            return page;
        }
        /// <summary>
        /// 根据类型查看信息
        /// </summary>
        public string SetType(string type)
        {
            StringBuilder builder = new StringBuilder();
            string sql = "select a.InfoID from MainInfoTab as a inner join NewsTab as b on a.InfoID=b.InfoID where b.NewsTypeId=@type and a.AuditingStatus=1 and a.HtmlFile!='' order by a.publishT desc";
            SqlParameter[] para ={
            new SqlParameter("@type",SqlDbType.Int,8)
           };
            para[0].Value = type;
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
        /// <summary>
        ///新闻静态页面显示
        /// </summary>
        /// <param name="NewsID">编号</param>
        /// <param name="title">标题</param>
        /// <param name="publishT">时间</param>
        /// <param name="Content">详细内容</param>
        public void StaticHtml(int NewsID, string title, string publishT, string Content)
        {
            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                #region 替换模版
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$title$", title);
                TempSoure = TempSoure.Replace("$publishT$", publishT);
                TempSoure = TempSoure.Replace("$Content$", Content);

                #endregion
                #region
                string inPathTo = "/News";

                string sql1 = "select a.HtmlFile from MainInfoTab as a inner join NewsTab as b on a.InfoID=b.InfoID where a.InfoID=" + NewsID + "";
                string htmlFile = Tz888.DBUtility.DbHelperSQL.GetSingle(sql1).ToString();
                string[] html = htmlFile.Split('/');
                string[] nn = html[2].Split('_');
                string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + html[1].Replace("News", "");
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);
                }

                string htmlpaths = wenjian + inPathTo + cc + "_" + NewsID + ".shtml";
                Compage.Writer(htmlpaths, TempSoure);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            #endregion
        }

        public void ModifyHtmlFile(int infoId)
        {

            try
            {
                string inPathTo = "/News";
                string sql1 = "select a.HtmlFile from MainInfoTab as a inner join NewsTab as b on a.InfoID=b.InfoID where a.InfoID=" + infoId + "";
                string htmlFile = Tz888.DBUtility.DbHelperSQL.GetSingle(sql1).ToString();
                if (htmlFile != "")
                {
                    string[] html = htmlFile.Split('/');
                    string htmlcc = html[1].Replace("News", "");
                    string[] nn = html[2].Split('_');
                    string cc = nn[0].Substring(nn[0].Length - 8);
                    //string arry = "F:/Topfo/tzWeb/News/" + htmlcc + inPathTo + cc + "_" + infoId + ".shtml";
                    //string arrylist = arry.Replace("F:/Topfo/tzWeb/", "");

                    string arry = "J:/Topfo/tzWeb/News/" + htmlcc + inPathTo + cc + "_" + infoId + ".shtml";
                    string arrylist = arry.Replace("J:/Topfo/tzWeb/", "");
                    string sql = "update MainInfoTab set HtmlFile='" + arrylist + "' where InfoID=" + infoId + "";
                    Tz888.DBUtility.DbHelperSQL.ExecuteSql(sql);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private DateTime _publishT;

        public DateTime PublishT
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

    }
}
