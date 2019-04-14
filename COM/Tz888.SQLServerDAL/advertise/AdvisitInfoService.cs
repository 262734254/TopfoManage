using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.Model.advertise;
namespace Tz888.SQLServerDAL.advertise
{
    public class AdvisitInfoService : Tz888.IDAL.advertise.IAdvisitInfo
    {
        #region IAdvisitInfo 成员
        /// <summary>
        /// 添加访问量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(int adv,string name,string time)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdvisitInfo(");
            strSql.Append("advertiserID,LoginID,VDate)");
            strSql.Append(" values (");
            strSql.Append("@adv,@name,@time)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@adv", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,100),
					new SqlParameter("@time", SqlDbType.VarChar,40)};
            parameters[0].Value = adv;
            parameters[1].Value = name;
            parameters[2].Value = time;

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
        /// <summary>
        /// 根据ID删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteDlaunchInfo(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdvisitInfo ");
            strSql.Append(" where visitID=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

           int num= DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
           return num;
        }
        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAdvisitInfo(AdvisitInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdvisitInfo set ");
            strSql.Append("advertiserID=@advertiserID,");
            strSql.Append("LoginID=@LoginID,");
            strSql.Append("VDate=@VDate");
            strSql.Append(" where visitID=@visitID ");
            SqlParameter[] parameters = {
					new SqlParameter("@visitID", SqlDbType.Int,4),
					new SqlParameter("@advertiserID", SqlDbType.Int,4),
					new SqlParameter("@LoginID", SqlDbType.VarChar,100),
					new SqlParameter("@VDate", SqlDbType.DateTime)};
            parameters[0].Value = model.visitID;
            parameters[1].Value = model.advertiserID;
            parameters[2].Value = model.LoginID;
            parameters[3].Value = model.VDate;

          int num=  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
          return num;
        }
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public AdvisitInfo GetAllAdvisitInfoById(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 visitID,advertiserID,LoginID,VDate from AdvisitInfo ");
            strSql.Append(" where visitID=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            AdvisitInfo model = new AdvisitInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["visitID"].ToString() != "")
                {
                    model.visitID = int.Parse(ds.Tables[0].Rows[0]["visitID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["advertiserID"].ToString() != "")
                {
                    model.advertiserID = int.Parse(ds.Tables[0].Rows[0]["advertiserID"].ToString());
                }
                model.LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                if (ds.Tables[0].Rows[0]["VDate"].ToString() != "")
                {
                    model.VDate = DateTime.Parse(ds.Tables[0].Rows[0]["VDate"].ToString());
                }
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
