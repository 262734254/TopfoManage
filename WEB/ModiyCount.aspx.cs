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

public partial class ModiyCount : System.Web.UI.Page
{
    Tz888.BLL.LogBLL bll = new Tz888.BLL.LogBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string InfoID = "0";
            try
            {
                if (Request.QueryString["infoid"] != "" && Request.QueryString["infoid"] != null)
                {
                    InfoID = Request.QueryString["infoid"].ToString().Trim();

                    bll.Update(InfoID);
                }
                else
                {

                }
            }
            catch
            {

            }

        }
    }
}
