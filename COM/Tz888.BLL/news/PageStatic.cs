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
using Tz888.Model.Info;
using Tz888.DALFactory;
using Tz888.IDAL.Info;
using System.Reflection;
namespace Tz888.BLL.news
{
    public class PageStatic
    {
         Tz888.BLL.news.NewsTabBLL newstabbll = new Tz888.BLL.news.NewsTabBLL();
         Tz888.BLL.news.NewsTypeTabBLL newstypetabbll = new Tz888.BLL.news.NewsTypeTabBLL();
         Tz888.BLL.news.NewsViewTabBLL newsviewtabbll = new Tz888.BLL.news.NewsViewTabBLL();
         string MerchantTmpPathTo = ConfigurationManager.AppSettings["DKNewsSuccse"].ToString(); //�ɹ���������ҳ����λ��
         string CasesTem = ConfigurationManager.AppSettings["DKNewsTest"].ToString(); //�����ɹ�����ģ����λ��
         string tupianlu = ConfigurationManager.AppSettings["UpimageNewss"].ToString();
        /// <summary>
        ///�������̬ҳ��
        /// </summary>
        public int StaticHtml(int newsid)
        {

            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //��ȡģ������
              
                string TempSoure = Tem;
                Tz888 .Model .NewsTab newstab=newstabbll.GetNewsTabByNewId(newsid);
                Tz888 .Model .NewsViewTab newsviewtab=newsviewtabbll.GetNewsViewByNewId(newsid);
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
             
                string contextname = newsviewtab.NewView.ToString ().Replace("/images/","crm.topfo.com/images/").ToString ();
                TempSoure = TempSoure.Replace("$infoID$", newsid.ToString().Trim());
                TempSoure = TempSoure.Replace("$NewsTitle$", newstab.NTitle.ToString().Trim());
                TempSoure = TempSoure.Replace("$Createtime$", newstab.Createdate.Substring (0,9).Trim ());
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

        public string newsup()
        {
           return  ConfigurationManager.AppSettings["UpimageNews"].ToString();
        }
        public string newindex()
        {
            return ConfigurationManager.AppSettings["DKNewsIndex"].ToString(); 
        }
        public string sethtml()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 6 NTitle,urlhtml from NewsTab where audit=1 order by createdate desc";
            DataSet ds = Tz888.DBUtility.DBHelper.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string Title = ds.Tables[0].Rows[i]["NTitle"].ToString();
                    sb.Append("<li>��<a href='http://news.topfo.com/" + row["urlhtml"].ToString() + "' target=\"_blank\">" + StrLength(Title.ToString().Trim(), 16) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        public string sethtmls()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 6 NTitle,urlhtml,createdate from NewsTab where audit=1 order by createdate desc";
            DataSet ds = Tz888.DBUtility.DBHelper.Query(sql);
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
