using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Common;
using Tz888.IDAL.Common;
using Tz888.DALFactory;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.BLL.Common
{
    /// <summary>
    /// 行业类别信息业务逻辑处理类
    /// </summary>
    public class IndustryBLL
    {
        private readonly IIndustry dal = DataAccess.CreateIndustry();

        /// <summary>
        /// 获取所有行业分类信息
        /// </summary>
        /// <returns>行业分类信息列表</returns>
        public List<IndustryModel> GetAllList()
        {
            return dal.GetAllList();
        } 


        /// <summary>
        /// 根据行业代码获取行业名称
        /// </summary>
        /// <param name="IndustryID">行业代码</param>
        /// <returns></returns>
        public string GetNameByID(string IndustryID)
        {
            return dal.GetNameByID(IndustryID);
        }

        /// <summary>
        /// 大区域类型表
        /// </summary>
        /// <returns></returns>
        public DataView SetAreaTab()
        {
            return dal.SetAreaTab();
        }
        /// <summary>
        /// 新闻行页类型表
        /// </summary>
        /// <returns></returns>
        public DataView SetNewsIndustry()
        {
            return dal.SetNewsIndustry();
        }

        /// <summary>
        /// 修改时根据行业代码获取行业名称
        /// </summary>
        /// <param name="IndustryID">list</param>
        /// <returns></returns>
        public List<IndustryModel> GetIndustryList(string IndustryList)
        {
            return dal.GetIndustryList(IndustryList);
        }


        public DataView SetNewsType()
        {
            return dal.SetNewsType();
        }
        /// <summary>
        /// 获取行业信息
        /// </summary>
        /// <returns></returns>
        public DataView dvGetAllIndustry()
        {
            return dal.dvGetAllIndustry();
        }
        public string GetSetNewsTypeByID(string NewsId)
        {
            return dal.GetSetNewsTypeByID(NewsId);
        }
        #region IIndustry 成员

        /// <summary>
        /// 信息等级表
        /// </summary>
        /// <returns></returns>
        //信息等级表
        public DataView SetGradeTab()
        {
            return dal.SetGradeTab();
        }
        /// <summary>
        /// 信息价值
        /// </summary>
        /// <returns></returns>
        //信息价值
        public DataView SetFixWorthPointTab()
        {
            return dal.SetFixWorthPointTab();
        }

        #endregion

    }
}
