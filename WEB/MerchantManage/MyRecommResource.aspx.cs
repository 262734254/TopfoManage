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
using System.Text;
using System.IO;
using System.Net;
public partial class MerchantManage_MyRecommResource : System.Web.UI.Page
{
    Tz888.BLL.Recomm.recommResourceBLL bll = new Tz888.BLL.Recomm.recommResourceBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.AspNetPager.PageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());

        if (!IsPostBack)
        {
            BasePage bp = new BasePage();
            ViewState["Criteria"] = "RecommName='" + bp.LoginName + "'"; ;  //全部资讯
            this.AspNetPager.CurrentPageIndex = 1;
            this.ViewState["TotalNumCount"] = 1;
            this.ViewState["SortBy"] = "";
            GetInfoNews();
        }
    }

    #region 删除
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="Id"></param>
    private void DeleteNws(int Id)
    {
        if (bll.Delete(Convert.ToInt32(Id)))
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败");
        }

        this.GetInfoNews();
    }
    #endregion

    #region 根据ID删除事件
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {

        int Id = Convert.ToInt32(e.CommandArgument);
        if (bll.Delete(Convert.ToInt32(Id)))
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败");
        }
        this.GetInfoNews();


    }
    #endregion
    #region 查询出信息绑定方法
   
    private void GetInfoNews()
    {
        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        long TotalCount = 0;
        long PageCount = 1;
        Tz888.BLL.Recomm.recommResourceBLL resourceBll = new Tz888.BLL.Recomm.recommResourceBLL();
        //DataTable ds = manager.GetListT("ProfessionalinfoTab", "professionalid", "professionalid,chargeID,titel,typetID,Htmlurl,LoginName,createdate,auditID", strCriteria, "createdate desc", ref CurrentPage, PageNum, ref TotalCount);

        DataTable ds = resourceBll.GetListT("recommResource", "RecommID", "RecommID,ResourceId,ResourceTitle ,ResourceTypeId ,ResourceUrl,RecommName,RecommToUser,RecommDate", strCriteria, "RecommDate desc", ref CurrentPage, PageNum, ref TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.NewsList.DataSource = ds.DefaultView;
        this.NewsList.DataBind();
        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;
    }
    #endregion
    #region 截取字符串的个数
    protected string StrLength(object title)
    {
        string name = "";
        name = title.ToString();
        if (name.Length > 9)
        {
            name = name.Substring(0, 8) + "...";
        }
        return name;
    }
    #endregion
    #region 属于会员绑定
    /// <summary>
    /// 属于会员绑定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void NewsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ListItemType objItemType = e.Item.ItemType;

        if (objItemType == ListItemType.Item ||
            objItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvData = (DataRowView)e.Item.DataItem;
            #region 标题
            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
            string Title = "";
            hlTitle.Text = "<a href='http://www.topfo.com/" + drvData["ResourceUrl"].ToString() + "' target=\"_blank\">" + Tz888.Common.Utility.PageValidate.FixLenth(drvData["ResourceTitle"].ToString(), 37, "...") + Title + "</a>";
            hlTitle.ToolTip = drvData["ResourceTitle"].ToString();

            #endregion

        }
    }
    #endregion
    #region 条件查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //string LoginName = this.txtLoginName.Value.Trim();
        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();

        if (strCriteria.ToString() == "")
        {
            if (this.txtNuber.Value.Trim() != "")   //根据ID
                strCriteria.Append(" RecommID like  '%" + this.txtNuber.Value.Trim() + "%'");
        }
        if (strCriteria.ToString() == "")
        {
            if (this.txtTitle.Value.Trim() != "")   //根据标题
                strCriteria.Append(" ResourceTitle like  '%" + this.txtTitle.Value.Trim() + "%'");
        }
        //if (strCriteria.ToString() == "")
        //{
        //if (this.txtLoginName.Value.ToString().Trim() != "" && ddlStatus.SelectedValue.ToString().Trim() != "5")
        //{
        //    strCriteria.Append("LoginName='" + LoginName + "'");
        //    strCriteria.Append(" and AuditingStatus =" + this.ddlStatus.SelectedValue.ToString().Trim());

        //}
        //else
        //{
        //    if (txtLoginName.Value.ToString().Trim() != "")
        //    {
        //        strCriteria.Append("LoginName='" + LoginName + "'");

        //    }

        //}
        //}

        ViewState["Criteria"] = strCriteria.ToString();
        GetInfoNews();

    }
    #endregion
    #region 批量删除
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");

        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            if (bll.Delete(Convert.ToInt32(str.Trim())))
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除成功");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除失败");
            }
            this.GetInfoNews();
        }

    }
    #endregion
    #region 每页显示多少条
    /// <summary>
    /// 每页显示多少条
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    #endregion
    #region 分页事件
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    #endregion
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MerchantManage.aspx");
    }
}
