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

public partial class Member_checkMenu : BasePage
{
    Tz888.BLL.ManageSystem.MenuBLL MenuBLL = new Tz888.BLL.ManageSystem.MenuBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["MID"] != null && Request.QueryString["MParentCode"] != null)
        {
            string isCheck="1";
            if (Request.QueryString["MParentCode"].ToString().Trim() == "未审核")
            {
                isCheck = "1";
            }
            else if (Request.QueryString["MParentCode"].ToString().Trim() == "审核")
            {
                isCheck = "0";
            }
            int isOK = MenuBLL.MenuCheck(Request.QueryString["MID"].ToString(), isCheck);

            Response.Redirect("MenuInfo.aspx");
            
        }


    }
}
