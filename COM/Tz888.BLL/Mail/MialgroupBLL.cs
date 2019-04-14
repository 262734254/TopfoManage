using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Mail
{
    public class MialgroupBLL
    {
        Tz888.SQLServerDAL.Mail.MialgroupDAL dal = new Tz888.SQLServerDAL.Mail.MialgroupDAL();
        public int Add(Tz888.Model.Mail.Mialgroup model)
        {
            return dal.Add(model);
        }
        public int Update(Tz888.Model.Mail.Mialgroup model)
        {
            return dal.Update(model);
        }
        public int Delete(int groupID)
        {
            return dal.Delete(groupID);
        }
        public Tz888.Model.Mail.Mialgroup GetModel(int groupID)
        {
            return dal.GetModel(groupID);
        }
        public List<Tz888.Model.Mail.Mialgroup> GetModelList()
        {
            return dal.GetModelList();
        }
        public Tz888.Model.Mail.Mialgroup GetModelByName(string groupname)
        {
            return dal.GetModelByName(groupname);
        }
    }
}
