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
        /// ��ҵ��Ƭ�޸�
        /// </summary>
        /// <returns></returns>
        public int Company_Update(CompanyModel model, int id)
        {
            return dal.Company_Update(model,id);
        }

        #region ɾ��ʱ���ı�״̬������ʾ����
        /// <summary>
        /// ɾ��ʱ���ı�״̬������ʾ����
        /// </summary>
        /// <returns></returns>
        public int UpdateDelete(int id)
        {
            return dal.UpdateDelete(id);
        }
        #endregion

        #region ����ɾ��
        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <returns></returns>
        public int DelCompany(int id)
        {
            return dal.DelCompany(id);
        }
        #endregion

        #region ������
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyHit(int id)
        {
            return dal.ModfiyHit(id);
        }
        #endregion

        #region ��ѯ��ϵ����Ϣ
        /// <summary>
        /// ��ѯ��ϵ����Ϣ
        public string SelLinkName(int id)
        {
            return dal.SelLinkName(id);
        }
        #endregion

        #region �жϾ�̬ģ���Ƿ����
        /// <summary>
        /// �жϾ�̬ģ���Ƿ����
        /// </summary>
        public string SelHtmlFile(int id)
        {
            return dal.SelHtmlFile(id);
        }
        #endregion

        #region ���ݱ�Ų�ѯ����Ӧ����Ϣ
        public CompanyModel SelCompany(int id)
        {
            return dal.SelCompany(id);
        }
        #endregion
       /// <summary>
       /// ��test���ݿ�
       /// </summary>
       /// <param name="TableViewName">����</param>
       /// <param name="Key">����</param>
       /// <param name="SelectStr">��ѯ�ֶ�</param>
       /// <param name="Criteria">����</param>
       /// <param name="Sort">�����ֶ�</param>
       /// <param name="CurrentPage">��ǰҳ</param>
       /// <param name="PageSize">ҳ��С</param>
       /// <param name="TotalCount">�ܼ�¼</param>
       /// <returns></returns>
       public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
       {
           return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort,
           ref CurrentPage, PageSize, ref TotalCount);
       }

        /// <summary>
        /// ¼����ҵ��Ƭ 
        /// </summary>
        /// <param name="companymodel"></param>
        /// <returns></returns>
        public int InsertCompany(CompanyModel companymodel)
        {
            return dal.InsertCompany(companymodel);
        }
    }
}
