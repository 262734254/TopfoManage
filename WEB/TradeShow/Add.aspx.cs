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
using Tz888.Model.TradeShow;
using Tz888.BLL.TradeShow;

public partial class TradeShow_Add : System.Web.UI.Page
{
    private readonly TradeShowBLL bll = new TradeShowBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        BasePage bp = new BasePage();
        if (bp.LoginName == "")
        {
            Response.Redirect("~/login.aspx");
        }
    }

    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        TradeShowModel TradeShow = new TradeShowModel();
        TradeShow.Title = txtTitle.Value.Trim();
        TradeShow.Img = "";
        TradeShow.UserName = txtUserName.Value.Trim();
        TradeShow.Job = txtJob.Value.Trim();
        TradeShow.Sort = ((txtSort.Value.Trim() == "") ? 0 : Convert.ToInt32(txtSort.Value.Trim()));
        TradeShow.Types = Convert.ToInt32(DropTypes.SelectedValue.Trim());
        TradeShow.PublishTime = DateTime.Now;
        TradeShow.Remark = Remark.Value.Trim();
        if (bll.Add(TradeShow))
        {
            Tz888.Common.MessageBox.ShowAndHref("添加成功!", "Manage.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "添加失败!");
        }
    }
}
