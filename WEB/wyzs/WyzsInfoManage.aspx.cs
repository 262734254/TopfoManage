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
using Tz888.BLL.wyzs;

public partial class wyzs_WyzsInfoManage : System.Web.UI.Page
{
    private readonly MainInfoBLL bll = new MainInfoBLL();
    private readonly BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(bp.LoginName))
            {

            }
            if (Request.QueryString["MainId"] != null)
            {
                string MainId = Request.QueryString["MainId"].ToString();
                Del(MainId);
            }
            BindData();
        }
    }

    private void BindData()
    {
        int PageCurrent = Convert.ToInt32(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 20;
        int TotalCount = 1;
        int PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        DataTable dt = bll.GetTradeShowList("MainInfoTab", "Id", "*", "", "Id desc", ref PageCurrent, PageNum, ref TotalCount);
        if (dt != null)
        {
            this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
            RfList.DataSource = dt.DefaultView;
            RfList.DataBind();
            if (TotalCount % PageNum > 0)
                PageCount = TotalCount / PageNum + 1;
            else
                PageCount = TotalCount / PageNum;
            this.pinfo.InnerText = Convert.ToString(TotalCount);//总条数
        }
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }

    private void Del(string MainId)
    {
        if (bll.Delete(MainId))
        {
           Tz888.Common.MessageBox.Show(this.Page,"删除成功!");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {


    }
}
