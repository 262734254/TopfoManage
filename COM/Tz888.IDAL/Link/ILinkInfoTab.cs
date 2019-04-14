using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Link;
using System.Data;

namespace Tz888.IDAL.Link
{
    /// <summary>
    /// �������ӱ�
    /// </summary>
    public interface ILinkInfoTab
    {
        //<summary>
        //��ҳ
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
        /// ɾ����������
        /// </summary>
        /// <param name="LinkId">LinkId</param>
        /// <returns></returns>
        bool DelLinkById(string LinkInfoId);

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="LinkId">����id</param>
        /// <returns></returns>
        DataTable GetLinkById(string LinkId);


        /// <summary>
        /// �������
        /// </summary>
        /// <param name="Link">����</param>
        /// <returns></returns>
        bool AddLink(Tz888.Model.Link.LinkInfoTab LinkInfo);

        /// <summary>
        /// �޸���������
        /// </summary>
        /// <param name="LinkInfo"></param>
        /// <returns></returns>
        bool ModfiyLink(Tz888.Model.Link.LinkInfoTab LinkInfo);
    }
}
