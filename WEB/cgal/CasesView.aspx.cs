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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

public partial class cgal_CasesView : Tz888.Common.Pager.BasePage
{
    private static Tz888.BLL.PageBLL page = new Tz888.BLL.PageBLL();
    private static Tz888.BLL.PageStatic2 cc = new Tz888.BLL.PageStatic2();
    private static Tz888.BLL.CasesInfoTabBLL casesInfo = new Tz888.BLL.CasesInfoTabBLL();
    private static Tz888.BLL.Compage com = new Tz888.BLL.Compage();

    private int _myPageSize = 20;
    private string _criteria;
    private int CCId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        SetPagerParameters();
        if (!IsPostBack)
        {
            this.Pager1.DataBind();
        }
        if (Convert.ToInt32(Request["fID"]) != 0)
        {
            CCId = Convert.ToInt32(Request["fID"].ToString());
            DelZS(CCId);
        }

    }

    private void SetPagerParameters()
    {
        if (ViewState["MyPageSize"] != null)
            this._myPageSize = Convert.ToInt32(ViewState["MyPageSize"]);
        else
            ViewState["MyPageSize"] = this._myPageSize;

        if (ViewState["Criteria"] == null)
        {
            this._criteria = "";
            ViewState["Criteria"] = this._criteria;
        }
        else
            this._criteria = ViewState["Criteria"].ToString();

        this.Pager1.PageSize = this._myPageSize;
        this.Pager1.StrWhere = this._criteria;
        this.Pager1.TableViewName = "MainInfoCas";
        this.Pager1.KeyColumn = "InfoID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "PublishT";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
    }

    #region 设置时间有效期
    /// <summary>
    /// 设置时间有效期
    /// </summary>
    /// <returns></returns>
    protected string GetValiditeInfo(object time)
    {
        DateTime dt = new DateTime();
        string request = "";
        try
        {
            dt = Convert.ToDateTime(time);
            request = "有效期至:" + dt.ToString("yyyy-MM-dd hh:mm:ss");
        }
        catch
        {
            request = "未设置有效期";
        }
        return request;
    }
   #endregion

   #region 删除
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="TID"></param>
    private void DelZS(int TID)
    {
        string name= casesInfo.PaperExeists(TID);
        if (name != "")
        {
            string[] html=name.Split('/');
            string[] cc = html[2].Split('.');
            com.DeleteFile(@"F:\topfo\News\Caseshtml\" + html[1].ToString() + "\\" + html[2].ToString());
        }
        long info = casesInfo.delete(TID);
        if (info > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败");
        }

        this.SetPagerParameters();
        this.Pager1.DataBind();
    } 
    #endregion


    #region 部分删除
    /// <summary>
    /// 部分删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelPart_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的资源!");
            return;
        }
        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            string name = casesInfo.PaperExeists(Convert.ToInt32(str.ToString().Trim()));
            if (name != "")
            {
                string[] html = name.Split('/');
                string[] cc = html[2].Split('.');
                com.DeleteFile(@"J:\topfo\News\Caseshtml\" + html[1].ToString() + "\\" + html[2].ToString());
            }
            long info = casesInfo.delete(Convert.ToInt32(str.Trim()));
            if( info< 0)
            {
               sb.Append("编号:"+str.ToString().Trim()+",删除失败\\n");
            }

        }
        if (sb.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功");
        }
        this.SetPagerParameters();
        this.Pager1.DataBind();
    }
    #endregion

    #region 将审核状态进行翻译
    protected string Verify(int com)
    {
        string Nnamn = "";
        switch (com)
        {
            case 0:
                Nnamn = "审核中";
                break;
            case 1:
                Nnamn = "审核通过";
                break;
            case 2:
                Nnamn = "审核未通过";
                break;
            case 3:
                Nnamn = "已过期";
                break;
            case 4:
                Nnamn = "已删除";
                break;
            case 5:
                Nnamn = "全部";
                break;
        }
        return Nnamn;
    }
    #endregion
    #region
    /// <summary>
    /// 将分类中的数字转换成文字
    /// </summary>
    /// <returns></returns>
    protected string CasesType(string CasesTypeId)
    {
        string name = "";
        switch (CasesTypeId.Trim())
        {
            case "01":
                name = "招商案例";
                break;
            case "02":
                name = "融资案例";
                break;
            case "03":
                name = "创业案例";
                break;
            case "04":
                name = "产权交易案例";
                break;
            case "05":
                name = "贤泽创富案例";
                break;
            case "06":
                name = "其他案例";
                break;
            case "07":
                name = "技术案例";
                break;
            case "08":
                name = "投资案例";
                break;
        }
        return name;
    }
    #endregion

    #region 生成静态文件
    /// <summary>
    /// 生成静态文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnStatic_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要静态化的资源!");
            return;
        }
        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            cc=page.cgyl(Convert.ToInt32(str.Trim()));
            
            if (cc.AuditingStatus != 1)
            {
                sb.Append("编号:" + str.Trim() +"  所对应的状态为:"+ Verify(cc.AuditingStatus)+" ，生成静态化页面失败\\n");
            }
            else
            {
                
                page.StaticHtml(Convert.ToInt32(str.Trim()),str.Trim(), cc.Title, cc.PublishT.ToString(),cc.Laiyuan,cc.Zuozhe, cc.Content,cc.CasesTypeID.Trim());
                page.ModifyHtmlFile(Convert.ToInt32(str.Trim()));
                 
            }
 
        }
        if (sb.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
        
    }
    #endregion

    #region 截取字符串的个数
    protected string StrLength(object title)
    {
        string name = "";
        name =title.ToString();
        if (name.Length > 15)
        {
            name = name.Substring(0, 14) + "...";
        }
        return name;
    }
    #endregion

    #region  全部生成静态文件
    /// <summary>
    /// 全部生成静态文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAll_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string info = page.selInfoId();
        string[] name = info.Split(',');
        for (int i = 0; i < name.Length-1; i++)
        {
            cc = page.cgyl(Convert.ToInt32(name[i]));
            if (cc.AuditingStatus != 1)
            {
                sb.Append("编号:" + name[i] + "  所对应的状态为:" + Verify(cc.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {

                page.StaticHtml(Convert.ToInt32(name[i]), name[i].Trim(), cc.Title, cc.PublishT.ToString(), cc.Laiyuan, cc.Zuozhe, cc.Content, cc.CasesTypeID.Trim());
                page.ModifyHtmlFile(Convert.ToInt32(name[i]));
                
            }
        }
        if (sb.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
    }
    #endregion

    #region 在所对应的区间内生成静态文件
    /// <summary>
    /// 在所对应的区间内生成静态文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShare_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        int begInfoID =Convert.ToInt32(this.begInfo.Value);
        int endInfoID =Convert.ToInt32(this.endInfo.Value);
        string[] name = page.selInfoIdRegion(begInfoID, endInfoID).Split(',');
        for (int i = 0; i < name.Length-1; i++)
        {
            
            cc = page.cgyl(Convert.ToInt32(name[i]));
            if (cc.AuditingStatus != 1)
            {
                sb.Append("编号:" + name[i] + "  所对应的状态为:" + Verify(cc.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {

                page.StaticHtml(Convert.ToInt32(name[i]), name[i].Trim(), cc.Title, cc.PublishT.ToString(), cc.Laiyuan, cc.Zuozhe, cc.Content, cc.CasesTypeID.Trim());
                page.ModifyHtmlFile(Convert.ToInt32(name[i]));
               
            }
        }
        if (sb.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
    }
    #endregion

    protected void btnCount_Click(object sender, EventArgs e)
    {

        Encoding code = Encoding.GetEncoding("gb2312");
        StreamReader sr = null;
        StreamWriter sw = null;
        string str = null;

        //读取远程路径
        WebRequest temp = WebRequest.Create(txtPage.Value.Trim());
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
            throw ex;
        }
        finally
        {
            sr.Close();
        }
        string fileName = "index.html";

        //写入
        try
        {
            sw = new StreamWriter(@"J:\topfo\News\CGAl\" + fileName, false, code);
            sw.Write(str);
            sw.Flush();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sw.Close();
            Tz888.Common.MessageBox.Show(this.Page, "静态页面" + fileName + "已经生成成功");
        }
    }
}
