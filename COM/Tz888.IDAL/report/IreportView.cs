using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.report;
namespace Tz888.IDAL.report
{
   public interface IreportView
    {
       int DeletereportView(int Id);
          /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="report"></param>
        /// <param name="view"></param>
        /// <returns></returns>
       bool UpdateReport(ReportTab report, ReportView view);
       /// <summary>
        /// 向两个表中插入数据
        /// </summary>
        /// <param name="report"></param>
        /// <param name="view"></param>
        /// <returns></returns>
       int InsertReport(ReportTab report, ReportView view);
       ReportView GetModel(int Reportviewid);
        
    }
}
