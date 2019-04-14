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

public partial class Common_AajxStrs : System.Web.UI.Page
{
    GZS.BLL.XHIndex.XHIndex index = new GZS.BLL.XHIndex.XHIndex();
    DataSet ds = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //<div id="right_a">
        //       <li><h2 style="background-image: url(images/ico4.gif)">推荐项目</h2>
        //           <ul><li><a href="#">500万美元以上备用信用证担保贷</a></li>
        //           </ul></li></div>
        //   <div id="right_b">
        //       <li><h2 style="background-image: url(images/ico6.gif)">个人收藏</h2>
        //           <ul>
        //             <li><a href="#">500万美元以上备用信用证担保贷</a></li>
        //           </ul></li></div>
        //   <div id="right_c">
        //       <li><h2 style="background-image: url(images/pic4.gif)">专业服务</h2>
        //           <ul>li><a href="#">500万美元以上备用信用证担保贷</a></li></ul></li>
        //   </div>
        ds = index.GetRecommResoure(5, "cn001");
        StringBuilder sb = new StringBuilder();
        sb.Append("<div id=\"right_a\"><li><h2 style=\"background-image: url(images/ico4.gif)\">推荐项目</h2><ul>");
        if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
        {
            DataRow dr = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                sb.Append("<li>");
                sb.Append("<a target='_blank' href=http://www.topfo.com/" + dr["resourceURL"].ToString() + ">");

                sb.Append(GetLen(dr["resourceTitle"].ToString()) + "</a>");
                sb.Append("</li>");
            }
        }
        else
        {
            sb.Append("<li><a href='#'>暂无数据"); sb.Append("</a></li>");

        }
        sb.Append("</ul></li></div>");
        sb.Append(" <div id=\"right_b\"> <li><h2 style=\"background-image: url(images/ico6.gif)\">个人收藏</h2><ul>");
        ds = index.GetCollection(5, "eclatcn");

        if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
        {
            DataRow dr = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                sb.Append("<li>");
                sb.Append("<a target='_blank' href=http://www.topfo.com/" + dr["HtmlFile"].ToString() + ">");

                sb.Append(GetLen(dr["title"].ToString()) + "</a>");
                sb.Append("</li>");
            }
        }
        else
        {
            sb.Append("<li><a href='#'>暂无数据"); sb.Append("</a></li>");

        }
        sb.Append("</ul></li></div>");
        sb.Append("<div id=\"right_c\"> <li><h2 style=\"background-image: url(images/pic4.gif)\">专业服务</h2><ul>");
        ds = index.GetProfessional(5, "cn001");
      
        if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
        {
            DataRow dr = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dr = ds.Tables[0].Rows[i];
                sb.Append("<li>");
                sb.Append("<a target='_blank' href=http://www.topfo.com/" + dr["htmlURL"].ToString() + ">");
                sb.Append(GetLen(dr["titel"].ToString()) + "</a>");
                sb.Append("</li>");
            }
        }
        else
        {
            sb.Append("<li><a href='#'>暂无数据"); sb.Append("</a></li>");

        }
        sb.Append("</ul></li></div>");
        Response.Write(sb.ToString());
    }
    private string GetLen(string title)
    {
        string str = "";
        if (title.Length > 14)
        {
            str = title.Substring(0, 14).ToString();
        }
        else
        {
            str = title;
        }
        return str;
    }
}
