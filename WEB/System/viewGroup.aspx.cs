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

public partial class System_viewGroup:BasePage
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
       // Tz888.BLL.Sys.SysRoleTab bll = new Tz888.BLL.Sys.SysRoleTab();
        // DataSet dt = bll.GetList("");
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("SysGroupTab", "*", "SGID", 100, 1, 0, 1, "");

        this.GroupGridView.DataSource = dt;
        this.GroupGridView.DataBind();
    }

   

    protected void GroupGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GroupGridView.PageIndex = e.NewPageIndex;
        //GroupGridView.DataBind();
        GetRoleTable();

    }

    /// <summary>
    /// 删除组

    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkDelete_Click(object sender, EventArgs e)
    {


        LinkButton link = sender as LinkButton;
        int SGID= Convert.ToInt32(link.CommandArgument.ToString());

        Response.Redirect("DelGroup.aspx?SGID=" + SGID);

        //Tz888.SQLServerDAL.Common.MemberDAL MemDAL = new Tz888.SQLServerDAL.Common.MemberDAL();
        //MemDAL.DelMember(id);
       
       // Tz888.Common.MessageBox.Show(this.Page, "删除成功！");
        // GetRoleTable();


    }

    /// <summary>
    /// 审核角色
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void LinkCheck_Click(object sender, EventArgs e)
    //{
    //    LinkButton link = sender as LinkButton;
    //    int id = Convert.ToInt16(link.CommandArgument.ToString());
    //    Response.Redirect("CheckGroup.aspx?SGID=" + id);

    //    //Response.Write("<script>alert(" + id + ")</script>");
    //    //Tz888.SQLServerDAL.Sys.SysGroupTab CheckDAL = new Tz888.SQLServerDAL.Sys.SysGroupTab();
    //    //CheckDAL.Check(id);
    //    //GetRoleTable();
        
    //}

    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void LinkUpdate_Click(object sender, EventArgs e)
    //{
    //    LinkButton link = sender as LinkButton;
    //    int id = Convert.ToInt32(link.CommandArgument.ToString());
    //    Response.Redirect("ModifyGroup.aspx?SGID=" + id);
    //}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("InsertGroup.aspx");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void jiaose_Btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Role.aspx");
    }
    protected void GroupGridView_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#f5f5f5'";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor=''";
        }
    }

    /// <summary>
    /// 转换角色
    /// </summary>
    /// <param name="SRoleID"></param>
    /// <returns></returns>
    public static string ReturnJiaose(string RoleID)
    {
        string Role="";
        string[] SRoleID = RoleID.Split(',');
        int len = SRoleID.Length;
        Tz888.SQLServerDAL.Sys.SysRoleTab RoleName = new Tz888.SQLServerDAL.Sys.SysRoleTab();

        for (int i=0; i<len-1;i++)
        {

            Role +=RoleName.GetNameByID(SRoleID[i].ToString())+" ";
        }
        return Role;


    }
}
