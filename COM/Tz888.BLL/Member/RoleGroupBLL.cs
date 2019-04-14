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
        /// 添加角色组
        /// </summary>
        /// <param name="RoleGroup"></param>
        /// <returns></returns>
        public bool AddRoleGroup(RoleGroupTab RoleGroup)
        {
            return RGDale.AddRoleGroup(RoleGroup);
        }

        #region
        /// <summary>
        /// 查询每种角色下的所有角色组
        /// </summary>
        /// <returns></returns>
        //public IList<RoleGroupTab> SelectAllRolGroups(int RoleID)
        //{
        //    return RGDale.SelectAllRolGroups(RoleID);
        //}
        #endregion

        /// <summary>
        /// 查询每种角色下的所有角色组
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllRolGroup(int RoleID)
        {
            return RGDale.SelectAllRolGroup(RoleID);
        }

        /// <summary>
        /// 检查角色组是否存在
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable IsExistRole(string ID, string name)
        {
            return RGDale.IsExistRole(ID, name);
        }

        /// <summary>
        /// 删除角色组
        /// </summary>
        /// <param name="roleGroupId"></param>
        /// <returns></returns>
        public int DeleteRoleGroup(int roleGroupId)
        {
            return RGDale.DeleteRoleGroup(roleGroupId);
        }

        /// <summary>
        /// 修改角色组信息
        /// </summary>
        /// <param name="roleTab"></param>
        /// <returns></returns>
        public bool UPdateRoleGroupInfo(RoleGroupTab roleTab)
        {
            return RGDale.UPdateRoleGroupInfo(roleTab);
        }

        /// <summary>
        /// 根据角色ID获取信息
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
        /// 查找Vip用户
        /// </summary>
        /// <param name="MemberGradeID"></param>
        /// <returns></returns>
        public DataTable GetListVip(string MemberGradeID)
        {
            return RGDale.GetListVip(MemberGradeID);
        }

        /// <summary>
        /// 用test数据库
        /// </summary>
        /// <param name="TableViewName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="SelectStr">查询字段</param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">总记录</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return RGDale.GetListT(TableViewName, Key, SelectStr, Criteria, Sort,
            ref CurrentPage, PageSize, ref TotalCount);
        }
    }
}
