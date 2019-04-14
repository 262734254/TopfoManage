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

public partial class ManageSystem_AddRoleGrop : BasePage
{
    RoleGroupBLL roleGroupBLL = new RoleGroupBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                string name = Request.QueryString["name"].ToString().Trim();
                if (name.Equals("Edit"))
                {
                    if (Request.QueryString["RoleID"].ToString().Trim() != null)
                    {
                        string roleGroupId = Request.QueryString["RoleID"].ToString().Trim();
                        RoleGroupTab roleGroup = new RoleGroupTab();
                        roleGroup = roleGroupBLL.GetRoleGroupById(roleGroupId);
                        if (roleGroup != null)
                        {
                            this.txtRoleGroupID.Text = roleGroup.MemberGradeID.ToString();
                            this.txtRoleGroupName.Text = roleGroup.MemberGradeName.ToString();
                            this.txtGroupRemark.Text = roleGroup.Remark.ToString();
                            this.txtRoleGroupID.ReadOnly = true;
                            this.Button1.Enabled = false;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 添加角色组
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string roleId = Request.QueryString["RoleID"].ToString();
        RoleGroupTab roleGroup = new RoleGroupTab();
        if (this.txtRoleGroupName.Text.ToString().Trim() == null || this.txtRoleGroupName.Text.ToString().Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入角色组名称！');location.href='AddRoleGrop.aspx'", true);
            return;
        }
        if (this.txtRoleGroupName.Text == "普通会员")
        {
            roleGroup.MemberGradeID ="1";
        }
        else if (this.txtRoleGroupName.Text == "银牌会员")
        {
            roleGroup.MemberGradeID = "2";
        }
        else if (this.txtRoleGroupName.Text == "金牌会员")
        {
            roleGroup.MemberGradeID = "3";
        }
        else if (this.txtRoleGroupName.Text == "钻石会员")
        {
            roleGroup.MemberGradeID = "4";
        }
        else
        {
            roleGroup.MemberGradeID = this.txtRoleGroupID.Text.ToString().Trim();
        }
        roleGroup.ManageTypeID = roleId;
        roleGroup.MemberGradeName = this.txtRoleGroupName.Text.ToString().Trim();
        roleGroup.SDate = DateTime.Now;
        roleGroup.SCheck = 0;
        roleGroup.IsVip = 0;
        roleGroup.Remark = this.txtGroupRemark.Text.ToString().Trim();
        if (IsExist(roleGroup.MemberGradeID, roleGroup.MemberGradeName))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('角色组名称或角色组ID已存在！');location.href='AddRole.aspx'", true);
            return;
        }
        try
        {
            if (roleGroupBLL.AddRoleGroup(roleGroup))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加角色组成功！');location.href='ShowRoleList.aspx'", true);
                return;
            }           
        }
        catch (Exception ex)
        { 
           this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加角色组失败！');location.href='AddRoleGrop.aspx'", true);
           return;
        }
    }

    /// <summary>
    /// 判断角色组是否已经存在
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool IsExist(string ID, string name)
    {
        DataTable dt = new DataTable();
        dt = roleGroupBLL.IsExistRole(ID, name);
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 修改角色信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click1(object sender, EventArgs e)
    {
        RoleGroupTab roleGroup = new RoleGroupTab();
        roleGroup.MemberGradeName = this.txtRoleGroupName.Text.ToString().Trim();
        roleGroup.Remark = this.txtGroupRemark.Text.ToString().Trim();
        roleGroup.MemberGradeID = this.txtRoleGroupID.Text.ToString().Trim();
        if (roleGroupBLL.UPdateRoleGroupInfo(roleGroup))
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('角色组信息修改成功！');location.href='ShowRoleList.aspx'", true);
            return;
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('角色组信息修改失败！');location.href='ShowRoleList.aspx'", true);
            return;
        }
    }
}
