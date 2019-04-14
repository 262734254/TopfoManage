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
using Tz888.BLL.Express;
using Tz888.Model.Express;
using System.Text;
using System.IO;
public partial class Express_ExpressMange : System.Web.UI.Page
{
    ExpressBLL bll = new ExpressBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.AspNetPager.PageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "";
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
        DataTable ds = bll.GetListT("ExpressTab", "expressID", "*", strCriteria, "Expressdata desc", ref CurrentPage, PageNum, ref TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        if ((ds != null) && ds.Rows.Count > 0)
        {
            this.NewsList.DataSource = ds.DefaultView;
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
        //string[] values = Request.Form.GetValues("inType");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的资源!");
            return;
        }
        else
        {
            foreach (string str in values)
            {
                if (!bll.Delete(int.Parse(str.ToString().Trim())))
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
    #region 生成
    protected void btnStatic_Click(object sender, EventArgs e)
    {
        ExpressStatic stat = new ExpressStatic();
        int result = stat.StaticHtml();
        if (result > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成成功");
        }
        else { Tz888.Common.MessageBox.Show(this.Page, "生成失败"); }
        this.GetInfoNews();
    }
    #endregion
    #endregion
    protected string GetLen(string strMsg)
    {
        string str = string.Empty;
        if (strMsg.Length > 16)
        {
            str = strMsg.Substring(0, 16) + "...";
        }
        else
        {
            str = strMsg;
        }
        return str;
    }
}
