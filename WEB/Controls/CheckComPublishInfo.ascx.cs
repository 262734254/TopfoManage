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

public partial class Controls_CheckComPublishInfo : System.Web.UI.UserControl
{
    string _strCriteria = "";

    public string StrCriteria
    {
        get { return _strCriteria; }
        set { _strCriteria = value; }
    }
    string theInfoType = "";
    public string TheInfoType
    {
        get { return theInfoType; }
        set { theInfoType = value; }
    }
    string organizationName = "";
    public string OrganizationName
    {
        get { return organizationName; }
        set { organizationName = value; }
    }
    public string infoTypeID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Visible = false;
            ViewState["CurrPage"] = 1;
            ViewState["infoTypeID"] = this.theInfoType.Trim().ToLower();
        }
    }

    protected string GetValiditeInfo(object time)
    {
        DateTime dt = new DateTime();
        string request = "";
        try
        {
            dt = Convert.ToDateTime(time);
            request = "有效期至:" + dt.ToString("yyyy-MM-dd hh:mm:ss");
        }
        catch
        {
            request = "未设置有效期";
        }
        return request;
    }

    public void CheckConflict()
    {
        this.Visible = false;


        Tz888.BLL.Conn SqlConn = new Tz888.BLL.Conn();
        string tableName = "";
        string selectColumns = "*";
        string keyColumn = "InfoID";
        int pageSize = 10;
        string sort = "InfoID DESC";
        long CurrentPage = Convert.ToInt64(ViewState["CurrPage"]);
        long PageCount = 0;

        if (!string.IsNullOrEmpty(_strCriteria))
            this._strCriteria += " And InfoTypeID = '" + theInfoType + "'";
        else
            this._strCriteria = "InfoTypeID = '" + theInfoType + "'";

        string typename = "";
        switch (this.theInfoType.Trim().ToLower())
        {
            case "capital":
                tableName = "CapitalInfo_VIW";
                typename = "投资";
                break;
            case "merchant":
                tableName = "MerchantInfo_VIW";
                typename = "招商";
                break;
            case "project":
                tableName = "ProjectInfo_VIW";
                typename = "融资";
                break;
            default:
                break;
        }

        DataTable dt = SqlConn.GetList(tableName, keyColumn, selectColumns, _strCriteria, sort, ref CurrentPage, pageSize, ref PageCount);
        lblCount.Text = PageCount.ToString();
        lblCurrPage.Text = CurrentPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(PageCount) / Convert.ToDouble(pageSize)).ToString();
        Pager();
        if (dt != null && dt.Rows.Count > 0)
        {
            this.lbMessage.Text = "[" + organizationName + "]发布的其他" + typename + "信息";
            this.rpCheck.DataSource = dt.DefaultView;
            this.rpCheck.DataBind();
            this.plDisplay.Visible = true;
        }
        else
        {
            this.lbMessage.Text = "<font color='red'>[" + organizationName + "]未发布其他" + typename + "信息！</font>";
            this.plDisplay.Visible = false;
        }
        this.Visible = true;
    }
    #region 翻页
    public void Pager()
    {
        if (ViewState["CurrPage"].ToString() == lblPageCount.Text)
        {
            NextPage.Enabled = false;
            LastPage.Enabled = false;
            if (lblPageCount.Text != "1")
            {
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (Convert.ToInt32(ViewState["CurrPage"]) < Convert.ToInt32(lblPageCount.Text))
        {

            if (lblPageCount.Text != "1")
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (ViewState["CurrPage"].ToString() == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            if (Convert.ToInt32(lblPageCount.Text) > 1)
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
            }
        }
        if (lblCount.Text == "0" || lblCount.Text == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            NextPage.Enabled = false;
            LastPage.Enabled = false;
        }
    }
    protected void FirstPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = 1;
        CheckConflict();
    }
    protected void PerPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) - 1;
        CheckConflict();
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) + 1;
        CheckConflict();
    }
    protected void LastPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = lblPageCount.Text;
        CheckConflict();
    }

    #endregion

    public string GetStatus(object AuditingStatus)
    {
        if (AuditingStatus.ToString().Trim() == "0")
            return "未审核";
        if (AuditingStatus.ToString().Trim() == "1")
            return "审核通过";
        if (AuditingStatus.ToString().Trim() == "2")
            return  "审核未通过";
        else
            return "状态错误";
    }
    protected void rpCheck_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ListItemType objItemType = e.Item.ItemType;

        if (objItemType == ListItemType.Item ||
            objItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvData = (DataRowView)e.Item.DataItem;

            #region 标题
            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlkTitle");
            string InfoOriginRoleName = drvData["InfoOriginRoleName"].ToString().Trim();
            string MemberGradeID = drvData["MemberGradeID"].ToString().Trim();
            string Title = "";
            switch (InfoOriginRoleName)
            {
                case "0":
                    if (MemberGradeID == "1001")
                        Title += "<font color='#FF9933'>[会员]</font>";
                    else if (MemberGradeID == "1002")
                        //Title += "<img src='http://www.topfo.com/Web13/images/home/tfzs.gif' border='0' alt='拓富通会员'></img>";
                        Title += "<font color='#FF3300'>[拓富通]</font>";
                    else
                        Title += "<font color='#FF3300'>[拓富通]</font><font color='#FFDF60'>(试用)</font>";
                    break;
                case "1":
                    Title += "<font color='#FF00CC'>[分站]</font>";
                    break;
                case "2":
                    Title += "<font color='#1A9E0A'>[总站]</font>";
                    break;
                default:
                    break;
            }
            hlTitle.Text = Tz888.Common.Utility.PageValidate.FixLenth(drvData["Title"].ToString(), 37, "...") + Title;
            hlTitle.ToolTip = drvData["Title"].ToString();

            if (drvData["HtmlFile"] != null && !string.IsNullOrEmpty(drvData["HtmlFile"].ToString().Trim()))
                hlTitle.NavigateUrl = Tz888.Common.Common.GetWWWDomain() + @"/" + drvData["HtmlFile"].ToString();
            else
            {
                switch (this.theInfoType.ToLower())
                {
                    case "capital":
                        hlTitle.NavigateUrl = "./CapitalModify.aspx?id=" + drvData["InfoID"].ToString();
                        break;
                    case "merchant":
                        hlTitle.NavigateUrl = "./MerchantModify.aspx?id=" + drvData["InfoID"].ToString();
                        break;
                    case "project":
                        hlTitle.NavigateUrl = "./ProjectModify.aspx?id=" + drvData["InfoID"].ToString();
                        break;
                    default:
                        break;
                }
            }

            hlTitle.Target = "_blank";
            #endregion
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.Visible = false;
    }
}
