using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data.SqlClient;
using Tz888.IDAL.report;
using Tz888.Model.report;
using System.Data;
namespace Tz888.SQLServerDAL.report
{
    public class IndustryFromDAL : IndustryFromIDAL
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(IndustryFrom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into IndustryFrom(");
            strSql.Append("industryName,LinkMan,tel,email,phone,fax,company,address,QQ,site,meo)");
            strSql.Append(" values (");
            strSql.Append("@industryName,@LinkMan,@tel,@email,@phone,@fax,@company,@address,@QQ,@site,@meo)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@industryName", SqlDbType.VarChar,50),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@fax", SqlDbType.VarChar,50),
					new SqlParameter("@company", SqlDbType.VarChar,150),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@site", SqlDbType.VarChar,120),
					new SqlParameter("@meo", SqlDbType.NVarChar,3000)};
            parameters[0].Value = model.industryName;
            parameters[1].Value = model.LinkMan;
            parameters[2].Value = model.tel;
            parameters[3].Value = model.email;
            parameters[4].Value = model.phone;
            parameters[5].Value = model.fax;
            parameters[6].Value = model.company;
            parameters[7].Value = model.address;
            parameters[8].Value = model.QQ;
            parameters[9].Value = model.site;
            parameters[10].Value = model.meo;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(IndustryFrom model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update IndustryFrom set ");
            strSql.Append("industryName=@industryName,");
            strSql.Append("LinkMan=@LinkMan,");
            strSql.Append("tel=@tel,");
            strSql.Append("email=@email,");
            strSql.Append("phone=@phone,");
            strSql.Append("fax=@fax,");
            strSql.Append("company=@company,");
            strSql.Append("address=@address,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("site=@site,");
            strSql.Append("meo=@meo");
            strSql.Append(" where industryId=@industryId");
            SqlParameter[] parameters = {
					new SqlParameter("@industryId", SqlDbType.Int,4),
					new SqlParameter("@industryName", SqlDbType.VarChar,50),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,50),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@fax", SqlDbType.VarChar,50),
					new SqlParameter("@company", SqlDbType.VarChar,150),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@site", SqlDbType.VarChar,120),
					new SqlParameter("@meo", SqlDbType.NVarChar,3000)};
            parameters[0].Value = model.industryId;
            parameters[1].Value = model.industryName;
            parameters[2].Value = model.LinkMan;
            parameters[3].Value = model.tel;
            parameters[4].Value = model.email;
            parameters[5].Value = model.phone;
            parameters[6].Value = model.fax;
            parameters[7].Value = model.company;
            parameters[8].Value = model.address;
            parameters[9].Value = model.QQ;
            parameters[10].Value = model.site;
            parameters[11].Value = model.meo;

            int rows = DBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int industryId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IndustryFrom ");
            strSql.Append(" where industryId=@industryId");
            SqlParameter[] parameters = {
					new SqlParameter("@industryId", SqlDbType.Int,4)
};
            parameters[0].Value = industryId;

            int rows = DBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string industryIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IndustryFrom ");
            strSql.Append(" where industryId in (" + industryIdlist + ")  ");
            int rows = DBHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public IndustryFrom GetModel(int industryId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 industryId,industryName,LinkMan,tel,email,phone,fax,company,address,QQ,site,meo from IndustryFrom ");
            strSql.Append(" where industryId=@industryId");
            SqlParameter[] parameters = {
					new SqlParameter("@industryId", SqlDbType.Int,4)
};
            parameters[0].Value = industryId;

            IndustryFrom model = new IndustryFrom();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["industryId"].ToString() != "")
                {
                    model.industryId = int.Parse(ds.Tables[0].Rows[0]["industryId"].ToString());
                }
                model.industryName = ds.Tables[0].Rows[0]["industryName"].ToString();
                model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                model.fax = ds.Tables[0].Rows[0]["fax"].ToString();
                model.company = ds.Tables[0].Rows[0]["company"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                model.site = ds.Tables[0].Rows[0]["site"].ToString();
                model.meo = ds.Tables[0].Rows[0]["meo"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select industryId,industryName,LinkMan,tel,email,phone,fax,company,address,QQ,site,meo ");
            strSql.Append(" FROM IndustryFrom ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" industryId,industryName,LinkMan,tel,email,phone,fax,company,address,QQ,site,meo ");
            strSql.Append(" FROM IndustryFrom ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.Query(strSql.ToString());
        }
        
        #endregion  Method
    }
}
