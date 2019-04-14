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
using Tz888.Model.report;
using Tz888.BLL.report;
public partial class report_AddIndustry : System.Web.UI.Page
{
    IndustryFromBLL bll = new IndustryFromBLL();
    IndustryFrom model = new IndustryFrom();
    public string title = "添加合作机构";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["alt"] == "1")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))//修改
                {
                    bindModel(int.Parse(Request.QueryString["id"].ToString()));
                    title = "修改合作机构";
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
        btnSubmit.Attributes.Add("onclick", "return CheckForm();");
    }
    private void bindModel(int id)
    {
        model = bll.GetModel(id);
        txtIndustryName.Text = model.industryName;
        txtLinkMan.Text = model.LinkMan;
        txtPhone.Text = model.phone;
        string tel = model.tel;
        txtAddress.Text = model.address.Trim();
        txtCompany.Text = model.company.Trim();
        txtFax.Text = model.fax.Trim();
        txtEmail.Text = model.email.Trim();
        txtQQ.Text = model.QQ;
        txtMeo.Text = model.meo;
        txtSite.Text = model.site;
        if (!string.IsNullOrEmpty(tel))
        {
            string[] telLen = tel.Split(new char[] { ',' });
            if (telLen.Length == 1)
            {
                txtTel.Text = model.tel;
            }
            else
            {
                txtcontactsTel.Text = telLen[0].ToString();
                txtTel.Text = telLen[1].ToString();
                txttel2.Text = telLen[2].ToString();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        model.industryName = txtIndustryName.Text.Trim();
        model.LinkMan = txtLinkMan.Text.Trim().Trim();
        model.phone = txtPhone.Text.Trim().Trim();
        string tel = string.Empty;
        if (!string.IsNullOrEmpty(txtcontactsTel.Text.Trim()))
        {
            tel = txtcontactsTel.Text.Trim() + ",";
        }
        else
        {
            tel = ",";
        }
        if (!string.IsNullOrEmpty(txtTel.Text.Trim()))
        {
            tel += txtTel.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        if (!string.IsNullOrEmpty(txttel2.Text.Trim()))
        {
            tel += txttel2.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        model.tel = tel;
        model.fax = txtFax.Text.Trim();
        model.email = txtEmail.Text.Trim();
        model.address = txtAddress.Text.Trim();
        model.company = txtCompany.Text.Trim();
        model.QQ = txtQQ.Text.Trim();
        model.meo = txtMeo.Text.Trim();
        model.site = txtSite.Text;
        if (bll.Add(model) <= 0)
        {
            Response.Write("<script>alert('添加失败！');document.location='IndustryManage.aspx'</script>");
        }
        else
        {
            Response.Redirect("IndustryManage.aspx");
        }
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        model = bll.GetModel(int.Parse(Request.QueryString["id"].ToString()));
        model.industryName = txtIndustryName.Text.Trim();
        model.LinkMan = txtLinkMan.Text.Trim().Trim();
        model.phone = txtPhone.Text.Trim().Trim();

        string tel = string.Empty;
        if (!string.IsNullOrEmpty(txtcontactsTel.Text.Trim()))
        {
            tel = txtcontactsTel.Text.Trim() + ",";
        }
        else
        {
            tel = ",";
        }
        if (!string.IsNullOrEmpty(txtTel.Text.Trim()))
        {
            tel += txtTel.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        if (!string.IsNullOrEmpty(txttel2.Text.Trim()))
        {
            tel += txttel2.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        model.tel = tel;
        model.fax = txtFax.Text.Trim();
        model.email = txtEmail.Text.Trim();
        model.address = txtAddress.Text.Trim();
        model.company = txtCompany.Text.Trim();
        model.QQ = txtQQ.Text.Trim();
        model.meo = txtMeo.Text.Trim();
        model.site = txtSite.Text;
        if (!bll.Update(model))
        {
            Response.Write("<script>alert('修改失败！');document.location='IndustryManage.aspx'</script>");

        }
        else
        {
            Response.Redirect("IndustryManage.aspx");
        }
    }
}
