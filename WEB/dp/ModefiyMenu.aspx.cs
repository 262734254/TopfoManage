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

public partial class dp_ModefiyMenu : System.Web.UI.Page//BasePage
{
    Tz888.BLL.dp.SysMenuTab bll = new Tz888.BLL.dp.SysMenuTab();
    Tz888.Model.dp.SysMenuTab model = new Tz888.Model.dp.SysMenuTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["sid"]!=null && Request.QueryString["sid"]!="")
            {
                int sid =Convert.ToInt32(Request.QueryString["sid"].ToString());
                model = bll.GetModel(sid);
                txtMuneName.Text = model.SName;
                txtUrlAdd.Text = model.Surl;
                txtOrder.Text =model.Sorder.ToString();
                DropDownList1.SelectedValue = model.Starget;
            }
            if (Request.UrlReferrer!=null)
            {
                ViewState["returnUrl"] = Request.UrlReferrer.ToString();
            }
            else
            {
                ViewState["returnUrl"] = "MenuList1.aspx";
            }
            if (Request.QueryString["ji"] != null && Request.QueryString["ji"] != "")
            {
                switch (Request.QueryString["ji"].ToString())
                {
                    case "1":
                        lbmenu.Text = "修改一级菜单";
                        break;
                    case "2":
                        lbmenu.Text = "修改二级菜单";
                        break;
                    case "3":
                        lbmenu.Text = "修改三级菜单";
                        break;
                    case "4":
                        lbmenu.Text = "修改四级菜单";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                lbmenu.Text = "修改一级菜单";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int sid = Convert.ToInt32(Request.QueryString["sid"].ToString());
        model = bll.GetModel(sid);
        model.SName = txtMuneName.Text.Trim();
        model.Surl = txtUrlAdd.Text.Trim();
        try
        {
            model.Sorder = int.Parse(txtOrder.Text.Trim());
        }
        catch (Exception)
        {

            Response.Write("<script>alert('请输入数字')</script>");
            return;
        }
        
        model.Starget = DropDownList1.SelectedValue.Trim();
        if (bll.Update(model))
        {
            Response.Write("<script>alert('更新成功');location.href='" + ViewState["returnUrl"].ToString() + "';</script>");
            //Response.Redirect(ViewState["returnUrl"].ToString());   
        }
        else
        {
            Response.Write("<script>alert('更新失败');location.href='" + ViewState["returnUrl"].ToString() + "';</script>");
        }
    }
}
