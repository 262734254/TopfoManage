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

public partial class Mail_PositionInsert : System.Web.UI.Page
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
    Tz888.BLL.Mail.PositionBLL bll = new Tz888.BLL.Mail.PositionBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.labTitle.Text = "职位录入";
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
        this.labTitle.Text = "职位审核";
        Tz888.Model.Mail.Position model = bll.GetModel(Id);
        txtName.Text = model.Name.Trim();
        rbtAudit.SelectedValue = model.Audit.ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Id == 0)
        {
            Tz888.Model.Mail.Position model = new Tz888.Model.Mail.Position();
            if (txtName.Text.Trim() == "")
            {
                Response.Write("<script>alert('请输入职位名称！')</script>");
                return;
            }
            model.Name = txtName.Text.Trim();
            model.Audit = Convert.ToInt32(rbtAudit.SelectedValue.Trim());
            int result = bll.Add(model);
            if (result > 0)
            {
                Response.Redirect("PositionManage.aspx");
            }
            else { Response.Write("<script>alert('已经存在该职位！')</script>"); }
        }
        else 
        {
            Tz888.Model.Mail.Position models = new Tz888.Model.Mail.Position();
            models.Id = Id;
            models.Name = txtName.Text.Trim();
            models.Audit = Convert.ToInt32(rbtAudit.SelectedValue.Trim());
            int rs = bll.Update(models);
            if (rs > 0)
            {
                Response.Redirect("PositionManage.aspx");
            }
            else { Response.Write("<script>alert('已经存在该职位！')</script>"); }
        }
    }
}
