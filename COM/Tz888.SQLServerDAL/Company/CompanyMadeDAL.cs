using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.Company;

namespace Tz888.SQLServerDAL.Company
{
    public class CompanyMadeDAL:Tz888.IDAL.Company.ICompanyMade
    {
        #region ICompanyMade 成员
        Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
        /// <summary>
        /// 根据编号查看广告定制
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyMadeModel SelGetMade(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MadeID,CompanyID,Price,SumPrice,UserName,CreateDate,BeginTime,EndTime,LinkName,TelPhone,Email,Audit,AuditName,Hit,VisitHit from CompanyMadeTab ");
            strSql.Append(" where MadeID=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            CompanyMadeModel model = new CompanyMadeModel();
            DataSet ds = crm.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MadeID"].ToString() != "")
                {
                    model.MadeID = int.Parse(ds.Tables[0].Rows[0]["MadeID"].ToString());
                }
                model.CompanyID = ds.Tables[0].Rows[0]["CompanyID"].ToString();
                model.Price = ds.Tables[0].Rows[0]["Price"].ToString();
                model.SumPrice = ds.Tables[0].Rows[0]["SumPrice"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                model.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();
                model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["Audit"].ToString());
                }
                model.AuditName = ds.Tables[0].Rows[0]["AuditName"].ToString();
                if (ds.Tables[0].Rows[0]["Hit"].ToString() != "")
                {
                    model.Hit = int.Parse(ds.Tables[0].Rows[0]["Hit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VisitHit"].ToString() != "")
                {
                    model.VisitHit = int.Parse(ds.Tables[0].Rows[0]["VisitHit"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 广告定制修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateMade(CompanyMadeModel model, int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CompanyMadeTab set ");
            //strSql.Append("CompanyID=@CompanyID,");
            //strSql.Append("Price=@Price,");
            strSql.Append("SumPrice=@SumPrice,");
            //strSql.Append("UserName=@UserName,");
            //strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("LinkName=@LinkName,");
            strSql.Append("TelPhone=@TelPhone,");
            strSql.Append("Email=@Email,");
            strSql.Append("Audit=@Audit,");
            strSql.Append("AuditName=@AuditName,");
            strSql.Append("Remark=@Remark ");
            //strSql.Append("Hit=@Hit,");
            //strSql.Append("VisitHit=@VisitHit");
            strSql.Append(" where MadeID=@MadeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MadeID", SqlDbType.Int,4),
                    //new SqlParameter("@CompanyID", SqlDbType.VarChar,50),
                    //new SqlParameter("@Price", SqlDbType.VarChar,100),
                    new SqlParameter("@SumPrice", SqlDbType.VarChar,50),
                    //new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    //new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@BeginTime", SqlDbType.DateTime),
                    new SqlParameter("@EndTime", SqlDbType.DateTime),
                    new SqlParameter("@LinkName", SqlDbType.VarChar,50),
                    new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
                    new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@AuditName", SqlDbType.VarChar,50),
                    new SqlParameter("@Remark",SqlDbType.NVarChar,4000)
                    //new SqlParameter("@Hit", SqlDbType.Int,4),
                    //new SqlParameter("@VisitHit", SqlDbType.Int,4)
            };
            model.MadeID = id;
            parameters[0].Value = model.MadeID;
            //parameters[1].Value = model.CompanyID;
            //parameters[2].Value = model.Price;
            parameters[1].Value = model.SumPrice;
            //parameters[4].Value = model.UserName;
            //parameters[5].Value = model.CreateDate;
            parameters[2].Value = model.BeginTime;
            parameters[3].Value = model.EndTime;
            parameters[4].Value = model.LinkName;
            parameters[5].Value = model.TelPhone;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.Audit;
            parameters[8].Value = model.AuditName;
            parameters[9].Value = model.Remark;
            //parameters[13].Value = model.Hit;
            //parameters[14].Value = model.VisitHit;

          int num=Convert.ToInt32(crm.GetSingle(strSql.ToString(), parameters));
          return num;
        }
        /// <summary>
        /// 删除广告定制信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int MadeDelete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CompanyMadeTab ");
            strSql.Append(" where MadeID=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int num = Convert.ToInt32(crm.GetSingle(strSql.ToString(), parameters));
            return num;
        }

        /// <summary>
        /// 根据窄告编号查询出搜索表中ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string NarrowID(int Id)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select ID from NarrowSearchTab where AdID=@Id";
            SqlParameter[] para ={
                new SqlParameter("@Id",SqlDbType.Int,4)
            };
            para[0].Value = Id;
            DataSet ds = crm.Query(sql,para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append(""+row["ID"]+",");
                }
            }
            return sb.ToString();
        }
       

        /// <summary>
        /// 删除窄告信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int NarrowDelete(int id)
        {
            int num = 0;
            string[] values = NarrowID(id).Split(',');
            for (int i = 0; i < values.Length - 1; i++)
            {
                int com = Convert.ToInt32(values[i]);
                string sqlS = "delete from NarrowSearchTab where ID=@com";
                SqlParameter[] paraS ={ 
                   new SqlParameter("@com",SqlDbType.Int,4)
                };
                paraS[0].Value = com;
                int dt = Convert.ToInt32(crm.GetSingle(sqlS, paraS));
            }
            string sql = "delete from NarrowAdInfoTab where AdID=@Id";
            SqlParameter[] para ={ 
                new SqlParameter("@Id",SqlDbType.Int,4) 
            };
            para[0].Value = id;
            num = Convert.ToInt32(crm.GetSingle(sql, para));
            return num;
        }
        /// <summary>
        /// 查询所对应的窄告条件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NarrowModel SelNarrow(int id)
        {
            NarrowModel model = new NarrowModel();
            string sql = "select CreateDate,Title,Descript,Url,InfoTypeName,ProvinceID from NarrowAdInfoTab where AdID=@id";
            SqlParameter[] para ={ 
                new SqlParameter("@id",SqlDbType.Int,4)
            };
            para[0].Value = id;
            DataSet ds = crm.Query(sql, para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Descript = ds.Tables[0].Rows[0]["Descript"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                model.InfoTypeName = ds.Tables[0].Rows[0]["InfoTypeName"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                return model;
            }
            else
            {
                return null;
            }

        }
        #endregion
    }
}
