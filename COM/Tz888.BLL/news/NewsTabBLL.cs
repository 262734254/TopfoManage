using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.news
{
    public class NewsTabBLL
    {
        Tz888.SQLServerDAL.news.NewsTabDAL newstabdal = new Tz888.SQLServerDAL.news.NewsTabDAL();
        public int InsertNewsTab(Tz888.Model.NewsTab newstab, Tz888.Model.NewsTypeTab newstypetab, Tz888.Model.NewsViewTab newsviewtab)
        {
            return newstabdal.InsertNewsTab(newstab,newstypetab ,newsviewtab);
        }
        public Tz888.Model.NewsTab GetNewsTabByNewId(int NewId)
        {
            return newstabdal.GetNewsTabByNewId(NewId);
        }
        public int DeleteNewsTab(int Newsid)
        {
            return newstabdal.DeleteNewsTab(Newsid);
        }
        public int UpdateNewsTab(Tz888.Model.NewsTab newstab, int newsid)
        {
            return newstabdal.UpdateNewsTab(newstab,newsid);
        }
        public string GetMaxNewsId()
        {
            return newstabdal.GetMaxNewsId();
        }
        public int UpdateNewsTabUrl(string url, int newsid)
        {
            return newstabdal.UpdateNewsTabUrl(url,newsid);
        }
        public int UpdateNewsTabImageUrl(string url, int newsid)
        {
            return newstabdal.UpdateNewsTabImageUrl(url,newsid);
        }
    }
}
