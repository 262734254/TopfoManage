using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace GZS.DAL.Menu
{
	/// <summary>
	/// 数据访问类:SystemTemTab
	/// </summary>
	public class SystemTemTabDAL
	{
		public SystemTemTabDAL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SystemTemTab");
			strSql.Append(" where userid=@userid ");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4)};
			parameters[0].Value = userid;

			return DBHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GZS.Model.Menu.SystemTemTabM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SystemTemTab(");
			strSql.Append("levelName,menuCode)");
			strSql.Append(" values (");
			strSql.Append("@levelName,@menuCode)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@levelName", SqlDbType.VarChar,50),
					new SqlParameter("@menuCode", SqlDbType.VarChar,500)};
			parameters[0].Value = model.levelName;
			parameters[1].Value = model.menuCode;

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
		public bool Update(GZS.Model.Menu.SystemTemTabM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SystemTemTab set ");
			strSql.Append("levelName=@levelName,");
			strSql.Append("menuCode=@menuCode");
			strSql.Append(" where userid=@userid");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4),
					new SqlParameter("@levelName", SqlDbType.VarChar,50),
					new SqlParameter("@menuCode", SqlDbType.VarChar,500)};
			parameters[0].Value = model.userid;
			parameters[1].Value = model.levelName;
			parameters[2].Value = model.menuCode;

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
		public bool Delete(int userid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemTemTab ");
			strSql.Append(" where userid=@userid");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4)
};
			parameters[0].Value = userid;

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
		public bool DeleteList(string useridlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SystemTemTab ");
			strSql.Append(" where userid in ("+useridlist + ")  ");
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
        public GZS.Model.Menu.SystemTemTabM GetModels(string userid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 userid,levelName,menuCode from SystemTemTab ");
            strSql.Append(" where levelName=@levelName");
            SqlParameter[] parameters = {
					new SqlParameter("@levelName", SqlDbType.VarChar,50)
};
            parameters[0].Value = userid;

            GZS.Model.Menu.SystemTemTabM model = new GZS.Model.Menu.SystemTemTabM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["userid"].ToString() != "")
                {
                    model.userid = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                }
                model.levelName = ds.Tables[0].Rows[0]["levelName"].ToString();
                model.menuCode = ds.Tables[0].Rows[0]["menuCode"].ToString();
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
		public GZS.Model.Menu.SystemTemTabM GetModel(int userid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 userid,levelName,menuCode from SystemTemTab ");
			strSql.Append(" where userid=@userid");
			SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4)
};
			parameters[0].Value = userid;

			GZS.Model.Menu.SystemTemTabM model=new GZS.Model.Menu.SystemTemTabM();
			DataSet ds=DBHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["userid"].ToString()!="")
				{
					model.userid=int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
				}
				model.levelName=ds.Tables[0].Rows[0]["levelName"].ToString();
				model.menuCode=ds.Tables[0].Rows[0]["menuCode"].ToString();
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
			strSql.Append("select userid,levelName,menuCode ");
			strSql.Append(" FROM SystemTemTab ");
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
			strSql.Append(" userid,levelName,menuCode ");
			strSql.Append(" FROM SystemTemTab ");
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
			parameters[0].Value = "SystemTemTab";
			parameters[1].Value = "userid";
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

