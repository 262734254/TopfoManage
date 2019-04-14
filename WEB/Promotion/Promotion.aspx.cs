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

public partial class Promotion_Promotion : System.Web.UI.Page
{
    Tz888.BLL.PromotionInfo.PromotionInfoBLL per = new Tz888.BLL.PromotionInfo.PromotionInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int id =Convert.ToInt32(this.txtId.Value.Trim());
        string name = this.txtName.Value.Trim();
        string remark = this.txtRemark.Value.Trim();
        int num = per.AddPromotion(id,name,remark);
        if (num >= 0)
        {
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功", "SelPromotion.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page,"添加失败");
        }
        
    }
}
