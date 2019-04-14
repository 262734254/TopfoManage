using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.BLL.CatialManage
{
    public class CatialInfoBLL
    {
        private readonly Tz888.SQLServerDAL.CatialManage.CatialInfoDAL dal = new Tz888.SQLServerDAL.CatialManage.CatialInfoDAL();
        //获取行业名称
        public string GetInduyName(string Induy)
        {
            return dal.GetInduyName(Induy);
        }

        //获取行业ID
        public string GetIndustryBID(string Induy)
        {
            return dal.GetIndustryBID(Induy);
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="PageCount">总条数</param>
        /// <param name="PageSize">每页多少条</param>
        /// <returns>总页数</returns>
        public int GetPageCount(int Count, int PageSize)
        {
            return dal.GetPageCount(Count, PageSize);
        }

        /// <summary>
        /// 根据行业获取总条数
        /// </summary>
        /// <param name="Induy">行业</param>
        /// <returns></returns>
        public int GetCountByIndustryBID(string IndustryBID)
        {
            return dal.GetCountByIndustryBID(IndustryBID);
        }


        /// <summary>
        /// 根据行业和区域获取总条数
        /// </summary>
        /// <param name="IndustryBID">行业</param>
        /// <param name="Province">区域</param>
        /// <returns></returns>
        public int GetCountByIndustryBIDAndProvinceID(string IndustryBID, string ProvinceID)
        {
            return dal.GetCountByIndustryBIDAndProvinceID(IndustryBID, ProvinceID);
        }

        /// <summary>
        /// 根据区域获取总条数
        /// </summary>
        /// <param name="Induy">区域</param>
        /// <returns></returns>
        public int GetCountByProvinceID(string ProvinceID)
        {
            return dal.GetCountByProvinceID(ProvinceID);
        }

        /// <summary>
        /// 根据行业ID获取投资信息
        /// </summary>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="IndustryBID">行业ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCatialInfoIndustryBID(int PageCurrent, string IndustryBID)
        {
            return dal.GetCatialInfoIndustryBID(PageCurrent, IndustryBID);
        }

        /// <summary>
        /// 根据区域ID获取投资信息
        /// </summary>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="ProvinceID">区域ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCatialInfoByProvinceID(int PageCurrent, string ProvinceID)
        {
            return dal.GetCatialInfoByProvinceID(PageCurrent, ProvinceID);
        }

        /// <summary>
        /// 根据行业ID跟区域ID获取投资信息
        /// </summary>
        /// <param name="PageCurrent">当前页</param>
        /// <param name="IndustryBID">行业ID</param>
        /// <param name="ProvinceID">区域ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetCatialInfoByIndustryBIDAndProvinceID(int PageCurrent, string IndustryBID, string ProvinceID)
        {
            return dal.GetCatialInfoByIndustryBIDAndProvinceID(PageCurrent, IndustryBID, ProvinceID);
        }
    }
}
