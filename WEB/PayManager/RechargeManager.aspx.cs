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
using Tz888.BLL.MyHome;
public partial class PayManager_RechargeManager : System.Web.UI.Page
{
    HomeLinkManager manager = new HomeLinkManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.AspNetPager.PageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());

        if (!IsPostBack)
        {

            ViewState["Criteria"] = "";  //全部资讯
            this.AspNetPager.CurrentPageIndex = 1;

            this.ViewState["SortBy"] = "";
            GetInfoNews();

        }
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }

    #region 卡号列表
    /// <summary>
    /// 会员列表
    /// </summary>
    private void GetInfoNews()
    {

        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        long TotalCount = 0;
        long PageCount = 1;
        DataTable ds = manager.GetListT("RechargeCard", "id", "*", strCriteria, " id asc ", ref CurrentPage, PageNum, ref TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.NewsList.DataSource = ds.DefaultView;

        this.NewsList.DataBind();
        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;

    }
    #endregion
 
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        MakeCriteria(ref sb);
        ViewState["Criteria"] = sb.ToString();

        GetInfoNews();
    }


    private void MakeCriteria(ref System.Text.StringBuilder Criteria)
    {

    
        if (txtNumber.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "NumberID=", txtNumber.Value.Trim(), true, false);
        }
        if (sType.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "Free", sType.Value.Trim(), true, true);
        }

    }
}
