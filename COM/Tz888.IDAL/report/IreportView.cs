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
        /// ����һ������
        /// </summary>
        /// <param name="report"></param>
        /// <param name="view"></param>
        /// <returns></returns>
       bool UpdateReport(ReportTab report, ReportView view);
       /// <summary>
        /// ���������в�������
        /// </summary>
        /// <param name="report"></param>
        /// <param name="view"></param>
        /// <returns></returns>
       int InsertReport(ReportTab report, ReportView view);
       ReportView GetModel(int Reportviewid);
        
    }
}
