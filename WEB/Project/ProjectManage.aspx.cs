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
public partial class Project_ProjectManage : Tz888.Common.Pager.BasePage
{
    Tz888.BLL.PageBLL page = new Tz888.BLL.PageBLL();
    Tz888.BLL.Visit.VisitInfoBLL visit = new Tz888.BLL.Visit.VisitInfoBLL();
    Tz888.BLL.Info.ProjectInfoBLL project = new Tz888.BLL.Info.ProjectInfoBLL();
    string RZStatic = ConfigurationManager.AppSettings["ProjectPath"].ToString(); //静态页面存放位置
    Tz888.Common.Common Dcommon = new Tz888.Common.Common();
    private static Tz888.BLL.Compage com = new Tz888.BLL.Compage();
    Tz888.BLL.ProjectState state = new Tz888.BLL.ProjectState();

    private int _myPageSize = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "";
            SetPagerParameters();
            if (Convert.ToInt32(Request["id"]) != 0)
            {
                long infoc =Convert.ToInt64(Request["id"].ToString());
              
            }
        }
    }
    protected string getStatu(int com)
    {
        if (com == 1)
        {
            return "推荐";
        }
        else
        {
            return "";
            //return "推荐";
        }
    }
  
    #region 加载信息绑定
    /// <summary>
    /// 绑定分页
    /// </summary>
    private void SetPagerParameters()
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        string str = "";
        if (ViewState["MyPageSize"] != null)
            this._myPageSize = Convert.ToInt32(ViewState["MyPageSize"]);
        else
            ViewState["MyPageSize"] = this._myPageSize;
        if (ViewState["Criteria"] == "")
        {
            str = " AuditingStatus=0";
        }
        else
        {
            str = ViewState["Criteria"].ToString().Trim();
        }

        this.Pager1.PageSize = this._myPageSize;
        this.Pager1.StrWhere = str;
        this.Pager1.TableViewName = "ProjectInfo_VIW";
        this.Pager1.KeyColumn = "InfoID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "PublishT";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    } 
    #endregion

    #region 会员角色绑定
    protected string InfoOriginRoleName(string OriginRoleName)
    {
        string name = OriginRoleName.ToString().Trim();
        if (name != "")
        {
            switch (name)
            {

                case "0":

                    name = "<font color='#FF9933'>[会员]</font>";

                    break;
                case "1":
                    name = "<font color='#FF00CC'>[分站]</font>";
                    break;
                case "2":
                    name = "<font color='#1A9E0A'>[总站]</font>";
                    break;
                case "4":
                    name = "<font color='#1A9E0B'>[采集]</font>";
                    break;
                default:
                    name = "<font color='#FF9933'>[会员]</font>";
                    break;
            }

        }
        return name;
    } 
    #endregion

    #region 条件查询
    /// <summary>
    /// 条件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSel_Click(object sender, EventArgs e)
    {
        ViewState["Criteria"] = "";
        string name = "";
        if (this.txtBeginTime.Value != "")
        {
            name += " publishT>='" + this.txtBeginTime.Value + "' and";
        }
        if (this.txtEndTime.Value != "")
        {
            name += " publishT<='" + this.txtEndTime.Value + "' and";
        }
        if (this.txtID.Text != "")
        {
            name += " InfoID='" + this.txtID.Text + "' and";
        }
        if (this.txtTitle.Text != "")
        {
            name += " Title like  '%" + txtTitle.Text.ToString().Trim() + "%' and";
                    
        }
        if (this.rblStatus.SelectedValue != "" & this.rblStatus.SelectedValue != "1000")
        {
            name += " AuditingStatus='" + this.rblStatus.SelectedValue + "' and";
        }
        if (this.rblrz.SelectedValue != "" & this.rblrz.SelectedValue != "1000")
        {
            name += " CooperationDemandType='" + this.rblrz.SelectedValue + "' and";
        }
        if (this.btnName.Value != "")
        {
            name += " LoginName='" + this.btnName.Value + "' and";
        }
        ViewState["Criteria"] = name + " 1=1";
        SetPagerParameters();
    } 
    #endregion

    #region 有效期和状态绑定
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

    #region 债券融资,债券融资绑定
    protected string DemType(int com)
    {
        string name = "";
        switch (com)
        {
            case 9:
                name = "债券融资";
                break;
            case 10:
                name = "股权融资";
                break;
        }
        return name;

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

    #region 删除
    private void Delete(long num)
    {
        bool b = Dcommon.bBuyInfoOfUserName(Convert.ToString(num));

        if (b)
        {

            string name = page.SelHtmlFile(Convert.ToString(num));
            if (name != "")
            {
                string[] html = name.Split('/');
                com.DeleteFile(@RZStatic + html[1].ToString() + "\\" + html[2].ToString());
            }
            long info = project.delete(Convert.ToInt32(num));
            if (info >= 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除成功");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除失败");
            }

            this.SetPagerParameters();
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "该信息已有用户购买，不能删除");
        }
    }
    #endregion

    #region 根据ID删除事件
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        bool b = Dcommon.bBuyInfoOfUserName(Convert.ToString(Id));

         if (b!=true)
         {
             string name = page.SelHtmlFile(Convert.ToString(Id));
             if (name != "")
             {
                 string[] html = name.Split('/');
                 com.DeleteFile(@RZStatic + html[1].ToString() + @"\" + html[2].ToString());
             }
             long info = project.delete(Convert.ToInt32(Id));
             if (info >= 0)
             {
                 Tz888.Common.MessageBox.Show(this.Page, "删除成功");
             }
             else
             {
                 Tz888.Common.MessageBox.Show(this.Page, "删除失败");
             }
             this.SetPagerParameters();
         }
         else
         {
             Tz888.Common.MessageBox.Show(this.Page, "该信息已有用户购买，不能删除");
         }

    }
    #endregion

    #region 生成静态文件
    protected void btnBatch_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要静态化的资源!");
            return;
        }
        StringBuilder sb = new StringBuilder();
        string cc = "";
        foreach (string str in values)
        {
            state = page.SelProjectM(str.Trim());
            //string[] ht = cc.Split('^');
            string CountryCode = "中国";// visit.SelCountry(ht[3].ToString().Trim());//国家
            string Province = visit.SelProvince(state.ProvinceID.ToString().Trim());//省名
            string City = visit.SelCityID(state.CityID.ToString().Trim());//地区所对应城市
            string County = visit.SelCounty(state.CountyID.ToString().Trim());//地区
            string[] Bid = state.IndustryBID.ToString().Trim().Split(',');
            string Industry = "";
            if (Bid.Length >= 0)
            {
                for (int j = 0; j < Bid.Length - 1; j++)
                {
                    Industry += page.SelIndustryName(Bid[j].ToString()) + "、";//行业名称
                }
            }
            if (Bid.Length == 1)
            {

                Industry = page.SelIndustryName(Bid[0].ToString());

            }

            //string Industry = page.SelIndustryName(Bid[0].ToString());//行业名称
            string lated = page.SelIndustryLated(state.IndustryBID.ToString().Trim());
            string sdt = "";//还款保证
            if (state.IZqYqjjdwqk == "" || state.IZqYqjjdwqk == null || state.IZqYqjjdwqk == "0")
            {
                sdt = "暂无";
            }
            else if (state.IZqYqjjdwqk == "1")
            {
                sdt = "担保";
            }
            else if (state.IZqYqjjdwqk == "2")
            {
                sdt = "抵押";
            }
            else if (state.IZqYqjjdwqk == "3")
            {
                sdt = "信用";
            }
            string iZqXmyxqs = page.SelDictName(state.IZqXmyxqs.ToString());//有效期
            DateTime dt = Convert.ToDateTime(state.PublishT.ToString());
            string publishT = Convert.ToString(dt.ToString("yyyy-MM-dd"));//发布时间
            string mainPoint = page.SelMainPoint();//资源收费查询
            string Fix = "";//收费状态
            if (state.FixPriceID == "1" || state.FixPriceID == "0")
            {
                Fix = "免费";
            }
            else if (state.FixPriceID == "2")
            {
                Fix = "<span style='color:Red'>" + state.MainPointCount.ToString() + "</span>元";
            }
            else
            {
                Fix = "免费";
            }
            if (Convert.ToString(state.AuditingStatus.ToString()) != "1")
            {
                sb.Append("编号:" + str.Trim() + "  所对应的状态为:" + Verify(Convert.ToInt32(state.AuditingStatus.ToString())) + " ，生成静态化页面失败\\n");
            }
            else
            {
                string str1 = Convert.ToString(state.CooperationDemandType).Trim(",".ToCharArray());
                if (str1 == "9")//为债权融资
                {
                    page.ProjectZqHtml(state.Id.ToString(), state.ProjectName.ToString(), state.ComAbout.ToString(), CountryCode, Province, City, County.Trim(), Industry,
                        state.CapitalTotal.ToString(), sdt, iZqXmyxqs, publishT, "", "", state.DisplayTitle.ToString(), state.KeyWord.ToString(),
                        state.Descript.ToString(), 1, lated, mainPoint, Fix);
                }
                else if (str1 == "10")//股权融资
                {
                    page.ProjectZqHtml(state.Id.ToString(), state.ProjectName.ToString(), state.ComAbout.ToString(), CountryCode, Province, City, County.Trim(), Industry,
                       state.CapitalTotal.ToString(), sdt, iZqXmyxqs, publishT, state.ComBrief.ToString(), state.ManageTeamAbout.ToString(), state.DisplayTitle.ToString(), state.KeyWord.ToString(),
                       state.Descript.ToString(), 2, lated, mainPoint, Fix);
                }
                else
                {

                    page.ProjectZqHtml(state.Id.ToString(), state.ProjectName.ToString(), state.ComAbout.ToString(), CountryCode, Province, City, County.Trim(), Industry,
                   state.CapitalTotal.ToString(), sdt, iZqXmyxqs, publishT, state.ComBrief.ToString(), state.ManageTeamAbout.ToString(), state.DisplayTitle.ToString(), state.KeyWord.ToString(),
                     state.Descript.ToString(), 2, lated, mainPoint, Fix);
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
    #endregion

    #region 全部生成静态文件
    protected void btnAll_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string[] values = page.SelProjectAll().Split(',');
        string cc = "";
        foreach (string str in values)
        {
            state = page.SelProjectM(str.Trim());
            string CountryCode = "中国";// visit.SelCountry(ht[3].ToString().Trim());//国家
            string Province = visit.SelProvince(state.ProvinceID.ToString().Trim());//省名
            string City = visit.SelCityID(state.CityID.ToString().Trim());//地区所对应城市
            string County = visit.SelCounty(state.CountyID.ToString().Trim());//地区
            string[] Bid = state.IndustryBID.ToString().Trim().Split(',');
            string Industry = "";
            if (Bid.Length >= 0)
            {
                for (int j = 0; j < Bid.Length - 1; j++)
                {
                    Industry += page.SelIndustryName(Bid[j].ToString()) + "、";//行业名称
                }
            }
            if (Bid.Length == 1)
            {

                Industry = page.SelIndustryName(Bid[0].ToString());

            }

            //string Industry = page.SelIndustryName(Bid[0].ToString());//行业名称
            string lated = page.SelIndustryLated(state.IndustryBID.ToString().Trim());
            string sdt = "";//还款保证
            if (state.IZqYqjjdwqk == "" || state.IZqYqjjdwqk == null || state.IZqYqjjdwqk == "0")
            {
                sdt = "暂无";
            }
            else if (state.IZqYqjjdwqk == "1")
            {
                sdt = "担保";
            }
            else if (state.IZqYqjjdwqk == "2")
            {
                sdt = "抵押";
            }
            else if (state.IZqYqjjdwqk == "3")
            {
                sdt = "信用";
            }
            string iZqXmyxqs = page.SelDictName(state.IZqXmyxqs.ToString());//有效期
            DateTime dt = Convert.ToDateTime(state.PublishT.ToString());
            string publishT = Convert.ToString(dt.ToString("yyyy-MM-dd"));//发布时间
            string mainPoint = page.SelMainPoint();//资源收费查询
            string Fix = "";//收费状态
            if (state.FixPriceID == "1" || state.FixPriceID == "0")
            {
                Fix = "免费";
            }
            else if (state.FixPriceID == "2")
            {
                Fix = "<span style='color:Red'>" + state.MainPointCount.ToString() + "</span>元";
            }
            else
            {
                Fix = "免费";
            }
            if (Convert.ToString(state.AuditingStatus) != "1")
            {
                sb.Append("编号: 所对应的状态为:" + Verify(Convert.ToInt32(state.AuditingStatus.ToString())) + " ，生成静态化页面失败\\n");
            }
            else
            {
                string str1 = Convert.ToString(state.CooperationDemandType).Trim(",".ToCharArray());
                if (str1 == "9")//为债权融资
                {
                    page.ProjectZqHtml(state.Id.ToString(), state.ProjectName.ToString(), state.ComAbout.ToString(), CountryCode, Province, City, County.Trim(), Industry,
                        state.CapitalTotal.ToString(), sdt, iZqXmyxqs, publishT, "", "", state.DisplayTitle.ToString(), state.KeyWord.ToString(),
                        state.Descript.ToString(), 1, lated, mainPoint, Fix);
                }
                else if (str1 == "10")//股权融资
                {
                    page.ProjectZqHtml(state.Id.ToString(), state.ProjectName.ToString(), state.ComAbout.ToString(), CountryCode, Province, City, County.Trim(), Industry,
                       state.CapitalTotal.ToString(), sdt, iZqXmyxqs, publishT, state.ComBrief.ToString(), state.ManageTeamAbout.ToString(), state.DisplayTitle.ToString(), state.KeyWord.ToString(),
                       state.Descript.ToString(), 2, lated, mainPoint, Fix);
                }
                else
                {

                    page.ProjectZqHtml(state.Id.ToString(), state.ProjectName.ToString(), state.ComAbout.ToString(), CountryCode, Province, City, County.Trim(), Industry,
                   state.CapitalTotal.ToString(), sdt, iZqXmyxqs, publishT, state.ComBrief.ToString(), state.ManageTeamAbout.ToString(), state.DisplayTitle.ToString(), state.KeyWord.ToString(),
                     state.Descript.ToString(), 2, lated, mainPoint, Fix);
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
    #endregion

    #region 批量删除
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");


        StringBuilder sb = new StringBuilder();
        foreach (string str in values)
        {
            bool b = Dcommon.bBuyInfoOfUserName(Convert.ToString(str.ToString().Trim()));

            if (b != true)
            {
                string name = page.SelHtmlFile(str.ToString().Trim());
                if (name != "")
                {
                    string[] html = name.Split('/');
                    string[] cc = html[2].Split('.');

                    com.DeleteFile(@RZStatic + html[1].ToString() + @"\" + html[2].ToString());

                }
                else
                {
                    sb.Append("编号:" + str.ToString().Trim() + ",删除失败\\n");
                }
                long info = project.delete(Convert.ToInt32(str.Trim()));
                if (info >= 0)
                {
                    Tz888.Common.MessageBox.Show(this.Page, "删除成功");
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "删除失败");
                }
                this.SetPagerParameters();
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "该信息已有用户购买，不能删除");

            }
        }

    } 
    #endregion




    #region 融资首页静态页面生成
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
            sw = new StreamWriter(@"J:\topfo\rz\" + fileName, false, code);
            //sw = new StreamWriter("F:/topfo/tzweb/News/" + fileName, false, code);
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
    #endregion
    protected void btnShare_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        int begInfoID = Convert.ToInt32(this.begInfo.Value);
        int endInfoID = Convert.ToInt32(this.endInfo.Value);
        string[] name = project.selInfoIdRegion(begInfoID, endInfoID).Split(',');
        string cc = "";
        for (int i = 0; i < name.Length - 1; i++)
        {
            state = page.SelProjectM(Convert.ToString(name[i]));
            //string[] ht = cc.Split('^');
            string CountryCode = "中国";// visit.SelCountry(ht[3].ToString().Trim());//国家
            string Province = visit.SelProvince(state.ProvinceID.ToString().Trim());//省名
            string City = visit.SelCityID(state.CityID.ToString().Trim());//地区所对应城市
            string County = visit.SelCounty(state.CountyID.ToString().Trim());//地区
            string[] Bid = state.IndustryBID.ToString().Trim().Split(',');
            string Industry = "";
            if (Bid.Length >= 0)
            {
                for (int j = 0; j < Bid.Length - 1; j++)
                {
                    Industry += page.SelIndustryName(Bid[j].ToString()) + "、";//行业名称
                }
            }
            if (Bid.Length == 1)
            {

                Industry = page.SelIndustryName(Bid[0].ToString());

            }

            //string Industry = page.SelIndustryName(Bid[0].ToString());//行业名称
            string lated = page.SelIndustryLated(state.IndustryBID.ToString().Trim());
            string sdt = "";//还款保证
            if (state.IZqYqjjdwqk == "" || state.IZqYqjjdwqk == null || state.IZqYqjjdwqk == "0")
            {
                sdt = "暂无";
            }
            else if (state.IZqYqjjdwqk == "1")
            {
                sdt = "担保";
            }
            else if (state.IZqYqjjdwqk == "2")
            {
                sdt = "抵押";
            }
            else if (state.IZqYqjjdwqk == "3")
            {
                sdt = "信用";
            }
            string iZqXmyxqs = page.SelDictName(state.IZqXmyxqs.ToString());//有效期
            DateTime dt = Convert.ToDateTime(state.PublishT.ToString());
            string publishT = Convert.ToString(dt.ToString("yyyy-MM-dd"));//发布时间
            string mainPoint = page.SelMainPoint();//资源收费查询
            string Fix = "";//收费状态
            if (state.FixPriceID == "1" || state.FixPriceID == "0")
            {
                Fix = "免费";
            }
            else if (state.FixPriceID == "2")
            {
                Fix = "<span style='color:Red'>" + state.MainPointCount.ToString() + "</span>元";
            }
            else
            {
                Fix = "免费";
            }
            if (Convert.ToString(state.AuditingStatus) != "1")
            {
                sb.Append("编号:" + Convert.ToString(name[i]) + "  所对应的状态为:" + Verify(Convert.ToInt32(state.AuditingStatus.ToString())) + " ，生成静态化页面失败\\n");
            }
            else
            {
                string str = Convert.ToString(state.CooperationDemandType).Trim(",".ToCharArray());
                if (str == "9")//为债权融资
                {
                    page.ProjectZqHtml(state.Id.ToString(), state.ProjectName.ToString(), state.ComAbout.ToString(), CountryCode, Province, City, County.Trim(), Industry,
                        state.CapitalTotal.ToString(), sdt, iZqXmyxqs, publishT, "", "", state.DisplayTitle.ToString(), state.KeyWord.ToString(),
                        state.Descript.ToString(), 1, lated, mainPoint, Fix);
                }
                else if (str == "10")//股权融资
                {
                    page.ProjectZqHtml(state.Id.ToString(), state.ProjectName.ToString(), state.ComAbout.ToString(), CountryCode, Province, City, County.Trim(), Industry,
                       state.CapitalTotal.ToString(), sdt, iZqXmyxqs, publishT, state.ComBrief.ToString(), state.ManageTeamAbout.ToString(), state.DisplayTitle.ToString(), state.KeyWord.ToString(),
                       state.Descript.ToString(), 2, lated, mainPoint, Fix);
                }
                else
                {

                    page.ProjectZqHtml(state.Id.ToString(), state.ProjectName.ToString(), state.ComAbout.ToString(), CountryCode, Province, City, County.Trim(), Industry,
                   state.CapitalTotal.ToString(), sdt, iZqXmyxqs, publishT, state.ComBrief.ToString(), state.ManageTeamAbout.ToString(), state.DisplayTitle.ToString(), state.KeyWord.ToString(),
                     state.Descript.ToString(), 2, lated, mainPoint, Fix);
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
