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

public partial class wyzs_GenStatic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //首页
    protected void btnIndex_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.Index();
            
        }
        catch (Exception ex)
        {

            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        if (num > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }

        // GenerateStaticPage("index.aspx", "index.html");
    }
    //写字楼
    protected void btnWrite_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.Write();
        }
        catch (Exception ex)
        {

            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        if (num > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        // GenerateStaticPage("index_01.aspx", "index_01.html");
    }
    //购物中心
    protected void btnShopCenter_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.ShopCenter();
        }
        catch (Exception ex)
        {

            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        if (num > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        //GenerateStaticPage("index_02.aspx", "index_02.html");
    }
    //商业街
    protected void btnBusinessStreet_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.BusinessStreet();
        }
        catch (Exception ex)
        {

            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        if (num > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        // GenerateStaticPage("index_03.aspx", "index_03.html");
    }
    //批发市场
    protected void btnSale_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.Sale();
        }
        catch (Exception ex)
        {

            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        if (num > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        // GenerateStaticPage("index_04.aspx", "index_04.html");
    }
    //商铺
    protected void btnRetailShop_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.RetailShop();
        }
        catch (Exception ex)
        {

            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        if (num>0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        // GenerateStaticPage("index_05.aspx", "index_05.html");
    }
    //厂房
    protected void btnYardHouse_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.YardHouse();
        }
        catch (Exception ex)
        {

            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        if (num > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        //GenerateStaticPage("index_06.aspx", "index_06.html");
    }
    //配套服务
    protected void btnMatingService_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.MatingService();
        }
        catch (Exception ex)
        {

            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        if (num > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        // GenerateStaticPage("index_07.aspx", "index_07.html");
    }
    //全部生成
    protected void btnAllGenerate_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.AllGenerate();
        }
        catch (Exception ex)
        {

            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        if (num > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        //for (int i = 0; i < 7; i++)
        //{
        //    if (i == 0)
        //    {
        //        GenerateStaticPage("index.aspx", "index.html");
        //    }
        //    else
        //    {
        //        GenerateStaticPage("index_0" + i + ".aspx", "index_0" + i + ".html");
        //    }
        //}

    }
    /// <summary>
    /// 生成页面
    /// </summary>
    /// <param name="url">传入要生成的URL</param>
    /// <param name="fileName">生成的文件名</param>
    /// <returns></returns>
    private void GenerateStaticPage(string url, string fileName)
    {

        Encoding code = Encoding.GetEncoding("gb2312");
        StreamReader sr = null;
        StreamWriter sw = null;
        string str = null;
        string urls = "http://wyzs.topfo.com/" + url;
        //读取远程路径
        WebRequest temp = WebRequest.Create(urls);
        WebResponse myTemp = temp.GetResponse();
        sr = new StreamReader(myTemp.GetResponseStream(), code);
        //读取
        try
        {
            sr = new StreamReader(myTemp.GetResponseStream(), code);
            str = sr.ReadToEnd();

        }
        catch (Exception ex)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
        finally
        {
            sr.Close();
        }
        //写入
        try
        {
            sw = new StreamWriter(@"D:\wyzs.topfo.com\" + fileName, false, code);
            sw.Write(str);
            sw.Flush();

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败!");
        }
        if (sw != null)
        {
            sw.Close();
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败3");
        }
    }
}
