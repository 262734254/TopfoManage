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

public partial class System_DelUser :BasePage 
{
    Tz888.BLL.Sys.EmployeeInfoTab bll = new Tz888.BLL.Sys.EmployeeInfoTab();

    protected void Page_Load(object sender, EventArgs e)
    {
        //删除数据
        
        if (Request.QueryString["UserID"] != null && Request.QueryString["UserID"]!="")
        {
            
            //if (Request.Form["strID"] != null && Request.Form["strID"] != "")
            //{
            //    string strID = Tz888.Common.Text.FormatDh(Request.Form["strID"].ToString(), ",");

            //    int iCount = 0;
            //    string[] arr = strID.Split(',');
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        if (UpdateStatus(arr[i].ToString().Trim(), 1) > 0)
            //        {
            //            UpdateStatus(arr[i].ToString().Trim(), 2);
            //            iCount += 1;
            //        }
            //    }
            //    if (iCount == arr.Length)
            //    {
            //        Response.Write("1");
            //    }
            //    else
            //    {
            //        Response.Write("2");
            //    }
            //}
            //else
            //    Response.Write("0");

            string strUserID = Request.QueryString["UserID"].ToString().Trim();
            strUserID = Tz888.Common.Text.FormatDh(strUserID, ",");
            int iCount = 0;
            string[] arr = strUserID.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (UpdateStatus(arr[i].ToString()) > 0)
                {
                    iCount += 1;
                }
            }
            if (iCount == arr.Length)
            {
                Response.Redirect("SysUser.aspx",true);
            }
        }
    }

    //更新状态
    public int UpdateStatus(string strID)
    {
        return bll.DelEmployee(strID);
    }
}
