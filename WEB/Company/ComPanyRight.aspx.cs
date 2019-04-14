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

public partial class Company_ComPanyRight : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyStateBLL company = new Tz888.BLL.Company.CompanyStateBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //企业名片会员排行
    protected void btnHit_Click(object sender, EventArgs e)
    {
        company.ComPanyHit();
    }
    //最新加入企业
    protected void btnTime_Click(object sender, EventArgs e)
    {
        company.ComPanyTime();
    }
}
