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

public partial class Promotion_SelPromotion : System.Web.UI.Page
{
    Tz888.BLL.PromotionInfo.PromotionInfoBLL pr = new Tz888.BLL.PromotionInfo.PromotionInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.rpLisht.DataSource = pr.SelPromotion();
        this.rpLisht.DataBind();
    }

}
