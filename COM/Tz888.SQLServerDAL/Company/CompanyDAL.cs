using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.Company;
using Tz888.Model.Company;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Company
{
    public class CompanyDAL : ICompanyInfoTab
    {
        CrmDBHelper crm = new CrmDBHelper();

        #region 企业名片修改
        /// <summary>
        /// 企业名片修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Company_Update(CompanyModel model, int id)
        {
            int rowsAffected;
            int num = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@IndustryID", SqlDbType.Int,4),
					new SqlParameter("@IndustryName", SqlDbType.VarChar,50),
					new SqlParameter("@RangeID", SqlDbType.Int,4),
					new SqlParameter("@RangeName", SqlDbType.VarChar,50),
					new SqlParameter("@NatureID", SqlDbType.Int,4),
					new SqlParameter("@NatureName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@Integrity", SqlDbType.Int,4),
					new SqlParameter("@EstablishMent", SqlDbType.VarChar,50),
					new SqlParameter("@Employees", SqlDbType.BigInt,8),
					new SqlParameter("@Capital", SqlDbType.BigInt,8),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@URL", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@Logo", SqlDbType.VarChar,1000),
					new SqlParameter("@Introduction", SqlDbType.NVarChar,2000),
					new SqlParameter("@ServiceProce", SqlDbType.NVarChar,2000),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Keywords", SqlDbType.VarChar,100),
					new SqlParameter("@Description", SqlDbType.VarChar,300),
                    new SqlParameter("@TelPhone",SqlDbType.VarChar,50),
                    new SqlParameter("@Mobile",SqlDbType.VarChar,50),
                    new SqlParameter("@AuditingStatus",SqlDbType.Int,4),
                    new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),
                    new SqlParameter("@Ismake",SqlDbType.Int,4),
                    new SqlParameter("@IsDelete",SqlDbType.Int,4),
                    new SqlParameter("@Provice",SqlDbType.Int,4),
                    new SqlParameter("@City",SqlDbType.Int,4)
            };
            model.CompanyID = id;
            parameters[0].Value = model.CompanyID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.CompanyName;
            parameters[3].Value = model.IndustryID;
            parameters[4].Value = model.IndustryName;
            parameters[5].Value = model.RangeID;
            parameters[6].Value = model.RangeName;
            parameters[7].Value = model.NatureID;
            parameters[8].Value = model.NatureName;
            parameters[9].Value = model.CreateDate;
            parameters[10].Value = model.Hit;
            parameters[11].Value = model.Integrity;
            parameters[12].Value = model.EstablishMent;
            parameters[13].Value = model.Employees;
            parameters[14].Value = model.Capital;
            parameters[15].Value = model.LinkName;
            parameters[16].Value = model.Email;
            parameters[17].Value = model.URL;
            parameters[18].Value = model.Address;
            parameters[19].Value = model.Logo;
            parameters[20].Value = model.Introduction;
            parameters[21].Value = model.ServiceProce;
            parameters[22].Value = model.Title;
            parameters[23].Value = model.Keywords;
            parameters[24].Value = model.Description;
            parameters[25].Value = model.Telphone;
            parameters[26].Value = model.Mobile;
            parameters[27].Value = model.Auditingstatus;
            parameters[28].Value = model.Htmlfile;
            parameters[29].Value = model.Ismake;
            parameters[30].Value = model.IsDelete;
            parameters[31].Value = model.Sheng;
            parameters[32].Value = model.City;
            num = crm.RunProcedure("Pro_Company_Update", parameters, out rowsAffected);
            return num;
        }
        #endregion

        #region 根据编号查询所对应的信息
        public CompanyModel SelCompany(int id)
        {
            CompanyModel com = new CompanyModel();
            string sql = "select [CompanyID],[FromId],[LoginName],[CompanyName],[IndustryID],[IndustryName],[RangeID],"
                +"[RangeName],[NatureID],[NatureName],[CreateDate],[Hit],[AuditingStatus],[HtmlFile],[Integrity],"
                +"[EstablishMent],[Employees],[Capital],[Ismake],[IsDelete],[LinkName],[Email],[TelPhone],[Mobile],"
                +"[URL],[Address],[Logo],[Introduction],[ServiceProce],[Title],[Keywords],[Description],[Sheng],[City] from [CompanyTab] "
                + "where CompanyID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,4)
            };
            para[0].Value = id;
            DataSet ds = crm.Query(sql,para);
            com.CompanyID = Convert.ToInt32(ds.Tables[0].Rows[0]["CompanyID"].ToString());
            com.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();//用户帐号
            com.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();//企业名称
            com.IndustryID = Convert.ToInt32(ds.Tables[0].Rows[0]["IndustryID"].ToString());//行业ID
            com.IndustryName = ds.Tables[0].Rows[0]["IndustryName"].ToString();//行业名称   
            com.RangeID = Convert.ToInt32(ds.Tables[0].Rows[0]["RangeID"].ToString());//区域ID
            com.RangeName = ds.Tables[0].Rows[0]["RangeName"].ToString();//区域名称
            com.NatureID = Convert.ToInt32(ds.Tables[0].Rows[0]["NatureID"].ToString());//企业性质ID
            com.NatureName = ds.Tables[0].Rows[0]["NatureName"].ToString();//企业性质名称

            com.CreateDate =Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"].ToString());//发布日期
            com.Hit =Convert.ToInt32(ds.Tables[0].Rows[0]["Hit"].ToString());//点击率
            com.Auditingstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["Auditingstatus"].ToString());//审核状态
            com.Htmlfile = ds.Tables[0].Rows[0]["Htmlfile"].ToString();//静态路径
            com.Integrity =Convert.ToInt32(ds.Tables[0].Rows[0]["Integrity"].ToString());//诚信指度
            com.EstablishMent = ds.Tables[0].Rows[0]["EstablishMent"].ToString();//成立日期
            com.Employees =Convert.ToInt64( ds.Tables[0].Rows[0]["Employees"].ToString());//员工人数    
            com.Capital =Convert.ToInt64(ds.Tables[0].Rows[0]["Capital"].ToString());//注册自己
            com.Ismake = Convert.ToInt32(ds.Tables[0].Rows[0]["Ismake"].ToString());//是否推荐  
            com.IsDelete = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDelete"].ToString());//是否删除

            com.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();//联系人
            com.Email = ds.Tables[0].Rows[0]["Email"].ToString();//电子邮箱
            com.Telphone = ds.Tables[0].Rows[0]["TelPhone"].ToString();//电话号码
            com.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();//手机号码
            com.URL = ds.Tables[0].Rows[0]["URL"].ToString();//网址
            com.Address = ds.Tables[0].Rows[0]["Address"].ToString();//联系地址
            com.Logo = ds.Tables[0].Rows[0]["Logo"].ToString();//图片
            com.Introduction = ds.Tables[0].Rows[0]["Introduction"].ToString();//企业介绍
            com.ServiceProce = ds.Tables[0].Rows[0]["ServiceProce"].ToString();//主营介绍
            com.Title = ds.Tables[0].Rows[0]["Title"].ToString();//标题
            com.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();//网页关键字
            com.Description = ds.Tables[0].Rows[0]["Description"].ToString();//网页短标题
            com.Sheng = Convert.ToInt32(ds.Tables[0].Rows[0]["Sheng"].ToString());
            com.City = Convert.ToInt32(ds.Tables[0].Rows[0]["City"].ToString());
            com.FromId = Convert.ToInt32(ds.Tables[0].Rows[0]["FromId"].ToString());//来源
            return com;
        }
        #endregion

        #region 删除时，改变状态，不显示出来
        /// <summary>
        /// 删除时，改变状态，不显示出来
        /// </summary>
        /// <returns></returns>
        public int UpdateDelete(int id)
        {
            int num = 0;
            string sql = "update CompanyTab set IsDelete=1 where CompanyID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,4)
            };
            para[0].Value = id;
            num = Convert.ToInt32(crm.GetSingle(sql, para));
            return num;
        }
        #endregion

        #region 彻底删除
        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <returns></returns>
        public int DelCompany(int id)
        {
            int num = 0;
            string sql = "delete from  CompanyTab where CompanyID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,4)
            };
            para[0].Value = id;
            num = Convert.ToInt32(crm.GetSingle(sql, para));
            return num;
        }
        #endregion
        #region 访问率
        /// <summary>
        /// 访问率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyHit(int id)
        {
            int num = 0;
            string sql = "select Hit from CompanyTab where CompanyID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            num = Convert.ToInt32(crm.GetSingle(sql, para).ToString());
            int Hit = num + 1;
            string sqll = "update CompanyTab set Hit=@Hit where CompanyID=@id";
            SqlParameter[] sqlpara ={ 
                 new SqlParameter("@Hit",SqlDbType.Int,8),
                new SqlParameter("@id",SqlDbType.Int,8)
            };
            sqlpara[0].Value = Hit;
            sqlpara[1].Value = id;
            int com = Convert.ToInt32(crm.GetSingle(sqll, sqlpara));
            return Hit;
        }
        #endregion

        #region 查询联系人信息
        /// <summary>
        /// 查询联系人信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelLinkName(int id)
        {
            StringBuilder sb = new StringBuilder();
            CompanyModel com = new CompanyModel();
            com = SelCompany(id);
            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tab1\">");
            sb.Append("<tr><td class=\"col\">企业名称：</td>");
            sb.Append("<td colspan=\"3\">"+com.CompanyName+"</td></tr>");
            sb.Append("<tr><td width=\"17%\" class=\"col\">联系人：</td><td width=\"30%\">"+com.LinkName+"</td>");
            sb.Append("<td width=\"15%\" class=\"col\">联系电话：</td><td>"+com.Telphone+"</td></tr>");
            sb.Append("<tr><td class=\"col\">企业网址：</td><td>"+com.URL+"</td>");
            sb.Append("<td class=\"col\">  EMail:</td><td>"+com.Email+"</td></tr>");
            sb.Append("<tr><td class=\"col\">企业地址：</td>");
            sb.Append("<td colspan=\"3\">"+com.Address+"</td></tr>");
            sb.Append("</table>");
            return sb.ToString();
        }
        #endregion

        #region 判断静态模版是否存在
        /// <summary>
        /// 判断静态模版是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelHtmlFile(int id)
        {
            string num = "";
            string sql = "select HtmlFile from CompanyTab where CompanyID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,4)
            };
            para[0].Value = id;
            num = Convert.ToString(crm.GetSingle(sql,para));
            return num;
        }
        #endregion

        #region 分页查询
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

            DataSet ds = crm.RunProcedure("GetDataList", parameters, "ds");

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
        #endregion 

        #region 录入企业名片
        /// <summary>
        /// 录入企业名片
        /// </summary>
        /// <param name="companymodel"></param>
        public int InsertCompany(CompanyModel companymodel)
        {
            string sql = "insert into CompanyTab(LoginName, CompanyName, IndustryID, IndustryName, RangeID, RangeName, NatureID, NatureName, CreateDate, Hit, Integrity, EstablishMent, Employees, Capital, LinkName, Email, URL, Address, Logo, Introduction, ServiceProce, Title, Keywords, Description, Telphone, Mobile, Auditingstatus, HtmlFile, Ismake, IsDelete, FromId, Sheng, City)" +
              "values(@LoginName, @CompanyName, @IndustryID, @IndustryName, @RangeID, @RangeName, @NatureID, @NatureName, @CreateDate, @Hit, @Integrity, " +
              "@EstablishMent, @Employees, @Capital, @LinkName, @Email, @URL, @Address, @Logo, @Introduction, @ServiceProce, @Title, @Keywords, @Description, @Telphone, @Mobile, @Auditingstatus, @HtmlFile, @Ismake, @IsDelete, @FromId, @Sheng, @City)";
            SqlParameter[] Parms = new SqlParameter[] { 
                new SqlParameter("@LoginName",companymodel.LoginName),
                new SqlParameter("@CompanyName",companymodel.CompanyName),
                new SqlParameter("@IndustryID",companymodel.IndustryID),
                new SqlParameter("@IndustryName",companymodel.IndustryName),
                new SqlParameter("@RangeID",companymodel.RangeID),
                new SqlParameter("@RangeName",companymodel.RangeName),
                new SqlParameter("@NatureID",companymodel.NatureID),
                new SqlParameter("@NatureName",companymodel.NatureName),
                new SqlParameter("@CreateDate",companymodel.CreateDate),
                new SqlParameter("@Hit",companymodel.Hit),
                new SqlParameter("@Integrity",companymodel.Integrity),
                new SqlParameter("@EstablishMent",companymodel.EstablishMent),
                new SqlParameter("@Employees",companymodel.Employees),
                new SqlParameter("@Capital",companymodel.Capital),
                new SqlParameter("@LinkName",companymodel.LinkName),
                new SqlParameter("@Email",companymodel.Email),
                new SqlParameter("@URL",companymodel.URL),
                new SqlParameter("@Address",companymodel.Address),
                new SqlParameter("@Logo",companymodel.Logo),
                new SqlParameter("@Introduction",companymodel.Introduction),
                new SqlParameter("@ServiceProce",companymodel.ServiceProce),
                new SqlParameter("@Title",companymodel.Title),
                new SqlParameter("@Keywords",companymodel.Keywords),
                new SqlParameter("@Description",companymodel.Description),
                new SqlParameter("@Telphone",companymodel.Telphone),
                new SqlParameter("@Mobile",companymodel.Mobile),
                new SqlParameter("@Auditingstatus",companymodel.Auditingstatus),
                new SqlParameter("@HtmlFile",companymodel.Htmlfile),
                new SqlParameter("@Ismake",companymodel.Ismake),
                new SqlParameter("@IsDelete",companymodel.IsDelete),
                new SqlParameter("@FromId",companymodel.FromId),
                new SqlParameter("@Sheng",companymodel.Sheng),
                new SqlParameter("@City",companymodel.City)
            };
            return crm.ExecuteSql(sql, Parms);
        }
        #endregion
    }
}