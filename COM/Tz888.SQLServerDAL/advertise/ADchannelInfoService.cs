using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.Model.advertise;
namespace Tz888.SQLServerDAL.advertise
{
   public class ADchannelInfoService:Tz888.IDAL.advertise.IADchannelInfo
    {
        #region 添加频道

        public int Add(Tz888.Model.advertise.ADchannelInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ADchannelInfo(");
            strSql.Append("BName,BDoc)");
            strSql.Append(" values (");
            strSql.Append("@BName,@BDoc)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BName", SqlDbType.VarChar,50),
					new SqlParameter("@BDoc", SqlDbType.VarChar,100)};
            parameters[0].Value = model.BName;
            parameters[1].Value = model.BDoc;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion

        #region 删除频道


        public int DeletechannelInfo(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ADchannelInfo ");
            strSql.Append(" where BID=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            int num = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return num;
        }

      

        #endregion
        #region 修改频道

        public int UpdatechannelInfo(Tz888.Model.advertise.ADchannelInfo model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update ADchannelInfo set ");
           strSql.Append("BName=@BName,");
           strSql.Append("BDoc=@BDoc");
           strSql.Append(" where BID=@BID ");
           SqlParameter[] parameters = {
					new SqlParameter("@BID", SqlDbType.Int,4),
					new SqlParameter("@BName", SqlDbType.VarChar,50),
					new SqlParameter("@BDoc", SqlDbType.VarChar,100)};
           parameters[0].Value = model.BID;
           parameters[1].Value = model.BName;
           parameters[2].Value = model.BDoc;

         int num=  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
         return num;
       }
       #endregion

       #region 根据ID查询信息


       public Tz888.Model.advertise.ADchannelInfo GetAllchannelInfoById(int Id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 BID,BName,BDoc from ADchannelInfo ");
           strSql.Append(" where BID=@Id ");
           SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
           parameters[0].Value = Id;

           ADchannelInfo model = new ADchannelInfo();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["BID"].ToString() != "")
               {
                   model.BID = int.Parse(ds.Tables[0].Rows[0]["BID"].ToString());
               }
               model.BName = ds.Tables[0].Rows[0]["BName"].ToString();
               model.BDoc = ds.Tables[0].Rows[0]["BDoc"].ToString();
               return model;
           }
           else
           {
               return null;
           }
       }

       #endregion
   }
}
