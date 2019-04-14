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
using Tz888.Model.ManageSystem;
using System.Collections.Generic;
using Tz888.BLL.ManageSystem;

public partial class ManageSystem_ShowRoleList : BasePage
{
    RoleTabBLL RoleTabBll = new RoleTabBLL();
    RoleGroupBLL roleGroupBll = new RoleGroupBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBin();
        }
    }

    /// <summary>
    /// 绑定Repeater1的数据

    /// </summary>
    public void dataBin()
    {
        this.Repeater1.DataSource = RoleTabBll.SelectAllRoles();
        this.DataBind();
    }

    /// <summary>
    /// 绑定Repeater2的数据源
    /// </summary>
    /// <param name="RoleID"></param>
    /// <returns></returns>
    protected DataTable GetDataSourceByRoleID(int RoleID)
    {
        //IList<RoleGroupTab> ListRoleGroupTab = new List<RoleGroupTab>();
        DataTable dt = roleGroupBll.SelectAllRolGroup(RoleID);
        return dt;
    }

    /// <summary>
    /// 转换是否审核的值
    /// </summary>
    /// <param name="IsCheck"></param>
    /// <returns></returns>
    protected string getCheckType(object IsCheck)
    {
        if (IsCheck.ToString() == "1")
        {
            return "已审核";
        }
        else
        {
            return "<font color='red'>未审核</font>";
        }
    }

    /// <summary>
    /// 转换是否开通
    /// </summary>
    /// <param name="IsCheck"></param>
    /// <returns></returns>
    protected string getSCheck(object IsCheck)
    {
        if (IsCheck.ToString() == "1")
        {
            return "已开通";
        }
        else
        {
            return "<font color='red'>未开通</font>";
        }
    }

    /// <summary>
    /// repeater1
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int num = 0;
        switch (e.CommandName)
        {
            case "Add":
                Response.Redirect("AddRoleGrop.aspx?RoleID=" + Convert.ToInt32(e.CommandArgument)+"&name="+e.CommandName.ToString().Trim());
                break;
            case "IsCheck":
                
                int RoleID = Convert.ToInt32(e.CommandArgument);
                LinkButton linkBtn = e.Item.FindControl("LinkButton2") as LinkButton;
                int IsCheck = Convert.ToInt32(linkBtn.Text.ToString().Trim() == "已审核" ? 0 : 1);
                //num = RoleTabBll.UpdateCheck(IsCheck, RoleID);
                Response.Redirect("IsCheck.aspx?IsCheck="+IsCheck+"&RoleID="+RoleID);
                //dataBin();
                break;
            case"Edit":
                Response.Redirect("AddRole.aspx?RoleID=" + Convert.ToInt32(e.CommandArgument));
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int num = 0;
        switch (e.CommandName)
        {
            case "delete":
                int roleGroupId = Convert.ToInt32(e.CommandArgument);
                num = roleGroupBll.DeleteRoleGroup(roleGroupId);
                if (num > 0)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');location.href='ShowRoleList.aspx'", true);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');location.href='ShowRoleList.aspx'", true);
                }
                break;
            case "Edit":
                Response.Redirect("AddRoleGrop.aspx?RoleID=" + Convert.ToInt32(e.CommandArgument.ToString().Trim())+"&name="+e.CommandName.ToString().Trim());
                break;
                case "IsKai":
                    string Id =e.CommandArgument.ToString().Trim();
                    int Check = (roleGroupBll.GetRoleGroupById(Id)).SCheck;
                    int SCheck =Check==1?0:1;
                    roleGroupBll.UPdateRoleGroupSCheck(Id, SCheck);
                    this.dataBin();
                break;
            default:
                break;
        }
    }
}
