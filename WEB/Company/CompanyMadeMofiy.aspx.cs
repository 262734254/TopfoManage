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

public partial class Company_CompanyMadeMofiy : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyMadeBLL made = new Tz888.BLL.Company.CompanyMadeBLL();
    Tz888.Model.Company.CompanyMadeModel model = new Tz888.Model.Company.CompanyMadeModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int ad = Convert.ToInt32(Request["Ma"]);
            ViewState["ad"] = ad;
            BasePage bp = new BasePage();
            CommentName.InnerHtml = bp.LoginName;
            CompanyMage(ad);
        }
    }
    //根据编号查出所对应的信息
    private void CompanyMage(int id)
    {
        model = made.SelGetMade(id);
        Company.InnerHtml = Session["CpName"].ToString();//广告名称
        txtSumPrice.Value = model.SumPrice;//总价格
        begTime.Value = model.BeginTime.ToString().Trim();//开始时间
        endTime.Value = model.EndTime.ToString().Trim();//结束时间
        txtLinkName.Value = model.LinkName.ToString();//联系人
        txtTelPhone.Value = model.TelPhone.ToString();//电话号码
        txtEmail.Value = model.Email.ToString();//电子邮箱
        rblAuditing.SelectedValue = model.Audit.ToString();//审核状态
        txtRemark.Value = model.Remark;//备注
    }

    //审核
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        model.SumPrice = txtSumPrice.Value.Trim();//总价格
        model.LinkName = txtLinkName.Value.ToString().Trim();//联系人
        model.TelPhone = txtTelPhone.Value.ToString().Trim();//电话号码
        model.Email = txtEmail.Value.ToString().Trim();//电子邮箱
        model.Remark = txtRemark.Value.ToString().Trim();//备注
        model.BeginTime =Convert.ToDateTime(begTime.Value.ToString().Trim());//开始时间
        model.EndTime = Convert.ToDateTime(endTime.Value.ToString().Trim());//结束时间
        model.Audit = Convert.ToInt32(this.rblAuditing.SelectedValue.Trim());//审核
        model.AuditName = CommentName.InnerHtml.Trim();//审核人

        int num = made.UpdateMade(model,Convert.ToInt32(ViewState["ad"]));
        if (num >= 0)
        {
            Tz888.Common.MessageBox.ShowAndHref("审核成功", "CompanyMadeView.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page,"审核失败");
        }
    }
}
