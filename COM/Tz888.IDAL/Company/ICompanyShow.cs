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
        /// ���ݱ�Ų�ѯ����Ӧ��չ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyShow SelAllShow(int id);
        /// <summary>
        /// �޸�չ����Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int ModfiyShow(CompanyShow model, int id);
        /// <summary>
        /// ɾ������Ӧ��չ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteShow(int id);
         /// <summary>
        /// �����û�����ѯ������Ӧ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyShow SelAllShows(string userName);
        
        /// <summary>
        /// ��ѯ�����û���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelCompanyUserName();
       
        /// <summary>
        /// ��ѯ����ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelCompanyID();
          /// <summary>
        /// �����û���ֻ��ѯ��ҵ����
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        string GetCompanyNameByLoginName(string loginName);
        
        /// <summary>
        /// �����û��������Ƿ��м�¼��
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
         bool ExistsName(string loginName);
       
        /// <summary>
        /// ��ҳ
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
        /// �����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int SelHit(int id);
        
    }
}
