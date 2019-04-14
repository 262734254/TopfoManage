using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.zstft;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.zstft
{
    /// <summary>
    /// ’–…ÃÕÿ∏ªÕ®
    /// </summary>
    public class zstftDAL
    {
        private readonly Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
        public bool Add(zstftModel M)
        {
            int row = 0;
            try
            {
                string sql = "insert into zstft(Title,Category,Address,LogName,PublishTime,Picture,Remark,ProvinceName,Sort) values(@Title,@Category,@Address,@LogName,@PublishTime,@Picture,@Remark,@ProvinceName,@Sort)";
                SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Title",SqlDbType.VarChar,200),                     
                new SqlParameter("@Category",SqlDbType.VarChar,50),
                new SqlParameter("@Address",SqlDbType.VarChar,200),
                new SqlParameter("@LogName",SqlDbType.VarChar,50),
                new SqlParameter("@PublishTime",SqlDbType.DateTime),
                new SqlParameter("@Picture",SqlDbType.VarChar,200),
                new SqlParameter("@Remark",SqlDbType.VarChar,500),
                new SqlParameter("@ProvinceName",SqlDbType.VarChar,50),
                new SqlParameter("@Sort",SqlDbType.Int)
            };
                Paras[0].Value = M.Title;
                Paras[1].Value = M.Category;
                Paras[2].Value = M.Address;
                Paras[3].Value = M.LogName;
                Paras[4].Value = M.PublishTime;
                Paras[5].Value = M.Picture;
                Paras[6].Value = M.Remark;
                Paras[7].Value = M.ProvinceName;
                Paras[8].Value = M.Sort;
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

        public bool Update(zstftModel M)
        {
            int row = 0;
            try
            {
                string sql = "update zstft set Category=@Category,Address=@Address,Picture=@Picture,LogName=@LogName,Remark=@Remark,Title=@Title,ProvinceName=@ProvinceName,Sort=@Sort where Id=@Id";
                SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Category",SqlDbType.VarChar,50),
                new SqlParameter("@Address",SqlDbType.VarChar,200),
                new SqlParameter("@LogName",SqlDbType.VarChar,50),
                new SqlParameter("@Picture",SqlDbType.VarChar,200),
                new SqlParameter("@Remark",SqlDbType.VarChar,500),
                new SqlParameter("@Title",SqlDbType.VarChar,200),
                new SqlParameter("@ProvinceName",SqlDbType.VarChar,50),
                new SqlParameter("@Sort",SqlDbType.Int),
                new SqlParameter("@Id",SqlDbType.Int,4)
            };

                Paras[0].Value = M.Category;
                Paras[1].Value = M.Address;
                Paras[2].Value = M.LogName;
                Paras[3].Value = M.Picture;
                Paras[4].Value = M.Remark;
                Paras[5].Value = M.Title;
                Paras[6].Value = M.ProvinceName;
                Paras[7].Value = M.Sort;
                Paras[8].Value = M.Id;
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
                string sql = "delete zstft where Id=@Id";
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

        public int GetCount(string Category)
        {
            string sql = "select count(*) from zstft where Category='" + Category + "'";
            return Convert.ToInt32(crm.GetSingle(sql));
        }

        public DataTable GetAllzstft(string Category)
        {
            DataTable dt = null;
            string sql = "select * from zstft where Category='" + Category + "'";
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

        public DataTable Getzstft(string Id)
        {
            DataTable dt = null;
            string sql = "select * from zstft where Id=" + Id;
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

        public bool DelzstftByIds(string Id)
        {
            string sql = "delete zstft where Id in(" + Id + ")";
            int row = crm.ExecuteSql(sql);
            if (row > 0)
                return true;
            else
                return false;
        }

        public DataTable GetzstftList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
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
    }
}
