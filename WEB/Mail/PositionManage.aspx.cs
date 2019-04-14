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

public partial class Mail_PositionManage : Tz888.Common.Pager.BasePage
{
    Tz888.BLL.Mail.PositionBLL bll = new Tz888.BLL.Mail.PositionBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request["str"]) != 0)
            {
                int Id = Convert.ToInt32(Request["str"].ToString());
                DeleteLoansInfoTab(Id);
            }
            BindShow();
        }
    }

    private void DeleteLoansInfoTab(int Id)
    {

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
        this.Pager1.PageSize = 20;
        this.Pager1.StrWhere = par;
        this.Pager1.TableViewName = "Position,#,@";
        this.Pager1.KeyColumn = "Id";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "Id";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    }

}
