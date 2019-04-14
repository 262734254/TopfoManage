using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Text;
using Tz888.BLL.Login;
using System.Web.Caching;
using System.Collections.Generic;
using System.Xml;


/// <summary>
/// TopfoInfo 的摘要说明
/// </summary>
[WebService(Namespace = "http://www.topfo.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class TopfoInfo : System.Web.Services.WebService
{

    public TopfoInfo()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetContactDetail(string InfoID)
    {
        StringBuilder sb = new StringBuilder();
        string LoginName = "";

        #region 资源是否购买的提示信息

        //string WhetherCharges_button = "";  //按钮提示
        //string WhetherCharges_Clew = "";    //提示信息
        int FixPriceID = 0;            //资源是否收费
        string infoTypeName = "";   
        decimal MainPointCount = 0;    //资源报价
        string userState = "Charge";         // Charge购买 / Login登陆 / View查看
        string payDomain = System.Configuration.ConfigurationManager.AppSettings["payDomain"];
        string buyUrl = payDomain + "/order_item.aspx?InfoID=" + InfoID;    //资源购买的路径
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("MainInfoTab", "InfoID,FixPriceID,MainPointCount,InfoType", "InfoID", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));
        if (dt != null && dt.Rows.Count > 0)
        {
            FixPriceID = Convert.ToInt32(dt.Rows[0]["FixPriceID"].ToString().Trim());
            MainPointCount = Convert.ToDecimal(dt.Rows[0]["MainPointCount"].ToString().Trim());
            infoTypeName = dt.Rows[0]["InfoType"].ToString().Trim();
        }
        if (MainPointCount > 0 && FixPriceID > 1)       //是否免费信息
        {
            bool bIsBuy = false;                        //这是一条收费信息   
            Tz888.BLL.Info.CapitalInfoBLL ciBll = new Tz888.BLL.Info.CapitalInfoBLL();
            bIsBuy = ciBll.bIsBuyInfoOfUser(LoginName, InfoID);
            if (bIsBuy)
            {
                userState = "View";
            }
            else
            {
                userState = "Charge";
            }
        }
        else
        {
            userState = "View";
        }
        switch (userState)
        {
            case "View":    //提示查看
                //WhetherCharges_button = "<a href=\"#88\" onclick=\"javascript:GetContactDetail(" + InfoID + ");\" ><img src=\"/CommonV3/img/res3_btn13.gif\" alt=\"请点击查看\"></a>";
                //WhetherCharges_Clew = "<span class=\"tit f_tit3\">以下为项目核心资料，你需要购买才能查看！</span><span class=\"btn\">" +
                //    "<a href=\"#88\" onclick=\"javascript:GetContactDetail(" + InfoID + ");\"><img src=\"/CommonV3/img/res3_btn13.gif\" alt=\"点击查看\" /></a></span>" +
                //    "<div class=\"clear\"></div>";
                sb.Append("");
                break;
            case "Charge":  //提示购买
                //WhetherCharges_button = "<a href=\"" + buyUrl + "\"><img src=\"/CommonV3/img/res3_btn7.gif\" alt=\"请点击购买\"></a>";
                //WhetherCharges_Clew = "<span class=\"tit f_tit3\">以下为项目核心资料，你需要购买才能查看！</span><span class=\"btn\">" +
                //    "<a href=\"" + buyUrl + "\"><img src=\"/CommonV3/img/res3_btn7.gif\" alt=\"点击购买\" /></a></span>" +
                //    "<div class=\"clear\"></div>";
                break;
        }
        return sb.ToString().Trim();
        #endregion
    }

}

