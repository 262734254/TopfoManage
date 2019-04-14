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
using System.Xml;
using System.Text;

public partial class AD_ADListView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Url"] = null;
        if (!IsPostBack)
        {
            ReadAdXml();
        }
    }


    /// <summary>
    /// 解析AD.XML文件
    /// </summary>
    protected void ReadAdXml()
    {
        StringBuilder sbFrom = new StringBuilder();
        XmlDocument Xdoc = new XmlDocument();
        string name = Server.MapPath("XML/AD.xml");
        Xdoc.Load(name);
        XmlNode node = Xdoc.DocumentElement.LastChild;
        XmlNodeList listNode = node.ChildNodes;
        sbFrom.Append("<table id='table1' runat='server' class=\"one_table\">");
        sbFrom.Append("<tr >");
        sbFrom.Append("<th > 广告性质</th>");
        sbFrom.Append("<th > 广告类型</th>");
        sbFrom.Append("<th > 广告位置</th>");
        sbFrom.Append("<th > 图片地址</th>");
        sbFrom.Append("<th > 图片效果</th>");
        sbFrom.Append("<th > 地    址</th>");
        sbFrom.Append("<th > 操    作</th>");
        sbFrom.Append("</tr >");
        foreach (XmlNode xn in listNode)
        {
            XmlNodeList xn1 = xn.ChildNodes;
            sbFrom.Append("<tr>");
            foreach (XmlNode xn2 in xn1)
            {
                string channelid = null;
                //if (xn2.Name == "channelid")
                //{
                //    channelid = xn2.FirstChild.Value.ToString().Trim();
                //}
                //else
                //{
                XmlNodeList xn3 = xn2.ChildNodes;
                foreach (XmlNode xn4 in xn3)
                {
                    string adid = null;
                    string img = null;
                    string url = null;
                    XmlNodeList xn5 = xn4.ChildNodes;
                    if (xn2.Name == "channelname")
                    {
                        sbFrom.Append("<td colspan='6'>" + xn4.Value + "</td>");
                        //sbFrom.Append("<td align='center'><a href='ADUpLoadXml.aspx?Url="+channelid+"'>上传</a></td>");

                    }
                    if (xn2.Name == "channelid")
                    {
                        channelid = xn2.FirstChild.Value.ToString().Trim();
                        sbFrom.Append("<td align='center'><input type=\"button\" id=\"Button1\" value=\"上传文件\" class='btn' onclick=\"return Button1_onclick('" + channelid + "')\" />   <input type=\"button\" id=\"Button2\" value=\"查看记录\" class='btn' onclick=\"return Button2_onclick('" + channelid + "')\" /></td>");
                    }
                    if (xn5.Count > 0)
                    {
                        sbFrom.Append("<tr>");
                        foreach (XmlNode xn6 in xn5)
                        {
                            adid = xn4.FirstChild.FirstChild.Value.ToString().Trim();
                            if (xn6.Name != "adid" && xn6.Name != "adsname")
                            {
                                string value = null;
                                string va = null;
                                value = xn6.FirstChild.Value.ToString();
                                //if (xn6.FirstChild.Value.Length > 30)
                                //{
                                va = value.Substring(value.LastIndexOf("/") + 1);
                                //}
                                //else
                                //{
                                //va = value;
                                //}
                                if (value.Substring(value.LastIndexOf("/") + 1).Length > 0)
                                {
                                    va = va = value.Substring(value.LastIndexOf("/") + 1);
                                }
                                else
                                {
                                    va = value;
                                }
                                if (xn6.Name == "category")
                                {
                                    sbFrom.Append("<td>" + value + "</a></td>");
                                }
                                else
                                {
                                    sbFrom.Append("<td title='" + value + "'>" + va + "</td>");
                                }
                            }
                            if (xn6.Name == "ImageUrl")
                            {
                                img = xn6.FirstChild.Value;
                                ViewState["Url"] = img;
                                sbFrom.Append("<td><img style='width: 45px; height: 45px' src='" + img + "' /> </td>");
                            }
                            if (xn6.Name == "URL")
                            {
                                url = xn6.FirstChild.Value;
                            }
                        }
                        if (xn2.Name != "channelname")
                        {
                            sbFrom.Append("<td align='center'><a href='ADUpLoad.aspx?ImageUrl=" + img + "&URL=" + url + "&adid=" + adid + "'>上传</a>   <a href='ADDetail.aspx?adid=" + adid + "'>记录</a></td>");
                        }
                    }

                }
                //}
            }
            sbFrom.Append("</tr>");
            sbFrom.Append("</tr>");
        }
        sbFrom.Append("</table>");
        Div1.InnerHtml = sbFrom.ToString();
    }
}
