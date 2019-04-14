using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GZS.Model;

namespace GZS.DAL
{
   public class EnvironmentImgDAL
    {
       public int Insert(GZS .Model .EnvironmentImgM  model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into EnvironmentImg(");
           strSql.Append("Environmenttabid,imgpath,imgexplain)");
           strSql.Append(" values (");
           strSql.Append("@Environmenttabid,@imgpath,@imgexplain)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@Environmenttabid", SqlDbType.Int,4),
					new SqlParameter("@imgpath", SqlDbType.NVarChar,300),
					new SqlParameter("@imgexplain", SqlDbType.NVarChar,300)};
           parameters[0].Value = model.Environmenttabid;
           parameters[1].Value = model.imgpath;
           parameters[2].Value = model.imgexplain;

           object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
           if (obj == null)
           {
               return 1;
           }
           else
           {
               return Convert.ToInt32(obj);
           }
       }
       public List<GZS.Model.EnvironmentImgM> GetAllByEnvironmentTabId(int EnviromentId)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select Environmentid,Environmenttabid,imgpath,imgexplain from EnvironmentImg ");
           strSql.Append(" where Environmenttabid=@Environmenttabid ");
           SqlParameter[] parameters = {
					new SqlParameter("@Environmenttabid", SqlDbType.Int,4)};
           parameters[0].Value = EnviromentId;

           List<EnvironmentImgM>list = new List<EnvironmentImgM>();
           DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
           foreach(DataRow row in ds.Tables [0].Rows)
           {
               EnvironmentImgM model = new EnvironmentImgM();
               if (row["Environmentid"].ToString() != "")
               {
                   model.Environmentid = int.Parse(row["Environmentid"].ToString());
               }
               if (row["Environmenttabid"].ToString() != "")
               {
                   model.Environmenttabid = int.Parse(row["Environmenttabid"].ToString());
               }
               model.imgpath = row["imgpath"].ToString();
               model.imgexplain = row["imgexplain"].ToString();
                 list.Add (model);
           }
           return list;
       }
       public void Delete(int Environmenttabid)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from EnvironmentImg ");
           strSql.Append(" where Environmenttabid=@Environmentid ");
           SqlParameter[] parameters = {
					new SqlParameter("@Environmentid", SqlDbType.Int,4)};
           parameters[0].Value = Environmenttabid;

           DBHelper.ExecuteSql(strSql.ToString(), parameters);
       }

    }
}
