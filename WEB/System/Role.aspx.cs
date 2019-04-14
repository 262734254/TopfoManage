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

public partial class System_Role:BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetRoleTable();
        }
    }
    /// <summary>
    /// 绑定GridView
    /// </summary>
    private void GetRoleTable()
    {
        Tz888.BLL.Sys.SysRoleTab bll = new Tz888.BLL.Sys.SysRoleTab();
        DataSet dt = bll.GetList("");
        this.GridRoleTab.DataSource = dt;
        this.GridRoleTab.DataBind();
    }
    /// <summary>
    /// 增加角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void InsertBut_Click(object sender, EventArgs e)
    {
        Response.Redirect("InsertRoleTab.aspx");
    }
    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void LinkDelete_Click(object sender, EventArgs e)
    //{
    //    LinkButton link = sender as LinkButton;
    //    int id = Convert.ToInt32(link.CommandArgument.ToString());
    //    //Response.Write("DelRole.aspx?id="+id);
    //    Response.Redirect("DelRole.aspx?id="+id);
       
    //   // Tz888.BLL.Sys.SysRoleTab bll = new Tz888.BLL.Sys.SysRoleTab();
        
    //   // bll.Delete(id);
   
    //    //Tz888.Common.MessageBox.Show(this.Page, "删除成功！");
    //   // GetRoleTable();
    //}

    /// <summary>
    /// 审核角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void LinkCheck_Click(object sender, EventArgs e)
    //{
    //    LinkButton link = sender as LinkButton;
    //    int SRoleID=Convert.ToInt32(link.CommandArgument.ToString());
    //    //Tz888.SQLServerDAL.Sys.SysRoleTab CheckDAL = new Tz888.SQLServerDAL.Sys.SysRoleTab();
    //    //CheckDAL.Check(SRoleID);
    //   // GetRoleTable();       
    //    Response.Redirect("CheckRole.aspx?SRoleID="+SRoleID);
    //}
    /// <summary>
    /// 查看权限
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkQuan_Click(object sender, EventArgs e)
    {
        LinkButton link = sender as LinkButton;
        int id = Convert.ToInt32(link.CommandArgument.ToString());
        Response.Redirect("ListMenu.aspx?SRoleID=" + id);
    }

    /// <summary>
    /// 修改角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton link = sender as LinkButton;
        int id = Convert.ToInt32(link.CommandArgument.ToString());
        Response.Redirect("InsertRoleTab.aspx?SRoleID=" + id);
    }
    /// <summary>
    /// 放入组表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void butZu_Click(object sender, EventArgs e)
    {
        //string id = "";
        //for (int i = 0; i < this.GridRoleTab.Rows.Count; i++)
        //{
        //    CheckBox box = this.GridRoleTab.Rows[i].FindControl("chk") as CheckBox;
        //    if (box.Checked == true)
        //    {
        //        id += this.GridRoleTab.DataKeys[i].Value.ToString()+",";
        //    }
        //}
        //if (id.Length != 0)
        //{
        //    id = id.Substring(0, id.LastIndexOf(","));
        //}
       // Response.Redirect("GetGroupTab.aspx?SrID=" + id);
        Response.Redirect("viewGroup.aspx");

    }


    protected void GridRoleTab_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#f5f5f5'";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor=''";
        }
    }
}
