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
public partial class wyzs_Addcontract : System.Web.UI.Page
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
        txtorder.Text = model.orderid.ToString();
        txtTitle.Text = model.title.Trim();
        txtContent.Value = model.descript;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //model.htmlurl = txtSite.Text.Trim();
        model.orderid = Convert.ToInt32(txtorder.Text.ToString());
        model.title = txtTitle.Text.Trim();
        model.descript = txtContent.Value.ToString();
        model.pageAddress = 3;
        int num = bll.Add(model);
        if (num > 0)
        {
            model.htmlurl = "details_" + num + ".html";
            model.id = num;
            bll.Update(model);
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            gen.GenerateContract(num);
            Response.Redirect("contractManage.aspx");
        }
        else
        {
            Response.Write("<script>alert('添加失败！');document.location='contractManage.aspx'</script>");


        }
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        model = bll.GetModel(int.Parse(Request.QueryString["id"].ToString()));
        model.orderid = Convert.ToInt32(txtorder.Text.ToString());
        model.title = txtTitle.Text.Trim();
        model.descript = txtContent.Value.ToString();
        model.htmlurl = "details_" + model.id.ToString() + ".html";
        //model.pageAddress = rdochannel.Checked == true ? 0 : 1;
        if (!bll.Update(model))
        {
            Response.Write("<script>alert('修改失败！');document.location='contractManage.aspx'</script>");

        }
        else
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            gen.GenerateContract(model.id);
            Response.Redirect("contractManage.aspx");
        }
    }
}
