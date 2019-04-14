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
public partial class Advertorial_IndustryManage1 : System.Web.UI.Page
{
    Tz888.Model.Advertorial.IndustryTypeModel model = new Tz888.Model.Advertorial.IndustryTypeModel();
    IndustryType bll = new IndustryType();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["sid"] != null && Request.QueryString["sid"] != "")
            {
                int sid = int.Parse(Request.QueryString["sid"].ToString());
                ViewState["sid"] = sid;
                databind();
            }
        }
    }
    private void databind()
    {
        int SParentCode = int.Parse(Request.QueryString["sid"].ToString());
        DataSet ds = bll.GetList(" classID=" + SParentCode);//第一级菜单

        foreach (DataRow dr in bll.GetList(" classID=" + SParentCode).Tables[0].Rows)
        {
            ViewState["parentCode"] = dr["classID"].ToString();
            break;
        }
        if (ViewState["parentCode"] == null)
        {
            ViewState["parentCode"] = SParentCode;
        }
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#f5f5f5'";  //#b1bfee
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor=''";
        }
    }
    //添加
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddIndustry.aspx?parentCode=" + Convert.ToInt32(ViewState["parentCode"].ToString()) + "&ji=2");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    public string GetStatu(int checkId)
    {
        //int id = int.Parse(checkId.ToString());
        string str = string.Empty;
        if (checkId == 0)
        {
            str = "关闭";
        }
        else
        {
            str = "启动";
        }
        return str;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("IndustryManage.aspx");
    }
}
