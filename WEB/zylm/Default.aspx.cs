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

public partial class zylm_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButIndex_Click(object sender, EventArgs e)
    {
        string ErrorMessage = "";
        bool isError = false;
        Encoding code = Encoding.GetEncoding("utf-8");
        string str = null;
        string urls = "http://zy.topfo.com/template/index.aspx";
        StreamReader sr = null;
        //读取
        try
        {
            //读取远程路径
            WebRequest temp = WebRequest.Create(urls);
            WebResponse myTemp = temp.GetResponse();
            sr = new StreamReader(myTemp.GetResponseStream(), code);
            str = sr.ReadToEnd();
            if (str.Length > 0)
            {
                byte[] bytes = System.Text.Encoding.Unicode.GetBytes(str);
                ZylmServices.WebService ser = new ZylmServices.WebService();
               // isError = ser.CreateZylmIndex(bytes);有问题
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
