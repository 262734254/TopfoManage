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
public partial class news_NewsTabManage : Tz888.Common.Pager.BasePage
{
    Tz888.BLL.news.NewsTabBLL newstabbll = new Tz888.BLL.news.NewsTabBLL();
    Tz888.BLL.news.NewsTypeTabBLL newstypetabbll = new Tz888.BLL.news.NewsTypeTabBLL();
    Tz888.BLL.news.NewsViewTabBLL newsviewtabbll = new Tz888.BLL.news.NewsViewTabBLL();
    private static Tz888.BLL.Compage com = new Tz888.BLL.Compage();
    string CasesTem = ConfigurationManager.AppSettings["DKNewsSuccse"].ToString();
    string PsStatic = ConfigurationManager.AppSettings["DKNewsIndex"].ToString();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlType.DataSource = newstypetabbll.GetAllNewsType();
            this.ddlType.DataValueField = "TypeID";
            this.ddlType.DataTextField = "TypeName";
            this.ddlType.DataBind();
            ListItem item = new ListItem();
            item.Value = "-1";
            item.Text = "请选择";
            ddlType.Items.Add(item);
            this.ddlType.Items.FindByValue("-1").Selected = true;
            size = 20;
            par = "";

            if (Convert.ToInt32(Request["str"]) != 0)
            {
                int Id = Convert.ToInt32(Request["str"].ToString());
                DeleteLoansInfoTab(Id);
            }
            BindShow();
        }
    }
    public string GetLaiyuan(int formid)
    {
        string par = "";
        if (formid == 1)
        {
            par = "总站";
        }
        else { par = "拓富中心"; }
        return par;
    }
    private void DeleteLoansInfoTab(int Id)
    {
        Tz888.Model.NewsTab newstab = newstabbll.GetNewsTabByNewId(Id);
        int result2 = newsviewtabbll.DeleteNewsViewTab(Id);
        int result1 = newstabbll.DeleteNewsTab(Id);
        if (result1 > 0 && result2 > 0)
        {

            if (newstab.Urlhtml.Trim() != "")
            {
                string[] html = newstab.Urlhtml.Split('/');
                string[] cc = html[2].Split('.');
                com.DeleteFile(@CasesTem + html[1].ToString() + @"\" + html[2].ToString());
            }


            Tz888.Common.MessageBox.Show(this.Page, "删除成功");



        }
        else { Tz888.Common.MessageBox.Show(this.Page, "删除失败"); }
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
        this.Pager1.TableViewName = "NewsTab,@";
        this.Pager1.KeyColumn = "Newsid";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "createdate";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    }
    public string GetType(int typeid)
    {
        Tz888.Model.NewsTypeTab newstypetab = newstypetabbll.GetNewsTypeByTypeId(typeid);
        string pard = "";
        if (newstypetab == null)
        {
            pard = "";
        }
        else { pard = newstypetab.TypeName.ToString().Trim(); }
        return pard;
    }

    public string GetTime(string times)
    {
        return times.Substring(0, 9);
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
        else if (stuta == 3)
        {
            strs = "未通过审核";
        }
        else if (stuta == 5)
        {
            strs = "已删除";
        }
        return strs;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string bianhao = "";
        string type = "";
        string biaoti = "";
        string name = "";
        string statu = "";
        if (txtNuber.Value.Trim() == "")
        {
            bianhao = "";
        }
        else { bianhao = " Newsid=" + txtNuber.Value.Trim() + ""; }
        if (txtnewstitle.Text.Trim() == "")
        {
            biaoti = "";
        }
        else
        {
            if (txtNuber.Value.Trim() == "")
            {
                biaoti = " NTitle='" + txtnewstitle.Text.Trim() + "'";
            }
            else
            {
                biaoti = "and NTitle='" + txtnewstitle.Text.Trim() + "'";
            }
        }
        if (Convert.ToInt32(ddlType.SelectedValue.Trim()) == -1)
        {
            type = "";

        }
        else
        {
            if (txtNuber.Value.Trim() == "" && txtnewstitle.Text.Trim() == "")
            {
                type = " TypeID=" + ddlType.SelectedValue.Trim();
            }
            else
            {
                type = " and TypeID=" + ddlType.SelectedValue.Trim();
            }
        }
        if (Convert.ToInt32(ddrstuta.SelectedValue.Trim()) == -1)
        {
            statu = "";

        }
        else
        {
            if (txtNuber.Value.Trim() == "" && txtnewstitle.Text.Trim() == "" && Convert.ToInt32(ddlType.SelectedValue.Trim()) == -1)
            {
                statu = " Audit=" + ddrstuta.SelectedValue.Trim();
            }
            else
            {
                statu = " and Audit=" + ddrstuta.SelectedValue.Trim();
            }
        }
        if (txtName.Text.Trim() == "")
        {
            name = "";
        }
        else
        {
            if (txtNuber.Value.Trim() == "" && txtnewstitle.Text.Trim() == "" && Convert.ToInt32(ddlType.SelectedValue.Trim()) == -1 && Convert.ToInt32(ddrstuta.SelectedValue.Trim()) == -1)
            {
                name = " UserName='" + txtName.Text.Trim() + "'";
            }
            else
            {
                name = " and UserName='" + txtName.Text.Trim() + "'";
            }
        }
        if (bianhao == "" && biaoti == "" && type == "" && name == "" && statu == "")
        {
            par = "";
        }
        else
        {
            par = "" + bianhao + biaoti + type + statu + name;
        }
        BindShow();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的项目!");
            return;
        }
        int result1 = 0;
        int result2 = 0;
        for (int i = 0; i < values.Length; i++)
        {
            Tz888.Model.NewsTab newstab = newstabbll.GetNewsTabByNewId(Convert.ToInt32(values[i].Trim()));
            result2 = newsviewtabbll.DeleteNewsViewTab(Convert.ToInt32(values[i].Trim()));
            result1 = newstabbll.DeleteNewsTab(Convert.ToInt32(values[i].Trim()));

            if (result1 > 0 && result2 > 0)
            {
                if (newstab.Urlhtml.Trim() != "")
                {
                    string[] html = newstab.Urlhtml.Split('/');
                    string[] cc = html[2].Split('.');
                    com.DeleteFile(@CasesTem + html[1].ToString() + @"\" + html[2].ToString());
                }
            }

        }
        if (result1 > 0 && result2 > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
        }

        BindShow();

    }
    protected void btnpublic_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要静态化的资源!");
            return;
        }
        int result = 0;
        for (int i = 0; i < values.Length; i++)
        {
            Tz888.Model.NewsTab newstab = newstabbll.GetNewsTabByNewId(Convert.ToInt32(values[i].Trim()));
            if (newstab.Audit == 1)
            {
                Tz888.BLL.news.PageStatic stat = new Tz888.BLL.news.PageStatic();
                result = stat.StaticHtml(Convert.ToInt32(values[i].Trim()));
            }
        }
        Tz888.Common.MessageBox.Show(this.Page, "生成成功");
    }
    protected void btnIndexStatic_Click(object sender, EventArgs e)
    {
        string fileName = "index.htm";
        Encoding code = Encoding.GetEncoding("gb2312");
        StreamReader sr = null;
        StreamWriter sw = null;
        string str = null;

        //读取远程路径
        WebRequest temp = WebRequest.Create(txtIndex.Text.Trim());
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
            sw = new StreamWriter(@PsStatic + fileName, false, code);
            sw.Write(str);
            sw.Flush();

        }
        catch (Exception ex)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败!");

        }
        if (sw != null)
        {
            sw.Close();
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败");
        }
    }
}
