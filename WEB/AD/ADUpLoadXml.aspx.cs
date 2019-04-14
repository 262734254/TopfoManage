using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Configuration;


public partial class AD_XML_ADUpLoadXml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["channelid"] != null || Request.QueryString["channelid"] != "")
                {
                    ViewState["channelid"] = Request.QueryString["channelid"].ToString().Trim();
                    ReadADFileXml();
                }
            }
        }
    }

    /// <summary>
    /// 解析ADFile.XMl文件
    /// </summary>
    protected void ReadADFileXml()
    {
        XmlDocument Xdoc = new XmlDocument();
        string name = Server.MapPath("XML/ADFile.xml");
        Xdoc.Load(name);
        XmlNode node = Xdoc.DocumentElement.LastChild;
        XmlNodeList listNode = node.ChildNodes;
        foreach (XmlNode xn in listNode)
        {
            if (xn.FirstChild.FirstChild.Value.ToString().Trim() == ViewState["channelid"].ToString().Trim())
            {
                XmlNodeList xn1 = xn.ChildNodes;
                foreach (XmlNode xn2 in xn1)
                {
                    XmlNodeList xn3 = xn2.ChildNodes;
                    foreach (XmlNode xn4 in xn3)
                    {
                        XmlNodeList xn5 = xn4.ChildNodes;
                        foreach (XmlNode xn6 in xn5)
                        {
                            if (xn4.Name == "address")
                            {
                                this.txtUpLoadAdr.Text = xn6.Value.ToString().Trim();
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 上传XML文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        // string file = "E:\\8-5\\TopfoManage\\WEB\\AD\\XML" + "AD.xml";
        //string file = System.Configuration.ConfigurationManager.AppSettings["UpLoadXml"].ToString() + "AD.xml";

        FileInfo fileInfo = new FileInfo(Server.MapPath("XML/AD.xml"));
        string file = this.txtUpLoadAdr.Text.ToString().Trim() + "AD.xml";
        try
        {
            if (fileInfo.Exists)
            {
                fileInfo.CopyTo(file, true);
                UpdateXml();         //修改ADFile.xml文件
                Response.Write("<script>alert(\"上传文件成功！\");location.href='ADListView.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert(\"上传文件不能为空！\");location.href='ADUpLoadXml.aspx';</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert(\"" + ex.Message + "\");location.href='ADListView.aspx';</script>");
        }
        finally
        {
            //UpdateXml();         //修改ADFile.xml文件
        }
    }

    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ADListView.aspx");
    }

    /// <summary>
    /// 修改ADFile.xml文件
    /// </summary>
    public void UpdateXml()
    {
        string loginName = Session["LoginName"].ToString();
        //string loginName = "UserName1";
        string dateTime = DateTime.Now.ToString();
        XmlDocument Xdoc = new XmlDocument();
        string name = Server.MapPath("XML/ADFile.xml");
        Xdoc.Load(name);
        XmlNode node = Xdoc.DocumentElement.LastChild;
        XmlNodeList listNode = node.ChildNodes;
        foreach (XmlNode xn in listNode)
        {
            if (xn.FirstChild.FirstChild.Value.ToString().Trim() == ViewState["channelid"].ToString().Trim())
            {
                XmlNodeList xn1 = xn.ChildNodes;
                foreach (XmlNode xn2 in xn1)
                {
                    XmlNodeList xn3 = xn2.ChildNodes;
                    foreach (XmlNode xn4 in xn3)
                    {
                        XmlNodeList xn5 = xn4.ChildNodes;
                        foreach (XmlNode xn6 in xn5)
                        {
                            if (xn4.Name == "dates")
                            {
                                xn6.Value = dateTime;
                            }
                            if (xn4.Name == "UserName")
                            {
                                xn6.Value = loginName;
                            }
                        }
                    }
                }
            }
        }
        Xdoc.Save(Server.MapPath("XML/ADFile.xml"));
    }
}
