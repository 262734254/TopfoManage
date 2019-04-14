using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;

namespace GZS.DAL.news
{
    public class NewsTabDAL
    {
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["DKNewsSuccse"].ToString(); //成功案例生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["DKNewsListLink"].ToString(); //其他更多资讯成功案例模版存放位置
        /// <summary>
        ///创建首页更多资讯链接静态页面
        /// </summary>
        public int StaticHtml(string loginname)
        {

            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                List<GZS.Model.news.NewsTab> list = GetNewsTabAllByUserName(loginname);
                StringBuilder ste=new StringBuilder();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i < 20)
                    {
                        ste.Append(" <li><a href='http://news.topfo.com/" + list[i].Urlhtml.ToString() + "' target=\"_blank\"><span class=\"infor-l\">" + list[i].NTitle + "</span><span  class=\"infor-r\">" + Convert.ToDateTime(list[i].Createdate).ToString("yyyy-MM-dd") + "</span></a></li>");
                    }
                }
                TempSoure = TempSoure.Replace("$cntex$", ste.ToString ());
                TempSoure = TempSoure.Replace("$loginName$", loginname.Trim());
                //string[] html = htmlFile.Split('/');


                //string[] nn = html[2].Split('_');
                //string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = MerchantTmpPathTo + loginname + "/infor.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        public int InsertNewsTab(GZS.Model.news.NewsTab newstab, GZS.Model.news.NewsTypeTab newstypetab, GZS.Model.news.NewsViewTab newsviewtab)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@NTitle", SqlDbType.VarChar,200),
					new SqlParameter("@audit", SqlDbType.Int,4),
					new SqlParameter("@FromID", SqlDbType.Int,4),
					new SqlParameter("@urlhtml", SqlDbType.VarChar,200),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@keywords", SqlDbType.VarChar,200),
                    new SqlParameter("@description", SqlDbType.VarChar,200),
                    new SqlParameter("@NewView", SqlDbType.Text,10000),
                    new SqlParameter("@form", SqlDbType.VarChar,2000),
                    new SqlParameter("@author", SqlDbType.VarChar,200),
                    new SqlParameter("@zhaiyao", SqlDbType.VarChar,200),
                    new SqlParameter("@recommendID", SqlDbType.Int,4),
                    new SqlParameter ("@ImagesUrls",SqlDbType .NVarChar ,400)
            };
            parameters[0].Value = newstab.TypeID ;
            parameters[1].Value = newstab.UserName;
            parameters[2].Value = newstab.NTitle;
            parameters[3].Value = newstab.Audit ;
            parameters[4].Value = newstab.FromID;
            parameters[5].Value = newstab.Urlhtml ;
            parameters[6].Value =newstab .Createdate ;
            parameters[7].Value = newsviewtab.Title ;
            parameters[8].Value = newsviewtab.Keywords ;
            parameters[9].Value = newsviewtab.Description ;
            parameters[10].Value = newsviewtab.NewView;
            parameters[11].Value = newsviewtab.Formid;
            parameters[12].Value = newsviewtab.Author;
            parameters[13].Value = newsviewtab.Zhaiyao ;
            parameters[14].Value = newstab.RecommendID;
            parameters[15].Value = newstab.Imagesurls;

            DBHelper.RunProcedure("NewsTab_Insert", parameters, out rowsAffected);
            return rowsAffected;
        }
        public GZS.Model.news.NewsTab GetNewsTabByNewId(int NewId)
        {
            string sql = "select Newsid,UserName,NTitle,TypeID,audit,FromID,urlhtml,createdate,recommendID,reason,ImagesUrls from NewsTab where Newsid=@newid";
            GZS.Model.news.NewsTab newstab=null;
            DataSet set = DBHelper.Query(sql, new SqlParameter("newid", NewId));
            foreach (DataRow row in set.Tables[0].Rows)
            {
                newstab = new GZS.Model.news.NewsTab();
                newstab.Newsid = Convert.ToInt32(row["Newsid"]);
                newstab.NTitle =row["NTitle"].ToString ().Trim ();
                newstab.UserName = row["UserName"].ToString().Trim();
                newstab.TypeID = Convert.ToInt32(row["TypeID"]);
                newstab.Audit = Convert.ToInt32(row["Audit"]);
                newstab.FromID = Convert.ToInt32(row["FromID"]);
                newstab.Urlhtml = row["urlhtml"].ToString().Trim();
                newstab.Createdate = row["Createdate"].ToString().Trim();
                newstab.RecommendID = Convert .ToInt32(row["RecommendID"].ToString().Trim());
                newstab.Reason = row["Reason"].ToString().Trim();
                newstab.Imagesurls = row["Imagesurls"].ToString().Trim();
            }
            return newstab;
        }
        public List<GZS.Model.news.NewsTab> GetNewsTabAllByUserName(string UserName)
        {
            string sql = "select Newsid,UserName,NTitle,TypeID,audit,FromID,urlhtml,createdate,recommendID,reason,ImagesUrls from NewsTab where UserName=@UserName order by createdate desc";
            List<GZS.Model.news.NewsTab> list = new List<GZS.Model.news.NewsTab> ();
            DataSet set = DBHelper.Query(sql, new SqlParameter("@UserName", UserName));
            foreach (DataRow row in set.Tables[0].Rows)
            {
                GZS.Model.news.NewsTab newstab = new GZS.Model.news.NewsTab();
                newstab.Newsid = Convert.ToInt32(row["Newsid"]);
                newstab.NTitle = row["NTitle"].ToString().Trim();
                newstab.UserName = row["UserName"].ToString().Trim();
                newstab.TypeID = Convert.ToInt32(row["TypeID"]);
                newstab.Audit = Convert.ToInt32(row["Audit"]);
                newstab.FromID = Convert.ToInt32(row["FromID"]);
                newstab.Urlhtml = row["urlhtml"].ToString().Trim();
                newstab.Createdate = row["Createdate"].ToString().Trim();
                newstab.RecommendID = Convert.ToInt32(row["RecommendID"].ToString().Trim());
                newstab.Reason = row["Reason"].ToString().Trim();
                newstab.Imagesurls = row["Imagesurls"].ToString().Trim();
                list.Add(newstab);
            }
            return list;
        }
        public string  GetMaxNewsId()
        {
            string sql = "select Max(Newsid)as Newsid from NewsTab";
            DataSet set = DBHelper.Query(sql);
            string par = "";
            foreach (DataRow row in set.Tables[0].Rows)
            {
                par = row["Newsid"].ToString().Trim();
            }
            return par;
        }
        public int DeleteNewsTab(int Newsid)
        {
            string sql = "delete NewsTab where Newsid=@Newsid  ";
            int result = DBHelper.ExecuteSql(sql, new SqlParameter("Newsid", Newsid));
            return result;
        }
        public int UpdateNewsTab(GZS.Model.news.NewsTab newstab, int newsid)
        {
            string sql = "Update NewsTab set NTitle=@ntitle ,TypeID=@typeid,Audit=@audit,urlhtml=@urlhtml,Reason=@Reason,RecommendID=@RecommendID where Newsid=@Newsid  ";
            SqlParameter[] ps = new SqlParameter[]{
                     new SqlParameter("@ntitle",newstab.NTitle)
                    ,new SqlParameter ("@typeid",newstab.TypeID)
                    ,new SqlParameter ("@audit",newstab.Audit)
                    ,new SqlParameter ("@urlhtml",newstab.Urlhtml)
                    ,new SqlParameter ("@Reason",newstab .Reason )
                    ,new SqlParameter ("@RecommendID",newstab .RecommendID )
                    ,new SqlParameter ("@Newsid",newsid)
             
                    
            };
            int result = DBHelper.ExecuteSql(sql, ps);
            return result;
        }
        public int UpdateNewsTabUrl(string url, int newsid)
        {
            string sql = "Update NewsTab set urlhtml=@urlhtml where Newsid=@Newsid  ";
            SqlParameter[] ps = new SqlParameter[]{
                    new SqlParameter ("@urlhtml",url)
                    ,new SqlParameter ("@Newsid",newsid)
                    
            };
            int result = DBHelper.ExecuteSql(sql, ps);
            return result;
        }
        public int UpdateNewsTabImageUrl(string url, int newsid)
        {
            string sql = "Update NewsTab set Imagesurls=@urlhtml where Newsid=@Newsid  ";
            SqlParameter[] ps = new SqlParameter[]{
                    new SqlParameter ("@urlhtml",url)
                    ,new SqlParameter ("@Newsid",newsid)
                    
            };
            int result = DBHelper.ExecuteSql(sql, ps);
            return result;
        }
    }
}
