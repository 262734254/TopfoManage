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
using System.IO;

public partial class AD_ADUpLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                string Url = Request.QueryString["URL"].ToString().Trim();
                ViewState["adid"] = Request.QueryString["adid"].ToString().Trim();
                this.txtLinkAdr.Text = Url;
            }
        }
    }

    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string houzhui = FileUp.PostedFile.FileName.Substring(this.FileUp.PostedFile.FileName.LastIndexOf(".") + 1);
        string ImageUrl = Request.QueryString["ImageUrl"].ToString().Trim();
        string imageUrl = ImageUrl.Substring(ImageUrl.LastIndexOf("/") + 1);
        string Url = this.txtLinkAdr.Text.ToString().Trim();
        string image = "http://www.topfo.com/AdImg/ad/" + imageUrl;
        string adid = ViewState["adid"].ToString().Trim();
        string LoginName = Session["LoginName"].ToString();
        string riqi = DateTime.Now.ToString();
        try
        {
            if (this.FileUp.PostedFile.ContentLength >1000000)
            {
                Response.Write("<script>alert(\"上传图片太大！\");</script>");
                return;
            }
            if (this.FileUp.FileName.Length == 0)
            {
                houzhui = ImageUrl.Substring(ImageUrl.LastIndexOf(".") + 1);
                UpdateXml(Url, adid);
                UpdateXmlMessage(LoginName, riqi, adid);
                Response.Write("<script>alert(\"修改成功！\");location.href='ADListView.aspx';</script>");
            }
            //string ImageUrl = this.FileUp.PostedFile.FileName.Substring(this.FileUp.PostedFile.FileName.LastIndexOf("\\") + 1);
            else if (houzhui == "gif" || houzhui == "jpg" || houzhui == "JPG"||houzhui=="GIF")
            {
                FileUp.PostedFile.SaveAs("J:/topfo/tzWeb/AdImg/ad/" + imageUrl);
                UpdateXml(Url, adid);
                UpdateXmlMessage(LoginName, riqi, adid);
                Response.Write("<script>alert(\"上传文件成功！\");location.href='ADListView.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert(\"上传文件必须是gif,jpg,bmp格式！\");location.href='ADUpLoad.aspx';</script>");
                return;
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert(\""+ex.Message+"\");</script>");
        }
    }

    /// <summary>
    /// 修改xml文件
    /// </summary>
    public void UpdateXml(string url,string adid)
    {
        XmlDocument Xdoc = new XmlDocument();
        string name = Server.MapPath("XML/AD.xml");
        Xdoc.Load(name);
        XmlNode node = Xdoc.DocumentElement.LastChild;
        XmlNodeList listNode = node.ChildNodes;
        foreach (XmlNode xn in listNode)
        {
            XmlNodeList xn1 = xn.ChildNodes;
            foreach (XmlNode xn2 in xn1)
            {
                XmlNodeList xn3 = xn2.ChildNodes;
                foreach (XmlNode xn4 in xn3)
                {
                    if (xn4.FirstChild != null)
                    {
                        if (xn4.FirstChild.FirstChild.Value == adid)
                        {
                            XmlNodeList xn5 = xn4.ChildNodes;
                            foreach (XmlNode xn6 in xn5)
                            {
                                //if (xn6.Name == "ImageUrl")
                                //{
                                //    xn6.InnerText = image;
                                //}
                                if (xn6.Name == "URL")
                                {
                                    xn6.InnerText = url;
                                }
                            }
                        }
                    }
                }
            }
        }
        Xdoc.Save(Server.MapPath("XML/AD.xml"));
    }

    /// <summary>
    /// 修改信息
    /// </summary>
    /// <param name="?"></param>
    /// <param name="?"></param>
    public void UpdateXmlMessage(string LoginName,string riqi,string adid)
    {
        XmlDocument Xdoc = new XmlDocument();
        string name = Server.MapPath("XML/ADMessage.xml");
        Xdoc.Load(name);
        XmlNode node = Xdoc.DocumentElement.LastChild;
        XmlNodeList listNode = node.ChildNodes;
        foreach (XmlNode xn in listNode)
        {
            XmlNodeList xn1 = xn.ChildNodes;
            if (xn.FirstChild.FirstChild.Value == adid)
            {
                foreach (XmlNode xn2 in xn1)
                {
                    XmlNodeList xn3 = xn2.ChildNodes;
                    foreach (XmlNode xn4 in xn3)
                    {
                        if (xn4.Name == "date")
                        {
                            xn4.InnerText = riqi;
                        }
                        if (xn4.Name == "User")
                        {
                            xn4.InnerText = LoginName;
                        }
                    }
                }
            }
        }
        Xdoc.Save(Server.MapPath("XML/ADMessage.xml"));
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
}


