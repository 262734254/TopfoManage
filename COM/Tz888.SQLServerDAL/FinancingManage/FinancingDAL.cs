using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.FinancingManage
{
    //��������
    public class FinancingDAL
    {
        //��ȡ��ҵ����
        public string GetInduyName(string Induy)
        {
            string InduyName = "";
            switch (Induy)
            {
                case "#": InduyName = "��������"; break;
                case "$": InduyName = "���ز�ҵ"; break;
                case "*": InduyName = "������ҵ"; break;
                case "A": InduyName = "ũ������"; break;
                case "B": InduyName = "ʳƷ����"; break;
                case "C": InduyName = "ұ����"; break;
                case "D": InduyName = "��е����"; break;
                case "E": InduyName = "��������"; break;
                case "F": InduyName = "��Դ����"; break;
                case "G": InduyName = "ʯ�ͻ���"; break;
                case "H": InduyName = "��֯��װ"; break;
                case "I": InduyName = "��������"; break;
                case "J": InduyName = "ҽ�Ʊ���"; break;
                case "K": InduyName = "����Ƽ�"; break;
                case "L": InduyName = "������ѵ"; break;
                case "M": InduyName = "ӡˢ����"; break;
                case "N": InduyName = "��洫ý"; break;
                case "O": InduyName = "Ӱ������"; break;
                case "P": InduyName = "����ͨѶ"; break;
                case "Q": InduyName = "��������"; break;
                case "R": InduyName = "��Ϣ��ҵ"; break;
                case "S": InduyName = "���¼���"; break;
                case "T": InduyName = "������ʩ"; break;
                case "U": InduyName = "��ͨ����"; break;
                case "V": InduyName = "�����ִ�"; break;
                case "W": InduyName = "��������"; break;
                case "X": InduyName = "��������"; break;
                case "Y": InduyName = "������"; break;
                case "Z": InduyName = "�Ƶ����"; break;
            }
            return InduyName;
        }

        //��ȡ��ҵID
        public string GetIndustryBID(string Induy)
        {
            string IndustryBID = "";
            switch (Induy)
            {
                case "#": IndustryBID = "0"; break;
                case "$": IndustryBID = "1"; break;
                case "*": IndustryBID = "2"; break;
                case "A": IndustryBID = "3"; break;
                case "B": IndustryBID = "4"; break;
                case "C": IndustryBID = "5"; break;
                case "D": IndustryBID = "6"; break;
                case "E": IndustryBID = "7"; break;
                case "F": IndustryBID = "8"; break;
                case "G": IndustryBID = "9"; break;
                case "H": IndustryBID = "10"; break;
                case "I": IndustryBID = "11"; break;
                case "J": IndustryBID = "12"; break;
                case "K": IndustryBID = "13"; break;
                case "L": IndustryBID = "14"; break;
                case "M": IndustryBID = "15"; break;
                case "N": IndustryBID = "16"; break;
                case "O": IndustryBID = "17"; break;
                case "P": IndustryBID = "18"; break;
                case "Q": IndustryBID = "19"; break;
                case "R": IndustryBID = "20"; break;
                case "S": IndustryBID = "21"; break;
                case "T": IndustryBID = "22"; break;
                case "U": IndustryBID = "23"; break;
                case "V": IndustryBID = "24"; break;
                case "W": IndustryBID = "25"; break;
                case "X": IndustryBID = "26"; break;
                case "Y": IndustryBID = "27"; break;
                case "Z": IndustryBID = "28"; break;
            }
            return IndustryBID;
        }

        /// <summary>
        /// ��ȡ��ҳ��
        /// </summary>
        /// <param name="Count">������</param>
        /// <param name="PageSize">ÿҳ������</param>
        /// <returns>��ҳ��</returns>
        public int GetPageCount(int Count, int PageSize)
        {
            int PageCount = 0;
            if (Count < PageSize)
                PageCount = 1;
            else if (Count % PageSize == 0)
                PageCount = Count / PageSize;
            else
                PageCount = Count / PageSize + 1;
            return PageCount;
        }

        /// <summary>
        /// ������ҵ��ȡ������
        /// </summary>
        /// <param name="Induy">��ҵ</param>
        /// <returns></returns>
        public int GetCountByIndustryBID(string IndustryBID)
        {
            string sql = "select count(InfoID) FROM MainInfoTabTest where IndustryBID like '%" + IndustryBID + "%' ";
            return Convert.ToInt32(SearchDBHelper.GetSingle(sql));
        }


        /// <summary>
        /// ������ҵ�������ȡ������
        /// </summary>
        /// <param name="IndustryBID">��ҵ</param>
        /// <param name="Province">����</param>
        /// <returns></returns>
        public int GetCountByIndustryBIDAndProvinceID(string IndustryBID, string ProvinceID)
        {
            string sql = "select count(InfoID) from MainInfoTabTest where ProvinceID like '%" + ProvinceID + "%' and  IndustryBID like '%" + IndustryBID + "%' ";
            return Convert.ToInt32(SearchDBHelper.GetSingle(sql));
        }

        /// <summary>
        /// ���������ȡ������
        /// </summary>
        /// <param name="Induy">����</param>
        /// <returns></returns>
        public int GetCountByProvinceID(string ProvinceID)
        {
            string sql = "select count(InfoID) FROM MainInfoTabTest where ProvinceID like '%" + ProvinceID + "%' ";
            return Convert.ToInt32(SearchDBHelper.GetSingle(sql));
        }

        /// <summary>
        /// ������ҵID��ȡ������Ϣ
        /// </summary>
        /// <param name="PageCurrent">��ǰҳ</param>
        /// <param name="IndustryBID">��ҵID</param>
        /// <returns>DataTable</returns>
        public DataTable GetFinancingByIndustryBID(int PageCurrent, string IndustryBID)
        {
            string sql = "select top 10 [InfoID] ,[Title],[publishT],[Hit],[FixPriceID],[HtmlFile],[ProvinceID],[CountyID],[IndustryBID],[CityID],"
            + "[CapitalTotal],[ValidateTerm],[ComAbout] ,[AuditingStatus] from MainInfoTabTest where "
            + "IndustryBID like '%" + IndustryBID + "%' and infoID not in (select top "
            + 10 * (PageCurrent - 1) + " infoID from MainInfoTabTest where IndustryBID like '%"
            + IndustryBID + "%' order by publishT desc) order by publishT desc";

            DataSet ds = SearchDBHelper.Query(sql.ToString());
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// ��������ID��ȡ������Ϣ
        /// </summary>
        /// <param name="PageCurrent">��ǰҳ</param>
        /// <param name="ProvinceID">����ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetFinancingByProvinceID(int PageCurrent, string ProvinceID)
        {
            string sql = "select top 10 [InfoID] ,[Title],[publishT],[Hit],[FixPriceID],[HtmlFile],[ProvinceID],[CountyID],[IndustryBID],[CityID],"
             + "[CapitalTotal],[ValidateTerm],[ComAbout] ,[AuditingStatus] from MainInfoTabTest"
             + " where ProvinceID=" + ProvinceID + " and infoID not in (select top " + 10 * (PageCurrent - 1) + " infoID from MainInfoTabTest"
             + " where ProvinceID=" + ProvinceID + " order by publishT desc) order by publishT desc";

            DataSet ds = SearchDBHelper.Query(sql.ToString());
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// ������ҵID������ID��ȡ������Ϣ
        /// </summary>
        /// <param name="PageCurrent">��ǰҳ</param>
        /// <param name="IndustryBID">��ҵID</param>
        /// <param name="ProvinceID">����ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetFinancingByIndustryBIDAndProvinceID(int PageCurrent, string IndustryBID, string ProvinceID)
        {
            string sql = "select top 10 [InfoID] ,[Title],[publishT],[Hit],[FixPriceID],[HtmlFile],[ProvinceID],[CountyID],[IndustryBID],[CityID],"
             + "[CapitalTotal],[ValidateTerm],[ComAbout] ,[AuditingStatus] from MainInfoTabTest"
             + " where ProvinceID=" + ProvinceID + " and  IndustryBID like '%" + IndustryBID + "%' and infoID not in (select top " + 10 * (PageCurrent - 1) + " infoID from MainInfoTabTest"
             + " where ProvinceID=" + ProvinceID + " and  IndustryBID like '%" + IndustryBID + "%' order by  publishT desc   )  order by  publishT desc";

            DataSet ds = SearchDBHelper.Query(sql.ToString());
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
    }
}
