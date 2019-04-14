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

public partial class Recommend_RecommendManage : System.Web.UI.Page
{
    private readonly Tz888.BLL.Recommend.RecommendBLL bll = new Tz888.BLL.Recommend.RecommendBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
                    DelRecommend(Id);
                else
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
            }
            dataBind("");
        }
    }

    public void DelRecommend(string Id)
    {
        if (bll.DelRecommend(Id))
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "删除成功!", "RecommendManage.aspx", false);
        else
            Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
    }

    public string GetFenzhanName(string ProvinceID)
    {
        Tz888.BLL.FenZhan.FenZhanBLL Fz = new Tz888.BLL.FenZhan.FenZhanBLL();
        return Fz.GetFenZhanName(ProvinceID);
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind("");
    }

    protected void dataBind(string where)
    {
        int PageCurrent = Convert.ToInt32(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 20;
        int TotalCount = 1;
        int PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        try
        {
            DataTable dt = bll.GetRecommendList("Recommend", "Id", "*", where, "Sort Desc", ref PageCurrent, PageNum, ref TotalCount);
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


    protected string Verify(int com)
    {
        string Nnamn = "";
        switch (com)
        {
            case 0:
                Nnamn = "招商方";
                break;
            case 1:
                Nnamn = "投资方";
                break;
            case 2:
                Nnamn = "融资方";
                break;
            case 3:
                Nnamn = "热点资源项目";
                break;
            case 4:
                Nnamn = "重大热点资源项目";
                break;
            case 5:
                Nnamn = "重大投资项目";
                break;

        }
        return Nnamn;
    }
    protected void Search_Click(object sender, EventArgs e)
    { 
         //搜索
        try
        {
            string where = "";
            string Title = txtTitle.Value.Trim();
            if (!string.IsNullOrEmpty(Title))
            {
                Title = Tz888.Common.Utility.PageValidate.HtmlEncode(Title);
                if (filterSql(Title))
                    Title = "";
            }

            if (!string.IsNullOrEmpty(Title))
            {
                where = "Title='" + Title + "' and ";
            }

            if (DropIdentity.SelectedValue != "-1")
            {
                where = where + "[Identity]=" + DropIdentity.SelectedValue + " and ";
            }

            if (where.Length > 0)
            {
                where = where.Substring(0, where.LastIndexOf("and")).Trim();
            }

            dataBind(where);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 过滤SQL语句,防止注入
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns>fasle - 没有注入, true - 有注入 </returns>
    public bool filterSql(string sSql)
    {
        int srcLen, decLen = 0;
        sSql = sSql.ToLower();
        sSql = sSql.ToLower().Trim();
        srcLen = sSql.Length;
        sSql = sSql.Replace("exec", "");
        sSql = sSql.Replace("delete", "");
        sSql = sSql.Replace("master", "");
        sSql = sSql.Replace("truncate", "");
        sSql = sSql.Replace("declare", "");
        sSql = sSql.Replace("create", "");
        sSql = sSql.Replace("xp_", "no");
        sSql = sSql.Replace("and", "");
        decLen = sSql.Length;
        if (srcLen == decLen)
            return false;
        else
            return true;
    }
}
