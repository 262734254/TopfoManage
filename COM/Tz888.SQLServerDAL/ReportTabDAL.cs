using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    public class ReportTabDAL:IReportTab
    {
        #region ��Ӿٱ���Ϣ
        /// <summary>
        /// ��Ӿٱ���Ϣ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="Title"></param>
        /// <param name="content"></param>
        /// <param name="insertTime"></param>
        /// <returns></returns>
        public int addReportInfo(long InfoID, string Title, string content, string insertTime)
        {
            string SqlText = "insert into InfoReportTab(InfoID,ReportTime,ReportRemark,isCheck) values('" + InfoID + "','" + insertTime + "','" + content + "','0')";
            return DbHelperSQL.ExecuteSql(SqlText);
        }
        #endregion
    }
}
