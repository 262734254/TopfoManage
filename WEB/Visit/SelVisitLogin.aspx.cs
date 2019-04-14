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

public partial class Visit_SelVisitLogin : Tz888.Common.Pager.BasePage
{
    private int _myPageSize = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ManageType();
            ViewState["Criteria"] = "";
            SetPagerParameters();
        }
    }

    /// <summary>
    /// 绑定分页
    /// </summary>
    private void SetPagerParameters()
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        string str = "";
        if (ViewState["MyPageSize"] != null)
            this._myPageSize = Convert.ToInt32(ViewState["MyPageSize"]);
        else
            ViewState["MyPageSize"] = this._myPageSize;
        str = ViewState["Criteria"].ToString().Trim();
        this.Pager1.PageSize = this._myPageSize;
        this.Pager1.StrWhere = str;
        this.Pager1.TableViewName = "MemberInfoQueryVIW20110224";
        this.Pager1.KeyColumn = "LoginID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "RegisterTime";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    }


    /// <summary>
    /// 翻译类型
    /// </summary>
    private void ManageType()
    {
        Tz888.BLL.Visit.VisitInfoBLL visit = new Tz888.BLL.Visit.VisitInfoBLL();
        this.ddlTypeID.DataSource = visit.SelManageTypeName();
        this.ddlTypeID.DataTextField = "ManageTypeName";
        this.ddlTypeID.DataValueField = "ManageTypeID";
        this.ddlTypeID.DataBind();
        ddlTypeID.Items.Insert(0, new ListItem("请选择 ", ""));

    }

    /// <summary>
    /// 按条件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSel_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        string name = "";
        if (this.txtLoginID.Text != "")
        {
            name += " LoginID='" + this.txtLoginID.Text.Trim() + "' and ";
        }
        if (this.txtLoginName.Text != "")
        {
            name += " LoginName='" + this.txtLoginName.Text.Trim() + "' and ";
        }
        if (this.txtNickName.Text != "")
        {
            name += " NickName='" + this.txtNickName.Text.Trim() + "' and ";
        }
        if (this.ZoneSelectControl1.CountryID != "")
        {
            name += " CountryCode='" + this.ZoneSelectControl1.CountryID.Trim() + "' and ";
        }
        if (this.ZoneSelectControl1.ProvinceID != "")
        {
            name += " ProvinceID='" + this.ZoneSelectControl1.ProvinceID + "' and ";
        }
        if (this.ZoneSelectControl1.CountyID != "")
        {
            name += " CountyID='" + this.ZoneSelectControl1.CountyID + "' and ";
        }
        if (this.ddlTypeID.SelectedValue != "")
        {
            name += " ManageTypeID='" + this.ddlTypeID.SelectedValue.Trim() + "' and ";
        }
        if (this.txtTime.Value != "")
        {
            name += " RegisterTime='" + this.txtTime.Value.Trim() + "' and ";
        }
        ViewState["Criteria"] = name + " 1=1";
        SetPagerParameters();
    }


    protected string Province(int a, string name)
    {
        Tz888.BLL.Visit.VisitInfoBLL visit = new Tz888.BLL.Visit.VisitInfoBLL();
        string com = "";
        int num = visit.SelValidNew(a, name);
        if (a == 1)
        {
            switch (num)
            {
                case 0:
                    com = "无效";
                    break;
                case 1:
                    com = "有效";
                    break;
            }
        }
        else if (a == 2)
        {
            switch (num)
            {
                case 0:
                    com = "未回访";
                    break;
                case 1:
                    com = "已回访";
                    break;
            }
        }
        return com;
    }
}
