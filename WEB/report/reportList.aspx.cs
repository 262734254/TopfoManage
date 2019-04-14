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
using Tz888.Model.report;
using Tz888.BLL.report;
using System.Text;
public partial class report_reportList : Tz888.Common.Pager.BasePage
{
    reportTabBLL reporttabbll = new reportTabBLL();
    ReportTab report = new ReportTab();
    reportViewBLL reportviewbll = new reportViewBLL();
    private static Tz888.BLL.Compage com = new Tz888.BLL.Compage();
    string PsStatic = ConfigurationManager.AppSettings["INAppPath"].ToString();
    private string par
    {
        get
        {
            return ViewState["par"].ToString();
        }
        set
        {
            ViewState["par"] = value;
        }
    }
    private int size
    {
        get
        {
            return Convert.ToInt32(ViewState["size"]);
        }
        set
        {
            ViewState["size"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            par = "";
            size = 20;
            if (Convert.ToInt32(Request["str"]) != 0)
            {
                int Id = Convert.ToInt32(Request["str"].ToString());
                DeleteLoansInfoTab(Id);
            }
            BindShow();
        }
    }

    private void DeleteLoansInfoTab(int Id)
    {
        ReportTab reporttab = reporttabbll.GetModel(Id);
        if (reporttab.Html != "")
        {
            string[] html = reporttab.Html.Split('/');//Professional/201103/Professional20110321_7.shtml
            string[] cc = html[2].Split('.');
            com.DeleteFile(@PsStatic + html[1].ToString() + @"\" + html[2].ToString());
        }
        if (reportviewbll.DeletereportView(Id) > 0)
        {
            if (reporttabbll.DeletereportTab(Id) > 0)
            {
                Response.Write("<script>alert('删除成功');location.href='reportList.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败');location.href='reportList.aspx'</script>");
            }
        } BindShow();
    }

    private void BindShow()
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        if (par == "")
        {
            par = " 1=1";
        }
        this.Pager1.PageSize = size;
        this.Pager1.StrWhere = par;
        this.Pager1.TableViewName = "reportTab,@";
        this.Pager1.KeyColumn = "reportID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "reportID";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    }
    //删除
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool flag = false;
        string[] values = Request.Form.GetValues("cbxSelect");
        //string[] values = Request.Form.GetValues("inType");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的资源!");
            return;
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in values)
            {

                string name = reporttabbll.GetModel(Convert.ToInt32(str.ToString().Trim())).Html;
                if (name != "")
                {
                    string[] html = name.Split('/');
                    string[] cc = html[2].Split('.');
                    com.DeleteFile(@PsStatic + html[1].ToString() + @"\" + html[2].ToString());
                }
                else
                {
                    sb.Append("编号:" + str.ToString().Trim() + ",删除失败\\n");
                }
                if (reportviewbll.DeletereportView(Convert.ToInt32(str.ToString().Trim())) > 0)
                {
                    if (reporttabbll.DeletereportTab(Convert.ToInt32(str.ToString().Trim())) > 0)
                    {
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                Response.Write("<script>location.href='reportList.aspx'</script>");
                //Response.Write("<script>alert('删除成功');location.href='reportList.aspx'</script>");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
            }
            this.BindShow();
        }
    }
    //生成
    protected void btnpublic_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要静态化的资源!");
            return;
        }
        else
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            foreach (string str in values)
            {
                report = reporttabbll.GetModel(int.Parse(str.ToString().Trim()));
                if (report.Auditid == 1)
                {
                    PageStatic stat = new PageStatic();
                    result = stat.StaticHtml(int.Parse(str.ToString().Trim()));
                    if (result <= 0)
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
                    }
                }
            }
            if (result > 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "生成成功");
            }
            else { Tz888.Common.MessageBox.Show(this.Page, "生成失败"); }
            BindShow();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string bianhao = "";
        string statu = "";
        if (txtnewstitle.Text.Trim() == "")
        {
            bianhao = "";
        }
        else { bianhao = " reportname='" + txtnewstitle.Text.Trim() + "'"; }

        if (Convert.ToInt32(ddrstuta.SelectedValue.Trim()) == -1)
        {
            statu = "";

        }
        else
        {
            if (txtnewstitle.Text.Trim() == "")
            {
                statu = " auditid=" + ddrstuta.SelectedValue.Trim();
            }
            else
            {
                statu = " and auditid=" + ddrstuta.SelectedValue.Trim();
            }
        }
        if (bianhao == "" && statu == "")
        {
            par = "";
        }
        else
        {
            par = "" + bianhao + statu;
        }
        BindShow();
    }
    protected string GetComm(int commId)//0:不1：推荐
    {
        string str = "";
        if (commId == 0)
        {
            str= "不推荐";
        }
        else if (commId == 1)
        {
            str = "<font color='red'>推荐</font>";
        }
        else if (commId == 2)
        {
            str = "推广资讯";
        }
        return str;
    }
    public string GetLaiyuan(int formid)
    {
        if (formid > 0)
        {
            IndustryFromBLL bll = new IndustryFromBLL();
            if (bll.GetModel(formid) != null)
            {
                return bll.GetModel(formid).industryName;
            }
            else
            {
                return "数据己被删除";
            }

        }
        else
        {
            return "暂无机构";
        }

        //string par = "";
        //if (formid == 1)
        //{
        //    par = "总站";
        //}
        //else { par = "拓富中心"; }
        //return par;
    }
    /// <summary>
    /// 去掉多余的字符
    /// </summary>
    /// <param name="strFile"></param>
    /// <param name="iLong"></param>
    /// <returns></returns>
    public string FormatNull(string strFile, int iLong)
    {
        if (strFile.GetType().ToString() == "System.DBNull")
            return "";
        else
        {
            if (iLong == 0)
                return strFile;
            else if (strFile.Length > iLong)
                return strFile.Substring(0, iLong) + "...";
            else
                return strFile;
        }
    }
    public string GetStatu(int stuta)
    {
        string strs = "";
        if (stuta == 0)
        {
            strs = "未审核";
        }
        else if (stuta == 1)
        {
            strs = "已审核";
        }
        return strs;
    }
}
