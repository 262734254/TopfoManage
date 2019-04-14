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

        #region ��ѯ������ID����ȫ�����ɾ�̬ҳ��ʱ�õ�
        /// <summary>
        /// ��ѯ������ID����ȫ�����ɾ�̬ҳ��ʱ�õ�
        /// </summary>
        /// <returns></returns>
        public string AllCompany()
        {
            return company.AllCompany();
        }
        #endregion

        #region ��ҵ��Ƭ�Ҳ���
        /// <summary>
        /// ��ҵ��Ƭ��Ա����
        /// </summary>
        /// <param name="name"></param>
        public void ComPanyHit()
        {
            company.ComPanyHit();
        }
        /// <summary>
        /// ��ҵ��Ƭ���¼�����ҵ
        /// </summary>
        /// <param name="name"></param>
        public void ComPanyTime()
        {
            company.ComPanyTime();
        }
        #endregion

        #region ��ҵչ��
        public void CompanyShowHtml(string LoginName, string Title, string KeyWord, string Descript)

        {
            company.CompanyShowHtml(LoginName, Title, KeyWord, Descript);

        }
        #endregion
            
        
        /// <summary>
        /// ����������ĿIfrom
        /// </summary>
        /// <param name="LoginName"></param>
        public int MerchantStatic(string LoginName)
        {
           return company.MerchantStatic(LoginName);
        }
        /// <summary>
        /// ��������Ͷ������ģ��ҳ
        /// </summary>
        /// <param name="LoginName"></param>
        public int PmcStatic(string LoginName)
        {
            return company.PmcStatic(LoginName);

        }

        #region ɾ��ָ���ļ���
        public void DelFile(string name)
        {
            company.DelFile(name);
        }
        #endregion

    }

}
