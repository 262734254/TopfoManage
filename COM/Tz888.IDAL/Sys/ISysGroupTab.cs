using System;
using System.Data;
namespace Tz888.IDAL.Sys
{
    /// <summary>
    /// �ӿڲ�ISysGroupTab ��ժҪ˵����
    /// </summary>
    public interface ISysGroupTab
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int SID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Tz888.Model.Sys.SysGroupTab model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Tz888.Model.Sys.SysGroupTab model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int SID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.Sys.SysGroupTab GetModel(int SID);
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
