using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.IDAL.news;

namespace Tz888.BLL.news
{
    public class NewsTypeTabBLL
    {
        Tz888.SQLServerDAL.news.NewsTypeTabDAL newstabdal = new Tz888.SQLServerDAL.news.NewsTypeTabDAL();
        public List<Tz888.Model.NewsTypeTab> GetAllNewsType()
        {
            return newstabdal.GetAllNewsType();
        }
        public Tz888.Model.NewsTypeTab GetNewsTypeByTypeId(int typeId)
        {
            return newstabdal.GetNewsTypeByTypeId(typeId);
        }
        public int InsertNewTypeTab(Tz888.Model.NewsTypeTab newstypetab)
        {
            return newstabdal.InsertNewTypeTab(newstypetab);
        }
        public int UpdateNewTypeTab(Tz888.Model.NewsTypeTab newstypetab)
        {
            return newstabdal.UpdateNewTypeTab(newstypetab);
        }
    }
}
