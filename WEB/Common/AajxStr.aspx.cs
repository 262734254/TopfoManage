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

public partial class Common_AajxStr : System.Web.UI.Page
{
    private string loginName = "";
    BasePage bp = new BasePage();
    GZS.BLL.XHIndex.XHIndex index = new GZS.BLL.XHIndex.XHIndex();
    protected void Page_Load(object sender, EventArgs e)
    {
        //string type = Request["index"];

        loginName = bp.LoginName;
        DataSet ds = null;
        StringBuilder sb = new StringBuilder();
        string type = "";
        sb.Append("<ul>");
        for (int j = 0; j < 3; j++)
        {
            if (j == 0)
            {
                type = "Project";//融资
                ds = index.GetProject(type, 5, 1, "111222333");
                sb.Append("<li class=\"b\"><h3 style=\"background-image: url(images/pic3.gif); height: 46px\">融资项目</h3><ul>");
                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    DataRow dr = null;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dr = ds.Tables[0].Rows[i];
                        sb.Append("<li>");
                        sb.Append("<a target='_blank' href='http://www.topfo.com/" + dr["htmlFile"].ToString() + "'>");
                        sb.Append(GetLen(dr["title"].ToString()) + "</a>");
                        sb.Append("</li>");
                    }
                   
                }
                else
                {
                    sb.Append("<li><a href='#'>暂无数据"); sb.Append("</a></li>");

                }
                sb.Append("<p class=\"more\"><a href='http://rz.topfo.com/' target=\"_blank\">more</a></p>");
                sb.Append("</li>");
            }
            else if (j == 1)
            {
                type = "Capital";//投资
                ds = index.GetProject(type, 5, 1, "zhangcongbao");
                sb.Append("<li class=\"b\"><h3 style=\"background-image: url(images/pic2.gif); height: 46px\">投资项目</h3><ul>");
                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    DataRow dr = null;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dr = ds.Tables[0].Rows[i];
                        sb.Append("<li>");
                        sb.Append("<a target='_blank' href='http://www.topfo.com/" + dr["htmlFile"].ToString() + "'>");
                        sb.Append(GetLen(dr["title"].ToString()) + "</a>");
                        sb.Append("</li>");
                    }
                   
                }
                else
                {
                    sb.Append("<li><a href='#'>暂无数据"); sb.Append("</a></li>");

                }
                sb.Append("<p class=\"more\"><a href='http://tz.topfo.com/' target=\"_blank\">more</a></p>");
                sb.Append("</li>");
            }
            else
            {
                type = "Merchant";//招商
                ds = index.GetProject(type, 5, 1, "dgwlzs");
                sb.Append("<li class=\"b\"><h3 style=\"background-image: url(images/ico7.gif); height: 46px\">招商项目</h3><ul>");
                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    DataRow dr = null;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dr = ds.Tables[0].Rows[i];
                        sb.Append("<li>");
                        sb.Append("<a target='_blank' href='http://www.topfo.com/" + dr["htmlFile"].ToString() + "'>");
                        sb.Append(GetLen(dr["title"].ToString()) + "</a>");
                        sb.Append("</li>");
                    }
                   
                }
                else
                {
                    sb.Append("<li><a href='#'>暂无数据"); sb.Append("</a></li>");

                }
                sb.Append("<p class=\"more\"><a href='http://zs.topfo.com/' target=\"_blank\">more</a></p>");
                sb.Append("</li>");
            }
            #region
            //<ul><li class="b">
            //                <h3 style="background-image: url(images/pic3.gif); height: 46px">
            //                    融资项目</h3>
            //                <ul><li><a href="#">500万美元以上备用信用证担保贷</a></li></ul>
            //                <p class="more">
            //                    <a href="http://rz.topfo.com/" target="_blank">more</a></p>
            //            </li>
            //            <li class="b">
            //                <h3 style="background-image: url(images/pic2.gif); height: 46px">
            //                    投资项目</h3>
            //                <ul><li><a href="#">500万美元以上备用信用证担保贷</a></li></ul>
            //                <p class="more"><a href="http://tz.topfo.com/" target="_blank">more</a></p>
            //            </li>
            //            <li class="b">
            //                <h3 style="background-image: url(images/ico7.gif); height: 46px">
            //                    招商项目</h3>
            //                <ul><li><a href="#">500万美元以上备用信用证担保贷</a></li> </ul>
            //                <p class="more">
            //                    <a href="http://zs.topfo.com/" target="_blank">more</a></p>
            //            </li>
            //        </ul>
            #endregion

        } 
        sb.Append("</ul>");
        Response.Write(sb.ToString());
        // return sb.ToString();
    }
    private string GetLen(string title)
    {
        string str = "";
        if (title.Length>13)
        {
            str = title.Substring(0, 13).ToString();
        }
        else
        {
            str = title;
        }
        return str;
    }
}
