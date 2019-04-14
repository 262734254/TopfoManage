using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Link
{
    public class LinkChannelType
    {
        private readonly Tz888.IDAL.Link.ILinkChannelType dal = DataAccess.CreateChannel();

        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort, ref CurrentPage, PageSize, ref  TotalCount);
        }

        /// <summary>
        /// ɾ��Ƶ��
        /// </summary>
        /// <param name="ChannelId">�ܵ�ID</param>
        /// <returns></returns>
        public bool DelChannelById(string ChannelId)
        {
            return dal.DelChannelById(ChannelId);
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="Channel">Ƶ��</param>
        /// <returns></returns>
        public bool UpdateChannelById(Tz888.Model.Link.LinkChannelType Channel)
        {
            return dal.UpdateChannelById(Channel);
        }

        /// <summary>
        /// ����Ƶ��Id��ȡ��Ӧ��Ƶ��
        /// </summary>
        /// <param name="ChannelId">Ƶ��ID</param>
        /// <returns></returns>
        public DataTable GetChannelById(string ChannelId)
        {
            return dal.GetChannelById(ChannelId);
        }

        /// <summary>
        /// ���Ƶ��
        /// </summary>
        /// <param name="Channel">Ƶ��</param>
        /// <returns></returns>
        public bool AddChannel(Tz888.Model.Link.LinkChannelType Channel)
        {
            return dal.AddChannel(Channel);
        }

        /// <summary>
        /// Ƶ���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetChannelList()
        {
            return dal.GetChannelList();
        }
    }
}
