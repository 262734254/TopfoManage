using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Invest;
using System.Data;
using System.Data.SqlClient;
namespace GZS.DAL.Invest
{
    public class TzchildTypDAL
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TzchildTypeM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tzchildType(");
            strSql.Append("loginName,tztypeid,typeprice,tzchildName,createTime)");
            strSql.Append(" values (");
            strSql.Append("@loginName,@tztypeid,@typeprice,@tzchildName,getdate())");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@tztypeid", SqlDbType.Int,4),
					new SqlParameter("@typeprice", SqlDbType.Decimal,9),
					new SqlParameter("@tzchildName", SqlDbType.VarChar,120)
					//new SqlParameter("@createTime", SqlDbType.DateTime)
            };
            parameters[0].Value = model.loginName;
            parameters[1].Value = model.tztypeid;
            parameters[2].Value = model.typeprice;
            parameters[3].Value = model.tzchildName;
            //parameters[4].Value = model.createTime;

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
        public bool Update(TzchildTypeM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tzchildType set ");
            strSql.Append("loginName=@loginName,");
            strSql.Append("tztypeid=@tztypeid,");
            strSql.Append("typeprice=@typeprice,");
            strSql.Append("tzchildName=@tzchildName");
            //strSql.Append("createTime=@createTime");
            strSql.Append(" where typeid=@typeid");
            SqlParameter[] parameters = {
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@tztypeid", SqlDbType.Int,4),
					new SqlParameter("@typeprice", SqlDbType.Decimal,9),
					new SqlParameter("@tzchildName", SqlDbType.VarChar,120)
					//new SqlParameter("@createTime", SqlDbType.DateTime)
            };
            parameters[0].Value = model.typeid;
            parameters[1].Value = model.loginName;
            parameters[2].Value = model.tztypeid;
            parameters[3].Value = model.typeprice;
            parameters[4].Value = model.tzchildName;
            //parameters[5].Value = model.createTime;

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
        public bool Delete(int typeid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tzchildType ");
            strSql.Append(" where typeid=@typeid");
            SqlParameter[] parameters = {
					new SqlParameter("@typeid", SqlDbType.Int,4)
};
            parameters[0].Value = typeid;

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
        public bool DeleteList(string typeidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tzchildType ");
            strSql.Append(" where typeid in (" + typeidlist + ")  ");
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
        public TzchildTypeM GetModels(int typeid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 typeid,loginName,tztypeid,typeprice,tzchildName,createTime from tzchildType ");
            strSql.Append(" where tztypeid=@typeid");
            SqlParameter[] parameters = {
					new SqlParameter("@typeid", SqlDbType.Int,4)
};
            parameters[0].Value = typeid;

            TzchildTypeM model = new TzchildTypeM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["typeid"].ToString() != "")
                {
                    model.typeid = int.Parse(ds.Tables[0].Rows[0]["typeid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                if (ds.Tables[0].Rows[0]["tztypeid"].ToString() != "")
                {
                    model.tztypeid = int.Parse(ds.Tables[0].Rows[0]["tztypeid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["typeprice"].ToString() != "")
                {
                    model.typeprice = decimal.Parse(ds.Tables[0].Rows[0]["typeprice"].ToString());
                }
                model.tzchildName = ds.Tables[0].Rows[0]["tzchildName"].ToString();
                if (ds.Tables[0].Rows[0]["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public int ExistsByInvestTypeId(int tzTypeId, string loginName)
        {
            string sql = "select count(tzTypeId) as typeID from tzchildType where tzTypeId=" + tzTypeId + " and loginname='" + loginName + "'";
            return int.Parse(DBHelper.Query(sql).Tables[0].Rows[0]["typeID"].ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TzchildTypeM GetModel(int tztypeid, string loginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 typeid,loginName,tztypeid,typeprice,tzchildName,createTime from tzchildType ");
            strSql.Append(" where tztypeid=@tztypeid and loginName=@loginName");
            SqlParameter[] parameters = {
					new SqlParameter("@tztypeid", SqlDbType.Int,4),
                new SqlParameter("@loginName", SqlDbType.VarChar,50)
};
            parameters[0].Value = tztypeid;
            parameters[1].Value = loginName;
            TzchildTypeM model = new TzchildTypeM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["typeid"].ToString() != "")
                {
                    model.typeid = int.Parse(ds.Tables[0].Rows[0]["typeid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                if (ds.Tables[0].Rows[0]["tztypeid"].ToString() != "")
                {
                    model.tztypeid = int.Parse(ds.Tables[0].Rows[0]["tztypeid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["typeprice"].ToString() != "")
                {
                    model.typeprice = decimal.Parse(ds.Tables[0].Rows[0]["typeprice"].ToString());
                }
                model.tzchildName = ds.Tables[0].Rows[0]["tzchildName"].ToString();
                if (ds.Tables[0].Rows[0]["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TzchildTypeM GetModel(int typeid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 typeid,loginName,tztypeid,typeprice,tzchildName,createTime from tzchildType ");
            strSql.Append(" where typeid=@typeid");
            SqlParameter[] parameters = {
					new SqlParameter("@typeid", SqlDbType.Int,4)
};
            parameters[0].Value = typeid;

            TzchildTypeM model = new TzchildTypeM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["typeid"].ToString() != "")
                {
                    model.typeid = int.Parse(ds.Tables[0].Rows[0]["typeid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                if (ds.Tables[0].Rows[0]["tztypeid"].ToString() != "")
                {
                    model.tztypeid = int.Parse(ds.Tables[0].Rows[0]["tztypeid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["typeprice"].ToString() != "")
                {
                    model.typeprice = decimal.Parse(ds.Tables[0].Rows[0]["typeprice"].ToString());
                }
                model.tzchildName = ds.Tables[0].Rows[0]["tzchildName"].ToString();
                if (ds.Tables[0].Rows[0]["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
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
            strSql.Append("select typeid,loginName,tztypeid,typeprice,tzchildName,createTime ");
            strSql.Append(" FROM tzchildType ");
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
            strSql.Append(" typeid,loginName,tztypeid,typeprice,tzchildName,createTime ");
            strSql.Append(" FROM tzchildType ");
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
