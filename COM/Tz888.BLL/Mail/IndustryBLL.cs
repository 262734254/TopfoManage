using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Mail
{
    public class IndustryBLL
    {
        Tz888.SQLServerDAL.Mail.IndustryDAL dal = new Tz888.SQLServerDAL.Mail.IndustryDAL();
        public int Add(Tz888.Model.Mail.Industry model) 
        {
            return dal.Add(model);
        }
        public int Update(Tz888.Model.Mail.Industry model, int id)
        {
            return dal.Update(model,id);
        }
        public List<Tz888.Model.Mail.Industry> GetModelList()
        {
            return dal.GetModelList();
        }
        public Tz888.Model.Mail.Industry GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        public Tz888.Model.Mail.Industry GetModelByName(string Name)
        {
            return dal.GetModelByName(Name);
        }
        public List<Tz888.Model.Mail.Industry> GetModelRepeater()
        {
            return dal.GetModelRepeater();
        }
    }
}
