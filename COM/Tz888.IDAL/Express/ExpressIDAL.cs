using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Express;
using System.Data;
namespace Tz888.IDAL.Express
{
   public interface ExpressIDAL
    {
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(ExpressModel model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update(ExpressModel model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int expressID);
        bool DeleteList(string expressIDlist);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        ExpressModel GetModel(int expressID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
       DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
          ref long CurrentPage, long PageSize, ref long TotalCount);
        #endregion  ��Ա����
    }
}
