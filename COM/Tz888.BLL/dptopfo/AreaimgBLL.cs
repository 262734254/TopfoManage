using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL
{
   public class AreaimgBLL
    {
       GZS.DAL.AreaimgDAL dal = new GZS.DAL.AreaimgDAL();
       public List<GZS.Model.Areaimg> GetAllModelByareId(int id)
       {
           return dal.GetAllModelByareId(id);
       }
       public void Delete(int areaid)
       {
           dal.Delete(areaid);
       }
       public int Inserts(GZS.Model.Areaimg model)
       {
           return dal.Inserts(model);
       }
    }
}
