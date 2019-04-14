using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Company;

namespace Tz888.IDAL.Company
{
    public interface ICompanyInfoTab
    {
        /// <summary>
        /// 企业名片修改
        /// </summary>
        /// <returns></returns>
        int Company_Update(CompanyModel model, int id);
        /// <summary>
        /// 删除时，改变状态，不显示出来
        /// </summary>
        /// <returns></returns>
        int UpdateDelete(int id);
        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <returns></returns>
        int DelCompany(int id);
        /// <summary>
        /// 访问率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ModfiyHit(int id);
        /// <summary>
        /// 查询联系人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelLinkName(int id);
        /// <summary>
        /// 判断静态模版是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelHtmlFile(int id);
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount);
        /// <summary>
        /// 根据ID查询信息
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        CompanyModel SelCompany(int comId);
    
        /// <summary>
        /// 录入企业名片
        /// </summary>
        /// <param name="companymodel"></param>
        int InsertCompany(CompanyModel companymodel);
    }
}
