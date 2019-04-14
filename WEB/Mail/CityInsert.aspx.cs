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

public partial class Mail_CityInsert : System.Web.UI.Page
{
    Tz888.BLL.Mail.ProvinceBLL bll = new Tz888.BLL.Mail.ProvinceBLL();
    Tz888.BLL.Mail.CityBLL blls = new Tz888.BLL.Mail.CityBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddrProvince.DataSource = bll.GetModelList();
            this.ddrProvince.DataValueField = "Id";
            this.ddrProvince.DataTextField = "Name";
            this.ddrProvince.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.Model.Mail.City model = new Tz888.Model.Mail.City();
        model.Name = txtName.Text.Trim();
        model .provinceId=int.Parse(this.ddrProvince .SelectedValue);
        int result = blls.Add(model);
        if (result > 0)
        {
            Response.Write("<script>alert('录入成功！')</script>");
        }
        else { Response.Write("<script>alert('该省已经存在该市！')</script>"); }

    }
}
