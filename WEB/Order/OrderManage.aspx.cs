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
using Tz888.BLL.Order;
using Tz888.BLL.Express;
public partial class Order_OrderManage : System.Web.UI.Page
{
    OrderMainBLL mainBll = new OrderMainBLL();
    ExpressBLL bll = new ExpressBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.AspNetPager.PageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "state<>3";
            this.AspNetPager.CurrentPageIndex = 1;
            GetInfoNews();
        }
    }
    private void GetInfoNews()
    {
        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        long TotalCount = 0;
        long PageCount = 1;
        DataTable ds = bll.GetListT("OrderMain", "orderId", "*", strCriteria, "orderDate desc", ref CurrentPage, PageNum, ref TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        if ((ds != null) && ds.Rows.Count > 0)
        {
            this.NewsList.DataSource = ds.DefaultView;
            this.NewsList.DataBind();
        }
        else
        {
            this.NewsList.DataSource = null;
            this.NewsList.DataBind();
        }

        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;

    }
    #region 每页显示多少条 ddlPageSize_SelectedIndexChanged
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    #endregion
    #region AspNetPager_PageChanged 分页控件
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    #endregion
    #region 删除按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool flag = false;
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的资源!");
            return;
        }
        else
        {
            foreach (string str in values)
            {
                if (!mainBll.DeleteMainByOrderNo(str.ToString().Trim()))
                {
                    flag = true;
                }
            }
            if (flag)
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除失败");
            }
            this.GetInfoNews();
        }
    }

    #endregion
    protected string getstate(int state, int flag)
    {
        string str = "";
        if (flag == 0)//订单状态2未处理1有效0无效
        {
            if (state == 0)
            {
                str = "无效";
            }
            else if (state == 1)
            {
                str = "<font color='red'>有效</font>";
            }
            else if (state == 2)
            {
                str = "未处理";
            }
        }
        else //支付状态 1已支付、0无
        {
            if (state == 0)
            {
                str = "没支付";
            }
            else if (state == 1)
            {
                str = "已支付";
            }
        }
        return str;
    }
}
