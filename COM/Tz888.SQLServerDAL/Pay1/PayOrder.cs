using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Tz888.IDAL.LoginInfo;
using Tz888.DBUtility;
using System.Security.Cryptography;

namespace Tz888.SQLServerDAL.Pay1
{
    /// <summary>
    /// PayOrder 的摘要说明。
    /// </summary>
    public class PayOrder : ErrorBase
    {

        #region 生成推广短信购买订单
        public int CreatePromotionOrder1(string LoginName, int smscount, int Id, float totalPrice, ref int mintErrorID, ref string mstrErrorMsg)
        {

            SqlParameter[] parameters = {
											
											new SqlParameter("@smscount", SqlDbType.Int),
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@sId", SqlDbType.Int),
											new SqlParameter("@TotalPrice", SqlDbType.Float,8),
											new SqlParameter("@OrderNo", SqlDbType.Int),
			};
            parameters[0].Value = smscount;
            parameters[1].Value = LoginName;
            parameters[2].Value = Id;
            parameters[3].Value = totalPrice;
            parameters[4].Direction = ParameterDirection.Output;

            int orderid = DbHelperSQL.RunProcReturn("ShopCarTab_Order_Promotion1", parameters);
            return orderid;
        }
        #endregion

    }
}
