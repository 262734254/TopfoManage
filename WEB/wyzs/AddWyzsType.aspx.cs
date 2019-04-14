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
public partial class wyzs_AddWyzsType : System.Web.UI.Page
{
    WyzsType model = new WyzsType();
    WyzsTypeBLL bll = new WyzsTypeBLL();
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
        txtTitle.Text = model.typeName.ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        model.typeName = txtTitle.Text.Trim();
        
        if (bll.Add(model) <= 0)
        {
            Response.Write("<script>alert('添加失败！');document.location='typeManage.aspx'</script>");
        }
        else
        {
            Response.Redirect("typeManage.aspx");
        }
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        model = bll.GetModel(int.Parse(Request.QueryString["id"].ToString()));

        model.typeName = txtTitle.Text.Trim();
       
        if (!bll.Update(model))
        {
            Response.Write("<script>alert('修改失败！');document.location='typeManage.aspx'</script>");

        }
        else
        {
            Response.Redirect("typeManage.aspx");
        }
    }
}
