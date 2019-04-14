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
        /// ��ӽ�ɫ
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool AddRole(RoleTab role)
        {
            return roleDal.AddRole(role);
        }

        /// <summary>
        /// ��ѯ���н�ɫ
        /// </summary>
        /// <returns></returns>
        public IList<RoleTab> SelectAllRoles()
        {
            return roleDal.SelectAllRoles();
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="IsCheck"></param>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public int UpdateCheck(int IsCheck, int RoleID)
        {
            return roleDal.UpdateCheck(IsCheck, RoleID);
        }

        /// <summary>
        /// ����ɫ�Ƿ����
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable IsExistRole(string ID, string name)
        {
            return roleDal.IsExistRole(ID, name);
        }

        /// <summary>
        /// ���ݽ�ɫID�õ���ɫ��Ϣ
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleTab GetRoleById(string roleId)
        {
            return roleDal.GetRoleById(roleId);
        }

        /// <summary>
        /// �޸Ľ�ɫ��Ϣ
        /// </summary>
        /// <param name="roleTab"></param>
        /// <returns></returns>
        public bool UPdateRoleInfo(RoleTab roleTab)
        {
            return roleDal.UPdateRoleInfo(roleTab);
        }

        /// <summary>
        /// ɾ����ɫ
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public int deleteRoleById(int roleID)
        {
            return roleDal.deleteRoleById(roleID);
        }
    }
}
