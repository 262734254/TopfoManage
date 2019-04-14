using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using GZS.DAL;

namespace GZS.DAL.Person
{
	/// <summary>
	/// 数据访问类:PersonDAL
	/// </summary>
	public partial class PersonDAL
	{
		public PersonDAL()
		{}
		#region  Method
		

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(GZS.Model.Person.PersonM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PersonTab(");
            strSql.Append("name,createTime,birthDay,signature,description,address,img,LoginName)");
			strSql.Append(" values (");
            strSql.Append("@name,GETDATE(),@birthDay,@signature,@description,@address,@img,@LoginName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					//new SqlParameter("@createTime", SqlDbType.DateTime),
					new SqlParameter("@birthDay", SqlDbType.DateTime),
					new SqlParameter("@signature", SqlDbType.NVarChar,1000),
					new SqlParameter("@description", SqlDbType.NVarChar,2000),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@img", SqlDbType.VarChar,100),
                new SqlParameter("@LoginName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.name;
			//parameters[1].Value = model.createTime;
			parameters[1].Value = model.birthDay;
			parameters[2].Value = model.signature;
			parameters[3].Value = model.description;
			parameters[4].Value = model.address;
			parameters[5].Value = model.img;
            parameters[6].Value = model.LoginName;
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
        public bool Update(GZS.Model.Person.PersonM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PersonTab set ");
			strSql.Append("name=@name,");
			//strSql.Append("createTime=@createTime,");
			strSql.Append("birthDay=@birthDay,");
			strSql.Append("signature=@signature,");
			strSql.Append("description=@description,");
			strSql.Append("address=@address,");
			strSql.Append("img=@img,");
            strSql.Append("loginName=@LoginName");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					//new SqlParameter("@createTime", SqlDbType.DateTime),
					new SqlParameter("@birthDay", SqlDbType.DateTime),
					new SqlParameter("@signature", SqlDbType.NVarChar,1000),
					new SqlParameter("@description", SqlDbType.NVarChar,2000),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@img", SqlDbType.VarChar,100),
                new SqlParameter("@LoginName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.name;
			//parameters[2].Value = model.createTime;
			parameters[2].Value = model.birthDay;
			parameters[3].Value = model.signature;
			parameters[4].Value = model.description;
			parameters[5].Value = model.address;
			parameters[6].Value = model.img;
            parameters[7].Value = model.LoginName;
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
			strSql.Append("delete from PersonTab ");
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
			strSql.Append("delete from PersonTab ");
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
        public GZS.Model.Person.PersonM GetModelByLoginName(string LoginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,createTime,birthDay,signature,description,address,img,LoginName from PersonTab ");
            strSql.Append(" where LoginName=@LoginName");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50)
};
            parameters[0].Value = LoginName;

            GZS.Model.Person.PersonM model = new GZS.Model.Person.PersonM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                if (ds.Tables[0].Rows[0]["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["birthDay"].ToString() != "")
                {
                    model.birthDay = DateTime.Parse(ds.Tables[0].Rows[0]["birthDay"].ToString());
                }
                model.signature = ds.Tables[0].Rows[0]["signature"].ToString();
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.img = ds.Tables[0].Rows[0]["img"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
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
        public GZS.Model.Person.PersonM GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,name,createTime,birthDay,signature,description,address,img,LoginName from PersonTab ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
			parameters[0].Value = id;

            GZS.Model.Person.PersonM model = new GZS.Model.Person.PersonM();
			DataSet ds=DBHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				if(ds.Tables[0].Rows[0]["createTime"].ToString()!="")
				{
					model.createTime=DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["birthDay"].ToString()!="")
				{
					model.birthDay=DateTime.Parse(ds.Tables[0].Rows[0]["birthDay"].ToString());
				}
				model.signature=ds.Tables[0].Rows[0]["signature"].ToString();
				model.description=ds.Tables[0].Rows[0]["description"].ToString();
				model.address=ds.Tables[0].Rows[0]["address"].ToString();
				model.img=ds.Tables[0].Rows[0]["img"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
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
            strSql.Append("select id,name,createTime,birthDay,signature,description,address,img,LoginName ");
			strSql.Append(" FROM PersonTab ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelper.Query(strSql.ToString());
		}
        /// <summary>
        /// 根据用户名查找是否有记录数
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistsName(string loginName)
        {

            string sql = "select count(loginname) as loginname from PersonTab where LoginName='" + loginName + "'";
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
            strSql.Append(" id,name,createTime,birthDay,signature,description,address,img,LoginName ");
			strSql.Append(" FROM PersonTab ");
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
			parameters[0].Value = "PersonTab";
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

