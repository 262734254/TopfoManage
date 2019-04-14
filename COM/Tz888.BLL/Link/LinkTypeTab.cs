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
        /// �����������Idɾ����ǰ���
        /// </summary>
        /// <param name="TypeId">���ID</param>
        /// <returns></returns>
        public bool DelTypeById(string TypeId)
        {
            return dal.DelTypeById(TypeId);
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="LinkInfo">Model.Link.LinkInfoTab</param>
        /// <returns></returns>
        public bool UpdateTypeById(Tz888.Model.Link.LinkTypeTab LinkType)
        {
            return dal.UpdateTypeById(LinkType);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="TypeId">���ID</param>
        /// <returns></returns>
        public DataTable GetTypeById(string TypeId)
        {
            return dal.GetTypeById(TypeId);
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="LinkTypeTab">���</param>
        /// <returns></returns>
        public bool AddType(Tz888.Model.Link.LinkTypeTab Type)
        {
            return dal.AddType(Type);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DataTable GetLinkTypeList()
        {
            return dal.GetLinkTypeList();
        }
    }
}
