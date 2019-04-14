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
using Tz888.BLL.ManageSystem;
public partial class PayManager_LmOrder : System.Web.UI.Page
{
    RoleGroupBLL RoleGroupBll = new RoleGroupBLL(); 
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {

            ViewState["Criteria"] = "";  //全部信息
            dataBind();

        }

    }
    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void dataBind()
    {
        string strCriteria = ViewState["Criteria"].ToString();
        long PageSize = Convert.ToInt64(ViewState["pageSize"]);
        long CurrPage = Convert.ToInt64(AspNetPager.CurrentPageIndex);
        long TotalCount = 0;
        DataTable dt = RoleGroupBll.GetListT("LmOrderTab", "lmorderid", "*", strCriteria, "lmorderid desc", ref CurrPage, 20, ref TotalCount);
        this.NewsList.DataSource = dt;
        AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();
        if (strCriteria.ToString() == "")
        {
            if (this.txtLoginName.Value.Trim() != "")
                strCriteria.Append("buyName  ='" + this.txtLoginName.Value.ToString().Trim() + "'");
        } 
        if (strCriteria.ToString() == "")
        {
            if (this.txtNuber.Value.Trim() != "")
                strCriteria.Append("OrderNo  ='" + this.txtNuber.Value.ToString().Trim() + "'");
        }
        if (strCriteria.ToString() == "")
        {
            if (this.txtTitle.Value.Trim() != "")
                strCriteria.Append("Title  ='" + this.txtTitle.Value.ToString().Trim() + "'");
        }

        ViewState["Criteria"] = strCriteria.ToString();
        dataBind();
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        dataBind();
    }
}
