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

public partial class Controls_StatusInfo : System.Web.UI.UserControl
{
    private string _Message;   //状态条提示消息

    #region 属性
    public string Message
    {
        get { return _Message; }
        set { _Message = value; }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(Page.User.Identity.Name))
        //{
        //    Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        //    return;
        //}
        try
        {
            string strLoginName = Page.User.Identity.Name;
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            long CurrPage = 0;
            long TotalCount = 0;

            string strWhere = "loginName='" + strLoginName + "'";
            DataTable dt = dal.GetList("LoginInfoTab", "loginName",
                "nickName", strWhere, "loginName", ref CurrPage, 0, ref TotalCount);
            string nickName = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                nickName = dt.Rows[0][0].ToString().Trim();
            }
            lblWelcome.Text = "     " + "您的用户登录名：" + strLoginName + "    " + "您的姓名:" + nickName + "          ";
        }
        catch
        {
        }
    }
}
