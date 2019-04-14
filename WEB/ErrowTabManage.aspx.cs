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

public partial class ErrowTabManage : Tz888.Common.Pager.BasePage
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
        this.Pager1.PageSize = 20;
        this.Pager1.StrWhere = par;
        this.Pager1.TableViewName = "ErrowTab,@";
        this.Pager1.KeyColumn = "Id";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "createtime";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    }
    public string CreateDate(string datetime) 
    {
        string par = Convert.ToDateTime(datetime).ToString("yyyy-MM-dd");
        return par;

    }
    public string GetChuLi(int boolchuli)
    {
        string par = "";
        if (boolchuli == 0)
        {
            par = "未处理";
        }
        else { par = "已处理"; }
        return par;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void btnpublic_Click(object sender, EventArgs e)
    {

    }
}
