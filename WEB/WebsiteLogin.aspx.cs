using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using Tz888.BLL.Login;
using Tz888.BLL.Common;

public partial class WebsiteLogin : System.Web.UI.Page
{
    Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
    Tz888.BLL.Sys.EmployeeInfoTab bll = new Tz888.BLL.Sys.EmployeeInfoTab();
    DataTable dt = new DataTable();
    private static string strLoginName = "";
    private static string strPassword = "";
    private static string strRoleName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
        
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int ErrorID = 0;
        string ErrorMsg = "";
        Tz888.BLL.Login.LoginInfoBLL loginRule = new Tz888.BLL.Login.LoginInfoBLL();
        DataTable dt = new DataTable();
        strLoginName = txtLoginName.Value.Trim();
        strPassword = txtPassWord.Value.Trim();

        dt = loginRule.Authenticate(
            strLoginName,
            0,
            strPassword,
            false,
            ref ErrorID,
            ref ErrorMsg);

        if (dt.Rows.Count > 0) //
        {
            strRoleName = dt.Rows[0]["RoleName"].ToString().Trim();

            InsertLoginLog(strLoginName, strRoleName);

            //写登陆cookie开始
            HttpCookie loginedUser = new HttpCookie("loginedUser");
            loginedUser.Expires = DateTime.Now.AddDays(1);
            loginedUser.Value = strLoginName;

            Response.Cookies.Add(loginedUser);
            ////写登陆cookie结束
            //Tz888.BLL.Login.LoginInfoBLL.Logout();

            //分配验证票,同时建立角色信息		
           // LoginInfoBLL.SetUserFormsCookie(strLoginName, dt.Rows[0]["MemberGradeID"].ToString().Trim(), dt.Rows[0]["ManageTypeID"].ToString().Trim(), true);
           // #region  登录后SESSION记录 用户名，用户角色以及 角色组
           // Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
           // DataTable dtUser = dal.GetList("VipApplyTab", "BuyTerm", "ApplyID", 1, 1, 0, 1, "LoginName='" + strLoginName + "'");
           // string MemberType = "";
           // if (dtUser != null && dtUser.Rows.Count > 0)
           // {
           //     MemberType = dtUser.Rows[0]["BuyTerm"].ToString();
           // }
           // else { MemberType = "1"; }

           // string[] obj = { strLoginName, dt.Rows[0]["ManageTypeID"].ToString().Trim(), MemberType };

           // Session["MemberObj"] = obj;

           //#endregion

            //if (!(HttpContext.Current.User == null))
            //{
            //    if (HttpContext.Current.User.Identity.AuthenticationType == "Forms")
            //    {
            //        System.Web.Security.FormsIdentity id;
            //        id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
            //        String[] myRoles = new String[6];
            //        myRoles[0] = "2001";
            //        myRoles[1] = "2002";
            //        myRoles[2] = "2003";
            //        myRoles[3] = "2004";
            //        myRoles[4] = "2006";
            //        myRoles[5] = "2007";

            //        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, myRoles);
            //    }
            //}
           // Response.Write("<script>window.close();</script>");
            //Response.Write("<script>alert('sssssssss!')</script>");
            Response.Write("<script>alert('1');</script>");
        }
        else
        {
            InsertLoginErrorLog(strLoginName);

            if (dt.Rows.Count == 0)
            {
                divText.InnerHtml = "您输入的用户名或密码不正确,请重新登录!";
            }
        }
    }

   
    #region 插入登录失败日志
    private void InsertLoginErrorLog(string strLoginName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginErrorLog(strLoginName, dtLoginTime, strLoginIP, true);
    }
    #endregion
    #region 插入登录日志
    private void InsertLoginLog(string strLoginName, string strRoleName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginLog(strLoginName, strRoleName, dtLoginTime, strLoginIP);

    }
    #endregion
}
