using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL.dp;
using Maticsoft.DBUtility;//请先添加引用
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.dp
{
    /// <summary>
    /// 数据访问类System。
    /// </summary>
    public class System : ISystem
    {
        CrmDBHelper crm = new CrmDBHelper();
        public System()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string EmployeeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from System");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar)};
            parameters[0].Value = EmployeeID;

            return crm.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.dp.System model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into System(EmployeeID,");
            strSql.Append("Tem)");
            strSql.Append(" values (");
            strSql.Append("@EmployeeID,@Tem)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@EmployeeID", SqlDbType.VarChar,50),
					new SqlParameter("@Tem", SqlDbType.VarChar,100)};
            parameters[0].Value = model.EmployeeID;
            parameters[1].Value = model.Tem;

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
        public bool Update(Tz888.Model.dp.System model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update System set ");
            strSql.Append("Tem=@Tem");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar),
					new SqlParameter("@Tem", SqlDbType.VarChar,100)};
            parameters[0].Value = model.EmployeeID;
            parameters[1].Value = model.Tem;

            if (crm.ExecuteSqls(strSql.ToString(), parameters) > 0)
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
        public void Delete(string EmployeeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from System ");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar)};
            parameters[0].Value = EmployeeID;

            crm.ExecuteSqls(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.dp.System GetModel(string EmployeeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 EmployeeID,Tem from System ");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.NVarChar)};
            parameters[0].Value = EmployeeID;

            Tz888.Model.dp.System model = new Tz888.Model.dp.System();
            DataSet ds = crm.Querys(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID =ds.Tables[0].Rows[0]["EmployeeID"].ToString();
                }
                model.Tem = ds.Tables[0].Rows[0]["Tem"].ToString();
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
            strSql.Append("select EmployeeID,Tem ");
            strSql.Append(" FROM System ");
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
            strSql.Append(" EmployeeID,Tem ");
            strSql.Append(" FROM System ");
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
            parameters[0].Value = "System";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return crm.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

