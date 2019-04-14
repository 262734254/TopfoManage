using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using GZS.Model.Menu;
using Tz888.DBUtility;
namespace GZS.DAL.Menu
{
    /// <summary>
    /// ���ݷ�����SysMenuTab��
    /// </summary>
    public class SysMenuTab 
    {
        public SysMenuTab()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysMenuTab");
            strSql.Append(" where sid=@sid ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters[0].Value = sid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// �˵������Ƿ���ͬ
        /// </summary>
        public bool ExistsMenuName(string menuName)
        {
            StringBuilder strSql = new StringBuilder();
            string name = string.Empty;
            strSql.Append("select Sname from SysMenuTab");
            strSql.Append(" where Sname=@Sname ");
            SqlParameter[] parameters = {
					new SqlParameter("@Sname", SqlDbType.VarChar,100)};
            parameters[0].Value = menuName;

            SqlDataReader reader = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters);
            if (reader.Read())
            {
                name = reader["Sname"].ToString();
            }
            if (name.Equals(menuName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(GZS.Model.Menu.SysMenuTab model)
        {
            int identity = 0;
            bool a = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.Int,4),
					new SqlParameter("@SName", SqlDbType.VarChar,100),
					new SqlParameter("@SCheck", SqlDbType.Int,4),
					new SqlParameter("@Surl", SqlDbType.VarChar,300),
					new SqlParameter("@SisActive", SqlDbType.Int,4),
					new SqlParameter("@SParentCode", SqlDbType.Int,4),
					new SqlParameter("@SCode", SqlDbType.VarChar,200),
					new SqlParameter("@Starget", SqlDbType.VarChar,50),
                    new SqlParameter("@SOrder", SqlDbType.Int,4),
                    new SqlParameter("@SParentSid", SqlDbType.Int,4),
                    new SqlParameter("@identity", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.SName;
            parameters[2].Value = model.SCheck;
            parameters[3].Value = model.Surl;
            parameters[4].Value = model.SisActive;
            parameters[5].Value = model.SParentCode;
            parameters[6].Value = model.SCode;
            parameters[7].Value = model.Starget;
            parameters[8].Value = model.Sorder;
            parameters[9].Value = model.Sparentsid;
            parameters[10].Direction = ParameterDirection.Output;
            try
            {
                a = DbHelperSQL.RunProcLob("SysMenuTab_insert", parameters);
            }
            catch (Exception ex2)
            {

                throw ex2;
            }
            if (a)
            {

                if (parameters[10].Value != null)
                {
                    identity = Convert.ToInt32(parameters[10].Value);
                }
                else
                {
                    identity = 0;
                }
            }
            return identity;
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(GZS.Model.Menu.SysMenuTab model)
        {
            bool a = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.Int,4),
                    new SqlParameter("@SName", SqlDbType.VarChar,100),
                    new SqlParameter("@SCheck", SqlDbType.Int,4),
                    new SqlParameter("@Surl", SqlDbType.VarChar,300),
                    new SqlParameter("@SisActive", SqlDbType.Int,4),
                    new SqlParameter("@SParentCode", SqlDbType.Int,4),
                    new SqlParameter("@SCode", SqlDbType.VarChar,200),
                    new SqlParameter("@Starget", SqlDbType.VarChar,50),
                    new SqlParameter("@SOrder", SqlDbType.Int,4),
                     new SqlParameter("@SParentSid", SqlDbType.Int,4)
            };
            parameters[0].Value = model.sid;
            parameters[1].Value = model.SName;
            parameters[2].Value = model.SCheck;
            parameters[3].Value = model.Surl;
            parameters[4].Value = model.SisActive;
            parameters[5].Value = model.SParentCode;
            parameters[6].Value = model.SCode;
            parameters[7].Value = model.Starget;
            parameters[8].Value = model.Sorder;
            parameters[9].Value = model.Sparentsid;
            try
            {
                a = DbHelperSQL.RunProcLob("SysMenuTab_insert", parameters);
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
            return a;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysMenuTab ");
            strSql.Append(" where sid=@sid ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters[0].Value = sid;

            int a = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (a > 0)
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
        public bool Delete1(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @var int");
            strSql.Append(" set @var=@sid");
            strSql.Append(" delete from SysMenuTab ");
            strSql.Append(" where sid=@sid ");
            strSql.Append(" delete from SysMenuTab ");
            strSql.Append(" where SparentCode=@var ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters[0].Value = sid;

            int a = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (a > 0)
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
        public GZS.Model.Menu.SysMenuTab GetModel(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sid,SName,SCheck,Surl,SisActive,SParentCode,SCode,Starget,SDate,SOrder,SParentSid from SysMenuTab ");
            strSql.Append(" where sid=@sid ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters[0].Value = sid;

            GZS.Model.Menu.SysMenuTab model = new GZS.Model.Menu.SysMenuTab();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["sid"].ToString() != "")
                {
                    model.sid = int.Parse(ds.Tables[0].Rows[0]["sid"].ToString());
                }
                model.SName = ds.Tables[0].Rows[0]["SName"].ToString();
                if (ds.Tables[0].Rows[0]["SCheck"].ToString() != "")
                {
                    model.SCheck = int.Parse(ds.Tables[0].Rows[0]["SCheck"].ToString());
                }
                model.Surl = ds.Tables[0].Rows[0]["Surl"].ToString();
                if (ds.Tables[0].Rows[0]["SisActive"].ToString() != "")
                {
                    model.SisActive = int.Parse(ds.Tables[0].Rows[0]["SisActive"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SParentCode"].ToString() != "")
                {
                    model.SParentCode = int.Parse(ds.Tables[0].Rows[0]["SParentCode"].ToString());
                }
                model.SCode = ds.Tables[0].Rows[0]["SCode"].ToString();
                model.Starget = ds.Tables[0].Rows[0]["Starget"].ToString();
                if (ds.Tables[0].Rows[0]["SDate"].ToString() != "")
                {
                    model.SDate = DateTime.Parse(ds.Tables[0].Rows[0]["SDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SOrder"].ToString() != "")
                {
                    model.Sorder = int.Parse(ds.Tables[0].Rows[0]["SOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SParentSid"].ToString() != "")
                {
                    model.Sparentsid = int.Parse(ds.Tables[0].Rows[0]["SParentSid"].ToString());
                }
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
            strSql.Append("select sid,SName,SCheck,Surl,SisActive,SParentCode,SCode,Starget,SDate,SOrder,SParentSid ");
            strSql.Append(" FROM SysMenuTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// ��������б�(ȡ�������ֶ�)
        /// </summary>
        public DataSet GetListSingle(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Surl,SCode ");
            strSql.Append(" FROM SysMenuTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" sid,SName,SCheck,Surl,SisActive,SParentCode,SCode,Starget,SDate,SOrder,SParentSid ");
            strSql.Append(" FROM SysMenuTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// ��ҳ��ȡ�����б�
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
            parameters[0].Value = "SysMenuTab";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  ��Ա����


        #region ISysMenuTab ��Ա


        public IList<GZS.Model.Menu.SysMenuTab> GetList(int SParentCode, string sort)
        {
            IList<GZS.Model.Menu.SysMenuTab> list = new List<GZS.Model.Menu.SysMenuTab>();
            string sql = "select  * from sysMenuTab where SParentCode=" + SParentCode;
            if (sort != "")
            {
                sql += " order by sorder " + sort;
            }
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    GZS.Model.Menu.SysMenuTab menu = new GZS.Model.Menu.SysMenuTab();
                    menu.SCheck = (int)reader["SCheck"];
                    menu.sid = (int)reader["sid"];
                    menu.SisActive = (int)reader["SisActive"];
                    menu.SName = reader["SName"].ToString();
                    menu.SParentCode = (int)reader["SParentCode"];
                    menu.Starget = reader["Starget"].ToString();
                    menu.Surl = reader["Surl"].ToString();
                    menu.SCode = reader["SCode"].ToString();
                    menu.SDate = Convert.ToDateTime(reader["SDate"]);
                    menu.Sorder = (int)reader["SOrder"];
                    menu.Sparentsid = (int)reader["SParentSid"];
                    list.Add(menu);
                }
            }
            return list;
        }
        #endregion

        public IList<GZS.Model.Menu.SysMenuTab> GetList()
        {
            IList<GZS.Model.Menu.SysMenuTab> list = new List<GZS.Model.Menu.SysMenuTab>();
            string sql = "select  * from sysMenuTab";

            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    GZS.Model.Menu.SysMenuTab menu = new GZS.Model.Menu.SysMenuTab();
                    menu.SCheck = (int)reader["SCheck"];
                    menu.sid = (int)reader["sid"];
                    menu.SisActive = (int)reader["SisActive"];
                    menu.SName = reader["SName"].ToString();
                    menu.SParentCode = (int)reader["SParentCode"];
                    menu.Starget = reader["Starget"].ToString();
                    menu.Surl = reader["Surl"].ToString();
                    menu.SCode = reader["SCode"].ToString();
                    menu.SDate = Convert.ToDateTime(reader["SDate"]);
                    menu.Sorder = (int)reader["SOrder"];
                    menu.Sparentsid = (int)reader["SParentSid"];
                    list.Add(menu);
                }
            }
            return list;
        }

    }
}

