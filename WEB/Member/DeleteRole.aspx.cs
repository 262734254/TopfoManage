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
using Tz888.BLL.ManageSystem;

public partial class Member_DeleteRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                int roleID = Convert.ToInt32(Request.QueryString["RoleID"]);
                if (roleID == 1001 || roleID == 1002 || roleID == 1003 || roleID == 1004 || roleID == 2001 || roleID == 2002 || roleID == 2003 || roleID == 2004 || roleID == 2005 || roleID == 2006 || roleID == 2007)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('不能删除！');location.href='ShowRoleList.aspx'", true);
                    return;
                }
                RoleTabBLL roleBll = new RoleTabBLL();
                int num = roleBll.deleteRoleById(roleID);
                if (num > 0)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');location.href='ShowRoleList.aspx'", true);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');location.href='ShowRoleList.aspx'", true);
                }
            }
        }
    }
}
