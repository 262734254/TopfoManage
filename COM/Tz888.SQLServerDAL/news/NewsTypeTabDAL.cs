using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.news;
using Tz888.DBUtility;
using System.Data;
using Tz888.Model;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.news
{
    public class NewsTypeTabDAL : INewsTypeTab
    {
        public List<Tz888.Model.NewsTypeTab> GetAllNewsType()
        {
            string sql = "select TypeID ,TypeName from NewsTypeTab where BoolStar=1";
            List<Tz888.Model.NewsTypeTab> list = new List<NewsTypeTab>();
            DataSet set = null;
            set = DBHelper.Query(sql);
            foreach (DataRow row in set.Tables[0].Rows)
            {
                Tz888.Model.NewsTypeTab newstypetab = new Tz888.Model.NewsTypeTab();
                newstypetab.TypeID=Convert .ToInt32 (row["TypeID"]);
                newstypetab.TypeName = row["TypeName"].ToString().Trim();
                list.Add(newstypetab);
            }
            return list;
        }
        public Tz888.Model.NewsTypeTab GetNewsTypeByTypeId(int typeId)
        {
            string sql = "select TypeID ,TypeName,BoolStar,outid from NewsTypeTab where TypeID=@typeid ";
            DataSet set = DBHelper.Query(sql,new SqlParameter("typeid",typeId));
            Tz888.Model.NewsTypeTab newstypetab=null;
            foreach (DataRow row in set.Tables[0].Rows)
            {
                newstypetab = new Tz888.Model.NewsTypeTab();
                newstypetab.TypeID = Convert.ToInt32(row["TypeID"]);
                newstypetab.TypeName = row["TypeName"].ToString().Trim();
                newstypetab.BoolStar = Convert.ToInt32(row["BoolStar"].ToString().Trim());
                newstypetab.Outid = Convert.ToInt32(row["Outid"].ToString().Trim());

            }
            return newstypetab;
        }
        public int InsertNewTypeTab(Tz888.Model.NewsTypeTab newstypetab)
        {
            string sql = "Insert into NewsTypeTab (TypeName,BoolStar,outid) values(@typename,@boolstar,@outid)";
            SqlParameter[] ps = new SqlParameter[] { new SqlParameter("typename",newstypetab.TypeName),new SqlParameter ("boolstar",newstypetab .BoolStar),new SqlParameter ("outid",newstypetab .Outid) };
            int result = DBHelper.ExecuteCommand(sql, ps);
            return result;
        }
        public int UpdateNewTypeTab(Tz888.Model.NewsTypeTab newstypetab)
        {
            string sql = "update  NewsTypeTab set TypeName=@typename,BoolStar=@boolstar,outid=@outid where TypeID=@typeid";
            SqlParameter[] ps = new SqlParameter[] { new SqlParameter("typename", newstypetab.TypeName), new SqlParameter("boolstar", newstypetab.BoolStar), new SqlParameter("outid", newstypetab.Outid), new SqlParameter("typeid", newstypetab.TypeID) };
            int result = DBHelper.ExecuteCommand(sql, ps);
            return result;
        }
    }
}
