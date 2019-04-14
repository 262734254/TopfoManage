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

public partial class tuijian_DuiyinList : BasePage
{
    public int ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ID = Convert.ToInt16(Request.QueryString["SGID"].ToString());

        if (!IsPostBack)
        {
            Bind(ID);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Bind(int ID)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("InfoRecommend", "*", "ResourceID", 100, 1, 0, 1, "ResourceID=" + ID);

        this.GridView1.DataSource = dt;
        this.GridView1.DataBind();

    }

    /// <summary>
    /// 资源类型
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string Listtype(string type)
    {
        string Ltype = type.Trim().ToString();
        if (Ltype == "Capital")
        {
            return "资本资源";
        }
        else
        {
            if (Ltype == "Merchant")
            {
                return "招商资源";
            }
            else
            {
                if (Ltype == "Project")
                {
                    return "融资资源";
                }
                else
                {
                    return "全部";
                }
            }
        }
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        Bind(ID);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#f5f5f5'";
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor=''";
        }
    }


    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResDongList.aspx");
    }
}
