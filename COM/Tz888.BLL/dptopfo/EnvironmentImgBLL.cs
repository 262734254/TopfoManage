using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL
{
    public class EnvironmentImgBLL
    {
        GZS.DAL.EnvironmentImgDAL dal = new GZS.DAL.EnvironmentImgDAL();
        public int Insert(GZS.Model.EnvironmentImgM model)
        {
            return dal.Insert(model);
        }
        public List<GZS.Model.EnvironmentImgM> GetAllByEnvironmentTabId(int EnviromentId)
        {
            return dal.GetAllByEnvironmentTabId(EnviromentId);
        }
        public void Delete(int Environmenttabid)
        {
             dal.Delete(Environmenttabid);
        }
    }


}
