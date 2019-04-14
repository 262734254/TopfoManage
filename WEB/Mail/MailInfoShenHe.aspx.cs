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

public partial class Mail_MailInfoShenHe : System.Web.UI.Page
{
    BasePage bp = new BasePage();
    Tz888.BLL.Mail.ProvinceBLL provincebll = new Tz888.BLL.Mail.ProvinceBLL();
    Tz888.BLL.Mail.CityBLL citybll = new Tz888.BLL.Mail.CityBLL();
    Tz888.BLL.Mail.IndustryBLL industrybll = new Tz888.BLL.Mail.IndustryBLL();
    Tz888.BLL.Mail.MailInfoBLL mailinfobll = new Tz888.BLL.Mail.MailInfoBLL();
    Tz888.BLL.Mail.MailTypeBLL mailtypebll = new Tz888.BLL.Mail.MailTypeBLL();
    Tz888.BLL.Mail.MialgroupBLL mialgroupbll = new Tz888.BLL.Mail.MialgroupBLL();
    Tz888.BLL.Mail.PositionBLL positionbll = new Tz888.BLL.Mail.PositionBLL();
    private int Id
    {
        get
        {
            return (int)ViewState["Id"];
        }
        set
        {
            ViewState["Id"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Id = Convert.ToInt32(Request.QueryString["str"].Trim());
            BindShow();
        }
    }

    private void BindShow()
    {
        Tz888.Model.Mail.MailInfo model = mailinfobll.GetModel(Id);
        this.ddrcity.Visible = false;
        this.ddrprovice.DataSource = provincebll.GetModelList();
        this.ddrprovice.DataValueField = "Id";
        this.ddrprovice.DataTextField = "Name";
        this.ddrprovice.DataBind();
      //  ddrprovice.Items.FindByValue(model.ProvinceId.ToString().Trim()).Selected = true;
        ddrprovice.SelectedValue = model.ProvinceId.ToString().Trim();

        this.ddrxingye.DataSource = industrybll.GetModelList();
        this.ddrxingye.DataValueField = "Id";
        this.ddrxingye.DataTextField = "Name";
        this.ddrxingye.DataBind();
        ListItem items = new ListItem();
        items.Value = "-1";
        items.Text = "所有行业";
        ddrxingye.Items.Add(items);
       // ddrxingye.Items.FindByValue(model.industry.ToString().Trim()).Selected = true;
        ddrxingye.SelectedValue = model.industry.ToString().Trim();

        this.ddrzhiwei.DataSource = positionbll.GetModelList();
        this.ddrzhiwei.DataValueField = "Id";
        this.ddrzhiwei.DataTextField = "Name";
        this.ddrzhiwei.DataBind();
       // ddrzhiwei.Items.FindByValue(model.PositionId.ToString().Trim()).Selected = true;
        ddrzhiwei.SelectedValue = model.PositionId.ToString().Trim();

        this.ddrzu.DataSource = mialgroupbll.GetModelList();
        this.ddrzu.DataValueField = "groupID";
        this.ddrzu.DataTextField = "groupname";
        this.ddrzu.DataBind();
       // ddrzu.Items.FindByValue(model.groupID.ToString().Trim()).Selected = true;
        ddrzu.SelectedValue = model.groupID.ToString().Trim();

        this.ddrleixing.DataSource = mailtypebll.GetModelList();
        this.ddrleixing.DataValueField = "typeID";
        this.ddrleixing.DataTextField = "TypeName";
        this.ddrleixing.DataBind();
       // ddrleixing.Items.FindByValue(model.typeID.ToString().Trim()).Selected = true;
        ddrleixing.SelectedValue = model.typeID.ToString().Trim();

        List<Tz888.Model.Mail.City> list = citybll.GetModelList(Convert.ToInt32(this.ddrprovice.SelectedValue));
        if (list.Count > 0)
        {
            this.ddrcity.Visible = true;
            this.ddrcity.DataSource = list;
            this.ddrcity.DataValueField = "Id";
            this.ddrcity.DataTextField = "Name";
            this.ddrcity.DataBind();
            if (Convert.ToInt32(model.CityId.ToString()) > 0)
            {
               // ddrcity.Items.FindByValue(model.CityId.ToString().Trim()).Selected = true;
                ddrcity.SelectedValue = model.CityId.ToString().Trim();
            }
            else { this.ddrcity.Visible = false; }
        }
        else { this.ddrcity.Visible = false; }
        txtUserName.Text = model.UserName;
        txtPanyName.Text = model.PanyName;
        txtAddress.Text=model.Address;
        txtLinkUrl.Text=model.LinkUrl;
        txtMail.Text=model.Mial;
        txtMoblie.Text=model.Mobile;
        string Phone = model.phone;
        if (Phone.Split('-').Length < 3)
        {
            txtTelNumber.Value = Phone;
        }
        else
        {
            txtTelCountry.Value = (Phone.Split('-')[0] == null) ? "" : Phone.Split('-')[0];
            txtTelZoneCode.Value = (Phone.Split('-')[1] == null) ? "" : Phone.Split('-')[1];
            txtTelNumber.Value = (Phone.Split('-')[2] == null) ? "" : Phone.Split('-')[2];
        }
        txtDescript.Text= model.remark ;
       // this.radioaudit.Items.FindByValue(model.audit.ToString().Trim()).Selected = true;
        radioaudit.SelectedValue = model.audit.ToString().Trim();
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
        model.UserID = Id;
        model.LoginName = bp.LoginName.Trim();
        model.UserName = txtUserName.Text.Trim();
        model.PanyName = txtPanyName.Text.Trim();
        model.PositionId = Convert.ToInt32(this.ddrzhiwei.SelectedValue);
        model.Address = txtAddress.Text.Trim();
        model.LinkUrl = txtLinkUrl.Text.Trim();
        model.audit = Convert .ToInt32 (this.radioaudit .SelectedValue);
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
        model.Mobile = txtMoblie.Text.Trim();
        model.phone = txtTelCountry.Value + "-" + txtTelZoneCode.Value + "-" + txtTelNumber.Value;
        model.typeID = Convert.ToInt32(this.ddrleixing.SelectedValue);
        model.groupID = Convert.ToInt32(this.ddrzu.SelectedValue);
        model.remark = txtDescript.Text.Trim();
        int result = mailinfobll.Update(model);
        if (result > 0)
        {
            Response.Redirect("MailInfoManage.aspx");
        }
        else { Response.Write("<script>alert('修改失败！')</script>"); }
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
