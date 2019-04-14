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
    /// 数据访问类SysRoleTab。
    /// </summary>
    public class SysRoleTab : ISysRoleTab
    {
        public SysRoleTab()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SRoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysRoleTab");
            strSql.Append(" where SRoleID=@SRoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SRoleID", SqlDbType.Int,4)};
            parameters[0].Value = SRoleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Sys.SysRoleTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysRoleTab(");
            strSql.Append("SRName,SRDoc,SysCode,SRDate)");
            strSql.Append(" values (");
            strSql.Append("@SRName,@SRDoc,@SysCode,@SRDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SRName", SqlDbType.VarChar,100),
					new SqlParameter("@SRDoc", SqlDbType.VarChar,200),
					new SqlParameter("@SysCode", SqlDbType.VarChar,100),
					new SqlParameter("@SRDate", SqlDbType.DateTime)};
            parameters[0].Value = model.SRName;
            parameters[1].Value = model.SRDoc;
            parameters[2].Value = model.SysCode;
            parameters[3].Value = model.SRDate;

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
        public void Update(Tz888.Model.Sys.SysRoleTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysRoleTab set ");
            strSql.Append("SRName=@SRName,");
            strSql.Append("SRDoc=@SRDoc,");
            strSql.Append("SysCode=@SysCode,");
            strSql.Append("SRDate=@SRDate");
            strSql.Append(" where SRoleID=@SRoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SRoleID", SqlDbType.Int,4),
					new SqlParameter("@SRName", SqlDbType.VarChar,100),
					new SqlParameter("@SRDoc", SqlDbType.VarChar,200),
					new SqlParameter("@SysCode", SqlDbType.VarChar,100),
					new SqlParameter("@SRDate", SqlDbType.DateTime)};
            parameters[0].Value = model.SRoleID;
            parameters[1].Value = model.SRName;
            parameters[2].Value = model.SRDoc;
            parameters[3].Value = model.SysCode;
            parameters[4].Value = model.SRDate;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 审核一个角色
        /// </summary>
        /// <param name="SRoleID"></param>
        public void Check(int SRoleID)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update SysRoleTab set");
            strsql.Append(" SRCheck=@SRCheck");
            strsql.Append(" where SRoleID=@SRoleID");
            SqlParameter[] para ={ 
             new SqlParameter("@SRCheck",SqlDbType.Int,4),
            new SqlParameter("@SRoleID",SqlDbType.Int, 8)
            
            };
            para[0].Value = 1;
            para[1].Value = SRoleID;
            DbHelperSQL.ExecuteSql(strsql.ToString(), para);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SRoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysRoleTab ");
            strSql.Append(" where SRoleID=@SRoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SRoleID", SqlDbType.Int,4)};
            parameters[0].Value = SRoleID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Sys.SysRoleTab GetModel(int SRoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SRoleID,SRName,SRDoc,SysCode,SRDate from SysRoleTab ");
            strSql.Append(" where SRoleID=@SRoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SRoleID", SqlDbType.Int,4)};
            parameters[0].Value = SRoleID;

            Tz888.Model.Sys.SysRoleTab model = new Tz888.Model.Sys.SysRoleTab();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SRoleID"].ToString() != "")
                {
                    model.SRoleID = int.Parse(ds.Tables[0].Rows[0]["SRoleID"].ToString());
                }
                model.SRName = ds.Tables[0].Rows[0]["SRName"].ToString();
                model.SRDoc = ds.Tables[0].Rows[0]["SRDoc"].ToString();
                model.SysCode = ds.Tables[0].Rows[0]["SysCode"].ToString();
                if (ds.Tables[0].Rows[0]["SRDate"].ToString() != "")
                {
                    model.SRDate = DateTime.Parse(ds.Tables[0].Rows[0]["SRDate"].ToString());
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
            strSql.Append("select SRoleID,SRName,SRDoc,SysCode,SRDate,SRCheck ");
            strSql.Append(" FROM SysRoleTab  order by SRoleID desc");
            if (strWhere.Trim() != "")
            {  
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取通过角色看用户
        /// </summary>
        /// <param name="tem"></param>
        /// <returns></returns>
        public DataSet GetUserList(string tem)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  a.EmployeeName,a.NickName,a.Mobile,a.Email ");
            strSql.Append("from dbo.EmployeeInfoTab  a join system b on  a.LoginName=b.EmployeeID");
            if (tem.Trim() != "")
            {
                strSql.Append(" where  b.Tem='"+tem+"'");
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
            strSql.Append(" SRoleID,SRName,SRDoc,SysCode,SRDate ");
            strSql.Append(" FROM SysRoleTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取所有角色信息
        /// </summary>
        /// <returns></returns>
        public DataSet dvGetAllIndustry()
        {
            string sql = "select * from SysRoleTab order by SRoleID asc ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);

            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds;
        }


        /// <summary>
        /// 根据角色代码获取角色名称
        /// </summary>
        /// <param name="IndustryID">角色代码</param>
        /// <returns></returns>
        public string GetNameByID(string IndustryID)
        {
            SqlParameter para = new SqlParameter("@SRoleID", SqlDbType.Int, 8);
            para.Value = Convert.ToInt16(IndustryID);
            return
                Convert.ToString(Tz888.DBUtility.SqlHelper.ExecuteScalar(Tz888.DBUtility.SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "SetRoleTab_GetNameByID", para));
              
            //以下不用存储过程的方法
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select SRName ");
            //strSql.Append(" FROM SysRoleTab ");
            //if (IndustryID.Trim() != "")
            //{
            //    strSql.Append(" where SRoleID= " + IndustryID);
            //}
            //return DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0][0].ToString();
        
        
        
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
            parameters[0].Value = "SysRoleTab";
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

