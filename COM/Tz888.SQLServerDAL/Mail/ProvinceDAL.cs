using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Mail
{
    public class ProvinceDAL
    {
        /// <summary>
        /// 增加省
        /// </summary>
        public int Add(Tz888.Model.Mail.Province model)
        {
            int count=GetCount(model .Name);
            if (count == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Province(");
                strSql.Append("Name)");
                strSql.Append(" values (");
                strSql.Append("@Name)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
		        new SqlParameter("@Name", SqlDbType.NVarChar,200)};
                parameters[0].Value = model.Name;

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
        //验证省名称是否存在
        public int GetCount(string Name)
        {
            string sql = "select count(*) from Province where Name=@name ";
            return DBHelpers.GetScalar(sql, new SqlParameter("@name", Name));
        }
        /// <summary>
        /// 得到一个对象实体集合
        /// </summary>
        public List<Tz888.Model.Mail.Province> GetModelList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name from Province ");

            List<Tz888.Model.Mail.Province> list = new List<Tz888.Model.Mail.Province>();
            DataSet ds = DBHelpers.Query(strSql.ToString());
            foreach (DataRow row in ds.Tables [0].Rows)
            {
                Tz888.Model.Mail.Province model = new Tz888.Model.Mail.Province();
                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                model.Name = row["Name"].ToString();
                list.Add(model);
            }
            return list;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Mail.Province GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name from Province ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Tz888.Model.Mail.Province model = new Tz888.Model.Mail.Province();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
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
        public Tz888.Model.Mail.Province GetModelByName(string Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name from Province ");
            strSql.Append(" where Name=@Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar ,200)};
            parameters[0].Value = Name;

            Tz888.Model.Mail.Province model = new Tz888.Model.Mail.Province();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
