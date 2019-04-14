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
using System.Collections.Generic;

public partial class Mail_MailSuperInsert : System.Web.UI.Page
{
    Tz888.BLL.Mail.ProvinceBLL provincebll = new Tz888.BLL.Mail.ProvinceBLL();
    Tz888.BLL.Mail.CityBLL citybll = new Tz888.BLL.Mail.CityBLL();
    Tz888.BLL.Mail.IndustryBLL industrybll = new Tz888.BLL.Mail.IndustryBLL();
    Tz888.BLL.Mail.MailInfoBLL mailinfobll = new Tz888.BLL.Mail.MailInfoBLL();
    Tz888.BLL.Mail.MailTypeBLL mailtypebll = new Tz888.BLL.Mail.MailTypeBLL();
    Tz888.BLL.Mail.MialgroupBLL mialgroupbll = new Tz888.BLL.Mail.MialgroupBLL();
    Tz888.BLL.Mail.PositionBLL positionbll = new Tz888.BLL.Mail.PositionBLL();
    BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindShow();
        }
    }

    private void BindShow()
    {
        this.ddrcity.Visible = false;
        this.ddrprovice.DataSource = provincebll.GetModelList();
        this.ddrprovice.DataValueField = "Id";
        this.ddrprovice.DataTextField = "Name";
        this.ddrprovice.DataBind();
        this.ddrxingye.DataSource = industrybll.GetModelList();
        this.ddrxingye.DataValueField = "Id";
        this.ddrxingye.DataTextField = "Name";
        this.ddrxingye.DataBind();
        ListItem items = new ListItem();
        items.Value = "-1";
        items.Text = "所有行业";
        ddrxingye.Items.Add(items);
        this.ddrxingye.Items.FindByValue("-1").Selected = true;
        this.ddrzhiwei.DataSource = positionbll.GetModelList();
        this.ddrzhiwei.DataValueField = "Id";
        this.ddrzhiwei.DataTextField = "Name";
        this.ddrzhiwei.DataBind();
        this.ddrzu.DataSource = mialgroupbll.GetModelList();
        this.ddrzu.DataValueField = "groupID";
        this.ddrzu.DataTextField = "groupname";
        this.ddrzu.DataBind();
        this.ddrleixing.DataSource = mailtypebll.GetModelList();
        this.ddrleixing.DataValueField = "typeID";
        this.ddrleixing.DataTextField = "TypeName";
        this.ddrleixing.DataBind();
        List<Tz888.Model.Mail.City> list = citybll.GetModelList(Convert.ToInt32(this.ddrprovice.SelectedValue));
        if (list.Count > 0)
        {
            this.ddrcity.Visible = true;
            this.ddrcity.DataSource = list;
            this.ddrcity.DataValueField = "Id";
            this.ddrcity.DataTextField = "Name";
            this.ddrcity.DataBind();
        }
        else { this.ddrcity.Visible = false; }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入用户名！')</script>");
            return;
        }
        if (txtPanyName.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入公司名！')</script>");
            return;
        }
        //if (txtMail.Text.Trim() == "")
        //{
        //    Response.Write("<script>alert('请输入邮件！')</script>");
        //    return;
        //}
        //if (txtUserName.Text.Trim() == "")
        //{
        //    Response.Write("<script>alert('请输入手机！')</script>");
        //    return;
        //}
        Tz888.Model.Mail.MailInfo model = new Tz888.Model.Mail.MailInfo();
        model.LoginName = bp.LoginName;

        model.UserName = txtUserName.Text.Trim();
        model.PanyName = txtPanyName.Text.Trim();
        model.PositionId = Convert.ToInt32(this.ddrzhiwei.SelectedValue);
        model.Address = txtAddress.Text.Trim();
        model.LinkUrl = txtLinkUrl.Text.Trim();
        model.audit = 1;
        model.ProvinceId = Convert.ToInt32(this.ddrprovice.SelectedValue);
        if (this.ddrcity.Visible == true)
        {
            model.CityId = Convert.ToInt32(this.ddrcity.SelectedValue);
        }
        else
        {
            model.CityId = 0;//省级下没有市的话默认为:0 
        }
        model.industry = Convert.ToInt32(this.ddrxingye.SelectedValue);
        model.Mial = txtMail.Text.Trim();
        model.phone = txtTelCountry.Value.Trim() + "-" + txtTelZoneCode.Value.Trim() + "-" + txtTelNumber.Value.Trim();
        model.Mobile = txtMoblie.Text.Trim();
        model.typeID = Convert.ToInt32(this.ddrleixing.SelectedValue);
        model.groupID = Convert.ToInt32(this.ddrzu.SelectedValue);
        model.remark = txtDescript.Text.Trim();
        model.Mdatetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
        int result = 0;
        try
        {
            result = mailinfobll.Add(model);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        if (result > 0)
        {
            Response.Redirect("MailSupervise.aspx");
        }
        else
        {
            Response.Write("<script>alert('录入失败！')</script>");
        }

    }

    protected void ddrprovice_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Tz888.Model.Mail.City> list = citybll.GetModelList(Convert.ToInt32(this.ddrprovice.SelectedValue));
        if (list.Count > 0)
        {
            this.ddrcity.Visible = true;
            this.ddrcity.DataSource = list;
            this.ddrcity.DataValueField = "Id";
            this.ddrcity.DataTextField = "Name";
            this.ddrcity.DataBind();
        }
        else { this.ddrcity.Visible = false; }
    }
}
