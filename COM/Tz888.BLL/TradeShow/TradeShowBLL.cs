using System;
using System.Collections.Generic;
using System.Text;
using Tz888.SQLServerDAL.TradeShow;
using Tz888.Model.TradeShow;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.BLL.TradeShow
{
    public class TradeShowBLL
    {
        private readonly TradeShowDAL dal = new TradeShowDAL();
        public bool Add(TradeShowModel TradeShow)
        {
            return dal.Add(TradeShow);
        }

        public bool Modify(TradeShowModel TradeShow)
        {
            return dal.Modify(TradeShow);
        }

        public bool Del(int Id)
        {
            return dal.Del(Id);
        }

        public bool Del(string Id)
        {
            return dal.Del(Id);
        }

        public DataTable GetTradeShowById(string Id)
        {
            return dal.GetTradeShowById(Id);
        }

        public DataTable GetTradeShowList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            return dal.GetTradeShowList(ObjectName, Key, ShowFiled, Where, OrderFiled, ref PageCurrent, PageSize, ref TotalCount);
        }
    }
}
