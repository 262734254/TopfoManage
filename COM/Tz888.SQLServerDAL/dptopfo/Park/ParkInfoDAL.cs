using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GZS.Model.Park;
namespace GZS.DAL.Park
{
    public class ParkInfoDAL
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ParkInfoM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into parkInfoTab(");
            strSql.Append("parkName,parktypeid,Chineseintroduced,Englishintroduction,CreateDate,loginName,htmlurl)");
            strSql.Append(" values (");
            strSql.Append("@parkName,@parktypeid,@Chineseintroduced,@Englishintroduction,getdate(),@loginName,@htmlurl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@parkName", SqlDbType.VarChar,50),
					new SqlParameter("@parktypeid", SqlDbType.Int,4),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
            new SqlParameter("@htmlurl", SqlDbType.VarChar,120)};
            parameters[0].Value = model.parkName;
            parameters[1].Value = model.parktypeid;
            parameters[2].Value = model.Chineseintroduced;
            parameters[3].Value = model.Englishintroduction;
            parameters[4].Value = model.loginName;
            parameters[5].Value = model.htmlurl;

            object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ParkInfoM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update parkInfoTab set ");
            strSql.Append("parkName=@parkName,");
            strSql.Append("parktypeid=@parktypeid,");
            strSql.Append("Chineseintroduced=@Chineseintroduced,");
            strSql.Append("Englishintroduction=@Englishintroduction,");
            strSql.Append("htmlurl=@htmlurl");
            strSql.Append(" where parkid=@parkid");
            SqlParameter[] parameters = {
					new SqlParameter("@parkid", SqlDbType.Int,4),
					new SqlParameter("@parkName", SqlDbType.VarChar,50),
					new SqlParameter("@parktypeid", SqlDbType.Int,4),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
					new SqlParameter("@htmlurl", SqlDbType.VarChar,120)};
            parameters[0].Value = model.parkid;
            parameters[1].Value = model.parkName;
            parameters[2].Value = model.parktypeid;
            parameters[3].Value = model.Chineseintroduced;
            parameters[4].Value = model.Englishintroduction;
            parameters[5].Value = model.htmlurl;

            int rows = DBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int ExistsByParkTypeId(int typeId)
        {
            string sql = "select count(parktypeid) as typeID from parkInfoTab where parktypeid=" + typeId;
            return int.Parse(DBHelper.Query(sql).Tables[0].Rows[0]["typeID"].ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int parkid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from parkInfoTab ");
            strSql.Append(" where parkid=@parkid");
            SqlParameter[] parameters = {
					new SqlParameter("@parkid", SqlDbType.Int,4)
};
            parameters[0].Value = parkid;

            int rows = DBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string parkidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from parkInfoTab ");
            strSql.Append(" where parkid in (" + parkidlist + ")  ");
            int rows = DBHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ParkInfoM GetModel(int parktypeid, string loginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 loginName,parkid,parkName,parktypeid,Chineseintroduced,Englishintroduction,CreateDate from parkInfoTab ");
            strSql.Append(" where parktypeid=@parktypeid and loginName=@loginName");
            SqlParameter[] parameters = {
					new SqlParameter("@parktypeid", SqlDbType.Int,4),
                    new SqlParameter("@loginName", SqlDbType.VarChar,50)
};
            parameters[0].Value = parktypeid;
            parameters[1].Value = loginName;
            ParkInfoM model = new ParkInfoM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["parkid"].ToString() != "")
                {
                    model.parkid = int.Parse(ds.Tables[0].Rows[0]["parkid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.parkName = ds.Tables[0].Rows[0]["parkName"].ToString();
                if (ds.Tables[0].Rows[0]["parktypeid"].ToString() != "")
                {
                    model.parktypeid = int.Parse(ds.Tables[0].Rows[0]["parktypeid"].ToString());
                }
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public ParkInfoM GetParkByLoginName(string loginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 loginName,parkid,parkName,parktypeid,Chineseintroduced,Englishintroduction,CreateDate from parkInfoTab ");
            strSql.Append(" where loginName=@loginName");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50)
};
            parameters[0].Value = loginName;

            ParkInfoM model = new ParkInfoM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["parkid"].ToString() != "")
                {
                    model.parkid = int.Parse(ds.Tables[0].Rows[0]["parkid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.parkName = ds.Tables[0].Rows[0]["parkName"].ToString();
                if (ds.Tables[0].Rows[0]["parktypeid"].ToString() != "")
                {
                    model.parktypeid = int.Parse(ds.Tables[0].Rows[0]["parktypeid"].ToString());
                }
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ParkInfoM GetModel(int parkid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 loginName,parkid,parkName,parktypeid,Chineseintroduced,Englishintroduction,CreateDate from parkInfoTab ");
            strSql.Append(" where parkid=@parkid");
            SqlParameter[] parameters = {
					new SqlParameter("@parkid", SqlDbType.Int,4)
};
            parameters[0].Value = parkid;

            ParkInfoM model = new ParkInfoM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["parkid"].ToString() != "")
                {
                    model.parkid = int.Parse(ds.Tables[0].Rows[0]["parkid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.parkName = ds.Tables[0].Rows[0]["parkName"].ToString();
                if (ds.Tables[0].Rows[0]["parktypeid"].ToString() != "")
                {
                    model.parktypeid = int.Parse(ds.Tables[0].Rows[0]["parktypeid"].ToString());
                }
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select parkid,parkName,parktypeid,loginName,Chineseintroduced,Englishintroduction,CreateDate ");
            strSql.Append(" FROM parkInfoTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" parkid,parkName,parktypeid,loginName,Chineseintroduced,Englishintroduction,CreateDate ");
            strSql.Append(" FROM parkInfoTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "parkInfoTab";
            parameters[1].Value = "parkid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
