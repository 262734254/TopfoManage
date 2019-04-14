using System;
using System.Collections.Generic;
using System.Text;
using Tz888.SQLServerDAL.ManageSystem;
using Tz888.Model.ManageSystem;
using System.Data;

namespace Tz888.BLL.ManageSystem
{
    public class RoleTabBLL
    {
        RoleTabDAL roleDal = new RoleTabDAL();

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool AddRole(RoleTab role)
        {
            return roleDal.AddRole(role);
        }

        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        public IList<RoleTab> SelectAllRoles()
        {
            return roleDal.SelectAllRoles();
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="IsCheck"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public int UpdateCheck(int IsCheck, int RoleID)
        {
            return roleDal.UpdateCheck(IsCheck, RoleID);
        }

        /// <summary>
        /// 检查角色是否存在
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable IsExistRole(string ID, string name)
        {
            return roleDal.IsExistRole(ID, name);
        }

        /// <summary>
        /// 根据角色ID得到角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleTab GetRoleById(string roleId)
        {
            return roleDal.GetRoleById(roleId);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roleTab"></param>
        /// <returns></returns>
        public bool UPdateRoleInfo(RoleTab roleTab)
        {
            return roleDal.UPdateRoleInfo(roleTab);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public int deleteRoleById(int roleID)
        {
            return roleDal.deleteRoleById(roleID);
        }
    }
}
