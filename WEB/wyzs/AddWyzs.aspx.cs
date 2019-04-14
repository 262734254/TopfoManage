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
public partial class wyzs_AddWyzs : System.Web.UI.Page
{
    WyzsModel model = new WyzsModel();
    WyzsTabBLL bll = new WyzsTabBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(1);", true);
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(0);", true);
                btnSubmit.Visible = true;
                btnAudit.Visible = false;

            }
        }
        bindDrop();

    }
    private void bindModel(int id)
    {
        model = bll.GetModel(id);
        if (model.pageAddress == 0)//频道
        {
            rdochannel.Checked = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(0);", true);
        }
        else//配套服务  1
        {
            rdoService.Checked = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(1);", true);
        }
        txtSite.Text = model.htmlurl.ToString();
        txtorder.Text = model.orderid.ToString();
        txtTitle.Text = model.title.Trim();
        ddlTypeName.SelectedValue = model.typeid.ToString();
        txtType.Text = model.type.Trim();
    }
    private void bindDrop()
    {
        WyzsTypeBLL blls = new WyzsTypeBLL();
        ddlTypeName.DataSource = blls.GetList("");
        ddlTypeName.DataValueField = "ID";
        ddlTypeName.DataTextField = "typeName";
        ddlTypeName.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        model.htmlurl = txtSite.Text.Trim();
        model.orderid = Convert.ToInt32(txtorder.Text.ToString());
        model.title = txtTitle.Text.Trim();
        model.typeid = Convert.ToInt32(ddlTypeName.SelectedValue.ToString());
        model.type = txtType.Text.Trim();
        model.pageAddress = rdochannel.Checked == true ? 0 : 1;
        
        if (bll.Add(model) <= 0)
        {
            Response.Write("<script>alert('添加失败！');document.location='WyzsManage.aspx'</script>");
        }
        else
        {
            Response.Redirect("WyzsManage.aspx");
        }
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        model = bll.GetModel(int.Parse(Request.QueryString["id"].ToString()));
        model.htmlurl = txtSite.Text.Trim();
        model.orderid = Convert.ToInt32(txtorder.Text.ToString());
        model.title = txtTitle.Text.Trim();
        model.typeid = Convert.ToInt32(ddlTypeName.SelectedValue.ToString());
        model.type = txtType.Text.Trim();
        model.pageAddress = rdochannel.Checked == true ? 0 : 1;
        if (!bll.Update(model))
        {
            Response.Write("<script>alert('修改失败！');document.location='WyzsManage.aspx'</script>");

        }
        else
        {
            Response.Redirect("WyzsManage.aspx");
        }
    }
    
}
