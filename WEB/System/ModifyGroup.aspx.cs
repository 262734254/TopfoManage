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

public partial class System_ModifyGroup:BasePage
{

    private int SGID;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.SGID = Convert.ToInt16(this.Page.Request.QueryString["SGID"]);
        if (!IsPostBack)
        {
            DataBinder(SGID);
        }

    }
    private void DataBinder(int SGID)
    {
        Tz888.Model.Sys.SysGroupTab GroupModel = new Tz888.Model.Sys.SysGroupTab();
        Tz888.SQLServerDAL.Sys.SysGroupTab MDAL = new Tz888.SQLServerDAL.Sys.SysGroupTab();
        GroupModel = MDAL.GetModel(SGID);
        if (GroupModel != null)
        {
            this.SelectIndustryControl1.IndustryString = GroupModel.SRoleID;
            //Response.Write(GroupModel.SRoleID);
            this.MemberList1.IndustryString = GroupModel.EmployeeID;
        }
        this.nameTxt.Text = GroupModel.SName;
        this.TxtSRDoc.Value = GroupModel.SDescribe;
    }


    /// <summary>
    /// 修改组数据

    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Modify_btn_Click(object sender, EventArgs e)
    {

        //实体化组表的实体类


        Tz888.Model.Sys.SysGroupTab GroupModel = new Tz888.Model.Sys.SysGroupTab();

       
        List<Tz888.Model.Sys.SysRoleTab> RoleModels = new List<Tz888.Model.Sys.SysRoleTab>();
        RoleModels = this.SelectIndustryControl1.IndustryModels;
        foreach (Tz888.Model.Sys.SysRoleTab model in RoleModels)
        {
            GroupModel.SRoleID += model.SRoleID + ",";
        }
        //员工实体类声明

        List<Tz888.Model.Sys.EmployeeInfoTab> EmpModels = new List<Tz888.Model.Sys.EmployeeInfoTab>();
        EmpModels = this.MemberList1.IndustryModels;

        foreach (Tz888.Model.Sys.EmployeeInfoTab model1 in EmpModels)
        {
            GroupModel.EmployeeID += model1.EmployeeID + ",";
        }
        //组的ID
        GroupModel.SGID = Convert.ToInt16(this.SGID);
        //组名
        GroupModel.SName = this.nameTxt.Text.ToString().Trim();
        //组描述

        GroupModel.SDescribe = this.TxtSRDoc.Value.ToString().Trim();
        //是否通过
        GroupModel.SysCheck = 1;
        //创建日期
        GroupModel.SysDate = Convert.ToDateTime(DateTime.Now);
        //添加数据
        Tz888.SQLServerDAL.Sys.SysGroupTab InsertDAL = new Tz888.SQLServerDAL.Sys.SysGroupTab();
        bool flag = false;
        try
        {

            InsertDAL.Update(GroupModel);
            flag = true;
        }
        catch
        { 
        
        }
        if (flag)
        {

            Response.Write("<script>alert('修改成功');location.href='viewGroup.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('no')</script>");
        }


    }
}
