using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GZS.Model.Invest;
using System.Data.SqlClient;
namespace GZS.DAL.Invest
{
    public class TzbigTypeDAL
    {
        #region  Method

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(TzbigTypeM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tzbigType(");
            strSql.Append("tztypeName,tzParId)");
            strSql.Append(" values (");
            strSql.Append("@tztypeName,@tzParId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@tztypeName", SqlDbType.VarChar,50),
            new SqlParameter("@tzParId", SqlDbType.Int,4)};
            parameters[0].Value = model.tztypeName;
            parameters[1].Value = model.tzParId;
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
        /// ����һ������
        /// </summary>
        public bool Update(TzbigTypeM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tzbigType set ");
            strSql.Append("tztypeName=@tztypeName,tzParId=@tzParId");
            strSql.Append(" where tztypeid=@tztypeid");
            SqlParameter[] parameters = {
					new SqlParameter("@tztypeid", SqlDbType.Int,4),
					new SqlParameter("@tztypeName", SqlDbType.VarChar,50),
            new SqlParameter("@tzParId", SqlDbType.Int,4)};
            parameters[0].Value = model.tztypeid;
            parameters[1].Value = model.tztypeName;
            parameters[2].Value = model.tzParId;
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
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int tztypeid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tzbigType ");
            strSql.Append(" where tztypeid=@tztypeid");
            SqlParameter[] parameters = {
					new SqlParameter("@tztypeid", SqlDbType.Int,4)
};
            parameters[0].Value = tztypeid;

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
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string tztypeidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tzbigType ");
            strSql.Append(" where tztypeid in (" + tztypeidlist + ")  ");
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
        /// �õ�һ������ʵ��
        /// </summary>
        public TzbigTypeM GetModel(int tztypeid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 tztypeid,tzParId,tztypeName from tzbigType ");
            strSql.Append(" where tztypeid=@tztypeid");
            SqlParameter[] parameters = {
					new SqlParameter("@tztypeid", SqlDbType.Int,4)
};
            parameters[0].Value = tztypeid;

            TzbigTypeM model = new TzbigTypeM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["tztypeid"].ToString() != "")
                {
                    model.tztypeid = int.Parse(ds.Tables[0].Rows[0]["tztypeid"].ToString());
                }
                model.tzParId = int.Parse(ds.Tables[0].Rows[0]["tzParId"].ToString());
                model.tztypeName = ds.Tables[0].Rows[0]["tztypeName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tztypeid,tzParId,tztypeName ");
            strSql.Append(" FROM tzbigType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" tztypeid,tzParId,tztypeName ");
            strSql.Append(" FROM tzbigType ");
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
