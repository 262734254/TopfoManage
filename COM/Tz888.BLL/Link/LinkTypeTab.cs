using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Link
{
    public class LinkTypeTab
    {
        private readonly Tz888.IDAL.Link.ILinkTypeTab dal = DataAccess.CreateLinkType();

        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName, Key, SelectStr, Criteria, Sort, ref  CurrentPage, PageSize, ref  TotalCount);
        }

        /// <summary>
        /// 根据链接类别Id删除但前类别
        /// </summary>
        /// <param name="TypeId">类别ID</param>
        /// <returns></returns>
        public bool DelTypeById(string TypeId)
        {
            return dal.DelTypeById(TypeId);
        }

        /// <summary>
        /// 链接类别审核
        /// </summary>
        /// <param name="LinkInfo">Model.Link.LinkInfoTab</param>
        /// <returns></returns>
        public bool UpdateTypeById(Tz888.Model.Link.LinkTypeTab LinkType)
        {
            return dal.UpdateTypeById(LinkType);
        }

        /// <summary>
        /// 根据链接类别
        /// </summary>
        /// <param name="TypeId">类别ID</param>
        /// <returns></returns>
        public DataTable GetTypeById(string TypeId)
        {
            return dal.GetTypeById(TypeId);
        }

        /// <summary>
        /// 添加链接类别
        /// </summary>
        /// <param name="LinkTypeTab">类别</param>
        /// <returns></returns>
        public bool AddType(Tz888.Model.Link.LinkTypeTab Type)
        {
            return dal.AddType(Type);
        }

        /// <summary>
        /// 链接类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetLinkTypeList()
        {
            return dal.GetLinkTypeList();
        }
    }
}
