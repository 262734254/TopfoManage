using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.BLL.Resource
{

    public class ResourceBLL
    {
        private readonly Tz888.SQLServerDAL.Resource.ResourceDAL resource = new Tz888.SQLServerDAL.Resource.ResourceDAL();

        public bool ModfiyResource(string DeclarationId)
        {
            return resource.ModfiyResource(DeclarationId);
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
            return resource.GetResourceDetail(DeclarationId);
        }

        /// <summary>
        /// 删除CRM
        /// </summary>
        /// <param name="DeclarationId">DeclarationId</param>
        /// <returns></returns>
        public bool DelResource(string DeclarationId)
        {
            return resource.DelResource(DeclarationId);
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
            return resource.GetResourceList("Resource", "DeclarationId", "DeclarationId,Title,Contact,Status", Where, "DeclarationId desc", ref PageCurrent, PageSize, ref TotalCount);
        }
    }
}
