using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Mail
{
    public class PositionBLL
    {
        Tz888.SQLServerDAL.Mail.PositionDAL dal = new Tz888.SQLServerDAL.Mail.PositionDAL();
        public int Add(Tz888.Model.Mail.Position model)
        {
            return dal.Add(model);
        }
        public List<Tz888.Model.Mail.Position> GetModelList()
        {
            return dal.GetModelList();
        }
        public Tz888.Model.Mail.Position GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        public Tz888.Model.Mail.Position GetModelByName(string Name)
        {
            return dal.GetModelByName(Name);
        }
        public int Update(Tz888.Model.Mail.Position model)
        {
            return dal.Update(model);
        }
    }
}
