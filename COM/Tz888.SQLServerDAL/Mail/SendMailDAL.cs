using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Mail
{
    public class SendMailDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Mail.SendMail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SendMail(");
            strSql.Append("LoginName,EMtitle,SendContext,SendCount,SendNumber,SendTime)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@EMtitle,@SendContext,@SendCount,@SendNumber,@SendTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.NVarChar,200),
					new SqlParameter("@EMtitle", SqlDbType.NVarChar,3000),
					new SqlParameter("@SendContext", SqlDbType.Text),
					new SqlParameter("@SendCount", SqlDbType.Int,4),
					new SqlParameter("@SendNumber", SqlDbType.Int,4),
					new SqlParameter("@SendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.EMtitle;
            parameters[2].Value = model.SendContext;
            parameters[3].Value = model.SendCount;
            parameters[4].Value = model.SendNumber;
            parameters[5].Value = model.SendTime;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Tz888.Model.Mail.SendMail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SendMail set ");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("EMtitle=@EMtitle,");
            strSql.Append("SendContext=@SendContext,");
            strSql.Append("SendCount=@SendCount,");
            strSql.Append("SendNumber=@SendNumber,");
            strSql.Append("SendTime=@SendTime");
            strSql.Append(" where MailId=@MailId ");
            SqlParameter[] parameters = {
					new SqlParameter("@MailId", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.NVarChar,200),
					new SqlParameter("@EMtitle", SqlDbType.NVarChar,3000),
					new SqlParameter("@SendContext", SqlDbType.Text),
					new SqlParameter("@SendCount", SqlDbType.Int,4),
					new SqlParameter("@SendNumber", SqlDbType.Int,4),
					new SqlParameter("@SendTime", SqlDbType.DateTime)};
            parameters[0].Value = model.MailId;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.EMtitle;
            parameters[3].Value = model.SendContext;
            parameters[4].Value = model.SendCount;
            parameters[5].Value = model.SendNumber;
            parameters[6].Value = model.SendTime;

            return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int MailId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SendMail ");
            strSql.Append(" where MailId=@MailId ");
            SqlParameter[] parameters = {
					new SqlParameter("@MailId", SqlDbType.Int,4)};
            parameters[0].Value = MailId;

            return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Mail.SendMail GetModel(int MailId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MailId,LoginName,EMtitle,SendContext,SendCount,SendNumber,SendTime from SendMail ");
            strSql.Append(" where MailId=@MailId ");
            SqlParameter[] parameters = {
					new SqlParameter("@MailId", SqlDbType.Int,4)};
            parameters[0].Value = MailId;

            Tz888.Model.Mail.SendMail model = new Tz888.Model.Mail.SendMail();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MailId"].ToString() != "")
                {
                    model.MailId = int.Parse(ds.Tables[0].Rows[0]["MailId"].ToString());
                }
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.EMtitle = ds.Tables[0].Rows[0]["EMtitle"].ToString();
                model.SendContext = ds.Tables[0].Rows[0]["SendContext"].ToString();
                if (ds.Tables[0].Rows[0]["SendCount"].ToString() != "")
                {
                    model.SendCount = int.Parse(ds.Tables[0].Rows[0]["SendCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SendNumber"].ToString() != "")
                {
                    model.SendNumber = int.Parse(ds.Tables[0].Rows[0]["SendNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SendTime"].ToString() != "")
                {
                    model.SendTime = ds.Tables[0].Rows[0]["SendTime"].ToString();
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
        public List<Tz888.Model.Mail.SendMail> GetModelList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MailId,LoginName,EMtitle,SendContext,SendCount,SendNumber,SendTime from SendMail ");

            List<Tz888.Model.Mail.SendMail>list = new List<Tz888.Model.Mail.SendMail> ();
            DataSet ds = DBHelpers.Query(strSql.ToString());
            foreach (DataRow row in ds.Tables [0].Rows)
            {
                Tz888.Model.Mail.SendMail model = new Tz888.Model.Mail.SendMail();
                if (row["MailId"].ToString() != "")
                {
                    model.MailId = int.Parse(row["MailId"].ToString());
                }
                model.LoginName = row["LoginName"].ToString();
                model.EMtitle = row["EMtitle"].ToString();
                model.SendContext = row["SendContext"].ToString();
                if (row["SendCount"].ToString() != "")
                {
                    model.SendCount = int.Parse(row["SendCount"].ToString());
                }
                if (row["SendNumber"].ToString() != "")
                {
                    model.SendNumber = int.Parse(row["SendNumber"].ToString());
                }
                if (row["SendTime"].ToString() != "")
                {
                    model.SendTime = row["SendTime"].ToString();
                }
                list.Add( model);
            }
            return list;
        }
    }
}
