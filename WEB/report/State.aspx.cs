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
public partial class report_State : System.Web.UI.Page
{
    Tz888.BLL.report.InsStatic ins = new Tz888.BLL.report.InsStatic();
    string FieldPath = ConfigurationManager.AppSettings["INAppPath"].ToString(); //生成页面存放位置
    string FieldTem = ConfigurationManager.AppSettings["FieldTemd"].ToString(); //模版存放位置

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private string InName(int id)
    {
        Tz888.BLL.Advertorial.IndustryType bll = new Tz888.BLL.Advertorial.IndustryType();
        return bll.GetModel(id).industryName;
    }
    public string SelReport(int typeId)
    {
        StringBuilder sb = new StringBuilder();
        string strW = " where 1=1 ";
        if (typeId == 1)
        {
            strW += "order by createDate desc";
        }
        else if (typeId == 2)
        {
            strW += " and recommendID=1 and charges=1 order by createDate desc ";
        }
        else if (typeId == 3)
        {
            strW += " and charges=0 order by createDate desc";
        }
        string sql = "select  reportname,bigtypeid,html from dbo.reportTab" + strW;
        DataSet ds = Tz888.DBUtility.DBHelper.Query(sql);
        sb.Append("<div class=\"con1_sub\"><ul>");
        if (ds != null & ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                sb.Append("<li>·<a href='#' target=\"_blank\">[" + InName(int.Parse(row["bigtypeid"].ToString())) + "]</a><a href='http://sr.topfo.com/" + row["html"].ToString() + "' target=\"_blank\">" + row["reportname"].ToString() + "</a></li>");
            }
        }
        sb.Append("</ul></div><div class=\"con_mar\"></div>");
        return sb.ToString();
    }
    public int StaticHtml(string Field, int num, string title)
    {
        try
        {
            string Tem = Tz888.BLL.Compage.Reader(FieldTem.ToString()); //读取模板内容
            #region 替换模版
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$title$", title);
            TempSoure = TempSoure.Replace("$Field$", Field);
            #endregion
            string wenjian = FieldPath;
            if (!Directory.Exists(wenjian))
            {
                Directory.CreateDirectory(wenjian);
            }
            string htmlpaths = "";
            if (num == 1)//最新分析报告
            {
                htmlpaths = wenjian + "NewReport.html";
            }
            else if (num == 2)//推荐行业报告
            {
                htmlpaths = wenjian + "RecomReport.html";
            }
            else if (num == 3)//免费行业报告
            {
                htmlpaths = wenjian + "ChargesReport.html";
            }
            Tz888.BLL.Compage.Writer(htmlpaths, TempSoure);
            return 1;
        }
        catch (Exception e)
        {

            return 0;
        }
    }
    protected void btnZs_Click(object sender, EventArgs e)
    {
        int num = 0;
        for (int i = 1; i < 4; i++)
        {
            string institu = ins.SelReport(i);
            num = ins.StaticHtml(institu, i);
            if (num == 1)
            {
                Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");

            }
        }
        //int num = 0;
        //for (int i = 1; i < 4; i++)
        //{
        //    string institu = SelReport(i);
        //    string title = "";
        //    if (i == 1)
        //    {
        //        title = "最新行业分析报告";
        //    }
        //    else if (i == 2)
        //    {
        //        title = "推荐行业分析报告";
        //    }
        //    else if (i == 3)
        //    {
        //        title = "免费行业分析报告";
        //    }
        //    num = StaticHtml(institu, i, title);
        //    if (num == 1)
        //    {
        //        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        //    }
        //    else
        //    {
        //        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");


        //    }
        //}
    }
    protected void btnKX_Click(object sender, EventArgs e)
    {
        string newsStr = ins.strNews();
        int num = ins.StaticHtml(newsStr);
        if (num == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int num = 0;
        for (int i = 1; i < 4; i++)
        {
            string institu = SelReport(i);
            string title = "";
            if (i == 1)
            {
                title = "最新行业分析报告";
            }
            else if (i == 2)
            {
                title = "推荐行业分析报告";
            }
            else if (i == 3)
            {
                title = "免费行业分析报告";
            }
            num = StaticHtml(institu, i, title);
            if (num == 1)
            {
                Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");

            }
        }
    }
}
