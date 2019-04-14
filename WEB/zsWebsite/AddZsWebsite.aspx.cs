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
using Tz888.Model.zsWebsite;

public partial class zsWebsite_AddZsWebsite : System.Web.UI.Page
{
    private readonly Tz888.BLL.Common.ZoneSelectBLL common = new Tz888.BLL.Common.ZoneSelectBLL();
    private readonly Tz888.BLL.zsWebsite.zsWebsiteBLL bll = new Tz888.BLL.zsWebsite.zsWebsiteBLL();
    private readonly BasePage bp = new BasePage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadProvince();
        }
    }

    public void LoadProvince()
    {
        Province.DataSource = common.GetProvice();
        Province.DataTextField = "ProvinceName";
        Province.DataValueField = "ProvinceName";
        Province.DataBind();

        ListItem Item = new ListItem();
        Item.Text = "请选择";
        Item.Value = "-1";
        Province.Items.Insert(0, Item);
    }


    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        zsWebsiteModel M = new zsWebsiteModel();
        M.LogName = bp.LoginName;
        M.WebsiteName = txtWebsiteName.Value.Trim();
        M.WebsiteUrl = txtWebsiteUrl.Value.Trim();
        M.ProvinceName = Province.SelectedValue.Trim();
        M.PublishTime = DateTime.Now;
        M.SiteContent = txtSiteContent.Text.ToString().Trim();
        M.Remarks = txtRemarks.Text.ToString().Trim();

        if (bll.Add(M))
        {
            Tz888.Common.MessageBox.ShowAndHref("添加成功!", "ManageZsWebsite.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "添加失败!");
        }
    }
}
