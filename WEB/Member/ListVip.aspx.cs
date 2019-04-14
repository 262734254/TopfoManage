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
using Tz888.BLL.ManageSystem;


public partial class Member_ListVip : BasePage
{
    RoleGroupBLL RoleGroupBll = new RoleGroupBLL(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                //string MemberGradeID = Request.QueryString["MemberGradeID"].ToString().Trim();
                //this.Repeater1.DataSource= RoleGroupBll.GetListVip(MemberGradeID);
                //this.DataBind();
                this.dataBind();
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    protected string getName()
    {
        return Request.QueryString["name"].ToString().Trim();
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void dataBind()
    {
        string Id = Request.QueryString["MemberGradeID"].ToString().Trim();
        long PageSize = Convert.ToInt64(ViewState["pageSize"]);
        long CurrPage = Convert.ToInt64(AspNetPager1.CurrentPageIndex);
        long TotalCount = 0;
        DataTable dt = RoleGroupBll.GetListT("LoginInfoTab", "LoginName", "LoginName", "MemberGradeID = " + Id, "LoginName", ref CurrPage, 10, ref TotalCount);
        this.Repeater1.DataSource = dt;
        AspNetPager1.RecordCount =Convert.ToInt32(TotalCount);
        this.DataBind();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.dataBind();
    }
}
