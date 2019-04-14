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
using Tz888.BLL.Register;
public partial class PayManager_StrikeOrder : System.Web.UI.Page
{
    BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtByName.Text =  bp.LoginName;
    }
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        string LoginName = bp.LoginName;
        if (txtLoginName.Text.Trim() != "" )
            {
                MemberInfoBLL memberBll = new MemberInfoBLL();
                int result = memberBll.ValideNameUseable(txtLoginName.Text.Trim());
                if (result > 0)
                {   //不可用


                    Tz888.Model.StrikeOrder model = new Tz888.Model.StrikeOrder();
                    Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();

                    model.PayTypeCode = "bank";
                    model.LoginName = LoginName;              //充值人
                    model.StrikeLoginName = txtLoginName.Text.Trim();          //充值帐户
                    model.TotalCount = Convert.ToDouble(txtMoney.Text.Trim());
                    model.BuyType = "Pre-Paid";                             //购买类型
                    if (txtBank.Text.ToString().Trim() == "")
                    {
                        model.remark = txtLoginName.Text.Trim() + "使用银行汇款充值" + txtMoney.Text.Trim() + "元" + " 操作人 " + LoginName;//备注
                    }
                    else
                    {
                        model.remark = txtBank.Text.ToString().Trim();
                    }
                    model.OperationMan = LoginName;

                    int orderno = dal.CreateStrikeOrder(model);
                    if (orderno > 0)
                    {
                        Tz888.BLL.StrikeOrder dall = new Tz888.BLL.StrikeOrder();
                        bool b = dall.StrikeSuccess(Convert.ToString(orderno), "bank", "", LoginName);
                        if (b)
                        {
                            Tz888.BLL.Order.BusStrikeRecBLL RecBLL = new Tz888.BLL.Order.BusStrikeRecBLL();
                            Tz888.Model.Orders.BusStrikeRecTab BusModel = new Tz888.Model.Orders.BusStrikeRecTab();
                            BusModel.CardNo = Convert.ToInt64(orderno);
                            BusModel.ChangeBy = LoginName;
                            BusModel.ChangeTime = System.DateTime.Now;
                            BusModel.Email = txtEmail.Text.ToString().Trim();
                            BusModel.Tel = txtTelCountry.Value.ToString().Trim() + txtTelZoneCode.Value.ToString().Trim() + txtTelNumber.Value.ToString().Trim();
                            BusModel.PointCount = Convert.ToDecimal(txtMoney.Text.ToString().Trim());
                            if (txtBank.Text.ToString().Trim() == "")
                            {
                                model.remark = txtLoginName.Text.Trim() + "使用银行汇款充值" + txtMoney.Text.Trim() + "元" + " 操作人 " + LoginName;//备注
                            }
                            else
                            {
                                model.remark = txtBank.Text.ToString().Trim();
                            }
                            BusModel.StrikeType = "bank";
                            BusModel.Mobile = txtMobile.Value.ToString().Trim();
                            BusModel.LoginName = txtLoginName.Text.ToString().Trim();
                            BusModel.Free = Convert.ToInt32(sType.Value.Trim());
                            int num = RecBLL.Add(BusModel);
                            if (num > 0)
                            {
                                Tz888.Common.MessageBox.Show(this.Page, "充值成功!");
                            }
                        }
                    }
                    else
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "订单提交失败!请重试!");
                    }
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "充值帐号不正确请重新输入！");
                }
             
            }
    
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "帐号不为空或者帐号不正确!");
                return;
            }
        
    }
    
        
}
