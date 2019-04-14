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

public partial class Member_IsKaiTong : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                RoleGroupBLL roleGroupBll = new RoleGroupBLL();
                string Id = Request.QueryString["Id"].ToString().Trim();
                int Check =Convert.ToInt32(Request.QueryString["IsKai"]);
                int IsKai = Check == 1 ? 0 : 1;
                if (roleGroupBll.UPdateRoleGroupSCheck(Id, IsKai))
                {
                    Response.Redirect("ShowRoleList.aspx");
                }
            }
        }
    }
}
