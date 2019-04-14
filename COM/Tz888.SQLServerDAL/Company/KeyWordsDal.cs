using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.Model.Company;

namespace Tz888.SQLServerDAL.Company
{
    /// <summary>
    /// 数据访问类D_KeyWords。
    /// </summary>
    public class KeyWordsDal
    {
        CrmDBHelper crm = new CrmDBHelper();

        public KeyWordsDal()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoseID, string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KeyWords");
            strSql.Append(" where RoseID=@RoseID and UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoseID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50)};


            parameters[0].Value = RoseID;
            parameters[1].Value = UserName;
            return crm.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(KeyWords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KeyWords(");
            strSql.Append("WebTitle,WebKeyWord,description,RoseID,UserName)");
            strSql.Append(" values (");
            strSql.Append("@WebTitle,@WebKeyWord,@description,@RoseID,@UserName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@WebTitle", SqlDbType.NVarChar),
					new SqlParameter("@WebKeyWord", SqlDbType.NVarChar),
					new SqlParameter("@description", SqlDbType.NVarChar),
					new SqlParameter("@RoseID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.WebTitle;
            parameters[1].Value = model.WebKeyWord;
            parameters[2].Value = model.description;
            parameters[3].Value = model.RoseID;
            parameters[4].Value = model.UserName;

            object obj = crm.GetSingles(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public void Update(KeyWords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KeyWords set ");
            strSql.Append("WebTitle=@WebTitle,");
            strSql.Append("WebKeyWord=@WebKeyWord,");
            strSql.Append("description=@description,");
            strSql.Append("RoseID=@RoseID,");
            strSql.Append("UserName=@UserName");
            strSql.Append(" where UserName=@UserName and RoseID =@RoseID");
            SqlParameter[] parameters = {
					new SqlParameter("@WebTitle", SqlDbType.NVarChar),
					new SqlParameter("@WebKeyWord", SqlDbType.NVarChar),
					new SqlParameter("@description", SqlDbType.NVarChar),
					new SqlParameter("@RoseID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.WebTitle;
            parameters[1].Value = model.WebKeyWord;
            parameters[2].Value = model.description;
            parameters[3].Value = model.RoseID;
            parameters[4].Value = model.UserName;

            crm.ExecuteSqls(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KeyWords ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            crm.ExecuteSqls(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KeyWords GetModel(int RoseId,string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,WebTitle,WebKeyWord,description,RoseID,UserName from KeyWords ");
            strSql.Append(" where RoseId=@RoseId and UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@RoseId", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50)
            };
            parameters[0].Value = RoseId;
            parameters[1].Value = UserName;
            KeyWords model = new KeyWords();
            DataSet ds = crm.Querys(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.WebTitle = ds.Tables[0].Rows[0]["WebTitle"].ToString();
                model.WebKeyWord = ds.Tables[0].Rows[0]["WebKeyWord"].ToString();
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                if (ds.Tables[0].Rows[0]["RoseID"].ToString() != "")
                {
                    model.RoseID = int.Parse(ds.Tables[0].Rows[0]["RoseID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
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
            strSql.Append("select Id,WebTitle,WebKeyWord,description,RoseID,UserName ");
            strSql.Append(" FROM KeyWords ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return crm.Querys(strSql.ToString());
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
            strSql.Append(" Id,WebTitle,WebKeyWord,description,RoseID,UserName ");
            strSql.Append(" FROM KeyWords ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return crm.Querys(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "KeyWords";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

