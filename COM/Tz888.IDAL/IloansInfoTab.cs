using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IloansInfoTab
    {
        int InsertLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab, Tz888.Model.LoansInfo loansinfo, Tz888.Model.LoanscontactsTab loanscontactstab);
        List<Tz888.Model.LoansInfoTab> GetAllInfoTabByLoginName(string name);
        Tz888.Model.LoansInfoTab GetLoansInfoTabByLoansInfoId(int LoansInfoId);
        int UpdateLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab);
       
        int DeleteLoansInfoTab(int loansInfoID);
        int ShenHeLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab);
     
    }
}
