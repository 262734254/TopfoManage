using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Link;
using System.Data;

namespace Tz888.IDAL.Link
{
    /// <summary>
    /// 友情连接表
    /// </summary>
    public interface ILinkInfoTab
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
        /// 删除友情链接
        /// </summary>
        /// <param name="LinkId">LinkId</param>
        /// <returns></returns>
        bool DelLinkById(string LinkInfoId);

        /// <summary>
        /// 获取链接
        /// </summary>
        /// <param name="LinkId">链接id</param>
        /// <returns></returns>
        DataTable GetLinkById(string LinkId);


        /// <summary>
        /// 添加链接
        /// </summary>
        /// <param name="Link">链接</param>
        /// <returns></returns>
        bool AddLink(Tz888.Model.Link.LinkInfoTab LinkInfo);

        /// <summary>
        /// 修改友情链接
        /// </summary>
        /// <param name="LinkInfo"></param>
        /// <returns></returns>
        bool ModfiyLink(Tz888.Model.Link.LinkInfoTab LinkInfo);
    }
}
