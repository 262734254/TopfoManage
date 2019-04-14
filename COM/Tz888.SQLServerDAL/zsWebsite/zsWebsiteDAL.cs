using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.zsWebsite;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.zsWebsite
{
    public class zsWebsiteDAL
    {
        private readonly Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();

        public bool Add(zsWebsiteModel M)
        {
            int row = 0;
            try
            {
                string sql = "insert into zsWebsite(LogName,WebsiteName,WebsiteUrl,ProvinceName,PublisTime,SiteContent,Remarks) values(@LogName,@WebsiteName,@WebsiteUrl,@ProvinceName,@PublisTime,@SiteContent,@Remarks)";
                SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@LogName",SqlDbType.VarChar,50),
                new SqlParameter("@WebsiteName",SqlDbType.VarChar,100),
                new SqlParameter("@WebsiteUrl",SqlDbType.VarChar,100),
                new SqlParameter("@ProvinceName",SqlDbType.VarChar,50),
                new SqlParameter("@PublisTime",SqlDbType.DateTime),
                new SqlParameter("@SiteContent",SqlDbType.VarChar,500),
                 new SqlParameter("@Remarks",SqlDbType.VarChar,500)
            };
                Paras[0].Value = M.LogName;
                Paras[1].Value = M.WebsiteName;
                Paras[2].Value = M.WebsiteUrl;
                Paras[3].Value = M.ProvinceName;
                Paras[4].Value = M.PublishTime;
                Paras[5].Value = M.SiteContent;
                Paras[6].Value = M.Remarks;
                row = crm.ExecuteSql(sql, Paras);
                if (row > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool Update(zsWebsiteModel M)
        {
            int row = 0;
            try
            {
                string sql = "update zsWebsite set WebsiteName=@WebsiteName,WebsiteUrl=@WebsiteUrl,ProvinceName=@ProvinceName,SiteContent=@SiteContent,Remarks=@Remarks where Id=@Id";
                SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@WebsiteName",SqlDbType.VarChar,100),
                new SqlParameter("@WebsiteUrl",SqlDbType.VarChar,100),
                new SqlParameter("@ProvinceName",SqlDbType.VarChar,50),
                new SqlParameter("@Id",SqlDbType.Int,4),
                new SqlParameter("@SiteContent",SqlDbType.VarChar,500),
                    new SqlParameter("@Remarks",SqlDbType.VarChar,500)
            };
                
                Paras[0].Value = M.WebsiteName;
                Paras[1].Value = M.WebsiteUrl;
                Paras[2].Value = M.ProvinceName;
                Paras[3].Value = M.Id;
                Paras[4].Value = M.SiteContent;
                Paras[5].Value = M.Remarks;
                row = crm.ExecuteSql(sql, Paras);
                if (row > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool Delete(string Id)
        {
            int row = 0;
            try
            {
                string sql = "delete zsWebsite where Id=@Id";
                SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int,4),
            };
                Paras[0].Value = Id;
                row = crm.ExecuteSql(sql, Paras);
                if (row > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable GetAllzsWebsite()
        {
            DataTable dt = null;
            string sql = "select * from zsWebSite";
            try
            {
                DataSet ds = crm.ExecuteQuery(sql);
                if (ds != null && ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            return dt;
        }

        public DataTable GetzsWebsite(string Id)
        {
            DataTable dt = null;
            string sql = "select * from zsWebsite where Id=" + Id;
            try
            {
                DataSet ds = crm.ExecuteQuery(sql);
                if (ds != null && ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }

        public DataTable GetzsWebsiteList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = ObjectName;
            parameters[1].Value = Key;
            parameters[2].Value = ShowFiled;
            parameters[3].Value = Where;
            parameters[4].Value = OrderFiled;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = PageCurrent;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;

            DataSet ds = crm.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt32(parameters[7].Value);
                    PageCurrent = Convert.ToInt32(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt32(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        PageCurrent = 1;
                    }
                    else
                    {
                        PageCurrent = 0;
                    }
                }
            }
            return dt;
        }


        public DataTable GetProvicne()
        {
            DataTable dt = null;
            string sql = "SELECT DISTINCT ProvinceName FROM zsWebsite";
            try
            {
                DataSet ds = crm.ExecuteQuery(sql);
                if (ds != null && ds.Tables.Count > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return dt;
        }
    }
}
