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
public partial class advertise_channelInfoList : System.Web.UI.Page
{
    HomeLinkManager manager = new HomeLinkManager();//引用公告分页方法
    ADchannelInfoManager infoManager = new ADchannelInfoManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            dataBind();
        }
    }
    /// <summary>
    /// 数据绑定
    /// </summary>
    protected void dataBind()
    {
        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager1.PageSize);
        long TotalCount = 1;
        long PageCount = 1;
        DataTable dt = manager.GetListT("ADchannelInfo", "BID", "*", "", "", ref CurrentPage, PageNum, ref TotalCount);
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
    #region 根据ID删除事件
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        infoManager.DeletechannelInfo(Id);
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
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind();
    }
}
