using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using GZS.Model.Park;
namespace GZS.DAL.Park
{
    public class ParkImgDAL
    {
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ParkImgM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ParkimgTab(");
            strSql.Append("parkId,imgName,imgexplain)");
            strSql.Append(" values (");
            strSql.Append("@parkId,@imgName,@imgexplain)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@parkId", SqlDbType.Int,4),
					new SqlParameter("@imgName", SqlDbType.VarChar,50),
					new SqlParameter("@imgexplain", SqlDbType.NVarChar)};
            parameters[0].Value = model.parkId;
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
        public bool Update(ParkImgM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ParkimgTab set ");
            strSql.Append("parkId=@parkId,");
            strSql.Append("imgName=@imgName,");
            strSql.Append("imgexplain=@imgexplain");
            strSql.Append(" where imgId=@imgId");
            SqlParameter[] parameters = {
					new SqlParameter("@imgId", SqlDbType.Int,4),
					new SqlParameter("@parkId", SqlDbType.Int,4),
					new SqlParameter("@imgName", SqlDbType.VarChar,50),
					new SqlParameter("@imgexplain", SqlDbType.NVarChar)};
            parameters[0].Value = model.imgId;
            parameters[1].Value = model.parkId;
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
        public bool DeleteByParkId(int ParkId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ParkimgTab ");
            strSql.Append(" where parkid=@parkid");
            SqlParameter[] parameters = {
					new SqlParameter("@parkid", SqlDbType.Int,4)
};
            parameters[0].Value = ParkId;

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
        public bool Delete(int imgId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ParkimgTab ");
            strSql.Append(" where imgId=@imgId");
            SqlParameter[] parameters = {
					new SqlParameter("@imgId", SqlDbType.Int,4)
};
            parameters[0].Value = imgId;

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
        public bool DeleteList(string imgIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ParkimgTab ");
            strSql.Append(" where imgId in (" + imgIdlist + ")  ");
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
        public ParkImgM GetModel(int imgId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 imgId,parkId,imgName,imgexplain from ParkimgTab ");
            strSql.Append(" where imgId=@imgId");
            SqlParameter[] parameters = {
					new SqlParameter("@imgId", SqlDbType.Int,4)
};
            parameters[0].Value = imgId;

            ParkImgM model = new ParkImgM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["imgId"].ToString() != "")
                {
                    model.imgId = int.Parse(ds.Tables[0].Rows[0]["imgId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["parkId"].ToString() != "")
                {
                    model.parkId = int.Parse(ds.Tables[0].Rows[0]["parkId"].ToString());
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
            strSql.Append("select imgId,parkId,imgName,imgexplain ");
            strSql.Append(" FROM ParkimgTab ");
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
            strSql.Append(" imgId,parkId,imgName,imgexplain ");
            strSql.Append(" FROM ParkimgTab ");
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
            parameters[0].Value = "ParkimgTab";
            parameters[1].Value = "imgId";
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
