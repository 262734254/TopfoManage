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
public partial class Advertorial_IndustryManage : System.Web.UI.Page
{
    Tz888.Model.Advertorial.IndustryTypeModel model = new Tz888.Model.Advertorial.IndustryTypeModel();
    IndustryType bll = new IndustryType();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        databind();
    }
    private void databind()
    {
        //int classID = 0;
       
        DataSet ds = bll.GetList(" classID=0");//第一级菜单
        foreach (DataRow dr in bll.GetList(" classID=0").Tables[0].Rows)
        {
            ViewState["parentCode"] = dr["classID"].ToString();
            break;
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
        if (ViewState["parentCode"]!=null)
        {
            Response.Redirect("AddIndustry.aspx?parentCode=" + Convert.ToInt32(ViewState["parentCode"].ToString()) + "&ji=1");
        }
        else
        {
            Response.Redirect("AddIndustry.aspx");
        }
       
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
}
