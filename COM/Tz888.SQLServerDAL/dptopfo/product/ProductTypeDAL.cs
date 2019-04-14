using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using GZS.Model.Product;
namespace GZS.DAL.product
{
    public class ProductTypeDAL
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ProductTypeM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into productType(");
            strSql.Append("productName,orderId)");
            strSql.Append(" values (");
            strSql.Append("@productName,@orderId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@productName", SqlDbType.VarChar,50),
                    new SqlParameter("@orderId", SqlDbType.Int)};
            parameters[0].Value = model.productName;

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
        public bool Update(ProductTypeM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update productType set ");
            strSql.Append("productName=@productName");
            strSql.Append(" where productTypeid=@productTypeid");
            SqlParameter[] parameters = {
					new SqlParameter("@productTypeid", SqlDbType.Int,4),
					new SqlParameter("@productName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.productTypeid;
            parameters[1].Value = model.productName;

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
        public bool Delete(int productTypeid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from productType ");
            strSql.Append(" where productTypeid=@productTypeid");
            SqlParameter[] parameters = {
					new SqlParameter("@productTypeid", SqlDbType.Int,4)
};
            parameters[0].Value = productTypeid;

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
        public bool DeleteList(string productTypeidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from productType ");
            strSql.Append(" where productTypeid in (" + productTypeidlist + ")  ");
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
        public ProductTypeM GetModel(int productTypeid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 productTypeid,productName,orderId from productType ");
            strSql.Append(" where productTypeid=@productTypeid");
            SqlParameter[] parameters = {
					new SqlParameter("@productTypeid", SqlDbType.Int,4)
};
            parameters[0].Value = productTypeid;

            ProductTypeM model = new ProductTypeM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["productTypeid"].ToString() != "")
                {
                    model.productTypeid = int.Parse(ds.Tables[0].Rows[0]["productTypeid"].ToString());
                }
                model.orderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
                model.productName = ds.Tables[0].Rows[0]["productName"].ToString();
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
            strSql.Append("select productTypeid,productName,orderId ");
            strSql.Append(" FROM productType ");
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
            strSql.Append(" productTypeid,productName,orderId ");
            strSql.Append(" FROM productType ");
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
