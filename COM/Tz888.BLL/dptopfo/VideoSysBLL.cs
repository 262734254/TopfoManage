using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL
{
    public class VideoSysBLL
    {
        GZS.DAL.VideoSysDAL dal = new GZS.DAL.VideoSysDAL();
        public int Insert(GZS.Model.VideoSysM model)
        {
            return dal.Insert(model);
        }
        public GZS.Model.VideoSysM GetModel(int videoid)
        {
            return dal.GetModel(videoid);
        }
        public int Update(GZS.Model.VideoSysM model)
        {
            return dal.Update(model);
        }
        public List<GZS.Model.VideoSysM> GetAllModel(string loginname)
        {
            return dal.GetAllModel(loginname);
        }
        public List<GZS.Model.VideoSysM> GetTopModel(string loginname)
        {
            return dal.GetTopModel(loginname);
        }
        public int Delete(int id)
        {
            return dal.Delete(id);
        }
        public int UpdateHtml(string htmlurl, int id)
        {
            return dal.UpdateHtml(htmlurl ,id);
        }
        public int UpdateHtmls(string htmlurl, string loginname)
        {
            return dal.UpdateHtmls(htmlurl ,loginname);
        }
    }
}
