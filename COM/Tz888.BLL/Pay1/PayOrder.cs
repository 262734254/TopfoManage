using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
namespace Tz888.BLL.Pay1
{
    /// <summary>
    /// PayOrder 的摘要说明。
    /// </summary>
    public class PayOrder
    {
        Tz888.SQLServerDAL.Pay1.PayOrder obj = new Tz888.SQLServerDAL.Pay1.PayOrder();

        #region 生成推广短信购买订单
        public int CreatePromotionOrder1(string LoginName, int smscount, int Id, float totalPrice, ref int mintErrorID, ref string mstrErrorMsg)
        {
            return obj.CreatePromotionOrder1(LoginName, smscount,Id, totalPrice, ref mintErrorID, ref mstrErrorMsg);
        }
        #endregion

    }
}
