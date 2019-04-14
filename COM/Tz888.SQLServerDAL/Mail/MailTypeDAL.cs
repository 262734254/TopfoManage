using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.Mail
{
    public class MailTypeDAL
    {
        /// <summary>
        /// 增加类型
        /// </summary>
        public int Add(Tz888.Model.Mail.MailType model)
        {
             Tz888.Model.Mail.MailType models=GetModelByTypeName(model .TypeName);
             if (models == null)
             {
                 StringBuilder strSql = new StringBuilder();
                 strSql.Append("insert into MailType(");
                 strSql.Append("TypeName,TypeRemark,audit)");
                 strSql.Append(" values (");
                 strSql.Append("@TypeName,@TypeRemark,@audit)");
                 strSql.Append(";select @@IDENTITY");
                 SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.NVarChar,200),
					new SqlParameter("@TypeRemark", SqlDbType.NVarChar,200),
                	new SqlParameter("@audit", SqlDbType.Int ,4)
                  };
                 parameters[0].Value = model.TypeName;
                 parameters[1].Value = model.TypeRemark;
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
             else { return 0; }
           
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Tz888.Model.Mail.MailType model)
        {
            Tz888.Model.Mail.MailType models = GetModelByTypeName(model.TypeName);
            if (models != null)
            {
                if (models.typeID != model.typeID)
                {
                    return 0;
                }
                else
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update MailType set ");
                    strSql.Append("TypeName=@TypeName,");
                    strSql.Append("TypeRemark=@TypeRemark,");
                    strSql.Append("audit=@audit");
                    strSql.Append(" where typeID=@typeID ");
                    SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,200),
					new SqlParameter("@TypeRemark", SqlDbType.NVarChar,200),
            	    new SqlParameter("@audit", SqlDbType.Int,4)
                    };
                    parameters[0].Value = model.typeID;
                    parameters[1].Value = model.TypeName;
                    parameters[2].Value = model.TypeRemark;
                    parameters[3].Value = model.Audit;

                    return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update MailType set ");
                strSql.Append("TypeName=@TypeName,");
                strSql.Append("TypeRemark=@TypeRemark,");
                strSql.Append("audit=@audit");
                strSql.Append(" where typeID=@typeID ");
                SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,200),
					new SqlParameter("@TypeRemark", SqlDbType.NVarChar,200),
            	new SqlParameter("@audit", SqlDbType.Int,4)
                };
                parameters[0].Value = model.typeID;
                parameters[1].Value = model.TypeName;
                parameters[2].Value = model.TypeRemark;
                parameters[3].Value = model.Audit;

                return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int typeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MailType ");
            strSql.Append(" where typeID=@typeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.Int,4)};
            parameters[0].Value = typeID;

            return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个类型对象实体
        /// </summary>
        public Tz888.Model.Mail.MailType GetModel(int typeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 typeID,TypeName,TypeRemark,audit from MailType ");
            strSql.Append(" where typeID=@typeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@typeID", SqlDbType.Int,4)};
            parameters[0].Value = typeID;

            Tz888.Model.Mail.MailType model = new Tz888.Model.Mail.MailType();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["audit"].ToString());
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                model.TypeRemark = ds.Tables[0].Rows[0]["TypeRemark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个类型对象实体
        /// </summary>
        public Tz888.Model.Mail.MailType GetModelByTypeName(string TypeName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 typeID,TypeName,TypeRemark,audit from MailType ");
            strSql.Append(" where TypeName=@TypeName ");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.NVarChar ,200)};
            parameters[0].Value = TypeName;

            Tz888.Model.Mail.MailType model = new Tz888.Model.Mail.MailType();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["audit"].ToString());
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                model.TypeRemark = ds.Tables[0].Rows[0]["TypeRemark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个类型对象实体集合
        /// </summary>
        public List<Tz888.Model.Mail.MailType> GetModelList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select typeID,TypeName,TypeRemark,audit from MailType where audit=1 ");

            List<Tz888.Model.Mail.MailType> list = new List<Tz888.Model.Mail.MailType>();
            DataSet ds = DBHelpers.Query(strSql.ToString());
            foreach (DataRow row in ds.Tables [0].Rows )
            {
                Tz888.Model.Mail.MailType model = new Tz888.Model.Mail.MailType();
                if (row["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(row["typeID"].ToString());
                }
                if (row["audit"].ToString() != "")
                {
                    model.Audit = int.Parse(row["audit"].ToString());
                }
                model.TypeName =row["TypeName"].ToString();
                model.TypeRemark =row["TypeRemark"].ToString();
                list.Add(model);
            }
            return list;
        }
    }
}
