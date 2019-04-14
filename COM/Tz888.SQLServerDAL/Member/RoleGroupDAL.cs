using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.ManageSystem;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.ManageSystem
{
    public class RoleGroupDAL
    {
        /// <summary>
        /// 添加角色组
        /// </summary>
        /// <param name="RoleGroup"></param>
        /// <returns></returns>
        public bool AddRoleGroup(RoleGroupTab RoleGroup)
        {
            bool flag = false;
            SqlParameter[] para ={    new SqlParameter("@RoleID",SqlDbType.Int,4),
                                      new SqlParameter("@SName",SqlDbType.NVarChar,100),
                                      new SqlParameter("@SCheck",SqlDbType.Int,4),
                                      new SqlParameter("@SDate",SqlDbType.SmallDateTime,50),
                                      new SqlParameter("@SysID",SqlDbType.NVarChar,50),
                                      new SqlParameter("@IsVIP",SqlDbType.BigInt,4),
                                      new SqlParameter("@Remark",SqlDbType.NVarChar,500),
                                      new SqlParameter("@Pcode",SqlDbType.NVarChar,3000)
                                        
                                };
            para[0].Value = RoleGroup.ManageTypeID;
            para[1].Value = RoleGroup.MemberGradeName;
            para[2].Value = RoleGroup.SCheck;
            para[3].Value = RoleGroup.SDate;
            para[4].Value = RoleGroup.MemberGradeID;
            para[5].Value = RoleGroup.IsVip;
            para[6].Value = RoleGroup.Remark;
            para[7].Value = "暂无";
            flag = DbHelperSQL.RunProcLob("Pro_AddGroupRole", para);
            return flag;
        }
        /// <summary>
        /// 查询出所有角色组
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAllRolGroup(int RoleID)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlParameter[] para ={ new SqlParameter("@RoleID", RoleID) };
            ds = DbHelperSQL.RunProcedure("Pro_GetAllRoleGroups", para, "ds");
            dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// 检查角色组是否存在
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable IsExistRole(string ID, string name)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            SqlParameter[] para ={ new SqlParameter("@RoleGroupID", ID), new SqlParameter("@RoleGroupName", name) };
            ds = DbHelperSQL.RunProcedure("Pro_Pro_IsExistRoleGroup", para, "ds");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }


        /// <summary>
        /// 删除角色组
        /// </summary>
        /// <param name="roleGroupId"></param>
        /// <returns></returns>
        public int DeleteRoleGroup(int roleGroupId)
        {
            int num = 0;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@MemberGradeID", roleGroupId) };
            num = DbHelperSQL.RunProcedureInt("Pro_DeleteRoleGroup", para);
            return num;
        }

        /// <summary>
        /// 修改角色组信息
        /// </summary>
        /// <param name="roleTab"></param>
        /// <returns></returns>
        public bool UPdateRoleGroupInfo(RoleGroupTab roleTab)
        {
            bool flag = false;
            SqlParameter[] para = new SqlParameter[]{ new SqlParameter ("@MemberGradeID",SqlDbType.NVarChar,20),
                                                    new SqlParameter("@SName",SqlDbType.NVarChar,50),
                                                    new SqlParameter("@Remark",SqlDbType.NVarChar,200)
                                    };
            para[0].Value = roleTab.MemberGradeID;
            para[1].Value = roleTab.MemberGradeName;
            para[2].Value = roleTab.Remark;
            flag = DbHelperSQL.RunProcLob("Pro_UpdateRoleGroupInfo", para);
            return flag;
        }

        /// <summary>
        /// 根据角色组ID获取信息
        /// </summary>
        /// <param name="roleGroupId"></param>
        /// <returns></returns>
        public RoleGroupTab GetRoleGroupById(string roleGroupId)
        {
            RoleGroupTab roleGroup = null;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@roleGroupId", roleGroupId) };
            para[0].Value = roleGroupId;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Pro_GetRoleGroupByID", para);
            if (reader.Read())
            {
                roleGroup = new RoleGroupTab();
                roleGroup.MemberGradeID = reader["MemberGradeID"].ToString();
                roleGroup.MemberGradeName = reader["MemberGradeName"].ToString().Trim();
                roleGroup.Remark = reader["Remark"].ToString().Trim();
                roleGroup.SCheck = Convert.ToInt32(reader["SCheck"].ToString().Trim());
            }
            reader.Close();
            reader.Dispose();
            return roleGroup;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleGroupId"></param>
        /// <returns></returns>
        public bool UPdateRoleGroupSCheck(string roleGroupId, int SCheck)
        {
            bool flag = false;
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@MemberGradeID", SqlDbType.NVarChar, 20), new SqlParameter("@SCheck", SqlDbType.Int, 4) };
            para[0].Value = roleGroupId;
            para[1].Value = SCheck;
            flag = DbHelperSQL.RunProcLob("Pro_UpdateCheckGroup", para);
            return flag;
        }

        /// <summary>
        /// 查找Vip
        /// </summary>
        /// <param name="MemberGradeID"></param>
        /// <returns></returns>
        public DataTable GetListVip(string MemberGradeID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlParameter[] para ={ new SqlParameter("@MemberGradeID", SqlDbType.NVarChar, 50) };
            para[0].Value = MemberGradeID;
            ds = DbHelperSQL.RunProcedure("Pro_SelectVipByID", para, "ds");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            else
            {
                dt = null;
            }
            return dt;
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
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = TableViewName;
            parameters[1].Value = Key;
            parameters[2].Value = SelectStr;
            parameters[3].Value = Criteria;
            parameters[4].Value = Sort;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;
            //parameters[7].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }

    }
}
