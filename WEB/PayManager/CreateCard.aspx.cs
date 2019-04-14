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
public partial class PayManager_CreateCard : System.Web.UI.Page
{
    HomeLinkManager manager = new HomeLinkManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.AspNetPager.PageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());

        
        if (!IsPostBack)
        {

            if (this.Page.Request.QueryString["LoginName"] != null)
            {
                string Name = Request.QueryString["LoginName"].ToString().Trim();
                ViewState["Criteria"] = "LoginName='" + Name + "'";
                GetInfoNews();
            
            }
            else
            {
                ViewState["Criteria"] = "WorthPoint !=0";  //全部资讯
                this.AspNetPager.CurrentPageIndex = 1;

                this.ViewState["SortBy"] = "";
                GetInfoNews();
            }

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
        DataTable ds = manager.GetListT("CreateCardTab", "ID", "*", strCriteria, "ChangeTime desc", ref CurrentPage, PageNum, ref TotalCount);
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
        string LoginName = this.txtLoginName.Value.Trim();
        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();

        if (strCriteria.ToString() == "")
        {
            if (this.txtLoginName.Value.ToString().Trim() != "" )
            {
                strCriteria.Append("LoginName='" + LoginName + "'");
           

            }
       
        }

      

        ViewState["Criteria"] = strCriteria.ToString();
        GetInfoNews();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
}
