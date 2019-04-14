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

public partial class Mail_ProvinceInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.BLL.Mail.ProvinceBLL bll = new Tz888.BLL.Mail.ProvinceBLL ();
        Tz888.Model.Mail.Province model = new Tz888.Model.Mail.Province();
        if (txtName.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入省级名称！')</script>");
            return;
        }
        model.Name = txtName.Text.Trim();
        int result = bll.Add(model);
        if (result > 0)
        {
            Response.Write("<script>alert('录入成功！')</script>");
        }
        else { Response.Write("<script>alert('已经存在该省！')</script>"); }

    }
}
