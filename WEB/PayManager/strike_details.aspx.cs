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

public partial class PayManager_strike_details : System.Web.UI.Page
{
    public long orderNo;
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (Request.QueryString["order_no"] != null)
        {
            orderNo = Convert.ToInt64(Request.QueryString["order_no"].Trim());
        }
        lblOrderNo.Text = orderNo.ToString();
        if (!Page.IsPostBack)
        {
            bind();
        }
    }
    public void bind()
    {
        DataTable dt = dal.GetList("StrikeOrderViw", "*", "OID", 1, 1, 0, 1, "orderNo=" + orderNo);
        if (dt.Rows.Count > 0)
        {
            lblStrikeLoginName.Text = dt.Rows[0]["StrikeLoginName"].ToString();
            lblStatus.Text = dt.Rows[0]["Status"].ToString() == "1" ? "已支付" : "未支付";
            lblOrderDate.Text = dt.Rows[0]["OrderTime"].ToString();
            lblPayDate.Text = dt.Rows[0]["PayTime"].ToString();
            lblMoeny.Text = dt.Rows[0]["TransMoney"].ToString();
            lblPayType.Text = dt.Rows[0]["PayTypeName"].ToString() == "" ? "暂无" : dt.Rows[0]["PayTypeName"].ToString();
            lblRemark.Text = dt.Rows[0]["Remark"].ToString() == "" ? "无" : dt.Rows[0]["Remark"].ToString();
            lblTradeNo.Text = dt.Rows[0]["PayInfo"].ToString() == "" ? "无" : dt.Rows[0]["PayInfo"].ToString();
            if (dt.Rows[0]["payType"].ToString().Trim() == "bank" || dt.Rows[0]["payType"].ToString().Trim() == "PostOffice")
            {
                OrderUserInfo(orderNo);
            }
            else
            {
                UserInfo(dt.Rows[0]["LoginName"].ToString());
            }
        }
    }
    //用户信息
    public void UserInfo(string LoginName)
    {
        DataTable dt = dal.GetList("LoginInfoTab", "*", "LoginID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
        if (dt.Rows.Count > 0)
        {
            lblStrikeNickName.Text = dt.Rows[0]["LoginName"].ToString() + "[" + dt.Rows[0]["NickName"].ToString() + "]";
            lblTel.Text = dt.Rows[0]["Tel"].ToString();
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblRealName.Text = dt.Rows[0]["RealName"].ToString() == "" ? "未填写" : dt.Rows[0]["RealName"].ToString();
        }
    }
    //订单用户信息
    public void OrderUserInfo(long OrderNo)
    {
        DataTable dt = dal.GetList("OrderTab", "*", "OrderNo", 1, 1, 0, 1, "OrderNo=" + OrderNo);
        if (dt.Rows.Count > 0)
        {
            lblStrikeNickName.Text = dt.Rows[0]["LoginName"].ToString() + "[" + dt.Rows[0]["NickName"].ToString() + "]";
            lblTel.Text = dt.Rows[0]["Tel"].ToString() + " | " + dt.Rows[0]["MobileNo"].ToString();
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblRealName.Text = dt.Rows[0]["RealName"].ToString() == "" ? "未填写" : dt.Rows[0]["RealName"].ToString();

        }
    }
}
