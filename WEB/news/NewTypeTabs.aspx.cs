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

public partial class news_NewTypeTabs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888 .BLL .news .NewsTypeTabBLL newtypebll=new Tz888.BLL.news.NewsTypeTabBLL ();
        Tz888.Model.NewsTypeTab newstypetab = new Tz888.Model.NewsTypeTab();
        newstypetab.TypeName = txtnewsTitle.Text.Trim();
        newstypetab.Outid=Convert .ToInt32(radiotuijian.SelectedValue.Trim ());
        newstypetab.BoolStar = Convert.ToInt32(radiocaozuo.SelectedValue.Trim());
        if (txtnewsTitle.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入名称');", true);
            return;
        }
        int result = newtypebll.InsertNewTypeTab(newstypetab);
        if (result > 0)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='NewTypeManage.aspx';", true);
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('录入失败');", true);
        }
    }
}
