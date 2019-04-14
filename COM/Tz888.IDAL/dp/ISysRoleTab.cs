using System;
using System.Data;
namespace Tz888.IDAL.dp
{
    /// <summary>
    /// �ӿڲ�ISysRoleTab ��ժҪ˵����
    /// </summary>
    public interface ISysRoleTab
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int SRoleID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Tz888.Model.dp.SysRoleTab model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Tz888.Model.dp.SysRoleTab model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int SRoleID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.dp.SysRoleTab GetModel(int SRoleID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// ��ȡ���н�ɫ��Ϣ
        /// </summary>
        /// <returns></returns>
        DataSet dvGetAllIndustry();
        /// <summary>
        /// ���ݽ�ɫ�����ȡ��ɫ����
        /// </summary>
        /// <param name="IndustryID"></param>
        /// <returns></returns>
        string GetNameByID(string IndustryID);
        /// <summary>
        /// ���ݷ�ҳ��������б�
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  ��Ա����
    }
}
