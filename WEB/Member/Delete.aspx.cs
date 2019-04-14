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

public partial class Member_Delete : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                RoleGroupBLL roleGroupBll = new RoleGroupBLL();
                int roleGroupId = Convert.ToInt32(Request.QueryString["Id"]);
                int num = roleGroupBll.DeleteRoleGroup(roleGroupId);
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
