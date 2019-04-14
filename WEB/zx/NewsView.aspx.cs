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
public partial class zx_NewsList : System.Web.UI.Page
{
    private static Tz888.BLL.PageBLL page = new Tz888.BLL.PageBLL();//实例化创建文件类
    private static Tz888.BLL.zx.PageStatic cc = new Tz888.BLL.zx.PageStatic(); //实例化创建文件类
    private static Tz888.BLL.CasesInfoTabBLL casesInfo = new Tz888.BLL.CasesInfoTabBLL();
    Tz888.BLL.Common.IndustryBLL bll = new Tz888.BLL.Common.IndustryBLL();  
    private static Tz888.BLL.Compage com = new Tz888.BLL.Compage();  //调用删除文件
    news.StaticWebService service = new news.StaticWebService();  //webService创建调用
    news.ComPageWebService compage = new news.ComPageWebService();//webService删除文件方法调用

    public int iPageSize = 15;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.AspNetPager.PageSize=Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());
        
        if (!IsPostBack)
        {

            ViewState["Criteria"] = "";  //全部资讯
             this.AspNetPager.CurrentPageIndex = 1;          
            this.ViewState["TotalNumCount"] = 1;
            SetANewsType();
            this.ViewState["SortBy"] = "";
            SetNewsType();
            GetInfoNews();
          
        }
        if (Convert.ToInt32(Request["fID"]) != 0)
        {
          int  Id = Convert.ToInt32(Request["fID"].ToString());
            DeleteNws(Id);
        }
    
    }

    #region 将审核状态进行翻译
    protected string Verify(int com)
    {
        string Nnamn = "";
        switch (com)
        {
            case 0:
                Nnamn = "未审核";
                break;
            case 1:
                Nnamn = "审核通过";
                break;
            case 2:
                Nnamn = "审核未通过";
                break;
          
        }
        return Nnamn;
    }
    #endregion
    #region 获取资讯

    private void GetInfoNews()
    {
        //this.AspNetPager.CurrentPageIndex = 1;
        //this.AspNetPager.PageSize = iPageSize;
        //this.ViewState["TotalNumCount"] = 1;
        //string strCriteria = ViewState["Criteria"].ToString();
        //long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        //long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        //long TotalCount = 0;
        //long PageCount = 1;
        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        long TotalCount = 0;
        long PageCount = 1;
        Tz888.BLL.zx.NewsTabManager srvSI = new Tz888.BLL.zx.NewsTabManager();

        DataSet ds = srvSI.dsGetNewsList("*", strCriteria, "publishT desc", CurrentPage, PageNum, out TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.NewsList.DataSource = ds.Tables[0].DefaultView;

        this.NewsList.DataBind();
        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;

        //this.pinfo.InnerText = "共" + PageCount + "页";
        //this.LblCount.Text = TotalCount.ToString();


        if (ds.Tables[0].Rows.Count <= 0)
        {
            //this.NoMessage.Style.Value = "display:block";
            //this.dvCheck.Style.Value = "display:none";
            //this.pinfo2.Style.Value = "display:none";
        }

    }
    #endregion
    #region 删除
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="Id"></param>
    private void DeleteNws(int Id)
    {
       Tz888.BLL.zx.NewsTabManager bllobj = new Tz888.BLL.zx.NewsTabManager();

        string name = casesInfo.PaperExeists(Id);
        if (name != "")
        {
            string[] html = name.Split('/');
            string[] cc = html[2].Split('.');
            compage.DeleteFile(@"j:\topfo\News\News\" + html[1].ToString() + @"\" + html[2].ToString());
        }
        long info = bllobj.delete(Convert.ToString(Id));
        if (info > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败");
        }

        this.GetInfoNews();
    }
       #endregion
    #region 分页事件
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    } 
    #endregion

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        //iPageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());
        GetInfoNews();

    }
    #region 批量删除
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        Tz888.BLL.zx.NewsTabManager bllobj = new Tz888.BLL.zx.NewsTabManager();

        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            string name = casesInfo.PaperExeists(Convert.ToInt32(str.ToString().Trim()));
            if (name != "")
            {
                string[] html = name.Split('/');
                string[] cc = html[2].Split('.');
                compage.DeleteFile(@"j:\topfo\News\News\" + html[1].ToString() + @"\" + html[2].ToString());
            }
            long info = bllobj.delete(str.Trim());
            if (info < 0)
            {
                sb.Append("编号:" + str.ToString().Trim() + ",删除失败\\n");
            }

        }
    } 
    #endregion
    #region 根据ID获取类型名称
    /// <summary>
    /// 根据ID获取类型名称
    /// </summary>
    /// <param name="NewsId">ID编号</param>
    /// <returns></returns>
    public string GetSetNewsTypeByID(string NewsId)
    {
        return bll.GetSetNewsTypeByID(NewsId);
    } 
    #endregion
    #region 截取字符串的个数
    protected string StrLength(object title)
    {
        string name = "";
        name = title.ToString();
        if (name.Length > 9)
        {
            name = name.Substring(0,8) + "...";
        }
        return name;
    }
    #endregion
    #region 新闻类型绑定
    /// <summary>
    /// 新闻类型
    /// </summary>
    private void SetNewsType()
    {



        this.ddlType.DataSource = bll.SetNewsType();
        this.ddlType.DataBind();
        ListItem liTemp = new ListItem();
        liTemp.Text = "全部资讯";
        liTemp.Value = "-1";
        ddlType.Items.Insert(0, liTemp);
    } 
    #endregion
    #region 类型绑定
    /// <summary>
    /// 新闻类型
    /// </summary>
    private void SetANewsType()
    {



        this.ddlTypea.DataSource = bll.SetNewsType();
        this.ddlTypea.DataBind();
       
    }
    #endregion
    #region 查找事件
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();
        //if (this.ddlType.SelectedValue.ToString().Trim() != "-1")
        //{
        //    strCriteria.Append(" NewsTypeID=");
        //    strCriteria.Append(this.ddlType.SelectedValue.ToString().Trim());
        //}
        if (strCriteria.ToString() == "")
        {
            if (this.txtNuber.Value.Trim() != "")
                strCriteria.Append(" InfoID like  '%" + this.txtNuber.Value.Trim() + "%'");
        }
        if (strCriteria.ToString() == "")
        {
            if (this.ddlType.SelectedValue.ToString().Trim() != "-1" && ddlStatus.SelectedValue.ToString().Trim() != "5")
            {
                strCriteria.Append(" NewsTypeID=" + this.ddlType.SelectedValue.ToString().Trim());
                strCriteria.Append(" and AuditingStatus =" + this.ddlStatus.SelectedValue.ToString().Trim());

            }
            else
            {
                if (this.ddlType.SelectedValue.ToString().Trim() != "-1")
                {
                    strCriteria.Append(" NewsTypeID=" + this.ddlType.SelectedValue.ToString().Trim());

                }
 
            }
        }


        if (strCriteria.ToString() == "")
        {
            switch (this.ddlStatus.SelectedValue.ToString().Trim())
            {
                case "0":
                    strCriteria.Append(" AuditingStatus=");
                    strCriteria.Append(this.ddlStatus.SelectedValue.ToString().Trim());
                    break;
                case "1":
                    strCriteria.Append(" AuditingStatus=");
                    strCriteria.Append(this.ddlStatus.SelectedValue.ToString().Trim());
                    break;
                case "2":
                    strCriteria.Append(" AuditingStatus=");
                    strCriteria.Append(this.ddlStatus.SelectedValue.ToString().Trim());
                    break;

                default:
                    break;
            }
        }

        ViewState["Criteria"] = strCriteria.ToString();
        GetInfoNews();
    } 
    #endregion
    /// <summary>
    /// 生成静态文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnStatic_Click(object sender, EventArgs e)
    {
        news.StaticWebService service = new news.StaticWebService();
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要静态化的资源!");
            return;
        }
        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            cc = page.NewsIdAll(Convert.ToInt32(str.Trim()));

            if (cc.AuditingStatus != 1)
            {
                sb.Append("编号:" + str.Trim() + "  所对应的状态为:" + Verify(cc.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {
                int num = service.ModifyHtmlFile(Convert.ToInt32(str.Trim()));
                if (num != 0)
                {
                    string number = service.CreateHtml(Convert.ToInt32(str.Trim()), cc.Title, cc.PublishT.ToString(), cc.Content, cc.Hit, "tz888Admin", "mtvc2909");
                    if (number == "1")
                    {

                        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
                    }
                    else
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");

                    }
                }
                else 
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
                }

                //page.NewsStaticHtml(Convert.ToInt32(str.Trim()), cc.Title, cc.PublishT.ToString(), cc.Content);
                //page.NewsModifyHtmlFile(Convert.ToInt32(str.Trim()));

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
    protected void btnType_Click(object sender, EventArgs e)
    {
        news.StaticWebService service = new news.StaticWebService();
        string type = ddlTypea.SelectedValue.ToString().Trim();
        StringBuilder sb = new StringBuilder();
        string info = page.SetType(type);
        string[] name = info.Split(',');
        for (int i = 0; i < name.Length - 1; i++)
        {
            cc = page.NewsIdAll(Convert.ToInt32(name[i]));
            if (cc.AuditingStatus != 1)
            {
                sb.Append("编号:" + name[i] + "  所对应的状态为:" + Verify(cc.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {

                int num = service.ModifyHtmlFile(Convert.ToInt32(name[i]));
                if (num != 0)
                {
                   string number= service.CreateHtml(Convert.ToInt32(name[i]), cc.Title, cc.PublishT.ToString(), cc.Content, cc.Hit, "tz888Admin", "mtvc2909");
                   if (number == "1")
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
        if (sb.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        }
    }

}
