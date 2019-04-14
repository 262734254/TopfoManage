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
using Tz888.BLL.ManageSystem;

public partial class ManageSystem_AddRole : BasePage
{
    RoleTabBLL roleTabBLL = new RoleTabBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["RoleID"].ToString().Trim() != null)
                {
                    string roleId = Request.QueryString["RoleID"].ToString().Trim();
                    RoleTab roleTab = new RoleTab();
                    roleTab = roleTabBLL.GetRoleById(roleId);
                    if (roleTab != null)
                    {
                        this.txtRoleID.Text = roleTab.ManageTypeID.ToString();
                        this.txtRoleName.Text = roleTab.ManageTypeName.ToString();
                        this.txtRemark.Text = roleTab.Remark.ToString();
                        this.txtRoleID.ReadOnly = true;
                        this.Button1.Enabled = false;
                    }
                }
            }
        }
    }
    /// <summary>
    /// 添加角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        RoleTab role = new RoleTab();
        if (this.txtRoleName.Text.ToString().Trim() == null || this.txtRoleName.Text.ToString().Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入角色名称！');location.href='AddRole.aspx'", true);
            return;
        }
        try
        {
            int id =Convert.ToInt32(this.txtRoleID.Text.ToString().Trim());
        }
        catch (Exception a)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('角色ID请输入数字类型！');location.href='AddRole.aspx'", true);
            return;
        }
        role.ManageTypeName = this.txtRoleName.Text.ToString().Trim();
        role.Remark = this.txtRemark.Text.ToString().Trim();
        role.RDate = DateTime.Now;
        role.ManageTypeID = this.txtRoleID.Text.ToString().Trim();
        role.IsCheck = 0;
        if (IsExist(role.ManageTypeID, role.ManageTypeName))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('角色名称或角色ID已存在！');location.href='AddRole.aspx'", true);
            return;
        }
        if (roleTabBLL.AddRole(role))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加角色成功！');location.href='ShowRoleList.aspx'", true);
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加角色失败！');location.href='AddRole.aspx'", true);
        }
    }

    /// <summary>
    /// 判断角色是否已经存在
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool IsExist(string ID, string name)
    {
        DataTable dt = new DataTable();
        dt = roleTabBLL.IsExistRole(ID, name);
        if (dt.Rows.Count>0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 修改角色信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        RoleTab roleTab = new RoleTab();
        roleTab.ManageTypeName = this.txtRoleName.Text.ToString().Trim();
        roleTab.Remark = this.txtRemark.Text.ToString().Trim();
        roleTab.ManageTypeID = this.txtRoleID.Text.ToString().Trim();
        if (roleTabBLL.UPdateRoleInfo(roleTab))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('角色信息修改成功！');location.href='ShowRoleList.aspx'", true);
            return;
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('角色信息修改失败！');location.href='ShowRoleList.aspx'", true);
            return;
        }
    }
}
