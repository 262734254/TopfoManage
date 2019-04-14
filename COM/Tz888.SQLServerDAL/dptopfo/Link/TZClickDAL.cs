using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Link;
using System.Data;
using System.Data.SqlClient;
namespace GZS.DAL.Link
{
    public class TZClickDAL
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TZClickM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TZClick(");
            strSql.Append("loginName,createTime,ClickId,PageId)");
            strSql.Append(" values (");
            strSql.Append("@loginName,getdate(),@ClickId,@PageId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					//new SqlParameter("@createTime", SqlDbType.DateTime),
					new SqlParameter("@ClickId", SqlDbType.Int,4),
            new SqlParameter("@PageId", SqlDbType.Int,4)};
            parameters[0].Value = model.loginName;
            //parameters[1].Value = model.createTime;
            parameters[1].Value = model.ClickId;
            parameters[2].Value = model.PageId;
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
        public bool Update(TZClickM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TZClick set ");
            strSql.Append("loginName=@loginName,");
            strSql.Append("createTime=@createTime,");
            strSql.Append("ClickId=@ClickId,");
            strSql.Append("PageId=@PageId");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@createTime", SqlDbType.DateTime),
					new SqlParameter("@ClickId", SqlDbType.Int,4),
            new SqlParameter("@PageId", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.loginName;
            parameters[2].Value = model.createTime;
            parameters[3].Value = model.ClickId;
            parameters[4].Value = model.PageId;
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
        //public int ModfiyHit(string name, int pageId)
        //{
        //    int num = 0;
        //    DateTime na = DateTime.Now;
        //    string startTime = na.ToString("yyyy-MM-dd") + " 23:59:59";
        //    string endTime = na.AddDays(-1).ToString("yyyy-MM-dd") + " 00:00:00";
        //    string sql = "select ClickId from TZClick where loginname=@name and PageId=@PageId and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
        //    SqlParameter[] para ={ 
        //        new SqlParameter("@name",SqlDbType.VarChar,50),
        //       new SqlParameter("@PageId",SqlDbType.Int,4)
        //    };
        //    para[0].Value = name;
        //    para[1].Value = pageId;
        //    num = Convert.ToInt32(DBHelper.GetSingle(sql.ToString(), para).ToString());
        //    int Hit = num + 1;
        //    string sqll = "update TZClick set ClickId=@ClickId where loginname=@name and PageId=@PageId and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
        //    SqlParameter[] sqlpara ={ 
        //         new SqlParameter("@ClickId",SqlDbType.Int,8),
        //         new SqlParameter("@name",SqlDbType.VarChar,50),
        //         new SqlParameter("@PageId",SqlDbType.Int,8)
        //    };
        //    sqlpara[0].Value = Hit;
        //    sqlpara[1].Value = name;
        //    sqlpara[2].Value = pageId;
        //    int com = Convert.ToInt32(DBHelper.GetSingle(sqll, sqlpara));
        //    return Hit;
        //}
        public int ModfiyHit(string name, int pageId)
        {
            int num = 0;
            DateTime na = DateTime.Now;
            string startTime = na.ToString("yyyy-MM-dd") + " 23:59:59";
            string endTime = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
            string sql = "select ClickId from TZClick where loginname=@name and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)//,
               //new SqlParameter("@PageId",SqlDbType.Int,4)
            };
            para[0].Value = name;
            //para[1].Value = pageId;
            num = Convert.ToInt32(DBHelper.GetSingle(sql.ToString(), para).ToString());
            int Hit = num + 1;
            string sqll = "update TZClick set ClickId=@ClickId where loginname=@name and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
            SqlParameter[] sqlpara ={ 
                 new SqlParameter("@ClickId",SqlDbType.Int,8),
                 new SqlParameter("@name",SqlDbType.VarChar,50)//,
                 //new SqlParameter("@PageId",SqlDbType.Int,8)
            };
            sqlpara[0].Value = Hit;
            sqlpara[1].Value = name;
            //sqlpara[2].Value = pageId;
            int com = Convert.ToInt32(DBHelper.GetSingle(sqll, sqlpara));
            return Hit;
        }
        //public bool ExistsIsUserName(string loginName, int pageId)
        //{
        //    DateTime na = DateTime.Now;
        //    string startTime = na.ToString("yyyy-MM-dd") + " 23:59:59";
        //    string endTime = na.AddDays(-1).ToString("yyyy-MM-dd") + " 00:00:00";
        //    string sql = "select count(loginname) as loginname from dbo.TZClick where  PageId=" + pageId + " and loginname='" + loginName + "'  and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
        //    DataSet ds = DBHelper.Query(sql.ToString());
        //    if (int.Parse(ds.Tables[0].Rows[0]["loginname"].ToString()) > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public bool ExistsIsUserName(string loginName, int pageId)
        {
            DateTime na = DateTime.Now;
            string startTime = na.ToString("yyyy-MM-dd") + " 23:59:59";
            string endTime = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
            string sql = "select count(loginname) as loginname from dbo.TZClick where loginname='" + loginName + "'  and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
            DataSet ds = DBHelper.Query(sql.ToString());
            if (int.Parse(ds.Tables[0].Rows[0]["loginname"].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获得今日,昨天，历史用户访问量
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="day">0,表是历史，1,表示今天 2，表是昨天</param>
        /// <returns></returns>
        public int GetTodayCount(string loginName, int day)
        {
            DateTime na = DateTime.Now;
            string sql = "";
            if (day == 0)
            {
                sql = "select sum(clickid) as clickid from dbo.TZClick where loginname='" + loginName + "'";
            }
            else if (day == 1)
            {
                string startTime = na.ToString("yyyy-MM-dd") + " 23:59:59";
                string endTime = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59"; //00:00:00
                sql = "select sum(clickid) as clickid from dbo.TZClick where loginname='" + loginName + "'  and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
            }
            else
            {
                string yesterdayStart = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
                string yesterdayEnd = na.AddDays(-2).ToString("yyyy-MM-dd") + " 23:59:59";
                sql = "select sum(clickid) as clickid from dbo.TZClick where loginname='" + loginName + "'  and createtime>'" + yesterdayEnd + "' and createtime<= '" + yesterdayStart + "'";
            }
            DataSet ds = DBHelper.Query(sql.ToString());
            if (ds != null)
            {
                try
                {
                    return int.Parse(ds.Tables[0].Rows[0]["clickid"].ToString());
                }
                catch (Exception)
                {

                    return 0;
                }

            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 获得今日,昨天，历史用户访问量
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="day">0,表是历史，1,表示今天 2，表是昨天</param>
        /// <returns></returns>
        //public int GetTodayCount(string loginName, int day)
        //{
        //    DateTime na = DateTime.Now;
        //    string sql = "";
        //    if (day == 0)
        //    {
        //        sql = "select sum(clickid) as clickid from dbo.TZClick where  pageid>0 and loginname='" + loginName + "'";
        //    }
        //    else if (day == 1)
        //    {
        //        string startTime = na.ToString("yyyy-MM-dd") + " 23:59:59";
        //        string endTime = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59"; //00:00:00
        //        sql = "select sum(clickid) as clickid from dbo.TZClick where  pageid>0 and loginname='" + loginName + "'  and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
        //    }
        //    else
        //    {
        //        string yesterdayStart = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
        //        string yesterdayEnd = na.AddDays(-2).ToString("yyyy-MM-dd") + " 23:59:59";
        //        sql = "select sum(clickid) as clickid from dbo.TZClick where  pageid>0 and loginname='" + loginName + "'  and createtime>'" + yesterdayEnd + "' and createtime<= '" + yesterdayStart + "'";
        //    }
        //    DataSet ds = DBHelper.Query(sql.ToString());
        //    if (ds != null)
        //    {
        //        try
        //        {
        //            return int.Parse(ds.Tables[0].Rows[0]["clickid"].ToString());
        //        }
        //        catch (Exception)
        //        {

        //            return 0;
        //        }

        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        /// <summary>
        /// 获得单个页面今日,昨天，历史用户访问量
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="pageId">页面ID</param>
        /// <param name="day">0,表是历史，1,表示今天 2，表是昨天</param>
        /// <returns></returns>
        public int GetTodayCount(string loginName, int pageId, int day)
        {
            DateTime na = DateTime.Now;
            string sql = "";
            if (day == 0)
            {
                sql = "select sum(clickid) as clickid from dbo.TZClick where loginname='" + loginName + "'";
            }
            else if (day == 1)
            {
                string startTime = na.ToString("yyyy-MM-dd") + " 23:59:59";
                string endTime = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";//00:00:00
                sql = "select sum(clickid) as clickid from dbo.TZClick where  loginname='" + loginName + "'  and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
            }
            else
            {
                string yesterdayStart = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
                string yesterdayEnd = na.AddDays(-2).ToString("yyyy-MM-dd") + " 23:59:59";//00:00:00";
                sql = "select sum(clickid) as clickid from dbo.TZClick where loginname='" + loginName + "'  and createtime>'" + yesterdayEnd + "' and createtime<= '" + yesterdayStart + "'";
            }
            DataSet ds = DBHelper.Query(sql.ToString());
            if (ds != null)
            {
                try
                {
                    return int.Parse(ds.Tables[0].Rows[0]["clickid"].ToString());
                }
                catch (Exception)
                {

                    return 0;
                }

            }
            else
            {
                return 0;
            }

        }
        /// <summary>
        /// 获得单个页面今日,昨天，历史用户访问量
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="pageId">页面ID</param>
        /// <param name="day">0,表是历史，1,表示今天 2，表是昨天</param>
        /// <returns></returns>
        //public int GetTodayCount(string loginName, int pageId, int day)
        //{
        //    DateTime na = DateTime.Now;
        //    string sql = "";
        //    if (day == 0)
        //    {
        //        sql = "select sum(clickid) as clickid from dbo.TZClick where  PageId=" + pageId + " and loginname='" + loginName + "'";
        //    }
        //    else if (day == 1)
        //    {
        //        string startTime = na.ToString("yyyy-MM-dd") + " 23:59:59";
        //        string endTime = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";//00:00:00
        //        sql = "select sum(clickid) as clickid from dbo.TZClick where  PageId=" + pageId + " and loginname='" + loginName + "'  and createtime>'" + endTime + "' and createtime<= '" + startTime + "'";
        //    }
        //    else
        //    {
        //        string yesterdayStart = na.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
        //        string yesterdayEnd = na.AddDays(-2).ToString("yyyy-MM-dd") + " 23:59:59";//00:00:00";
        //        sql = "select sum(clickid) as clickid from dbo.TZClick where  PageId=" + pageId + " and loginname='" + loginName + "'  and createtime>'" + yesterdayEnd + "' and createtime<= '" + yesterdayStart + "'";
        //    }
        //    DataSet ds = DBHelper.Query(sql.ToString());
        //    if (ds!=null)
        //    {
        //        try
        //        {
        //            return int.Parse(ds.Tables[0].Rows[0]["clickid"].ToString());
        //        }
        //        catch (Exception)
        //        {

        //            return 0;
        //        }
                
        //    }
        //    else
        //    {
        //        return 0;
        //    }
            
        //}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TZClick ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TZClick ");
            strSql.Append(" where id in (" + idlist + ")  ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TZClickM GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,PageId,loginName,createTime,ClickId from TZClick ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            TZClickM model = new TZClickM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                if (ds.Tables[0].Rows[0]["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClickId"].ToString() != "")
                {
                    model.ClickId = int.Parse(ds.Tables[0].Rows[0]["ClickId"].ToString());
                } if (ds.Tables[0].Rows[0]["PageId"].ToString() != "")
                {
                    model.PageId = int.Parse(ds.Tables[0].Rows[0]["PageId"].ToString());
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
            strSql.Append("select id,PageId,loginName,createTime,ClickId ");
            strSql.Append(" FROM TZClick ");
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
            strSql.Append(" id,PageId,loginName,createTime,ClickId ");
            strSql.Append(" FROM TZClick ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.Query(strSql.ToString());
        }
        #endregion  Method
    }
}
