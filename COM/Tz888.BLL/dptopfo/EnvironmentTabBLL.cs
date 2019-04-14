using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model;

namespace GZS.BLL
{
    public class EnvironmentTabBLL
    {
        GZS.DAL.EnvironmentTabDAL dal = new GZS.DAL.EnvironmentTabDAL();
        public int Insert(GZS.Model.EnvironmentTabM model)
        {
            return dal.Insert(model);
        }
        public int CountByLoginNameandTypeid(string loginname, int environmentid)
        {
            return dal.CountByLoginNameandTypeid(loginname ,environmentid);
        }
        public EnvironmentTabM EnvironmentlistByLoginNameandTypeid(string loginname, int environmentid)
        {
            return dal.EnvironmentlistByLoginNameandTypeid(loginname ,environmentid);
        }
        public int StaticHtml(string loginname)
        {
            return dal.StaticHtml(loginname);
        }
        public GZS.Model.EnvironmentTabM GetModel(int id)
        {
            return dal.GetModel(id);
        }
        public int Update(EnvironmentTabM model)
        {
            return dal.Update(model);
        }
        public int StaticHtmls(string loginname)
        {
            return dal.StaticHtmls(loginname);
        }
    }
}
