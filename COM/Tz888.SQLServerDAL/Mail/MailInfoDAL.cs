using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Mail
{
    public class MailInfoDAL
    {
        /// <summary>
        /// 增加用户
        /// </summary>
        public int Add(Tz888.Model.Mail.MailInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MailInfo(");
            strSql.Append("LoginName,UserName,PanyName,PositionId,Address,LinkUrl,audit,ProvinceId,CityId,industry,Mial,Mobile,Phone,typeID,groupID,remark,Mdatetime)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@UserName,@PanyName,@PositionId,@Address,@LinkUrl,@audit,@ProvinceId,@CityId,@industry,@Mial,@Mobile,@Phone,@typeID,@groupID,@remark,@Mdatetime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.NVarChar,200),
					new SqlParameter("@UserName", SqlDbType.VarChar,100),
					new SqlParameter("@PanyName", SqlDbType.NVarChar,200),
					new SqlParameter("@PositionId", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,300),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@audit", SqlDbType.Int,4),
                	new SqlParameter("@ProvinceId", SqlDbType.Int,4),
					new SqlParameter("@CityId", SqlDbType.Int,4),
					new SqlParameter("@industry", SqlDbType.Int,4),
					new SqlParameter("@Mial", SqlDbType.NVarChar,200),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
                    new SqlParameter("@Phone",SqlDbType.VarChar,50),
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@groupID", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@Mdatetime", SqlDbType.DateTime)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.PanyName;
            parameters[3].Value = model.PositionId;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.LinkUrl;
            parameters[6].Value = model.audit;
            parameters[7].Value = model.ProvinceId;
            parameters[8].Value = model.CityId;
            parameters[9].Value = model.industry;
            parameters[10].Value = model.Mial;
            parameters[11].Value = model.Mobile;
            parameters[12].Value = model.phone;
            parameters[13].Value = model.typeID;
            parameters[14].Value = model.groupID;
            parameters[15].Value = model.remark;
            parameters[16].Value = model.Mdatetime;

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
        public int Update(Tz888.Model.Mail.MailInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MailInfo set ");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PanyName=@PanyName,");
            strSql.Append("PositionId=@PositionId,");
            strSql.Append("Address=@Address,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("audit=@audit,");
            strSql.Append("ProvinceId=@ProvinceId,");
            strSql.Append("CityId=@CityId,");
            strSql.Append("industry=@industry,");
            strSql.Append("Mial=@Mial,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("typeID=@typeID,");
            strSql.Append("groupID=@groupID,");
            strSql.Append("remark=@remark");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.NVarChar,200),
					new SqlParameter("@UserName", SqlDbType.VarChar,100),
					new SqlParameter("@PanyName", SqlDbType.NVarChar,200),
					new SqlParameter("@PositionId", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,300),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@audit", SqlDbType.Int,4),
                    new SqlParameter("@ProvinceId", SqlDbType.Int,4),
					new SqlParameter("@CityId", SqlDbType.Int,4),
					new SqlParameter("@industry", SqlDbType.Int,4),
					new SqlParameter("@Mial", SqlDbType.NVarChar,200),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
                    new SqlParameter("@Phone",SqlDbType.VarChar,100),
					new SqlParameter("@typeID", SqlDbType.Int,4),
					new SqlParameter("@groupID", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,200)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.PanyName;
            parameters[4].Value = model.PositionId;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.LinkUrl;
            parameters[7].Value = model.audit;
            parameters[8].Value = model.ProvinceId ;
            parameters[9].Value = model.CityId;
            parameters[10].Value = model.industry;
            parameters[11].Value = model.Mial;
            parameters[12].Value = model.Mobile;
            parameters[13].Value = model.phone;
            parameters[14].Value = model.typeID;
            parameters[15].Value = model.groupID;
            parameters[16].Value = model.remark;

           return  DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MailInfo ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条Email内容数据
        /// </summary>
        public int DelEmail(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EmailType ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Mail.MailInfo GetModel(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,LoginName,UserName,PanyName,PositionId,Address,LinkUrl,audit,ProvinceId,CityId,industry,Mial,Mobile,Phone,typeID,groupID,remark,Mdatetime from MailInfo ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            Tz888.Model.Mail.MailInfo model = new Tz888.Model.Mail.MailInfo();
            DataSet ds = DBHelpers.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.PanyName = ds.Tables[0].Rows[0]["PanyName"].ToString();
                if (ds.Tables[0].Rows[0]["PositionId"].ToString() != "")
                {
                    model.PositionId = int.Parse(ds.Tables[0].Rows[0]["PositionId"].ToString());
                }
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
                if (ds.Tables[0].Rows[0]["audit"].ToString() != "")
                {
                    model.audit = int.Parse(ds.Tables[0].Rows[0]["audit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProvinceId"].ToString() != "")
                {
                    model.ProvinceId = int.Parse(ds.Tables[0].Rows[0]["ProvinceId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CityId"].ToString() != "")
                {
                    model.CityId = int.Parse(ds.Tables[0].Rows[0]["CityId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["industry"].ToString() != "")
                {
                    model.industry = int.Parse(ds.Tables[0].Rows[0]["industry"].ToString());
                }
                model.Mial = ds.Tables[0].Rows[0]["Mial"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                if (ds.Tables[0].Rows[0]["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["groupID"].ToString() != "")
                {
                    model.groupID = int.Parse(ds.Tables[0].Rows[0]["groupID"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["Mdatetime"].ToString() != "")
                {
                    model.Mdatetime =ds.Tables[0].Rows[0]["Mdatetime"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体集合
        /// </summary>
        public List<Tz888.Model.Mail.MailInfo> GetModelList(string par)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,LoginName,UserName,PanyName,PositionId,Address,LinkUrl,audit,ProvinceId,CityId,industry,Mial,Mobile,typeID,groupID,remark,Mdatetime from MailInfo ");
            strSql.Append(" where " + par + " order by Mdatetime desc");

            List<Tz888.Model.Mail.MailInfo> list = new List<Tz888.Model.Mail.MailInfo>();
            DataSet ds = DBHelpers.Query(strSql.ToString());
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Tz888.Model.Mail.MailInfo model = new Tz888.Model.Mail.MailInfo();
                if (row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                model.LoginName = row["LoginName"].ToString();
                model.UserName = row["UserName"].ToString();
                model.PanyName = row["PanyName"].ToString();
                if (row["PositionId"].ToString() != "")
                {
                    model.PositionId = int.Parse(row["PositionId"].ToString());
                }
                model.Address = row["Address"].ToString();
                model.LinkUrl = row["LinkUrl"].ToString();
                if (row["audit"].ToString() != "")
                {
                    model.audit = int.Parse(row["audit"].ToString());
                }
                if (row["ProvinceId"].ToString() != "")
                {
                    model.ProvinceId = int.Parse(row["ProvinceId"].ToString());
                }
                if (row["CityId"].ToString() != "")
                {
                    model.CityId = int.Parse(row["CityId"].ToString());
                }
                if (row["industry"].ToString() != "")
                {
                    model.industry = int.Parse(row["industry"].ToString());
                }
                model.Mial = row["Mial"].ToString();
                model.Mobile = row["Mobile"].ToString();
                if (row["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(row["typeID"].ToString());
                }
                if (row["groupID"].ToString() != "")
                {
                    model.groupID = int.Parse(row["groupID"].ToString());
                }
                model.remark = row["remark"].ToString();
                if (row["Mdatetime"].ToString() != "")
                {
                    model.Mdatetime = row["Mdatetime"].ToString();
                }
                list.Add(model);
            }
            return list;

        }
        /// <summary>
        /// 得到一个DataTable集合
        /// </summary>
        public DataTable GetDataTable(string par)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,LoginName,UserName,PanyName,PositionId,Address,LinkUrl,audit,ProvinceId,CityId,industry,Mial,Mobile,typeID,groupID,remark,Mdatetime from MailInfo ");
            strSql.Append(" where " + par + " ");
            DataTable ds = DBHelpers.Query(strSql.ToString()).Tables[0];
            return ds;
        }
        /// <summary>
        /// //插入招商信息ID 邮件
        /// </summary>
        #region
        public int InsertEmail(int infoID)
        {

           
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("select count(*) from [TotpfoMail].[dbo].EmailType where infoid=@infoid");

            SqlParameter[] par = {
					new SqlParameter("@infoID", SqlDbType.Int,8)};
            par[0].Value = infoID;

            int b =int.Parse( DBHelpers.GetSingle(strSql1.ToString(), par).ToString());
            if (b== 0)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into EmailType values(@infoID,getdate())");
                SqlParameter[] parameters = {
					new SqlParameter("@infoID", SqlDbType.Int,8)};
                parameters[0].Value = infoID;
                return DBHelpers.ExecuteCommand(strSql.ToString(), parameters);

            }
            else
            {
                return 1;
            }

        }
        #endregion


        /// <summary>
        /// //获取招商内容信息 index 条数
        /// </summary>
        ///
        #region//DataSet 招商信息集合

        public DataSet SelDataSet()
        {
            string sql = "select  a.infoid as ainfoid,*from [Search].[dbo].[MerchantInfoTab] as a  inner join [TotpfoMail].[dbo].EmailType b on a.infoid=b.infoid order by b.time desc ";
            return SearchDBHelper.Query(sql.ToString());
           
        }
        #endregion
    }
}
