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

public partial class Mail_IndustryManage : System.Web.UI.Page
{
    Tz888.BLL.Mail.IndustryBLL industry = new Tz888.BLL.Mail.IndustryBLL();
    Tz888.Model.Mail.Industry model = new Tz888.Model.Mail.Industry();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    private void Bind()
    {
        this.RfList.DataSource = industry.GetModelRepeater();
        this.RfList.DataBind();
    }
}
