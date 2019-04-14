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

public partial class Mail_MailTypeInsert : System.Web.UI.Page
{
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
    Tz888.BLL.Mail.MailTypeBLL bll = new Tz888.BLL.Mail.MailTypeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.labTitle.Text = "邮件类型录入";
            Id = 0;
            if (Convert.ToInt32(Request["str"]) != 0)
            {
                Id = Convert.ToInt32(Request["str"]);
                BindShow(Id);
            }

        }
    }

    private void BindShow(int Id)
    {
        this.labTitle.Text = "邮件类型审核";
        Tz888.Model.Mail.MailType  model = bll.GetModel(Id);
        txtName.Text = model.TypeName.Trim();
        txtdesctption.Text = model.TypeRemark.Trim();
        showshenhes.Attributes.Add("style", "display:block");
        this.radiocaozuo.Items.FindByValue(model.Audit.ToString().Trim()).Selected = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Id == 0)
        {
            Tz888.Model.Mail.MailType model = new Tz888.Model.Mail.MailType();
            if (txtName.Text.Trim() == "")
            {
                Response.Write("<script>alert('请输入类型名称！')</script>");
                return;
            }
            model.TypeName = txtName.Text.Trim();
            model.TypeRemark = txtdesctption.Text.Trim();
            model.Audit =1;
            int result = bll.Add(model);
            if (result > 0)
            {
                Response.Redirect("MailTypeManage.aspx");
            }
            else { Response.Write("<script>alert('已经存在该邮件类型！')</script>"); }
        }
        else
        {
            Tz888.Model.Mail.MailType model = new Tz888.Model.Mail.MailType();
            if (txtName.Text.Trim() == "")
            {
                Response.Write("<script>alert('请输入类型名称！')</script>");
                return;
            }
            model.TypeName = txtName.Text.Trim();
            model.TypeRemark = txtdesctption.Text.Trim();
            model.Audit = Convert.ToInt32(this.radiocaozuo.SelectedValue);
            model.typeID = Id;
            int result = bll.Update(model);
            if (result > 0)
            {
                Response.Redirect("MailTypeManage.aspx");
            }
            else { Response.Write("<script>alert('已经存在该类型名称,请重命名类型名称！')</script>"); }
        }
    }

}
