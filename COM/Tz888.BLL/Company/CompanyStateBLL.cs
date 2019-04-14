using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Company
{
    public class CompanyStateBLL
    {
        CompanyState company = new CompanyState();
        public void ComPanyHtml(string CompanyID, string LoginName, string CompanyName, string IndustryName, string RangeName, string NatureName,
            string HtmlFile, string EstablishMent, string Employees, string Capital, string Introduction, string ServiceProce,
            string Title, string Keywords, string Description,string logo,string FromID)
        {
            company.ComPanyHtml(CompanyID, LoginName, CompanyName, IndustryName, RangeName,NatureName, HtmlFile, EstablishMent,
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

        #region 企业名片右侧栏
        /// <summary>
        /// 企业名片会员排行
        /// </summary>
        /// <param name="name"></param>
        public void ComPanyHit()
        {
            company.ComPanyHit();
        }
        /// <summary>
        /// 企业名片最新加入企业
        /// </summary>
        /// <param name="name"></param>
        public void ComPanyTime()
        {
            company.ComPanyTime();
        }
        #endregion

        #region 企业展厅
        public void CompanyShowHtml(string LoginName, string Title, string KeyWord, string Descript)

        {
            company.CompanyShowHtml(LoginName, Title, KeyWord, Descript);

        }
        #endregion
            
        
        /// <summary>
        /// 生成招商项目Ifrom
        /// </summary>
        /// <param name="LoginName"></param>
        public int MerchantStatic(string LoginName)
        {
           return company.MerchantStatic(LoginName);
        }
        /// <summary>
        /// 生成招商投资融资模板页
        /// </summary>
        /// <param name="LoginName"></param>
        public int PmcStatic(string LoginName)
        {
            return company.PmcStatic(LoginName);

        }

        #region 删除指定文件夹
        public void DelFile(string name)
        {
            company.DelFile(name);
        }
        #endregion

    }

}
