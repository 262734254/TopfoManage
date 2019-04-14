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
using System.Text;
using System.Xml;

public partial class AD_ADDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                ReadADFileXml();
            }
        }
    }

    /// <summary>
    /// 解析ADMessage.xml文件
    /// </summary>
    protected void ReadADFileXml()
    {
        string str = Request.QueryString["adid"].ToString().Trim();
        StringBuilder sbFrom = new StringBuilder();
        XmlDocument Xdoc = new XmlDocument();
        string name = Server.MapPath("XML/ADMessage.xml");
        Xdoc.Load(name);
        XmlNode node = Xdoc.DocumentElement.FirstChild;
        XmlNodeList listNode = node.ChildNodes;
        sbFrom.Append("<table id='table1' runat='server'class=\"one_table\">");
        sbFrom.Append("<tr>");
        sbFrom.Append("<th> 页    面</th>");
        sbFrom.Append("<th> 修改日期</th>");
        sbFrom.Append("<th> 图片大小</th>");
        sbFrom.Append("<th> 修 改 人</th>");
        sbFrom.Append("</tr>");
        foreach (XmlNode xn in listNode)
        {
            XmlNodeList xn1 = xn.ChildNodes;
            foreach (XmlNode xn2 in xn1)
            {
                if (xn2.Name != "adid")
                {
                    if (xn.FirstChild.FirstChild.Value == str)
                    {
                        XmlNodeList xn3 = xn2.ChildNodes;
                        sbFrom.Append("<tr>");
                        foreach (XmlNode xn4 in xn3)
                        {
                            XmlNodeList xn5 = xn4.ChildNodes;
                            foreach (XmlNode xn6 in xn5)
                            {
                                sbFrom.Append("<td align='center'>" + xn6.Value + "</td>");
                            }
                        }
                        sbFrom.Append("</tr>");
                    }
                }
            }
        }
        sbFrom.Append("<tr>");
        sbFrom.Append("<td align='center' colspan='4'><a href='ADListView.aspx'>返回</a></td>");
        sbFrom.Append("</tr>");
        sbFrom.Append("</table>");
        Div1.InnerHtml = sbFrom.ToString();
    }
}
