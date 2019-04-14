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

public partial class Mail_IndustryInsert : System.Web.UI.Page
{
    Tz888.BLL.Mail.IndustryBLL indust = new Tz888.BLL.Mail.IndustryBLL();
    Tz888.Model.Mail.Industry model = new Tz888.Model.Mail.Industry();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sk = Request["sk"].ToString();
            ViewState["sk"] = sk;
            if (Convert.ToInt32(Request["str"]) != 0)
            {
                int sdt = Convert.ToInt32(Request["str"]);
                ViewState["sdt"] = sdt;
                Sel(sdt);
            }
        }
    }
    /// <summary>
    /// 查询内容
    /// </summary>
    /// <param name="id"></param>
    private void Sel(int id)
    {
        model = indust.GetModel(id);
        this.txtName.Text = model.Name.ToString();
        this.rbtIsShow.SelectedValue = model.IsShow.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.BLL.Mail.IndustryBLL bll = new Tz888.BLL.Mail.IndustryBLL();
        Tz888.Model.Mail.Industry model = new Tz888.Model.Mail.Industry();
        if (txtName.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入行业名称！')</script>");
            return;
        }
        model.Name = txtName.Text.Trim();
        model.IsShow =Convert.ToInt32(this.rbtIsShow.SelectedValue.Trim());
        if (Convert.ToString(ViewState["sk"]) == "add")
        {
            int result = bll.Add(model);
            if (result > 0)
            {
                Tz888.Common.MessageBox.ShowAndHref("录入成功", "IndustryManage.aspx");
            }
            else { Response.Write("<script>alert('已经存在该行业！')</script>"); }
        }
        else
        {
            int red = bll.Update(model,Convert.ToInt32(ViewState["sdt"]));
            if (red >= 0)
            {
                Tz888.Common.MessageBox.ShowAndHref("审核成功", "IndustryManage.aspx");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "审核失败");
            }
        }

    }
}
