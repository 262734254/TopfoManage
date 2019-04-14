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

public partial class System_AddMenu : BasePage
{
    Tz888.Model.Sys.SysMenuTab model = new Tz888.Model.Sys.SysMenuTab();
    Tz888.BLL.Sys.SysMenuTab bll = new Tz888.BLL.Sys.SysMenuTab();
    bool a = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["parentCode"] != "" && Request.QueryString["parentCode"] != null)
            {
                int code = Convert.ToInt32(Request.QueryString["parentCode"].ToString());
                ViewState["code"] = code;
            }
            if (Request.QueryString["ji"] != null && Request.QueryString["ji"] != "")
            {
                switch (Request.QueryString["ji"].ToString())
                {
                    case "1":
                        lbmenu.Text = "添加一级菜单";
                        break;
                    case "2":
                        lbmenu.Text = "添加二级菜单";
                        break;
                    case "3":
                        lbmenu.Text = "添加三级菜单";
                        break;
                    case "4":
                        lbmenu.Text = "添加四级菜单";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                lbmenu.Text = "添加一级菜单";
            }
            if (Request.UrlReferrer != null)
            {
                ViewState["returnUrl"] = Request.UrlReferrer.ToString();
            }
            else
            {
                ViewState["returnUrl"] = "MenuList1.aspx";
            }
        }
          
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        model.SName = txtMuneName.Text.Trim();
        model.Surl = txtUrlAdd.Text.Trim();
        model.Starget = DropDownList1.SelectedValue;
        model.SDate = DateTime.Now;
        model.SCheck = 1;
        model.Sorder = 0;
        model.SCode = "";
        if (ViewState["code"]!=null)
        {
            model.SParentCode = Convert.ToInt32(ViewState["code"].ToString());
            if (model.SParentCode==0) //一级节点
            {
                a = true;
            }
            else
            {
                model.Sparentsid = Convert.ToInt32(ViewState["code"].ToString());
            }
           
           // ViewState["code"] = null;
        }
        else
        {
            model.SParentCode = 0; 
            a = true;
        }
       
        if (Request.QueryString["ji"] != null)
        {
            model.SisActive = Convert.ToInt32(Request.QueryString["ji"].ToString());
        }
        else
        {
            model.SisActive = 1;
        }
        int result = bll.Add(model);
        if (result > 0)
        {
            model.SCode = "M" + result;//改变model.SCode值
            model.sid = result;
            if (a)
            {
                model.Sparentsid = result; //添加一级菜单
            }
            if (bll.Update(model))
            {
                Response.Write("<script>alert('添加成功');location.href='" + ViewState["returnUrl"].ToString() + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败');location.href='" + ViewState["returnUrl"].ToString() + "';</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('添加失败');location.href='" + ViewState["returnUrl"].ToString() + "';</script>");
        }
    }
}
