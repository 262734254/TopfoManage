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
using Tz888.Model.wyzs;
using Tz888.BLL.wyzs;
public partial class wyzs_AddService : System.Web.UI.Page
{
    WyzsModel model = new WyzsModel();
    WyzsTabBLL bll = new WyzsTabBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["alt"] == "1")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))//修改
                {
                    bindModel(int.Parse(Request.QueryString["id"].ToString()));

                    btnSubmit.Visible = false;
                    btnAudit.Visible = true;
                }
            }
            else
            {
                btnSubmit.Visible = true;
                btnAudit.Visible = false;
            }
        }
    }
    private void bindModel(int id)
    {
        model = bll.GetModel(id);
        txtSite.Text = model.htmlurl.ToString();
        txtorder.Text = model.orderid.ToString();
        txtTitle.Text = model.title.Trim();
        ddlPosition.SelectedValue = model.status.Trim();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        model.htmlurl = txtSite.Text.Trim();
        model.orderid = Convert.ToInt32(txtorder.Text.ToString());
        model.title = txtTitle.Text.Trim();
        model.status = ddlPosition.SelectedItem.Value.ToString().Trim();
        model.pageAddress = 2;

        if (bll.Add(model) <= 0)
        {
            Response.Write("<script>alert('添加失败！');document.location='ServiceManage.aspx'</script>");
        }
        else
        {
            Response.Redirect("ServiceManage.aspx");
        }
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        model = bll.GetModel(int.Parse(Request.QueryString["id"].ToString()));
        model.htmlurl = txtSite.Text.Trim();
        model.orderid = Convert.ToInt32(txtorder.Text.ToString());
        model.title = txtTitle.Text.Trim();
        model.status = ddlPosition.SelectedItem.Value.ToString().Trim();
       // model.pageAddress = 2;
        if (!bll.Update(model))
        {
            Response.Write("<script>alert('修改失败！');document.location='ServiceManage.aspx'</script>");

        }
        else
        {
            Response.Redirect("ServiceManage.aspx");
        }
    }
}
