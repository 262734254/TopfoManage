using System;
using System.Data;
using System.Text;
using GZS.Model.Invest;
using System.Data.SqlClient;
namespace GZS.DAL.Invest
{
	/// <summary>
	/// 数据访问类:InvestCost
	/// </summary>
	public class InvestCostDAL
	{
		public InvestCostDAL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Costid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from InvestCost");
			strSql.Append(" where Costid=@Costid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Costid", SqlDbType.Int,4)};
			parameters[0].Value = Costid;

			return DBHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 根据用户名查找是否有记录数
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistsName(string loginName)
        {

            string sql = "select count(loginname) as loginname from dbo.InvestCost where loginname='" + loginName + "'";
            DataSet ds = DBHelper.Query(sql);
            if (int.Parse(ds.Tables[0].Rows[0]["loginname"].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(GZS.Model.Invest.InvestCostM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into InvestCost(");
			strSql.Append("loginName,Chineseintroduced,Englishintroduction,createdate,hits)");
			strSql.Append(" values (");
			strSql.Append("@loginName,@Chineseintroduced,@Englishintroduction,getdate(),@hits)");
			SqlParameter[] parameters = {
					//new SqlParameter("@Costid", SqlDbType.Int,4),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@Chineseintroduced", SqlDbType.NVarChar),
					new SqlParameter("@Englishintroduction", SqlDbType.NVarChar),
					//new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@hits", SqlDbType.Int,4)};
			//parameters[0].Value = model.Costid;
			parameters[0].Value = model.loginName;
			parameters[1].Value = model.Chineseintroduced;
			parameters[2].Value = model.Englishintroduction;
			//parameters[4].Value = model.createdate;
			parameters[3].Value = model.hits;
            object obj = DBHelper.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Update(GZS.Model.Invest.InvestCostM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update InvestCost set ");
			strSql.Append("loginName=@loginName,");
			strSql.Append("Chineseintroduced=@Chineseintroduced,");
			strSql.Append("Englishintroduction=@Englishintroduction,");
			//strSql.Append("createdate=@createdate,");
			strSql.Append("hits=@hits");
			strSql.Append(" where Costid=@Costid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Costid", SqlDbType.Int,4),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@Chineseintroduced", SqlDbType.NVarChar),
					new SqlParameter("@Englishintroduction", SqlDbType.NVarChar),
					//new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@hits", SqlDbType.Int,4)};
			parameters[0].Value = model.Costid;
			parameters[1].Value = model.loginName;
			parameters[2].Value = model.Chineseintroduced;
			parameters[3].Value = model.Englishintroduction;
			//parameters[4].Value = model.createdate;
			parameters[4].Value = model.hits;

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
		public bool Delete(int Costid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from InvestCost ");
			strSql.Append(" where Costid=@Costid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Costid", SqlDbType.Int,4)};
			parameters[0].Value = Costid;

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
		public bool DeleteList(string Costidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from InvestCost ");
			strSql.Append(" where Costid in ("+Costidlist + ")  ");
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
        public GZS.Model.Invest.InvestCostM GetModels(string loginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Costid,loginName,Chineseintroduced,Englishintroduction,createdate,hits from InvestCost ");
            strSql.Append(" where loginName=@loginName ");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50)};
            parameters[0].Value = loginName;

            GZS.Model.Invest.InvestCostM model = new GZS.Model.Invest.InvestCostM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Costid"].ToString() != "")
                {
                    model.Costid = int.Parse(ds.Tables[0].Rows[0]["Costid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(ds.Tables[0].Rows[0]["createdate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hits"].ToString() != "")
                {
                    model.hits = int.Parse(ds.Tables[0].Rows[0]["hits"].ToString());
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
		public GZS.Model.Invest.InvestCostM GetModel(int Costid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Costid,loginName,Chineseintroduced,Englishintroduction,createdate,hits from InvestCost ");
			strSql.Append(" where Costid=@Costid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Costid", SqlDbType.Int,4)};
			parameters[0].Value = Costid;

			GZS.Model.Invest.InvestCostM model=new GZS.Model.Invest.InvestCostM();
			DataSet ds=DBHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Costid"].ToString()!="")
				{
					model.Costid=int.Parse(ds.Tables[0].Rows[0]["Costid"].ToString());
				}
				model.loginName=ds.Tables[0].Rows[0]["loginName"].ToString();
				model.Chineseintroduced=ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
				model.Englishintroduction=ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
				if(ds.Tables[0].Rows[0]["createdate"].ToString()!="")
				{
					model.createdate=DateTime.Parse(ds.Tables[0].Rows[0]["createdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["hits"].ToString()!="")
				{
					model.hits=int.Parse(ds.Tables[0].Rows[0]["hits"].ToString());
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
			strSql.Append("select Costid,loginName,Chineseintroduced,Englishintroduction,createdate,hits ");
			strSql.Append(" FROM InvestCost ");
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
			strSql.Append(" Costid,loginName,Chineseintroduced,Englishintroduction,createdate,hits ");
			strSql.Append(" FROM InvestCost ");
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
			parameters[0].Value = "InvestCost";
			parameters[1].Value = "Costid";
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

