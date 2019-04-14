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
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class System_ModefiyPassword :System.Web.UI.Page// BasePage
{
    Tz888.BLL.Sys.EmployeeInfoTab empBll = new Tz888.BLL.Sys.EmployeeInfoTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //string b = Tz888.Common.Text.Decrypt(
            lbmenu.Text = "修改用户密码";
            BasePage bp = new BasePage();
            bp.LoginName = "tz888";
            txtUserName.Text = bp.LoginName;
            //byte[] pwd = empBll.GetPwdByLoginName(txtUserName.Text.Trim());
            //string a = Tz888.Common.Text.Decrypt(pwd, "topfo");
            //txtOldPwd.Text = a.ToString();
        }
    }
    //修改
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        SHA1 sha1 = SHA1.Create();
        byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(txtConfirmPassword.Text.Trim()));
        if (empBll.UpdatePwdByLoginName(txtUserName.Text.Trim(), bytePassword) > 0)
        {
            Response.Write("<script>alert('修改成功')</script>");
        }
    }
}
