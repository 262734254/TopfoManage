using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.report;
namespace Tz888.IDAL.report
{
    public interface IreportTab
    {
        int DeletereportTab(int Id);
        ReportTab GetModel(int reportID);
        /// <summary>
        /// ∑√Œ ¬ 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ModfiyHit(int id);
        
    }
}
