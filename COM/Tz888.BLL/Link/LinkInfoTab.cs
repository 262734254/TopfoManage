using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Link
{
    public class LinkInfoTab
    {
        private readonly Tz888.IDAL.Link.ILinkInfoTab dal = DataAccess.CreateLink();

        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort, ref  CurrentPage, PageSize, ref  TotalCount);
        }

        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="LinkInfoId">链接ID</param>
        /// <returns></returns>
        public bool DelLinkById(string LinkInfoId)
        {
            return dal.DelLinkById(LinkInfoId);
        }

        /// <summary>
        /// 获取友情链接详情
        /// </summary>
        /// <param name="LinkInfoId">LinkInfoId</param>
        /// <returns></returns>
        public DataTable GetLinkById(string LinkInfoId)
        {
            return dal.GetLinkById(LinkInfoId);
        }

        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="LinkInfoTab">LinkInfoTab</param>
        /// <returns></returns>
        public bool AddLink(Tz888.Model.Link.LinkInfoTab LinkInfo)
        {
            return dal.AddLink(LinkInfo);
        }

        /// <summary>
        /// 修改链接
        /// </summary>
        /// <param name="LinkInfo">Model</param>
        /// <returns></returns>
        public bool ModfiyLink(Tz888.Model.Link.LinkInfoTab LinkInfo)
        {
            return dal.ModfiyLink(LinkInfo);
        }
    }
}
