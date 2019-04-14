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
using System.Data.SqlClient;

public partial class productType_ProductTypeManage : System.Web.UI.Page
{
    Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBind();
        }
    }


    public void dataBind()
    {
        string sql = "select * from productType order by orderId Desc";
        DataSet ds = crm.Querys(sql, null);
        RepList.DataSource = ds;
        RepList.DataBind();
    }
}

