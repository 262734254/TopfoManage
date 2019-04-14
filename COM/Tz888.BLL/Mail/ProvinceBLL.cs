using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Mail
{
    public class ProvinceBLL
    {
        Tz888.SQLServerDAL.Mail.ProvinceDAL dal = new Tz888.SQLServerDAL.Mail.ProvinceDAL();
        public int Add(Tz888.Model.Mail.Province model)
        {
            return dal.Add(model);
        }
        public List<Tz888.Model.Mail.Province> GetModelList()
        {
            return dal.GetModelList();
        }
        public Tz888.Model.Mail.Province GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        public Tz888.Model.Mail.Province GetModelByName(string Name)
        {
            return dal.GetModelByName(Name);
        }
    }
}
