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
using Tz888.BLL.MyHome;
using Tz888.BLL.advertise;
using System.Text;
using System.Drawing;
using System.IO;
public partial class advertise_AdvisitInfoList : System.Web.UI.Page
{
    HomeLinkManager manager = new HomeLinkManager();//引用公告分页方法
    AdvisitInfoManager infoManager = new AdvisitInfoManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request["infoId"]) != 0)
            {
                ViewState["Criteria"] = " advertiserID = '" + Convert.ToInt32(Request["infoId"]) + "'";
            }
            else
            {
                ViewState["Criteria"] = " ";  //全部
            }
            dataBind();
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind();
    }
    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void dataBind()
    {
        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        //long PageNum = Convert.ToInt64(this.AspNetPager1.PageSize);
        int PageNum = 20;
        long TotalCount = 1;
        long PageCount = 1;
        DataTable dt = manager.GetListT("AdvisitInfo", "visitID", "*", strCriteria, "VDate desc", ref CurrentPage, PageNum, ref TotalCount);
        if (dt != null)
        {
            this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
            this.Repeater1.DataSource = dt.DefaultView;

            this.Repeater1.DataBind();

            if (TotalCount % PageNum > 0)
                PageCount = TotalCount / PageNum + 1;
            else
                PageCount = TotalCount / PageNum;

            this.pinfo.InnerText =Convert.ToString(TotalCount);

        }

    }
    #region 根据ID删除事件
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        infoManager.DeleteDlaunchInfo(Id);
        if (Id > 0)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');", true);
            dataBind();
        }

        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);
        }
    }
    #endregion
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();
    
        if (strCriteria.ToString() == "")
        {
            if (this.txtNuber.Value.Trim() != "")
                strCriteria.Append(" LoginID = '" + this.txtNuber.Value.Trim() + "'");
            

        }
     
        ViewState["Criteria"] = strCriteria.ToString();
        dataBind();
    }

}
