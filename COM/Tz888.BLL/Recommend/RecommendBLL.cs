using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.BLL.Recommend
{
    public class RecommendBLL
    {
        private readonly Tz888.SQLServerDAL.Recommend.RecommendDAL dal = new Tz888.SQLServerDAL.Recommend.RecommendDAL();

        public bool AddRecommend(Tz888.Model.Recommend.RecommendModel model)
        {
            return dal.AddRecommend(model);
        }

        public bool ModfiyRecommend(Tz888.Model.Recommend.RecommendModel model)
        {
            return dal.ModfiyRecommend(model);
        }

        public bool DelRecommend(string Id)
        {
            return dal.DelRecommend(Id);
        }

        public DataTable GetRecommendDetail(string Id)
        {
            return dal.GetRecommendDetail(Id);
        }

        public DataTable GetRecommendList(string ObjectName,string Key,string ShowFiled,string Where,string OrderFiled,ref int PageCurrent,int PageSize,ref int TotalCount)
        {
            return dal.GetRecommendList(ObjectName, Key, ShowFiled, Where, OrderFiled, ref PageCurrent, PageSize, ref TotalCount);
        }
    }
}
