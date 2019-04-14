using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Mail
{
    public class MailTypeBLL
    {
        Tz888.SQLServerDAL.Mail.MailTypeDAL dal = new Tz888.SQLServerDAL.Mail.MailTypeDAL();
        public int Add(Tz888.Model.Mail.MailType model)
        {
            return dal.Add(model);
        }
        public int Update(Tz888.Model.Mail.MailType model)
        {
            return dal.Update(model);
        }
        public int Delete(int typeID)
        {
            return dal.Delete(typeID);
        }
        public Tz888.Model.Mail.MailType GetModel(int typeID)
        {
            return dal.GetModel(typeID);
        }
        public List<Tz888.Model.Mail.MailType> GetModelList()
        {
            return dal.GetModelList();
        }
        public Tz888.Model.Mail.MailType GetModelByTypeName(string TypeName)
        {
            return dal.GetModelByTypeName(TypeName);
        }
    }
}
