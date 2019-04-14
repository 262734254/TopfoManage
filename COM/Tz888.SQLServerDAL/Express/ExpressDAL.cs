using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Tz888.Model.Express;
using Tz888.DBUtility;
using System.Data;
using Tz888.IDAL.Express;
namespace Tz888.SQLServerDAL.Express
{
   public class ExpressDAL:ExpressIDAL
    {
       public int Add(ExpressModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ExpressTab(");
			strSql.Append("express,Expressdata,recommend)");
			strSql.Append(" values (");
			strSql.Append("@express,@Expressdata,@recommend)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@express", SqlDbType.NVarChar,3000),
					new SqlParameter("@Expressdata", SqlDbType.DateTime),
					new SqlParameter("@recommend", SqlDbType.Int,4)};
			parameters[0].Value = model.express;
			parameters[1].Value = model.Expressdata;
			parameters[2].Value = model.recommend;

			object obj = DBHelper.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(ExpressModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ExpressTab set ");
			strSql.Append("express=@express,");
			strSql.Append("Expressdata=@Expressdata,");
			strSql.Append("recommend=@recommend");
			strSql.Append(" where expressID=@expressID");
			SqlParameter[] parameters = {
					new SqlParameter("@expressID", SqlDbType.Int,4),
					new SqlParameter("@express", SqlDbType.NVarChar,3000),
					new SqlParameter("@Expressdata", SqlDbType.DateTime),
					new SqlParameter("@recommend", SqlDbType.Int,4)};
			parameters[0].Value = model.expressID;
			parameters[1].Value = model.express;
			parameters[2].Value = model.Expressdata;
			parameters[3].Value = model.recommend;

			int rows=DBHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int expressID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ExpressTab ");
			strSql.Append(" where expressID=@expressID");
			SqlParameter[] parameters = {
					new SqlParameter("@expressID", SqlDbType.Int,4)
};
			parameters[0].Value = expressID;

			int rows=DBHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string expressIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ExpressTab ");
			strSql.Append(" where expressID in ("+expressIDlist + ")  ");
			int rows=DBHelper.ExecuteSql(strSql.ToString());
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
		public ExpressModel GetModel(int expressID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 expressID,express,Expressdata,recommend from ExpressTab ");
			strSql.Append(" where expressID=@expressID");
			SqlParameter[] parameters = {
					new SqlParameter("@expressID", SqlDbType.Int,4)
};
			parameters[0].Value = expressID;

			ExpressModel model=new ExpressModel();
			DataSet ds=DBHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["expressID"].ToString()!="")
				{
					model.expressID=int.Parse(ds.Tables[0].Rows[0]["expressID"].ToString());
				}
				model.express=ds.Tables[0].Rows[0]["express"].ToString();
				if(ds.Tables[0].Rows[0]["Expressdata"].ToString()!="")
				{
					model.Expressdata=DateTime.Parse(ds.Tables[0].Rows[0]["Expressdata"].ToString());
				}
				if(ds.Tables[0].Rows[0]["recommend"].ToString()!="")
				{
					model.recommend=int.Parse(ds.Tables[0].Rows[0]["recommend"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select expressID,express,Expressdata,recommend ");
			strSql.Append(" FROM ExpressTab ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DBHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" expressID,express,Expressdata,recommend ");
			strSql.Append(" FROM ExpressTab ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.Query(strSql.ToString());
		}
        /// <summary>
        /// 用TOPFOCRM数据库
        /// </summary>
        /// <param name="TableViewName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="SelectStr">查询字段</param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">总记录</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = TableViewName;
            parameters[1].Value = Key;
            parameters[2].Value = SelectStr;
            parameters[3].Value = Criteria;
            parameters[4].Value = Sort;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;
            //parameters[7].Value = 1;

            DataSet ds = Tz888.DBUtility.DBHelper.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }


	
    }
}
