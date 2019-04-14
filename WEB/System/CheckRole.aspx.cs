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

public partial class System_CheckRole : BasePage
{
    int SRoleID;
    protected void Page_Load(object sender, EventArgs e)
    {
        SRoleID = Convert.ToInt16(Request.QueryString["SRoleID"].ToString());
        Tz888.SQLServerDAL.Sys.SysRoleTab CheckDAL = new Tz888.SQLServerDAL.Sys.SysRoleTab();
        CheckDAL.Check(SRoleID);
        Response.Redirect("Role.aspx");
    }
}
