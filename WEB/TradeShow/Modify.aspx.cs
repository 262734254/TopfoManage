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
using Tz888.BLL.TradeShow;
using Tz888.Model.TradeShow;

public partial class TradeShow_Modify : System.Web.UI.Page
{
    private readonly TradeShowBLL bll = new TradeShowBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        BasePage bp = new BasePage();
        if (bp.LoginName == "")
        {
            Response.Redirect("~/login.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["ID"];
                DataTable dt = bll.GetTradeShowById(Id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtTitle.Value = row["Title"].ToString();
                    txtUserName.Value = row["UserName"].ToString();
                    txtJob.Value = row["Job"].ToString();
                    txtSort.Value = row["Sort"].ToString();
                    DropTypes.SelectedValue = row["Types"].ToString();
                    Remark.Value = row["Remark"].ToString();
                }
            }
        }
    }

    protected void BtnModify_Click(object sender, EventArgs e)
    {
        int Id = Convert.ToInt32(Request.QueryString["ID"]);
        TradeShowModel TradeShow = new TradeShowModel();
        TradeShow.Id = Id;
        TradeShow.Title = txtTitle.Value.Trim();
        TradeShow.UserName = txtUserName.Value.Trim();
        TradeShow.Job = txtJob.Value.Trim();
        TradeShow.Img = "";
        TradeShow.Sort = ((txtSort.Value.Trim() == "") ? 0 : Convert.ToInt32(txtSort.Value.Trim()));
        TradeShow.Types = Convert.ToInt32(DropTypes.SelectedValue.Trim());
        TradeShow.PublishTime = DateTime.Now;
        TradeShow.Remark = Remark.Value;
        if (bll.Modify(TradeShow))
        {
            Tz888.Common.MessageBox.ShowAndHref("修改成功!", "Manage.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "修改失败!");
        }
    }
}
