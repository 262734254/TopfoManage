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
using Tz888.BLL.Company;

public partial class Company_SelCompanyShow : System.Web.UI.Page
{
    Tz888.BLL.Company.KeyWordsBll KeyBll = new Tz888.BLL.Company.KeyWordsBll();
    Tz888.Model.Company.KeyWords KeyModel = new Tz888.Model.Company.KeyWords();

    Tz888.BLL.Company.CompanyShowBLL pany = new Tz888.BLL.Company.CompanyShowBLL();
    Tz888.Model.Company.CompanyShow com = new Tz888.Model.Company.CompanyShow();
    Tz888.BLL.Company.CompanyStateBLL comState = new Tz888.BLL.Company.CompanyStateBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "";
            dataBind();
            if (Convert.ToInt32(Request["CompanyId"]) != 0)
            {
                int id = Convert.ToInt32(Request["CompanyId"]);
                DelCompanyShow(id);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["userName"]))
            {
                ResourceStatic sta = new ResourceStatic();
                //生成资源联盟  子表
                KeyModel = KeyBll.GetModel(1, Request.QueryString["userName"].ToString().Trim());
                sta.StaticHtml(Request.QueryString["userName"].ToString(),KeyModel.WebTitle,KeyModel.WebKeyWord,KeyModel.description);
                Tz888.Common.MessageBox.Show(this.Page, "生成成功");
                dataBind();
            }
        }
    }

    private void DelCompanyShow(int id)
    {
        int num = pany.DeleteShow(id);
        if (num != 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败");
        }
        dataBind();
    }
    protected string GetRoleId(int roleID)
    {
        if (roleID == 1)
        {
            return "招商拓富通";
        }
        if (roleID == 3)
        {
            return "资源联盟";
        }
        if (roleID == 4)
        {
            return "融资拓富通";
        }
        if (roleID == 5)
        {
            return "投资拓富通";
        }
        if (roleID == 6)
        {
            return "专业服务拓富通";
        }
        else
        {
            return "";
        }
    }
    #region 绑定
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
        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 20;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        DataTable dt = pany.GetListT("CompanyShow", "CompanyID", "*", strCriteria, "StartTime desc", ref CurrentPage, PageNum, ref TotalCount);
        if (dt != null)
        {
            this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
            this.Repeater1.DataSource = dt.DefaultView;

            this.Repeater1.DataBind();

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
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind();
    }
    #endregion
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        com = pany.SelAllShow(Convert.ToInt32(Id));
        int num = 0;
        if (com.RoleId != 1)
        {
            KeyModel = KeyBll.GetModel(com.RoleId, com.UserName.ToString().Trim());
            if (KeyModel != null)
            {
                ResourceStatic sta = new ResourceStatic();
                sta.StaticHtml(com.UserName.ToString(), KeyModel.WebTitle, KeyModel.WebKeyWord, KeyModel.description);
                num = 1;
            }
        }
        else
        {
            num = comState.MerchantStatic(com.UserName);
        }
        if (num == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
        }

    }
    protected string AuditName(int audit)
    {
        string num = "";
        switch (audit)
        {
            case 0:
                num = "未审核";
                break;
            case 1:
                num = "审核通过";
                break;
            case 2:
                num = "审核未通过";
                break;
        }
        return num;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        string name = "";
        string names = "";
        bool flag = false;
        if (this.txtBeginTime.Value != "")
        {
            flag = true;
            name += " starttime>='" + this.txtBeginTime.Value + "' ";
        }

        if (name != "" && this.txtEndTime.Value != "")
        {
            flag = true;
            name += " and starttime<='" + this.txtEndTime.Value + " 23:59:59' ";
        }


        if (this.ddlJs.SelectedValue != "-1")
        {
            names += "RoleId=" + this.ddlJs.SelectedValue + "";
        }
    


        if (this.txtLoginName.Value != "")
        {
            names += " UserName like '%" + this.txtLoginName.Value + "%'";
        }
        if (this.txtCompanyName.Value != "")
        {
            if (this.ddlStatus.SelectedValue != "-1")
            {
                names += " TypeName like '%" + this.txtCompanyName.Value + "%' and Audit=" + this.ddlStatus.SelectedValue + "";
            }
            else
            {
                names += " TypeName like '%" + this.txtCompanyName.Value + "%'";
            }
        }
        else
        {
            if (this.ddlStatus.SelectedValue != "-1")
            {
                names += " and  Audit=" + this.ddlStatus.SelectedValue + " ";
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
    //protected void btnSel_Click(object sender, EventArgs e)
    //{
    //    string[] values = Request.Form.GetValues("cbxSelect");
    //    if (values == null)
    //    {
    //        return;
    //    }
    //    StringBuilder sb = new StringBuilder();
    //    foreach (string str in values)
    //    {
    //        com = pany.SelAllShow(Convert.ToInt32(str));
    //        if (com.Audit != 1)
    //        {
    //            sb.Append("用户名:" + com.UserName + " 所对应的状态为:" + AuditName(Convert.ToInt32(com.Audit)) + " ，生成静态化页面失败\\n");
    //        }
    //        else
    //        {
    //            if (com.RoleId == 1)
    //            {
    //                comState.CompanyShowHtml(com.UserName);
    //            }

    //        }
    //    }
    //    if (sb.ToString() != "")
    //    {
    //        Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
    //    }
    //    else
    //    {
    //        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
    //    }
    //}
    //protected void btnAll_Click(object sender, EventArgs e)
    //{
    //    string[] values = pany.SelCompanyID().Split(',');
    //    StringBuilder sb = new StringBuilder();
    //    for (int i = 0; i < values.Length - 1; i++)
    //    {
    //        com = pany.SelAllShow(Convert.ToInt32(values[i]));
    //        if (com.Audit != 1)
    //        {
    //            sb.Append("用户名:" + com.UserName + " 所对应的状态为:" + AuditName(Convert.ToInt32(com.Audit)) + " ，生成静态化页面失败\\n");
    //        }
    //        else
    //        {
    //            if (com.RoleId == 1)
    //            {
    //                comState.CompanyShowHtml(com.UserName);
    //            }
    //        }
    //    }

    //    if (sb.ToString() != "")
    //    {
    //        Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
    //    }
    //    else
    //    {
    //        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
    //    }
    //}
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ListItemType objItemType = e.Item.ItemType;

        if (objItemType == ListItemType.Item || objItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvData = (DataRowView)e.Item.DataItem;
            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
            string str = "";
            if (Convert.ToInt32(drvData["Audit"]) == 1)
            {
                if (Convert.ToInt32(drvData["RoleId"]) == 1)
                {
                    str = "<a href='http://" + drvData["UserName"].ToString() + ".topfo.com/\' target='_blank'>" + drvData["UserName"].ToString() + "</a>";
                }
                if (Convert.ToInt32(drvData["RoleId"]) == 3)
                {
                    str = "<a href='http://lm" + drvData["UserName"].ToString() + ".topfo.com/' target='_blank'>" + drvData["UserName"].ToString() + "</a>";
                }
                if (Convert.ToInt32(drvData["RoleId"]) == 4)
                {
                    str = "<a href='http://rz" + drvData["UserName"].ToString() + ".topfo.com/' target='_blank'>" + drvData["UserName"].ToString() + "</a>";
                }
                if (Convert.ToInt32(drvData["RoleId"]) ==5)
                {
                    str = "<a href='http://tz" + drvData["UserName"].ToString() + ".topfo.com/' target='_blank'>" + drvData["UserName"].ToString() + "</a>";
                }
                if (Convert.ToInt32(drvData["RoleId"]) == 6)
                {
                    str = "<a href='http://zf" + drvData["UserName"].ToString() + ".topfo.com/' target='_blank'>" + drvData["UserName"].ToString() + "</a>";
                }


            }
            else
            {
                str = "<a href='http://www.topfo.com/\' target='_blank'>" + drvData["UserName"].ToString() + "</a>";
            }
            hlTitle.Text = str;
            hlTitle.ToolTip = drvData["UserName"].ToString();
        }
    }

    protected string DateTime(string time)
    {
        string na = "";
        if (time != "")
        {
            DateTime dt = Convert.ToDateTime(time);
            na = dt.ToString("yyyy-MM-dd HH:mm");
        }
        return na;
    }
    //protected void btnRes_Click(object sender, EventArgs e)
    //{
    //    string[] values = Request.Form.GetValues("cbxSelect");
    //    if (values == null)
    //    {
    //        Tz888.Common.MessageBox.Show(this.Page, "请选择要恢复的数据");
    //        return;
    //    }
    //    StringBuilder sb = new StringBuilder();
    //    foreach (string str in values)
    //    {
    //        com = pany.SelAllShow(Convert.ToInt32(str));
    //        if (com.Audit == 1)
    //        {
    //            //sb.Append(com.UserName + ",");
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " shows('"+com.UserName+"');", true);
    //        }
    //    }
    //    //namevalue.Value = sb.ToString();
    //   // Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " show();", true);
    //}
}
