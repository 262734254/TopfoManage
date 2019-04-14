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

public partial class CRM_CrmManage : System.Web.UI.Page
{
    private readonly Tz888.BLL.Resource.ResourceBLL bll = new Tz888.BLL.Resource.ResourceBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["DeclarationId"] != null)
            {
                string DeclarationId = Request.QueryString["DeclarationId"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(DeclarationId))
                    DelResource(DeclarationId);
                else
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
            }
            dataBind("");
        }
    }

    public void DelResource(string DeclarationId)
    {
        try
        {
            if (bll.DelResource(DeclarationId))
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "删除成功!", "CrmManage.aspx", false);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
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
        int PageCurrent = Convert.ToInt32(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 5;
        int TotalCount = 1;
        int PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        try
        {
            DataTable dt = bll.GetResourceList("CRM", "DeclarationId", "DeclarationId,Title,Contact,Status", where, "DeclarationId Desc", ref PageCurrent, PageNum, ref TotalCount);
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
    protected void Search_Click(object sender, EventArgs e)
    {
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

            string Contact = txtContact.Value.Trim();
            if (!string.IsNullOrEmpty(Contact))
            {
                Contact = Tz888.Common.Utility.PageValidate.HtmlEncode(Contact);
                if (filterSql(Contact))
                    Contact = "";
            }

            if (!string.IsNullOrEmpty(Title))
            {
                where = "Title='" + Title + "' and ";
            }

            if (!string.IsNullOrEmpty(Contact))
            {
                where = where + "Contact='" + Contact + "' and ";
            }

            if (Status.SelectedValue != "-1")
            {
                where = where + "Status=" + Status.SelectedValue + " and ";
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
