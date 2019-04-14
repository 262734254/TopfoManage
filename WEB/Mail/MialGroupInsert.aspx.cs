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

public partial class Mail_MialGroupInsert : System.Web.UI.Page
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
    Tz888.BLL.Mail.MialgroupBLL bll = new Tz888.BLL.Mail.MialgroupBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.labTitle.Text = "邮件组录入";
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
        this.labTitle.Text = "邮件组审核";
        Tz888.Model.Mail.Mialgroup model = bll.GetModel(Id);
        txtName.Text = model.groupname.Trim();
        txtdesctption.Text=model.groupremark.Trim ();
        showshenhes.Attributes.Add("style", "display:block");
        this.radiocaozuo.Items.FindByValue(model .Audit .ToString ().Trim ()).Selected = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Id == 0)
        {
            Tz888.Model.Mail.Mialgroup model = new Tz888.Model.Mail.Mialgroup();
            if (txtName.Text.Trim() == "")
            {
                Response.Write("<script>alert('请输入组名称！')</script>");
                return;
            }
            model.groupname = txtName.Text.Trim();
            model.groupremark = txtdesctption.Text.Trim();
            model.Audit =1;
            int result = bll.Add(model);
            if (result > 0)
            {
                Response.Redirect("MialGroupManage.aspx");
            }
            else { Response.Write("<script>alert('已经存在该组！')</script>"); }
        }
        else 
        {
            Tz888.Model.Mail.Mialgroup model = new Tz888.Model.Mail.Mialgroup();
            if (txtName.Text.Trim() == "")
            {
                Response.Write("<script>alert('请输入组名称！')</script>");
                return;
            }
            model.groupname = txtName.Text.Trim();
            model.groupremark = txtdesctption.Text.Trim();
            model.Audit = Convert.ToInt32(this.radiocaozuo.SelectedValue);
            model.groupID = Id;
            int result = bll.Update(model);
            if (result > 0)
            {
                Response.Redirect("MialGroupManage.aspx");
            }
            else { Response.Write("<script>alert('已经存在该组名称,请重命名组名称！')</script>"); }
        }
    }

}
