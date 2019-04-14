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
using Tz888.BLL.report;
public partial class report_IndustryManage : System.Web.UI.Page
{
    IndustryFromBLL bll = new IndustryFromBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request["str"]) != 0)
            {
                int Id = Convert.ToInt32(Request["str"].ToString());
                DeleteLoansInfoTab(Id);
            }
            if ((bll.GetList("") != null) && bll.GetList("").Tables[0].Rows.Count > 0)
            {
                RfList.DataSource = bll.GetList("");
                RfList.DataBind();
            }

        }
    }
    private void DeleteLoansInfoTab(int Id)
    {
        if (!bll.Delete(Id))
        {
            Response.Write("<script>alert('删除失败');location.href='IndustryManage.aspx'</script>");
        }
        else
        {
            Response.Write("<script>location.href='IndustryManage.aspx'</script>");
        }
    }
}
