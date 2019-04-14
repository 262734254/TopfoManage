using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.BLL.Mail
{
    public class MailInfoBLL
    {
        Tz888.SQLServerDAL.Mail.MailInfoDAL dal = new Tz888.SQLServerDAL.Mail.MailInfoDAL();
        public int Add(Tz888.Model.Mail.MailInfo model)
        {
            return dal.Add(model);
        }
        public int Update(Tz888.Model.Mail.MailInfo model)
        {
            return dal.Update(model);
        }
        public int Delete(int UserID)
        {
            return dal.Delete(UserID);
        }
        public Tz888.Model.Mail.MailInfo GetModel(int UserID)
        {
            return dal.GetModel(UserID);
        }
        public List<Tz888.Model.Mail.MailInfo> GetModelList(string par)
        {
            return dal.GetModelList(par);
        }
        public DataTable GetDataTable(string par)
        {
            return dal.GetDataTable(par);
        }
        #region //����������ϢID �ʼ�
        public int InsertEmail(int infoID)
        {
            return dal.InsertEmail(infoID);
        }

        #endregion
        #region//��ȡ������Ϣ����
        public DataSet SelDataSet()
        {
            return dal.SelDataSet();
        }
        #endregion

        #region//ɾ��һ�� EMAIL��������
        public int DelEmail(int userind)
        {
            return dal.DelEmail(userind);
        }
        #endregion
    }
}
