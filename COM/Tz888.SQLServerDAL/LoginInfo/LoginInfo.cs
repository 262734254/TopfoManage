using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Tz888.IDAL.LoginInfo;
using Tz888.DBUtility;
using System.Security.Cryptography;

namespace Tz888.SQLServerDAL.LoginInfo
{
    /// <summary>
    /// ���ݷ�����LoginInfo ��
    /// </summary>
    public class LoginInfo : ILoginInfo
    {
        private Tz888.SQLServerDAL.Conn coon;                //���ݿ����Ӷ���
        public LoginInfo()
        {
            coon = new Conn();
        }
        /// <summary>
		/// ��¼ϵͳ
		/// </summary>
		/// <returns>�Ƿ��¼�ɹ�</returns>
		public bool LoginSys()
		{
			return( true );
		}	

		#region �޸�����
		public bool ChangePassword(string strLoginName,string strNewPassword)
		{
           // ////��������
           // SHA1 sha1 = SHA1.Create();
           // byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(strNewPassword.ToString().Trim()));


           // DbHelperSQL.ExecuteSql("update loginInfotab set password=" + bytePassword + " where loginname='test'"); //'"+strLoginName+"'");
           //return true;
            int iRcount = 0;
            int rowsAffected = 0;
            //��������
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(strNewPassword.ToString().Trim()));


            SqlParameter[] parameters = { new SqlParameter("@LoginName",SqlDbType.Char,16),
                new SqlParameter("@PassWord ",SqlDbType.VarBinary)
													
                                        };
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName.Trim();       //��¼��

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = bytePassword;  //����

            try
            {
                rowsAffected = DbHelperSQL.RunProcedure("LoginInfoTab_ChangePassword", parameters, out iRcount);
               
                    return true;
             
            }
            catch (Exception err)
            {
                throw err;
                return false;
            }              
        }
		#endregion

        #region ͨ����¼����ȡ����������

        public DataTable GetMemberNameByLoginName(string strLoginName, string strRoleName)
        {
            
            DataTable dt = new DataTable();

            SqlParameter[] parameters = { new SqlParameter("@LoginName",SqlDbType.Char,16),
											new SqlParameter("@RoleName",SqlDbType.Char,10)
											// new SqlParameter("@VarLoginName",SqlDbType.Char,16)

										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = strRoleName;

            //			parameters[2].Direction =ParameterDirection.Output;


            try
            {               
                dt = DbHelperSQL.RunProcedure("LoginInfoTab_GetMemberName", parameters,"aaaaa").Tables[0];
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


        // 
 
        public DataTable GetInfoList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            return (coon.GetList(
                   tblName,
                   strGetFields,
                   fldName,
                   PageSize,
                   PageIndex,
                   doCount,
                   OrderType,
                   strWhere));
        }      
        #endregion


        #region ��֤��Ա��¼
        public DataTable AuthMemberLogin(
            string strLoginName,
            long lgCardNo,
            string strPassWord,
            bool IsOnlyCheck)
        {
          
            DataTable dt = null;

            //��������
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(strPassWord.Trim()));

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),
											new SqlParameter("@CardID",SqlDbType.BigInt),
											new SqlParameter("@PassWord",SqlDbType.VarBinary),
											new SqlParameter("@IsOnlyCheck",SqlDbType.Bit)			
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;       //��¼��

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = lgCardNo;       //��¼��

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = bytePassword;  //����

            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = IsOnlyCheck;

            try
            {
                //DataSet ds = DbHelperSQL.RunProcedure("LoginInfoTab_MAuthenticate", parameters, "ddddddd")
                dt = DbHelperSQL.RunProcedure("LoginInfoTab_MAuthenticate", parameters, "ddddddd").Tables[0];            
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
        #endregion	


        #region ��̳��½��Ϣ����
        /// <summary>
        /// ��̳��½��Ϣ���� kevin 2006-11-24
        /// </summary>
        /// <param name="userId">�û�ID</param>
        /// <param name="ip">����½IP</param>
        /// <param name="truePassword">�µ��������</param>
        /// <returns>��������,���ؿջ�nullΪ��Ч</returns>
        public string BBSLoginUpdate(int userId, string ip, string truePassword)
        {
            string groupName;       

            SqlParameter[] parameters = { new SqlParameter("@UserId",SqlDbType.Int),
											new SqlParameter("@tpwd",SqlDbType.VarChar,20),
											new SqlParameter("@GroupName",SqlDbType.VarChar,20),
											new SqlParameter("@ip",SqlDbType.VarChar,30)
																							
			};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = userId;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = truePassword;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = ip;

            try
            {
                int iRowsAffected = 0;
                int iRet = DbHelperSQL.RunProcedure("BBS_LoginUpdate", parameters,out iRowsAffected);
                groupName = parameters[2].Value.ToString().Trim();
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                 
            }
            return groupName;
        }
        #endregion 


        #region ����¼ʧ�ܴ���
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="LoginTimeRange"></param>
        /// <param name="AllowErrorTimes"></param>
        /// <returns></returns>
        public int CheckLoginErrorTime(string strLoginName, int LoginTimeRange, int AllowErrorTimes)
        {
        
            DataTable dt = new DataTable();
            int intReturnVal = 0;

            SqlParameter[] parameters = { new SqlParameter("@LoginName",SqlDbType.Char,16),
										new SqlParameter("@LoginTimeRange",SqlDbType.Int),
										new SqlParameter("@AllowErrorTimes",SqlDbType.Int),
										 new SqlParameter("@ReturnValue",SqlDbType.Int)

										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = LoginTimeRange;

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = AllowErrorTimes;

            parameters[3].Direction = ParameterDirection.Output;


            try
            {
                int iRowsAffected = 0;
                int iRet = DbHelperSQL.RunProcedure("LoginErrorLogTab_Check", parameters,out iRowsAffected);
                intReturnVal = Convert.ToInt32(parameters[3].Value.ToString().Trim());
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                 
            }
            return intReturnVal;

        }
        #endregion



        #region-- ��ѯ��¼��Ϣ�б�
		/// <summary>
		/// ��ѯ��¼��Ϣ�б�
		/// </summary>
		/// <param name="SelectCol">ѡ����</param>		
		/// <param name="Criteria">��ѯ����</param>
		/// <param name="OrderBy">����</param>
		/// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
		/// <param name="PageSize">ҳ��С</param>
		/// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
		/// <returns>��ѯ�б�</returns>
		public DataTable GetLoginInfoList(
			string SelectCol,
			string Criteria,
			string Sort
			)
		{
			 
			DataTable   dt = new DataTable();

			SqlParameter[] parameters = { new SqlParameter("@SelectStr",SqlDbType.VarChar,200),
											new SqlParameter("@Criteria",SqlDbType.VarChar,200),
											new SqlParameter("@Sort",SqlDbType.VarChar,200)
					
										};

			parameters[0].Direction =ParameterDirection.Input;
			parameters[0].Value = SelectCol;       

			parameters[1].Direction =ParameterDirection.Input;
			parameters[1].Value = Criteria;  

			parameters[2].Direction =ParameterDirection.Input;
			parameters[2].Value = Sort;  
			

			try
			{

                dt = DbHelperSQL.RunProcedure("LoginInfoTab_List", parameters, "ddddddd").Tables[0];
				
			}
			catch(Exception err)
			{
				throw err;
			}
			finally
			{
			 
			}
			return dt;
		}
		#endregion


        #region-- ��ѯ��¼��Ϣ�б�
        /// <summary>
        /// ��ѯ��¼��Ϣ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
        public DataTable GetLoginInfo(
           string LoginName
            )
        {

            DataTable dt = new DataTable();

            SqlParameter[] parameters = { new SqlParameter("@LoginName",SqlDbType.VarChar,200)										 
										};
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = LoginName;
            try
            {
                dt = DbHelperSQL.RunProcedure("TJ_UserCenter_LOGIN_INFO", parameters, "ddddddd").Tables[0];
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
        #endregion


        #region ��֤Ա����¼
        public DataTable Authenticate(
            string strLoginName,
            string strPassWord,
            bool IsOnlyCheck)
        {
            //��������
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(strPassWord.Trim()));

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char ,16),
											new SqlParameter("@PassWord ",SqlDbType.VarBinary),
											new SqlParameter("@IsOnlyCheck",SqlDbType.Bit)				
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;       //��¼��

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = bytePassword;  //����

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = IsOnlyCheck;

            DataSet ds = DbHelperSQL.RunProcedure("LoginInfoTab_Authenticate",parameters,"ds");

            if(ds!=null && ds.Tables.Count > 0)
                return ds.Tables["ds"];
            return null;
        }
        #endregion

        #region �����¼��־
        public bool InsertLoginLog(string strLoginName, string strRoleName, DateTime dtLoginTime, string strLoginIP)
        {
            int rowsAffected;
            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),				//--��¼��
											new SqlParameter("@RoleName",SqlDbType.Char,10),				//��ɫ��EG��"0 ��Ա""1��������","2��Ա��"��
										
											new SqlParameter("@LoginTime",SqlDbType.DateTime),				//��¼ʱ��
											
											new SqlParameter("@LoginIP",SqlDbType.VarChar,20)					//��¼IP
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = strRoleName;

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = dtLoginTime;

            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = strLoginIP;

            DbHelperSQL.RunProcedure("LoginLogTab_Insert", parameters,out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        #endregion

        public bool CreateLoginErrorLog(string strLoginName, DateTime dtLoginTime, string strLoginIP, bool blFlag)
		{
            int rowsAffected;
            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),				//--��¼��
											new SqlParameter("@LoginTime",SqlDbType.DateTime),				//��¼ʱ��
											new SqlParameter("@LoginIP",SqlDbType.VarChar,20),					//��¼IP
											new SqlParameter("@Flag",SqlDbType.Bit)							//��¼IP
										};

         			parameters[0].Direction=ParameterDirection.Input;
			parameters[0].Value=strLoginName;



			parameters[1].Direction=ParameterDirection.Input;
			parameters[1].Value=dtLoginTime;

			parameters[2].Direction=ParameterDirection.Input;
			parameters[2].Value=strLoginIP;

			parameters[3].Direction=ParameterDirection.Input;
			parameters[3].Value= blFlag;

            DbHelperSQL.RunProcedure("LoginErrorLogTab_Insert", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }


        ///--------------------------------------
        ///---20090811 wangwei
        ///--------------------------------------

        #region ��Ա������Ϣ��Ȩ����֤
        //��֤������ע���һ��Сʱ��������û�б��������ʻ�
        public bool yanzheng(string loginName)
        {
            bool flag = false;
            string sqlStr = "select count(LoginName) from LoginInfoTab where LoginName='" + loginName.Trim() + "' "
                + " and (AuditStatus is null or AuditStatus!=3 ) ";    //û�б�����
               // + " and datediff(n,LoginInfoTab.RegisterTime,getdate())>=30 ";  //ע�����ٰ��Сʱ��ſ���
            //string sqlStr1 = "";

            try 
            {
                SqlDataReader dr = DbHelperSQL.ExecuteReader(sqlStr);
                dr.Read();
                if (dr!=null && dr[0].ToString().Trim() == "1")
                {
                    flag = true;
                }
                dr.Close();
            }
            catch (Exception err)
            {
                throw err;
                flag = false;
            }
            return flag;
        }
        #endregion

        #region �Ƿ��������û� //0δ��ˣ�1���ͨ����2���δͨ����3����
        public int LockUser(string loginName, int AuditStatus)
        {
            //int AuditStatus = IsLock ? 2 : 1;
            int rowsAffected = 0;
            string sqlStr = "update LoginInfoTab set AuditStatus=" + AuditStatus.ToString() + " where LoginName='" + loginName.Trim() + "'";

            try
            {
                rowsAffected = DbHelperSQL.ExecuteSql(sqlStr);
            }
            catch (Exception err)
            {
                throw err;
                rowsAffected = 0;
            }
            return rowsAffected;
        }
        #endregion



        //��ȡ��̨Ա���б�
        public DataTable GetEmployeeList(string sIsPage,  string sSort, int iPageSize, int iPageIndex, int iDoCount)
        {
            //@IsPage varchar(10),  --�Ƿ��ҳ
            //@SuperStr varchar(8000),--������ѯ��䣬##����Ϊ�գ������г�����ѯ���
            //@Sort varchar(1000), --���� ##����Ϊ�գ��������������
            //@PageSize int,  --��ҳ��ÿҳ������
            //@PageIndex int,  --ҳ��
            //@docount int --�Ƿ�ȥͳ������


            //## �ݲ���
            //string sSuperStr = "select                              "+
            //                        "b.employeeid,b.loginname, b.employeename+'['+a.loginname+']' as username,d.deptname,c.worktypename,b.enable,a.registertime   "+
            //                        ",(select tem from system where employeeid=b.loginname )   as tem   "+
            //                   "from logininfotab as a    "+
            //                        "inner join employeeinfotab b on a.loginname=b.loginname      "+
            //                        "inner join setworktypetab as c on b.worktype=c.worktype     "+
            //                        "inner join setdeptinfotab as d on b.deptid=d.deptid     "+
            //                   "where a.rolename='2' and b.enable='1' and a.enable='1'";  

            //�µĲ�ѯ���
            string sSuperStr = "select   " +
                               "     a.employeeid,a.loginname, a.employeename+'['+a.loginname+']' as username,c.deptname,b.worktypename,a.enable,d.tem  " +
                               " from employeeinfotab as a   " +
                               "      left join setworktypetab as b on a.worktype=b.worktype  " +
                               "      left join setdeptinfotab as c on a.deptid=c.deptid  " +
                               "      left join system d on a.loginname=d.employeeid  " +
                               " where a.enable='1' ";

            DataTable dt = null;
            SqlParameter[] par ={
                                    new SqlParameter("@ispage",SqlDbType.VarChar,10),
                                    new SqlParameter("@SuperStr",SqlDbType.VarChar,8000),
                                    new SqlParameter("@Sort",SqlDbType.VarChar,1000),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@docount",SqlDbType.Int)
                                };
            
            par[0].Direction=ParameterDirection.Input;
            par[0].Value = sIsPage;
            par[1].Direction=ParameterDirection.Input;
            par[1].Value = sSuperStr;
            par[2].Direction=ParameterDirection.Input;
            par[2].Value = sSort;
            par[3].Direction=ParameterDirection.Input;
            par[3].Value = iPageSize;
            par[4].Direction=ParameterDirection.Input;
            par[4].Value = iPageIndex;
            par[5].Direction=ParameterDirection.Input;
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

        //��ȡ��̨Ա���б�
        public DataTable GetEmployeeList(string sIsPage, string sSort, int iPageSize, int iPageIndex, int iDoCount, Tz888.Model.Sys.EmployeeInfoTab empMode)
        {
            //@IsPage varchar(10),  --�Ƿ��ҳ
            //@SuperStr varchar(8000),--������ѯ��䣬##����Ϊ�գ������г�����ѯ���
            //@Sort varchar(1000), --���� ##����Ϊ�գ��������������
            //@PageSize int,  --��ҳ��ÿҳ������
            //@PageIndex int,  --ҳ��
            //@docount int --�Ƿ�ȥͳ������

            //�µĲ�ѯ���
            string sSuperStr = "select   "+
                                "a.employeeid,a.loginname, a.employeename+'['+a.loginname+']' as username,c.deptname,b.worktypename,a.enable,d.tem ,a.worktype ,a.deptid " +
                                "from employeeinfotab as a     "+
                                "     left join setworktypetab as b on a.worktype=b.worktype    "+
                                "     left join setdeptinfotab as c on a.deptid=c.deptid   "+
                                "     left join system d on a.loginname=d.employeeid   "+
                                " where 1=1 ";

            //empMode.EmployeeName = tbLoginName.Value.Trim(); //�˺�
            //empMode.DeptID = ddlDept.SelectedValue; //����
            //empMode.sRole = ddlRole.SelectedValue; //��ɫ
            //empMode.WorkType = ddlWorkType.SelectedValue; //��λ
            //empMode.sStatus = ddlStatus.SelectedValue; //״̬
            if (empMode.EmployeeName!=null &&  empMode.EmployeeName != "")
            {
                sSuperStr += " and (loginname like '%" + empMode.EmployeeName.Trim() + "%' or employeename like '%" + empMode.EmployeeName.Trim() + "%'  or nickname like '%" + empMode.EmployeeName.Trim() + "%' )";
            }
            if (empMode.DeptID!=null && empMode.DeptID != "")
            {
                sSuperStr +=" and a.deptid='"+ empMode.DeptID +"'";
            }
            if (empMode.WorkType!=null && empMode.WorkType != "")
            {
                sSuperStr+=" and a.worktype='"+ empMode.WorkType +"'";
            }
            if (empMode.sStatus!=null && empMode.sStatus != "2")
            {
                sSuperStr+=" and a.enable="+empMode.sStatus.Trim();
            }
            if (empMode.sRole!=null & empMode.sRole.Trim() != "")
            {
                sSuperStr+=" and loginname in(select employeeid from system where tem like '%"+ empMode.sRole.Trim() +"%')";
            }

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


        //����״̬
        public int UpdateStatus(string strID, int iStatus,int iType)
        {
            string SqlTxt = "";
            int iRetu = 0;
            //if (iType == 1)  //����logininfotab��
            //{
            //    SqlTxt = "update logininfotab  set enable=@iStatus where loginname=@strID";
            //}
            if (iType == 2) //����employeeinfotab��
            {
                SqlTxt="update employeeinfotab  set enable=@iStatus where loginname=@strID";
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlTxt;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@iStatus", SqlDbType.Int).Value = iStatus;
            cmd.Parameters.Add("@strID", SqlDbType.VarChar).Value = strID;

            try
            {
                iRetu = DbHelperSQL.ExecSqlNonQuery(cmd);
            }
            catch(SqlException err)
            {
                throw err;
            }
            return iRetu;
        }

        //��ȡ����
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

        /// <summary>
        /// ��ȡ��ɫ����
        /// </summary>
        /// <param name="strRoleIDs"></param>
        /// <returns></returns>
        public DataTable GetRoleName(string strRoleIDs)
        {
            StringBuilder SqlTxt = new StringBuilder();
            strRoleIDs = strRoleIDs.Replace(",", "','");
            SqlTxt.Append(" select SRName  from sysroletab where sroleid in('" + strRoleIDs + "') and srcheck=1 ");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlTxt.ToString();
            cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add("@strRoleIDs", SqlDbType.VarChar).Value = "'"+strRoleIDs.Replace(",","','")+"'";

            DataSet ds = new DataSet();
            try
            {
                ds = DbHelperSQL.SelectSqlDataSet(cmd);
            }
            catch (SqlException err)
            {
                throw err;
            }
            return ds.Tables[0];
        }
    }
}
