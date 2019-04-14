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
using GZS.BLL.Link;
using GZS.Model.Link;
public partial class admin_AddComm : System.Web.UI.Page
{
    CommentBLL comBll = new CommentBLL();
    CommentM comM = new CommentM();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["CommID"]))
            {
                ViewState["CommID"] = Request.QueryString["CommID"].ToString();
            }
            else
            {
                ViewState["CommID"] = "";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        comM.description = txtContent.Text.Trim();
        string name = Request.RawUrl.ToString();
        comM.SendName = ViewState["loginName"].ToString();
        comM.LinkMode=txtOther.Text.Trim();
        comM.LinkName = txtName.Text.Trim();
        if (comBll.Add(comM) > 0)
        {
            comM.description = "";
            comM.SendName = "";
            txtName.Text = "";
            Response.Write("<script>alert('留言成功')</script>");
        }
        else
        {
            Response.Write("<script>alert('留言失败')</script>");
        }
    }
}
