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

public partial class zsWebsite_ManageZsWebsite : System.Web.UI.Page
{
    private readonly Tz888.BLL.zsWebsite.zsWebsiteBLL bll = new Tz888.BLL.zsWebsite.zsWebsiteBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
                {
                    Del(Id);
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
                }
            }
            BindData("");
        }
    }


    public void Del(string Id)
    {
        if (bll.Delete(Id))
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
        }
    }

    public void BindData(string where)
    {
        try
        {
            int PageCurrent = Convert.ToInt32(this.AspNetPager1.CurrentPageIndex);
            int PageNum = 20;
            int TotalCount = 1;
            int PageCount = 1;
            AspNetPager1.PageSize = PageNum;
            DataTable dt = bll.GetzsWebsiteList("zsWebsite", "Id", "*", where, "Id desc", ref PageCurrent, PageNum, ref TotalCount);
            if (dt != null)
            {
                this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
                this.Website.DataSource = dt.DefaultView;
                Website.DataBind();
                if (TotalCount % PageNum > 0)
                    PageCount = TotalCount / PageNum + 1;
                else
                    PageCount = TotalCount / PageNum;
                this.pinfo.InnerText = Convert.ToString(TotalCount);//总条数
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData("");
    }

    protected void StaticPage_Click(object sender, EventArgs e)
    {
            StringBuilder sb = new StringBuilder();
            string ErrorMessage = "";
            Encoding code = Encoding.GetEncoding("gb2312");
            StreamReader sr = null;
            StreamWriter sw = null;
            string ProvinceName = "";
            try
            {
                sr = new StreamReader(@"J:\topfo\zs\zsurl\Template\index.html", code);
                string str = sr.ReadToEnd();
                DataTable dt = bll.GetProvicne();
                DataTable dt1 = bll.GetAllzsWebsite();
                if (dt != null && dt.Rows.Count > 0 && dt1 != null && dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ProvinceName = dt.Rows[i]["ProvinceName"].ToString();
                        sb.Append("<tr><td colspan=\"6\" class=\"col strong\"><div align=\"left\"><a name=\"" + ProvinceName + "\"></a>" + ProvinceName + "</div></td></tr>");
                        DataRow[] row = dt1.Select("ProvinceName='" + ProvinceName + "'");
                        int Count = row.Length;
                        if (Count > 0)
                        {
                            if (Count <= 6)
                            {
                                sb.Append("<tr>");
                                for (int j = 0; j < Count; j++)
                                {
                                    sb.Append("<td width=\"16%\"><div align=\"left\"><a href=\"" + row[j]["WebsiteUrl"].ToString() + "\" target=\"_blank\">" + row[j]["WebsiteName"].ToString() + "</a></div></td>");
                                }
                                int temp = 6 - Count;
                                for (int n = 0; n < temp; n++)
                                {
                                    sb.Append("<td width=\"16%\"><div align=\"left\">&nbsp;</div></td>");
                                }
                                sb.Append("</tr>");
                            }
                            else
                            {
                                if (Count % 6 == 0)
                                {
                                    int rows = Count / 6;
                                    for (int n = 0; n < rows; n++)
                                    {
                                        sb.Append("<tr>");
                                        for (int m = n * 6; m < n * 6 + 6; m++)
                                        {
                                            sb.Append("<td width=\"16%\"><div align=\"left\"><a href=\"" + row[m]["WebsiteUrl"].ToString() + "\" target=\"_blank\">" + row[m]["WebsiteName"].ToString() + "</a></div></td>");
                                        }
                                        sb.Append("</tr>");
                                    }
                                }
                                else
                                {
                                    int rows = ((6 - (Count % 6)) + Count) / 6;
                                    for (int n = 0; n < rows; n++)
                                    {
                                        sb.Append("<tr>");
                                        for (int m = n * 6; m < n * 6 + 6; m++)
                                        {
                                            if ((m + 1) > Count)
                                            {
                                                sb.Append("<td width=\"16%\"><div align=\"left\">&nbsp;</div></td>");
                                            }
                                            else
                                            {
                                                sb.Append("<td width=\"16%\"><div align=\"left\"><a href=\"" + row[m]["WebsiteUrl"].ToString() + "\" target=\"_blank\">" + row[m]["WebsiteName"].ToString() + "</a></div></td>");
                                            }
                                        }
                                        sb.Append("</tr>");
                                    }
                                }
                            }
                        }
                    }
                }
                str = str.Replace("$WebsiteList$", sb.ToString());
                sw = new StreamWriter(@"J:\topfo\zs\zsurl\index.html", false, code);
                sw.Write(str);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
                if (sw != null)
                    sw.Close();
            }

            if (ErrorMessage != "")
            {
                Tz888.Common.MessageBox.Show(this.Page, ErrorMessage = "静态页面生成失败,错误消息:" + ErrorMessage);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "生成成功!");
            }
    }
}
