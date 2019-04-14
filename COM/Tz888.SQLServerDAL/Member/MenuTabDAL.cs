using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data;
using System.Data.SqlClient;
namespace Tz888.SQLServerDAL.ManageSystem
{
    public class MenuTabDAL
    {
        #region 添加菜单
        public bool addMenuInfo(Tz888.Model.ManageSystem.MenuTabModel model)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@MName",SqlDbType.NVarChar,100),
                new SqlParameter("@MCheck",SqlDbType.Int,4),
                new SqlParameter("@Murl",SqlDbType.NVarChar,300),
                new SqlParameter("@IsActive",SqlDbType.Int,4),
                new SqlParameter("@MparentCode",SqlDbType.Int),
                new SqlParameter("@MCode",SqlDbType.NVarChar,200),
                new SqlParameter("@target",SqlDbType.NVarChar,50),
                new SqlParameter("@MDate",SqlDbType.DateTime,8),
                new SqlParameter("@Sort",SqlDbType.NVarChar,100)
            };
            parms[0].Value = model.MName;
            parms[1].Value = model.MCheck;
            parms[2].Value = model.Murl;
            parms[3].Value = model.MIsActive.ToString();
            parms[4].Value = model.MparentCode;
            parms[5].Value = model.MCode;
            parms[6].Value = model.Target;
            parms[7].Value = model.MDate.ToShortDateString();
            parms[8].Value = model.Sort;

            bool isOK = DbHelperSQL.RunProcLob("proc_addMenuTabInfo", parms);

            return isOK;
        }
        #endregion

        #region 获取菜单列表
        public DataTable getMenuInfoList(string MparentCode)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@MparentCode",MparentCode)
            };
            DataSet ds = Tz888.DBUtility.DbHelperSQL.RunProcedure("proc_getMenuList", parm, "MenuTab");
            return ds.Tables[0];

        }
        #endregion

        #region 获取菜单列表ByID
        public DataTable getMenuInfoListByMID(string MID)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@MID",MID)
            };
            DataSet ds = Tz888.DBUtility.DbHelperSQL.RunProcedure("proc_getMenuListById", parm, "MenuTab");
            return ds.Tables[0];

        }
        #endregion
        #region 审核
        public int MenuCheck(string MID, string MCheck)
        {
            return Tz888.DBUtility.DbHelperSQL.ExecuteSql("update MenuTab set MCheck='" + MCheck + "' where MID='" + MID + "'");
        }
        #endregion

        #region 删除
        public bool deletMenuInfoList(string MparentCode, string MID)
        {
            SqlParameter[] parms = new SqlParameter[] 
            {
                new SqlParameter("@MID",MID),
                new SqlParameter("@MparentCode",MparentCode)
            };
            bool isOK = DbHelperSQL.RunProcLob("proc_deleteMenuList", parms);
            return isOK;
        }
        #endregion

        #region 修改菜单
        public bool updateMenuInfo(Tz888.Model.ManageSystem.MenuTabModel model)
        {
            SqlParameter[] parms = new SqlParameter[]
            {
                new SqlParameter("@MName",SqlDbType.NVarChar,100),
                new SqlParameter("@MCheck",SqlDbType.Int,4),
                new SqlParameter("@Murl",SqlDbType.NVarChar,300),
                new SqlParameter("@IsActive",SqlDbType.Int,4),
                new SqlParameter("@MparentCode",SqlDbType.Int),
                new SqlParameter("@MCode",SqlDbType.NVarChar,200),
                new SqlParameter("@target",SqlDbType.NVarChar,50),
                new SqlParameter("@MDate",SqlDbType.DateTime,8),
                new SqlParameter("@MID",SqlDbType.Int),
                new SqlParameter ("@Sort",SqlDbType.NVarChar,100)
            };
            parms[0].Value = model.MName;
            parms[1].Value = model.MCheck;
            parms[2].Value = model.Murl;
            parms[3].Value = model.MIsActive.ToString();
            parms[4].Value = model.MparentCode;
            parms[5].Value = model.MCode;
            parms[6].Value = model.Target;
            parms[7].Value = model.MDate.ToShortDateString();
            parms[8].Value = model.Mid.ToString();
            parms[9].Value = model.Sort.ToString();
            bool isOK = DbHelperSQL.RunProcLob("proc_updateMenuTabInfo", parms);

            return isOK;
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MID,MName,MCheck,Murl,MIsActive,MParentCode,MCode,target,MDate,Sort ");
            strSql.Append(" FROM MenuTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int UpdateSort(int id, int sort)
        {
            string strSQL = string.Format("UPDATE MenuTab SET Sort={1} WHERE MID={0}", id, sort);
            object obj = DbHelperSQL.ExecuteSql(strSQL);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

    }
}
