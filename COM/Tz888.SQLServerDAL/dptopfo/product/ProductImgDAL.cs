using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Product;
using System.Data;
using System.Data.SqlClient;
namespace GZS.DAL.product
{
    public class ProductImgDAL
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ProductImgM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into productImage(");
            strSql.Append("productid,imgName,imgexplain)");
            strSql.Append(" values (");
            strSql.Append("@productid,@imgName,@imgexplain)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@imgName", SqlDbType.VarChar,120),
					new SqlParameter("@imgexplain", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.productid;
            parameters[1].Value = model.imgName;
            parameters[2].Value = model.imgexplain;

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
        public bool Update(ProductImgM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update productImage set ");
            strSql.Append("productid=@productid,");
            strSql.Append("imgName=@imgName,");
            strSql.Append("imgexplain=@imgexplain");
            strSql.Append(" where Imgid=@Imgid");
            SqlParameter[] parameters = {
					new SqlParameter("@Imgid", SqlDbType.Int,4),
					new SqlParameter("@productid", SqlDbType.Int,4),
					new SqlParameter("@imgName", SqlDbType.VarChar,120),
					new SqlParameter("@imgexplain", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Imgid;
            parameters[1].Value = model.productid;
            parameters[2].Value = model.imgName;
            parameters[3].Value = model.imgexplain;

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
        public bool Delete(int Imgid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from productImage ");
            strSql.Append(" where Imgid=@Imgid");
            SqlParameter[] parameters = {
					new SqlParameter("@Imgid", SqlDbType.Int,4)
};
            parameters[0].Value = Imgid;

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
        public bool DeleteByProductId(int ProcductId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from productImage ");
            strSql.Append(" where ProductId=@Imgid");
            SqlParameter[] parameters = {
					new SqlParameter("@Imgid", SqlDbType.Int,4)
};
            parameters[0].Value = ProcductId;

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
        public bool DeleteList(string Imgidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from productImage ");
            strSql.Append(" where Imgid in (" + Imgidlist + ")  ");
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
        public ProductImgM GetModel(int Imgid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Imgid,productid,imgName,imgexplain from productImage ");
            strSql.Append(" where Imgid=@Imgid");
            SqlParameter[] parameters = {
					new SqlParameter("@Imgid", SqlDbType.Int,4)
};
            parameters[0].Value = Imgid;

            ProductImgM model = new ProductImgM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Imgid"].ToString() != "")
                {
                    model.Imgid = int.Parse(ds.Tables[0].Rows[0]["Imgid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["productid"].ToString() != "")
                {
                    model.productid = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                }
                model.imgName = ds.Tables[0].Rows[0]["imgName"].ToString();
                model.imgexplain = ds.Tables[0].Rows[0]["imgexplain"].ToString();
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
            strSql.Append("select Imgid,productid,imgName,imgexplain ");
            strSql.Append(" FROM productImage ");
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
            strSql.Append(" Imgid,productid,imgName,imgexplain ");
            strSql.Append(" FROM productImage ");
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
