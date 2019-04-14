using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace GZS.DAL
{
    public class AreaimgDAL
    {
        public static int Insert(GZS.Model.Areaimg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into areaimg(");
            strSql.Append("areaid,ImageUrl,ImageName,imgageexplain)");
            strSql.Append(" values (");
            strSql.Append("@areaid,@ImageUrl,@ImageName,@imgageexplain)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.Text),
					new SqlParameter("@ImageName", SqlDbType.Text),
					new SqlParameter("@imgageexplain", SqlDbType.Text)};
            parameters[0].Value = model.areaid;
            parameters[1].Value = model.ImageUrl;
            parameters[2].Value = model.ImageName;
            parameters[3].Value = model.imgageexplain;

            object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public List<GZS.Model.Areaimg> GetAllModelByareId(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select areaimgid,areaid,ImageUrl,ImageName,imgageexplain from areaimg ");
            strSql.Append(" where areaid=@areaid order by areaimgid desc");
            SqlParameter[] parameters = {
					new SqlParameter("@areaid", SqlDbType.Int,4)};
            parameters[0].Value = id;

            List<GZS.Model.Areaimg> list = new List<GZS.Model.Areaimg>();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            foreach(DataRow row in ds.Tables [0].Rows)
            {
                GZS.Model.Areaimg model = new GZS.Model.Areaimg();
                if (row["areaimgid"].ToString() != "")
                {
                    model.areaimgid = int.Parse(row["areaimgid"].ToString());
                }
                if (row["areaid"].ToString() != "")
                {
                    model.areaid = int.Parse(row["areaid"].ToString());
                }
                model.ImageUrl =row["ImageUrl"].ToString();
                model.ImageName = row["ImageName"].ToString();
                model.imgageexplain =row["imgageexplain"].ToString();
                list.Add(model);
            }
            return list;
        }

        public void Delete(int areaid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from areaimg ");
            strSql.Append(" where areaid=@areaimgid ");
            SqlParameter[] parameters = {
					new SqlParameter("@areaimgid", SqlDbType.Int,4)};
            parameters[0].Value = areaid;

            DBHelper.ExecuteCommand(strSql.ToString(), parameters);
        }

        public int Inserts(GZS.Model.Areaimg model)
        {
            int count = 0;
            string[] num = model.ImageUrl.Trim ('$').Split('$');
            for (int i = 0; i < num.Length; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into areaimg(");
                strSql.Append("areaid,ImageUrl,ImageName,imgageexplain)");
                strSql.Append(" values (");
                strSql.Append("@areaid,@ImageUrl,@ImageName,@imgageexplain)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.Text),
					new SqlParameter("@ImageName", SqlDbType.Text),
					new SqlParameter("@imgageexplain", SqlDbType.Text)};
                parameters[0].Value = model.areaid;
                parameters[1].Value = num[i].Trim();
                parameters[2].Value = model.ImageName;
                parameters[3].Value = model.imgageexplain;

                object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
                if (obj != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
