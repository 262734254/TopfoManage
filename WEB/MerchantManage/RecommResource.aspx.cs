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
using Tz888.Model.Recomm;
using Tz888.BLL.Recomm;
using Tz888.BLL.Company;
public partial class MerchantManage_RecommResource : System.Web.UI.Page
{
    recommResourceBLL bll = new recommResourceBLL();
    BasePage bp = new BasePage();
    CompanyShowBLL companyBll = new CompanyShowBLL();
    public string strs = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            strs = companyBll.SelCompanyUserName();//取得所有的用户名展现在文本框中
            if (strs.ToString().EndsWith(","))
            {
                strs = strs.ToString().Substring(0, strs.ToString().Length - 1);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["infoID"]))
            {
                string _infoID = Request["infoID"].ToString();
                ViewState["typeId"] = Request["typeId"].ToString();
                ViewState["_infoID"] = _infoID;
                if (_infoID.EndsWith(","))//多个推荐
                {
                }
                else//单个推荐
                {
                    GetInfoNews(_infoID);
                }
            }
        }
    }
    private void GetInfoNews(string infoid)
    {
        DataSet ds = bll.GetTitleAndUrlByInfoId(infoid);
        this.NewsList.DataSource = ds.Tables[0].DefaultView;
        this.NewsList.DataBind();
    }
    protected void NewsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ListItemType objItemType = e.Item.ItemType;

        if (objItemType == ListItemType.Item ||
            objItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvData = (DataRowView)e.Item.DataItem;
            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
            hlTitle.Text = "<a href='http://www.topfo.com/" + drvData["HtmlFile"].ToString() + "' target=\"_blank\">" + Tz888.Common.Utility.PageValidate.FixLenth(drvData["Title"].ToString(), 37, "...") + Title + "</a>";
            hlTitle.ToolTip = drvData["Title"].ToString();
        }
    }
    #region  推荐按钮
    protected void btnIndexStatic_Click(object sender, EventArgs e)
    {
        CompanyShowBLL comBll = new CompanyShowBLL();
        int result = 0;
        if (comBll.ExistsName(txtIndex.Text.Trim()))//exists
        {
            //bp.LoginName = "longbin";
            DataSet ds = bll.GetTitleAndUrlByInfoId(ViewState["_infoID"].ToString());
            int recommId = bll.ExistsByWhere(int.Parse(ViewState["typeId"].ToString()), bp.LoginName, long.Parse(ds.Tables[0].Rows[0]["infoID"].ToString()));
            if (recommId > 0)
            {
                result = bll.UpdateTimeByRecommId(recommId);
            }
            else
            {
                recommResourceM sourceM = new recommResourceM();
                sourceM.ResourceTitle = ds.Tables[0].Rows[0]["Title"].ToString();
                sourceM.ResourceUrl = ds.Tables[0].Rows[0]["HtmlFile"].ToString();
                sourceM.ResourceTypeId = int.Parse(ViewState["typeId"].ToString());//1代表项目（招商，投资,融资）
                sourceM.ResourceId = long.Parse(ds.Tables[0].Rows[0]["infoID"].ToString());
                sourceM.RecommName = bp.LoginName;
                sourceM.RecommToUser = txtIndex.Text.Trim();
                result = bll.Add(sourceM);
            }
        }
        else//exists
        {
            Response.Write("<script>alert('您输入的用户不存在')</script>");
        }
        if (result > 0)
        {
            //success
            Response.Write("<script>location.href='MyRecommResource.aspx';</script>");
        }
        else
        {
            //error
            Response.Write("<script>alert('推荐失败');location.href='MerchantManage.aspx'</script>");
        }

    }
    #endregion
}
