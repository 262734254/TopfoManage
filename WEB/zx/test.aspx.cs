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

public partial class zx_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        news.StaticWebService dal = new news.StaticWebService();
        //dal.CreateHtml(Convert.ToInt32("31201"), "testtestesafasasdsad", "2010-02-02", "jreljtlkrjlkdfjgkldfjglfdjglkdfgjlkf",);
    }
}
