using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL
{
    public class VideoSysPagestaticBLL
    {
        GZS.DAL.VideoSysPagestaticDAL dal = new GZS.DAL.VideoSysPagestaticDAL();
        public int StaticHtml(int id, string loginname)
        {
            return dal.StaticHtml(id, loginname);
        }
    }
}
