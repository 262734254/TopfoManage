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
using System.IO;
using System.Net;
public partial class State_Static : System.Web.UI.Page
{
    Tz888.BLL.MerchantManage.PageStatic  page= new Tz888.BLL.MerchantManage.PageStatic();
    Tz888.BLL.StaticBLL st = new Tz888.BLL.StaticBLL();
    //Tz888.BLL.StaticBLL search = new Tz888.BLL.StaticBLL();
    Tz888.BLL.SearchStatic.SearchStatic search = new Tz888.BLL.SearchStatic.SearchStatic();
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }
    protected void btnZs_Click(object sender, EventArgs e)
    {
        string zs = st.SelMerchant();
        int num = st.StaticHtml(zs, "1");//招商静态生成
        if (num == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");

        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
 
        }
    }
    protected void btnTz_Click(object sender, EventArgs e)
    {
        string tz = st.SelCapital();
         int num = st.StaticHtml(tz,"3");//投资静态生成
          if (num == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");

        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
 
        }
    }
    protected void btnRz_Click(object sender, EventArgs e)
    {
        string rz = st.SelProject();
         int num = st.StaticHtml(rz,"2");//融资静态生成
          if (num == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");

        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
 
        }
    }


    protected void btnFw_Click(object sender, EventArgs e)
    {
        string fu = st.SelFuWu();
        int num = st.StaticHtml(fu, "4");//专业服务需求
        if (num == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");

        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");

        }
    }
    /// <summary>
    /// 资本资源静态页面生成
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnZiBen_Click(object sender, EventArgs e)
    {

        string fu = st.SelProject1();//融资
        int num = search.StaticHtml(fu, "2");//融资
        if (num == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");

        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");

        }
    }
   /// <summary>
    /// 企业项目资源推荐
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void btnqy_Click(object sender, EventArgs e)
    {
        string fu = st.SelCapital1(); //投资
        int num = search.StaticHtml(fu, "3");//投资
        if (num == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");

        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");

        }
    }
    /// <summary>
    /// 政府项目资源推荐
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnzf_Click(object sender, EventArgs e)
    {
        string fu = st.SelMerchant1();
        int num = search.StaticHtml(fu, "1");//政府项目资源推荐
        if (num == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");

        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");

        }
    }
    protected void btnIndex_Click(object sender, EventArgs e)
    {
        string fileName = "indexv4.htm";
        Encoding code = Encoding.GetEncoding("gb2312");
        StreamReader sr = null;
        StreamWriter sw = null;
        string str = null;

        //读取远程路径
        WebRequest temp = WebRequest.Create("http://topfo.topfo.com/IndexTest.aspx");
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
           sw = new StreamWriter(@"J:\topfo\tzWeb\" + fileName, false, code);
            //sw = new StreamWriter("F:/topfo/tzweb/News/" + fileName, false, code);
            sw.Write(str);
            sw.Flush();

        }
        catch (Exception ex)
        {
        
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败2!");

        }
        if (sw != null)
        {
            sw.Close();
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败1");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        int num = 0;
        try
        {
            com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
            num = gen.QyIndex();

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
    }
}
