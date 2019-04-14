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
using System.Net;
using System.IO;
using System.Text;
using Tz888.BLL.FenZhan;
using Tz888.BLL.Common;
using System.Text.RegularExpressions;
using System.DirectoryServices;

public partial class FenZhan_FenZhanManage : System.Web.UI.Page
{
    private readonly FenZhanBLL bll = new FenZhanBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Address"] != null)
            {
                int Error = 0;
                string Address = Request.QueryString["Address"];
                string temp = Regex.Match(Address, @"//\w*?\.").Value.Replace("//", "").Replace(".", "");
                string SvaePath = @"G:\fz\" + temp + @".topfo.com\";
                CreateIndex(Address, SvaePath, ref Error);
                if (Error > 0)
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成失败!");
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成成功!");
                }
            }
            BindData();
        }
    }

    public void BindData()
    {
        FenZhanList.DataSource = bll.GetFenZhanList();
        FenZhanList.DataBind();
    }

    public void CreateIndex(string Address, string SvaePath,ref int Error)
    {
        string responseFromServer = "";
        StreamWriter sw = null;
        HttpWebRequest request;
        HttpWebResponse response = null;
        try
        {
            request = WebRequest.Create(Address) as HttpWebRequest;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.KeepAlive = false;
            request.Timeout = 180 * 1000; //设置时间为3分钟
            response = (HttpWebResponse)request.GetResponse();
            if (request.HaveResponse == true && response != null)//如果在三分钟内得到了远程网页返回的内容就读取
            {
                HttpContext.Current.Response.Write(response.StatusDescription);
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream, Encoding.Default);
                responseFromServer = reader.ReadToEnd(); //远程网页返回的内容                 
                reader.Close();
                dataStream.Close();
                response.Close();
            }
        }
        catch (WebException wex)
        {
            if (wex.Response != null)
            {
                using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                {
                    Error++;
                    //Tz888.Common.MessageBox.Show(this.Page, "The server returned '{0}' with the status code {1} ({2:d}).",
                    //errorResponse.StatusDescription, errorResponse.StatusCode,
                    //errorResponse.StatusCode);
                }
            }
        }
        finally
        {
            if (response != null)
            {
                response.Close(); 
            }
        }

        //写入
        if (responseFromServer != "")
        {
            try
            {
                if (!Directory.Exists(SvaePath))
                {
                    Directory.CreateDirectory(SvaePath);
                }
                Encoding code = Encoding.GetEncoding("gb2312");
                sw = new StreamWriter(SvaePath + "index.html", false, code);
                sw.Write(responseFromServer);
                sw.Flush();
            }
            catch (Exception ex)
            {
                Error++;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }

    protected void BtnDelChecked_Click(object sender, EventArgs e)
    {
        if (FenZhanList.Items.Count > 0)
        {
            int Count = 0;
            int Error = 0;
            for (int i = 0; i < FenZhanList.Items.Count; i++)
            {
                CheckBox Cbox = FenZhanList.Items[i].FindControl("Cbox") as CheckBox;
                if (Cbox.Checked)
                {
                    Label obj = FenZhanList.Items[i].FindControl("Address") as Label;
                    string Address = obj.Text;
                    string temp = Regex.Match(Address, @"//\w*?\.").Value.Replace("//", "").Replace(".", "");
                    string SvaePath = @"G:\fz\" + temp + @".topfo.com\";
                    CreateIndex(Address, SvaePath, ref Error);
                    Count = Count + Error;
                }
            }
            if (Count > 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "全部生成失败!");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "全部生成成功!");
            }
            BindData();
        }
    }
}


   
