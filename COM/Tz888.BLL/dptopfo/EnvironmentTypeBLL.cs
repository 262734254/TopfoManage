using System;
using System.Collections.Generic;
using System.Text;

namespace GZS.BLL
{
   public class EnvironmentTypeBLL
    {
       GZS.DAL.EnvironmentTypeDAL dal = new GZS.DAL.EnvironmentTypeDAL();
       public List<GZS.Model.EnvironmentTypeM> GetAllType()
       {
           return dal.GetAllType();
       }
    }
}
