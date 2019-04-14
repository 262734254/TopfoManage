using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.FinancingManage
{
    //融资搜索
    public class FinancingDAL
    {
        //获取行业名称
        public string GetInduyName(string Induy)
        {
            string InduyName = "";
            switch (Induy)
            {
                case "#": InduyName = "批发零售"; break;
                case "$": InduyName = "房地产业"; break;
                case "*": InduyName = "其他行业"; break;
                case "A": InduyName = "农林牧渔"; break;
                case "B": InduyName = "食品饮料"; break;
                case "C": InduyName = "冶金矿产"; break;
                case "D": InduyName = "机械制造"; break;
                case "E": InduyName = "汽车汽配"; break;
                case "F": InduyName = "能源动力"; break;
                case "G": InduyName = "石油化工"; break;
                case "H": InduyName = "纺织服装"; break;
                case "I": InduyName = "环境保护"; break;
                case "J": InduyName = "医疗保健"; break;
                case "K": InduyName = "生物科技"; break;
                case "L": InduyName = "教育培训"; break;
                case "M": InduyName = "印刷出版"; break;
                case "N": InduyName = "广告传媒"; break;
                case "O": InduyName = "影视娱乐"; break;
                case "P": InduyName = "电子通讯"; break;
                case "Q": InduyName = "建筑建材"; break;
                case "R": InduyName = "信息产业"; break;
                case "S": InduyName = "高新技术"; break;
                case "T": InduyName = "基础设施"; break;
                case "U": InduyName = "交通运输"; break;
                case "V": InduyName = "物流仓储"; break;
                case "W": InduyName = "金融融资"; break;
                case "X": InduyName = "旅游休闲"; break;
                case "Y": InduyName = "社会服务"; break;
                case "Z": InduyName = "酒店餐饮"; break;
            }
            return InduyName;
        }

        //获取行业ID
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
        /// 获取总页数
        /// </summary>
        /// <param name="Count">总条数</param>
        /// <param name="PageSize">每页多少条</param>
        /// <returns>总页数</returns>
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
        /// 根据行业获取总条数
        /// </summary>
        /// <param name="Induy">行业</param>
        /// <returns></returns>
        public int GetCountByIndustryBID(string IndustryBID)
        {
            string sql = "select count(InfoID) FROM MainInfoTabTest where IndustryBID like '%" + IndustryBID + "%' ";
            return Convert.ToInt32(SearchDBHelper.GetSingle(sql));
        }


        /// <summary>
        /// 根据行业和区域获取总条数
        /// </summary>
        /// <param name="IndustryBID">行业</param>
        /// <param name="Province">区域</param>
        /// <returns></returns>
        public int GetCountByIndustryBIDAndProvinceID(string IndustryBID, string ProvinceID)
        {
            string sql = "select count(InfoID) from MainInfoTabTest where ProvinceID like '%" + ProvinceID + "%' and  IndustryBID like '%" + IndustryBID + "%' ";
            return Convert.ToInt32(SearchDBHelper.GetSingle(sql));
        }

        /// <summary>
        /// 根据区域获取总条数
        /// </summary>
        /// <param name="Induy">区域</param>
        /// <returns></returns>
        public int GetCountByProvinceID(string ProvinceID)
        {
            string sql = "select count(InfoID) FROM MainInfoTabTest where ProvinceID like '%" + ProvinceID + "%' ";
            return Convert.ToInt32(SearchDBHelper.GetSingle(sql));
        }

        /// <summary>
        /// 根据行业ID获取融资信息
        /// </summary>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="IndustryBID">行业ID</param>
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
        /// 根据区域ID获取融资信息
        /// </summary>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="ProvinceID">区域ID</param>
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
        /// 根据行业ID跟区域ID获取融资信息
        /// </summary>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="IndustryBID">行业ID</param>
        /// <param name="ProvinceID">区域ID</param>
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
