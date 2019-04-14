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
public partial class advertise_ADlaunchInfoList : System.Web.UI.Page
{
    ADMessageInfoBLL messageBLL = new ADMessageInfoBLL();
    HomeLinkManager manager = new HomeLinkManager();//引用公告分页方法
    ADlaunchInfoManager infoManager = new ADlaunchInfoManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["Sid"] == "SInfo")      
            {
                ViewState["Criteria"] = " positionID = '" + Convert.ToInt32(Request["fid"]) + "'"; 
            }
            else
            {
                ViewState["Criteria"] = "";  //全部
            }
           
            dataBind();
        }
    }
    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void dataBind()
    {
        string strCriteria = ViewState["Criteria"].ToString();

        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager1.PageSize);
        long TotalCount = 1;
        long PageCount = 1;
        DataTable dt = manager.GetListT("ADlaunchInfo", "advertiserID", "*", strCriteria, "Addates", ref CurrentPage, PageNum, ref TotalCount);
        if (dt != null)
        {
            this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
            this.Repeater1.DataSource = dt.DefaultView;

            this.Repeater1.DataBind();

            if (TotalCount % PageNum > 0)
                PageCount = TotalCount / PageNum + 1;
            else
                PageCount = TotalCount / PageNum;

            this.pinfo.InnerText = "共" + PageCount + "页";

        }


    }
    /// <summary>
    /// 查看频道对应名字
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    protected string ADName(int id)
    {
        string name = "";
        name = messageBLL.SelName(id);
        return name;
    }
    /// <summary>
    /// 查看广告对应名字
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    protected string TypeName(int id)
    {
        string name = "";
        name = messageBLL.TypdName(id);
        return name;
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
    #region 分页事件
    /// <summary>
    /// 分页事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind();
    }
    #endregion
    #region 查询条件事件
    /// <summary>
    /// 查询条件事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();

        if (strCriteria.ToString() == "")
        {
            if (this.txtNuber.Value.Trim() != "")
                strCriteria.Append(" LoginName = '" + this.txtNuber.Value.Trim() + "'");


        }
        ViewState["Criteria"] = strCriteria.ToString();
        dataBind();
    } 
    #endregion
}
