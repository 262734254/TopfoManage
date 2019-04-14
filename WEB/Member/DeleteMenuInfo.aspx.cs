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

public partial class Member_DeleteMenuInfo : BasePage
{
    Tz888.BLL.ManageSystem.MenuBLL MenuBLL = new Tz888.BLL.ManageSystem.MenuBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["MID"] != null && Request.QueryString["MParentCode"]!=null) 
        {
            bool isOK = MenuBLL.deletMenuInfoList(Request.QueryString["MParentCode"].ToString(), Request.QueryString["MID"].ToString());
            if (isOK) 
            {
                Tz888.Common.MessageBox.ShowAndHref("菜单删除成功", "MenuInfo.aspx");
            }
        }
        
        
    }
}
