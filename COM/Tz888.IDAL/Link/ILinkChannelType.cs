using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Link
{
    /// <summary>
    /// 页面频道
    /// </summary>
    public interface ILinkChannelType
    {
         //<summary>
         //分页
         //</summary>
         //<param name="TableViewName">表名</param>
         //<param name="Key">主键</param>
         //<param name="SelectStr">查询字段</param>
         //<param name="Criteria">条件</param>
         //<param name="Sort">排序字段</param>
         //<param name="CurrentPage">当前页</param>
         //<param name="PageSize">页大小</param>
         //<param name="TotalCount">总记录</param>
         //<returns></returns>
        DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
          ref long CurrentPage, long PageSize, ref long TotalCount);

        /// <summary>
        /// 删除频道
        /// </summary>
        /// <param name="ChannelId">频道Id</param>
        /// <returns></returns>
        bool DelChannelById(string ChannelId);

        /// <summary>
        /// 频道审核
        /// </summary>
        /// <param name="LinkChannelType">LinkChannelType</param>
        /// <returns></returns>
        bool UpdateChannelById(Tz888.Model.Link.LinkChannelType Channel);

        /// <summary>
        /// 获取频道
        /// </summary>
        /// <param name="ChannelId">频道id</param>
        /// <returns></returns>
        DataTable GetChannelById(string ChannelId);


        /// <summary>
        /// 添加频道
        /// </summary>
        /// <param name="Channel">频道</param>
        /// <returns></returns>
        bool AddChannel(Tz888.Model.Link.LinkChannelType Channel);

        /// <summary>
        /// 频道列表
        /// </summary>
        /// <returns></returns>
        DataTable GetChannelList();
    }
}
