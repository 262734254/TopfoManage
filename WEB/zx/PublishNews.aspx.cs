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
public partial class zx_PublishNews : System.Web.UI.Page
{
    Tz888.BLL.Common.IndustryBLL bll = new Tz888.BLL.Common.IndustryBLL();
    BasePage bp = new BasePage();
  
    protected void Page_Load(object sender, EventArgs e)
    {
       

        
        if (!Page.IsPostBack)
        {
            txtPublishT.Text = Convert.ToString(DateTime.Now);
            txtValidateStartTime.Text = Convert.ToString(DateTime.Now);
            SetNewsType();
            Area();
            ViewState["strSavePath"] = "";

        }
    }
    
    /// <summary>
    /// 新闻类型
    /// </summary>
    private void SetNewsType()
    {
     
        this.ddlNewsType.DataSource = bll.SetNewsType();
        this.ddlNewsType.DataTextField = "NewsTypeName";
        this.ddlNewsType.DataValueField = "NewsTypeID";
        this.ddlNewsType.DataBind();
    }

    private void Area()
    {
        ///大区域类型	数据绑定
        ddlArea.DataSource = bll.SetAreaTab();
        ddlArea.DataBind();
        
        ddlArea.Items.Insert(000, "请选择地域性标签");
        ddlArea.Items[0].Selected = true;
        ///新闻行业类型	数据绑定
        ddlIndustry.DataSource = bll.SetNewsIndustry();
        ddlIndustry.DataBind();
        ddlIndustry.Items.Insert(00, "请选择行业性标签");
        ddlIndustry.Items[0].Selected = true;
    }
    #region 外侧代码
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            picTitle = Tz888.Common.FileHelper.UploadFile(uploadPic, "", 500, "default");
            switch (picTitle)
            {
                case "1": Response.Write("<script>alert('图片类型不对');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                case "2": Response.Write("<script>alert('图片大小超出500K');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                case "3": Response.Write("<script>alert('请选择上传图片');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                default:
                    ViewState["strSavePath"] = "UploadFile/" + picTitle;
                    this.LblMessage.Text = "上传图片成功"; break;
            }

        }
        else
        {
            //RegisterStartupScript("alertMessage", "<script>alert('请选择上传的图片!'); </script>");
            Response.Write("<scrpit>alert('请选择上传的图片')</script>");
        }
    } 
    #endregion

    protected void btnPublish_Click(object sender, EventArgs e)
    {
        string LoginName = bp.LoginName;
        string ResearchSpot = "";
        Tz888.BLL.CasesInfoTabBLL state= new Tz888.BLL.CasesInfoTabBLL();
        Tz888.Model.Info.MainInfoModel main = new Tz888.Model.Info.MainInfoModel();//主表
        Tz888.Model.zx.NewsTabModel NewsModel = new Tz888.Model.zx.NewsTabModel();//新闻表
        Tz888.Model.Info.ShortInfoModel shortInfoRule = new Tz888.Model.Info.ShortInfoModel();//短消息表
      
        int Hit = 0;
        Random rnd = new Random();
        Hit = rnd.Next(25) + 5;
        string NewsLblStatus = "";
        main.publishT = Convert.ToDateTime(DateTime.Now);
        main.Hit = Hit;
        main.LoginName = LoginName;
        main.InfoOriginRoleName = "0";
        //ddlNewsType = ddlNewsType.SelectedValue.Trim();//新闻类型
        main.Title = txtTitle.Text.ToString().Trim();//标题
        main.KeyWord = txtKeyword.Text.ToString().Trim();//关键字
        main.Descript = txtDescript.Text.ToString().Trim();//网页描述
        main.DisplayTitle = txtDisplayTitle.Text.ToString().Trim();//显示标题
        main.ValidateStartTime =Convert.ToDateTime(txtValidateStartTime.Text.ToString().Trim());//开始日期
        main.TemplateID = txtTemplate.Text.ToString().Trim();//模版号
        main.ValidateTerm = Convert.ToInt32(ddlValiditeTerm.SelectedValue.ToString().Trim());//有效期
        main.publishT = Convert.ToDateTime(txtPublishT.Text.ToString().Trim());//发布时间
        main.FrontDisplayTime = Convert.ToDateTime(DateTime.Now);//前台显示日期
        main.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("News", "", ddlArea.SelectedValue.Trim(), DateTime.Now);     
        main.HtmlFile = "";
        main.AuditingStatus = 0;

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
        NewsModel.Pic1= Convert.ToString(ViewState["strSavePath"]);
        NewsModel.PicAbout = txtPicAbout.Value.ToString().Trim();
        NewsModel.PageStatus = Convert.ToInt32(rblPageStatus.SelectedValue);				//分页方法 0 不分页 1 手动分页 2 自动分页
        NewsModel.PageCharCount =  Convert.ToInt64(txtPageCharCount.Value.ToString().Trim());					//自动分页字符数
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
        shortInfoRule.ChangeBy = LoginName;//创建人

        #endregion	
        //插入数据
        Tz888.BLL.zx.NewsTabManager bll= new Tz888.BLL.zx.NewsTabManager();
        long InfoID = bll.Insert(main, NewsModel, shortInfoRule);

        if (InfoID != 0)
        {
            //if (cbAuditing.Checked)
            //{

            //    main.HtmlFile = "News/" + DateTime.Now.ToString("yyyyMM") + "/News" + DateTime.Now.ToString("yyyyMMdd") + "_" + InfoID + ".shtml";
            //    main.AuditingStatus = 1;
            //}
            //else
            //{
            //    main.HtmlFile = "";
            //    main.AuditingStatus = 0;
            //}

            //long statu = state.UpdateStatus(Convert.ToInt32(InfoID), main.HtmlFile, main.AuditingStatus);
            Response.Write("<script>alert('添加成功');window.location.href='NewsView.aspx';</script>");
        }
        else
        {
            Response.Write("<script language=\"javascript\">alert('添加失败');window.location.href='/PublishNews.aspx';</script>");
        }

		
    }
   
}
