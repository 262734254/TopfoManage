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

public partial class dp_DelRole : System.Web.UI.Page//BasePage
{
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt16(Request.QueryString["id"].ToString());
        //31为超级管理员,不能删除
        if (id != 31)
        {
            Tz888.BLL.dp.SysRoleTab bll = new Tz888.BLL.dp.SysRoleTab();

            bll.Delete(id);
        }
       Response.Redirect("Role.aspx");
        //Tz888.Common.MessageBox.Show(Role.aspx, "删除成功!");
      
    }
}
