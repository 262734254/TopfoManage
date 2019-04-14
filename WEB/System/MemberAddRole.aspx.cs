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
using System.Collections.Generic;

public partial class System_MemberAddRole:BasePage
{
    private string EmployeeID;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.EmployeeID =this.Page.Request.QueryString["EmployeeID"].ToString().Trim();
        //this.EmployeeID = "11";
        if (!IsPostBack)
        {
            DataBinder(EmployeeID);
        }
    }

    /// <summary>
    /// 绑定最初的用户的角色

    /// </summary>
    /// <param name="EmployeeID"></param>
    private void DataBinder(string EmployeeID)
    {
        //Tz888.Model.Sys.SysGroupTab GroupModel = new Tz888.Model.Sys.SysGroupTab();
        Tz888.Model.Sys.System SystModel = new Tz888.Model.Sys.System();

        //Tz888.SQLServerDAL.Common.MemberDAL MDAL = new Tz888.SQLServerDAL.Common.MemberDAL();
        Tz888.SQLServerDAL.Sys.System RDAL = new Tz888.SQLServerDAL.Sys.System();
        
        //GroupModel = MDAL.GetModel(EmployeeID);
        SystModel = RDAL.GetModel(EmployeeID);
        if (SystModel != null)
        {
            this.SelectIndustryControl1.IndustryString = SystModel.Tem;
        }
      
    }


    //修改用户角色信息
    protected void Modify_btn_Click(object sender, EventArgs e)
    {
        Tz888.Model.Sys.System SysModel = new Tz888.Model.Sys.System();

        List<Tz888.Model.Sys.SysRoleTab> RoleModels = new List<Tz888.Model.Sys.SysRoleTab>();
        RoleModels=this.SelectIndustryControl1.IndustryModels;
        foreach (Tz888.Model.Sys.SysRoleTab model in RoleModels)
        {
           //GroupModel.SRoleID += model.SRoleID + ",";
            SysModel.Tem += model.SRoleID + ",";

        }
        SysModel.EmployeeID = EmployeeID;

        //添加数据
        Tz888.SQLServerDAL.Sys.System SysUpDAL = new Tz888.SQLServerDAL.Sys.System();

        if (SysUpDAL.Update(SysModel))
        {

            Response.Write("<script>alert('修改成功');location.href='SysUser.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('no')</script>");
        }

    }
    protected void re_btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SysUser.aspx");
    }
}
