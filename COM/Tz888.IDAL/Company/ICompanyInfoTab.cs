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
        /// ��ҵ��Ƭ�޸�
        /// </summary>
        /// <returns></returns>
        int Company_Update(CompanyModel model, int id);
        /// <summary>
        /// ɾ��ʱ���ı�״̬������ʾ����
        /// </summary>
        /// <returns></returns>
        int UpdateDelete(int id);
        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <returns></returns>
        int DelCompany(int id);
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int ModfiyHit(int id);
        /// <summary>
        /// ��ѯ��ϵ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelLinkName(int id);
        /// <summary>
        /// �жϾ�̬ģ���Ƿ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelHtmlFile(int id);
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <returns></returns>
        DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount);
        /// <summary>
        /// ����ID��ѯ��Ϣ
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        CompanyModel SelCompany(int comId);
    
        /// <summary>
        /// ¼����ҵ��Ƭ
        /// </summary>
        /// <param name="companymodel"></param>
        int InsertCompany(CompanyModel companymodel);
    }
}
