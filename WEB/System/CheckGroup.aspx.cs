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

public partial class System_CheckGroup:BasePage
{
    int SGID;
    protected void Page_Load(object sender, EventArgs e)
    {
        SGID = Convert.ToInt16(Request.QueryString["SGID"].ToString());
        Tz888.SQLServerDAL.Sys.SysGroupTab CheckDAL = new Tz888.SQLServerDAL.Sys.SysGroupTab();
        CheckDAL.Check(SGID);
        Response.Redirect("viewGroup.aspx");
    }
}
