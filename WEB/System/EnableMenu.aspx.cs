using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_EnableMenu : BasePage
{
    Tz888.BLL.Sys.SysMenuTab bll = new Tz888.BLL.Sys.SysMenuTab();
    Tz888.Model.Sys.SysMenuTab model = new Tz888.Model.Sys.SysMenuTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {
                ViewState["url"] = Request.UrlReferrer.ToString();
            }
            else
            {
                ViewState["url"] = "MenuList1.aspx";
            }
            if (Request.QueryString["sid"] != "" && Request.QueryString["sid"]!=null)
            {
                int sid = Convert.ToInt32(Request.QueryString["sid"].ToString());
                model = bll.GetModel(sid);
                if (model.SCheck==1)
                {
                    model.SCheck = 0;
                }
                else
                {
                    model.SCheck = 1;
                }
               
                bll.Update(model);
                Response.Redirect(ViewState["url"].ToString());
            }
        }

    }
}
