using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL.Company;
using Tz888.DALFactory;
using Tz888.Model.Company;

namespace Tz888.BLL.Company
{
    
    public class CompanyBLL
    {
        private readonly ICompanyInfoTab dal = DataAccess.CreateCompany();
        
        /// <summary>
        /// 企业名片修改
        /// </summary>
        /// <returns></returns>
        public int Company_Update(CompanyModel model, int id)
        {
            return dal.Company_Update(model,id);
        }

        #region 删除时，改变状态，不显示出来
        /// <summary>
        /// 删除时，改变状态，不显示出来
        /// </summary>
        /// <returns></returns>
        public int UpdateDelete(int id)
        {
            return dal.UpdateDelete(id);
        }
        #endregion

        #region 彻底删除
        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <returns></returns>
        public int DelCompany(int id)
        {
            return dal.DelCompany(id);
        }
        #endregion

        #region 访问率
        /// <summary>
        /// 访问率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyHit(int id)
        {
            return dal.ModfiyHit(id);
        }
        #endregion

        #region 查询联系人信息
        /// <summary>
        /// 查询联系人信息
        public string SelLinkName(int id)
        {
            return dal.SelLinkName(id);
        }
        #endregion

        #region 判断静态模版是否存在
        /// <summary>
        /// 判断静态模版是否存在
        /// </summary>
        public string SelHtmlFile(int id)
        {
            return dal.SelHtmlFile(id);
        }
        #endregion

        #region 根据编号查询所对应的信息
        public CompanyModel SelCompany(int id)
        {
            return dal.SelCompany(id);
        }
        #endregion
       /// <summary>
       /// 用test数据库
       /// </summary>
       /// <param name="TableViewName">表名</param>
       /// <param name="Key">主键</param>
       /// <param name="SelectStr">查询字段</param>
       /// <param name="Criteria">条件</param>
       /// <param name="Sort">排序字段</param>
       /// <param name="CurrentPage">当前页</param>
       /// <param name="PageSize">页大小</param>
       /// <param name="TotalCount">总记录</param>
       /// <returns></returns>
       public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
       {
           return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort,
           ref CurrentPage, PageSize, ref TotalCount);
       }

        /// <summary>
        /// 录入企业名片 
        /// </summary>
        /// <param name="companymodel"></param>
        /// <returns></returns>
        public int InsertCompany(CompanyModel companymodel)
        {
            return dal.InsertCompany(companymodel);
        }
    }
}
