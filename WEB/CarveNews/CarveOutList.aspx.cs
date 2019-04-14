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
public partial class CarveNews_CarveOutList : System.Web.UI.Page
{
    private static Tz888.BLL.CasesInfoTabBLL casesInfo = new Tz888.BLL.CasesInfoTabBLL();
    private static Tz888.BLL.CarveOut.PageStatic bll = new Tz888.BLL.CarveOut.PageStatic();//实例化创建文件类
    private static Tz888.BLL.CarveOut.PageStatic page = new Tz888.BLL.CarveOut.PageStatic(); //实例化创建文件类
    CarveOut.CarveOutService service = new CarveOut.CarveOutService(); //调用WebService
    CarveOut.StaticService compage = new CarveOut.StaticService();////调用WebService
    protected void Page_Load(object sender, EventArgs e)
    {
        this.AspNetPager.PageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());

        if (!IsPostBack)
        {
          
            ViewState["Criteria"] = "";  //全部资讯
            this.AspNetPager.CurrentPageIndex = 1;          
            this.ViewState["TotalNumCount"] = 1;
            this.ViewState["SortBy"] = "";
            GetInfoNews();

        }
        if (Convert.ToInt32(Request["fID"]) != 0)
        {
            int Id = Convert.ToInt32(Request["fID"].ToString());
            DeleteNws(Id);
        }
    }
    #region 删除
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="Id"></param>
    private void DeleteNws(int Id)
    {
        Tz888.BLL.CarveOut.CarveOutInfoManager bllobj = new Tz888.BLL.CarveOut.CarveOutInfoManager();

        string name = casesInfo.PaperExeists(Id);
        if (name != "")
        {
            string[] html = name.Split('/');
            string[] cc = html[2].Split('.');
            compage.DeleteFile(@"F:\topfo\CY\CarveOut\" + html[1].ToString() + @"\" + html[2].ToString());
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
    #region 查询出创业信息绑定方法
    /// <summary>
    /// 查询出创业信息绑定方法
    /// </summary>
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
        Tz888.BLL.CarveOut.CarveOutInfoManager srvSI = new Tz888.BLL.CarveOut.CarveOutInfoManager();

        DataSet ds = srvSI.dsGetNewsList("*", strCriteria, "publishT desc", CurrentPage, PageNum, out TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.NewsList.DataSource = ds.Tables[0].DefaultView;

        this.NewsList.DataBind();
        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;

     


    } 
    #endregion
    #region 截取字符串的个数
    protected string StrLength(object title)
    {
        string name = "";
        name = title.ToString();
        if (name.Length > 9)
        {
            name = name.Substring(0, 8) + "...";
        }
        return name;
    }
    #endregion
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
    #region 选择每页显示多少条
    /// <summary>
    /// 选择每页显示多少条
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
   
        GetInfoNews();

    } 
    #endregion
    #region 类型中文转换
    protected string InfoType(int com)
    {
        string Nnamn = "";
        switch (com)
        {
            case 0:
                Nnamn = "项目找资金";
                break;
            case 01:
                Nnamn = "资金找项目";
                break;



        }
        return Nnamn;
    } 
    #endregion

    #region 按条件搜索
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
            if (this.txtNuber.Value.Trim() != "")   //根据ID
                strCriteria.Append(" InfoID like  '%" + this.txtNuber.Value.Trim() + "%'");
        }
        if (strCriteria.ToString() == "")
        {
            if (this.ddlCarveOutInfoType.SelectedValue.ToString().Trim() != "5" && ddlStatus.SelectedValue.ToString().Trim() != "5")
            {
                strCriteria.Append(" CarveOutInfoType=" + this.ddlCarveOutInfoType.SelectedValue.ToString().Trim());
                strCriteria.Append(" and AuditingStatus =" + this.ddlStatus.SelectedValue.ToString().Trim());

            }
            else
            {
                if (this.ddlCarveOutInfoType.SelectedValue.ToString().Trim() != "5")
                {
                    strCriteria.Append(" CarveOutInfoType=" + this.ddlCarveOutInfoType.SelectedValue.ToString().Trim());

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
    #region 批量生成静态页面
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
            page = bll.NewsIdAll(Convert.ToInt32(str.Trim()));

            if (page.AuditingStatus != 1)
            {
                sb.Append("编号:" + str.Trim() + "  所对应的状态为:" + Verify(page.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {
                int num = service.ModifyHtmlFile(Convert.ToInt32(str.Trim()));
                if (num != 0)
                {
                  string number= service.CreateHtml(Convert.ToInt32(str.Trim()), page.Title, page.PublishT.ToString(), page.Content, page.Hit,page.Address,page.CapitalID,page.ComName,page.Email,page.IndustryCarveOutID,page.InvestObject,page.InvestReturn,page.LinkMan,page.PostCode,page.ProvinceID,page.Tel,page.ValidateID,page.WebSite,page.KeyWord, page.CarveOutInfoType, "tz888Admin", "mtvc2909");
                  if (number=="1")
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
              
            }

        }
        if (sb.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        }


    } 
    #endregion
    #region 删除事件
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        Tz888.BLL.CarveOut.CarveOutInfoManager bllobj = new Tz888.BLL.CarveOut.CarveOutInfoManager();

        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            string name = casesInfo.PaperExeists(Convert.ToInt32(str.ToString().Trim()));
            if (name != "")
            {
                string[] html = name.Split('/');
                string[] cc = html[2].Split('.');
                compage.DeleteFile(@"j:\topfo\CY\CarveOut\" + html[1].ToString() + @"\" + html[2].ToString());
            }
            else
            {
                sb.Append("编号:" + str.ToString().Trim() + ",删除失败\\n");
            }
            long info = bllobj.delete(str.Trim());
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
    } 
    #endregion
    #region 根据类型批量生成静态页面
    protected void btnType_Click(object sender, EventArgs e)
    {
        string type = ddlTypea.SelectedValue.ToString().Trim();
        StringBuilder sb = new StringBuilder();
        string info = bll.SetType(type);
        string[] name = info.Split(',');
        for (int i = 0; i < name.Length - 1; i++)
        {
            page = page.NewsIdAll(Convert.ToInt32(name[i]));
            if (page.AuditingStatus != 1)
            {
                sb.Append("编号:" + name[i] + "  所对应的状态为:" + Verify(page.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {

                int num = service.ModifyHtmlFile(Convert.ToInt32(name[i]));
                if (num != 0)
                {
                    string number = service.CreateHtml(Convert.ToInt32(name[i]), page.Title, page.PublishT.ToString(), page.Content, page.Hit, page.Address, page.CapitalID, page.ComName, page.Email, page.IndustryCarveOutID, page.InvestObject, page.InvestReturn, page.LinkMan, page.PostCode, page.ProvinceID, page.Tel, page.ValidateID, page.WebSite, page.KeyWord, page.CarveOutInfoType, "tz888Admin", "mtvc2909");
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

            }
        }
        if (sb.ToString() != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        }
        //else
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
        //}
    } 
    #endregion
    #region 分页事件
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    #endregion

}
