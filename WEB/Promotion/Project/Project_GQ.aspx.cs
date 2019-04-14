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

public partial class Project_Project_GQ : System.Web.UI.Page
{
    Tz888.BLL.ProjectState state = new Tz888.BLL.ProjectState();

    protected long _infoid;
    protected string theInfoType = "Project";
    Tz888.BLL.PageBLL page = new Tz888.BLL.PageBLL();
    Tz888.BLL.Visit.VisitInfoBLL visit = new Tz888.BLL.Visit.VisitInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
       // _infoid = 2397084;
        _infoid = Convert.ToInt64(Request["id"].ToString());
        ViewState["InfoID"] = _infoid;
        if (!IsPostBack)
        {
            BindSetCapital();
            Xmyxqxx();
            GetInfoModel();
            this.FilesUploadControl1.InfoType = "Project";
            this.FilesUploadControl1.NoneCount = 5;
            this.FilesUploadControl1.Count = 5;            

        }
    }
    #region 绑定融资金额
    // 绑定融资金额
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        rbtnCapital.DataSource = bll.GetList();
        rbtnCapital.DataTextField = "CapitalName";
        rbtnCapital.DataValueField = "CapitalID";
        rbtnCapital.DataBind();
        //rbtnCapital.SelectedIndex = 0; 选定第一个
    } 
    #endregion

    #region 项目有效期限
    //项目有效期限
    public void Xmyxqxx()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='Xmyxqxx' ");
        rblXmyxqxx.DataTextField = "cdictname";
        rblXmyxqxx.DataValueField = "idictvalue";
        rblXmyxqxx.DataSource = dt;
        rblXmyxqxx.DataBind();
    } 
    #endregion
    #region 查看编号所对应的详细信息
    /// <summary>
    /// 查看编号所对应的详细信息
    /// </summary>
    public void GetInfoModel()
    {
        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.ProjectSetModel model = bll.GetIntegrityModel(_infoid);

        if (model == null)
            return;
        this.txtProjectName.Value = model.ProjectInfoModel.ProjectName;

        this.SelectIndustryControl1.IndustryString = model.ProjectInfoModel.IndustryBID;

        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CountryCode.Trim()))
            this.ZoneSelectControl1.CountryID = model.ProjectInfoModel.CountryCode.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.ProvinceID.Trim()))
            this.ZoneSelectControl1.ProvinceID = model.ProjectInfoModel.ProvinceID.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CityID.Trim()))
            this.ZoneSelectControl1.CityID = model.ProjectInfoModel.CityID.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CountyID.Trim()))
            this.ZoneSelectControl1.CountyID = model.ProjectInfoModel.CountyID.Trim();

        this.txtCapitalTotal.Text = model.ProjectInfoModel.CapitalTotal.ToString();
        txtKeord.Value = model.MainInfoModel.KeyWord;//网页关键字
        txtWtitle.Value = model.MainInfoModel.DisplayTitle;//网页标题
        this.txtDescript.Value = model.MainInfoModel.Descript;//网页描述

        this.rblXmyxqxx.SelectedValue = model.MainInfoModel.ValidateTerm.ToString().Trim();// model.ProjectInfoModel.iZqXmyxqs.ToString();

        if (model.ProjectInfoModel.CapitalID != "")
            rbtnCapital.SelectedValue = model.ProjectInfoModel.CapitalID;
        ////项目摘要
        txtProIntro.Value = model.ProjectInfoModel.ComBrief.Trim();
        ////项目详细描述
        txtXmqxms.Value = GetHtml(model.ProjectInfoModel.ComAbout);
        txtManageTeamAbout.Value = model.ProjectInfoModel.ManageTeamAbout.Trim();

        //联系信息
        if (model.InfoContactModel != null)
        {
            this.txtCompanyName.Value = model.InfoContactModel.OrganizationName;
            this.txtLinkMan.Value = model.InfoContactModel.Name;
            this.txtTelStateCode.Value = model.InfoContactModel.TelStateCode.Trim();
            this.txtTel.Value = model.InfoContactModel.TelNum;
            this.txtMobile.Value = model.InfoContactModel.Mobile;
            this.txtEmail.Value = model.InfoContactModel.Email;
            this.txtAddress.Value = model.InfoContactModel.Address;
            this.txtWebSite.Value = model.InfoContactModel.WebSite;
        }
        this.rblAuditing.SelectedValue = model.MainInfoModel.AuditingStatus.ToString();
        ViewState["AuditingStaus"] = model.MainInfoModel.AuditingStatus.ToString();
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile.ToString();
        if (this.rblAuditing.SelectedValue == "0")
        {
            span1.Style["display"] = "none";
            span2.Style["display"] = "none";
            span3.Style["display"] = "none";
            span4.Style["display"] = "none";
        }
        else if (this.rblAuditing.SelectedValue == "1")
        {
            span1.Style["display"] = "none";
            span2.Style["display"] = "none";
            span3.Style["display"] = "block";
            span4.Style["display"] = "block";
        }
        else if (this.rblAuditing.SelectedValue == "2")
        {
            span1.Style["display"] = "block";
            span2.Style["display"] = "block";
            span3.Style["display"] = "none";
            span4.Style["display"] = "none";
        }

        this.tbHits.Text = model.MainInfoModel.Hit.ToString().Trim();
        this.rblFixPrice.SelectedValue = model.MainInfoModel.FixPriceID.ToString().Trim();
        if (this.rblFixPrice.SelectedValue == "2")
        {
            span5.Style["display"] = "block";
        }

        ViewState["PublishT"] = model.MainInfoModel.publishT;
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;
        ViewState["ProjectNameBrief"] = model.ProjectInfoModel.ProjectNameBrief;
        this.FilesUploadControl1.InfoList = model.InfoResourceModels;

        //ViewState["ShortTitle"] = model.ShortInfoModel.ShortTitle;
        //ViewState["ShortContent"] = model.ShortInfoModel.ShortContent;
        //ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;
    } 
    #endregion
    #region 审核事件
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Tz888.Model.Info.ProjectSetModel model = new Tz888.Model.Info.ProjectSetModel();

        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>();

        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        DateTime time_Now = DateTime.Now;

        model.ProjectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProjectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.ProjectInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.ProjectInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        model.ProjectInfoModel.ProjectName = this.txtProjectName.Value.Trim();
        model.ProjectInfoModel.RecTime = DateTime.Now;
        model.ProjectInfoModel.CapitalCurrency = "CNY";
        model.ProjectInfoModel.ProjectCurrency = "CNY";
        model.ProjectInfoModel.CooperationDemandType = "10";
        //新属性
        string returnmodelid = "4";//退出方式

        model.ProjectInfoModel.ReturnModeID = returnmodelid;
        model.ProjectInfoModel.ProjectAbout = "";
        model.ProjectInfoModel.marketAbout = "";
        model.ProjectInfoModel.competitioAbout = "";
        model.ProjectInfoModel.BussinessModeAbout = "";
        model.ProjectInfoModel.ManageTeamAbout = txtManageTeamAbout.Value.Trim();
        model.ProjectInfoModel.iZqXmyxqs = Convert.ToInt32(this.rblXmyxqxx.SelectedValue.ToString());

        //借款单位年营业收入
        model.ProjectInfoModel.nDwlyysy = 1;
        ////借款单位年净利润
        model.ProjectInfoModel.nDwljly = 1;
        ////借款单位总资产
        model.ProjectInfoModel.nDwzzc = 1;

        //借款单位总负债
        model.ProjectInfoModel.nDwzfz = 1;

        if (!string.IsNullOrEmpty(this.txtCapitalTotal.Text.Trim()))
            model.ProjectInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());
        model.ProjectInfoModel.CapitalID = this.rbtnCapital.SelectedValue;

        model.ProjectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtXmqxms.Value.Trim());
        model.ProjectInfoModel.IndustryBID = this.SelectIndustryControl1.IndustryString;

        model.ProjectInfoModel.financingID = "";
        if (Convert.ToString(ViewState["ProjectNameBrief"].ToString()) == "")
        {
            model.ProjectInfoModel.ProjectNameBrief = "";
        }
        else
        {
            model.ProjectInfoModel.ProjectNameBrief = Convert.ToString(ViewState["ProjectNameBrief"].ToString());
        }

        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtProjectName.Value.Trim()))
            model.MainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        // model.MainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Project", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, time_Now);
        string InfoCode = "";
        model.MainInfoModel.publishT = Convert.ToDateTime(this.ViewState["PublishT"]);

        BasePage bp = new BasePage();
        model.MainInfoModel.LoginName = bp.LoginName;
        // model.MainInfoModel.LoginName = "topfo001";
        string tb = this.tbHits.Text == "" ? "0" : this.tbHits.Text;
        model.MainInfoModel.Hit = Convert.ToInt32(tb);
        string fix = this.txtPointCount.Text == "" ? "0" : this.txtPointCount.Text;
        model.MainInfoModel.MainPointCount = Convert.ToDecimal(fix);
        model.MainInfoModel.FixPriceID = this.rblFixPrice.SelectedValue.ToString().Trim();

        model.MainInfoModel.KeyWord = txtKeord.Value;//网页关键字
        model.MainInfoModel.DisplayTitle = txtWtitle.Value;//网页标题
        model.MainInfoModel.Descript = this.txtDescript.Value;//网页描述

        model.MainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now;


        model.MainInfoModel.TemplateID = "001";
        if (ViewState["HtmlFile"] == "")
        {
            model.MainInfoModel.HtmlFile = "Project/" + DateTime.Now.ToString("yyyyMM") + "/Project" + DateTime.Now.ToString("yyyyMMdd") + "_" + Convert.ToInt64(this.ViewState["InfoID"]) + ".shtml";
        }
        else
        {
            model.MainInfoModel.HtmlFile = Convert.ToString(ViewState["HtmlFile"].ToString());
        }

        model.ShortInfoModel.ShortInfoControlID = "";
        model.ShortInfoModel.ShortTitle = "";
        model.ShortInfoModel.ShortContent = "";
        model.ShortInfoModel.Remark = "";

        //联系信息
        model.InfoContactModel.OrganizationName = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtCompanyName.Value.Trim());
        model.InfoContactModel.Name = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtLinkMan.Value.Trim());
        model.InfoContactModel.Career = "";
        model.InfoContactModel.TelStateCode = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtTelStateCode.Value.Trim());
        model.InfoContactModel.TelNum = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtTel.Value.Trim());
        model.InfoContactModel.Mobile = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtMobile.Value.Trim());
        model.InfoContactModel.Email = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtEmail.Value.Trim());
        model.InfoContactModel.Address = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtAddress.Value.Trim());
        model.InfoContactModel.WebSite = txtWebSite.Value.Trim();

        //-----------------201006资源超市第二次改版，----------------------//
        //项目立项情况
        model.ProjectInfoModel.sXmlxqk = "";
        //企业发展阶段
        model.ProjectInfoModel.sQyfzjd = "";

        //要求资金到位情况
        model.ProjectInfoModel.iYqzjdwqk = Tz888.Common.Text.FormatData("1");

        //--------------------------------------------------------------
        //*市场占有率(份额)
        model.ProjectInfoModel.iSczylfy = Tz888.Common.Text.FormatData("1");
        //*行业市场增长率
        model.ProjectInfoModel.iHysczzl = Tz888.Common.Text.FormatData("1");
        //*资产负债率
        model.ProjectInfoModel.iZcfzl = Tz888.Common.Text.FormatData("1");
        //--------------------------------------------------------------
        //投资回报期
        model.ProjectInfoModel.iXmtzfbzq = Tz888.Common.Text.FormatData("1");

        //项目有效期限
        model.MainInfoModel.ValidateTerm = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim());
        //项目摘要
        model.ProjectInfoModel.ComBrief = txtProIntro.Value.Trim();

        //项目关键字 textbox

        model.ProjectInfoModel.sXmgjz = "融资";
        //产品概述
        model.ProjectInfoModel.ProjectAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(" ");
        //市场前景
        model.ProjectInfoModel.marketAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(" ");
        //竞争分析
        model.ProjectInfoModel.competitioAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(" ");
        //商业模式
        model.ProjectInfoModel.BussinessModeAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(" ");
        //管理团队
        model.ProjectInfoModel.ManageTeamAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtManageTeamAbout.Value.Trim());

        //信息完整度
        model.ProjectInfoModel.InformationIntegrity = 80;
        //-----------------END--------------------------------------------

        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();



        byte AuditingOrigin = Convert.ToByte(ViewState["AuditingStaus"]);
        byte AuditingStatus = 0;

        AuditingStatus = Convert.ToByte(this.rblAuditing.SelectedValue.ToString());

        bool IsSuccess = false;
        string actionMsg = "";
        bool IsSendEmail = false;
        int FeedbackStatus = 0;
        string FeedBackNote = "";
        string AuditingRemark = "";
        long InfoID = Convert.ToInt64(ViewState["InfoID"]);
        //  string LoginName = Page.User.Identity.Name;
        // string LoginName = "topfo001";
        // BasePage bp = new BasePage();
        string LoginName = bp.LoginName;

        bool AllHasDone = false;
        bool HasDone = false;
        //修改属性

        infoResourceModels = this.FilesUploadControl1.InfoList;



        bool h = bll.ProjectInfoGQ_Update_Up(model, infoResourceModels);

        if (h)
        {
            AllHasDone = true;
        }

        int MainPointCount = 0;
        Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
        string strHtmlFile = Convert.ToString(ViewState["HtmlFile"].ToString());
        if (strHtmlFile == "")
        {
            strHtmlFile = "Project/" + DateTime.Now.ToString("yyyyMM") + "/Project" + DateTime.Now.ToString("yyyyMMdd") + "_" + Convert.ToInt64(this.ViewState["InfoID"]) + ".shtml";
        }

        #region 审核

        Tz888.Model.Info.InfoAuditModel auditModel = new Tz888.Model.Info.InfoAuditModel();

        try
        {
            MainPointCount = Convert.ToInt32(txtPointCount.Text.Trim());
            if (MainPointCount < 0)
                MainPointCount = 0;
        }
        catch
        {
            MainPointCount = 0;
        }

        switch (AuditingOrigin)
        {
            case 0:
                switch (AuditingStatus)
                {
                    case 0:
                        break;
                    case 1:
                        AuditingRemark = "未审核->审核通过";

                        #region 写入操作记录
                        //需要生成文件
                        if (string.IsNullOrEmpty(strHtmlFile.Trim()))
                            strHtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName(theInfoType, InfoCode, _infoid);
                        //更改审核状态，同时记录操作
                        HasDone = mainBll.HasAuditing(_infoid, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                        auditModel.FeedBackNote = "";
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = bp.LoginName;
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);

                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        //#region 生成静态化文件
                        //Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
                        //IsSuccess = staticobj.CreateStaticPageProject_New(InfoID.ToString(), ref actionMsg);
                        //#endregion

                        IsSendEmail = true;

                        break;
                    case 2:
                        AuditingRemark = "未审核->审核未通过";

                        #region 写入操作记录
                        HasDone = mainBll.HasAuditing(_infoid, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, "", "", 0, MainPointCount);
                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        #region 写入信息审核记录
                        if (rblFeedbackStatus.SelectedValue.Trim() != "")
                        {
                            FeedbackStatus = Convert.ToInt32(this.rblFeedbackStatus.SelectedValue.Trim());
                        }
                        FeedBackNote = this.tbAuditingRemark.Text.Trim();

                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;

                        auditModel.FeedbackStatus = FeedbackStatus;
                        auditModel.FeedBackNote = this.tbAuditingRemark.Text.Trim();
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = bp.LoginName;
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);

                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        IsSendEmail = true;

                        break;
                    default:
                        break;
                }
                break;
            case 1:
                switch (AuditingStatus)
                {
                    case 0:
                        AuditingRemark = "审核通过->未审核";

                        #region 写入操作记录
                        //更改审核状态，同时记录操作
                        HasDone = mainBll.HasAuditing(_infoid, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, "", "", 0, MainPointCount);

                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = 0;
                        auditModel.FeedBackNote = "";
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = bp.LoginName;
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);

                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        break;
                    case 1:
                        #region 生成静态化文件
                        //需要生成文件
                        if (string.IsNullOrEmpty(strHtmlFile.Trim()))
                            strHtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName(theInfoType, InfoCode, _infoid);
                        //记录操作
                        HasDone = mainBll.HasAuditing(InfoID, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);

                        //Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
                        //IsSuccess = staticobj.CreateStaticPageProject_New(InfoID.ToString(), ref actionMsg);

                        #endregion
                        break;
                    case 2:
                        AuditingRemark = "审核通过->审核未通过";

                        #region 写入操作记录
                        //更改审核状态，同时记录操作
                        HasDone = mainBll.HasAuditing(_infoid, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, "", "", 0, MainPointCount);
                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        #region 写入信息审核记录

                        FeedbackStatus = Convert.ToInt32(this.rblFeedbackStatus.SelectedValue.Trim());
                        FeedBackNote = this.tbAuditingRemark.Text.Trim();

                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = Convert.ToInt32(this.rblFeedbackStatus.SelectedValue.Trim());
                        auditModel.FeedBackNote = this.tbAuditingRemark.Text.Trim();
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = bp.LoginName;
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);
                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        IsSendEmail = true;

                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch (AuditingStatus)
                {
                    case 0:
                        AuditingRemark = "审核未通过->未审核";

                        #region 写入操作记录
                        HasDone = mainBll.HasAuditing(_infoid, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, "", "", 0, MainPointCount);
                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = 0;
                        auditModel.FeedBackNote = "";
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = bp.LoginName;
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);
                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        break;
                    case 1:
                        AuditingRemark = "审核未通过->审核通过";

                        #region 写入操作记录
                        if (string.IsNullOrEmpty(strHtmlFile.Trim()))
                            strHtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName(theInfoType, InfoCode, _infoid);

                        HasDone = mainBll.HasAuditing(_infoid, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        #region 写入信息审核记录
                        auditModel = new Tz888.Model.Info.InfoAuditModel();
                        auditModel.InfoID = model.MainInfoModel.InfoID;
                        auditModel.InfoTypeID = theInfoType;
                        auditModel.LoginName = model.MainInfoModel.LoginName;
                        auditModel.PostDate = System.DateTime.Now;
                        auditModel.Title = model.MainInfoModel.Title;
                        auditModel.FeedbackStatus = 0;
                        auditModel.FeedBackNote = "";
                        auditModel.AuditStatus = AuditingStatus;
                        auditModel.AuditingDate = System.DateTime.Now;
                        auditModel.AuditingBy = bp.LoginName;
                        auditModel.AuditingRemark = AuditingRemark;
                        auditModel.Memo = "";
                        HasDone = mainBll.InfoAuditNote(auditModel);
                        if (!HasDone)
                        {
                            AllHasDone = false;//修改失败
                        }
                        #endregion

                        //#region 生成静态化文件
                        //Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
                        //IsSuccess = staticobj.CreateStaticPageProject_New(InfoID.ToString(), ref actionMsg);
                        //#endregion

                        IsSendEmail = true;

                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        #endregion

        #region 邮件通知
        if (IsSendEmail)
        {
            //try
            //{
            //    Tz888.BLL.Info.InfoAuditMailBLL MailBll = new Tz888.BLL.Info.InfoAuditMailBLL();
            //    if (AuditingStatus == 1)
            //        MailBll.SendPassMail(LoginName, Title, strHtmlFile, Server.MapPath(MailBll.GetEmailPassTmpPath()));
            //    else
            //        MailBll.SendNoPassEmail(_infoid, LoginName, Title, FeedbackStatus, FeedBackNote, "Capital", Server.MapPath(MailBll.GetEmailNoPassTmpPath()));
            //}
            //catch (Exception ex)
            //{
            //}
        }
        #endregion

        #region 审核成功状态为1就生成静态页面
        if (AllHasDone)
        {
            if (AuditingStatus == 1)
            {
                string cc = "";
                state = page.SelProjectM(Convert.ToString(_infoid));
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

                // string Industry =page.SelIndustryName(Bid[0].ToString());//行业名称
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

            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息成功！');location.href='ProjectManage.aspx'", true);
        }
        #endregion
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息失败！');location.href='ProjectManage.aspx'", true);
        }
    } 
    #endregion
    #region 页面跳转
    protected void btnfan_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectManage.aspx");
    } 
    #endregion
    #region 字符串替换
    public static string GetSafetyStr(string sStr)
    {
        string returnStr = sStr;
        returnStr = returnStr.Replace("&", "&amp;");
        returnStr = returnStr.Replace("'", "’");
        returnStr = returnStr.Replace("\"", "&quot;");
        returnStr = returnStr.Replace(" ", "&nbsp;");
        returnStr = returnStr.Replace("<", "&lt;");
        returnStr = returnStr.Replace(">", "&gt;");
        returnStr = returnStr.Replace("\n", "<br>");

        return returnStr;
    }
    public static string GetHtml(string sStr)
    {
        string returnStr = sStr;
        returnStr = returnStr.Replace("&amp;", "&");
        returnStr = returnStr.Replace("’", "'");
        returnStr = returnStr.Replace("&quot;", "\"");
        returnStr = returnStr.Replace("&nbsp;", " ");
        returnStr = returnStr.Replace("&lt;", "<");
        returnStr = returnStr.Replace("&gt;", ">");
        returnStr = returnStr.Replace("<br>", "\n");

        return returnStr;
    } 
    #endregion
}
