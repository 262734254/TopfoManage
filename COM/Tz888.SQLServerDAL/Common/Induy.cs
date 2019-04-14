using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Common
{
    public class Induy
    {
        #region 获取所有行业信息
        /// <summary>
        /// 获取所有行业信息
        /// </summary>
        /// <returns></returns>
        public DataView dvGetAllAre()
        {
            string sql = "select CountryCode, ProvinceID,ProvinceName from SetProvinceTab ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        #endregion
        #region 获取融资金额信息
        /// <summary>
        /// 获取融资金额信息
        /// </summary>
        /// <returns></returns>
        public string dvGetCapitalNae(string Money)
        {
            string name = "";
            string sql = "select CapitalID ,CapitalName from SetCapitalTab where CapitalID=@Money";
            SqlParameter[] para ={ 
               new SqlParameter("@Money",SqlDbType.VarChar,20)
            };
            para[0].Value = Money.ToString().Trim();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return "暂未填写";
            if (ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0]["CapitalName"].ToString();
            }
            return name;
        }
        #endregion
        #region 获取省名字
        /// <summary>
        /// 获取省名字
        /// </summary>
        /// <returns></returns> 

        public string dvGetProveName(string ProvinceID)
        {
            string name = "";
            string sql = "select ProvinceName from SetProvinceTab where ProvinceID=@ProvinceID";
            SqlParameter[] para ={ 
               new SqlParameter("@ProvinceID",SqlDbType.VarChar,20)
            };
            para[0].Value = ProvinceID.ToString().Trim();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0]["ProvinceName"].ToString();
            }
            return name;
        }
        #endregion
        #region 获取投资省名字
        /// <summary>
        /// 获取投资省名字
        /// </summary>
        /// <returns></returns>
        public string dvGetCatialProveName(string ProvinceID)
        {
            string name = "";
            if (ProvinceID.ToString().Trim() == "")
            {
                name = "全国";
                return name;
            }
            if (ProvinceID.IndexOf(",") != 1)
            {


                string[] num = ProvinceID.Split(',');
                for (int i = 0; i < num.Length - 1; i++)
                {
                    string sql = "select ProvinceName from SetProvinceTab where ProvinceID=@ProvinceID";
                    SqlParameter[] para ={
                new SqlParameter("@ProvinceID",SqlDbType.VarChar,20)};
                    para[0].Value = num[i];
                    DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
                    if (ds.Tables[0].Rows.Count > 0)
                    {


                        name += ds.Tables[0].Rows[0]["ProvinceName"].ToString() + " ";

                    }
                    else
                    {
                        return null;
                    }

                }

            }
            else
            {
                string sql = "select ProvinceName from SetProvinceTab where ProvinceID=@ProvinceID";
                SqlParameter[] para ={
                new SqlParameter("@ProvinceID",SqlDbType.VarChar,20)};
                para[0].Value = ProvinceID.ToString().Trim(); ;
                DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
                if (ds.Tables[0].Rows.Count > 0)
                {


                    name = ds.Tables[0].Rows[0]["ProvinceName"].ToString() + " ";

                }
                else
                {
                    return null;
                }
            }
            return name;
        }
        #endregion
        #region 获取市名字
        /// <summary>
        /// 获取市名字
        /// </summary>
        /// <returns></returns>
        public string dvGetCa(string CityID)
        {
            string name = "";
            string sql = "select CityName from SetCityTab where CityID=@CityID";
            SqlParameter[] para ={ 
               new SqlParameter("@CityID",SqlDbType.VarChar,20)
            };
            para[0].Value = CityID.ToString().Trim();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return "暂未填写";
            if (ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0]["CityName"].ToString();
            }
            return name;
        }
        #endregion
        #region 获取行页
        /// <summary>
        /// 根据ID获取行页
        /// </summary>
        /// <returns></returns>
        public string IndustrySelect(string IndustryBID)
        {
            string Name = "";

            if (IndustryBID.ToString().Trim() == "")
            {
                Name = "暂无行业";
                return Name;
            }
            if (IndustryBID.IndexOf(",") != 1)
            {

                string sql = "SELECT * FROM SetIndustryBTab where IndustryBID =@IndustryBID";
                SqlParameter[] para ={
                new SqlParameter("@IndustryBID",SqlDbType.VarChar,20)};
                para[0].Value = IndustryBID.ToString().Trim(); ;
                DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
                if (ds.Tables[0].Rows.Count > 0)
                {


                    Name = ds.Tables[0].Rows[0]["IndustryBName"].ToString() + " ";

                }
                else
                {
                    return null;
                }

            }
            else
            {

                string[] num = IndustryBID.Split(',');
                for (int i = 0; i < num.Length - 1; i++)
                {
                    string sql = "SELECT * FROM SetIndustryBTab where IndustryBID =@IndustryBID";
                    SqlParameter[] para ={
                new SqlParameter("@IndustryBID",SqlDbType.VarChar,20)};
                    para[0].Value = num[i];
                    DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
                    if (ds.Tables[0].Rows.Count > 0)
                    {


                        Name += ds.Tables[0].Rows[0]["IndustryBName"].ToString() + " ";

                    }
                    else
                    {
                        return null;
                    }

                }
            }

            return Name;




        }

        #endregion
        #region 截取字符串的个数
        public string StrLength(object title)
        {
            string name = "";
            name = title.ToString();
            if (name.Length > 600)
            {
                name = name.Substring(0, 600) + "...";
            }
            return name;
        }
        #endregion
        public string CooperationDemandType(string DemandType)
        {
            string name = "";
            if (DemandType.ToString().Trim() == "")
            {
                name = "不限";
                return name;
            }
            string Demand = "";
            if (DemandType.Trim().IndexOf(",") != 1)
            {



                string num = DemandType.ToString().Trim();
                if (num == "1")
                {
                    Demand = "资金借贷";
                }
                if (num == "11")
                {
                    Demand = "直接投资";
                }
                if (num == "2")
                {
                    Demand = "股权投资";
                }
                name += Demand + "";
            }
            else
            {
                string[] num = DemandType.Split(',');
                for (int i = 0; i < num.Length - 1; i++)
                {
                    if (num[i] == "1")
                    {
                        Demand = "资金借贷";
                    }
                    if (num[i] == "11")
                    {
                        Demand = "直接投资";
                    }
                    if (num[i] == "2")
                    {
                        Demand = "股权投资";
                    }
                    name += Demand + " ";


                }
            }
            return name;

        }
        #region 截获定长的字符串
        /// <summary>
        /// 截获定长的字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="length">需要截获的长度</param>
        /// <param name="postfix">如果字符串被截短，需要添加什么样的后缀</param>
        /// <returns>截获后的字符串</returns>
        public string FixLenth(string source, int length, string postfix)
        {
            int postfixLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(postfix);
            int srcLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(source);

            if (srcLength > length)
            {
                for (int i = source.Length; i > 0; i--)
                {
                    srcLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(source.Substring(0, i));

                    if (srcLength <= length - postfixLength)
                        return source.Substring(0, i) + postfix;
                }
                return "";
            }
            else
                return source;
        }
        #endregion

        #region //根据省ID获取市的集合
        /// <summary>
        /// //获取省集合
        /// </summary>
        /// <returns></returns>
        public DataView dvGetCity(string provinceID)
        {
            string sql = "select * from SetCityTab where provinceID=@provinceID ";
            SqlParameter[] para ={ 
               new SqlParameter("@provinceID",SqlDbType.VarChar,20)
            };
            para[0].Value = provinceID.ToString().Trim();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);

            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        #endregion

        #region //获取行业集合
        /// <summary>
        /// 获取行业集合
        /// </summary>
        /// <returns></returns>
        public DataView dvGetVocation()
        {
            string sql = "SELECT * FROM SetIndustryBTab  ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        #endregion
    }
}
