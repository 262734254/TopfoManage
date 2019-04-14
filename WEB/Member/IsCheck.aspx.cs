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

public partial class Member_IsCheck : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                int Check = Convert.ToInt32(Request.QueryString["IsCheck"]);
                int IsCheck = Check == 0 ? 1 : 0;
                int RoleID = Convert.ToInt32(Request.QueryString["RoleID"]);
                int num = 0;
                RoleTabBLL RoleTabBll = new RoleTabBLL();
                num = RoleTabBll.UpdateCheck(IsCheck, RoleID);
                if (num > 0)
                {
                    Response.Redirect("ShowRoleList.aspx");
                }
            }
        }
    }
}
