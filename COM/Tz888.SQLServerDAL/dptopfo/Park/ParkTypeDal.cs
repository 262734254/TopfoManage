using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GZS.Model.Park;
namespace GZS.DAL.Park
{
    public class ParkTypeDal
    {
        #region
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ParkTypeM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ParktypeTab(");
            strSql.Append("parktypename,tzParId)");
			strSql.Append(" values (");
            strSql.Append("@parktypename,@tzParId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@parktypename", SqlDbType.VarChar,50),
            new SqlParameter("@tzParId", SqlDbType.Int,4)};
			parameters[0].Value = model.parktypename;
            parameters[0].Value = model.tzParId;
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
		public bool Update(ParkTypeM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ParktypeTab set ");
            strSql.Append("parktypename=@parktypename,tzParId=@tzParId");
			strSql.Append(" where parktypeid=@parktypeid");
			SqlParameter[] parameters = {
					new SqlParameter("@parktypeid", SqlDbType.Int,4),
					new SqlParameter("@parktypename", SqlDbType.VarChar,50),
            new SqlParameter("@tzParId", SqlDbType.Int,4)};
			parameters[0].Value = model.parktypeid;
			parameters[1].Value = model.parktypename;

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
		public bool Delete(int parktypeid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ParktypeTab ");
			strSql.Append(" where parktypeid=@parktypeid");
			SqlParameter[] parameters = {
					new SqlParameter("@parktypeid", SqlDbType.Int,4)
};
			parameters[0].Value = parktypeid;

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
		public bool DeleteList(string parktypeidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ParktypeTab ");
			strSql.Append(" where parktypeid in ("+parktypeidlist + ")  ");
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
		public ParkTypeM GetModel(int parktypeid)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 parktypeid,tzParId,parktypename from ParktypeTab ");
			strSql.Append(" where parktypeid=@parktypeid");
			SqlParameter[] parameters = {
					new SqlParameter("@parktypeid", SqlDbType.Int,4)
};
			parameters[0].Value = parktypeid;

			ParkTypeM model=new ParkTypeM();
			DataSet ds=DBHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["parktypeid"].ToString()!="")
				{
					model.parktypeid=int.Parse(ds.Tables[0].Rows[0]["parktypeid"].ToString());
				}
                model.tzParId = int.Parse(ds.Tables[0].Rows[0]["tzParId"].ToString());
				model.parktypename=ds.Tables[0].Rows[0]["parktypename"].ToString();
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
            strSql.Append("select parktypeid,parktypename,tzParId ");
			strSql.Append(" FROM ParktypeTab ");
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
            strSql.Append(" parktypeid,parktypename,tzParId ");
			strSql.Append(" FROM ParktypeTab ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.Query(strSql.ToString());
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
			parameters[0].Value = "ParktypeTab";
			parameters[1].Value = "parktypeid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
    }
}
