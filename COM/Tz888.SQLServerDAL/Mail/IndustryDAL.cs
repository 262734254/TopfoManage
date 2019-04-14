using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Tz888.DBUtility;
using System.Data;

namespace Tz888.SQLServerDAL.Mail
{
    public class IndustryDAL
    {
        /// <summary>
        /// 增加行业
        /// </summary>
        public int Add(Tz888.Model.Mail.Industry model)
        {
            int count = GetCount(model.Name);
            if (count == 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Industry(");
                strSql.Append("Name,IsShow)");
                strSql.Append(" values (");
                strSql.Append("@Name,@IsShow)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,300),
                    new SqlParameter("@IsShow",SqlDbType.Int,4)
                };
                parameters[0].Value = model.Name;
                parameters[1].Value = model.IsShow;

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
        /// <summary>
        /// 修改行业
        /// </summary>
        public int Update(Tz888.Model.Mail.Industry model, int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update Industry set ");
            sb.Append("Name=@Name, ");
            sb.Append("IsShow=@IsShow where ID=@id");
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,4),
                new SqlParameter("@Name",SqlDbType.VarChar,50),
                new SqlParameter("@IsShow",SqlDbType.Int,4)
            };
            model.Id = id;
            para[0].Value = model.Id;
            para[1].Value = model.Name;
            para[2].Value = model.IsShow;
            object obj = DBHelpers.GetSingle(sb.ToString(), para);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        //验证省名称是否存在
        public int GetCount(string Name)
        {
            string sql = "select count(*) from Industry where Name=@name ";
            return DBHelpers.GetScalar(sql, new SqlParameter("@name", Name));
        }

        /// <summary>
        /// 绑定成dropdownlist的时候用
        /// </summary>
        public List<Tz888.Model.Mail.Industry> GetModelList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,IsShow from Industry where IsShow=1");
            List<Tz888.Model.Mail.Industry> list = new List<Tz888.Model.Mail.Industry>();
            DataSet ds = DBHelpers.Query(strSql.ToString());
            foreach (DataRow row in ds.Tables [0].Rows)
            {
                Tz888.Model.Mail.Industry model = new Tz888.Model.Mail.Industry();
                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                model.Name = row["Name"].ToString();
                if (row["IsShow"].ToString() != "")
                {
                    model.IsShow = int.Parse(row["IsShow"].ToString());
                }
                list.Add(model);
            }
            return list;

        }
        /// <summary>
        /// 绑定成Repeater的时候用
        /// </summary>
        public List<Tz888.Model.Mail.Industry> GetModelRepeater()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,IsShow from Industry ");
            List<Tz888.Model.Mail.Industry> list = new List<Tz888.Model.Mail.Industry>();
            DataSet ds = DBHelpers.Query(strSql.ToString());
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Tz888.Model.Mail.Industry model = new Tz888.Model.Mail.Industry();
                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                model.Name = row["Name"].ToString();
                if (row["IsShow"].ToString() != "")
                {
                    model.IsShow = int.Parse(row["IsShow"].ToString());
                }
                list.Add(model);
            }
            return list;

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Mail.Industry GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,IsShow from Industry ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Tz888.Model.Mail.Industry model = new Tz888.Model.Mail.Industry();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
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
        public Tz888.Model.Mail.Industry GetModelByName(string Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,IsShow from Industry ");
            strSql.Append(" where Name=@Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar ,200)};
            parameters[0].Value = Name;

            Tz888.Model.Mail.Industry model = new Tz888.Model.Mail.Industry();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["IsShow"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["IsShow"].ToString());
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
