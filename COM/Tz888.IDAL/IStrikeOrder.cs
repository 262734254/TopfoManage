using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IStrikeOrder
    {
        int CreateStrikeOrder(Tz888.Model.StrikeOrder model);

        bool StrikeOrderDelete(string OrderNO);

        bool StrikeSuccess(string OrderNO, string PayType,string tradeNo, string OperationMan);

        bool RechargeCardSuccess(string OrderNO, string PayType, string tradeNo, string OperationMan,string Number,int Free);

        int CardStrike(string LoginName, long CardNo, string CardPwd, string changeBy, string Remark);

        bool StrikeOrderConfirmed(string OrderNO, string PayType, string tradeNo, string OperationMan, double StrikeMoney);
    }
}
