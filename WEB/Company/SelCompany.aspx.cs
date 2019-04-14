using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
/*
 此页面用于查看所有企业名片信息
 */
public partial class Company_SelCompany : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyBLL pany = new Tz888.BLL.Company.CompanyBLL();
    Tz888.Model.Company.CompanyModel com = new Tz888.Model.Company.CompanyModel();
    Tz888.BLL.Company.CompanyStateManage csbll = new Tz888.BLL.Company.CompanyStateManage();
    Tz888.BLL.Compage comPage= new Tz888.BLL.Compage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "";
            dataBind();
            if (Convert.ToInt32(Request["CompanyId"]) != 0)
            {
                
                int com = Convert.ToInt32(Request["CompanyId"]);
                Del(com);
            }
        }
    }

    #region  删除方法
    private void Del(int id)
    {
        string ComTerm = ConfigurationManager.AppSettings["ComPanyPath"].ToString(); //企业名片模版存放位置
        string num = pany.SelHtmlFile(id);//判断静态模版所对应的路径是否存在 即:htmlfile是否为空
        if (num !="")
        {
            string[] com = num.Split('/');
            string term = ComTerm + "\\" + com[1] + "\\" + com[2];
            comPage.DeleteFile(term);//如果静态模版存在，删除静态模版
        }
        int delte = pany.DelCompany(id);//删除这条数据
        if (delte >= 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功！");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page,"删除失败！");
        }
        dataBind();
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

    #region 绑定
    /// <summary>
    /// 绑定
    /// </summary>
    protected void dataBind()
    {
        string strCriteria = "";
        if (ViewState["Criteria"].ToString() == "")
        {
            strCriteria = ViewState["Criteria"].ToString() + " IsDelete=0 ";//IsDelete=0表示这条数据不删除
        }
        else
        {
            strCriteria = ViewState["Criteria"].ToString() + " and IsDelete=0 ";
        }
        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        int PageNum =20;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        DataTable dt = pany.GetListT("CompanyTab", "CompanyID", "*", strCriteria, "CompanyID desc", ref CurrentPage, PageNum, ref TotalCount);
        if (dt != null)
        {
            this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
            this.Repeater1.DataSource = dt.DefaultView;

            this.Repeater1.DataBind();

            if (TotalCount % PageNum > 0)
                PageCount = TotalCount / PageNum + 1;
            else
                PageCount = TotalCount / PageNum;

            this.pinfo.InnerText = Convert.ToString(TotalCount);//总条数
        }
    }
    #endregion

    #region 条件查询
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        string name = "";

        if (this.txtLoginName.Value != "")
        {
            name += " LoginName='" + this.txtLoginName.Value.Trim() + "' ";
        }
        else
        {
            if (this.txtCompanyName.Value != "")
            {
                if (this.ddlStatus.SelectedValue != "-1")
                {
                    name += " CompanyName like '%" + this.txtCompanyName.Value.Trim() + "%' and AuditingStatus=" + this.ddlStatus.SelectedValue.Trim() + " ";
                }
                else
                {
                    name += " CompanyName like '%" + this.txtCompanyName.Value.Trim() + "%' ";
                }
            }
            else
            {
                if (this.ddlStatus.SelectedValue != "-1")
                {
                    name += " AuditingStatus=" + this.ddlStatus.SelectedValue.Trim() + " ";
                }
            }
        }
        ViewState["Criteria"] = name;
        dataBind();
    }
    #endregion

    #region 翻译审核状态
    protected string SelStatus(string id)
    {
        string name = "";
        switch (id)
        { 
            case "0":
                name = "未审核";
                break;
            case "1":
                name = "审核通过";
                break;
            case "2":
                name = "审核未通过";
                break;
            case "3":
                name = "已过期";
                break;
        }
        return name;
    }
    #endregion

    #region 静态路径
    protected string SelHtmlFile(string file)
    {
        string html = "";
        if (file != "")
        {
            string[] num = file.ToString().Trim().Split('/');
             html = num[1] + "/" + num[2];
        }
        return html;
    }
    #endregion

    #region 截取注册时间
    protected string PublishT(string time)
    {
        DateTime dt = Convert.ToDateTime(time);
        string bet=dt.ToString("yyyy-MM-dd hh:mm");
        return bet;
    }
    #endregion

    #region 翻译是否推荐
    protected string make(int n)
    {
        string num = "";
        switch (n)
        { 
            case 0:
                num = "否";
                break;
            case 1:
                num = "是";
                break;
        }
        return num;
    }
    #endregion

    #region 批量生成静态页面
    protected void btnSel_Click(object sender, EventArgs e)
    {

        string[] values = Request.Form.GetValues("cbxSelect");//获取所选择的checkbox的值
        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            com = pany.SelCompany(Convert.ToInt32(str));//根据编号查出所对应的信息
            if (com.Auditingstatus != 1)
            {
                sb.Append("企业名称:" + com.CompanyName + " 所对应的状态为:" + SelStatus(Convert.ToString(com.Auditingstatus)) + " ，生成静态化页面失败\\n");
            }
            else
            {
                //静态页面生成
                csbll.ComPanyHtml(str, com.LoginName, com.CompanyName, com.IndustryName, com.RangeName,
                com.NatureName, com.Htmlfile, com.EstablishMent, Convert.ToString(com.Employees), Convert.ToString(com.Capital),
                com.Introduction, com.ServiceProce, com.Title, com.Keywords, com.Description, com.Logo, com.FromId.ToString());
            }
        }
        if (sb.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
    }
    #endregion

    #region 全部生成静态页面
    protected void btnAll_Click(object sender, EventArgs e)
    {
        string[] all = csbll.AllCompany().Split('|');//查出表中所有的ID
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < all.Length-1; i++)
        {
            com = pany.SelCompany(Convert.ToInt32(all[i]));//根据编号查出所对应的信息
            if (com.Auditingstatus != 1)
            {
                sb.Append("企业名称:" + com.CompanyName + " 所对应的状态为:" + SelStatus(Convert.ToString(com.Auditingstatus)) + " ，生成静态化页面失败\\n");
            }
            else
            {
                //静态页面生成
                csbll.ComPanyHtml(all[i].ToString(), com.LoginName, com.CompanyName, com.IndustryName, com.RangeName, com.NatureName, com.Htmlfile,
                    com.EstablishMent, Convert.ToString(com.Employees), Convert.ToString(com.Capital), com.Introduction,
                    com.ServiceProce, com.Title, com.Keywords, com.Description, com.Logo, com.FromId.ToString());
            }
        }
        if (sb.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
    }
    #endregion

    /// <summary>
    /// 录入企业名片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCompanyInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompanyInsert.aspx");
    }
}
