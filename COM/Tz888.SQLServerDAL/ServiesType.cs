using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.DBUtility;//请先添加引用
namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// 数据访问类setServiesBigTab 。
    /// </summary>
    public class ServiesType
    {
        public ServiesType()
        { }
        #region  成员方法


        /// <summary>
        ///  添加大类
        /// </summary>
        public bool AddServiesB(string ServiesBName, int IndexNum,string Remark)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@ServiesBName", SqlDbType.VarChar,50),
                    new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@IndexNum", SqlDbType.Int,4)};
            parameters[0].Value = "InsertB";
            parameters[1].Value = ServiesBName;
            parameters[2].Value = Remark;
            parameters[3].Value = IndexNum; 

            bool b = DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }
        /// <summary>
        ///  添加小类
        /// </summary>
        public bool AddServiesM(int ServiesBID, string ServiesMName, int IndexNum, string Remark)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,30),
                    new SqlParameter("@ServiesBID", SqlDbType.Int),
					new SqlParameter("@ServiesMName", SqlDbType.VarChar,50),
                     new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@IndexNum", SqlDbType.Int,4)};
            parameters[0].Value = "InsertM";
            parameters[1].Value = ServiesBID;
            parameters[2].Value = ServiesMName;
            parameters[3].Value = Remark;
            parameters[4].Value = IndexNum;

            bool b = DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }

        /// <summary>
        ///  更新大类
        /// </summary>
        public bool UpdateServiesB(int ServiesBID, string ServiesBName, int IndexNum, string Remark, bool isShow)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ServiesBID", SqlDbType.Int,4),
					new SqlParameter("@ServiesBName", SqlDbType.VarChar,50),
					new SqlParameter("@IndexNum", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.Text),
                    new SqlParameter("@isShow", SqlDbType.Bit),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)};
            parameters[0].Value = ServiesBID;
            parameters[1].Value = ServiesBName;
            parameters[2].Value = IndexNum;
            parameters[3].Value = Remark;
            parameters[4].Value = isShow;
            parameters[5].Value = "UpdateBAll";
            bool b = DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }
        public bool UpdateServiesB(int ServiesBID, string ServiesBName, int IndexNum)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ServiesBID", SqlDbType.Int,4),
					new SqlParameter("@ServiesBName", SqlDbType.VarChar,50),
					new SqlParameter("@IndexNum", SqlDbType.Int,4),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)};
            parameters[0].Value = ServiesBID;
            parameters[1].Value = ServiesBName;
            parameters[2].Value = IndexNum;
            parameters[3].Value = "UpdateBNum";
            bool b = DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }
        /// <summary>
        ///  更新小类
        /// </summary>
        public bool UpdateServiesM(int ServiesMID, int ServiesBID, string ServiesMName, int IndexNum, string Remark, bool isShow)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ServiesMID", SqlDbType.Int,4),
                    new SqlParameter("@ServiesBID", SqlDbType.Int,4),
					new SqlParameter("@ServiesMName", SqlDbType.VarChar,50),
					new SqlParameter("@IndexNum", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.Text),
                    new SqlParameter("@isShow", SqlDbType.Bit),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)};
            parameters[0].Value = ServiesMID;
            parameters[1].Value = ServiesBID;
            parameters[2].Value = ServiesMName;
            parameters[3].Value = IndexNum;
            parameters[4].Value = Remark;
            parameters[5].Value = isShow;
            parameters[6].Value = "UpdateMAll";
            bool b = DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }

        public bool UpdateServiesM(int ServiesMID, string ServiesMName, int IndexNum)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ServiesMID", SqlDbType.Int,4), 
					new SqlParameter("@ServiesMName", SqlDbType.VarChar,50),
					new SqlParameter("@IndexNum", SqlDbType.Int,4),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)};
            parameters[0].Value = ServiesMID; 
            parameters[1].Value = ServiesMName;
            parameters[2].Value = IndexNum;
            parameters[3].Value = "UpdateMNum";
            bool b = DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }
        //大类是否显示
        public bool ShowBServies(int ServiesBID, bool isShow)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ServiesBID", SqlDbType.Int,4), 
					new SqlParameter("@isShow", SqlDbType.Bit),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)};
            parameters[0].Value = ServiesBID;
            parameters[1].Value = isShow;
            parameters[2].Value = "ShowB";
            bool b = DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }
        //小类是否显示
        public bool ShowMServies(int ServiesMID, bool isShow)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ServiesMID", SqlDbType.Int,4), 
					new SqlParameter("@isShow", SqlDbType.Bit),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)};
            parameters[0].Value = ServiesMID;
            parameters[1].Value = isShow;
            parameters[2].Value = "ShowM";
            bool b = DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }
        /// <summary>
        ///  更新排列
        /// </summary> 
        public bool UpdateServiesIndex()
        {
            SqlParameter[] parameters = { null };
            bool b = DbHelperSQL.RunProcLob3("USP_ServicesTabInit", parameters);
            return b;
        }

        public bool UpdateServiesIndex(int ID, int IndexNum)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4), 
					new SqlParameter("@IndexNum", SqlDbType.Int,4) };
            parameters[0].Value = ID; 
            parameters[1].Value = IndexNum;
            bool b = DbHelperSQL.RunProcLob3("UpdateServicesType", parameters);
            return b;
        }


        /// <summary>
        /// 删除大类
        /// </summary>
        public bool DeleteServiesB(int ServiesBID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ServiesBID", SqlDbType.Int,4),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)
				};
            parameters[0].Value = ServiesBID;
            parameters[1].Value = "DeleteB";
            bool b = DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }

        /// <summary>
        /// 删除小类
        /// </summary>
        public bool DeleteServiesM(int ServiesMID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ServiesMID", SqlDbType.Int,4),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)
				};
            parameters[0].Value = ServiesMID;
            parameters[1].Value = "DeleteM";
            bool b=DbHelperSQL.RunProcLob3("ServiesType", parameters);
            return b;
        }
        
        /// <summary>
        /// 服务一级分类列表
        /// </summary>
        /// <returns></returns>
        public DataView GetServiesList(bool isShow)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@flag", SqlDbType.VarChar,30),
                new SqlParameter("@isShow", SqlDbType.Bit),
			};
            parameters[0].Value = "GetB";
            parameters[1].Value = isShow;
            DataSet ds = DbHelperSQL.RunProcedure3("ServiesTypeGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        
        /// <summary>
        /// 服务二级分类列表
        /// </summary>
        /// <returns></returns>
        public DataView GetServiesList(int ServiesBID, bool isShow)
        {
            SqlParameter[] parameters = {
									new SqlParameter("@ServiesBID", SqlDbType.Int),
                                    new SqlParameter("@flag", SqlDbType.VarChar,30),
                                    new SqlParameter("@isShow", SqlDbType.Bit),
			};
            parameters[0].Value = ServiesBID;
            parameters[1].Value = "GetM";
            parameters[2].Value = isShow;
            DataSet ds = DbHelperSQL.RunProcedure3("ServiesTypeGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 所有分类
        /// </summary>
        /// <returns></returns>
        public DataView GetServiesAllList()
        {
            SqlParameter[] parameters = {
                                    new SqlParameter("@flag", SqlDbType.VarChar,30),
			};
            parameters[0].Value = "GetAll";
            DataSet ds = DbHelperSQL.RunProcedure3("ServiesTypeGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        #endregion  成员方法
    }
}

