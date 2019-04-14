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

public partial class news_NewTypeManage :Tz888.Common.Pager.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindShow();
        }
    }
    private void BindShow()
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        string par = "";
        if (par == "")
        {
            par = " 1=1";
        }
        this.Pager1.PageSize =15;
        this.Pager1.StrWhere = par;
        this.Pager1.TableViewName = "NewsTypeTab,@";
        this.Pager1.KeyColumn = "TypeID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "TypeID";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    }
}
