using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using Tz888.Model.FenZhan;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.FenZhan
{
    //分站管理
    public class FenZhanDAL
    {
        private readonly CrmDBHelper crm = new CrmDBHelper();

        /// <summary>
        /// 发布分站
        /// </summary>
        /// <param name="Model">实体</param>
        /// <returns></returns>
        public bool Add(FenZhanModel Model)
        {
            string sql = "insert into FenZhanInfo(FenZhanName,Address,CreateTime,ProvinceID) values(@FenZhanName,@Address,@CreateTime,@ProvinceID)";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@FenZhanName",SqlDbType.VarChar,100),
                new SqlParameter("@Address",SqlDbType.VarChar,100),
                new SqlParameter("@CreateTime",SqlDbType.DateTime),
                new SqlParameter("@ProvinceID",SqlDbType.Int,4)
            };
            Paras[0].Value = Model.FenZhanName;
            Paras[1].Value = Model.Address;
            Paras[2].Value = Model.CreateTime;
            Paras[3].Value = Model.ProvinceID;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改分站
        /// </summary>
        /// <param name="Model">实体</param>
        public bool Modfiy(FenZhanModel Model)
        {
            string sql = "update FenZhanInfo set FenZhanName=@FenZhanName,Address=@Address,ProvinceID=@ProvinceID where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@FenZhanName",SqlDbType.VarChar,100),
                new SqlParameter("@Address",SqlDbType.VarChar,100),
                new SqlParameter("@ProvinceID",SqlDbType.Int,4),
                new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = Model.FenZhanName;
            Paras[1].Value = Model.Address;
            Paras[2].Value = Model.ProvinceID;
            Paras[3].Value = Model.Id;

            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据ID获取当前分站信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>DataTable</returns>
        public DataTable GetFenZhanById(string Id)
        {
            string sql = "select * from FenZhanInfo where Id=@Id";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@Id",SqlDbType.Int,4)
            };
            Paras[0].Value = Id;
            return crm.GetDataSet(sql, Paras);
        }

        /// <summary>
        /// 获取所有分站
        /// </summary>
        /// <returns></returns>
        public DataTable GetFenZhanList()
        {
            string sql = "select * from FenZhanInfo";
            return crm.GetDataSet(sql);
        }

        /// <summary>
        /// 修改网站状态
        /// </summary>
        /// <param name="SiteState">状态码(SiteState=0->关闭,SiteState=1->开启)</param>
        /// <returns></returns>
        public bool ModfiySiteState(string SiteState)
        {
            string sql = "update FenZhanInfo set IsEnabled=@IsEnabled";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@IsEnabled",SqlDbType.Int,4)
            };
            Paras[0].Value = SiteState;
            int row = crm.ExecuteSql(sql, Paras);
            if (row > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取分站名称
        /// </summary>
        /// <param name="ProviceID"></param>
        /// <returns></returns>
        public string GetFenZhanName(string ProviceID)
        {
            string FenZhanName = "";

            string sql = "select FenZhanName from FenZhanInfo where ProvinceId=@ProvinceId";
            SqlParameter[] Paras = new SqlParameter[] { 
                new SqlParameter("@ProvinceId",SqlDbType.Int,4)
            };
            Paras[0].Value = ProviceID;
            if (crm.ExecuteScalar(CommandType.Text, sql, Paras) == null)
                FenZhanName = "&nbsp;";
            else
                FenZhanName = crm.ExecuteScalar(CommandType.Text, sql, Paras).ToString();
            return FenZhanName;
        }
    }
}
