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

public partial class Project_Project_ZQ : System.Web.UI.Page
{
    protected long _infoid;
    protected string theInfoType = "Project";
     Tz888.BLL.PageBLL page = new Tz888.BLL.PageBLL();
    Tz888.BLL.ProjectState state = new Tz888.BLL.ProjectState();

    Tz888.BLL.Visit.VisitInfoBLL visit = new Tz888.BLL.Visit.VisitInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
         _infoid = Convert.ToInt64(Request.QueryString["id"]);
       // _infoid = 2397088;
        ViewState["infoID"] = _infoid;
        if (!IsPostBack)
        {
            SetValid();
            GetInfoModel();
          
        }
    }

    #region 项目有效期
    /// <summary>
    /// 项目有效期
    /// </summary>
    private void SetValid()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rblXmyxqxx.DataTextField = "cdictname";
        this.rblXmyxqxx.DataValueField = "idictvalue";
        this.rblXmyxqxx.DataSource = dt;
        this.rblXmyxqxx.DataBind();
    } 
    #endregion
    #region 信息加载绑定
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

        this.txtCapitalTotal.Value = model.ProjectInfoModel.CapitalTotal.ToString();

        this.rblYqzjdwqk.SelectedValue = model.ProjectInfoModel.iZqYqjjdwqk.ToString();
        this.rblXmyxqxx.SelectedValue = model.MainInfoModel.ValidateTerm.ToString().Trim(); //model.ProjectInfoModel.iZqXmyxqs.ToString();// model.MainInfoModel.ValidateTerm.ToString();
        this.tbHits.Text = model.MainInfoModel.Hit.ToString();
        this.txtPointCount.Text = model.MainInfoModel.MainPointCount.ToString();

        txtKeord.Value = model.MainInfoModel.KeyWord;//网页关键字
        txtWtitle.Value = model.MainInfoModel.DisplayTitle;//网页标题
        this.txtDescript.Value = model.MainInfoModel.Descript;//网页描述


        this.txtZoneAbout.Value = model.ProjectInfoModel.ComAbout.ToString();

        this.txtCompanyName.Value = model.InfoContactModel.OrganizationName;
        this.txtLinkMan.Value = model.InfoContactModel.Name;
        this.txtTelStateCode.Value = model.InfoContactModel.TelStateCode.Trim();
        this.txtTel.Value = model.InfoContactModel.TelNum;
        this.txtMobile.Value = model.InfoContactModel.Mobile;
        this.txtEmail.Value = model.InfoContactModel.Email;
        this.txtAddress.Value = model.InfoContactModel.Address;
        this.txtWebSite.Value = model.InfoContactModel.WebSite;
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
    } 
    #endregion

    #region 审核事件
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        Tz888.Model.Info.ProjectSetModel model = new Tz888.Model.Info.ProjectSetModel();
        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>(); //上传文件


        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        DateTime time_Now = DateTime.Now;

        industryModels = this.SelectIndustryControl1.IndustryModels;

        model.ProjectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProjectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.ProjectInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.ProjectInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        model.ProjectInfoModel.ProjectName = this.txtProjectName.Value.Trim();
        model.ProjectInfoModel.RecTime = DateTime.Now;
        model.ProjectInfoModel.CapitalCurrency = "CNY";
        model.ProjectInfoModel.ProjectCurrency = "CNY";

        //投资总额
        if (!string.IsNullOrEmpty(this.txtCapitalTotal.Value.Trim()))
            model.ProjectInfoModel.CapitalTotal =Convert.ToDecimal(txtCapitalTotal.Value.Trim());

        //借钱金额
        model.ProjectInfoModel.CapitalID = "0";
        //项目详细描述
        model.ProjectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtZoneAbout.Value.ToString()));
        //行业
        foreach (Tz888.Model.Common.IndustryModel models in industryModels)
        {
            model.ProjectInfoModel.IndustryBID += models.IndustryBID + ",";
        }
        model.ProjectInfoModel.CooperationDemandType = "9";//债券融资

        //融资对象
        model.ProjectInfoModel.financingID = "01,";
        //融资计划及还款能力
        model.ProjectInfoModel.warrant = "";

        //-----------------201006资源超市第二次改版，----------------------//
        //项目立项情况
        model.ProjectInfoModel.cZqXmlxqkb = "1,";
        //企业发展阶段
        model.ProjectInfoModel.cZqQyfzjd = "1";

        //要求资金到位情况
        model.ProjectInfoModel.iZqYqjjdwqk = Tz888.Common.Text.FormatData(rblYqzjdwqk.SelectedValue.Trim());
        //产品市场增长率        
        model.ProjectInfoModel.iZqCpsczzl = 1;

        //产品市场容量
        model.ProjectInfoModel.iZqCpscYl = 1;
        //资产负债率
        model.ProjectInfoModel.iZqZcfzl = 1;
        //流动比率
        model.ProjectInfoModel.iZqYdbl = 1;
        //投资收益率
        model.ProjectInfoModel.iZqTzsl = 1;
        //销售利润率
        model.ProjectInfoModel.iZqXslyl = 1;
        //投资回报期
        model.ProjectInfoModel.iZqTzfbq = 1;
        //项目有效期限
        model.ProjectInfoModel.iZqXmyxqs = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim());
        //项目摘要
        model.ProjectInfoModel.ComBrief = "";

        //项目关键字 textbox
        string strXmgjz = "";
        model.ProjectInfoModel.cZqXmgjz = strXmgjz;

        model.ProjectInfoModel.nDwlyysy = 1;//单位年营业收入
        model.ProjectInfoModel.nDwljly = 1; //单位年净利润
        model.ProjectInfoModel.nDwzzc = 1;//单位总资产
        model.ProjectInfoModel.nDwzfz = 1; //单位总负债
        //产品概述
        model.ProjectInfoModel.cZqCpks = "";
        //市场前景
        model.ProjectInfoModel.marketAbout = "";
        //竞争分析
        model.ProjectInfoModel.cZqJzfx = "";
        //商业模式
        model.ProjectInfoModel.cZqSyms = "";
        //管理团队
        model.ProjectInfoModel.cZqGltd = "";
        //信息完整度
        model.ProjectInfoModel.InformationIntegrity = 0;

        //-----------------------------------主表信息-------------
        if (!string.IsNullOrEmpty(this.txtProjectName.Value))
            model.MainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value);

        string str = industryModels[0].IndustryBID;
        model.MainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Project", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, time_Now);
        string InfoCode = model.MainInfoModel.InfoCode;
        model.MainInfoModel.publishT = time_Now;
        string tb = this.tbHits.Text == "" ? "0" : this.tbHits.Text;
        model.MainInfoModel.Hit = Convert.ToInt32(tb);
        string fix = this.txtPointCount.Text == "" ? "0" : this.txtPointCount.Text;
        model.MainInfoModel.MainPointCount = Convert.ToDecimal(fix);
        model.MainInfoModel.FixPriceID = this.rblFixPrice.SelectedValue.ToString().Trim();
        //   model.MainInfoModel.InfoID = 2397088;
        model.MainInfoModel.InfoID = Convert.ToInt64(ViewState["infoID"].ToString());
        model.MainInfoModel.IsCore = true;

        model.MainInfoModel.KeyWord = txtKeord.Value;//网页关键字
        model.MainInfoModel.DisplayTitle = txtWtitle.Value;//网页标题
        model.MainInfoModel.Descript = txtDescript.Value;//网页描述

        BasePage bp = new BasePage();
        model.MainInfoModel.LoginName = bp.LoginName;
        //model.MainInfoModel.LoginName = "topfo001";
        model.MainInfoModel.InfoOriginRoleName = "0"; //用户角色
        model.MainInfoModel.GradeID = "0";
        model.MainInfoModel.FeeStatus = 0;
        model.MainInfoModel.AuditingStatus = Convert.ToInt32(this.rblAuditing.SelectedValue);

        if (!string.IsNullOrEmpty(this.txtProjectName.Value.Trim()))
            model.MainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        model.MainInfoModel.FrontDisplayTime = time_Now;
        model.MainInfoModel.ValidateStartTime = time_Now;
        model.MainInfoModel.ValidateTerm = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim()); //*项目有效期限

        model.MainInfoModel.TemplateID = "001";

        //------------------------
        model.ShortInfoModel.ShortInfoControlID = "ProjectIndex1";
        model.ShortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());

        string theURL = Request.CurrentExecutionFilePath;

        ////联系信息
        model.InfoContactModel.OrganizationName = txtCompanyName.Value.Trim();
        model.InfoContactModel.Name = txtLinkMan.Value.Trim();
        model.InfoContactModel.TelStateCode = txtTelStateCode.Value.Trim();
        model.InfoContactModel.TelNum = txtTel.Value.Trim();
        model.InfoContactModel.Mobile = txtMobile.Value.Trim();
        model.InfoContactModel.Email = txtEmail.Value.Trim();
        model.InfoContactModel.Address = txtAddress.Value.Trim();
        model.InfoContactModel.WebSite = txtWebSite.Value.Trim();

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
        long InfoID = Convert.ToInt64(ViewState["infoID"]);
        // BasePage bp = new BasePage();
        string LoginName = bp.LoginName;
        //string LoginName = "topfo001";


        bool AllHasDone = false;
        bool HasDone = false;
        //修改属性

        bool h = bll.ProjectInfoZQ_Update_Up(model, infoResourceModels);

        if (h)
        {
            AllHasDone = true;
        }

        int MainPointCount = 0;
        Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
        string strHtmlFile = ViewState["HtmlFile"].ToString();
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

                        #region 生成静态化文件
                        //Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
                        //IsSuccess = staticobj.CreateStaticPageProject_New(InfoID.ToString(), ref actionMsg);

                        //if (!IsSuccess)
                        //{
                        //    AllHasDone = false;//修改失败
                        //}
                        #endregion

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

                        #region 删除已生成的文件

                        //删除静态化文件

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

                        //if (!IsSuccess)
                        //{
                        //    AllHasDone = false;//修改失败
                        //}
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

                        #region 删除已生成的文件

                        //删除静态化文件

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

                        #region 生成静态化文件
                        //Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
                        //IsSuccess = staticobj.CreateStaticPageProject_New(InfoID.ToString(), ref actionMsg);
                        #endregion

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

        #region 修改成功并且状态为1就生成静态页面
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

                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息成功！');location.href='ProjectManage.aspx'", true);

            }

            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息成功！');location.href='ProjectManage.aspx'", true);
            }

        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息失败！');location.href='ProjectManage.aspx'", true);
        }
        #endregion
    } 
    #endregion

    #region 页面跳转
    protected void btnfanhui_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectManage.aspx");
    } 
    #endregion
}
