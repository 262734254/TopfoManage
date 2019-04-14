using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL.news
{
   public class NewsViewTabBLL
    {
       GZS.DAL.news.NewsViewTabDAL newsviewtabdal = new GZS.DAL.news.NewsViewTabDAL();
       public GZS.Model.news.NewsViewTab GetNewsViewByNewId(int NewId)
       {
           return newsviewtabdal.GetNewsViewByNewId(NewId);
       }
       public int DeleteNewsViewTab(int Newsid)
       {
           return newsviewtabdal.DeleteNewsViewTab(Newsid);
       }
       public int UpdateNewsViewTab(GZS.Model.news.NewsViewTab newsviewtab, int newsid)
       {
           return newsviewtabdal.UpdateNewsViewTab(newsviewtab,newsid);
       }
    }
}
