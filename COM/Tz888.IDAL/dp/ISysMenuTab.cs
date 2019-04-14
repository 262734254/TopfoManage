using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
namespace Tz888.IDAL.dp
{
    /// <summary>
    /// �ӿڲ�ISysMenuTab ��ժҪ˵����
    /// </summary>
    public interface ISysMenuTab
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int sid);
        /// <summary>
        /// �˵������Ƿ���ͬ
        /// </summary>
        bool ExistsMenuName(string menuName);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Tz888.Model.dp.SysMenuTab model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update(Tz888.Model.dp.SysMenuTab model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int sid);
        bool Delete1(int sid);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.dp.SysMenuTab GetModel(int sid);
        IList<Tz888.Model.dp.SysMenuTab> GetList(int SParentCode, string sort);
        IList<Tz888.Model.dp.SysMenuTab> GetList();
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ��������б�(ȡ�������ֶ�)
        /// </summary>
        DataSet GetListSingle(string strWhere);
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
