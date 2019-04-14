using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.report;
using System.Data;
namespace Tz888.IDAL.report
{
    public interface IndustryFromIDAL
    {
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(IndustryFrom model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update(IndustryFrom model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int industryId);
        bool DeleteList(string industryIdlist);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        IndustryFrom GetModel(int industryId);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// ���ݷ�ҳ��������б�
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  ��Ա����
    }
}
