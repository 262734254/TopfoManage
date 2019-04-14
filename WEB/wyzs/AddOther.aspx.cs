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
public partial class wyzs_AddOther : System.Web.UI.Page
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
            } bindDrop();
        }

    }
    private void bindModel(int id)
    {
        model = bll.GetModel(id);
        txtSite.Text = model.htmlurl.ToString();
        txtorder.Text = model.orderid.ToString();
        txtTitle.Text = model.title.Trim();
        ddlTypeName.SelectedValue = model.typeid.ToString();
        ddlPosition.SelectedValue = model.status.Trim();
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
        model.status = ddlPosition.SelectedItem.Value.ToString().Trim();
        model.pageAddress = 4;

        if (bll.Add(model) <= 0)
        {
            Response.Write("<script>alert('添加失败！');document.location='OtherManage.aspx'</script>");
        }
        else
        {
            Response.Redirect("OtherManage.aspx");
        }
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        model = bll.GetModel(int.Parse(Request.QueryString["id"].ToString()));
        model.htmlurl = txtSite.Text.Trim();
        model.orderid = Convert.ToInt32(txtorder.Text.ToString());
        model.title = txtTitle.Text.Trim();
        model.typeid = Convert.ToInt32(ddlTypeName.SelectedValue.ToString());
        model.status = ddlPosition.SelectedItem.Value.ToString().Trim();
        model.pageAddress = 4;
        if (!bll.Update(model))
        {
            Response.Write("<script>alert('修改失败！');document.location='OtherManage.aspx'</script>");

        }
        else
        {
            Response.Redirect("OtherManage.aspx");
        }
    }
    protected void ddlTypeName_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlTypeName.SelectedValue == "9" || ddlTypeName.SelectedItem.Text == "配套服务")
        {
            ddlPosition.Items.Clear();
            ddlPosition.Items.Add(new ListItem("--请选择--", "all"));
            ddlPosition.Items.Add(new ListItem("免费信息", "信息展示"));
        }
        //else if (ddlTypeName.SelectedValue == "8" || ddlTypeName.SelectedItem.Text == "厂房")
        //{
        //    ddlPosition.Items.Remove(new ListItem("首页底部", "首页底部"));
        //    ddlPosition.Items.Remove(new ListItem("物业展示", "物业展示"));
        //}
        else if (ddlTypeName.SelectedValue == "2" || ddlTypeName.SelectedItem.Text == "首页")
        {
            ddlPosition.Items.Clear();
            ddlPosition.Items.Add(new ListItem("--请选择--", "all"));
            ddlPosition.Items.Add(new ListItem("信息展示", "信息展示"));
            ddlPosition.Items.Add(new ListItem("点击排行", "点击排行"));
            //ddlPosition.Items.Add(new ListItem("物业展示", "物业展示"));
            ddlPosition.Items.Add(new ListItem("底部信息一","底部信息"));
            ddlPosition.Items.Add(new ListItem( "底部信息二","首页底部"));
        }
        else
        {
            ddlPosition.Items.Clear();
            ddlPosition.Items.Add(new ListItem("--请选择--", "all"));
            ddlPosition.Items.Add(new ListItem("信息展示", "信息展示"));
            ddlPosition.Items.Add(new ListItem("点击排行", "点击排行"));
            //ddlPosition.Items.Add(new ListItem("物业展示", "物业展示"));
            ddlPosition.Items.Add(new ListItem("底部信息一", "底部信息"));
            //ddlPosition.Items.Add(new ListItem("首页底部", "底部信息二"));
        }
    }
}
