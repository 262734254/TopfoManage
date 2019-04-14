using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GZS.Model.Link;
using GZS.DAL;//Please add references
namespace GZS.DAL.Link
{
	/// <summary>
	/// 数据访问类:TZLinkDAL
	/// </summary>
	public class TZLinkDAL
	{
		public TZLinkDAL()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TZLinkM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TZLinkTab(");
            strSql.Append("Name,Tel,Phone,Email,OtherMode,Address,createTime,LoginName,ImageMap)");
			strSql.Append(" values (");
            strSql.Append("@Name,@Tel,@Phone,@Email,@OtherMode,@Address,getdate(),@LoginName,@ImageMap)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@OtherMode", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
                new SqlParameter("@LoginName", SqlDbType.VarChar,50),
                 new SqlParameter("@ImageMap", SqlDbType.VarChar,150)
            
            };
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Tel;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Email;
			parameters[4].Value = model.OtherMode;
			parameters[5].Value = model.Address;
            parameters[6].Value = model.LoginName;
            parameters[7].Value = model.ImageMap;
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
		public bool Update(TZLinkM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TZLinkTab set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("OtherMode=@OtherMode,");
			strSql.Append("Address=@Address,");
            strSql.Append("ImageMap=@ImageMap");
			strSql.Append(" where linkId=@linkId");
			SqlParameter[] parameters = {
					new SqlParameter("@linkId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@OtherMode", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@ImageMap", SqlDbType.VarChar,150)
            };
			parameters[0].Value = model.linkId;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Tel;
			parameters[3].Value = model.Phone;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.OtherMode;
			parameters[6].Value = model.Address;
			parameters[7].Value = model.ImageMap;

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
        public bool ExistsName(string loginName)
        {

            string sql = "select count(loginname) as loginname from TZLinkTab where loginname='" + loginName + "'";
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int linkId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TZLinkTab ");
			strSql.Append(" where linkId=@linkId");
			SqlParameter[] parameters = {
					new SqlParameter("@linkId", SqlDbType.Int,4)
};
			parameters[0].Value = linkId;

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
		public bool DeleteList(string linkIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TZLinkTab ");
			strSql.Append(" where linkId in ("+linkIdlist + ")  ");
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
        public TZLinkM GetModelByLoginName(string loginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 linkId,Name,LoginName,ImageMap,Tel,Phone,Email,OtherMode,Address,createTime from TZLinkTab ");
            strSql.Append(" where loginName=@loginName");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50)
};
            parameters[0].Value = loginName;

            TZLinkM model = new TZLinkM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["linkId"].ToString() != "")
                {
                    model.linkId = int.Parse(ds.Tables[0].Rows[0]["linkId"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.OtherMode = ds.Tables[0].Rows[0]["OtherMode"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.ImageMap = ds.Tables[0].Rows[0]["ImageMap"].ToString();
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
		public TZLinkM GetModel(int linkId)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 linkId,Name,LoginName,Tel,Phone,Email,OtherMode,Address,createTime from TZLinkTab ");
			strSql.Append(" where linkId=@linkId");
			SqlParameter[] parameters = {
					new SqlParameter("@linkId", SqlDbType.Int,4)
};
			parameters[0].Value = linkId;

			TZLinkM model=new TZLinkM();
			DataSet ds=DBHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["linkId"].ToString()!="")
				{
					model.linkId=int.Parse(ds.Tables[0].Rows[0]["linkId"].ToString());
				}
				model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.OtherMode=ds.Tables[0].Rows[0]["OtherMode"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
				if(ds.Tables[0].Rows[0]["createTime"].ToString()!="")
				{
					model.createTime=DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
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
            strSql.Append("select linkId,Name,Tel,Phone,Email,ImageMap,LoginName,OtherMode,Address,createTime ");
			strSql.Append(" FROM TZLinkTab ");
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
            strSql.Append(" linkId,Name,LoginName,Tel,Phone,ImageMap,Email,OtherMode,Address,createTime ");
			strSql.Append(" FROM TZLinkTab ");
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
			parameters[0].Value = "TZLinkTab";
			parameters[1].Value = "linkId";
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

