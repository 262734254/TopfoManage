using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.report;
using Tz888.DALFactory;
using Tz888.Model.report;

namespace Tz888.BLL.report
{
    public class reportTabBLL
    {
        private readonly IreportTab dal = DataAccess.CreateIreportTab();
        public int DeletereportTab(int Id)
        {
            return dal.DeletereportTab(Id);
        }
        public ReportTab GetModel(int reportID)
        {
            return dal.GetModel(reportID);
        }
        /// <summary>
        /// ∑√Œ ¬ 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyHit(int id)
        {
            return dal.ModfiyHit(id);
        }

    }

}
