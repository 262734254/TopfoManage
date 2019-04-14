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

public partial class PayManager_trade_info_details : System.Web.UI.Page
{
    public long ID;
    public string status;
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        ID = Convert.ToInt64(Request.QueryString["ID"]);
        status = Request.QueryString["status"].Trim();
        if (status == "0")//未完成交易
        {
            bindWait();
        }
        if (status == "1")//已完成交易
        {
            bindEnd();
        }
    }
    //完成的订单信息

    public void bindEnd()
    {
        DataTable dt = dal.GetList("ConsumeRecviw", "*", "ID", 1, 1, 0, 1, "ID=" + ID);
        if (dt.Rows.Count > 0)
        {

            lblTitle.Text = "<a target='_blank' href='http://www.topfo.com/" + dt.Rows[0]["htmlfile"].ToString() + "'>" + dt.Rows[0]["SourceType"].ToString() + "</a>";
            lblTime.Text = dt.Rows[0]["ConsumeTime"].ToString();
            lblPoint1.Text = dt.Rows[0]["disPointCount"].ToString() == "" ? dt.Rows[0]["PointCount"].ToString() : dt.Rows[0]["disPointCount"].ToString();
            lblStatus.Text = "已付款";
            lblPayType.Text = Tz888.Common.Common.GetPayType(dt.Rows[0]["payType"].ToString().Trim());
            lblOrder.Text = dt.Rows[0]["OrderNo"].ToString() == "" ? dt.Rows[0]["InfoID"].ToString() : dt.Rows[0]["OrderNo"].ToString();
            lblLoginName.Text = dt.Rows[0]["LoginName"].ToString() + "[" + dt.Rows[0]["NickName"].ToString() + "]";
            UserInfo(dt.Rows[0]["LoginName"].ToString());
        }
    }

    //未完成的订单信息
    public void bindWait()
    {
        DataTable dt = dal.GetList("ShopCarViw", "*", "ShopCarID", 1, 1, 0, 1, "OrderNo=" + ID);

        if (dt.Rows.Count > 0)
        {
            lblTitle.Text = "<a target='_blank' href='http://www.topfo.com/" + dt.Rows[0]["htmlfile"].ToString() + "'>" + dt.Rows[0]["SourceType"].ToString() + "</a>";
            lblTime.Text = dt.Rows[0]["packdate"].ToString();
            lblPoint1.Text = dt.Rows[0]["disworthpoint"].ToString() == "" ? dt.Rows[0]["worthpoint"].ToString() : dt.Rows[0]["disworthpoint"].ToString();
            lblOrder.Text = dt.Rows[0]["OrderNo"].ToString() == "" ? dt.Rows[0]["InfoID"].ToString() : dt.Rows[0]["OrderNo"].ToString();
            lblStatus.Text = "未付款";
            lblRemark.Text = dt.Rows[0]["Remark"].ToString() == "" ? "无" : dt.Rows[0]["Remark"].ToString();
            lblPayType.Text = dt.Rows[0]["PayTypeName"].ToString() == "" ? "无" : dt.Rows[0]["PayTypeName"].ToString();
            if (dt.Rows[0]["PayTypeCode"].ToString().Trim() == "bank" || dt.Rows[0]["PayTypeCode"].ToString().Trim() == "PostOffice")
            {
                OrderUserInfo(Convert.ToInt64(dt.Rows[0]["OrderNo"]));
            }
            else
            {
                UserInfo(dt.Rows[0]["LoginName"].ToString());
            }
        }

    }
    //购买用户信息
    public void UserInfo(string LoginName)
    {
        DataTable dt = dal.GetList("LoginInfoTab", "*", "LoginID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
        if (dt.Rows.Count > 0)
        {
            lblMobile.Text = "未填写";// dt.Rows[0]["MobileNo"].ToString();
            lblLoginName.Text = dt.Rows[0]["LoginName"].ToString() + "[" + dt.Rows[0]["NickName"].ToString() + "]";
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
            lblMobile.Text = dt.Rows[0]["MobileNo"].ToString();
            lblTel.Text = dt.Rows[0]["Tel"].ToString();
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblRealName.Text = dt.Rows[0]["RealName"].ToString() == "" ? "未填写" : dt.Rows[0]["RealName"].ToString();

        }
    }
}
