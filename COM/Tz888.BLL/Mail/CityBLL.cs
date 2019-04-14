using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Mail
{
    public class CityBLL
    {
        Tz888.SQLServerDAL.Mail.CityDAL dal = new Tz888.SQLServerDAL.Mail.CityDAL();
        public int Add(Tz888.Model.Mail.City model) 
        {
            return dal.Add(model);
        }
        public List<Tz888.Model.Mail.City> GetModelList(int provinceId)
        {
            return dal.GetModelList(provinceId);
        }
        public Tz888.Model.Mail.City GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        public Tz888.Model.Mail.City GetModelByName(string Name)
        {
            return dal.GetModelByName(Name);
        }
    }
}
