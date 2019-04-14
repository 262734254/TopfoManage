using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Link;
using System.Data;

namespace Tz888.IDAL.Link
{
    /// <summary>
    /// �������ͱ�
    /// </summary>
    public interface ILinkTypeTab
    {
        //<summary>
        //����
        //</summary>
        //<param name="TableViewName">����</param>
        //<param name="Key">����</param>
        //<param name="SelectStr">��ѯ�ֶ�</param>
        //<param name="Criteria">����</param>
        //<param name="Sort">�����ֶ�</param>
        //<param name="CurrentPage">��ǰҳ</param>
        //<param name="PageSize">ҳ��С</param>
        //<param name="TotalCount">�ܼ�¼</param>
        //<returns></returns>
        DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
          ref long CurrentPage, long PageSize, ref long TotalCount);

        /// <summary>
        /// ɾ���������
        /// </summary>
        /// <param name="TypelId">���Id</param>
        /// <returns></returns>
        bool DelTypeById(string TypeId);

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="LinkInfoTab"></param>
        /// <returns></returns>
        bool UpdateTypeById(Tz888.Model.Link.LinkTypeTab LinkInfo);

        /// <summary>
        /// ��ȡ���
        /// </summary>
        /// <param name="TypelId">���id</param>
        /// <returns></returns>
        DataTable GetTypeById(string TypeId);


        /// <summary>
        /// ������
        /// </summary>
        /// <param name="Type">���</param>
        /// <returns></returns>
        bool AddType(Tz888.Model.Link.LinkTypeTab Type);

        /// <summary>
        /// ��������б�
        /// </summary>
        /// <returns></returns>
        DataTable GetLinkTypeList();
    }
}
