using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;

public partial class dp_DelMenu : System.Web.UI.Page//BasePage
{
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
            //删除一三级菜单
            if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
            {
                int sid = int.Parse(Request.QueryString["sid"].ToString());
                Tz888.BLL.dp.SysMenuTab bll = new Tz888.BLL.dp.SysMenuTab();
                if (bll.Delete(sid))
                {
                    Response.Redirect(ViewState["url"].ToString());
                }
                else
                {
                    
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "<script>alert('删除失败!');location.href='" + ViewState["url"].ToString() + "';</script>", false);
                    //Response.Write("<script>alert('删除失败');location.href='" + ViewState["url"].ToString() + "';</script>");
                }
            }
            //删除二级菜单
            if (Request.QueryString["sid2"] != null && Request.QueryString["sid2"] != "")
            {
                int sid = int.Parse(Request.QueryString["sid2"].ToString());
                Tz888.BLL.dp.SysMenuTab bll = new Tz888.BLL.dp.SysMenuTab();
                if (bll.Delete1(sid))
                {
                    Response.Redirect(ViewState["url"].ToString());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Msg", "<script>alert('删除失败!');location.href='" + ViewState["url"].ToString() + "';</script>", false);
                }
            }
        }
    }
}
