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

public partial class Link_LinkTypeManage : System.Web.UI.Page
{
    private readonly Tz888.BLL.Link.LinkTypeTab LinkType = new Tz888.BLL.Link.LinkTypeTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBind("");
        }
    }


    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind("");
    }

    protected void dataBind(string whrer)
    {

        try
        {
            long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
            int PageNum = 20;
            long TotalCount = 1;
            long PageCount = 1;
            AspNetPager1.PageSize = PageNum;
            DataTable dt = LinkType.GetListT("LinkTypeTab", "LinkId", "*", whrer, "LinkId desc", ref CurrentPage, PageNum, ref TotalCount);
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

    protected void Search_Click(object sender, EventArgs e)
    {
        string where = "";
        string LinkType = txtLinkType.Value.Trim();
        string Status = this.DropStatus.SelectedValue;
        if (!string.IsNullOrEmpty(LinkType))
        {
            LinkType = Tz888.Common.Utility.PageValidate.HtmlEncode(LinkType);
            if (filterSql(LinkType))
                LinkType = "";
        }

        if (!string.IsNullOrEmpty(LinkType))
        {
            where = "LinkName='" + LinkType + "' and ";
        }
        if (Status != "-1")
        {
            where = where + "CheckId=" + Status + " and ";
        }

        if (where.Length > 0)
        {
            where = where.Substring(0, where.LastIndexOf("and")).Trim();
        }
        
        dataBind(where);
    }
}
