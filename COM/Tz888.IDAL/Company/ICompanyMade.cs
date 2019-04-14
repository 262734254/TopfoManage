using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Company;

namespace Tz888.IDAL.Company
{
    public interface ICompanyMade
    {
        /// <summary>
        /// ���ݱ�Ų�������Ӧ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyMadeModel SelGetMade(int id);
        /// <summary>
        /// �޸���Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateMade(CompanyMadeModel model, int id);
        /// <summary>
        /// ɾ����涨����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int MadeDelete(int id);
        /// <summary>
        /// ɾ��խ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int NarrowDelete(int id);
        /// <summary>
        /// ��ѯ����Ӧ��խ������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        NarrowModel SelNarrow(int id);
    }
}
