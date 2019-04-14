
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.Model.Advertorial;
namespace Tz888.BLL.Advertorial
{
    public class IndustryType
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(IndustryTypeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into industryTypetab(");
            strSql.Append("industryName,CheckiD,classID,Desciption)");
            strSql.Append(" values (");
            strSql.Append("@industryName,@CheckiD,@classID,@Desciption)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@industryName", SqlDbType.VarChar,50),
					new SqlParameter("@CheckiD", SqlDbType.Int,4),
					new SqlParameter("@classID", SqlDbType.Int,4),
                    new SqlParameter("@Desciption", SqlDbType.VarChar,2000)};
            parameters[0].Value = model.industryName;
            parameters[1].Value = model.CheckiD;
            parameters[2].Value = model.classID;
            parameters[3].Value = model.desc;
            object obj = Tz888.DBUtility.DBHelper.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(IndustryTypeModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update industryTypetab set ");
            strSql.Append("industryName=@industryName,");
            strSql.Append("CheckiD=@CheckiD,");
            strSql.Append("classID=@classID,");
            strSql.Append("Desciption=@Desciption");
            strSql.Append(" where industryID=@industryID");
            SqlParameter[] parameters = {
					new SqlParameter("@industryID", SqlDbType.Int,4),
					new SqlParameter("@industryName", SqlDbType.VarChar,50),
					new SqlParameter("@CheckiD", SqlDbType.Int,4),
					new SqlParameter("@classID", SqlDbType.Int,4),
                    new SqlParameter("@Desciption", SqlDbType.VarChar,2000)};

            parameters[0].Value = model.industryID;
            parameters[1].Value = model.industryName;
            parameters[2].Value = model.CheckiD;
            parameters[3].Value = model.classID;
            parameters[4].Value = model.desc;
            int rows = Tz888.DBUtility.DBHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int industryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from industryTypetab ");
            strSql.Append(" where industryID=@industryID");
            SqlParameter[] parameters = {
					new SqlParameter("@industryID", SqlDbType.Int,4)
};
            parameters[0].Value = industryID;

            int rows = Tz888.DBUtility.DBHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string industryIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from industryTypetab ");
            strSql.Append(" where industryID in (" + industryIDlist + ")  ");
            int rows = Tz888.DBUtility.DBHelper.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public IndustryTypeModel GetModel(int industryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 industryID,industryName,Desciption,CheckiD,classID from industryTypetab ");
            strSql.Append(" where industryID=@industryID");
            SqlParameter[] parameters = {
					new SqlParameter("@industryID", SqlDbType.Int,4)
};
            parameters[0].Value = industryID;

            IndustryTypeModel model = new IndustryTypeModel();
            DataSet ds = Tz888.DBUtility.DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["industryID"].ToString() != "")
                {
                    model.industryID = int.Parse(ds.Tables[0].Rows[0]["industryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Desciption"].ToString() != "")
                {
                    model.desc = ds.Tables[0].Rows[0]["Desciption"].ToString();
                }
                model.industryName = ds.Tables[0].Rows[0]["industryName"].ToString();
                if (ds.Tables[0].Rows[0]["CheckiD"].ToString() != "")
                {
                    model.CheckiD = int.Parse(ds.Tables[0].Rows[0]["CheckiD"].ToString());
                }
                if (ds.Tables[0].Rows[0]["classID"].ToString() != "")
                {
                    model.classID = int.Parse(ds.Tables[0].Rows[0]["classID"].ToString());
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
            strSql.Append("select industryID,industryName,CheckiD,Desciption,classID ");
            strSql.Append(" FROM industryTypetab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Tz888.DBUtility.DBHelper.Query(strSql.ToString());
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
            strSql.Append(" industryID,industryName,CheckiD,classID,Desciption ");
            strSql.Append(" FROM industryTypetab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return Tz888.DBUtility.DBHelper.Query(strSql.ToString());
        }

    }
}
