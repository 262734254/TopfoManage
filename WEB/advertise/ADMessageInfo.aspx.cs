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
using Tz888.Model.advertise;
using Tz888.BLL.advertise;

public partial class advertise_ADMessageInfo : Tz888.Common.Pager.BasePage
{
   
    ADMessageInfoBLL messageBLL = new ADMessageInfoBLL();
    private int _myPageSize = 10;
    private string _criteria;
    protected void Page_Load(object sender, EventArgs e)
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        Message();
        if (!IsPostBack)
        {
            this.Pager1.DataBind();
        }
        if (Convert.ToInt32(Request["PostID"]) != 0)
        {
            DelMainage(Convert.ToInt32(Request["PostID"]));
        }
 
    }
    private void Message()
    {
        int id = Convert.ToInt32(Request.QueryString["infoID"]);
        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();
        if (id != 0)
        {
            strCriteria.Append(" BID=" + id);
        }
        ViewState["Criteria"] = strCriteria.ToString();
        SetPagerParameters();
    }
    private void SetPagerParameters()
    {
        if (ViewState["MyPageSize"] != null)
            this._myPageSize = Convert.ToInt32(ViewState["MyPageSize"]);
        else
            ViewState["MyPageSize"] = this._myPageSize;

        if (ViewState["Criteria"] == null)
        {
            this._criteria = "";
            ViewState["Criteria"] = this._criteria;
        }
        else
            this._criteria = ViewState["Criteria"].ToString();

        this.Pager1.PageSize = this._myPageSize;
        this.Pager1.StrWhere = this._criteria;
        this.Pager1.TableViewName = "ADMessageView";
        this.Pager1.KeyColumn = "positionID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "positionID";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
    }

    protected string ADName(int id)
    {
        string name = "";
        name = messageBLL.SelName(id);
        return name;
    }
    protected string Check(int id)
    {
        string name = "";
        switch (id)
        { 
            case 0:
                name = "未激活";
                break;
            case 1:
                name = "已激活";
                break;
        }
        return name;
    }
    protected void DelMainage(int id)
    {
        long info = messageBLL.DelMessage(id);
        if (info > 0)
        {
            Response.Write("<script>alert('删除成功！')</script>");
        }
        else
        {
            Response.Write("<script>alert('删除失败！')</script>");
        }
        this.SetPagerParameters();
        this.Pager1.DataBind();
    }
}
