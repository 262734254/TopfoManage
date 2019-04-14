using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Tz888.SQLServerDAL.Resource
{
    public class ResourceDAL:Tz888.IDAL.Resource.IResource
    {
        private readonly Tz888.DBUtility.CrmDBHelper CrmDB = new Tz888.DBUtility.CrmDBHelper();

        #region ICRM 成员
        /// <summary>
        /// 修改CRM
        /// </summary>
        /// <param name="crm">CRM</param>
        /// <returns></returns
        public bool ModfiyResource(string DeclarationId)
        {
            string sql = "update Resource set Status=@Status where @DeclarationId=DeclarationId";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@Status",SqlDbType.Int,4),
               new SqlParameter("@DeclarationId",SqlDbType.Int,4)
            };
            Paras[0].Value = 1;
            Paras[1].Value = DeclarationId;
            int row = CrmDB.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        //public bool ModfiyCRM(Tz888.Model.CRM.CRM crm)
        //{
        //    string sql = "update CRM set [Title]=@Title,[Identity]=@Identity,[Industry]=@Industry,[ProvinceId]=@Province,[CityId]=@CityId" +
        //        "[Funds]=@Funds,[Explain]=@Explain,[Contact]=@Contact,[Phone]=@Phone,[Email]=@Email,[Status]=@Status," +
        //        "[Remarks]=@Remarks,[UserName]=@UserName where @DeclarationId=DeclarationId";
        //    SqlParameter[] Paras = new SqlParameter[] { 
        //         new SqlParameter("@Title",SqlDbType.VarChar,100),
        //         new SqlParameter("@Identity",SqlDbType.VarChar,100),
        //         new SqlParameter("@Industry",SqlDbType.Char,10),
        //         new SqlParameter("@ProvinceId",SqlDbType.Int,4),
        //         new SqlParameter("@CityId",SqlDbType.Int,4),
        //         new SqlParameter("@Funds",SqlDbType.VarChar,100),
        //         new SqlParameter("@Explain",SqlDbType.NVarChar,200),
        //         new SqlParameter("@Contact",SqlDbType.VarChar,100),
        //         new SqlParameter("@Phone",SqlDbType.VarChar,100),
        //         new SqlParameter("@Email",SqlDbType.VarChar,100),
        //         new SqlParameter("@Status",SqlDbType.VarChar,100),
        //         new SqlParameter("@Remarks",SqlDbType.VarChar,100),
        //         new SqlParameter("@UserName",SqlDbType.VarChar,100),
        //         new SqlParameter("@DeclarationId",SqlDbType.Int,4)
        //    };
        //    Paras[0].Value = crm.Title;
        //    Paras[1].Value = crm.Identity;
        //    Paras[2].Value = crm.Industry;
        //    Paras[3].Value = crm.ProvinceId;
        //    Paras[4].Value = crm.CityId;
        //    Paras[5].Value = crm.Funds;
        //    Paras[6].Value = crm.Explain;
        //    Paras[7].Value = crm.Contact;
        //    Paras[8].Value = crm.Phone;
        //    Paras[9].Value = crm.Email;
        //    Paras[10].Value = crm.Status;
        //    Paras[11].Value = crm.Remarks;
        //    Paras[12].Value = crm.UserName;
        //    Paras[13].Value = crm.DeclarationId;
        //    int row = CrmDB.ExecuteSql(sql, Paras);
        //    if (row > 0)
        //        return true;
        //    else
        //        return false;
        //}

        /// <summary>
        /// CRM详情
        /// </summary>
        /// <param name="DeclarationId">DeclarationId</param>
        /// <returns></returns>
        public DataTable GetResourceDetail(string DeclarationId)
        {
            string sql = "select * from V_GetCrmDetail where DeclarationId=@DeclarationId";
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@DeclarationId",SqlDbType.Int,4)
            };
            Paras[0].Value = DeclarationId;
            return CrmDB.GetDataSet(sql, Paras);
        }

        /// <summary>
        /// 删除CRM
        /// </summary>
        /// <param name="DeclarationId">DeclarationId</param>
        /// <returns></returns>
        public bool DelResource(string DeclarationId)
        {
            string sql = "delete Resource where @DeclarationId=DeclarationId";
            SqlParameter[] Paras = new SqlParameter[] { 
                 new SqlParameter("@DeclarationId",SqlDbType.Int,4)
            };
            Paras[0].Value = DeclarationId;
            int row = CrmDB.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// CRM列表
        /// </summary>
        /// <param name="ObjectName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="ShowFiled">显示字段</param>
        /// <param name="Where">条件</param>
        /// <param name="OrderFiled">排序字段</param>
        /// <param name="PageCurrent">当前页码</param>
        /// <param name="PageSize">页码大小</param>
        /// <param name="TotalCount">总条数</param>
        /// <returns></returns>
        public DataTable GetResourceList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
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

            DataSet ds = CrmDB.RunProcedure("GetDataList", parameters, "ds");

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
        #endregion
    }
}
