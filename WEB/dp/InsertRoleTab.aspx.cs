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

public partial class dp_InsertRoleTab : System.Web.UI.Page//BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SRoleID"] != null)//窗体加载ID为空则为添加角色，不为空则为修改角色
            {
                this.BtnInsert.Visible = false;
                this.ButUpdate.Visible = true;
                
                int id = Convert.ToInt32(Request.QueryString["SRoleID"]);
                Tz888.Model.dp.SysRoleTab model = new Tz888.Model.dp.SysRoleTab();
                Tz888.BLL.dp.SysRoleTab bll = new Tz888.BLL.dp.SysRoleTab();
                model = bll.GetModel(id);
                this.TxtSRDoc.Value = model.SRDoc;
                this.TxtSrName.Text = model.SRName;
            }
            else
            {
                this.BtnInsert.Visible = true;
                this.ButUpdate.Visible = false;
            }
        }
    }
    /// <summary>
    /// 添加角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        if (this.TxtSrName.Text.ToString().Trim().Length > 0)
        {

            Tz888.BLL.dp.SysRoleTab rt = new Tz888.BLL.dp.SysRoleTab();
            Tz888.Model.dp.SysRoleTab model = new Tz888.Model.dp.SysRoleTab();
            model.SRName = this.TxtSrName.Text;
            model.SysCode = "aa";
            model.SRDoc = this.TxtSRDoc.Value.Trim();
            model.SRDate = DateTime.Now;
            int a = rt.Add(model);
            if (a > 0)
            {
                Response.Write("<script>alert('添加成功！');document.location='Role.aspx'</script>");
            }
            else
            {
               // Response.Write("<script>alert('添加失败！');</script>");
                Tz888.Common.MessageBox.Show(this.Page, "添加失败");
            }
        }

        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "名称不能为空！");
        }


    }
    /// <summary>
    /// 修改角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ButUpdate_Click(object sender, EventArgs e)
    {
        Tz888.BLL.dp.SysRoleTab rt = new Tz888.BLL.dp.SysRoleTab();
        Tz888.Model.dp.SysRoleTab model = new Tz888.Model.dp.SysRoleTab();
        model.SRoleID = Convert.ToInt32(Request.QueryString["SRoleID"]);
        model.SRName = this.TxtSrName.Text;
        model.SRDoc = this.TxtSRDoc.Value;
        model.SysCode = "2";
        model.SRDate = DateTime.Now;
        rt.Update(model);
        Response.Write("<script>alert('修改成功！');document.location='Role.aspx'</script>");
        
    }
    protected void rebtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Role.aspx");
    }
}
