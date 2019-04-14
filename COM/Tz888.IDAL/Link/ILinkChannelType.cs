using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Link
{
    /// <summary>
    /// ҳ��Ƶ��
    /// </summary>
    public interface ILinkChannelType
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
        /// ɾ��Ƶ��
        /// </summary>
        /// <param name="ChannelId">Ƶ��Id</param>
        /// <returns></returns>
        bool DelChannelById(string ChannelId);

        /// <summary>
        /// Ƶ�����
        /// </summary>
        /// <param name="LinkChannelType">LinkChannelType</param>
        /// <returns></returns>
        bool UpdateChannelById(Tz888.Model.Link.LinkChannelType Channel);

        /// <summary>
        /// ��ȡƵ��
        /// </summary>
        /// <param name="ChannelId">Ƶ��id</param>
        /// <returns></returns>
        DataTable GetChannelById(string ChannelId);


        /// <summary>
        /// ���Ƶ��
        /// </summary>
        /// <param name="Channel">Ƶ��</param>
        /// <returns></returns>
        bool AddChannel(Tz888.Model.Link.LinkChannelType Channel);

        /// <summary>
        /// Ƶ���б�
        /// </summary>
        /// <returns></returns>
        DataTable GetChannelList();
    }
}
