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

public partial class Mail_MailTypeManage : Tz888.Common.Pager.BasePage
{
    Tz888.BLL.Mail.MailTypeBLL bll = new Tz888.BLL.Mail.MailTypeBLL();
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
        int result = bll.Delete(Id);
        if (result > 0)
        {

        }
        else { Response.Write("<script>alert('删除失败！')</script>"); }
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
        this.Pager1.TableViewName = "MailType,#,@";
        this.Pager1.KeyColumn = "typeID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "typeID";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    }
    public string GetStatu(int stuta)
    {
        string strs = "";
        if (stuta == 0)
        {
            strs = "未审核";
        }
        else if (stuta == 1)
        {
            strs = "已审核";
        }
        return strs;
    }
}
