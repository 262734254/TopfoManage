using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Login : System.Web.UI.Page
{
    Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
    Tz888.BLL.Sys.EmployeeInfoTab bll = new Tz888.BLL.Sys.EmployeeInfoTab();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        tbLoginName.Focus();
    }
    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            if (txtValidator.Value.Trim() == "")
            {
                Tz888.Common.MessageBox.Show(this, "验证码不能为空，请输入验证码！");
                return;
            }

            if (txtValidator.Value.Trim().ToUpper() != Session["valationNo"].ToString().Trim().ToUpper())
            {
                Tz888.Common.MessageBox.Show(this, "验证码错误，请重新输入验证码！");
                txtValidator.Focus();
                return;
            }
            else
            {
                Session["valationNo"] = null;
            }

            if (tbLoginName.Value.Trim() != "" && tbPassword.Value.Trim() != "")
            {
                //之前的，暂不用 dt = loginBll.Authenticate(tbLoginName.Value.Trim(), tbPassword.Value.Trim(), false);
                dt = bll.Authenticate(tbLoginName.Value.Trim(), tbPassword.Value.Trim(), Tz888.Common.Text.GetIp().Trim());
                if (dt == null || dt.Rows.Count > 0)
                {
                    //登录成功

                    //写登陆cookie开始
                    //HttpCookie loginedUser = new HttpCookie("loginedUser");
                    //loginedUser.Expires = DateTime.Now.AddDays(1);
                    //loginedUser.Value = tbLoginName.Value.Trim();
                    //Response.Cookies.Add(loginedUser);
                    //写登陆cookie结束
                    //写session
                    BasePage bp = new BasePage();
                    bp.LoginName = tbLoginName.Value.Trim();
                   

                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this, "用户未审核或用户名与密码不正确！");
                    tbLoginName.Focus();
                    return;
                }
            }
            else
            {
                if (tbLoginName.Value.Trim() == "")
                {
                    Tz888.Common.MessageBox.Show(this, "登录用户名不能为空，请输入！");
                    tbLoginName.Focus();
                    return;
                }
                if (tbPassword.Value.Trim() == "")
                {
                    Tz888.Common.MessageBox.Show(this, "登录密码不能为空，请输入！");
                    tbPassword.Focus();
                    return;
                }
            }
        }
        catch(Exception err)
        {
            throw err;
        }
    }
}
