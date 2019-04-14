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

public partial class dp_Hander : System.Web.UI.Page
{
    Tz888.Model.dp.SysMenuTab model = new Tz888.Model.dp.SysMenuTab();
    Tz888.BLL.dp.SysMenuTab bll = new Tz888.BLL.dp.SysMenuTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
             if (Request["MuneName"] != null)
            {
                if (bll.ExistsMenuName(Request["MuneName"].ToString()))
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
