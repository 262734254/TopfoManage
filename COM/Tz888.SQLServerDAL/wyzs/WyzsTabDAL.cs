using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL.wyzs
{
	/// <summary>
	/// 数据访问类:WyzsTabDAL
	/// </summary>
	public partial class WyzsTabDAL
	{
		public WyzsTabDAL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WyzsTab");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelper.Exists(strSql.ToString(),parameters);
		}

        
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Tz888.Model.wyzs.WyzsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WyzsTab(");
            strSql.Append("title,typeid,type,htmlurl,orderid,pageAddress,status,imgPath,descript)");
			strSql.Append(" values (");
            strSql.Append("@title,@typeid,@type,@htmlurl,@orderid,@pageAddress,@status,@imgPath,@descript)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@htmlurl", SqlDbType.VarChar,100),
					new SqlParameter("@orderid", SqlDbType.Int,4),
            new SqlParameter("@pageAddress", SqlDbType.Int,4),
            new SqlParameter("@status", SqlDbType.VarChar,50) ,
            new SqlParameter("@imgPath", SqlDbType.VarChar,50),
             new SqlParameter("@descript", SqlDbType.Text)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.typeid;
			parameters[2].Value = model.type;
			parameters[3].Value = model.htmlurl;
			parameters[4].Value = model.orderid;
            parameters[5].Value = model.pageAddress;
            parameters[6].Value = model.status;
            parameters[7].Value = model.imgPath;
            parameters[8].Value = model.descript;
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
		public bool Update(Tz888.Model.wyzs.WyzsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WyzsTab set ");
			strSql.Append("title=@title,");
			strSql.Append("typeid=@typeid,");
			strSql.Append("type=@type,");
			strSql.Append("htmlurl=@htmlurl,");
			strSql.Append("orderid=@orderid,");
            strSql.Append("pageAddress=@pageAddress,");
              strSql.Append("status=@status,");
              strSql.Append("imgPath=@imgPath,");
              strSql.Append("descript=@descript");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@typeid", SqlDbType.Int,4),
					new SqlParameter("@type", SqlDbType.VarChar,50),
					new SqlParameter("@htmlurl", SqlDbType.VarChar,100),
					new SqlParameter("@orderid", SqlDbType.Int,4),
            new SqlParameter("@pageAddress", SqlDbType.Int,4),
            new SqlParameter("@status", SqlDbType.VarChar,50),
            new SqlParameter("@imgPath", SqlDbType.VarChar,50),
             new SqlParameter("@descript", SqlDbType.Text)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.typeid;
			parameters[3].Value = model.type;
			parameters[4].Value = model.htmlurl;
			parameters[5].Value = model.orderid;
            parameters[6].Value = model.pageAddress;
            parameters[7].Value = model.status;
            parameters[8].Value = model.imgPath;
            parameters[9].Value = model.descript;
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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WyzsTab ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WyzsTab ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public Tz888.Model.wyzs.WyzsModel GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,title,pageAddress,typeid,type,htmlurl,orderid,status,imgPath,descript from WyzsTab ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

			Tz888.Model.wyzs.WyzsModel model=new Tz888.Model.wyzs.WyzsModel();
			DataSet ds=DBHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				if(ds.Tables[0].Rows[0]["typeid"].ToString()!="")
				{
					model.typeid=int.Parse(ds.Tables[0].Rows[0]["typeid"].ToString());
				}
				model.type=ds.Tables[0].Rows[0]["type"].ToString();
				model.htmlurl=ds.Tables[0].Rows[0]["htmlurl"].ToString();
                model.imgPath = ds.Tables[0].Rows[0]["imgPath"].ToString();
                model.status = ds.Tables[0].Rows[0]["status"].ToString();
                model.descript = ds.Tables[0].Rows[0]["descript"].ToString();
				if(ds.Tables[0].Rows[0]["orderid"].ToString()!="")
				{
					model.orderid=int.Parse(ds.Tables[0].Rows[0]["orderid"].ToString());
				}
                if (ds.Tables[0].Rows[0]["pageAddress"].ToString() != "")
                {
                    model.pageAddress = int.Parse(ds.Tables[0].Rows[0]["pageAddress"].ToString());
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
            strSql.Append("select id,title,typeid,type,htmlurl,orderid,pageAddress,status,imgPath ");
			strSql.Append(" FROM WyzsTab ");
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
            
            strSql.Append(" id,title,typeid,type,htmlurl,orderid,pageAddress,status,imgPath,descript ");
			strSql.Append(" FROM WyzsTab ");
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
			parameters[0].Value = "WyzsTab";
			parameters[1].Value = "id";
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

