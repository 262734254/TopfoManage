using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.BLL.PromotionInfo
{
    public class PromotionInfoTab
    {
        CrmDBHelper crm = new CrmDBHelper();
        public int AddPromotion(int id, string name, string remark)
        {
            int num = 0;
            string sql = "INSERT INTO [PromotionInfoTab] ([Coding],[PromotionName] ,[Remark]) VALUES "
                +"(@id,@name,@remark)";
            SqlParameter[] para ={ 
                 new SqlParameter("@id",SqlDbType.Int,4),
                new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@remark",SqlDbType.VarChar,1000)
            };
            para[0].Value = id;
            para[1].Value = name;
            para[2].Value = remark;
            num = Convert.ToInt32(crm.GetSingle(sql, para));
            return num;
        }

        public DataView SelPromotion()
        {
            string sql = "select * from PromotionInfoTab";
            DataSet ds = crm.ExecuteQuery(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }
    }
}
