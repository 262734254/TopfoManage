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
public partial class report_test : System.Web.UI.Page
{
    public string strs = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //GridView1.DataSource = a(1);
        //GridView1.DataBind();
        
           strs= SelReport(1);
        
    }
    public DataSet a(int typeId)
    {
        string strW = " where 1=1 ";
        if (typeId == 1)
        {
            strW += "order by createDate desc";
        }
        else if (typeId == 2)
        {
            strW += " and recommendID=1 and charges=1 ";
        }
        else if (typeId == 3)
        {
            strW += " and charges=0 order by createDate desc";
        }
        string sql = "select reportID, reportname,createDate,bigtypeid,html from dbo.reportTab" + strW;
        DataSet ds = Tz888.DBUtility.DBHelper.Query(sql);
        return ds;
    }
    public string SelReport(int typeId)
    {
        StringBuilder sb = new StringBuilder();
        string title = string.Empty;
        string strW = " where 1=1 ";
        if (typeId == 1)
        {
            strW += "order by createDate desc";
            title = "最新行业分析报告";
        }
        else if (typeId == 2)
        {
            strW += " and recommendID=1 and charges=1 order by createDate desc ";
            title = "推荐行业分析报告";
        }
        else if (typeId == 3)
        {
            strW += " and charges=0 order by createDate desc";
            title = "免费行业分析报告";
        }
        string sql = "select  reportID, reportname,createDate,bigtypeid,html from dbo.reportTab" + strW;
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
    public string InName(int id)
    {
        Tz888.BLL.Advertorial.IndustryType bll = new Tz888.BLL.Advertorial.IndustryType();
        return bll.GetModel(id).industryName;
    }
}
