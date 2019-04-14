using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// ���ҵ�����Ϣ���ݿ�����߼���
    /// </summary>
    public class Common2
    {

        /// <summary>
        /// ��ȡ���еĹ�����Ϣ
        /// </summary>
        /// <returns>���й�����Ϣ�б�</returns>
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
        /// ��ȡָ�����ҵ�����ʡ����������Ϣ 
        /// </summary>
        /// <param name="CountryID">���Ҵ���</param>
        /// <returns>����ʡ����������Ϣ</returns>
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
        /// ��ȡָ��ʡ�������м���������Ϣ
        /// </summary>
        /// <param name="ProvinceID">ʡ������������</param>
        /// <returns>�м���������Ϣ</returns>
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
        /// ��ȡָ���е������ص���Ϣ
        /// </summary>
        /// <param name="CityID">���д���</param>
        /// <returns>����Ϣ</returns>
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
        /// ��ҵ�б�
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
        /// ����һ�������б�
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
        /// ������������б�
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
        /// ���з���
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
        /// �Ӹ��� ��ѯ����  ����Ҫ��ѯ����
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
        /// ʹ��Test���ݿ�Ӹ��� ��ѯ����  ����Ҫ��ѯ����
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

        #region ��ȡ�ַ���
        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="str">Ŀ���ַ���</param>
        /// <param name="length">����</param>
        /// <returns>���ؽ�ȡ����ַ�</returns>
        public string GetString(string str, int length)
        {
            //��������ַ���
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
