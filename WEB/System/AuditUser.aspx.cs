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

public partial class System_AuditUser : BasePage   // System.Web.UI.Page
{
    Tz888.BLL.Login.LoginInfoBLL bll = new Tz888.BLL.Login.LoginInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        //审核用户
        if (Request.QueryString["UserID"] != null && Request.QueryString["UserID"] != "")
        {
            if (Request.QueryString["audit"] != null && Request.QueryString["audit"] != "")
            {
                string strUserID = Request.QueryString["UserID"].ToString().Trim();
                int iAudit = Tz888.Common.Text.FormatData(Request.QueryString["audit"].ToString().Trim());
                if (UpdateStatus(strUserID, iAudit, 2) > 0)
                {
                    Response.Redirect("SysUser.aspx", true);
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "账户（strUserID）的状态修改失败！");
                }
            }
        }
    }

    /// <summary>
    /// //更新状态
    /// </summary>
    /// <param name="strID">用户id</param>
    /// <param name="iType">0=不可用,1=可用</param>
    /// <param name="iType">2=employeeinfotab表</param>
    /// <returns></returns>
    public int UpdateStatus(string strID,int iAudit, int iType)
    {
        return bll.UpdateStatus(strID, iAudit, iType);
    }

}
