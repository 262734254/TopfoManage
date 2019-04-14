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

public partial class System_InsertGroup:BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    ///添加组用户与角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Add_btn_Click(object sender, EventArgs e)
    {
        //实体化组表的实体类

        //判断组名不能够为空

        if (this.nameTxt.Text.ToString().Trim().Length > 0)
        {
            Tz888.Model.Sys.SysGroupTab GroupModel = new Tz888.Model.Sys.SysGroupTab();

            //foreach (Tz888.Model.Common.IndustryModel model in industryModels)
            //{
            //    capitalInfoModel.IndustryBID += model.IndustryBID + ",";
            //}
            //角色的实体类声明
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

            //组名
            GroupModel.SName = this.nameTxt.Text.ToString().Trim();
            //组描述

            GroupModel.SDescribe = this.TxtSRDoc.Value.ToString().Trim();
            //是否通过
            GroupModel.SysCheck = 0;
            //创建日期
            GroupModel.SysDate = Convert.ToDateTime(DateTime.Now);
            //添加数据
            Tz888.SQLServerDAL.Sys.SysGroupTab InsertDAL = new Tz888.SQLServerDAL.Sys.SysGroupTab();
            if (InsertDAL.Add(GroupModel)>0)
            {
                //  Response.Write("<script>alert('ok')</script>");
                Response.Redirect("viewGroup.aspx");
            }
            else
            {
                Response.Write("<script>alert('no')</script>");
            }
         }
              else
              {
                //  Response.Write("<script>alert('组名不能够为空！');</script>");
                  Tz888.Common.MessageBox.Show(this.Page, "组名不能够为空！");
               }
}
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewGroup.aspx");
    }
}
