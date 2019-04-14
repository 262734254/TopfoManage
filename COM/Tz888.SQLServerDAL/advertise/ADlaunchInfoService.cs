using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.Model.advertise;
namespace Tz888.SQLServerDAL.advertise
{
    public class ADlaunchInfoService : Tz888.IDAL.advertise.IADlaunchInfo
    {
        #region 添加一条信息

        public int Add(ADlaunchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ADlaunchInfo(");
            strSql.Append("BID,positionID,Stardate,enddate,Givindate,addoc,Addates,salesman,LoginName,countID)");
            strSql.Append(" values (");
            strSql.Append("@BID,@positionID,@Stardate,@enddate,@Givindate,@addoc,@Addates,@salesman,@LoginName,@countID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BID", SqlDbType.Int,4),
					new SqlParameter("@positionID", SqlDbType.Int,4),
					new SqlParameter("@Stardate", SqlDbType.DateTime),
					new SqlParameter("@enddate", SqlDbType.DateTime),
					new SqlParameter("@Givindate", SqlDbType.DateTime),
					new SqlParameter("@addoc", SqlDbType.NVarChar,200),
					new SqlParameter("@Addates", SqlDbType.DateTime),
					new SqlParameter("@salesman", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginName", SqlDbType.NVarChar,50),
					new SqlParameter("@countID", SqlDbType.Int,4)};
            parameters[0].Value = model.BID;
            parameters[1].Value = model.positionID;
            parameters[2].Value = model.Stardate;
            parameters[3].Value = model.enddate;
            parameters[4].Value = model.Givindate;
            parameters[5].Value = model.addoc;
            parameters[6].Value = model.Addates;
            parameters[7].Value = model.salesman;
            parameters[8].Value = model.LoginName;
            parameters[9].Value = model.countID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
         #endregion
        #region 根据ID删除一条信息
        public int DeleteDlaunchInfo(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ADlaunchInfo ");
            strSql.Append(" where advertiserID=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

           int num= DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
           return num;
        }
         #endregion
        #region 修改信息
        public int UpdatechannelInfo(ADlaunchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ADlaunchInfo set ");
            //strSql.Append("BID=@BID,");
            //strSql.Append("positionID=@positionID,");
            strSql.Append("Stardate=@Stardate,");
            strSql.Append("enddate=@enddate,");
            strSql.Append("Givindate=@Givindate,");
            strSql.Append("addoc=@addoc,");
            //strSql.Append("Addates=@Addates,");
            strSql.Append("salesman=@salesman,");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("countID=@countID");
            strSql.Append(" where advertiserID=@advertiserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@advertiserID", SqlDbType.Int,4),
                    //new SqlParameter("@BID", SqlDbType.Int,4),
                    //new SqlParameter("@positionID", SqlDbType.Int,4),
					new SqlParameter("@Stardate", SqlDbType.DateTime,50),
					new SqlParameter("@enddate", SqlDbType.DateTime,50),
					new SqlParameter("@Givindate", SqlDbType.DateTime,50),
					new SqlParameter("@addoc", SqlDbType.NVarChar,200),
                    //new SqlParameter("@Addates", SqlDbType.DateTime),
					new SqlParameter("@salesman", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginName", SqlDbType.NVarChar,50),
                    new SqlParameter("@countID", SqlDbType.Int,4)};
            parameters[0].Value = model.advertiserID;
            //parameters[1].Value = model.BID;
            //parameters[2].Value = model.positionID;
            parameters[1].Value = model.Stardate;
            parameters[2].Value = model.enddate;
            parameters[3].Value = model.Givindate;
            parameters[4].Value = model.addoc;
            //parameters[7].Value = model.Addates;
            parameters[5].Value = model.salesman;
            parameters[6].Value = model.LoginName;
            parameters[7].Value = model.countID;

           int num= DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
           return num;
        }
         #endregion
        #region 根据ID查询
        public ADlaunchInfo GetAllDlaunchInfoById(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 advertiserID,BID,positionID,Stardate,enddate,Givindate,addoc,Addates,salesman,LoginName,countID from ADlaunchInfo ");
            strSql.Append(" where advertiserID=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            ADlaunchInfo model = new ADlaunchInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["advertiserID"].ToString() != "")
                {
                    model.advertiserID = int.Parse(ds.Tables[0].Rows[0]["advertiserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BID"].ToString() != "")
                {
                    model.BID = int.Parse(ds.Tables[0].Rows[0]["BID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["positionID"].ToString() != "")
                {
                    model.positionID = int.Parse(ds.Tables[0].Rows[0]["positionID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Stardate"].ToString() != "")
                {
                    model.Stardate = DateTime.Parse(ds.Tables[0].Rows[0]["Stardate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["enddate"].ToString() != "")
                {
                    model.enddate = DateTime.Parse(ds.Tables[0].Rows[0]["enddate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Givindate"].ToString() != "")
                {
                    model.Givindate = DateTime.Parse(ds.Tables[0].Rows[0]["Givindate"].ToString());
                }
                model.addoc = ds.Tables[0].Rows[0]["addoc"].ToString();
                if (ds.Tables[0].Rows[0]["Addates"].ToString() != "")
                {
                    model.Addates = DateTime.Parse(ds.Tables[0].Rows[0]["Addates"].ToString());
                }
                model.salesman = ds.Tables[0].Rows[0]["salesman"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                if (ds.Tables[0].Rows[0]["countID"].ToString() != "")
                {
                    model.countID = int.Parse(ds.Tables[0].Rows[0]["countID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsLoginName(string LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LoginInfoTab");
            strSql.Append(" where LoginName=@LoginName ");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.NVarChar,50)};
            parameters[0].Value = LoginName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 处理访问量
        /// </summary>
        /// <param name="id"></param>
        public int ModifCount(int id)
        {
            int num = 0;
            string sql = "select countID from ADlaunchInfo where advertiserID=@Id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para).ToString());
            int count = num + 1;
            string sqll = "update ADlaunchInfo set countID=@count where advertiserID=@Id";
            SqlParameter[] sqlpara ={ 
                 new SqlParameter("@count",SqlDbType.Int,8),
                new SqlParameter("@Id",SqlDbType.Int,8)
            };
            sqlpara[0].Value = count;
            sqlpara[1].Value = id;
            int com = Convert.ToInt32(DbHelperSQL.ExecuteSql(sqll, sqlpara));
            return com;
        }
    }
}
