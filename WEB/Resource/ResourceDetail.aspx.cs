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

public partial class Resource_ResourceDetail : System.Web.UI.Page
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
                    ShowDetail(DeclarationId);
                else
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
            }
        }
    }

    public void ShowDetail(string DeclarationId)
    {
        Repeater1.DataSource = bll.GetResourceDetail(DeclarationId);
        Repeater1.DataBind();
    }

    protected void BtnModfiy_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["DeclarationId"] != null)
        {
            string DeclarationId = Request.QueryString["DeclarationId"];
            if (Tz888.Common.Utility.PageValidate.IsNumber(DeclarationId))
            {
                if (bll.ModfiyResource(DeclarationId))
                {
                    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "审核成功!", "ResourceManage.aspx");
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "审核失败!");
                }
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
            }
        }
    }
}

