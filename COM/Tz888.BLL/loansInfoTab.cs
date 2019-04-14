using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;

namespace Tz888.BLL
{
    public class loansInfoTab
    {
        private readonly IloansInfoTab dal = DataAccess.CreateILoansInfoTab();
        public int InsertLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab, Tz888.Model.LoansInfo loansinfo, Tz888.Model.LoanscontactsTab loanscontactstab)
        {
            return dal.InsertLoansInfoTab(loansinfotab, loansinfo, loanscontactstab);
        }
        public List<Tz888.Model.LoansInfoTab> GetAllInfoTabByLoginName(string name)
        {
            return dal.GetAllInfoTabByLoginName(name);
        }
        public Tz888.Model.LoansInfoTab GetLoansInfoTabByLoansInfoId(int LoansInfoId)
        {
            return dal.GetLoansInfoTabByLoansInfoId(LoansInfoId);
        }
        public int UpdateLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab)
        {
            return dal.UpdateLoansInfoTab(loansinfotab);
        }

        public int DeleteLoansInfoTab(int loansInfoID)
        {
            return dal.DeleteLoansInfoTab(loansInfoID);
        }
        public int ShenHeLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab)
        {
            return dal.ShenHeLoansInfoTab(loansinfotab);
        }

    }
}
