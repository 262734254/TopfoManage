using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.report;
using Tz888.DALFactory;
using Tz888.Model.report;
namespace Tz888.BLL.report
{
    public class reportViewBLL
    {
        private readonly IreportView dal = DataAccess.CreateIreportView();
        public int DeletereportView(int Id)
        {
            return dal.DeletereportView(Id);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="report"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public bool UpdateReport(ReportTab report, ReportView view)
        {
            return dal.UpdateReport(report, view);
        }
        /// <summary>
        /// 向两个表中插入数据
        /// </summary>
        /// <param name="report"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public int InsertReport(ReportTab report, ReportView view)
        {
            return dal.InsertReport(report, view);
        }
        public ReportView GetModel(int reportID)
        {
            return dal.GetModel(reportID);
        }
    }
}
