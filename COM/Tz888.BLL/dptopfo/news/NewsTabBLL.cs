using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL.news
{
    public class NewsTabBLL
    {
        GZS.DAL.news.NewsTabDAL newstabdal = new GZS.DAL.news.NewsTabDAL();
        public int InsertNewsTab(GZS.Model.news.NewsTab newstab, GZS.Model.news.NewsTypeTab newstypetab, GZS.Model.news.NewsViewTab newsviewtab)
        {
            return newstabdal.InsertNewsTab(newstab,newstypetab ,newsviewtab);
        }
        public GZS.Model.news.NewsTab GetNewsTabByNewId(int NewId)
        {
            return newstabdal.GetNewsTabByNewId(NewId);
        }
        public int DeleteNewsTab(int Newsid)
        {
            return newstabdal.DeleteNewsTab(Newsid);
        }
        public int UpdateNewsTab(GZS.Model.news.NewsTab newstab, int newsid)
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
        public List<GZS.Model.news.NewsTab> GetNewsTabAllByUserName(string UserName)
        {
            return newstabdal.GetNewsTabAllByUserName(UserName);
        }
        public int StaticHtml(string loginname)
        {
            return newstabdal.StaticHtml(loginname);
        }
    }
}
