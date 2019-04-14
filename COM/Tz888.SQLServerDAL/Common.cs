using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// 国家地区信息数据库访问逻辑类
    /// </summary>
    public class Common2
    {

        /// <summary>
        /// 获取所有的国家信息
        /// </summary>
        /// <returns>所有国家信息列表</returns>
        public DataView GetCountryList()
        {
            SqlParameter[] parameters = {
                                            new SqlParameter("@flag", SqlDbType.VarChar,30),
			};
            parameters[0].Value = "CountryList";
            DataSet ds = DbHelperSQL.RunProcedure3("AreaGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 获取指定国家的所有省级行政区信息 
        /// </summary>
        /// <param name="CountryID">国家代码</param>
        /// <returns>所有省级行政区信息</returns>
        public DataView GetProvinceList(string CountryCode)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@CountryCode", SqlDbType.VarChar,10),
                new SqlParameter("@flag", SqlDbType.VarChar,30),
			};
            parameters[0].Value = CountryCode;
            parameters[1].Value = "ProvinceList";
            DataSet ds = DbHelperSQL.RunProcedure3("AreaGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 获取指定省的所有市级行政区信息
        /// </summary>
        /// <param name="ProvinceID">省级行政区代码</param>
        /// <returns>市级行政区信息</returns>
        public DataView GetCityList(string ProvinceID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
                 new SqlParameter("@flag", SqlDbType.VarChar,30),
			};
            parameters[0].Value = ProvinceID;
            parameters[1].Value = "CityList";
            DataSet ds = DbHelperSQL.RunProcedure3("AreaGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 获取指定市的所有县的信息
        /// </summary>
        /// <param name="CityID">城市代码</param>
        /// <returns>县信息</returns>
        public DataView GetCountyList(string CityID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@CityID", SqlDbType.VarChar,10),
                new SqlParameter("@flag", SqlDbType.VarChar,30),
			};
            parameters[0].Value = CityID;
            parameters[1].Value = "CountyList";
            DataSet ds = DbHelperSQL.RunProcedure3("AreaGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 行业列表
        /// </summary>
        /// <returns></returns>
        public DataView GetIndustryList()
        {
            SqlParameter[] parameters = { };
            DataSet ds = DbHelperSQL.RunProcedure3("IndustryGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
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

        /// <summary>
        /// 从各表 查询单列  并需要查询条件
        /// </summary>
        /// <returns></returns>
        public DataTable GetCommonTop(string FileName, string TableName, string Where, int Top)
        {
            SqlParameter[] parameters = {
                                    new SqlParameter("@FileName", SqlDbType.VarChar,300),
                new SqlParameter("@TableName", SqlDbType.VarChar,30),
                new SqlParameter("@Where", SqlDbType.VarChar,300),
                new SqlParameter("@Top", SqlDbType.Int),
			};
            parameters[0].Value = FileName;
            parameters[1].Value = TableName;
            parameters[2].Value = Where;
            parameters[3].Value = Top;
            DataSet ds = DbHelperSQL.RunProcedure3("Common_Top", parameters, "Top");

            return ds.Tables["Top"];
        }
        /// <summary>
        /// 使用Test数据库从各表 查询单列  并需要查询条件
        /// </summary>
        /// <returns></returns>
        public DataTable GetCommonTopT(string FileName, string TableName, string Where, int Top)
        {
            SqlParameter[] parameters = {
                                    new SqlParameter("@FileName", SqlDbType.VarChar,300),
                new SqlParameter("@TableName", SqlDbType.VarChar,30),
                new SqlParameter("@Where", SqlDbType.VarChar,300),
                new SqlParameter("@Top", SqlDbType.Int),
			};
            parameters[0].Value = FileName;
            parameters[1].Value = TableName;
            parameters[2].Value = Where;
            parameters[3].Value = Top;
            DataSet ds = DbHelperSQL.RunProcedureT("Common_Top", parameters, "Top");

            return ds.Tables["Top"];
        }

        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">目标字符串</param>
        /// <param name="length">长度</param>
        /// <returns>返回截取后的字符</returns>
        public string GetString(string str, int length)
        {
            //限制输出字符串
            String output = "";
            if (str.Length < length)
            {
                output = str;
            }
            else
            {
                output = str.Substring(0, length) + "..."; //+ "...";
            }
            return output;
        }
        #endregion
    }
}
