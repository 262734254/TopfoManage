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
using System.Net;
using System.IO;

public partial class zycs_zycs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnIndex_Click(object sender, EventArgs e)
    {
        CreateStaticPage("http://zycs.topfo.com/index.aspx", "index.html");
    }

    protected void BtnIndex1_Click(object sender, EventArgs e)
    {
        CreateStaticPage("http://zycs.topfo.com/index1.aspx", "index1.html");
    }

    protected void ButIndex2_Click(object sender, EventArgs e)
    {
        CreateStaticPage("http://zycs.topfo.com/index2.aspx", "index2.html");
    }

    public void CreateStaticPage(string Url,string FileName)
    {
        string ErrorMessage = "";
        bool isError = false;
        Encoding code = Encoding.GetEncoding("gb2312");
        string str = null;
        StreamReader sr = null;
        //读取
        try
        {
            //读取远程路径
            WebRequest temp = WebRequest.Create(Url);
            WebResponse myTemp = temp.GetResponse();
            sr = new StreamReader(myTemp.GetResponseStream(), code);
            str = sr.ReadToEnd();
            if (str.Length > 0)
            {
                byte[] bytes = System.Text.Encoding.Unicode.GetBytes(str);
                zycsServices.WebService ser = new zycsServices.WebService();
                ser.CreateStaticPage(bytes, FileName);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            isError = true;
        }
        finally
        {
            if (sr != null)
                sr.Close();
        }

        if (isError)
        {
            ErrorMessage = "静态页面生成失败,错误消息:" + ErrorMessage;
        }
        if (ErrorMessage != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, ErrorMessage);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成成功!");
        }
    }
}
