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
/*
 此页面用于查看所有窄告信息
 */
public partial class Company_NarrowModeView : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyBLL pany = new Tz888.BLL.Company.CompanyBLL();
    Tz888.BLL.Company.CompanyMadeBLL madeBll = new Tz888.BLL.Company.CompanyMadeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "";
            dataBind();
            if (Convert.ToInt32(Request["AdId"]) != 0)
            {
                int ad = Convert.ToInt32(Request["AdId"]);
                Delete(ad);
            }
        }
    }
    //删除
    private void Delete(int id)
    {
        int num = madeBll.NarrowDelete(id);
        if (num == 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功！");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page,"删除失败");
        }
        dataBind();
    }
    #region 绑定
    /// <summary>
    /// 绑定
    /// </summary>
    protected void dataBind()
    {
        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 20;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        DataTable dt = pany.GetListT("NarrowAdInfoTab", "AdID", "*", strCriteria, "CreateDate desc", ref CurrentPage, PageNum, ref TotalCount);
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

    #region 类型翻译
    protected string TypeName(string name)
    {
        string num = "";
        if (name != "")
        {
            switch (name)
            {
                case "Project":
                    num = "项目方";
                    break;
                case "Merchant":
                    num = "招商方";
                    break;
                case "Capital":
                    num = "投资方";
                    break;
            }
        }
        return num;
    }
    #endregion

    #region 解析省名称
    protected string ProvinceName(string name)
    {
        string num = "";
        Tz888.BLL.ProfessionalManage.ProfessionalLinkBLL prof = new Tz888.BLL.ProfessionalManage.ProfessionalLinkBLL();
        if (name != "")
        {
            num = prof.GetProvinceNameByCode(name);
        }
        return num;
        return name;
    }
    #endregion

    #region 解析时间
    protected string ReTime(string name)
    {
        string num = "";
        DateTime dt = Convert.ToDateTime(name);
        if (name != "")
        {
            num = dt.ToString("yyyy-MM-dd");
        }
        return num;
    }
    #endregion

    #region 条件查询
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        string name = "";

        if (this.txtTitle.Value != "")
        {
            if (this.txtLoginName.Value != "")
            {
                name += " Title like '%" + this.txtTitle.Value.Trim() + "%' and UserName='" + this.txtLoginName.Value.Trim() + "' ";
            }
            else
            {
                name += " Title like '%" + this.txtTitle.Value.Trim() + "%'";
            }
        }
        else
        {
            if (this.txtLoginName.Value != "")
            {
                name += "  UserName='" + this.txtLoginName.Value.Trim() + "' ";
            }
            else
            {
                name += " ";
            }
        }

        ViewState["Criteria"] =name;
        dataBind();
    }
    #endregion
}
