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

public partial class db_UserList : System.Web.UI.Page
{

     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["tem"] != null)
            {
                ViewState["tem"] = Request.QueryString["tem"].ToString();
            }
            dataBind("");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("role.aspx");
    }

    //查询
    protected void Search_Click(object sender, EventArgs e)
    {
        string UserNaem = txtUserName.Text.Trim();
        dataBind(UserNaem);
        txtUserName.Text = "";
    }

     /// <summary>
    /// 绑定
    /// </summary>
    protected void dataBind(string Where)
    {
        if (ViewState["tem"] != null)
        {
            string userType = ViewState["tem"].ToString();
            if (Where != "")
            {
                Where = "Tem=" + userType + " and userName='" + Where + "'";
            }
            else
            {
                Where = "Tem=" + userType;
            }

            long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
            int PageNum = 20;
            long TotalCount = 1;
            long PageCount = 1;
            AspNetPager1.PageSize = PageNum;
            Tz888.BLL.Company.CompanyShowBLL pany = new Tz888.BLL.Company.CompanyShowBLL();
            DataTable dt = pany.GetListT("userListView", "userName", "userName,TypeName,Mobile,Email,StartTime", Where, "StartTime desc", ref CurrentPage, PageNum, ref TotalCount);
            if (dt != null)
            {
                this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
                this.GridView1.DataSource = dt.DefaultView;
                this.GridView1.DataBind();
                if (TotalCount % PageNum > 0)
                    PageCount = TotalCount / PageNum + 1;
                else
                    PageCount = TotalCount / PageNum;
                this.pinfo.InnerText = Convert.ToString(TotalCount);
            }
        }
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind("");
    }
}
