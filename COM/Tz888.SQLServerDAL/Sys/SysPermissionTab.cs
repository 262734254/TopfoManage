using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL.Sys;
using Maticsoft.DBUtility;//请先添加引用
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Sys
{
    /// <summary>
    /// 数据访问类SysPermissionTab。
    /// </summary>
    public class SysPermissionTab : ISysPermissionTab
    {
        public SysPermissionTab()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SPID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysPermissionTab");
            strSql.Append(" where SPID=@SPID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPID", SqlDbType.Int,4)};
            parameters[0].Value = SPID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Sys.SysPermissionTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysPermissionTab(");
            strSql.Append("RoleID,SPCode,SPDate)");
            strSql.Append(" values (");
            strSql.Append("@RoleID,@SPCode,@SPDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@SPCode", SqlDbType.VarChar,2000),
					new SqlParameter("@SPDate", SqlDbType.DateTime)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.SPCode;
            parameters[2].Value = model.SPDate;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Tz888.Model.Sys.SysPermissionTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysPermissionTab set ");
            strSql.Append("RoleID=@RoleID,");
            strSql.Append("SPCode=@SPCode");
            //strSql.Append("SPDate=@SPDate");
            strSql.Append(" where SPID=@SPID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@SPCode", SqlDbType.VarChar,2000)
					//new SqlParameter("@SPDate", SqlDbType.DateTime)
        };
            parameters[0].Value = model.SPID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.SPCode;
            //parameters[4].Value = model.SPDate;

          int a= DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
          if (a>0)
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
        public void Delete(int SPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysPermissionTab ");
            strSql.Append(" where SPID=@SPID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPID", SqlDbType.Int,4)};
            parameters[0].Value = SPID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Sys.SysPermissionTab GetModel(int SPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SPID,RoleID,SPCode,SPDate from SysPermissionTab ");
            strSql.Append(" where SPID=@SPID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPID", SqlDbType.Int,4)};
            parameters[0].Value = SPID;

            Tz888.Model.Sys.SysPermissionTab model = new Tz888.Model.Sys.SysPermissionTab();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SPID"].ToString() != "")
                {
                    model.SPID = int.Parse(ds.Tables[0].Rows[0]["SPID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SysID"].ToString() != "")
                {
                    model.SysID = int.Parse(ds.Tables[0].Rows[0]["SysID"].ToString());
                }
                model.SPCode = ds.Tables[0].Rows[0]["SPCode"].ToString();
                if (ds.Tables[0].Rows[0]["SPDate"].ToString() != "")
                {
                    model.SPDate = DateTime.Parse(ds.Tables[0].Rows[0]["SPDate"].ToString());
                }
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
            strSql.Append("select * ");
            strSql.Append(" FROM SysPermissionTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" SPID,RoleID,SPCode,SPDate ");
            strSql.Append(" FROM SysPermissionTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "SysPermissionTab";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        public Tz888.Model.Sys.SysPermissionTab GetModel1(int roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SPID,RoleID,SPCode,SPDate from SysPermissionTab ");
            strSql.Append(" where RoleID=@roleid ");
            SqlParameter[] parameters = {
					new SqlParameter("@roleid", SqlDbType.Int,4)};
            parameters[0].Value = roleid;
            Tz888.Model.Sys.SysPermissionTab model = new Tz888.Model.Sys.SysPermissionTab();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SPID"].ToString() != "")
                {
                    model.SPID = int.Parse(ds.Tables[0].Rows[0]["SPID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                model.SPCode = ds.Tables[0].Rows[0]["SPCode"].ToString();
                if (ds.Tables[0].Rows[0]["SPDate"].ToString() != "")
                {
                    model.SPDate = DateTime.Parse(ds.Tables[0].Rows[0]["SPDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}

