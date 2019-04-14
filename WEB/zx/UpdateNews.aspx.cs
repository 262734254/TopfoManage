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
using Tz888.Common;
using Tz888.BLL.zx;
public partial class zx_UpdateNews : System.Web.UI.Page
{
    Tz888.BLL.zx.NewsTabManager bll = new Tz888.BLL.zx.NewsTabManager();
    private static Tz888.BLL.zx.PageStatic cc = new Tz888.BLL.zx.PageStatic(); //实例化创建文件类

    Tz888.BLL.Common.IndustryBLL bllIn = new Tz888.BLL.Common.IndustryBLL();
    news.StaticWebService serivice = new news.StaticWebService();
    BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            SetNewsType();
            Area();
            SetFixWorthPointTabList();
            SetGradeTabList();
            try
            {
                long infoid = Convert.ToInt64(Request["infoID"].ToString());
                DataSet ds = bll.GetOneList( Convert.ToString(infoid));
                ddlSetGrade.SelectedValue = ds.Tables[0].Rows[0]["GradeID"].ToString();
                ddlFix.SelectedValue = ds.Tables[0].Rows[0]["FixPriceID"].ToString();
                ddlNewsType.SelectedValue = ds.Tables[0].Rows[0]["NewsTypeID"].ToString();
                txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                txtKeyword.Text = ds.Tables[0].Rows[0]["Keyword"].ToString();
                txtDescript.Text = ds.Tables[0].Rows[0]["Descript"].ToString();
                txtDisplayTitle.Text = ds.Tables[0].Rows[0]["DisplayTitle"].ToString();
                txtShortTitle.Text = ds.Tables[0].Rows[0]["ShortTitle"].ToString();
                txtShortContent.Text = ds.Tables[0].Rows[0]["ShortContent"].ToString();
                txtSubTitle.Text = ds.Tables[0].Rows[0]["SubTitle"].ToString();
                txtOrigin.Text = ds.Tables[0].Rows[0]["Origin"].ToString();
                txtAuthor.Text = ds.Tables[0].Rows[0]["Author"].ToString();
                rblAuditing.SelectedValue = ds.Tables[0].Rows[0]["AuditingStatus"].ToString().Trim();
                txtHit.Text = ds.Tables[0].Rows[0]["Hit"].ToString();
                txtRedirectUrl.Text = ds.Tables[0].Rows[0]["RedirectUrl"].ToString();
                txtSummary.Text = ds.Tables[0].Rows[0]["Summary"].ToString();
                FCKeditor.Value = ds.Tables[0].Rows[0]["Content"].ToString();
                txtPicAbout.Value = ds.Tables[0].Rows[0]["PicAbout"].ToString();
                txtPageCharCount.Value =ds.Tables[0].Rows[0]["PageCharCount"].ToString();//自动分页字符数
                txtValidateStartTime.Text = ds.Tables[0].Rows[0]["ValidateStartTime"].ToString();
                ddlValiditeTerm.SelectedValue = ds.Tables[0].Rows[0]["ValidateTerm"].ToString();
                txtPublishT.Text = ds.Tables[0].Rows[0]["PublishT"].ToString();
                rblPageStatus.SelectedValue = ds.Tables[0].Rows[0]["PageStatus"].ToString();	//分页方法 0 不分页 1 手动分页 2 自动分页
                string spot = ds.Tables[0].Rows[0]["ResearchSpot"].ToString();//加入中国招商投资研究会
                switch (spot.ToString().Trim())
                {
                    case "0":
                        rbyjcg.Checked = true;
                        break;
                    case "1":
                        rbhyjj.Checked = true;
                        break;
                    case "2":
                        rbfyrw.Checked = true;
                        break;
                }
                ddlIndustry.SelectedValue = ds.Tables[0].Rows[0]["NewsIndustryID"].ToString();
                ddlArea.SelectedValue = ds.Tables[0].Rows[0]["AreaID"].ToString();

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('请重新选择要修改的数据!');window.close();</script>");
            }


        }
    }
    /// <summary>
    /// 新闻类型
    /// </summary>
    private void SetNewsType()
    {

        this.ddlNewsType.DataSource = bllIn.SetNewsType();
        this.ddlNewsType.DataTextField = "NewsTypeName";
        this.ddlNewsType.DataValueField = "NewsTypeID";
        this.ddlNewsType.DataBind();
    }
    /// <summary>
    /// 价值查询
    /// </summary>
    private void SetGradeTabList()
    {

        this.ddlSetGrade.DataSource = bllIn.SetGradeTab();
        this.ddlSetGrade.DataTextField = "GradeName";
        this.ddlSetGrade.DataValueField = "GradeID";
        this.ddlSetGrade.DataBind();
    }
    /// <summary>
    /// 等级查询
    /// </summary>
    private void SetFixWorthPointTabList()
    {

        this.ddlFix.DataSource = bllIn.SetFixWorthPointTab();
        this.ddlFix.DataTextField = "FixWorthPointName";
        this.ddlFix.DataValueField = "FixWorthPointID";
        this.ddlFix.DataBind();
    }

    private void Area()
    {
        ///大区域类型	数据绑定
        ddlArea.DataSource = bllIn.SetAreaTab();
        ddlArea.DataBind();

        ddlArea.Items.Insert(000, "请选择地域性标签");
        ddlArea.Items[0].Selected = true;
        ///新闻行业类型	数据绑定
        ddlIndustry.DataSource = bllIn.SetNewsIndustry();
        ddlIndustry.DataBind();
        ddlIndustry.Items.Insert(00, "请选择行业性标签");
        ddlIndustry.Items[0].Selected = true;
    }
    protected void btnPublish_Click(object sender, EventArgs e)
    {
        string LogingName = bp.LoginName;
        long infoid = Convert.ToInt64(Request["infoID"].ToString());
        string ResearchSpot = "";
        Tz888.BLL.CasesInfoTabBLL state = new Tz888.BLL.CasesInfoTabBLL();
        Tz888.Model.Info.MainInfoModel main = new Tz888.Model.Info.MainInfoModel();//主表
        Tz888.Model.zx.NewsTabModel NewsModel = new Tz888.Model.zx.NewsTabModel();//新闻表
        Tz888.Model.Info.ShortInfoModel shortInfoRule = new Tz888.Model.Info.ShortInfoModel();//短消息表

        //int Hit = 0;
        //Random rnd = new Random();
        //Hit = rnd.Next(25) + 5;
        string NewsLblStatus = "";
        main.publishT = Convert.ToDateTime(DateTime.Now);
        main.Hit =Convert.ToInt32(txtHit.Text.ToString().Trim());
        main.InfoID = infoid;
        main.LoginName = LogingName;
        main.InfoOriginRoleName = "0";
        //ddlNewsType = ddlNewsType.SelectedValue.Trim();//新闻类型
        main.Title = txtTitle.Text.ToString().Trim();//标题
        main.KeyWord = txtKeyword.Text.ToString().Trim();//关键字
        main.Descript = txtDescript.Text.ToString().Trim();//网页描述
        main.DisplayTitle = txtDisplayTitle.Text.ToString().Trim();//显示标题
        main.ValidateStartTime = Convert.ToDateTime(txtValidateStartTime.Text.ToString().Trim());//开始日期
        main.TemplateID = txtTemplate.Text.ToString().Trim();//模版号
        main.ValidateTerm = Convert.ToInt32(ddlValiditeTerm.SelectedValue.ToString().Trim());//有效期
        main.publishT = Convert.ToDateTime(txtPublishT.Text.ToString().Trim());//发布时间
        main.FrontDisplayTime = Convert.ToDateTime(DateTime.Now);//前台显示日期
        int Auditting = 0;
           Auditting = Convert.ToByte(this.rblAuditing.SelectedValue.Trim());//审核状态
           main.AuditingStatus = Auditting;

         if (Auditting == 1)
         {
             main.HtmlFile = "News/" + DateTime.Now.ToString("yyyyMM") + "/News" + DateTime.Now.ToString("yyyyMMdd") + "_" + infoid + ".shtml";
         }
         else 
         {
             main.HtmlFile = "";
         }
        main.GradeID = ddlSetGrade.SelectedValue.Trim();
        main.FixPriceID = ddlFix.SelectedValue.Trim();

        NewsModel.Summary = txtSummary.ToString().Trim();//摘要
        NewsModel.subTitle = txtKeyword.Text.ToString().Trim();//短标题
        NewsModel.NewsTypeID = ddlNewsType.SelectedValue.Trim();//新闻类型

        if (rdArea.Checked)	//新闻标签 0区域，1行业
        {

            if (ddlArea.SelectedValue.Trim() != "请选择地域性标签")
            {
                NewsLblStatus = rdArea.Value;
                NewsModel.AreaID = ddlArea.SelectedValue.Trim();
                NewsModel.NewsIndustryID = ddlIndustry.Items[1].Value.ToString().Trim();
            }
            else
            { Response.Write("<script>alert('请选择地域性标签');</script>"); return; }
        }
        if (rdIndustry.Checked)
        {
            if (ddlIndustry.SelectedValue.Trim() != "请选择行业性标签")
            {
                NewsLblStatus = rdIndustry.Value;
                NewsModel.NewsIndustryID = ddlIndustry.SelectedValue.Trim();
                NewsModel.AreaID = ddlArea.Items[1].Value.ToString().Trim();
            }
            else
            { Response.Write("<script>alert('请选择行业性标签');</script>"); return; }
        }
        NewsModel.NewsLblStatus = NewsLblStatus;
        NewsModel.Origin = txtOrigin.Text.ToString().Trim();//资讯来源
        NewsModel.Author = txtAuthor.Text.ToString().Trim();//作者
        NewsModel.Keyword = txtKeyword.ToString().Trim();//关键字
        NewsModel.RedirectUrl = txtRedirectUrl.Text.ToString().Trim();//转向连接
        NewsModel.IsRedirect = chkIsRedirect.Checked;//是否使用转向连接
        NewsModel.Summary = txtSummary.Text.ToString().Trim();//摘要
        NewsModel.Content = FCKeditor.Value;
        NewsModel.Pic1 = Convert.ToString(ViewState["strSavePath"]);
        NewsModel.PicAbout = txtPicAbout.Value.ToString().Trim();
        NewsModel.PageStatus = Convert.ToInt32(rblPageStatus.SelectedValue);				//分页方法 0 不分页 1 手动分页 2 自动分页
        NewsModel.PageCharCount = Convert.ToInt64(txtPageCharCount.Value.ToString().Trim());					//自动分页字符数
        if (rbyjcg.Checked)														//加入中国招商投资研究会
        { ResearchSpot = "0"; }													//0:研究成果 1：行业聚焦 2：风云人物														
        else if (rbhyjj.Checked)
        { ResearchSpot = "1"; }
        else if (rbfyrw.Checked)
        { ResearchSpot = "2"; }
        else
        { ResearchSpot = ""; }
        NewsModel.ResearchSpot = ResearchSpot;

        #region 短信息表
        shortInfoRule.ShortTitle = txtShortTitle.Text.ToString().Trim();//短标题
        shortInfoRule.ShortContent = txtShortContent.Text.ToString().Trim();//短内容
        shortInfoRule.ShortInfoControlID = "NewsIndex1";//信息容量
        shortInfoRule.Remark = "";
        shortInfoRule.ChangeTime = Convert.ToDateTime(DateTime.Now);//时间
        shortInfoRule.ChangeBy = LogingName;//创建人

        #endregion
        //插入数据
        Tz888.BLL.zx.NewsTabManager bll = new Tz888.BLL.zx.NewsTabManager();
        long InfoID = bll.Update(main, NewsModel, shortInfoRule);


        if (InfoID >= 0)
        {
            int num = serivice.ModifyHtmlFile(Convert.ToInt32(InfoID));
            if (num >= 0)
            {
                cc = cc.NewsIdAll(Convert.ToInt32(InfoID));
                serivice.CreateHtml(Convert.ToInt32(InfoID), cc.Title, cc.PublishT.ToString(), cc.Content, cc.Hit, "tz888Admin", "mtvc2909");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "审核失败");
            }

            Tz888.Common.MessageBox.Show(this.Page, "审核成功");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "审核失败");
        }
        if (InfoID <= 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "审核失败");
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        
    }
    protected void txtAuthor_TextChanged(object sender, EventArgs e)
    {

    }
}
