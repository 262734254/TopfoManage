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

public partial class Member_Test2 : System.Web.UI.Page
{
    Tz888.BLL.ManageSystem.MenuBLL MenuBLL = new Tz888.BLL.ManageSystem.MenuBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        databind();
    }

    private void databind()
    {
        rpMax.DataSource = MenuBLL.getMenuInfoList("0");
        rpMax.DataBind();
    }

    public DataTable GetDataSourceByMID(string MID)
    {
        return MenuBLL.getMenuInfoList(MID);
    }
    protected void rpMax_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int num = 0;
        switch (e.CommandName)
        {
            case "check":
                //Response.Redirect("a.aspx?id" + 1 + "adtin=" + 1);
                //LinkButton lkCheck = e.Item.FindControl("lkCheck") as LinkButton;
                //if (lkCheck.ToolTip.ToString() == "1")
                //{
                //    num = MenuBLL.MenuCheck(e.CommandArgument.ToString(), "0");
                //}
                //else
                //{
                //    num = MenuBLL.MenuCheck(e.CommandArgument.ToString(), "1");
                //}
                //databind();
                break;
            case "delete":
                //LinkButton lkDelete = e.Item.FindControl("lkDelete") as LinkButton;
                //MenuBLL.deletMenuInfoList("0", e.CommandArgument.ToString());
                //databind();
                break;
            default:
                break;
        }
    }
    protected void rpMini_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int num = 0;
        switch (e.CommandName)
        {
            case "check":
                //LinkButton lkCheck = e.Item.FindControl("lkCheck") as LinkButton;

                //num = MenuBLL.MenuCheck(e.CommandArgument.ToString(), lkCheck.ToolTip.ToString());
                //databind();
                break;
            case "delete":
                //LinkButton lkDelete = e.Item.FindControl("lkDelete") as LinkButton;

                break;
            default:
                break;
        }
    }

    protected string getCheckType(object MCheck)
    {
        if (MCheck.ToString() == "1")
        {
            return "审核";
        }
        else
        {
            return "未审核";
        }
    }
}
