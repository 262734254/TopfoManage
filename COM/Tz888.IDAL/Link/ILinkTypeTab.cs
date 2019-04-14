using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Link;
using System.Data;

namespace Tz888.IDAL.Link
{
    /// <summary>
    /// 链接类型表
    /// </summary>
    public interface ILinkTypeTab
    {
        //<summary>
        //类型
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
        /// 删除链接类别
        /// </summary>
        /// <param name="TypelId">类别Id</param>
        /// <returns></returns>
        bool DelTypeById(string TypeId);

        /// <summary>
        /// 类别审核
        /// </summary>
        /// <param name="LinkInfoTab"></param>
        /// <returns></returns>
        bool UpdateTypeById(Tz888.Model.Link.LinkTypeTab LinkInfo);

        /// <summary>
        /// 获取类别
        /// </summary>
        /// <param name="TypelId">类别id</param>
        /// <returns></returns>
        DataTable GetTypeById(string TypeId);


        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="Type">类别</param>
        /// <returns></returns>
        bool AddType(Tz888.Model.Link.LinkTypeTab Type);

        /// <summary>
        /// 链接类别列表
        /// </summary>
        /// <returns></returns>
        DataTable GetLinkTypeList();
    }
}
