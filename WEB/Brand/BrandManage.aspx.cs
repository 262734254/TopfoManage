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
using Tz888.BLL.Brand;

public partial class Brand_BrandManage : System.Web.UI.Page
{
    private readonly BrandBLL bll = new BrandBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBind("");
            if (Request.QueryString["BrandId"] != null)
            {
                string BrandId = Request.QueryString["BrandId"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(BrandId))
                    DelBrand(BrandId);
                else
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
            }
        }
    }

    public void DelBrand(string BrandId)
    {
        try
        {
            if (bll.DeleteBrand(BrandId))
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "删除成功!", "BrandManage.aspx", false);
            }
            else
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "删除失败!", "BrandManage.aspx", false);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind("");
    }

    protected void dataBind(string where)
    {
        try
        {
            int PageCurrent = Convert.ToInt32(this.AspNetPager1.CurrentPageIndex);
            int PageNum = 20;
            int TotalCount = 1;
            int PageCount = 1;
            AspNetPager1.PageSize = PageNum;
            DataTable dt = bll.GetBrandList("BrandInfo", "BrandId", "*", where, "BrandId desc", ref PageCurrent, PageNum, ref TotalCount);
            if (dt != null)
            {
                this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
                this.Repeater1.DataSource = dt.DefaultView;

                this.Repeater1.DataBind();

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

    //搜索
    protected void Search_Click1(object sender, EventArgs e)
    {
        string where = "";
        string Title = txtTitle.Value.Trim();
        string Position = ShowPosition.SelectedValue.ToString();

        if (!string.IsNullOrEmpty(Title))
        {
            where = "Title='" + Title + "' and ";
        }
        if (Position != "0")
        {
            where = where + "ShowPosition='" + Position + "' and ";
        }

        if (where.Length > 0)
        {
            where = where.Substring(0, where.LastIndexOf("and")).Trim();
        }
        dataBind(where);
    }
}
