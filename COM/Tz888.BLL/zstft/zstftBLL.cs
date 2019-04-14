using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.zstft;
using System.Data;

namespace Tz888.BLL.zstft
{
    /// <summary>
    /// ’–…ÃÕÿ∏£Õ®
    /// </summary>
    public class zstftBLL
    {
        private readonly Tz888.SQLServerDAL.zstft.zstftDAL dal = new Tz888.SQLServerDAL.zstft.zstftDAL();
        public bool Add(zstftModel M)
        {
            return dal.Add(M);
        }

        public bool Update(zstftModel M)
        {
            return dal.Update(M);
        }

        public bool Delete(string Id)
        {
            return dal.Delete(Id);
        }

        public DataTable GetAllzstft(string Category)
        {
            return dal.GetAllzstft(Category);
        }

        public DataTable Getzstft(string Id)
        {
            return dal.Getzstft(Id);
        }

        public bool DelzstftByIds(string Id)
        {
            return dal.DelzstftByIds(Id);
        }

        public int GetCount(string Category)
        {
            return dal.GetCount(Category);
        }

        public DataTable GetzstftList(string ObjectName, string Key, string ShowFiled, string Where, string OrderFiled, ref int PageCurrent, int PageSize, ref int TotalCount)
        {
            return dal.GetzstftList(ObjectName, Key, ShowFiled, Where, OrderFiled, ref PageCurrent, PageSize, ref TotalCount);
        }
    }
}
