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

public partial class LmOrder_info_details : System.Web.UI.Page
{
    BasePage bp = new BasePage();
    Tz888.BLL.PleaseMoneyBLL.PleaseMoneyBLL bll = new Tz888.BLL.PleaseMoneyBLL.PleaseMoneyBLL();

    Tz888.Model.PleaseMoneyModel.PleaseMoneyModel model = new Tz888.Model.PleaseMoneyModel.PleaseMoneyModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["atmid"] != null)
            {
              int  atmid = Convert.ToInt32(Request.QueryString["atmid"].Trim());
            
                bind(atmid);
            }



        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime time_now = DateTime.Now;
        model.AccountName = this.txtAccountName.Text.Trim().ToString();//账号名称
        model.atmcount = Convert.ToDecimal(this.txtMoney.Text.Trim().ToString());//提取金额
        model.BankName = this.txtBankName.Text.Trim().ToString();//银行名称
        model.BankNumber = this.txtBankAccout.Text.Trim().ToString();//银行帐号
        model.DepositBank = this.txtDepositBank.Text.ToString().Trim();//开户银行
        model.Description = this.txtDesc.Text.ToString().Trim();//备注
        model.Mobile = this.txtMobile.Text.ToString().Trim();//手机
        model.LoginName = txtLoginName.Text.ToString().Trim() ;
        model.CreateTime =Convert.ToDateTime( txtTime.Text);
        model.Enddate = time_now;
        model.StateID = Convert.ToInt32(this.rblAuditing.SelectedValue.ToString());
        model.AuditName =bp.LoginName ;
        model.atmId =Convert.ToInt32( txtId.Value.ToString().Trim());
        int num = bll.Update(model);
        if (num > 0)
        {

            Response.Write("<script>alert('审核成功！');document.location='PleaseMoneyList.aspx'</script>");

        }
        else
        {
            Response.Write("<script>alert('审核失败！');document.location='PleaseMoneyList.aspx'</script>");
        }

    }
    public void bind(int atmid)
    {
     
        string LoginName = bp.LoginName;
        
        model = bll.GetModel(atmid);
        this.txtId.Value = model.atmId.ToString().Trim();
        this.txtAccountName.Text = model.AccountName.ToString().Trim();//账号名称
        this.txtMoney.Text = Convert.ToString(model.atmcount.ToString().Trim());
        this.txtBankName.Text = model.BankName.ToString().Trim();//银行名称
        this.txtBankAccout.Text = model.BankNumber.ToString().Trim();//银行帐号
        this.txtDepositBank.Text = model.DepositBank.ToString().Trim();//开户银行
        this.txtDesc.Text = model.Description.ToString().Trim();//备注
        this.txtMobile.Text = model.Mobile.ToString().Trim();//手机
        txtTime.Text = model.CreateTime.ToString().Trim();
        txtLoginName.Text = model.LoginName.ToString().Trim();
        this.rblAuditing.SelectedValue = model.StateID.ToString();

        string money = bll.SelUserMoney(model.LoginName);
        txtyu.Value = money;
        lblPoint.Text = money;
        //lblState.Text = Convert.ToString(model.StateID.ToString().Trim() == "1" ? "已支付" : "未支付");

    }
}
