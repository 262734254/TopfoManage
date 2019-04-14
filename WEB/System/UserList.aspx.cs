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

public partial class System_UserList : System.Web.UI.Page
{

     
    protected void Page_Load(object sender, EventArgs e)
    {
        string tem = Request.QueryString["tem"].ToString();
        if (!IsPostBack)
        {
            GetRoleTable(tem);
        }
    }

    /// <summary>
    /// 用户绑定
    /// </summary>
    /// <param name="tem"></param>
    private void GetRoleTable(string tem)
    {
       // Tz888.BLL.Sys.SysRoleTab bll = new Tz888.BLL.Sys.SysRoleTab();
        //DataSet dt = bll.GetList("");
        Tz888.SQLServerDAL.Sys.SysRoleTab SysDAL = new Tz888.SQLServerDAL.Sys.SysRoleTab();
        DataSet dt = SysDAL.GetUserList(tem);

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("role.aspx");
    }
}
