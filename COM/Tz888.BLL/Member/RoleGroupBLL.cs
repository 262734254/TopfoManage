using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.ManageSystem;
using Tz888.SQLServerDAL.ManageSystem;
using System.Data;

namespace Tz888.BLL.ManageSystem
{
    public class RoleGroupBLL
    {
        RoleGroupDAL RGDale = new RoleGroupDAL();
        /// <summary>
        /// ��ӽ�ɫ��
        /// </summary>
        /// <param name="RoleGroup"></param>
        /// <returns></returns>
        public bool AddRoleGroup(RoleGroupTab RoleGroup)
        {
            return RGDale.AddRoleGroup(RoleGroup);
        }

        #region
        /// <summary>
        /// ��ѯÿ�ֽ�ɫ�µ����н�ɫ��
        /// </summary>
        /// <returns></returns>
        //public IList<RoleGroupTab> SelectAllRolGroups(int RoleID)
        //{
        //    return RGDale.SelectAllRolGroups(RoleID);
        //}
        #endregion

        /// <summary>
        /// ��ѯÿ�ֽ�ɫ�µ����н�ɫ��
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllRolGroup(int RoleID)
        {
            return RGDale.SelectAllRolGroup(RoleID);
        }

        /// <summary>
        /// ����ɫ���Ƿ����
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable IsExistRole(string ID, string name)
        {
            return RGDale.IsExistRole(ID, name);
        }

        /// <summary>
        /// ɾ����ɫ��
        /// </summary>
        /// <param name="roleGroupId"></param>
        /// <returns></returns>
        public int DeleteRoleGroup(int roleGroupId)
        {
            return RGDale.DeleteRoleGroup(roleGroupId);
        }

        /// <summary>
        /// �޸Ľ�ɫ����Ϣ
        /// </summary>
        /// <param name="roleTab"></param>
        /// <returns></returns>
        public bool UPdateRoleGroupInfo(RoleGroupTab roleTab)
        {
            return RGDale.UPdateRoleGroupInfo(roleTab);
        }

        /// <summary>
        /// ���ݽ�ɫID��ȡ��Ϣ
        /// </summary>
        /// <param name="roleGroupId"></param>
        /// <returns></returns>
        public RoleGroupTab GetRoleGroupById(string roleGroupId)
        {
             return RGDale.GetRoleGroupById(roleGroupId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleGroupId"></param>
        /// <returns></returns>
        public bool UPdateRoleGroupSCheck(string roleGroupId,int SCheck)
        {
            return RGDale.UPdateRoleGroupSCheck(roleGroupId,SCheck);
        }

        /// <summary>
        /// ����Vip�û�
        /// </summary>
        /// <param name="MemberGradeID"></param>
        /// <returns></returns>
        public DataTable GetListVip(string MemberGradeID)
        {
            return RGDale.GetListVip(MemberGradeID);
        }

        /// <summary>
        /// ��test���ݿ�
        /// </summary>
        /// <param name="TableViewName">����</param>
        /// <param name="Key">����</param>
        /// <param name="SelectStr">��ѯ�ֶ�</param>
        /// <param name="Criteria">����</param>
        /// <param name="Sort">�����ֶ�</param>
        /// <param name="CurrentPage">��ǰҳ</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">�ܼ�¼</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return RGDale.GetListT(TableViewName, Key, SelectStr, Criteria, Sort,
            ref CurrentPage, PageSize, ref TotalCount);
        }
    }
}
