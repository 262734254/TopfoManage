using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GZS.DAL.news
{
    public class NewsViewTabDAL 
    {
        GZS.DAL.news.NewsTabDAL newstab = new NewsTabDAL();
        public GZS.Model.news.NewsViewTab GetNewsViewByNewId(int NewId)
        {
            string sql = "select * from NewsViewTab where Newsid=@newid";
            GZS.Model.news.NewsViewTab newsviewtab = null;
            DataSet set = DBHelper.Query(sql, new SqlParameter("newid", NewId));
            foreach (DataRow row in set.Tables[0].Rows)
            {
                newsviewtab = new GZS.Model.news.NewsViewTab();
                newsviewtab.NViewID = Convert.ToInt32(row["NViewID"]);
                newsviewtab.Newsid = newstab.GetNewsTabByNewId(Convert.ToInt32(row["Newsid"]));
                newsviewtab.Title = row["Title"].ToString().Trim();
                newsviewtab.Keywords = row["Keywords"].ToString().Trim();
                newsviewtab.Description = row["Description"].ToString().Trim();
                newsviewtab.NewView = row["NewView"].ToString().Trim();
                newsviewtab.Formid = row["form"].ToString().Trim();
                newsviewtab.Author = row["Author"].ToString().Trim();
                newsviewtab.Zhaiyao = row["Zhaiyao"].ToString().Trim();

            }
            return newsviewtab;
        }

        public int DeleteNewsViewTab(int Newsid)
        {
            string sql = "delete NewsViewTab where Newsid=@Newsid  ";
            int result = DBHelper.ExecuteSql(sql, new SqlParameter("Newsid", Newsid));
            return result;
        }
        public int UpdateNewsViewTab(GZS.Model.news.NewsViewTab newsviewtab, int newsid)
        {
            string sql = "Update NewsViewTab set Title=@title ,Keywords=@keywords,Description=@descript,NewView=@newview,form=@form,Author=@author,Zhaiyao=@zhaiyao where Newsid=@Newsid  ";
            SqlParameter[] ps = new SqlParameter[]{
                     new SqlParameter("@title",newsviewtab.Title)
                    ,new SqlParameter ("@keywords",newsviewtab.Keywords)
                    ,new SqlParameter ("@descript",newsviewtab.Description)
                    ,new SqlParameter ("@newview",newsviewtab.NewView)
                    ,new SqlParameter ("@form",newsviewtab.Formid)
                    ,new SqlParameter("@author",newsviewtab.Author)
                    ,new SqlParameter ("@zhaiyao",newsviewtab.Zhaiyao)
                    ,new SqlParameter ("@Newsid",newsid)                   
            };
            int result = DBHelper.ExecuteSql(sql, ps);
            return result;
        }
    }
}
