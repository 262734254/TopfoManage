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
using Tz888.SQLServerDAL.MyHome;
using Tz888.Model.MyHome;
using Tz888.BLL.MyHome;
using System.Text;
using System.Drawing;
using System.IO;
public partial class MyHome_HomeList : System.Web.UI.Page
{

    HomeLinkManager manager = new HomeLinkManager();
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
        DataTable dt = manager.GetListT("HomeLink", "LID", "*", "", "LoginName", ref CurrentPage, PageNum, ref TotalCount);
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
        manager.deleteMyHome(Id);
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
    #region 获取类别
    /// <summary>
    /// 显示类别
    /// </summary>
    /// <param name="Id">Id</param>
    /// <returns></returns>
    public string ShowStateName(string UserId)
    {
        HomeTypeManager mbll = new HomeTypeManager();
        MyHomeType model = new MyHomeType();
        model = mbll.GetAllTypeById(Convert.ToInt32(UserId));
        string strTemp = string.Empty;
        if (model != null)
            strTemp = model.TypeName;
        return strTemp;
    }
    #endregion
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.dataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
