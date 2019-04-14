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
using Tz888.Common;
using System.Data.SqlClient;

public partial class productType_ModfiyProductType : System.Web.UI.Page
{
    Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ProductId"] != null)
            {
                if (Text.IsInt(Request.QueryString["ProductId"]))
                {
                    string ProductId = Request.QueryString["ProductId"];
                    InitData(ProductId);
                }
                else
                {
                    MessageBox.ShowAndHref("参数错误!", "ProductTypeManage.aspx");
                }
            }
        }
    }

    public void InitData(string ProductId)
    {
        string sql = "select productName,orderId from productType where productTypeid=@ProductId";
        SqlParameter[] Paras = new SqlParameter[] { 
           new SqlParameter("@ProductId",SqlDbType.Int)
        };
        Paras[0].Value = ProductId;
        DataSet ds = crm.Querys(sql, Paras);
        if (ds != null && ds.Tables.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtTypeName.Value = row["productName"].ToString();
                txtOrder.Value = row["orderId"].ToString();
            }
        }
    }

    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        string ProductId = Request.QueryString["ProductId"];
        string TypeName = txtTypeName.Value.Trim();
        int Order = Convert.ToInt32(txtOrder.Value.Trim());
        string sql = "update productType set productName=@productName,orderId=@orderId where productTypeid=@productTypeid";

        Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
        SqlParameter[] Paras = new SqlParameter[] 
        { 
           new SqlParameter("@productName",SqlDbType.VarChar,50),
           new SqlParameter("@orderId",SqlDbType.Int),
           new SqlParameter("@productTypeid",SqlDbType.Int),
        };

        Paras[0].Value = TypeName;
        Paras[1].Value = Order;
        Paras[2].Value = ProductId;
        int result = crm.ExecuteSqls(sql, Paras);
        if (result > 0)
            Tz888.Common.MessageBox.ShowAndHref("修改成功!", "ProductTypeManage.aspx");
        else
            Tz888.Common.MessageBox.Show(this.Page, "修改失败!");
    }
}
