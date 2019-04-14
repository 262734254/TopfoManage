using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Tz888.DBUtility;
using System.Data;

namespace Tz888.SQLServerDAL.Mail
{
    public class CityDAL
    {
        /// <summary>
        /// 增加市
        /// </summary>
        public int Add(Tz888.Model.Mail.City model)
        {
            int result=GetCount(model .Name.ToString ().Trim (), Convert.ToInt32(model .provinceId));
            if (result == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into City(");
                strSql.Append("Name,provinceId)");
                strSql.Append(" values (");
                strSql.Append("@Name,@provinceId)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
					new SqlParameter("@provinceId", SqlDbType.Int,4)};
                parameters[0].Value = model.Name;
                parameters[1].Value = model.provinceId;

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
        //验证该省名称是否存在该市
        public int GetCount(string Name, int provinceId)
        {
            string sql = "select count(*) from City where Name=@name and provinceId=@provinceId ";
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
					new SqlParameter("@provinceId", SqlDbType.Int,4)};
            parameters[0].Value = Name;
            parameters[1].Value = provinceId;
            return DBHelpers.GetScalar(sql,parameters);
        }
        /// <summary>
        /// 得到一个对象实体集合通过provinceId
        /// </summary>
        public List<Tz888.Model.Mail.City> GetModelList(int provinceId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,provinceId from City ");
            strSql.Append(" where provinceId=@provinceId ");
            SqlParameter[] parameters = {
					new SqlParameter("@provinceId", SqlDbType.Int,4)};
            parameters[0].Value = provinceId;

            List<Tz888.Model.Mail.City> list = new List<Tz888.Model.Mail.City>();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Tz888.Model.Mail.City model = new Tz888.Model.Mail.City();
                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                model.Name = row["Name"].ToString();
                if (row["provinceId"].ToString() != "")
                {
                    model.provinceId = int.Parse(row["provinceId"].ToString());
                }
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Mail.City GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,provinceId from City ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Tz888.Model.Mail.City model = new Tz888.Model.Mail.City();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["provinceId"].ToString() != "")
                {
                    model.provinceId = int.Parse(ds.Tables[0].Rows[0]["provinceId"].ToString());
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
        public Tz888.Model.Mail.City GetModelByName(string Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,provinceId from City ");
            strSql.Append(" where Name=@Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar ,200)};
            parameters[0].Value = Name;

            Tz888.Model.Mail.City model = new Tz888.Model.Mail.City();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["provinceId"].ToString() != "")
                {
                    model.provinceId = int.Parse(ds.Tables[0].Rows[0]["provinceId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
