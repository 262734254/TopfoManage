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
using Tz888.BLL.Advertorial;
using Tz888.Model.Advertorial;
public partial class Advertorial_AddIndustry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["parentCode"] != "" && Request.QueryString["parentCode"] != null)
            {
                int code = Convert.ToInt32(Request.QueryString["parentCode"].ToString());
                ViewState["code"] = code;
                classId.Value = code.ToString();
            }
            else
            {
                classId.Value = "0";
            }
            if (Request.QueryString["ji"] != null && Request.QueryString["ji"] != "")
            {
                switch (Request.QueryString["ji"].ToString())
                {
                    case "1":
                        lbmenu.Text = "添加一级行业类型";
                        break;
                    case "2":
                        lbmenu.Text = "添加二级行业类型";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                lbmenu.Text = "添加一级行业类型";
            }
            if (Request.UrlReferrer != null)
            {
                ViewState["returnUrl"] = Request.UrlReferrer.ToString();
            }
            else
            {
                ViewState["returnUrl"] = "IndustryManage.aspx";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tz888.Model.Advertorial.IndustryTypeModel model = new Tz888.Model.Advertorial.IndustryTypeModel();
        IndustryType bll = new IndustryType();
        if (ViewState["code"] != null)
        {
            model.classID =int.Parse(ViewState["code"].ToString());
        }
        else
        {
            model.classID = 0;
        }
        model.industryName = txtMuneName.Text.Trim();
       
        if (rdoClose.Checked)
        {
            model.CheckiD = 0;
        }
        else
        {
            model.CheckiD = 1;
        }
        model.desc = txtUrlAdd.Text.Trim();
        if (bll.Add(model) > 0)
        {
            Response.Write("<script>alert('添加成功');location.href='" + ViewState["returnUrl"].ToString() + "';</script>");

        }
        else
        {
            Response.Write("<script>alert('添加失败');location.href='" + ViewState["returnUrl"].ToString() + "';</script>");
        }

    }
}
