using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace GZS.DAL.Menu
{
    public class CompanyShow
    {
        /// <summary>
        /// 根据用户名只查询企业名称
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetCompanyNameByLoginName(string loginName)
        {
            string sql = "select  CompanyName from CompanyShow  where UserName=@loginName ";
            SqlParameter[] para ={ 
                new SqlParameter("@loginName",SqlDbType.VarChar,50)
            };
            para[0].Value = loginName;
            DataSet ds = DBHelper.Query(sql, para);
            if ((ds != null) && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["CompanyName"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 根据用户名查询出所对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GZS.Model.Menu.CompanyShow SelAllShow(string loginName)
        {
            GZS.Model.Menu.CompanyShow model = new GZS.Model.Menu.CompanyShow();
            string sql = "select CompanyName,levels,LevelName, CompanyID,RoleId,UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,Hit "
                + " from CompanyShow  where UserName=@loginName ";
            SqlParameter[] para ={ 
                new SqlParameter("@loginName",SqlDbType.VarChar,50)
            };
            para[0].Value = loginName;
            DataSet ds = DBHelper.Query(sql, para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CompanyID"].ToString() != "")
                {
                    model.CompanyID = int.Parse(ds.Tables[0].Rows[0]["CompanyID"].ToString());//编号
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();//用户名
                if (ds.Tables[0].Rows[0]["UserPwd"].ToString() != "")
                {
                    model.UserPwd = (byte[])ds.Tables[0].Rows[0]["UserPwd"];//密码
                }
                model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();//电话号码
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();//手机号码
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();//电子邮箱
                model.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                model.LevelName = ds.Tables[0].Rows[0]["LevelName"].ToString();
                if (ds.Tables[0].Rows[0]["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["Audit"].ToString());//审核状态
                }
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());//发布时间
                }
                if (ds.Tables[0].Rows[0]["Valid"].ToString() != "")
                {
                    model.Valid = int.Parse(ds.Tables[0].Rows[0]["Valid"].ToString());//展厅有效期
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();//所属类型
                if (ds.Tables[0].Rows[0]["Hit"].ToString() != "")
                {
                    model.Hit = int.Parse(ds.Tables[0].Rows[0]["Hit"].ToString());//点击率
                }
                if (ds.Tables[0].Rows[0]["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(ds.Tables[0].Rows[0]["RoleId"].ToString());//点击率
                }
                if (ds.Tables[0].Rows[0]["levels"].ToString() != "")
                {
                    model.Levels = int.Parse(ds.Tables[0].Rows[0]["levels"].ToString());//点击率
                }
                return model;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GZS.Model.Menu.CompanyShow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CompanyShow(");
            strSql.Append("UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,Hit,RoleId,CompanyName,levels,LevelName)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@TelPhone,@Mobile,@Email,@Audit,@StartTime,@Valid,@TypeName,@Hit,@RoleId,@CompanyName,@levels,@LevelName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.VarBinary,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.VarChar,20),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@levels", SqlDbType.Int,4),
					new SqlParameter("@LevelName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.TelPhone;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Audit;
            parameters[6].Value = model.StartTime;
            parameters[7].Value = model.Valid;
            parameters[8].Value = model.TypeName;
            parameters[9].Value = model.Hit;
            parameters[10].Value = model.RoleId;
            parameters[11].Value = model.CompanyName;
            parameters[12].Value = model.Levels;
            parameters[13].Value = model.LevelName;

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
        public int updateById(int userId)
        {
            string sql = "update CompanyShow set levels=2 where companyID=" + userId;
            return DBHelper.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GZS.Model.Menu.CompanyShow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CompanyShow set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserPwd=@UserPwd,");
            strSql.Append("TelPhone=@TelPhone,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Email=@Email,");
            strSql.Append("Audit=@Audit,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("Valid=@Valid,");
            strSql.Append("TypeName=@TypeName,");
            strSql.Append("Hit=@Hit,");
            strSql.Append("RoleId=@RoleId,");
            strSql.Append("CompanyName=@CompanyName,");
            strSql.Append("levels=@levels,");
            strSql.Append("LevelName=@LevelName");
            strSql.Append(" where CompanyID=@CompanyID");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.VarBinary,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.VarChar,20),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@RoleId", SqlDbType.Int,4),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@levels", SqlDbType.Int,4),
					new SqlParameter("@LevelName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CompanyID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserPwd;
            parameters[3].Value = model.TelPhone;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.Audit;
            parameters[7].Value = model.StartTime;
            parameters[8].Value = model.Valid;
            parameters[9].Value = model.TypeName;
            parameters[10].Value = model.Hit;
            parameters[11].Value = model.RoleId;
            parameters[12].Value = model.CompanyName;
            parameters[13].Value = model.Levels;
            parameters[14].Value = model.LevelName;

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
        public bool Delete(int CompanyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CompanyShow ");
            strSql.Append(" where CompanyID=@CompanyID");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4)
};
            parameters[0].Value = CompanyID;

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
        public bool DeleteList(string CompanyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CompanyShow ");
            strSql.Append(" where CompanyID in (" + CompanyIDlist + ")  ");
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
        public GZS.Model.Menu.CompanyShow GetModel(int CompanyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CompanyID,UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,Hit,RoleId,CompanyName,levels,LevelName from CompanyShow ");
            strSql.Append(" where CompanyID=@CompanyID");
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4)
};
            parameters[0].Value = CompanyID;

            GZS.Model.Menu.CompanyShow model = new GZS.Model.Menu.CompanyShow();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CompanyID"].ToString() != "")
                {
                    model.CompanyID = int.Parse(ds.Tables[0].Rows[0]["CompanyID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["UserPwd"].ToString() != "")
                {
                    model.UserPwd = (byte[])ds.Tables[0].Rows[0]["UserPwd"];
                }
                model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["Audit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Valid"].ToString() != "")
                {
                    model.Valid = int.Parse(ds.Tables[0].Rows[0]["Valid"].ToString());
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                if (ds.Tables[0].Rows[0]["Hit"].ToString() != "")
                {
                    model.Hit = int.Parse(ds.Tables[0].Rows[0]["Hit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleId"].ToString() != "")
                {
                    model.RoleId = int.Parse(ds.Tables[0].Rows[0]["RoleId"].ToString());
                }
                model.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                if (ds.Tables[0].Rows[0]["levels"].ToString() != "")
                {
                    model.Levels = int.Parse(ds.Tables[0].Rows[0]["levels"].ToString());
                }
                model.LevelName = ds.Tables[0].Rows[0]["LevelName"].ToString();
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
            strSql.Append("select CompanyID,UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,Hit,RoleId,CompanyName,levels,LevelName ");
            strSql.Append(" FROM CompanyShow ");
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
            strSql.Append(" CompanyID,UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,Hit,RoleId,CompanyName,levels,LevelName ");
            strSql.Append(" FROM CompanyShow ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.Query(strSql.ToString());
        }

    }
}
