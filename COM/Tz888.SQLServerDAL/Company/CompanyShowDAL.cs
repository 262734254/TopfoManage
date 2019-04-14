using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.Model.Company;


namespace Tz888.SQLServerDAL.Company
{
    public class CompanyShowDAL : Tz888.IDAL.Company.ICompanyShow
    {
        #region ICompanyShow 成员
        CrmDBHelper crm = new CrmDBHelper();
        /// <summary>
        /// 根据编号查询出所对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyShow SelAllShow(int id)
        {
            CompanyShow model = new CompanyShow();
            string sql = "select  CompanyID,UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,Hit,countrycode,provinceid,cityid,countyid,orderId,Recomm,RoleId ,CompanyName,Industry"
                + " from CompanyShow  where CompanyID=@id ";
            SqlParameter[] para ={ 
                new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            DataSet ds = crm.QueryShow(sql, para);
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

                model.Countrycode = ds.Tables[0].Rows[0]["countrycode"].ToString();
                model.Provinceid = ds.Tables[0].Rows[0]["provinceid"].ToString();
                model.Cityid = ds.Tables[0].Rows[0]["cityid"].ToString();
                model.Countyid = ds.Tables[0].Rows[0]["countyid"].ToString();
                model.OrderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
                model.RoleId = int.Parse(ds.Tables[0].Rows[0]["RoleId"].ToString());
                model.Recomm = ds.Tables[0].Rows[0]["Recomm"].ToString();
                model.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                if (ds.Tables[0].Rows[0]["Hit"].ToString() != "")
                {
                    model.Hit = int.Parse(ds.Tables[0].Rows[0]["Hit"].ToString());//点击率
                }

                    model.Industry = ds.Tables[0].Rows[0]["Industry"].ToString();//点击率
       
                
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据用户名查询出所对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyShow SelAllShows(string userName)
        {
            CompanyShow model = new CompanyShow();
            string sql = "select  CompanyID,UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,Hit,countrycode,provinceid,cityid,countyid,orderId,Recomm,CompanyName "
                + " from CompanyShow  where UserName=@UserName ";
            SqlParameter[] para ={ 
                new SqlParameter("@UserName",SqlDbType.VarChar,50)
            };
            para[0].Value = userName;
            DataSet ds = crm.QueryShow(sql, para);
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

                model.Countrycode = ds.Tables[0].Rows[0]["countrycode"].ToString();
                model.Provinceid = ds.Tables[0].Rows[0]["provinceid"].ToString();
                model.Cityid = ds.Tables[0].Rows[0]["cityid"].ToString();
                model.Countyid = ds.Tables[0].Rows[0]["countyid"].ToString();
                model.OrderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
                model.Recomm = ds.Tables[0].Rows[0]["Recomm"].ToString();
                if (ds.Tables[0].Rows[0]["Hit"].ToString() != "")
                {
                    model.Hit = int.Parse(ds.Tables[0].Rows[0]["Hit"].ToString());//点击率
                }
                return model;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 根据用户名查找是否有记录数
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistsName(string loginName)
        {

            string sql = "select count(UserName) as loginName from CompanyShow where UserName='" + loginName + "'";
            DataSet ds = crm.Querys(sql);
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
            DataSet ds = crm.Querys(sql, para);
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
        /// 修改展厅信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyShow(CompanyShow model, int id)
        {
            int num = 0;
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
            

            strSql.Append("Countrycode=@Countrycode,");
            strSql.Append("Provinceid=@Provinceid,");
            strSql.Append("Cityid=@Cityid,");
            strSql.Append("Countyid=@Countyid,"); 
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("Recomm=@Recomm1");
            strSql.Append(" where CompanyID=@CompanyID ");
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
                   
                    new SqlParameter("@Countrycode", SqlDbType.VarChar,20),
                    new SqlParameter("@Provinceid", SqlDbType.VarChar,20),
                    new SqlParameter("@Cityid", SqlDbType.VarChar,20),
                    new SqlParameter("@Countyid", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderId", SqlDbType.Int,4),
                    new SqlParameter("@Recomm1", SqlDbType.VarChar,50)
            };
            model.CompanyID = id;
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
           

            parameters[12].Value = model.Countrycode;
            parameters[13].Value = model.Provinceid;
            parameters[14].Value = model.Cityid;
            parameters[15].Value = model.Countyid;
            parameters[16].Value = model.OrderId;
            parameters[17].Value = model.Recomm;
            
            num = Convert.ToInt32(crm.ExecuteSqls(strSql.ToString(), parameters));
            //num = Convert.ToInt32(crm.ExecuteSqls(strSql.ToString(), parameters));
            return num;
        }
        /// <summary>
        /// 查询所有ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelCompanyID()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select CompanyID from CompanyShow order by StartTime desc";
            DataSet ds = crm.ExecuteQueryShow(sql);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("" + row["CompanyID"].ToString() + ",");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 查询所有用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelCompanyUserName()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select UserName from CompanyShow order by StartTime desc";
            DataSet ds = crm.ExecuteQueryShow(sql);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("'" + row["UserName"].ToString() + "',");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 删除所对应的展厅信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteShow(int id)
        {
            int num = 0;
            string sql = "delete from CompanyShow where CompanyID=@id ";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            num = Convert.ToInt32(crm.GetSingleShow(sql, para));
            return num;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="TableViewName"></param>
        /// <param name="Key"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort", SqlDbType.VarChar,255),
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

            DataSet ds = crm.RunProcedureShow("GetDataList", parameters, "ds");

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
        /// <summary>
        /// 点击率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelHit(int id)
        {
            int num = 0;
            return num;
        }
        #endregion
    }
}
