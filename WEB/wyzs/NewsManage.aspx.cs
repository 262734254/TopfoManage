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
using Tz888.Model.wyzs;
using Tz888.BLL.wyzs;
using Tz888.BLL.MyHome;
using Tz888.SQLServerDAL.MyHome;
public partial class wyzs_NewsManage : System.Web.UI.Page
{
    WyzsModel model = new WyzsModel();
    WyzsTabBLL bll = new WyzsTabBLL();
    HomeLinkManager manager = new HomeLinkManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request["str"]) != 0)
            {
                int Id = Convert.ToInt32(Request["str"].ToString());
                DeleteLoansInfoTab(Id);
            }
            //DataSet ds = bll.GetAllList();
            //if ((ds != null) && ds.Tables[0].Rows.Count > 0)
            //{
            //    RfList.DataSource = ds;
            //    RfList.DataBind();
            //}
            ViewState["Criteria"] = " pageAddress =5 and status <>''";
            GetInfoNews();

        }
    }

    #region 页面加载方法
    private void GetInfoNews()
    {
        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        long TotalCount = 0;
        long PageCount = 1;
        DataTable ds = manager.GetListCrm("WyzsTab", "id", "title,typeid,type,htmlurl,orderid,pageAddress,id,status", strCriteria, "orderid desc", ref CurrentPage, PageNum, ref TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.RfList.DataSource = ds.DefaultView;

        this.RfList.DataBind();
        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;

    }
    #endregion

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();

    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    private void DeleteLoansInfoTab(int Id)
    {
        if (!bll.Delete(Id))
        {
            Response.Write("<script>alert('删除失败');location.href='NewsManage.aspx'</script>");
        }
        else
        {
            Response.Write("<script>location.href='NewsManage.aspx'</script>");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();

        if (strCriteria.ToString() == "")
        {
            if (this.txtNumber.Value.Trim() != "")   //根据ID
                strCriteria.Append(" id like  '%" + this.txtNumber.Value.Trim() + "%'");
        }
        if (strCriteria.ToString() == "")
        {
            if (this.txtTitle.Value.Trim() != "")   //根据标题
            {
                strCriteria.Append(" title like  '%" + this.txtTitle.Value.Trim() + "%'");
            }
        }

        if (strCriteria.ToString() == "")
        {
            ViewState["Criteria"] = "  pageAddress =5 and status <>''  ";
        }
        else
        {
            ViewState["Criteria"] = strCriteria.ToString() + " and pageAddress =5 and status <>'' ";
        }

        GetInfoNews();
    }
}
