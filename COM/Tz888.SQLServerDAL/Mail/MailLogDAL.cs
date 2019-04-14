using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DBUtility;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.Mail
{
    public class MailLogDAL
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Mail.MailLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MailLog(");
            strSql.Append("MailId,MUserName,edate)");
            strSql.Append(" values (");
            strSql.Append("@MailId,@MUserName,@edate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MailId", SqlDbType.Int,4),
					new SqlParameter("@MUserName", SqlDbType.NVarChar,200),
					new SqlParameter("@edate", SqlDbType.DateTime)};
            parameters[0].Value = model.MailId;
            parameters[1].Value = model.MUserName;
            parameters[2].Value = model.edate;

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
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Mail.MailLog GetModel(int EID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 EID,MailId,MUserName,edate from MailLog ");
            strSql.Append(" where EID=@EID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4)};
            parameters[0].Value = EID;

            Tz888.Model.Mail.MailLog model = new Tz888.Model.Mail.MailLog();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EID"].ToString() != "")
                {
                    model.EID = int.Parse(ds.Tables[0].Rows[0]["EID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MailId"].ToString() != "")
                {
                    model.MailId = int.Parse(ds.Tables[0].Rows[0]["MailId"].ToString());
                }
                model.MUserName = ds.Tables[0].Rows[0]["MUserName"].ToString();
                if (ds.Tables[0].Rows[0]["edate"].ToString() != "")
                {
                    model.edate = ds.Tables[0].Rows[0]["edate"].ToString();
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
