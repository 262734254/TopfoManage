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

public partial class productType_AddProductType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        string sql = "insert into productType(productName,orderId) values(@productName,@orderId)";
        string TypeName = txtTypeName.Value.Trim();
        int Order = Convert.ToInt32(txtOrder.Value.Trim());
        if (string.IsNullOrEmpty(Order.ToString()))
            Order = 0;

        Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
        SqlParameter[] Paras = new SqlParameter[] { 
           new SqlParameter("@productName",SqlDbType.VarChar,50),
           new SqlParameter("@orderId",SqlDbType.Int)
        };

        Paras[0].Value = TypeName;
        Paras[1].Value = Order;
        int result = crm.ExecuteSqls(sql, Paras);
        if (result > 0)
            Tz888.Common.MessageBox.ShowAndHref("添加成功!", "ProductTypeManage.aspx");
        else
            Tz888.Common.MessageBox.Show(this.Page, "添加失败!");
    }
}
