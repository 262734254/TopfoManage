using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Company
{
 public   class CompanyStateManage
    {
        CompanyState company = new CompanyState();
        public void ComPanyHtml(string CompanyID, string LoginName, string CompanyName, string IndustryName, string RangeName, string NatureName,
            string HtmlFile, string EstablishMent, string Employees, string Capital, string Introduction, string ServiceProce,
            string Title, string Keywords, string Description, string logo,string FromID)
        {
            company.ComPanyHtml(CompanyID, LoginName, CompanyName, IndustryName, RangeName, NatureName, HtmlFile, EstablishMent,
                Employees, Capital, Introduction, ServiceProce, Title, Keywords, Description, logo, FromID);
        }

        #region 查询出所有ID，在全部生成静态页面时用到
        /// <summary>
        /// 查询出所有ID，在全部生成静态页面时用到 
        /// </summary>
        /// <returns></returns>
        public string AllCompany()
        {
            return company.AllCompany();
        }
        #endregion

    }

}
