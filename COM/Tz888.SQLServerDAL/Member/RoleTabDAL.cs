using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.ManageSystem;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.ManageSystem
{
    public class RoleTabDAL
    {
        #region  添加角色
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool AddRole(RoleTab role)
        {
            bool flag = false;
            SqlParameter[] para ={   new SqlParameter("@RName",SqlDbType.NVarChar,100),
                                     new SqlParameter("@RDoc",SqlDbType.NVarChar,200),
                                     new SqlParameter("@RDate",SqlDbType.SmallDateTime,50),
                                     new SqlParameter("@RoleID",SqlDbType.NVarChar,50),
                                     new SqlParameter("IsCheck",SqlDbType.Int,4)
                                };
            para[0].Value = role.ManageTypeName;
            para[1].Value = role.Remark;
            para[2].Value = role.RDate;
            para[3].Value = role.ManageTypeID;
            para[4].Value = role.IsCheck;
            flag = DbHelperSQL.RunProcLob("Pro_AddRole", para);
            return flag;
        }
        #endregion


        #region 查询出所有角色
        /// <summary>
        /// 查询出所有角色
        /// </summary>
        /// <returns></returns>
        public IList<RoleTab> SelectAllRoles()
        {
            RoleTab role = null;
            IList<RoleTab> listRole = new List<RoleTab>();
            SqlDataReader reader = DbHelperSQL.dataReader("Pro_SelectAllRoles", null);
            while (reader.Read())
            {
                role = new RoleTab();
                role.ManageTypeID = reader["ManageTypeID"].ToString();
                role.ManageTypeName = reader["ManageTypeName"].ToString().Trim();
                role.Remark = reader["Remark"].ToString().Trim();
                role.RDate = Convert.ToDateTime(reader["RData"]);
                role.IsCheck = Convert.ToInt32(reader["IsCheck"]);
                listRole.Add(role);
            }
            reader.Close();
            reader.Dispose();
            return listRole;
        }
        #endregion

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public int UpdateCheck(int IsCheck, int RoleID)
        {
            int num = 0;
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@RoleID",RoleID),
                new SqlParameter("@IsCheck",IsCheck) 
            };
            para[0].Value = RoleID;
            para[1].Value = IsCheck;
            num = DbHelperSQL.RunProcedureInt("Pro_UpdateRoleIsCheck", para);
            return num;
        }

        /// <summary>
        /// 检查角色是否存在
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable IsExistRole(string ID, string name)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlParameter[] para ={ new SqlParameter("@RoleID", ID), new SqlParameter("RoleName", name) };
            ds = DbHelperSQL.RunProcedure("Pro_IsExistRole", para, "ds");
            dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// 根据角色ID得到角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public RoleTab GetRoleById(string roleId)
        {
            RoleTab role = null;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@RoleID", roleId) };
            para[0].Value = roleId;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Pro_GetRoleByID", para);
            if (reader.Read())
            {
                role = new RoleTab();
                role.ManageTypeID = reader["ManageTypeID"].ToString();
                role.ManageTypeName = reader["ManageTypeName"].ToString().Trim();
                role.Remark = reader["Remark"].ToString().Trim();
                role.RDate = Convert.ToDateTime(reader["RData"]);
                role.IsCheck = Convert.ToInt32(reader["IsCheck"]);
            }
            reader.Close();
            reader.Dispose();
            return role;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roleTab"></param>
        /// <returns></returns>
        public bool UPdateRoleInfo(RoleTab roleTab)
        {
            bool flag = false;
            SqlParameter[] para = new SqlParameter[]{ new SqlParameter ("@RoleId",SqlDbType.NVarChar,20),
                                                    new SqlParameter("@RoleName",SqlDbType.NVarChar,50),
                                                    new SqlParameter("@Remark",SqlDbType.NVarChar,200)
                                    };
            para[0].Value = roleTab.ManageTypeID;
            para[1].Value = roleTab.ManageTypeName;
            para[2].Value = roleTab.Remark;
            flag = DbHelperSQL.RunProcLob("Pro_UpdateRoleInfo", para);
            return flag;
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public int deleteRoleById(int roleID)
        {
            int num = 0;
            string roleId=roleID.ToString().Trim();
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@RoleID", roleID) };
            num = DbHelperSQL.RunProcedureInt("Pro_DeleteRoleById", para);
            return num;
        }
    }
}
