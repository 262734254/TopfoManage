using System;
using System.Collections.Generic;
using System.Data;
using Tz888.Model.zsWebsite;

namespace Tz888.BLL.zsWebsite
{
    public class zsWebsiteBLL
    {
        private readonly Tz888.SQLServerDAL.zsWebsite.zsWebsiteDAL dal = new Tz888.SQLServerDAL.zsWebsite.zsWebsiteDAL();
        public bool Add(zsWebsiteModel M)
        {
            return dal.Add(M);
        }

        public bool Update(zsWebsiteModel M)
        {
            return dal.Update(M);
        }

        public bool Delete(string Id)
        {
            return dal.Delete(Id);
        }

        public DataTable GetAllzsWebsite()
        {
            return dal.GetAllzsWebsite();
        }

        public DataTable GetzsWebsite(string Id)
        {
            return dal.GetzsWebsite(Id);
        }

        public DataTable GetzsWebsiteList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            return dal.GetzsWebsiteList(ObjectName, Key, ShowFiled, Where, OrderFiled, ref PageCurrent, PageSize, ref TotalCount);
        }

        public DataTable GetProvicne()
        {
            return dal.GetProvicne();
        }
    }
}
