using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL
{
    public class ImageTabMBLL
    {
        GZS.DAL.ImageTabMDAL dal = new GZS.DAL.ImageTabMDAL();
        public int Add(GZS.Model.ImageTabM model)
        {
            return dal.Add(model);
        }
        public List<GZS.Model.ImageTabM> GetAll(string loginname)
        {
            return dal.GetAll(loginname);
        }
        public GZS.Model.ImageTabM GetModel(int imageid)
        {
            return dal.GetModel(imageid);
        }
        public int UpdateImageTab(GZS.Model.ImageTabM model)
        {
            return dal.UpdateImageTab(model);
        }
        public int UpdateImageTabHtmlUrl(int id, string htmlurl)
        {
            return dal.UpdateImageTabHtmlUrl(id,htmlurl);
        }
        public int StaticHtml(int id, string loginname)
        {//
            return dal.StaticHtml(id, loginname);
        }
        public int StaticHtmls(int id, string loginname)
        {
            return dal.StaticHtmls(id, loginname);
        }
        public int StaticHtmlshouye(string loginname)
        {
            return dal.StaticHtmlshouye(loginname);
        }
        public void Delete(int imageid)
        {
            dal.Delete(imageid);
        }
    }
}
