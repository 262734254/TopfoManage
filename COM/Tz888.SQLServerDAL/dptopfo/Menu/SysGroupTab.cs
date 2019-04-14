using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GZS.Model.Menu;
using Tz888.DBUtility;

namespace GZS.DAL.Menu
{
    /// <summary>
    /// 数据访问类SysGroupTab。
    /// </summary>
    public class SysGroupTab
    {
        public SysGroupTab()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysGroupTab");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)};
            parameters[0].Value = SID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GZS.Model.Menu.SysGroupTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysGroupTab(");
            strSql.Append("SRoleID,SName,SysCheck,SysDate,EmployeeID,SDescribe)");
            strSql.Append(" values (");
            strSql.Append("@RoleID,@SName,@SysCheck,@SysDate,@EmployeeID,@SDescribe)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@SName", SqlDbType.VarChar,100),
					new SqlParameter("@SysCheck", SqlDbType.Int,4),
					new SqlParameter("@SysDate", SqlDbType.DateTime),
                    new SqlParameter("@EmployeeID", SqlDbType.VarChar,100),
                    new SqlParameter("@sdescribe", SqlDbType.VarChar,100)
            };
            parameters[0].Value = model.SRoleID;
            parameters[1].Value = model.SName;
            parameters[2].Value = model.SysCheck;
            parameters[3].Value = model.SysDate;
            parameters[4].Value = model.EmployeeID;
            parameters[5].Value = model.SDescribe;
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
        public void Update(GZS.Model.Menu.SysGroupTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysGroupTab set ");
            strSql.Append("SRoleID=@RoleID,");
            strSql.Append("SName=@SName,");
            strSql.Append("SysCheck=@SysCheck,");
            strSql.Append("SysDate=@SysDate,");
            strSql.Append("EmployeeID=@EmployeeID,");
            strSql.Append("sdescribe=@sdescribe");
            strSql.Append(" where SGID=@SID ");

            
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@SName", SqlDbType.VarChar,100),
					new SqlParameter("@SysCheck", SqlDbType.Int,4),
					new SqlParameter("@SysDate", SqlDbType.DateTime),
                    new SqlParameter("@EmployeeID", SqlDbType.VarChar,100),
                    new SqlParameter("@sdescribe", SqlDbType.VarChar,100)
            };
            parameters[0].Value = model.SGID;
            parameters[1].Value = model.SRoleID;
            parameters[2].Value = model.SName;
            parameters[3].Value = model.SysCheck;
            parameters[4].Value = model.SysDate;
            parameters[5].Value = model.EmployeeID;
            parameters[6].Value = model.SDescribe;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int SID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysGroupTab ");
            strSql.Append(" where SGID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)};
            parameters[0].Value = SID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 审核一个组
        /// </summary>
        /// <param name="SRoleID"></param>
        public void Check(int SGID)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update SysGroupTab set");
            strsql.Append(" SysCheck=@SysCheck");
            strsql.Append(" where SGID=@SGID");
            SqlParameter[] para ={ 
            new SqlParameter("@SysCheck",SqlDbType.Int,4),
            new SqlParameter("@SGID",SqlDbType.Int, 8)
            
            };
            para[0].Value = 1;
            para[1].Value = SGID;
            DbHelperSQL.ExecuteSql(strsql.ToString(), para);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GZS.Model.Menu.SysGroupTab GetModel(int SGID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SGID,SRoleID,EmployeeID,SName,Sdescribe,SysCheck,SysDate from SysGroupTab ");
            strSql.Append(" where SGID=@SID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)};
            parameters[0].Value = SGID;

            GZS.Model.Menu.SysGroupTab model = new GZS.Model.Menu.SysGroupTab();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SGID"].ToString() != "")
                {
                    model.SID = int.Parse(ds.Tables[0].Rows[0]["SGID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SRoleID"].ToString() != "")
                {
                    model.SRoleID = ds.Tables[0].Rows[0]["SRoleID"].ToString();
                }
                model.SName = ds.Tables[0].Rows[0]["SName"].ToString();
                if (ds.Tables[0].Rows[0]["SysCheck"].ToString() != "")
                {
                    model.SysCheck = int.Parse(ds.Tables[0].Rows[0]["SysCheck"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SysDate"].ToString() != "")
                {
                    model.SysDate = DateTime.Parse(ds.Tables[0].Rows[0]["SysDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SDescribe"].ToString() != "")
                {
                    model.SDescribe = ds.Tables[0].Rows[0]["SDescribe"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
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
            strSql.Append("select SGID,SRoleID,SName,SysCheck,SysDate ");
            strSql.Append(" FROM SysGroupTab ");
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
            strSql.Append(" SGID,SRoleID,SName,SysCheck,SysDate ");
            strSql.Append(" FROM SysGroupTab ");
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
            parameters[0].Value = "SysGroupTab";
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

