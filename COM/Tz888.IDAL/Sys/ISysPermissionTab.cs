using System;
using System.Data;
namespace Tz888.IDAL.Sys
{
    /// <summary>
    /// �ӿڲ�ISysPermissionTab ��ժҪ˵����
    /// </summary>
    public interface ISysPermissionTab
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int SPID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Tz888.Model.Sys.SysPermissionTab model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update(Tz888.Model.Sys.SysPermissionTab model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int SPID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.Sys.SysPermissionTab GetModel(int SPID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        Tz888.Model.Sys.SysPermissionTab GetModel1(int roleid);
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
