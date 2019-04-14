using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL
{
    public class AreaTabBLL
    {
        GZS.DAL.AreaTabDAL dal = new GZS.DAL.AreaTabDAL();
        public int InsertAreaTab(GZS.Model.AreaTab areatab, GZS.Model.Areaimg areaing)
        {
            return dal.InsertAreaTab(areatab, areaing);
        }
        public GZS.Model.AreaTab GetModelCountByLogName(string name)
        {
            return dal.GetModelCountByLogName(name);
        }
        public int UpdateAreatab(GZS.Model.AreaTab model)
        {
            return dal.UpdateAreatab(model);
        }
        public GZS.Model.AreaTab GetModel(int id)
        {
            return dal.GetModel(id);
        }
        public int StaticHtml(int id, string loaginnames)
        {

            return dal.StaticHtml(id, loaginnames);

        }
        public int StaticHtmls(string loginname)
        {
            return dal.StaticHtmls(loginname);
        }
    }
}
