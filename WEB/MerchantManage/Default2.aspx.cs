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

public partial class MerchantManage_Default2 : System.Web.UI.Page
{
    public string strs = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "JavaScript特效,JS效果,Js代码,Java特效,Javascript代码,JS脚本,Js是什么意思,Java,Java游戏";
        string[] strChild = str.Split(',');
        strs = "";
        for (int s = 0; s < strChild.Length; s++)
        {
            strs += "'" + strChild[s].ToString() + "',";
        }
        if (strs.ToString().EndsWith(","))
        {
            strs = strs.ToString().Substring(0, strs.ToString().Length - 1);
        }
    }
}
