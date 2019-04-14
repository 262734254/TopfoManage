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
using Tz888.BLL.Company;
public partial class MerchantManage_Hander : System.Web.UI.Page
{
    CompanyShowBLL comBll = new CompanyShowBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["MuneName"]))
        {
            string name = Request["MuneName"].ToString();
            if (comBll.ExistsName(name))
            {
                Response.Write("true");
                Response.End();
            }
            else
            {
                Response.Write("false");
                Response.End();
            }
            
        }
    }
}
