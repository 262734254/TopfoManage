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
using Tz888.BLL.MyHome;
/// <summary>
/// MerchantManage_MerchantManage招商信息查询
/// </summary>
public partial class MerchantManage_MerchantManage : System.Web.UI.Page
{  
    private static Tz888.BLL.CasesInfoTabBLL casesInfo = new Tz888.BLL.CasesInfoTabBLL();
    HomeLinkManager manager = new HomeLinkManager();
    private static Tz888.BLL.Compage com = new Tz888.BLL.Compage();
    Tz888.BLL.MerchantManage.PageStatic page = new Tz888.BLL.MerchantManage.PageStatic(); //实例化创建文件类
    Tz888.BLL.Static Mercahrstatic = new Tz888.BLL.Static();
    string zsStatic = ConfigurationManager.AppSettings["ZSAppPath"].ToString(); //静态页面存放位置
    Tz888.Common.Common Dcommon = new Tz888.Common.Common();


    Tz888.BLL.MerchantManage.MerchantManage bll = new Tz888.BLL.MerchantManage.MerchantManage();
    protected void Page_Load(object sender, EventArgs e)
    {  
        this.AspNetPager.PageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "InfoTypeID='Merchant' and AuditingStatus =0";  //全部资讯
            this.AspNetPager.CurrentPageIndex = 1;
            this.ViewState["TotalNumCount"] = 1;
            this.ViewState["SortBy"] = "";
            GetInfoNews();
        }
    }
    #region 删除
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="Id">Id</param>
    private void DeleteNws(int Id)
    {
        string name = casesInfo.PaperExeists(Id);
        if (name != "")
        {
            string[] html = name.Split('/');
            string[] cc = html[2].Split('.');
            com.DeleteFile(@zsStatic + html[1].ToString() + @"\" + html[2].ToString());
        }
        long info = bll.delete(Convert.ToString(Id));
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
    protected string getStatu(int com)
    {
        if (com == 1)
        {
            return "推荐";
        }
        else
        {
            return "";
            ///return "推荐";
        }
    }
    #region 根据ID删除事件
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
       
              int Id = Convert.ToInt32(e.CommandArgument);
              bool b = Dcommon.bBuyInfoOfUserName(Convert.ToString(Id));

              if (b != true)
              {
              string name = casesInfo.PaperExeists(Id);
              if (name != "")
              {
                  string[] html = name.Split('/');
                  string[] cc = html[2].Split('.');
                  com.DeleteFile(@zsStatic + html[1].ToString() + @"\" + html[2].ToString());
              }
              long info = bll.delete(Convert.ToString(Id));
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
          else
          {
              Tz888.Common.MessageBox.Show(this.Page, "该信息已有用户购买，不能删除");
          }

    }
    #endregion
    #region 查询出信息绑定方法
    /// <summary>
    /// 查询出创业信息绑定方法
    /// </summary>
    private void GetInfoNews()
    {


        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        long TotalCount = 0;
        long PageCount = 1;
        DataTable ds = manager.GetListT("maininfoTab", "ID", "*", strCriteria, "publishT desc", ref CurrentPage, PageNum, ref TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.NewsList.DataSource = ds.DefaultView;

        this.NewsList.DataBind();
        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;

        //string strCriteria = ViewState["Criteria"].ToString();
        //long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        //long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        //long TotalCount = 0;
        //long PageCount = 1;
        //Tz888.BLL.MerchantManage.MerchantManage srvSI = new    Tz888.BLL.MerchantManage.MerchantManage();

        //DataSet ds = srvSI.dsGetNewsList("*", strCriteria, "publishT desc", CurrentPage, PageNum, out TotalCount);
        //this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        //this.NewsList.DataSource = ds.Tables[0].DefaultView;

        //this.NewsList.DataBind();
        //if (TotalCount % PageNum > 0)
        //    PageCount = TotalCount / PageNum + 1;
        //else
        //    PageCount = TotalCount / PageNum;



      
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
    #region 属于会员绑定
    /// <summary>
    /// 属于会员绑定
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void NewsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ListItemType objItemType = e.Item.ItemType;

        if (objItemType == ListItemType.Item ||
            objItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvData = (DataRowView)e.Item.DataItem;

            #region 标题
            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
            string InfoOriginRoleName = drvData["InfoOriginRoleName"].ToString().Trim();
            //string MemberGradeID = drvData["MemberGradeID"].ToString().Trim();
            string Title = "";
            switch (InfoOriginRoleName)
            {
                case "0":

                    Title += "<font color='#FF9933'>[会员]</font>";

                    break;
                case "1":
                    Title += "<font color='#FF00CC'>[分站]</font>";
                    break;
                case "2":
                    Title += "<font color='#1A9E0A'>[总站]</font>";
                    break;
                case "4":
                    Title += "<font color='#1A9E0B'>[采集]</font>";
                    break;
                case "5":
                    Title += "<font color='#1A9E0B'>[拓富通]</font>";
                    break;
                default:
                   
                    break;
            }

            hlTitle.Text = "<a href='http://www.topfo.com/" + drvData["HtmlFile"].ToString() + "' target=\"_blank\">" + Tz888.Common.Utility.PageValidate.FixLenth(drvData["Title"].ToString(), 37, "...") + Title + "</a>";
            hlTitle.ToolTip = drvData["Title"].ToString();



            #endregion

        }
    } 
    #endregion
    #region 条件查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string LoginName = this.txtLoginName.Value.Trim();
        
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();

        if (strCriteria.ToString() == "")
        {
            if (this.txtNuber.Value.Trim() != "")   //根据ID
                strCriteria.Append(" InfoID like  '%" + this.txtNuber.Value.Trim() + "%'and InfoTypeID='Merchant'");
        }
        if (strCriteria.ToString() == "")
        {
            if (this.txtTitle.Value.Trim() != "")   //根据标题
                strCriteria.Append(" Title like  '%" + this.txtTitle.Value.Trim() + "%' and InfoTypeID='Merchant'");
        }
        if (strCriteria.ToString() == "")
        {
            if (this.txtLoginName.Value.ToString().Trim() != "" && ddlStatus.SelectedValue.ToString().Trim() != "5")
            {
                strCriteria.Append("LoginName='" + LoginName + "'and InfoTypeID='Merchant'");
                strCriteria.Append(" and AuditingStatus =" + this.ddlStatus.SelectedValue.ToString().Trim());

            }
            else
            {
                if (txtLoginName.Value.ToString().Trim() != "")
                {
                    strCriteria.Append("LoginName='" + LoginName + "'and InfoTypeID='Merchant'");

                }

            }
        }


        if (strCriteria.ToString() == "")
        {
            switch (this.ddlStatus.SelectedValue.ToString().Trim())
            {
                case "0":
                    strCriteria.Append(" InfoTypeID='Merchant' and AuditingStatus=");
                    strCriteria.Append(this.ddlStatus.SelectedValue.ToString().Trim());
                    break;
                case "1":
                    strCriteria.Append(" InfoTypeID='Merchant' and  AuditingStatus=");
                    strCriteria.Append(this.ddlStatus.SelectedValue.ToString().Trim());
                    break;
                case "2":
                    strCriteria.Append(" InfoTypeID='Merchant' and AuditingStatus=");
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
    #region 批量删除
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        Tz888.BLL.MerchantManage.MerchantManage bllobj = new Tz888.BLL.MerchantManage.MerchantManage();

        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            bool b = Dcommon.bBuyInfoOfUserName(Convert.ToString(str.ToString().Trim()));

            if (b != true)
            {
                string name = casesInfo.PaperExeists(Convert.ToInt32(str.ToString().Trim()));
                if (name != "")
                {
                    string[] html = name.Split('/');
                    string[] cc = html[2].Split('.');
                    com.DeleteFile(@zsStatic + html[1].ToString() + @"\" + html[2].ToString());
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
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "该信息已有用户购买，不能删除");

            }

        }
        
    } 
    #endregion
    #region 生成静态页面
    protected void btnStatic_Click(object sender, EventArgs e)
    {

        Tz888.Model.Info.MerchantSetModel model = new Tz888.Model.Info.MerchantSetModel();
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要静态化的资源!");
            return;
        }
        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            page = page.objGetMerchantInfoByInfoID(Convert.ToInt32(str.Trim()));//根ID获取信息
            if (page.AuditingStatus != 1)
            {
                sb.Append("编号:" + str.Trim() + "  所对应的状态为:" + Verify(page.AuditingStatus) + " ，生成静态化页面失败\\n");
            }
            else
            {
                int num = page.ModifyHtmlFile(Convert.ToInt32(str.Trim()));
                if (num != 0)
                {
                    string Idstuny = page.SelectLndus(page.Are);//根据区域查询信息

                    string IsVip = Mercahrstatic.SelIsVip();//查询为重大商机的信息
                    int sum = page.StaticHtml(Convert.ToInt32(str.Trim()), page.Title, page.PublishT, page.AreaName, page.Content, page.IndustryCarveOutID, page.MerchantNameTotal, page.ValidateID, Idstuny, IsVip, page.Keword, page.DisplayTitles, page.Descript,page.Merchanreturns);
                    if (sum != 1)
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
                    }
                    else
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面成功");
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
    #region 每页显示多少条
    /// <summary>
    /// 每页显示多少条
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    } 
    #endregion
    #region 分页事件
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    } 
    #endregion
    #region 生成首页静态页面
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
            sw = new StreamWriter(@"G:\zstopfocom\" + fileName, false, System.Text.Encoding.Default);
            sw.Write(str);
            sw.Flush();
        }
        catch (Exception ex)
        {
            Tz888.Common.MessageBox.Show(this.Page, "静态页面生成失败!" + ex.Message);
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
    #endregion
    #region //加入邮件群发集
    protected void Button2_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择最少一条数据....");
        }
        else
        {

            Tz888.BLL.Mail.MailInfoBLL email = new Tz888.BLL.Mail.MailInfoBLL();

            int max = 0;//成功条数    
            int min = 0;//失败条数
            foreach (string list in values)
            {
                bool bl = bll.SelMerchantInfo(Convert.ToInt32(list.ToString().Trim()));//判断是否有这条记录
                if (bl == true)
                {

                    int index = email.InsertEmail(Convert.ToInt32(list.ToString().Trim()));
                    if (index > 0)
                        max++;
                }
                else
                {
                    min++;
                }

            }
            Tz888.Common.MessageBox.Show(this.Page, "添加成功" + max + "条！失败" + min + "条！");
            // Response.Redirect("mail/MailSupervise.aspx");
        }
       
    }
    #endregion
}
