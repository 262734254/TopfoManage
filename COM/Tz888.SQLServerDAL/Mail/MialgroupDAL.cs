using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Mail
{
    public class MialgroupDAL
    {
        /// <summary>
        /// 增加组
        /// </summary>
        public int Add(Tz888.Model.Mail.Mialgroup model)
        {
            int count = GetCount(model .groupname.Trim ());
            if (count > 0)
            {
                return 0;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Mialgroup(");
                strSql.Append("groupname,groupremark,audit)");
                strSql.Append(" values (");
                strSql.Append("@groupname,@groupremark,@audit)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@groupname", SqlDbType.VarChar,100),
					new SqlParameter("@groupremark", SqlDbType.VarChar,200),
                    new SqlParameter("@audit", SqlDbType.Int,4)
                   };
                parameters[0].Value = model.groupname;
                parameters[1].Value = model.groupremark;
                parameters[2].Value = model.Audit;

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
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(Tz888.Model.Mail.Mialgroup model)
        {
            Tz888.Model.Mail.Mialgroup models=GetModelByName(model .groupname);
            if (models != null)
            {
                if (models.groupID != model.groupID)
                {
                    return 0;
                }
                else 
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update Mialgroup set ");
                    strSql.Append("groupname=@groupname,");
                    strSql.Append("groupremark=@groupremark,");
                    strSql.Append("audit=@audit");
                    strSql.Append(" where groupID=@groupID ");
                    SqlParameter[] parameters = {
                    new SqlParameter("@audit", SqlDbType.Int,4),
					new SqlParameter("@groupID", SqlDbType.Int,4),
					new SqlParameter("@groupname", SqlDbType.VarChar,100),
					new SqlParameter("@groupremark", SqlDbType.VarChar,200)};
                    parameters[0].Value = model.Audit;
                    parameters[1].Value = model.groupID;
                    parameters[2].Value = model.groupname;
                    parameters[3].Value = model.groupremark;

                    return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Mialgroup set ");
                strSql.Append("groupname=@groupname,");
                strSql.Append("groupremark=@groupremark,");
                strSql.Append("audit=@audit");
                strSql.Append(" where groupID=@groupID ");
                SqlParameter[] parameters = {
                    new SqlParameter("@audit", SqlDbType.Int,4),
					new SqlParameter("@groupID", SqlDbType.Int,4),
					new SqlParameter("@groupname", SqlDbType.VarChar,100),
					new SqlParameter("@groupremark", SqlDbType.VarChar,200)};
                parameters[0].Value = model.Audit;
                parameters[1].Value = model.groupID;
                parameters[2].Value = model.groupname;
                parameters[3].Value = model.groupremark;

                return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int groupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Mialgroup ");
            strSql.Append(" where groupID=@groupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@groupID", SqlDbType.Int,4)};
            parameters[0].Value = groupID;

            return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个组对象实体
        /// </summary>
        public Tz888.Model.Mail.Mialgroup GetModel(int groupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 groupID,groupname,groupremark,audit from Mialgroup ");
            strSql.Append(" where groupID=@groupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@groupID", SqlDbType.Int,4)};
            parameters[0].Value = groupID;

            Tz888.Model.Mail.Mialgroup model = new Tz888.Model.Mail.Mialgroup();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["groupID"].ToString() != "")
                {
                    model.groupID = int.Parse(ds.Tables[0].Rows[0]["groupID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["audit"].ToString());
                }
                model.groupname = ds.Tables[0].Rows[0]["groupname"].ToString();
                model.groupremark = ds.Tables[0].Rows[0]["groupremark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        public Tz888.Model.Mail.Mialgroup GetModelByName(string groupname)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 groupID,groupname,groupremark,audit from Mialgroup ");
            strSql.Append(" where groupname=@groupname ");
            SqlParameter[] parameters = {
					new SqlParameter("@groupname", SqlDbType.VarChar,100)};
            parameters[0].Value = groupname;

            Tz888.Model.Mail.Mialgroup model = new Tz888.Model.Mail.Mialgroup();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["groupID"].ToString() != "")
                {
                    model.groupID = int.Parse(ds.Tables[0].Rows[0]["groupID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["audit"].ToString());
                }
                model.groupname = ds.Tables[0].Rows[0]["groupname"].ToString();
                model.groupremark = ds.Tables[0].Rows[0]["groupremark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个组对象实体通过组名称
        /// </summary>
        public int GetCount(string groupname)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(*) from Mialgroup ");
            strSql.Append(" where groupname=@groupname ");
            return DBHelpers.GetScalar(strSql.ToString(), new SqlParameter("@groupname", groupname));

        }
        /// <summary>
        /// 得到一个组对象实体集合
        /// </summary>
        public List<Tz888.Model.Mail.Mialgroup> GetModelList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select groupID,groupname,groupremark,audit from Mialgroup where audit=1 ");

            List<Tz888.Model.Mail.Mialgroup> list = new List<Tz888.Model.Mail.Mialgroup>();
            DataSet ds = DBHelpers.Query(strSql.ToString());
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Tz888.Model.Mail.Mialgroup model = new Tz888.Model.Mail.Mialgroup();
                if (row["groupID"].ToString() != "")
                {
                    model.groupID = int.Parse(row["groupID"].ToString());
                }
                if (row["audit"].ToString() != "")
                {
                    model.Audit  = int.Parse(row["audit"].ToString());
                }
                model.groupname = row["groupname"].ToString();
                model.groupremark = row["groupremark"].ToString();
                list.Add(model);
            }
            return list;
        }
    }
}
