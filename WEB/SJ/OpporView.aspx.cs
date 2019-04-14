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
using System.Xml;

public partial class SJ_OpporView : Tz888.Common.Pager.BasePage
{
    private static Tz888.BLL.Info.OpportunityInfoBLL OpporInfo = new Tz888.BLL.Info.OpportunityInfoBLL();
    private static Tz888.BLL.PageBLL page = new Tz888.BLL.PageBLL();
    private static Tz888.BLL.PageStatic2 cc = new Tz888.BLL.PageStatic2();
    private static Sj.SJStatic webservice = new Sj.SJStatic();
    private int _myPageSize = 10;
    private string _criteria;
    private int CCId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        SetPagerParameters();
        if(!IsPostBack)
        {
            this.Pager1.DataBind();
        }
        if (Convert.ToInt32(Request["fID"]) != 0)
        {
            CCId = Convert.ToInt32(Request["fID"].ToString());
            DelSj(CCId);
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
        this.Pager1.TableViewName = "MainInfoOppor";
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

    #region 截取字符串的个数
    protected string StrLength(object title)
    {
        string name = "";
        name = title.ToString();
        if (name.Length > 15)
        {
            name = name.Substring(0, 14) + "...";
        }
        return name;
    }
    #endregion

    #region 将类型翻译成中文
    protected string industyName(int industyId)
    {
        string name = "";
        name = OpporInfo.IndustryOpportunityName(industyId);
        return name;
    }
    #endregion

    #region 删除
    private void DelSj(int num)
    {
        //string name = OpporInfo.PaperExeists(TID);
        //if (name != "")
        //{
        //    string[] html = name.Split('/');
        //    string[] cc = html[2].Split('.');
        //    com.DeleteFile(@"F:\topfo\tzWeb\Cases\" + html[1].ToString() + "\\" + html[2].ToString());
        //}
        long info = OpporInfo.delete(num);
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
    protected void btnDelPart_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的资源!");
            return;
        }
        StringBuilder builder = new StringBuilder();
        foreach (string str in values)
        {
            //string name = OpporInfo.PaperExeists(Convert.ToInt32(str.Trim()));
            //if (name != "")
            //{
            //    string[] html = name.Split('/');
            //    string[] cc = html[2].Split('.');
            //    com.DeleteFile(@"F:\topfo\tzWeb\Cases\" + html[1].ToString() + "\\" + html[2].ToString());
            //}
            long info = OpporInfo.delete(Convert.ToInt32(str.Trim()));
            if (info < 0)
            {
                builder.Append("编号:" + str.ToString().Trim() + ",删除失败\\n");
            }
        }
        if (builder.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, builder.ToString());
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功");
        }
        this.SetPagerParameters();
        this.Pager1.DataBind();
    }
    #endregion

    #region 全部生成静态文件
    protected void btnAll_Click(object sender, EventArgs e)
    {
        
        StringBuilder builder = new StringBuilder();
        string info = webservice.SjselAll();
        string[] name = info.Split(',');
        for (int i = 0; i < name.Length; i++)
        {
            cc = page.SJInfo(Convert.ToInt32(name[i]));
            if (cc.AuditingStatus != 1)
            {
                builder.Append("编号:" + name[i] + "  所对应的状态为:" + Verify(cc.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {
                webservice.SjHtml(Convert.ToInt32(name[i]), name[i].Trim(), cc.Title, cc.ProvinceID, cc.CountyID, cc.IndustryOpportunityID,
                    cc.OpportunityType, Convert.ToString(cc.PublishT), cc.ValidateTerm, cc.Content, cc.Analysis, cc.Request, cc.Flow);
                webservice.SjModifyHtml(Convert.ToInt32(name[i]));
            }
        }
        if (builder.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, builder.ToString());
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
    }
    #endregion

    #region 批量生成静态文件
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
            cc = page.SJInfo(Convert.ToInt32(str.Trim()));
            if (cc.AuditingStatus != 1)
            {
                sb.Append("编号:" + str.Trim()+ "  所对应的状态为:" + Verify(cc.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {
                webservice.SjHtml(Convert.ToInt32(str), str.Trim(), cc.Title, cc.ProvinceID, cc.CountyID, cc.IndustryOpportunityID,
                    cc.OpportunityType, Convert.ToString(cc.PublishT), cc.ValidateTerm, cc.Content, cc.Analysis, cc.Request, cc.Flow);
                webservice.SjModifyHtml(Convert.ToInt32(str.Trim()));
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

    #region 区间内生成静态文件
    protected void btnShare_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        int begInfoID = Convert.ToInt32(this.begInfo.Value);
        int endInfoID = Convert.ToInt32(this.endInfo.Value);
        string[] name = webservice.SjselBegion(begInfoID,endInfoID).Split(',');
        for (int i = 0; i < name.Length - 1; i++)
        {
            cc = page.SJInfo(Convert.ToInt32(name[i]));
            if (cc.AuditingStatus != 1)
            {
                sb.Append("编号:" + name[i] + "  所对应的状态为:" + Verify(cc.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {
                webservice.SjHtml(Convert.ToInt32(name[i]), name[i].Trim(), cc.Title, cc.ProvinceID, cc.CountyID, cc.IndustryOpportunityID,
                     cc.OpportunityType, Convert.ToString(cc.PublishT), cc.ValidateTerm, cc.Content, cc.Analysis, cc.Request, cc.Flow);
                webservice.SjModifyHtml(Convert.ToInt32(name[i]));
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
}
