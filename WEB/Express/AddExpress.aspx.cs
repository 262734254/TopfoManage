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
using Tz888.Model.Express;
using Tz888.BLL.Express;
public partial class Express_AddExpress : System.Web.UI.Page
{
    ExpressModel model = new ExpressModel();
    ExpressBLL bll = new ExpressBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["expressId"]))
            {
                int expressId = int.Parse(Request.QueryString["expressId"].ToString());
                bindModel(expressId);
                btnUpdate.Visible = true;
                Button1.Visible = false;
            }
            else
            {
                Button1.Visible = true;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["exId"]))
            {
                int expressId = int.Parse(Request.QueryString["exId"].ToString());
                 if (!bll.Delete(expressId))
                 {
                     Response.Write("<script>alert('删除失败！');document.location='ExpressMange.aspx'</script>");
                 }
                 else
                 {
                     Response.Redirect("ExpressMange.aspx");
                 }
            }
        }
    }
    private void bindModel(int id)
    {
        model = bll.GetModel(id);
        txtUrlAdd.Text = model.express;
        if (model.recommend == 0)
        {
            rdoNo.Checked = true;
        }
        else
        {
            rdoYes.Checked = true;
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        model.Expressdata = DateTime.Now;
        model.express = txtUrlAdd.Text.Trim();
        if (rdoYes.Checked)
        {
            model.recommend = 1;
        }
        else
        {
            model.recommend = 0;
        }
        if (bll.Add(model) <= 0)
        {
            Response.Write("<script>alert('发布失败！');document.location='ExpressMange.aspx'</script>");
        }
        else
        {
            Response.Redirect("ExpressMange.aspx");
        }
    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int expressId = int.Parse(Request.QueryString["expressId"].ToString());
         model = bll.GetModel(expressId);
        model.express = txtUrlAdd.Text.Trim();
        if (rdoYes.Checked)
        {
            model.recommend = 1;
        }
        else
        {
            model.recommend = 0;
        }
        if (!bll.Update(model))
        {
            Response.Write("<script>alert('更新失败！');document.location='ExpressMange.aspx'</script>");
        }
        else
        {
            Response.Redirect("ExpressMange.aspx");

        }
    }
}
