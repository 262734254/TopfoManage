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

public partial class advertise_SelLoginName : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Lg = Request["Login"].ToString().Trim();// "hengtonggu";
        if (!IsPostBack)
        {
            if (Lg == "游客" || Lg=="匿名")
            {
                PaNum.Visible = false;
                PanTishi.Visible = true;
            }
            else
            {
                PaNum.Visible = true;
                PanTishi.Visible = false;
                Login(Lg);
            }
        }
    }

    private void Login(string name)
    {
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
       // Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();
        Tz888.Model.Register.MemberInfoModel model = new Tz888.Model.Register.MemberInfoModel();
      //  model = bll.getContactModel(name);
        model = bll.SelorgContact(name);
        if (model != null)
        {
            // this.lblCompanyName.Text = model.OrganizationName.Trim();
            if (model.Email.ToString() != null || model.Email.ToString() != "")
            {
                this.lblEmial.Text = model.Email.ToString();
            }
            else
            {
                this.lblEmial.Text = "";
            }

            if (model.Mobile.ToString() != null || model.Mobile.ToString() != "")
            {
                this.lblMobile.Text = model.Mobile.ToString();
            }
            else
            {
                this.lblMobile.Text = "";
            }

            if (model.Tel.ToString() != null || model.Tel.ToString() != "")
            {
                this.lblPhone.Text = model.Tel.ToString();
            }
            else
            {
                this.lblPhone.Text = "";
            }

            if (model.Address.ToString() != null || model.Address.ToString() != "")
            {
                this.lblAddress.Text = model.Address.ToString();
            }
            else
            {
                this.lblAddress.Text = "";
            }
            //this.lblLinkMan.Text = model.Name.ToString();
            //this.lblMobile.Text = model.Mobile.ToString();
            //this.lblPhone.Text = model.Tel.ToString();// model.TelStateCode.ToString()+"-"+model.TelNum.ToString();
            //this.lblAddress.Text = model.Address.ToString();
        }
        else
        {
            Response.Write("<script>alert('不存在此详细信息')!;window.location.href='AdvisitInfoList.aspx'</script>");
        }
    }
}
