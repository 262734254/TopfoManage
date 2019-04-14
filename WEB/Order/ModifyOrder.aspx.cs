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
using Tz888.BLL.Order;
using Tz888.BLL.report;
using Tz888.Model.report;
using Tz888.Model.Orders;
public partial class Order_ModifyOrder : System.Web.UI.Page
{
    reportTabBLL Bll = new reportTabBLL();
    IndustryReport orReport = new IndustryReport();
    OrderLink orLink = new OrderLink();
    OrderMain orMain = new OrderMain();
    OrderMainBLL maBll = new OrderMainBLL();
    ReportTab repModel = new ReportTab();
    IndustryReportBLL OrRBll = new IndustryReportBLL();
    OrderLinkBLL orlinkBll = new OrderLinkBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["OrderNo"]))
            {
                string orderNo = Request.QueryString["OrderNo"].ToString();
                bindModel(orderNo);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["exId"]))
            {
                string orderNo = Request.QueryString["exId"].ToString();
                if (!maBll.DeleteMainByOrderNo(orderNo))
                {
                    Response.Write("<script>alert('删除失败！');document.location='OrderManage.aspx'</script>");
                }
                else
                {
                    Response.Redirect("OrderManage.aspx");
                }
            }
        }
        btnSubmit.Attributes.Add("onclick", "return CheckForm();");
    }
    private void bindModel(string orderNo)
    {
        orReport = OrRBll.GetModel(orderNo);
        orLink = orlinkBll.GetModel(orderNo);
        orMain = maBll.GetModel(orderNo);
        repModel = Bll.GetModel(orReport.reportID);
        txtCompany.Text = orReport.Company.Trim();
        txtAddress.Text = orReport.address.Trim();
        txtLinkMan.Text = orReport.LinkName.Trim();
        txtFax.Text = orReport.fax.Trim();
        txtMeo.Text = orReport.Note.Trim();
        txtPostion.Text = orReport.position.Trim();
        txtAmount.Text = orMain.amount.ToString();
        txtNum.Text = orMain.num.ToString();
        txtPayMent.Text = orMain.payMent.Trim();
        txtOrderNo.Text = orMain.orderNo;
        txtPrice.Text = orReport.reportPrice;
        txtName.Text = repModel.Reportname;
        switch (orMain.state)
        {
            case 0:
                rdoNo.Checked = true;
                break;
            case 1:
                rdoYes.Checked = true;
                break;
            case 2:
                rdoWeiCL.Checked = true;
                break;
            default:
                break;
        }
        if (orMain.paySate == 0)
        {
            rdoNoPay.Checked = true;
        }
        else
        {
            rdoPay.Checked = true;
        }
        txtEmail.Text = orLink.email.Trim();
        txtPhone.Text = orLink.phone.Trim();
        string tel = orLink.tel;
        if (!string.IsNullOrEmpty(tel))
        {
            string[] telLen = tel.Split(',');
            if (telLen.Length == 1)
            {
                txtTel.Text = orLink.tel;
            }
            else
            {
                txtcontactsTel.Text = telLen[0].ToString();
                txtTel.Text = telLen[1].ToString();
                txttel2.Text = telLen[2].ToString();

            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        orReport.Company = txtCompany.Text.Trim();
        orReport.address = txtAddress.Text.Trim();
        orReport.LinkName = txtLinkMan.Text.Trim();
        orReport.fax = txtFax.Text.Trim();
        orReport.Note = txtMeo.Text.Trim();
        orReport.position = txtPostion.Text.Trim();
        orMain.amount = Convert.ToDecimal(txtAmount.Text.Trim().ToString());
        orMain.num = Convert.ToInt32(txtNum.Text.Trim().ToString());
        orMain.payMent = txtPayMent.Text.Trim();
        orMain.orderNo = txtOrderNo.Text.Trim();
        orMain.orderNo = Request.QueryString["OrderNo"].ToString();
        orReport.reportPrice = txtPrice.Text;
        repModel.Reportname = txtName.Text.Trim();
        if (rdoNo.Checked)
        {
            orMain.state = 0;
        }
        else if (rdoYes.Checked)
        {
            orMain.state = 1;
        }
        else if (rdoWeiCL.Checked)
        {
            orMain.state = 2;
        }

        if (rdoNoPay.Checked)
        {
            orMain.paySate = 0;
        }
        else
        {
            orMain.paySate = 1;
        }
        orLink.email = txtEmail.Text.Trim();
        orLink.phone = txtPhone.Text.Trim();
        string tel = string.Empty;
        if (!string.IsNullOrEmpty(txtcontactsTel.Text.Trim()))
        {
            tel = txtcontactsTel.Text.Trim() + ",";
        }
        else
        {
            tel = ",";
        }
        if (!string.IsNullOrEmpty(txtTel.Text.Trim()))
        {
            tel += txtTel.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        if (!string.IsNullOrEmpty(txttel2.Text.Trim()))
        {
            tel += txttel2.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        orLink.tel = tel;
        if (!maBll.UpdateMainThreeTab(orMain, orLink, orReport))
        {
            Response.Write("<script>alert('修改失败！');document.location='OrderManage.aspx'</script>");
        }
        else
        {
            Response.Redirect("OrderManage.aspx");
        }
    }
}
