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
        /// 删除频道
        /// </summary>
        /// <param name="ChannelId">跑到ID</param>
        /// <returns></returns>
        public bool DelChannelById(string ChannelId)
        {
            return dal.DelChannelById(ChannelId);
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="Channel">频道</param>
        /// <returns></returns>
        public bool UpdateChannelById(Tz888.Model.Link.LinkChannelType Channel)
        {
            return dal.UpdateChannelById(Channel);
        }

        /// <summary>
        /// 根据频道Id获取对应的频道
        /// </summary>
        /// <param name="ChannelId">频道ID</param>
        /// <returns></returns>
        public DataTable GetChannelById(string ChannelId)
        {
            return dal.GetChannelById(ChannelId);
        }

        /// <summary>
        /// 添加频道
        /// </summary>
        /// <param name="Channel">频道</param>
        /// <returns></returns>
        public bool AddChannel(Tz888.Model.Link.LinkChannelType Channel)
        {
            return dal.AddChannel(Channel);
        }

        /// <summary>
        /// 频道列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetChannelList()
        {
            return dal.GetChannelList();
        }
    }
}
