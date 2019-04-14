using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL.Sys;
using Maticsoft.DBUtility;//请先添加引用
using Tz888.DBUtility;
using System.Security.Cryptography;

namespace Tz888.SQLServerDAL.Sys
{
    /// <summary>
    /// 数据访问类EmployeeInfoTab。
    /// </summary>
    public class EmployeeInfoTab : IEmployeeInfoTab
    {
        public EmployeeInfoTab()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int EmployeeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from EmployeeInfoTab");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.Int,4)};
            parameters[0].Value = EmployeeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Sys.EmployeeInfoTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EmployeeInfoTab(");
            strSql.Append("LoginName,EmployeeName,Sex,NickName,Birthday,CertificateID,CertificateNumber,CountryCode,ProvinceID,CityID,CountyID,Address,PostCode,Tel,Mobile,FAX,Email,DeptID,WorkType,DegreeID,Enable)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@EmployeeName,@Sex,@NickName,@Birthday,@CertificateID,@CertificateNumber,@CountryCode,@ProvinceID,@CityID,@CountyID,@Address,@PostCode,@Tel,@Mobile,@FAX,@Email,@DeptID,@WorkType,@DegreeID,@Enable)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@EmployeeName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@CertificateID", SqlDbType.Char,10),
					new SqlParameter("@CertificateNumber", SqlDbType.VarChar,20),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.Char,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@FAX", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@DeptID", SqlDbType.Char,10),
					new SqlParameter("@WorkType", SqlDbType.Char,10),
					new SqlParameter("@DegreeID", SqlDbType.Char,10),
					new SqlParameter("@Enable", SqlDbType.Bit,1)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.EmployeeName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.CertificateID;
            parameters[6].Value = model.CertificateNumber;
            parameters[7].Value = model.CountryCode;
            parameters[8].Value = model.ProvinceID;
            parameters[9].Value = model.CityID;
            parameters[10].Value = model.CountyID;
            parameters[11].Value = model.Address;
            parameters[12].Value = model.PostCode;
            parameters[13].Value = model.Tel;
            parameters[14].Value = model.Mobile;
            parameters[15].Value = model.FAX;
            parameters[16].Value = model.Email;
            parameters[17].Value = model.DeptID;
            parameters[18].Value = model.WorkType;
            parameters[19].Value = model.DegreeID;
            parameters[20].Value = model.Enable;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Tz888.Model.Sys.EmployeeInfoTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EmployeeInfoTab set ");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("EmployeeName=@EmployeeName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("CertificateID=@CertificateID,");
            strSql.Append("CertificateNumber=@CertificateNumber,");
            strSql.Append("CountryCode=@CountryCode,");
            strSql.Append("ProvinceID=@ProvinceID,");
            strSql.Append("CityID=@CityID,");
            strSql.Append("CountyID=@CountyID,");
            strSql.Append("Address=@Address,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("FAX=@FAX,");
            strSql.Append("Email=@Email,");
            strSql.Append("DeptID=@DeptID,");
            strSql.Append("WorkType=@WorkType,");
            strSql.Append("DegreeID=@DegreeID,");
            strSql.Append("Enable=@Enable");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@EmployeeName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@CertificateID", SqlDbType.Char,10),
					new SqlParameter("@CertificateNumber", SqlDbType.VarChar,20),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.Char,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@FAX", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@DeptID", SqlDbType.Char,10),
					new SqlParameter("@WorkType", SqlDbType.Char,10),
					new SqlParameter("@DegreeID", SqlDbType.Char,10),
					new SqlParameter("@Enable", SqlDbType.Bit,1)};

            parameters[0].Value = model.EmployeeID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.EmployeeName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.NickName;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.CertificateID;
            parameters[7].Value = model.CertificateNumber;
            parameters[8].Value = model.CountryCode;
            parameters[9].Value = model.ProvinceID;
            parameters[10].Value = model.CityID;
            parameters[11].Value = model.CountyID;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.PostCode;
            parameters[14].Value = model.Tel;
            parameters[15].Value = model.Mobile;
            parameters[16].Value = model.FAX;
            parameters[17].Value = model.Email;
            parameters[18].Value = model.DeptID;
            parameters[19].Value = model.WorkType;
            parameters[20].Value = model.DegreeID;
            parameters[21].Value = model.Enable;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int EmployeeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EmployeeInfoTab ");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.Int,4)};
            parameters[0].Value = EmployeeID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="strLoginName">根据loginname去删除</param>
        /// <returns></returns>
        public int DelEmployee(string strLoginName)
        {
            StringBuilder SqlTxt = new StringBuilder();
            SqlTxt.Append(" delete from employeeinfotab where loginname=@LoginName ");

            SqlParameter[] par ={ new SqlParameter("@LoginName", SqlDbType.VarChar, 16) };
            par[0].Value = strLoginName;
            return DbHelperSQL.ExecuteSql(SqlTxt.ToString(), par);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Sys.EmployeeInfoTab GetModel(int EmployeeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 EmployeeID,LoginName,EmployeeName,Sex,NickName,Birthday,CertificateID,CertificateNumber,CountryCode,ProvinceID,CityID,CountyID,Address,PostCode,Tel,Mobile,FAX,Email,DeptID,WorkType,DegreeID,Enable from EmployeeInfoTab ");
            strSql.Append(" where EmployeeID=@EmployeeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@EmployeeID", SqlDbType.Int,4)};
            parameters[0].Value = EmployeeID;

            Tz888.Model.Sys.EmployeeInfoTab model = new Tz888.Model.Sys.EmployeeInfoTab();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = int.Parse(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                }
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.EmployeeName = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Sex"].ToString() == "1") || (ds.Tables[0].Rows[0]["Sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
                model.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                model.CertificateID = ds.Tables[0].Rows[0]["CertificateID"].ToString();
                model.CertificateNumber = ds.Tables[0].Rows[0]["CertificateNumber"].ToString();
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.FAX = ds.Tables[0].Rows[0]["FAX"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.DeptID = ds.Tables[0].Rows[0]["DeptID"].ToString();
                model.WorkType = ds.Tables[0].Rows[0]["WorkType"].ToString();
                model.DegreeID = ds.Tables[0].Rows[0]["DegreeID"].ToString();
                if (ds.Tables[0].Rows[0]["Enable"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Enable"].ToString() == "1") || (ds.Tables[0].Rows[0]["Enable"].ToString().ToLower() == "true"))
                    {
                        model.Enable = true;
                    }
                    else
                    {
                        model.Enable = false;
                    }
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
        public Tz888.Model.Sys.EmployeeInfoTab GetModel(string strUserLoginName)
        {
            //select top 10 * from employeeinfotab where loginname='test'
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from EmployeeInfoTab ");
            strSql.Append(" where loginname=@UserLoginName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserLoginName", SqlDbType.VarChar,50)};
            parameters[0].Value = strUserLoginName;

            Tz888.Model.Sys.EmployeeInfoTab model = new Tz888.Model.Sys.EmployeeInfoTab();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = int.Parse(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                }
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.EmployeeName = ds.Tables[0].Rows[0]["EmployeeName"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Sex"].ToString() == "1") || (ds.Tables[0].Rows[0]["Sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
                model.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                model.CertificateID = ds.Tables[0].Rows[0]["CertificateID"].ToString();
                model.CertificateNumber = ds.Tables[0].Rows[0]["CertificateNumber"].ToString();
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.FAX = ds.Tables[0].Rows[0]["FAX"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.DeptID = ds.Tables[0].Rows[0]["DeptID"].ToString();
                model.WorkType = ds.Tables[0].Rows[0]["WorkType"].ToString();
                model.DegreeID = ds.Tables[0].Rows[0]["DegreeID"].ToString();
                if (ds.Tables[0].Rows[0]["Enable"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Enable"].ToString() == "1") || (ds.Tables[0].Rows[0]["Enable"].ToString().ToLower() == "true"))
                    {
                        model.Enable = true;
                    }
                    else
                    {
                        model.Enable = false;
                    }
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
            strSql.Append("select EmployeeID,LoginName,EmployeeName,Sex,NickName,Birthday,CertificateID,CertificateNumber,CountryCode,ProvinceID,CityID,CountyID,Address,PostCode,Tel,Mobile,FAX,Email,DeptID,WorkType,DegreeID,Enable ");
            strSql.Append(" FROM EmployeeInfoTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" EmployeeID,LoginName,EmployeeName,Sex,NickName,Birthday,CertificateID,CertificateNumber,CountryCode,ProvinceID,CityID,CountyID,Address,PostCode,Tel,Mobile,FAX,Email,DeptID,WorkType,DegreeID,Enable ");
            strSql.Append(" FROM EmployeeInfoTab ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "EmployeeInfoTab";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        //#######################################  2010-07-23 新添加的部门 ############################

        //检查登录用户名
        public DataSet CheckUserLoginName(string strUserLoginName)
        {
            StringBuilder SqlTxt = new StringBuilder();
            //以前的，查询错误表
            //SqlTxt.Append("select loginname from logininfotab where loginname =@LoginUserName");  
            SqlTxt.Append("select loginname from employeeinfotab where loginname =@LoginUserName");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlTxt.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@LoginUserName", SqlDbType.VarChar, 20).Value = strUserLoginName;
            DataSet ds = new DataSet();
            try
            {
                ds = DbHelperSQL.SelectSqlDataSet(cmd);
            }
            catch (SqlException err)
            {
                throw err;
            }
            return ds;
        }

        //获取数据
        public DataSet GetData(string strUserLoginName)
        {
            StringBuilder SqlTxt = new StringBuilder();

            SqlTxt.Append("select top 1 * from logininfotab where loginname =@LoginUserName");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlTxt.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@LoginUserName", SqlDbType.VarChar, 20).Value = strUserLoginName;
            DataSet ds = new DataSet();
            try
            {
                ds = DbHelperSQL.SelectSqlDataSet(cmd);
            }
            catch (SqlException err)
            {
                throw err;
            }
            return ds;
        }

        //同时向两个表插入数据
        public int Add(Tz888.Model.LoginInfo loginModel, Tz888.Model.Sys.EmployeeInfoTab empModel, string strTem)
        {
            //Employeeinfotab表
            StringBuilder SqlTxtEmployee = new StringBuilder();
            SqlTxtEmployee.Append("insert into employeeinfotab(loginname,employeename,sex,nickname,birthday,certificateid,certificatenumber,countrycode,provinceid,cityid,countyid,address,postcode,tel,mobile,fax,email,deptid,worktype,degreeid,enable)   " +
                          "values(@loginname,@employeename,@sex,@nickname,@birthday,@certificateid,@certificatenumber,@countrycode,@provinceid,@cityid,@countyid,@address,@postcode,@tel,@mobile,@fax,@email,@deptid,@worktype,@degreeid,@enable)");
            SqlTxtEmployee.Append(";select IDENT_CURRENT('employeeinfotab')");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlTxtEmployee.ToString();
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@loginname", SqlDbType.VarChar, 16).Value = empModel.LoginName;
            cmd.Parameters.Add("@employeename", SqlDbType.VarChar, 50).Value = empModel.EmployeeName;
            cmd.Parameters.Add("@sex", SqlDbType.Bit).Value = (empModel.Sex) == true ? 1 : 0;
            cmd.Parameters.Add("@nickname", SqlDbType.VarChar, 50).Value = empModel.NickName;
            cmd.Parameters.Add("@birthday", SqlDbType.DateTime).Value = empModel.Birthday;
            cmd.Parameters.Add("@certificateid", SqlDbType.VarChar, 10).Value = empModel.CertificateID;
            cmd.Parameters.Add("@certificatenumber", SqlDbType.VarChar, 20).Value = empModel.CertificateNumber;
            cmd.Parameters.Add("@countrycode", SqlDbType.VarChar, 10).Value = empModel.CountryCode;
            cmd.Parameters.Add("@provinceid", SqlDbType.VarChar, 10).Value = empModel.ProvinceID;
            cmd.Parameters.Add("@cityid", SqlDbType.VarChar, 10).Value = empModel.CityID;
            cmd.Parameters.Add("@countyid", SqlDbType.VarChar, 10).Value = empModel.CountyID;
            cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = empModel.Address;
            cmd.Parameters.Add("@postcode", SqlDbType.VarChar, 10).Value = empModel.PostCode;
            cmd.Parameters.Add("@tel", SqlDbType.VarChar, 30).Value = empModel.Tel;
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar, 20).Value = empModel.Mobile;
            cmd.Parameters.Add("@fax", SqlDbType.VarChar, 30).Value = empModel.FAX;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = empModel.Email;
            cmd.Parameters.Add("@deptid", SqlDbType.VarChar, 10).Value = empModel.DeptID;
            cmd.Parameters.Add("@worktype", SqlDbType.VarChar, 10).Value = empModel.WorkType;
            cmd.Parameters.Add("@degreeid", SqlDbType.VarChar, 10).Value = empModel.DegreeID;
            cmd.Parameters.Add("@enable", SqlDbType.Bit).Value = (empModel.Enable) == true ? 1 : 0;


            //Logininfotab表
            StringBuilder SqlTxtLogin = new StringBuilder();
            SqlTxtLogin.Append("insert into logininfotab(loginname,password,passwordquestion,passwordanswer,rolename,ischeckup,nickname,tel,email,requirinfo,realname,managetypeid,enable,membergradeid)    " +
                               "values(@loginname,@password,@passwordquestion,@passwordanswer,@rolename,@ischeckup,@nickname,@tel,@email,@requirinfo,@realname,@managetypeid,@enable,@membergradeid)");
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.CommandText = SqlTxtLogin.ToString();
            cmdLogin.CommandType = CommandType.Text;

            cmdLogin.Parameters.Add("@loginname", SqlDbType.VarChar, 16).Value = loginModel.LoginName;
            cmdLogin.Parameters.Add("@password", SqlDbType.VarBinary, 50).Value = loginModel.Password;
            cmdLogin.Parameters.Add("@passwordquestion", SqlDbType.VarChar, 50).Value = loginModel.PasswordQuestion;
            cmdLogin.Parameters.Add("@passwordanswer", SqlDbType.VarChar, 50).Value = loginModel.PasswordAnswer;
            cmdLogin.Parameters.Add("@rolename", SqlDbType.VarChar, 10).Value = loginModel.RoleName;
            cmdLogin.Parameters.Add("@ischeckup", SqlDbType.Bit).Value = loginModel.IsCheckUp;
            cmdLogin.Parameters.Add("@nickname", SqlDbType.VarChar, 50).Value = loginModel.NickName;
            cmdLogin.Parameters.Add("@tel", SqlDbType.VarChar, 30).Value = loginModel.Tel;
            cmdLogin.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = loginModel.Email;
            cmdLogin.Parameters.Add("@requirinfo", SqlDbType.VarChar, 50).Value = loginModel.RequirInfo;
            cmdLogin.Parameters.Add("@realname", SqlDbType.VarChar, 50).Value = loginModel.RealName;
            cmdLogin.Parameters.Add("@managetypeid", SqlDbType.VarChar, 10).Value = loginModel.ManageTypeID;
            cmdLogin.Parameters.Add("@enable", SqlDbType.Bit).Value = (loginModel.Enable) == true ? 1 : 0;
            cmdLogin.Parameters.Add("@membergradeid", SqlDbType.VarChar, 10).Value = loginModel.MemberGradeID;

            int iRetuEmp = 0;
            int iRetuLogin = 0;
            int iRetuSystem = 0;
            try
            {
                iRetuLogin = DbHelperSQL.ExecSqlNonQuery(cmdLogin);
                //iRetuEmp = DbHelperSQL.ExecSqlNonQuery(cmd);
            }
            catch (SqlException err)
            {
                throw err;
            }


            if (iRetuEmp > 0 && iRetuLogin > 0)
            {
                //表权的中间表
                StringBuilder SqlTxtSystem = new StringBuilder();
                SqlTxtSystem.Append("insert into system(employeeid,tem) values(@employeeid,@sTem)");
                SqlCommand cmdSystem = new SqlCommand();
                cmdSystem.CommandText = SqlTxtSystem.ToString();
                cmdSystem.CommandType = CommandType.Text;

                cmdSystem.Parameters.Add("@employeeid", SqlDbType.VarChar, 50).Value = empModel.LoginName;
                cmdSystem.Parameters.Add("@sTem", SqlDbType.VarChar, 1000).Value = strTem;

                try
                {
                    iRetuSystem = DbHelperSQL.ExecSqlNonQuery(cmdSystem);
                }
                catch (SqlException err)
                {
                    throw err;
                }
            }
            return iRetuSystem;
        }

        /// <summary>
        /// 向Employeeinfotab表插入记录
        /// </summary>
        /// <param name="empMode"></param>
        /// <returns></returns>
        public int Insert(Tz888.Model.Sys.EmployeeInfoTab empModel, string strTem)
        {
            //Employeeinfotab表
            StringBuilder SqlTxtEmployee = new StringBuilder();
            SqlTxtEmployee.Append("insert into employeeinfotab(loginname,password,employeename,sex,nickname,birthday,certificateid,certificatenumber,countrycode,provinceid,cityid,countyid,address,postcode,tel,mobile,fax,email,deptid,worktype,degreeid,enable)   " +
                          "values(@loginname,@password,@employeename,@sex,@nickname,@birthday,@certificateid,@certificatenumber,@countrycode,@provinceid,@cityid,@countyid,@address,@postcode,@tel,@mobile,@fax,@email,@deptid,@worktype,@degreeid,@enable)");
            //SqlTxtEmployee.Append(";select IDENT_CURRENT('employeeinfotab')"); 暂不用
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlTxtEmployee.ToString();
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@loginname", SqlDbType.VarChar, 16).Value = empModel.LoginName;
            cmd.Parameters.Add("@password", SqlDbType.VarBinary).Value = empModel.Password;
            cmd.Parameters.Add("@employeename", SqlDbType.VarChar, 50).Value = empModel.EmployeeName;
            cmd.Parameters.Add("@sex", SqlDbType.Bit).Value = (empModel.Sex) == true ? 1 : 0;
            cmd.Parameters.Add("@nickname", SqlDbType.VarChar, 50).Value = empModel.NickName;
            cmd.Parameters.Add("@birthday", SqlDbType.DateTime).Value = empModel.Birthday;
            cmd.Parameters.Add("@certificateid", SqlDbType.VarChar, 10).Value = empModel.CertificateID;
            cmd.Parameters.Add("@certificatenumber", SqlDbType.VarChar, 20).Value = empModel.CertificateNumber;
            cmd.Parameters.Add("@countrycode", SqlDbType.VarChar, 10).Value = empModel.CountryCode;
            cmd.Parameters.Add("@provinceid", SqlDbType.VarChar, 10).Value = empModel.ProvinceID;
            cmd.Parameters.Add("@cityid", SqlDbType.VarChar, 10).Value = empModel.CityID;
            cmd.Parameters.Add("@countyid", SqlDbType.VarChar, 10).Value = empModel.CountyID;
            cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = empModel.Address;
            cmd.Parameters.Add("@postcode", SqlDbType.VarChar, 10).Value = empModel.PostCode;
            cmd.Parameters.Add("@tel", SqlDbType.VarChar, 30).Value = empModel.Tel;
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar, 20).Value = empModel.Mobile;
            cmd.Parameters.Add("@fax", SqlDbType.VarChar, 30).Value = empModel.FAX;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = empModel.Email;
            cmd.Parameters.Add("@deptid", SqlDbType.VarChar, 10).Value = empModel.DeptID;
            cmd.Parameters.Add("@worktype", SqlDbType.VarChar, 10).Value = empModel.WorkType;
            cmd.Parameters.Add("@degreeid", SqlDbType.VarChar, 10).Value = empModel.DegreeID;
            cmd.Parameters.Add("@enable", SqlDbType.Bit).Value = (empModel.Enable) == true ? 1 : 0;

            int iRetuEmp = 0;
            int iRetuSystem = 0;
            try
            {
                // 暂不用RetuNumber = DbHelperSQL.ExecSqlScalar_RetuNumber(cmd);
                iRetuEmp = DbHelperSQL.ExecSqlNonQuery(cmd);
            }
            catch (SqlException err)
            {
                throw err;
            }

            //插入到权限表
            if (iRetuEmp > 0)
            {
                //表权的中间表
                StringBuilder SqlTxtSystem = new StringBuilder();
                SqlTxtSystem.Append("insert into system(employeeid,tem) values(@employeeid,@sTem)");
                SqlCommand cmdSystem = new SqlCommand();
                cmdSystem.CommandText = SqlTxtSystem.ToString();
                cmdSystem.CommandType = CommandType.Text;

                cmdSystem.Parameters.Add("@employeeid", SqlDbType.VarChar, 50).Value = empModel.LoginName;
                cmdSystem.Parameters.Add("@sTem", SqlDbType.VarChar, 1000).Value = strTem;

                try
                {
                    iRetuSystem = DbHelperSQL.ExecSqlNonQuery(cmdSystem);
                }
                catch (SqlException err)
                {
                    throw err;
                }
            }
            return iRetuSystem;
        }


        /// <summary>
        /// 添加员工，改版后_2010-8-9
        /// </summary>
        /// <param name="empModel"></param>
        /// <param name="strTem"></param>
        /// <returns></returns>
        public int Insert_V1(Tz888.Model.Sys.EmployeeInfoTab empModel, string strTem)
        {
            SqlParameter[] par ={ 
                                    new SqlParameter("@loginname", SqlDbType.VarChar,16),
	                                new SqlParameter("@password",  SqlDbType.VarBinary),
	                                new SqlParameter("@employeename", SqlDbType.VarChar,50),
	                                new SqlParameter("@sex",SqlDbType.Bit),
	                                new SqlParameter("@nickname", SqlDbType.VarChar,50),
	                                new SqlParameter("@birthday", SqlDbType.DateTime),
	                                new SqlParameter("@certificateid", SqlDbType.Char,10),
	                                new SqlParameter("@certificatenumber", SqlDbType.VarChar,20),
	                                new SqlParameter("@countrycode", SqlDbType.Char,10),
	                                new SqlParameter("@provinceid", SqlDbType.Char,10),
	                                new SqlParameter("@cityid", SqlDbType.Char,10),

	                                new SqlParameter("@countyid", SqlDbType.Char,10),
	                                new SqlParameter("@address", SqlDbType.VarChar,50),
	                                new SqlParameter("@postcode", SqlDbType.Char,10),
	                                new SqlParameter("@tel", SqlDbType.VarChar,30),
	                                new SqlParameter("@mobile", SqlDbType.VarChar,30),
	                                new SqlParameter("@fax", SqlDbType.VarChar,30),
	                                new SqlParameter("@email", SqlDbType.VarChar,50),
	                                new SqlParameter("@deptid", SqlDbType.Char,10),
	                                new SqlParameter("@worktype", SqlDbType.Char,10),
	                                new SqlParameter("@degreeid", SqlDbType.Char,10),
	                                new SqlParameter("@enable", SqlDbType.Bit),
                                    };

            par[0].Value = empModel.LoginName;
            par[1].Value = empModel.Password;
            par[2].Value = empModel.EmployeeName;
            par[3].Value = empModel.Sex;
            par[4].Value = empModel.NickName;
            par[5].Value = empModel.Birthday;
            par[6].Value = empModel.CertificateID;
            par[7].Value = empModel.CertificateNumber;
            par[8].Value = empModel.CountryCode;
            par[9].Value = empModel.ProvinceID;
            par[10].Value = empModel.CityID;

            par[11].Value = empModel.CountyID;
            par[12].Value = empModel.Address;
            par[13].Value = empModel.PostCode;
            par[14].Value = empModel.Tel;
            par[15].Value = empModel.Mobile;
            par[16].Value = empModel.FAX;
            par[17].Value = empModel.Email;
            par[18].Value = empModel.DeptID;
            par[19].Value = empModel.WorkType;
            par[20].Value = empModel.DegreeID;
            par[21].Value = empModel.Enable;

            int iRetuEmp = DbHelperSQL.RunProcReturn("EmployeeInfoTab_Insert_V1", par);
            int iRetu = 0;
            //插入到权限表
            if (iRetuEmp > 0)
            {
                //表权的中间表
                StringBuilder SqlTxtSystem = new StringBuilder();
                SqlTxtSystem.Append("insert into system(employeeid,tem) values(@employeeid,@sTem)");
                SqlCommand cmdSystem = new SqlCommand();
                cmdSystem.CommandText = SqlTxtSystem.ToString();
                cmdSystem.CommandType = CommandType.Text;

                cmdSystem.Parameters.Add("@employeeid", SqlDbType.VarChar, 50).Value = empModel.LoginName;
                cmdSystem.Parameters.Add("@sTem", SqlDbType.VarChar, 1000).Value = strTem;

                try
                {
                    iRetu = DbHelperSQL.ExecSqlNonQuery(cmdSystem);
                }
                catch (SqlException err)
                {
                    throw err;
                }
            }
            return iRetu;
        }


        //同时更新两人个表
        public int Update(Tz888.Model.LoginInfo loginModel, Tz888.Model.Sys.EmployeeInfoTab empModel, string strTem)
        {
            //Employeeinfotab表
            StringBuilder SqlTxtEmployee = new StringBuilder();
            //*SqlTxtEmployee.Append("update employeeinfotab set loginname=@loginname,employeename=@employeename,sex=@sex,nickname=@nickname,birthday=@birthday,certificateid=@certificateid,certificatenumber=@certificatenumber,countrycode=@countrycode,provinceid=@provinceid,cityid=@cityid,countyid=@countyid,address=@address,postcode=@postcode,tel=@tel,mobile=@mobile,fax=@fax,email=@email,deptid=@deptid,worktype=@worktype,degreeid=@degreeid,enable=@enable "+
            //                      "where loginname=@loginname");
            SqlTxtEmployee.Append("update employeeinfotab set employeename=@employeename,sex=@sex,nickname=@nickname,birthday=@birthday,certificateid=@certificateid,certificatenumber=@certificatenumber,address=@address,postcode=@postcode,tel=@tel,mobile=@mobile,fax=@fax,email=@email,deptid=@deptid,worktype=@worktype,degreeid=@degreeid " +
                                  "where loginname=@loginname");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlTxtEmployee.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@loginname", SqlDbType.VarChar, 16).Value = empModel.LoginName;
            cmd.Parameters.Add("@employeename", SqlDbType.VarChar, 50).Value = empModel.EmployeeName;
            cmd.Parameters.Add("@sex", SqlDbType.Bit).Value = (empModel.Sex) == true ? 1 : 0;
            cmd.Parameters.Add("@nickname", SqlDbType.VarChar, 50).Value = empModel.NickName;
            cmd.Parameters.Add("@birthday", SqlDbType.DateTime).Value = empModel.Birthday;
            cmd.Parameters.Add("@certificateid", SqlDbType.VarChar, 10).Value = empModel.CertificateID;
            cmd.Parameters.Add("@certificatenumber", SqlDbType.VarChar, 20).Value = empModel.CertificateNumber;

            //*cmd.Parameters.Add("@countrycode", SqlDbType.VarChar, 10).Value = empModel.CountryCode;
            //**cmd.Parameters.Add("@provinceid", SqlDbType.VarChar, 10).Value = empModel.ProvinceID;
            //*cmd.Parameters.Add("@cityid", SqlDbType.VarChar, 10).Value = empModel.CityID;
            //**cmd.Parameters.Add("@countyid", SqlDbType.VarChar, 10).Value = empModel.CountyID;

            cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = empModel.Address;
            cmd.Parameters.Add("@postcode", SqlDbType.VarChar, 10).Value = empModel.PostCode;
            cmd.Parameters.Add("@tel", SqlDbType.VarChar, 30).Value = empModel.Tel;
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar, 20).Value = empModel.Mobile;
            cmd.Parameters.Add("@fax", SqlDbType.VarChar, 30).Value = empModel.FAX;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = empModel.Email;
            cmd.Parameters.Add("@deptid", SqlDbType.VarChar, 10).Value = empModel.DeptID;
            cmd.Parameters.Add("@worktype", SqlDbType.VarChar, 10).Value = empModel.WorkType;
            cmd.Parameters.Add("@degreeid", SqlDbType.VarChar, 10).Value = empModel.DegreeID;
            //*cmd.Parameters.Add("@enable", SqlDbType.Bit).Value = (empModel.Enable) == true ? 1 : 0;


            //Logininfotab表
            StringBuilder SqlTxtLogin = new StringBuilder();


            //*SqlTxtLogin.Append("update logininfotab set passwordquestion=@passwordquestion,passwordanswer=@passwordanswer,rolename=@rolename,ischeckup=@ischeckup,nickname=@nickname,tel=@tel,email=@email,requirinfo=@requirinfo,realname=@realname,managetypeid=@managetypeid,enable=@enable,membergradeid=@membergradeid   "+
            //*                   "where loginname=@loginname");

            SqlTxtLogin.Append("update logininfotab set passwordquestion=@passwordquestion,passwordanswer=@passwordanswer,rolename=@rolename,ischeckup=@ischeckup,nickname=@nickname,tel=@tel,email=@email   " +
                               "where loginname=@loginname");
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.CommandText = SqlTxtLogin.ToString();
            cmdLogin.CommandType = CommandType.Text;

            cmdLogin.Parameters.Add("@loginname", SqlDbType.VarChar, 16).Value = loginModel.LoginName;
            cmdLogin.Parameters.Add("@passwordquestion", SqlDbType.VarChar, 50).Value = loginModel.PasswordQuestion;
            cmdLogin.Parameters.Add("@passwordanswer", SqlDbType.VarChar, 50).Value = loginModel.PasswordAnswer;
            cmdLogin.Parameters.Add("@rolename", SqlDbType.VarChar, 10).Value = loginModel.RoleName;
            cmdLogin.Parameters.Add("@ischeckup", SqlDbType.Bit).Value = loginModel.IsCheckUp;
            cmdLogin.Parameters.Add("@nickname", SqlDbType.VarChar, 50).Value = loginModel.NickName;
            cmdLogin.Parameters.Add("@tel", SqlDbType.VarChar, 30).Value = loginModel.Tel;
            cmdLogin.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = loginModel.Email;
            //*cmdLogin.Parameters.Add("@requirinfo", SqlDbType.VarChar, 50).Value = loginModel.RequirInfo;
            //*cmdLogin.Parameters.Add("@realname", SqlDbType.VarChar, 50).Value = loginModel.RealName;
            //*cmdLogin.Parameters.Add("@managetypeid", SqlDbType.VarChar, 10).Value = loginModel.ManageTypeID;
            //*cmdLogin.Parameters.Add("@enable", SqlDbType.Bit).Value = (loginModel.Enable) == true ? 1 : 0;
            //*cmdLogin.Parameters.Add("@membergradeid", SqlDbType.VarChar, 10).Value = loginModel.MemberGradeID;

            long iRetuEmp = 0;
            int iRetuLogin = 0;
            int iRetuSystem = 0;
            try
            {
                iRetuLogin = DbHelperSQL.ExecSqlNonQuery(cmdLogin);
                //iRetuEmp = DbHelperSQL.ExecSqlNonQuery(cmd);
                iRetuEmp = DbHelperSQL.ExecSqlScalar_RetuNumber(cmd);
            }
            catch (SqlException err)
            {
                throw err;
            }


            if (iRetuEmp > 0 && iRetuLogin > 0)
            {
                if (strTem.Trim() != "")
                {
                    //表权的中间表
                    StringBuilder SqlTxtSystem = new StringBuilder();
                    SqlTxtSystem.Append("update system set tem=@sTem where employeeid=@employeeid");
                    SqlCommand cmdSystem = new SqlCommand();
                    cmdSystem.CommandText = SqlTxtSystem.ToString();
                    cmdSystem.CommandType = CommandType.Text;

                    cmdSystem.Parameters.Add("@employeeid", SqlDbType.VarChar, 50).Value = empModel.LoginName;
                    cmdSystem.Parameters.Add("@sTem", SqlDbType.VarChar, 1000).Value = strTem;

                    try
                    {
                        iRetuSystem = DbHelperSQL.ExecSqlNonQuery(cmdSystem);
                    }
                    catch (SqlException err)
                    {
                        throw err;
                    }
                }
                else
                {
                    iRetuSystem = 1;
                }
            }
            return iRetuSystem;
        }


        /// <summary>
        /// 更新employeeinfotab表数据
        /// </summary>
        /// <param name="empModel"></param>
        /// <returns></returns>
        public int UpdateEmpTab(Tz888.Model.Sys.EmployeeInfoTab empModel)
        {
            //Employeeinfotab表
            StringBuilder SqlTxtEmployee = new StringBuilder();
            //*SqlTxtEmployee.Append("update employeeinfotab set loginname=@loginname,employeename=@employeename,sex=@sex,nickname=@nickname,birthday=@birthday,certificateid=@certificateid,certificatenumber=@certificatenumber,countrycode=@countrycode,provinceid=@provinceid,cityid=@cityid,countyid=@countyid,address=@address,postcode=@postcode,tel=@tel,mobile=@mobile,fax=@fax,email=@email,deptid=@deptid,worktype=@worktype,degreeid=@degreeid,enable=@enable "+
            //                      "where loginname=@loginname");
            SqlTxtEmployee.Append("update employeeinfotab set employeename=@employeename, sex=@sex,nickname=@nickname,birthday=@birthday,certificateid=@certificateid,certificatenumber=@certificatenumber,address=@address,postcode=@postcode,tel=@tel,mobile=@mobile,fax=@fax,email=@email,deptid=@deptid,worktype=@worktype,degreeid=@degreeid " +
                                  "where loginname=@loginname");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlTxtEmployee.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@loginname", SqlDbType.VarChar, 16).Value = empModel.LoginName.Trim();
            cmd.Parameters.Add("@employeename", SqlDbType.VarChar, 50).Value = empModel.EmployeeName.Trim();
            cmd.Parameters.Add("@sex", SqlDbType.Bit).Value = (empModel.Sex) == true ? 1 : 0;
            cmd.Parameters.Add("@nickname", SqlDbType.VarChar, 50).Value = empModel.NickName.Trim();
            cmd.Parameters.Add("@birthday", SqlDbType.DateTime).Value = empModel.Birthday;
            cmd.Parameters.Add("@certificateid", SqlDbType.VarChar, 10).Value = empModel.CertificateID;
            cmd.Parameters.Add("@certificatenumber", SqlDbType.VarChar, 20).Value = empModel.CertificateNumber.Trim();

            //*cmd.Parameters.Add("@countrycode", SqlDbType.VarChar, 10).Value = empModel.CountryCode;
            //**cmd.Parameters.Add("@provinceid", SqlDbType.VarChar, 10).Value = empModel.ProvinceID;
            //*cmd.Parameters.Add("@cityid", SqlDbType.VarChar, 10).Value = empModel.CityID;
            //**cmd.Parameters.Add("@countyid", SqlDbType.VarChar, 10).Value = empModel.CountyID;

            cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = empModel.Address.Trim();
            cmd.Parameters.Add("@postcode", SqlDbType.VarChar, 10).Value = empModel.PostCode.Trim();
            cmd.Parameters.Add("@tel", SqlDbType.VarChar, 30).Value = empModel.Tel.Trim();
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar, 20).Value = empModel.Mobile.Trim();
            cmd.Parameters.Add("@fax", SqlDbType.VarChar, 30).Value = empModel.FAX.Trim();
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = empModel.Email.Trim();
            cmd.Parameters.Add("@deptid", SqlDbType.VarChar, 10).Value = empModel.DeptID;
            cmd.Parameters.Add("@worktype", SqlDbType.VarChar, 10).Value = empModel.WorkType;
            cmd.Parameters.Add("@degreeid", SqlDbType.VarChar, 10).Value = empModel.DegreeID;
            //*cmd.Parameters.Add("@enable", SqlDbType.Bit).Value = (empModel.Enable) == true ? 1 : 0;

            int iRetuEmp = 0;
            try
            {
                iRetuEmp = DbHelperSQL.ExecSqlNonQuery(cmd);
            }
            catch (SqlException err)
            {
                throw err;
            }
            return iRetuEmp;
        }

        #region 验证员工登录及写入日志文件
        /// <summary>
        /// 验证员工登录及写入日志文件
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="strPassWord"></param>
        /// <param name="strIpAddress"></param>
        /// <returns></returns>
        public DataTable Authenticate(
            string strLoginName,
            string strPassWord,
            string strIpAddress)
        {
            //加密密码
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(strPassWord.Trim()));

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.VarChar,20),
											new SqlParameter("@PassWord ",SqlDbType.VarBinary),
											new SqlParameter("@IpAddress",SqlDbType.VarChar,30)				
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName.Trim();       //登录名

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = bytePassword;  //密码

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = strIpAddress.Trim(); //IP地址

            DataSet ds = DbHelperSQL.RunProcedure("EmployeeInfoTab_Authenticate", parameters, "ds");

            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables["ds"];
            return null;
        }
        #endregion
        /// <summary>
        /// 2011-03-04 design by longbin
        /// 修改用户密码
        /// 根据用户名来修改用户密码
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <returns></returns>
        public int UpdatePwdByLoginName(string LoginName, byte[] pwd)
        {

            SqlParameter[] para ={
                                    new SqlParameter("@LoginName",SqlDbType.VarChar,20),
                                    new SqlParameter("@LoginPwd",SqlDbType.VarBinary) 
                                 };
            para[0].Value = LoginName;
            para[1].Value = pwd;

            int result = DbHelperSQL.RunProcReturnNon("EmployeeModefiyPwdBy_LoginName", para);
            return result;
        }
        /// <summary>
        /// 2011-03-04 design by longbin
        /// 修改用户密码
        /// 根据用户名来修改用户密码
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <returns></returns>
        public byte[] GetPwdByLoginName(string LoginName)
        {
            Tz888.Model.Sys.EmployeeInfoTab empModel = new Tz888.Model.Sys.EmployeeInfoTab();
            SqlParameter[] para ={
                                    new SqlParameter("@LoginName",SqlDbType.VarChar,20),
                                    new SqlParameter("@LoginPwd",SqlDbType.VarBinary) 
                                 };
            para[0].Value = LoginName;
            para[1].Value = empModel.Password;
            para[1].Direction = ParameterDirection.InputOutput;
            


            int result = DbHelperSQL.RunProcReturnNon("EmployeeGetPwdBy_LoginName", para);
            //string sql = "select password from employeeinfotab where loginName='" + LoginName + "'";
            //string pwd=string.Empty;
            //SqlCommand cmdSystem = new SqlCommand();
            //cmdSystem.CommandText = sql.ToString();
            //cmdSystem.CommandType = CommandType.Text;


            //DataSet ds = DbHelperSQL.SelectSqlDataSet(cmdSystem);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    if (ds.Tables[0].Rows[0]["password"].ToString() != "")
            //    {
            //        empModel.Password = Encoding.Default.GetBytes(Convert.ToByte(ds.Tables[0].Rows[0]["password"]));
            //    }
            //}
            return empModel.Password;
        }

        //获取表的数据
        public DataTable GetData(string sIsPage, string sSuperStr, string sSort, int iPageSize, int iPageIndex, int iDoCount)
        {
            //@IsPage varchar(10),  --是否分页
            //@SuperStr varchar(8000),--超级查询语句，##不能为空，必须有超级查询语句
            //@Sort varchar(1000), --排序 ##不能为空，必须有排序语句
            //@PageSize int,  --分页，每页数据数
            //@PageIndex int,  --页数
            //@docount int --是否去统计总数



            DataTable dt = null;
            SqlParameter[] par ={
                                    new SqlParameter("@ispage",SqlDbType.VarChar,10),
                                    new SqlParameter("@SuperStr",SqlDbType.VarChar,8000),
                                    new SqlParameter("@Sort",SqlDbType.VarChar,1000),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@docount",SqlDbType.Int)
                                };

            par[0].Direction = ParameterDirection.Input;
            par[0].Value = sIsPage;
            par[1].Direction = ParameterDirection.Input;
            par[1].Value = sSuperStr;
            par[2].Direction = ParameterDirection.Input;
            par[2].Value = sSort;
            par[3].Direction = ParameterDirection.Input;
            par[3].Value = iPageSize;
            par[4].Direction = ParameterDirection.Input;
            par[4].Value = iPageIndex;
            par[5].Direction = ParameterDirection.Input;
            par[5].Value = iDoCount;

            try
            {
                dt = DbHelperSQL.RunProcedure("SP_SuperQuery", par, "mytable").Tables[0];
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return dt;
        }

        //#################################################################

        #endregion  成员方法
    }
}

