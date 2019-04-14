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

public partial class VipManager_VIPMemberList : System.Web.UI.Page
{
    RoleGroupBLL RoleGroupBll = new RoleGroupBLL(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "MemberGradeID = 1002";  //全部信息
            dataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();
        if (strCriteria.ToString() == "")
        {
            if (this.txtLoginName.Value.Trim() != "")
                strCriteria.Append("MemberGradeID = 1002 and LoginName ='"+ this.txtLoginName.Value.ToString().Trim()+"'");
        }

        ViewState["Criteria"] = strCriteria.ToString();
        dataBind();
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        dataBind();
    }


    #region 将类型进行翻译
    protected string Verify(int com)
    {
        string Nnamn = "";
        switch (com)
        {
            case 1001:
                Nnamn = "个人";
                break;
            case 1002:
                Nnamn = "个体经营";
                break;
            case 1003:
                Nnamn = "企业单位";
                break;
            case 1004:
                Nnamn = "政府机构";
                break;
            case 2001:
                Nnamn = "政府招商";
                break;
            case 2002:
                Nnamn = "投资单位";
                break;
            case 2003:
                Nnamn = "融资单位";
                break;
            case 2004:
                Nnamn = "中介机构";
                break;
            case 2005:
                Nnamn = "资源联盟";
                break;
            case 2006:
                Nnamn = "专业人才";
                break;
            case 2007:
                Nnamn = "服务机构";
                break;
            case 2008:
                Nnamn = "东莞台商会员";
                break;
            case 2009:
                Nnamn = "土石方工程方";
                break;
            case 2010:
                Nnamn = "土石方施工方";
                break;

        }
        return Nnamn;
    }
    #endregion
    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void dataBind()
    {
        string strCriteria = ViewState["Criteria"].ToString();
        long PageSize = Convert.ToInt64(ViewState["pageSize"]);
        long CurrPage = Convert.ToInt64(AspNetPager.CurrentPageIndex);
        long TotalCount = 0;
        DataTable dt = RoleGroupBll.GetListT("LoginInfoTab", "LoginName", "*", strCriteria, "VIPValidateDate desc", ref CurrPage, 20, ref TotalCount);
        this.VipList.DataSource = dt;
        AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.DataBind();
    }
}
