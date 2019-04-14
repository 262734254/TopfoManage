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

using System.Text.RegularExpressions;
using System.Reflection;
using GZS.DAL;
namespace GZS.BLL.news
{
    public class PageStatic
    {
         NewsTabBLL newstabbll = new NewsTabBLL();
         NewsTypeTabBLL newstypetabbll = new NewsTypeTabBLL();
         NewsViewTabBLL newsviewtabbll = new NewsViewTabBLL();
         string MerchantTmpPathTo = ConfigurationManager.AppSettings["DKNeSuccse"].ToString(); //成功案例生成页面存放位置
         string MerchantTmpPathTos = ConfigurationManager.AppSettings["DKNewsSuccse"].ToString(); //首页成功案例生成页面存放位置
         string CasesTem = ConfigurationManager.AppSettings["DKNeTest"].ToString(); //其他成功案例模版存放位置
         string CasesTems = ConfigurationManager.AppSettings["DKNewsshouye"].ToString(); //其他首页显示成功案例模版存放位置
        string tupianlu = ConfigurationManager.AppSettings["UpimageNewss"].ToString();
        /// <summary>
        ///创建贷款静态页面
        /// </summary>
        public int StaticHtml(int newsid, string loginname)
        {

            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.Model.news.NewsTab newstab = newstabbll.GetNewsTabByNewId(newsid);
                GZS.Model.news.NewsViewTab newsviewtab = newsviewtabbll.GetNewsViewByNewId(newsid);
                string titlelist = sethtmls();
                string context = sethtml();
                string tupianss = newstab.Imagesurls;
                string tupians = "";
                string[] num = tupianss.Split('$');
                for (int t = 0; t < num.Length; t++)
                {
                    if (num[t].Trim() != "")
                    {
                        tupians += "<input type=\"image\" id=\"" + num[t].Trim() + "\" src=\"" + tupianlu + "" + num[t].Trim() + "\"/>";
                    }
                }

                string contextname = newsviewtab.NewView.ToString().Replace("/images/", "crm.topfo.com/images/").ToString();
                TempSoure = TempSoure.Replace("$infoID$", newsid.ToString().Trim());
                TempSoure = TempSoure.Replace("$NewsTitle$", newstab.NTitle.ToString().Trim());
                TempSoure = TempSoure.Replace("$Createtime$", newstab.Createdate.Substring(0, 9).Trim());
                TempSoure = TempSoure.Replace("$FormId$", newsviewtab.Formid.ToString().Trim());
                TempSoure = TempSoure.Replace("$Author$", newsviewtab.Author.ToString().Trim());
                TempSoure = TempSoure.Replace("$ZhaiYao$", newsviewtab.Zhaiyao.ToString().Trim());
                TempSoure = TempSoure.Replace("$NewsView$", contextname);
                TempSoure = TempSoure.Replace("$tupian$", tupians);
                TempSoure = TempSoure.Replace("$TitleList$", titlelist.ToString().Trim());
                TempSoure = TempSoure.Replace("$Context$", context.ToString().Trim());
                TempSoure = TempSoure.Replace("$DisplayTitle$", newsviewtab.Title.ToString().Trim());
                TempSoure = TempSoure.Replace("$KeyWord$", newsviewtab.Keywords.ToString().Trim());
                TempSoure = TempSoure.Replace("$description$", newsviewtab.Description.ToString().Trim());



                string inPathTo = "/news";

                string htmlFile = newstab.Urlhtml.ToString().Trim();
                string[] html = htmlFile.Split('/');
                string[] nn = html[2].Split('_');
                string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + html[1].Replace("news", "");
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);
                }

                string htmlpaths = wenjian + inPathTo + cc + "_" + newsid + ".shtml";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }


        /// <summary>
        ///创建首页资讯链接静态页面1
        /// </summary>
        public int StaticHtmls(string loginname)
        {

            try
            {
                string TempFileName = CasesTems.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.DAL.product.CommStatic dal = new GZS.DAL.product.CommStatic();
                string ds = dal.GetNewList(loginname).Trim();
                TempSoure = TempSoure.Replace("$cntex$", ds);
                //string[] html = htmlFile.Split('/');


                //string[] nn = html[2].Split('_');
                //string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = MerchantTmpPathTos + loginname + "/newss.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        public string sethtml()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 6 NTitle,urlhtml from NewsTab where audit=1 order by createdate desc";
            DataSet ds = DBHelper.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string Title = ds.Tables[0].Rows[i]["NTitle"].ToString();
                    sb.Append("<li>·<a href='http://news.topfo.com/" + row["urlhtml"].ToString() + "' target=\"_blank\">" + StrLength(Title.ToString().Trim(), 16) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        public string sethtmls()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 6 NTitle,urlhtml,createdate from NewsTab where audit=1 order by createdate desc";
            DataSet ds =DBHelper.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string Title = ds.Tables[0].Rows[i]["NTitle"].ToString();
                    sb.Append("<li><a href='http://news.topfo.com/" + row["urlhtml"].ToString() + "' target=\"_blank\">" + "<span>" + StrLength(Title.ToString().Trim(), 16) + "</span>" + "<h12>" + ds.Tables[0].Rows[i]["createdate"].ToString().Substring(0, 9) + "</h12></a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        protected string StrLength(object title, int count)
        {
            string name = "";
            name = title.ToString();
            if (name.Length > count)
            {
                name = name.Substring(0, count) + "...";
            }
            return name;
        }
    }
}
