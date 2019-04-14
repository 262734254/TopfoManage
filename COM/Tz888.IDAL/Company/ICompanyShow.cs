using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Company;

namespace Tz888.IDAL.Company
{
    public interface ICompanyShow
    {
        /// <summary>
        /// 根据编号查询所对应的展厅信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyShow SelAllShow(int id);
        /// <summary>
        /// 修改展厅信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int ModfiyShow(CompanyShow model, int id);
        /// <summary>
        /// 删除所对应的展厅信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteShow(int id);
         /// <summary>
        /// 根据用户名查询出所对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyShow SelAllShows(string userName);
        
        /// <summary>
        /// 查询所有用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelCompanyUserName();
       
        /// <summary>
        /// 查询所有ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelCompanyID();
          /// <summary>
        /// 根据用户名只查询企业名称
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        string GetCompanyNameByLoginName(string loginName);
        
        /// <summary>
        /// 根据用户名查找是否有记录数
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
         bool ExistsName(string loginName);
       
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="TableViewName"></param>
        /// <param name="Key"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount);
        /// <summary>
        /// 点击率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int SelHit(int id);
        
    }
}
