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

public partial class zsWebsite_UpdateZsWebsite : System.Web.UI.Page
{
    private readonly Tz888.BLL.Common.ZoneSelectBLL common = new Tz888.BLL.Common.ZoneSelectBLL();
    private readonly Tz888.BLL.zsWebsite.zsWebsiteBLL bll = new Tz888.BLL.zsWebsite.zsWebsiteBLL();
    private readonly BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
                {
                    InitInfo(Id);
                }
                else
                {
                    Tz888.Common.MessageBox.ShowAndHref("参数错误!", "");
                }
            }
        }
    }

    public void InitInfo(string Id)
    {
        DataTable dt = bll.GetzsWebsite(Id);
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            txtWebsiteName.Value = row["WebsiteName"].ToString();
            txtWebsiteUrl.Value = row["websiteUrl"].ToString();
            LoadProvince(row["ProvinceName"].ToString());
            txtRemarks.Text = row["Remarks"].ToString();
            txtSiteContent.Text = row["SiteContent"].ToString();
        }
    }

    public void LoadProvince(string ProvinceName)
    {
        Province.DataSource = common.GetProvice();
        Province.DataTextField = "ProvinceName";
        Province.DataValueField = "ProvinceName";
        Province.DataBind();
        Province.SelectedValue = ProvinceName;
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        zsWebsiteModel M = new zsWebsiteModel();
        M.Id = Convert.ToInt32(Request.QueryString["Id"]);
        M.LogName = bp.LoginName;
        M.WebsiteName = txtWebsiteName.Value.Trim();
        M.WebsiteUrl = txtWebsiteUrl.Value.Trim();
        M.ProvinceName = Province.SelectedValue.Trim();
        M.PublishTime = DateTime.Now;
        M.SiteContent = txtSiteContent.Text.ToString().Trim();
        M.Remarks = txtRemarks.Text.ToString().Trim();

        if (bll.Update(M))
        {
            Tz888.Common.MessageBox.ShowAndHref("修改成功!", "ManageZsWebsite.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "修改失败!");
        }
    }
}
