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
using System.Data.SqlClient;

public partial class System_Process : System.Web.UI.Page
{
    Tz888.BLL.Login.LoginInfoBLL bll = new Tz888.BLL.Login.LoginInfoBLL();
    Tz888.BLL.Conn bllGet = new Tz888.BLL.Conn();
    public DataTable dt = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //删除数据
        if (Request.Form["DelData"] !="" && Request.Form["DelData"]=="1")
        {
            if (Request.Form["strID"] != null && Request.Form["strID"] != "")
            {
                string strID =Tz888.Common.Text.FormatDh(Request.Form["strID"].ToString(),",");

                int iCount = 0;
                string[] arr = strID.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (UpdateStatus(arr[i].ToString().Trim(), 1)>0)
                    {
                        UpdateStatus(arr[i].ToString().Trim(), 2);
                        iCount += 1;
                    }
                }
                if (iCount == arr.Length)
                {
                    Response.Write("1");
                }
                else
                {
                    Response.Write("2");
                }
            }
            else
                Response.Write("0");
        }

        //检查用户名是否可用
        if (Request.Form["ChkLoginNamePar"] != null && Request.Form["ChkLoginNamePar"] != "")
        {
            string strLoginName = Request.Form["ChkLoginNamePar"].ToString().Trim();

            dt = bllGet.GetList("employeeinfotab", "*", "loginname", 30, 1, 0, 0, " loginname='" + strLoginName + "'");
            //dt = bllGet.GetList("logininfotab", "*", "loginname", 30, 1, 0, 0, " loginname='" + strLoginName+"'");
            if(dt!=null && dt.Rows.Count>0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }
        }
    }

    //更新状态
    public int UpdateStatus(string strID, int iType)
    {
        return bll.UpdateStatus(strID, 0, iType);
    }


}
