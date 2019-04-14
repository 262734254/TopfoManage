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

public partial class LmOrder_PleaseMoneyList : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyShowBLL pany = new Tz888.BLL.Company.CompanyShowBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "";
            dataBind();
            
        }
    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        string name = "";
        string names = "";
        bool flag = false;
        if (this.txtBeginTime.Value != "")
        {
            flag = true;
            name += " CreateTime>='" + this.txtBeginTime.Value + "' ";
        }

        if (name != "" && this.txtEndTime.Value != "")
        {
            flag = true;
            name += " and CreateTime<='" + this.txtEndTime.Value + " 23:59:59' ";
        }

        if (this.txtLoginName.Value != "")
        {
            names += " LoginName like '%" + this.txtLoginName.Value + "%'";
        }
       
        else
        {
            if (this.ddlStatus.SelectedValue != "-1")
            {
                names += " StateID=" + this.ddlStatus.SelectedValue + " ";
            }
            else
            {
                names += "";
            }
        }
        string str = "";
        if (flag)
        {
            str = name + names;
        }
        else
        {
            str = names;
        }
        ViewState["Criteria"] = str;
        dataBind();
    }
    #region 绑定
    protected string getStatu(int com)
    {
        if (com == 0)
        {
            return "审核中";
        }
        if (com == 1)
        {
            return "已结账";
        }
       else
        {
            return "审核未通过";
        }
    }
    /// <summary>
    /// 绑定
    /// </summary>
    protected void dataBind()
    {
        string strCriteria = "";
        if (ViewState["Criteria"].ToString() == "")
        {
            strCriteria = "";
        }
        else
        {
            strCriteria = ViewState["Criteria"].ToString();
        }
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        int PageNum = 20;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager.PageSize = PageNum;
        DataTable dt = pany.GetListT("PleaseMoney", "atmid", "*", strCriteria, "createTime desc", ref CurrentPage, PageNum, ref TotalCount);
        if (dt != null)
        {
            this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
            this.NewsList.DataSource = dt.DefaultView;

            this.NewsList.DataBind();

            if (TotalCount % PageNum > 0)
                PageCount = TotalCount / PageNum + 1;
            else
                PageCount = TotalCount / PageNum;

            this.pinfo.InnerText = Convert.ToString(TotalCount);
        }
    }
    #endregion

    #region 绑定分页
    /// <summary>
    /// 绑定分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        dataBind();
    }
    #endregion
}
