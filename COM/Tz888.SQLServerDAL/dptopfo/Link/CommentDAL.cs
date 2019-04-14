using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GZS.Model.Link;
using GZS.DAL;//Please add references

namespace GZS.DAL.Link
{
	/// <summary>
	/// 数据访问类:CommentDAL
	/// </summary>
	public class CommentDAL
	{
		public CommentDAL()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CommentM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CommentTab(");
            strSql.Append("description,CommDate,SendName,LinkMode,LinkName)");
			strSql.Append(" values (");
            strSql.Append("@description,getdate(),@SendName,@LinkMode,@LinkName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@description", SqlDbType.NVarChar,1500),
					//new SqlParameter("@CommDate", SqlDbType.DateTime),
					new SqlParameter("@SendName", SqlDbType.VarChar,50),
					new SqlParameter("@LinkMode", SqlDbType.VarChar,50),
                new SqlParameter("@LinkName", SqlDbType.VarChar,50)

            };
			parameters[0].Value = model.description;
			//parameters[1].Value = model.CommDate;
			parameters[1].Value = model.SendName;
			parameters[2].Value = model.LinkMode;
            parameters[3].Value = model.LinkName;
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
		public bool Update(CommentM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CommentTab set ");
			strSql.Append("description=@description,");
            strSql.Append("LinkName=@LinkName,");
			strSql.Append("SendName=@SendName,");
			strSql.Append("LinkMode=@LinkMode");
			strSql.Append(" where CommentId=@CommentId");
			SqlParameter[] parameters = {
					new SqlParameter("@CommentId", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.NVarChar,1500),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@SendName", SqlDbType.VarChar,50),
					new SqlParameter("@LinkMode", SqlDbType.VarChar,50)};
			parameters[0].Value = model.CommentId;
			parameters[1].Value = model.description;
			parameters[2].Value = model.CommDate;
			parameters[3].Value = model.SendName;
			parameters[4].Value = model.LinkMode;

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
		public bool Delete(int CommentId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CommentTab ");
			strSql.Append(" where CommentId=@CommentId");
			SqlParameter[] parameters = {
					new SqlParameter("@CommentId", SqlDbType.Int,4)
};
			parameters[0].Value = CommentId;

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
		public bool DeleteList(string CommentIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CommentTab ");
			strSql.Append(" where CommentId in ("+CommentIdlist + ")  ");
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
		public CommentM GetModel(int CommentId)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 CommentId,description,LinkName,CommDate,SendName,LinkMode from CommentTab ");
			strSql.Append(" where CommentId=@CommentId");
			SqlParameter[] parameters = {
					new SqlParameter("@CommentId", SqlDbType.Int,4)
};
			parameters[0].Value = CommentId;

			CommentM model=new CommentM();
			DataSet ds=DBHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CommentId"].ToString()!="")
				{
					model.CommentId=int.Parse(ds.Tables[0].Rows[0]["CommentId"].ToString());
				}
				model.description=ds.Tables[0].Rows[0]["description"].ToString();
				if(ds.Tables[0].Rows[0]["CommDate"].ToString()!="")
				{
					model.CommDate=DateTime.Parse(ds.Tables[0].Rows[0]["CommDate"].ToString());
				}
				model.SendName=ds.Tables[0].Rows[0]["SendName"].ToString();
				model.LinkMode=ds.Tables[0].Rows[0]["LinkMode"].ToString();
                model.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();
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
            strSql.Append("select CommentId,description,LinkName,CommDate,SendName,LinkMode ");
			strSql.Append(" FROM CommentTab ");
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
            strSql.Append(" CommentId,description,CommDate,LinkName,SendName,LinkMode ");
			strSql.Append(" FROM CommentTab ");
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
			parameters[0].Value = "CommentTab";
			parameters[1].Value = "CommentId";
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

