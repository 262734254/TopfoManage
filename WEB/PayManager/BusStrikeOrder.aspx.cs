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

public partial class PayManager_BusStrikeOrder : System.Web.UI.Page
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
    #region 会员列表
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
        DataTable ds = manager.GetListT("BusStrikeRecTab", "ID", "*", strCriteria, "ChangeTime desc", ref CurrentPage, PageNum, ref TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.NewsList.DataSource = ds.DefaultView;

        this.NewsList.DataBind();
        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;

    }
    #endregion

    public string GetPayType(object str)
    {
        return Tz888.Common.Common.GetPayType(str.ToString());
    }


 
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        MakeCriteria(ref sb);
        ViewState["Criteria"] = sb.ToString();

        GetInfoNews();

    }
    private void MakeCriteria(ref System.Text.StringBuilder Criteria)
    {

        if (sType.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "StrikeType", sType.Value.Trim(), true, true);
        }
        if (!string.IsNullOrEmpty(this.txtBeginTime.Value.ToString().Trim()) && !string.IsNullOrEmpty(this.txtEndTime.Value.Trim()))
        {
            Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "ChangeTime", Convert.ToDateTime(this.txtBeginTime.Value.ToString().Trim()).ToShortDateString(), Convert.ToDateTime(this.txtEndTime.Value.Trim()).AddDays(1).ToShortDateString());
        }
        if (txtStrikeLoginName.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "LoginName=", txtStrikeLoginName.Value.Trim(), true, false);
        }
        if (txtLoginName.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "ChangeBy=", txtLoginName.Value.Trim(), true, false);
        }
        if (Mtype.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "Free", Mtype.Value.Trim(), true, true);
        }

    }
}
