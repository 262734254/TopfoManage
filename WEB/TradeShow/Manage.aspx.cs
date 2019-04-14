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
using Tz888.BLL.TradeShow;

public partial class TradeShow_Manage : System.Web.UI.Page
{
    private readonly TradeShowBLL bll = new TradeShowBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        BasePage bp = new BasePage();
        if (bp.LoginName == "")
        {
            Response.Redirect("~/login.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
                {
                    if (bll.Del(Convert.ToInt32(Id)))
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
                    }
                    else
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
                    }
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
                }
            }
            BindData("");
        }
    }

    public void BindData(string where)
    {
        try
        {
            int PageCurrent = Convert.ToInt32(this.AspNetPager1.CurrentPageIndex);
            int PageNum = 20;
            int TotalCount = 1;
            int PageCount = 1;
            AspNetPager1.PageSize = PageNum;
            DataTable dt = bll.GetTradeShowList("TradeShow", "Id", "*", where, "Id desc", ref PageCurrent, PageNum, ref TotalCount);
            if (dt != null)
            {
                this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
                RepTradeShow.DataSource = dt.DefaultView;
                RepTradeShow.DataBind();
                if (TotalCount % PageNum > 0)
                    PageCount = TotalCount / PageNum + 1;
                else
                    PageCount = TotalCount / PageNum;
                this.pinfo.InnerText = Convert.ToString(TotalCount);//总条数
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData("");
    }

    protected void BtnDel_Click(object sender, EventArgs e)
    {
        string Id = "";
        if (RepTradeShow.Items.Count > 0)
        {
            for (int i = 0; i < RepTradeShow.Items.Count; i++)
            {
                CheckBox Cbox = RepTradeShow.Items[i].FindControl("Cbox") as CheckBox;
                if (Cbox.Checked)
                {
                    Id = Id + Cbox.ToolTip + ",";
                }
            }
            if (Id.Length > 0)
            {
                Id = Id.Remove(Id.Length - 1, 1);
                if (bll.Del(Id))
                {
                    Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
                }
            }
        }
        BindData("");
    }
}
