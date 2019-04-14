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

public partial class advertise_ExistsLoginName : System.Web.UI.Page
{

    Tz888.BLL.advertise.ADlaunchInfoManager bll = new Tz888.BLL.advertise.ADlaunchInfoManager();
    bool a = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request["MuneName"] != null)
            {
                if (bll.ExistsLoginName(Request["MuneName"].ToString()))
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
}
