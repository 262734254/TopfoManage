using System;
using System.Collections.Generic;
using GZS.Model.Product;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace GZS.DAL.product
{
    public class ProductDominDAL
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ProductDominM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into produceDomin(");
            strSql.Append("loginName,Chineseintroduced,Englishintroduction,createdate,htmlurl,clicks,productTypeId,productName)");
            strSql.Append(" values (");
            strSql.Append("@loginName,@Chineseintroduced,@Englishintroduction,getdate(),@htmlurl,0,@productTypeId,@productName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
					//new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@htmlurl", SqlDbType.VarChar,120),
					//new SqlParameter("@clicks", SqlDbType.Int,4),
					new SqlParameter("@productTypeId", SqlDbType.Int,4),
                new SqlParameter("@productName", SqlDbType.VarChar,120)
            };
            parameters[0].Value = model.loginName;
            parameters[1].Value = model.Chineseintroduced;
            parameters[2].Value = model.Englishintroduction;
            // parameters[3].Value = model.createdate;
            parameters[3].Value = model.htmlurl;
            //parameters[5].Value = model.clicks;
            parameters[4].Value = model.productTypeId;
            parameters[5].Value = model.productName;
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
        public bool Update(ProductDominM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update produceDomin set ");
            //strSql.Append("loginName=@loginName,");
            strSql.Append("Chineseintroduced=@Chineseintroduced,");
            strSql.Append("Englishintroduction=@Englishintroduction,");
            //strSql.Append("createdate=@createdate,");
            strSql.Append("htmlurl=@htmlurl,");
            strSql.Append("productName=@productName,");
            //strSql.Append("clicks=@clicks,");
            strSql.Append("productTypeId=@productTypeId");
            strSql.Append(" where productid=@productid");
            SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4),
					//new SqlParameter("@loginName", SqlDbType.VarChar,50),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
					//new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@htmlurl", SqlDbType.VarChar,120),
                new SqlParameter("@productName", SqlDbType.VarChar,120),
					//new SqlParameter("@clicks", SqlDbType.Int,4),
					new SqlParameter("@productTypeId", SqlDbType.Int,4)};
            parameters[0].Value = model.productid;
            //parameters[1].Value = model.loginName;
            parameters[1].Value = model.Chineseintroduced;
            parameters[2].Value = model.Englishintroduction;
            // parameters[4].Value = model.createdate;
            parameters[3].Value = model.htmlurl;
            parameters[4].Value = model.productName;
            //parameters[6].Value = model.clicks;
            parameters[5].Value = model.productTypeId;

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
        public bool Delete(int productid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from produceDomin ");
            strSql.Append(" where productid=@productid");
            SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4)
};
            parameters[0].Value = productid;

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
        public bool DeleteList(string productidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from produceDomin ");
            strSql.Append(" where productid in (" + productidlist + ")  ");
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

        public ProductDominM GetProductByName(string loginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 productid,productname,loginName,Chineseintroduced,Englishintroduction,createdate,htmlurl,clicks,productTypeId from produceDomin ");
            strSql.Append(" where loginName=@loginName");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.VarChar,50)
};
            parameters[0].Value = loginName;

            ProductDominM model = new ProductDominM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["productid"].ToString() != "")
                {
                    model.productid = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.productName = ds.Tables[0].Rows[0]["productname"].ToString();
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(ds.Tables[0].Rows[0]["createdate"].ToString());
                }
                model.htmlurl = ds.Tables[0].Rows[0]["htmlurl"].ToString();
                if (ds.Tables[0].Rows[0]["clicks"].ToString() != "")
                {
                    model.clicks = int.Parse(ds.Tables[0].Rows[0]["clicks"].ToString());
                }
                if (ds.Tables[0].Rows[0]["productTypeId"].ToString() != "")
                {
                    model.productTypeId = int.Parse(ds.Tables[0].Rows[0]["productTypeId"].ToString());
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
        public ProductDominM GetModel(int productid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 productid,productname,loginName,Chineseintroduced,Englishintroduction,createdate,htmlurl,clicks,productTypeId from produceDomin ");
            strSql.Append(" where productid=@productid");
            SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4)
};
            parameters[0].Value = productid;

            ProductDominM model = new ProductDominM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["productid"].ToString() != "")
                {
                    model.productid = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.productName = ds.Tables[0].Rows[0]["productname"].ToString();
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(ds.Tables[0].Rows[0]["createdate"].ToString());
                }
                model.htmlurl = ds.Tables[0].Rows[0]["htmlurl"].ToString();
                if (ds.Tables[0].Rows[0]["clicks"].ToString() != "")
                {
                    model.clicks = int.Parse(ds.Tables[0].Rows[0]["clicks"].ToString());
                }
                if (ds.Tables[0].Rows[0]["productTypeId"].ToString() != "")
                {
                    model.productTypeId = int.Parse(ds.Tables[0].Rows[0]["productTypeId"].ToString());
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
        public ProductDominM GetModel(int productTypeId, string loginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 productid,loginName,Chineseintroduced,Englishintroduction,createdate,htmlurl,clicks,productTypeId from produceDomin ");
            strSql.Append(" where productTypeId=@productid and loginName=@loginname order by createdate desc");
            SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4),
                new SqlParameter("@loginname", SqlDbType.VarChar,50)
};
            parameters[0].Value = productTypeId;
            parameters[1].Value = loginName;
            ProductDominM model = new ProductDominM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["productid"].ToString() != "")
                {
                    model.productid = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
                {
                    model.createdate = DateTime.Parse(ds.Tables[0].Rows[0]["createdate"].ToString());
                }
                model.htmlurl = ds.Tables[0].Rows[0]["htmlurl"].ToString();
                if (ds.Tables[0].Rows[0]["clicks"].ToString() != "")
                {
                    model.clicks = int.Parse(ds.Tables[0].Rows[0]["clicks"].ToString());
                }
                if (ds.Tables[0].Rows[0]["productTypeId"].ToString() != "")
                {
                    model.productTypeId = int.Parse(ds.Tables[0].Rows[0]["productTypeId"].ToString());
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
            strSql.Append("select productid,loginName,productname,Chineseintroduced,Englishintroduction,createdate,htmlurl,clicks,productTypeId ");
            strSql.Append(" FROM produceDomin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.Query(strSql.ToString());
        }
        public int ExistsByProductTypeId(int typeId, string loginName)
        {
            string sql = "select count(productTypeId) as typeID from produceDomin where productTypeId=" + typeId + " and loginname='" + loginName + "'";
            return int.Parse(DBHelper.Query(sql).Tables[0].Rows[0]["typeID"].ToString());
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
            strSql.Append(" productid,loginName,productname,Chineseintroduced,Englishintroduction,createdate,htmlurl,clicks,productTypeId ");
            strSql.Append(" FROM produceDomin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 用test数据库
        /// </summary>
        /// <param name="TableViewName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="SelectStr">查询字段</param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">总记录</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = TableViewName;
            parameters[1].Value = Key;
            parameters[2].Value = SelectStr;
            parameters[3].Value = Criteria;
            parameters[4].Value = Sort;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;
            //parameters[7].Value = 1;

            DataSet ds = DBHelper.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }

        #endregion  Method
    }
}
