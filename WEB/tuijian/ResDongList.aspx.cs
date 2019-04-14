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

public partial class tuijian_ResDongList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
            Bind();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Bind()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("RecommendedResources", "*", "ResourceID", 100, 1, 0, 1, "");

        this.ResDongList.DataSource = dt;
        this.ResDongList.DataBind();
    }

    protected void ResDongList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ResDongList.PageIndex = e.NewPageIndex;

        Bind();
    }

    protected void ResDongList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#f5f5f5'";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor=''";
        }
    }
    /// <summary>
    /// 开启列表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void LinkCheck_Click(object sender, EventArgs e)
    //{
    // LinkButton link = sender as LinkButton;
    // int id = Convert.ToInt16(link.CommandArgument.ToString());
    // //Response.Redirect("CheckGroup.aspx?SGID=" + id);

    //    //Response.Write("<script>alert(" + id + ")</script>");
    //    //Tz888.SQLServerDAL.Sys.SysGroupTab CheckDAL = new Tz888.SQLServerDAL.Sys.SysGroupTab();
    //    //CheckDAL.Check(id);
    //    //GetRoleTable();

    //}
    /// <summary>
    /// 删除

    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkDelete_Click(object sender, EventArgs e)
    {
        LinkButton link = sender as LinkButton;
        int SGID = Convert.ToInt32(link.CommandArgument.ToString());
        // Response.Redirect("DelGroup.aspx?SGID=" + SGID);
        //Tz888.SQLServerDAL.Common.MemberDAL MemDAL = new Tz888.SQLServerDAL.Common.MemberDAL();
        //MemDAL.DelMember(id);

        //Tz888.Common.MessageBox.Show(this.Page, "删除成功！");
        string sqlstring = "delete from RecommendedResources where ResourceID=" + SGID;
        if (Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlstring) > 0)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "message", "<script language='javascript' defer>alert('成功');</script>");

            Bind();
        }
        else
        {
        }
    }
}
