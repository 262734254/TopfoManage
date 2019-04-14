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

public partial class tuijian_kaiqi : BasePage
{



    protected void Page_Load(object sender, EventArgs e)
    {
        int RescID = Convert.ToInt16(Request.QueryString["UserID"].ToString());
        int StateID = Convert.ToInt16(Request.QueryString["audit"].ToString());
         
         //开启边关闭
        if (StateID == 1)
        {
            string strsql = "update RecommendedResources set StateID=0 where ResourceID=" + RescID;
          
            if (Tz888.DBUtility.DbHelperSQL.ExecuteSql(strsql) > 0)
            {
                //this.ClientScript.RegisterStartupScript(this.GetType(), "message", "<script language='javascript' defer>alert('成功');</script>");
                Response.Redirect("ResDongList.aspx");
            }

        }
        else
        {
            //关闭变开启

            string strsql = "update RecommendedResources set StateID=1 where ResourceID=" + RescID;

            if (Tz888.DBUtility.DbHelperSQL.ExecuteSql(strsql) > 0)
            {
               
                Response.Redirect("ResDongList.aspx");
            }
        }

    }
}
