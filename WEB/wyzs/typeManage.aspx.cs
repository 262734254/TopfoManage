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
using Tz888.Model.wyzs;
using Tz888.BLL.wyzs;

public partial class wyzs_typeManage : System.Web.UI.Page
{
    WyzsType model = new WyzsType();
    WyzsTypeBLL bll = new WyzsTypeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request["str"]) != 0)
            {
                int Id = Convert.ToInt32(Request["str"].ToString());
                DeleteLoansInfoTab(Id);
            }
            DataSet ds = bll.GetAllList();
            if ((ds != null) && ds.Tables[0].Rows.Count > 0)
            {
                RfList.DataSource = ds;
                RfList.DataBind();
            }

        }
    }
    private void DeleteLoansInfoTab(int Id)
    {
        if (!bll.Delete(Id))
        {
            Response.Write("<script>alert('删除失败');location.href='typeManage.aspx'</script>");
        }
        else
        {
            Response.Write("<script>location.href='typeManage.aspx'</script>");
        }
    }
}
