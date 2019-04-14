using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Mail
{
    public class PositionDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Mail.Position model)
        {
            int count=GetCount(model .Name);
            if (count == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Position(");
                strSql.Append("Name,Audit)");
                strSql.Append(" values (");
                strSql.Append("@Name,@Audit)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,300),
                    new SqlParameter("@Audit",SqlDbType.Int,4)
                };
                    
                parameters[0].Value = model.Name;
                parameters[1].Value = model.Audit;

                object obj = DBHelpers.GetSingle(strSql.ToString(), parameters);
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
            else { return 0; }
        }
        //验证职位是否存在
        public int GetCount(string Name)
        {
            string sql = "select count(*) from Position where Name=@name ";
            return DBHelpers.GetScalar(sql,new SqlParameter ("@name",Name));
        }
        /// <summary>
        /// 得到一个对象实体集合
        /// </summary>
        public List<Tz888.Model.Mail.Position> GetModelList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,Audit from Position ");

            List<Tz888.Model.Mail.Position>list = new List<Tz888.Model.Mail.Position> ();
            DataSet ds = DBHelpers.Query(strSql.ToString());
            foreach(DataRow row in ds.Tables [0].Rows )
            {
                Tz888.Model.Mail.Position model = new Tz888.Model.Mail.Position();
                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                model.Name = row["Name"].ToString();
                if (row["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(row["Audit"].ToString());
                }
                list.Add(model);
            }
            return list;

        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Mail.Position GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,Audit from Position ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Tz888.Model.Mail.Position model = new Tz888.Model.Mail.Position();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["Audit"].ToString() != "")
                {
                    model.Audit= int.Parse(ds.Tables[0].Rows[0]["Audit"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public Tz888.Model.Mail.Position GetModelByName(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,Audit from Position ");
            strSql.Append(" where Name=@name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,300)};
            parameters[0].Value = name;

            Tz888.Model.Mail.Position model = new Tz888.Model.Mail.Position();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["Audit"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        //审核职位
        public int  Update(Tz888.Model.Mail.Position model)
        {



             Tz888.Model.Mail.Position models = GetModelByName(model.Name);
            if (models != null)
            {
                if (models.Id != model.Id)
                {
                    return 0;
                }
                else
                {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Position set ");
                strSql.Append("Name=@Name,Audit=@Audit");
                strSql.Append(" where Id=@Id ");
                SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,300),
                    new SqlParameter("@Audit",SqlDbType.Int,4)
                };
                parameters[0].Value = model.Id;
                parameters[1].Value = model.Name;
                parameters[2].Value = model.Audit;

                return DBHelpers.ExecuteSql(strSql.ToString(), parameters);
                }
            }
            else
            {
                 StringBuilder strSql = new StringBuilder();
                strSql.Append("update Position set ");
                strSql.Append("Name=@Name,Audit=@Audit");
                strSql.Append(" where Id=@Id ");
                SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,300),
                    new SqlParameter("@Audit",SqlDbType.Int,4)
                };
                parameters[0].Value = model.Id;
                parameters[1].Value = model.Name;
                parameters[2].Value = model.Audit;

                return DBHelpers.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        

    }
}
