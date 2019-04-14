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

public partial class news_NewsTypeUpdate : System.Web.UI.Page
{
    private int id
    {
        get
        {
            return Convert.ToInt32(ViewState["id"]);
        }
        set
        {
            ViewState["id"] = value;
        }
    }
    Tz888.BLL.news.NewsTypeTabBLL newstypetabbll = new Tz888.BLL.news.NewsTypeTabBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id = Convert .ToInt32(Request.QueryString["str"].Trim());
            BindShow();
        }
    }

    private void BindShow()
    {
        Tz888.Model.NewsTypeTab newtype = newstypetabbll.GetNewsTypeByTypeId(id);
        this.txtnewsTitle.Text = newtype.TypeName.ToString().Trim ();
        this.radiocaozuo.Items.FindByValue(newtype.BoolStar.ToString().Trim ()).Selected = true;
        this.radiotuijian.Items.FindByValue(newtype .Outid.ToString ().Trim ()).Selected = true;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.Model.NewsTypeTab newstype = new Tz888.Model.NewsTypeTab();
        newstype.TypeID = id;
        newstype.TypeName = txtnewsTitle.Text.Trim();
        newstype.BoolStar=Convert .ToInt32 (this.radiocaozuo.SelectedValue.Trim ());
        newstype.Outid = Convert.ToInt32(this.radiotuijian.SelectedValue.Trim());
        if (txtnewsTitle.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入名称');", true);
            return;
        }
        int result = newstypetabbll.UpdateNewTypeTab(newstype);
        if (result > 0)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='NewTypeManage.aspx';", true);
        }
        else { this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败');", true); }
    }
}
