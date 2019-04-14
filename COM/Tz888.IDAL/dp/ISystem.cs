using System;
using System.Data;
namespace Tz888.IDAL.dp
{
    /// <summary>
    /// �ӿڲ�ISystem ��ժҪ˵����
    /// </summary>
    public interface ISystem
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string EmployeeID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Tz888.Model.dp.System model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update(Tz888.Model.dp.System model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(string EmployeeID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.dp.System GetModel(string EmployeeID);
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
