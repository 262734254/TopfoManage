using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL.news
{
    public class NewsTypeTabBLL
    {
        GZS.DAL.news.NewsTypeTabDAL newstabdal = new GZS.DAL.news.NewsTypeTabDAL();
        public List<GZS.Model.news.NewsTypeTab> GetAllNewsType()
        {
            return newstabdal.GetAllNewsType();
        }
        public GZS.Model.news.NewsTypeTab GetNewsTypeByTypeId(int typeId)
        {
            return newstabdal.GetNewsTypeByTypeId(typeId);
        }
        public int InsertNewTypeTab(GZS.Model.news.NewsTypeTab newstypetab)
        {
            return newstabdal.InsertNewTypeTab(newstypetab);
        }
        public int UpdateNewTypeTab(GZS.Model.news.NewsTypeTab newstypetab)
        {
            return newstabdal.UpdateNewTypeTab(newstypetab);
        }
    }
}
