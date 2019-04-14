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

public partial class MerchantManage_UpdateMerchant : System.Web.UI.Page
{
    private static Tz888.BLL.MerchantManage.PageStatic page = new Tz888.BLL.MerchantManage.PageStatic(); //实例化创建文件类
    Tz888.BLL.Static Mercahrstatic = new Tz888.BLL.Static();
    //private long _infoID = 2396663;
    private string theInfoType = "Merchant";
    private string lginName = "";
    Tz888.Model.Info.InfoAuditModel auditModel = new Tz888.Model.Info.InfoAuditModel();

    Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            long _infoID =Convert.ToInt32( Request["infoID"].ToString());
            BindCurrency();
            LoadInfo( _infoID);
            this.FilesUploadControl1.InfoType = "Merchant";
            this.FilesUploadControl1.NoneCount = 5;
            this.FilesUploadControl1.Count = 5;
            
            
        }
    }
    #region 绑定货币种类
    /// <summary>
    /// 绑定货币种类
    /// </summary>
    private void BindCurrency()
    {
        Tz888.BLL.Common.SetCurrencyBLL bll = new Tz888.BLL.Common.SetCurrencyBLL();
        DataView dv = bll.GetList();
        this.ddlCapitalCurrency.DataSource = dv;
        this.ddlCapitalCurrency.DataTextField = "CurrencyName";
        this.ddlCapitalCurrency.DataValueField = "CurrencyID";
        this.ddlCapitalCurrency.DataBind();
    }
    #endregion

    #region 初始信息加载
    private void LoadInfo(long InfoID)
    {

        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();
        //2010-07-28 以上绑定项目有效期限


        Tz888.BLL.Info.MarchantInfoBLL bll = new Tz888.BLL.Info.MarchantInfoBLL();
        Tz888.Model.Info.MerchantSetModel model = bll.GetIntegrityModel(Convert.ToInt64(InfoID));




        //07-28项目有效期限
        this.rdlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();

        this.txtMerchantTopic.Text = model.MainInfoModel.Title;
        if (!string.IsNullOrEmpty(model.MerchantInfoModel.CountryCode))
            this.ZoneSelectControl1.CountryID = model.MerchantInfoModel.CountryCode.Trim();
        if (!string.IsNullOrEmpty(model.MerchantInfoModel.ProvinceID))
            this.ZoneSelectControl1.ProvinceID = model.MerchantInfoModel.ProvinceID.Trim();
        if (!string.IsNullOrEmpty(model.MerchantInfoModel.CityID))
            this.ZoneSelectControl1.CityID = model.MerchantInfoModel.CityID.Trim();
        if (!string.IsNullOrEmpty(model.MerchantInfoModel.CountyID))
            this.ZoneSelectControl1.CountyID = model.MerchantInfoModel.CountyID.Trim();
        this.SelectIndustryControl1.IndustryString = model.MerchantInfoModel.IndustryClassList.Trim();

        string CooperationDemandType = model.MerchantInfoModel.CooperationDemandType.Trim();
        txtHuiBao.Text =Convert.ToString(model.MerchantInfoModel.Merchanreturns);
        txtAddress.Text = model.InfoContactModel.Address;//地址
        txtEmail.Text = model.InfoContactModel.Email;//邮箱
        txtMobile.Text = model.InfoContactModel.Mobile;//手机
        txtCompanyName.Text = model.InfoContactModel.OrganizationName;//联系人
        txtName.Text = model.InfoContactModel.Name;
        txtTelCountry.Text = model.InfoContactModel.TelCountryCode;
        txtTelZoneCode.Text = model.InfoContactModel.TelStateCode;
        txtTelNumber.Text = model.InfoContactModel.TelNum;
        txtKeord.Text = model.MainInfoModel.KeyWord;//网页关键字
        txtWtitle.Text = model.MainInfoModel.DisplayTitle;//网页标题
        this.txtDescript.Text = model.MainInfoModel.Descript;//网页描述
        this.ddlCapitalCurrency.SelectedValue = model.MerchantInfoModel.CapitalCurrency;
        decimal CapitalTotal = Convert.ToDecimal(model.MerchantInfoModel.CapitalTotal);
        if (CapitalTotal > 0)
            this.txtCapitalTotal.Text = CapitalTotal.ToString();


        this.txtZoneAbout.Value = model.MerchantInfoModel.ZoneAbout;

        if (model.MainInfoModel.IsVip == 1)
        {
            chkIsVip.Checked = true;
        }
        txtIsVipAbout.Text = model.MerchantInfoModel.VipAbout.Trim();


        //this.ddlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();

        this.FilesUploadControl1.InfoList = model.InfoResourceModels;


        int FixPriceID = Convert.ToInt32(model.MainInfoModel.FixPriceID.Trim());

        if (FixPriceID > 1)
        {

            chkIsPoint.Checked = true;
            spShowPoint.Attributes.Add("style", "display:''");
        }
        else
        {
            rbFree.Checked = true;
            spShowPoint.Attributes.Add("style", "display:none");
        }
        this.txtPointCount.Text = model.MainInfoModel.MainPointCount.ToString();

        //ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;

        this.tbHits.Text = model.MainInfoModel.Hit.ToString();

        if (model.MainInfoModel.AuditingStatus == 0)
            this.rdAudit.Checked = true;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(0);", true);
        if (model.MainInfoModel.AuditingStatus == 1)
            this.rdPass.Checked = true;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(1);", true);

 
        if (model.MainInfoModel.AuditingStatus == 2)
            this.rdNopass.Checked = true;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(2);", true);

        if (Request.UrlReferrer != null)
            ViewState["strPrePage"] = Request.UrlReferrer.ToString();
        else
            ViewState["strPrePage"] = "";
        lginName = model.MainInfoModel.LoginName;
        ViewState["UserName"] = model.MainInfoModel.LoginName;
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        //ViewState["InfoCode"] = model.MainInfoModel.InfoCode;
        ViewState["PublishT"] = model.MainInfoModel.publishT;
        //ViewState["FrontDisplayTime"] = model.MainInfoModel.FrontDisplayTime;
        //ViewState["ValidateStartTime"] = model.MainInfoModel.ValidateStartTime;
        ViewState["AuditingStatus"] = model.MainInfoModel.AuditingStatus;
        //ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;
        //ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;



    } 
    #endregion

    #region 审核事件
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        long _infoID = Convert.ToInt32(Request["infoID"].ToString());
        Tz888.Model.Info.MerchantSetModel model = new Tz888.Model.Info.MerchantSetModel();
        #region 招商信息实体
        model.MerchantInfoModel.MerchantTypeID = "";// this.rblMerchantType.SelectedValue;
        model.MerchantInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.MerchantInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.MerchantInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.MerchantInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        model.MerchantInfoModel.IndustryClassList = this.SelectIndustryControl1.IndustryString;
        model.MerchantInfoModel.CapitalCurrency = this.ddlCapitalCurrency.SelectedValue;
        model.MerchantInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());
        model.MerchantInfoModel.MerchantCurrency = "";//this.ddlMerchantCurrency.SelectedValue;
        model.MerchantInfoModel.MerchantTotal = ""; //this.ddlMerchantTotal.SelectedValue;
        model.MerchantInfoModel.Merchanreturns =Convert.ToInt32(this.txtHuiBao.Text.Trim());
        //项目现状及规划
        model.MerchantInfoModel.ProjectStatus = "";// txtProjectStatus.Text;
        //项目优势及市场分析
        model.MerchantInfoModel.Market = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //地方经济指标描述
        model.MerchantInfoModel.EconomicIndicators = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //投资环境描述
        model.MerchantInfoModel.InvestmentEnvironment = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //经济效益分析
        model.MerchantInfoModel.Benefit = Tz888.Common.Utility.PageValidate.TxtToHtml("");

        model.MerchantInfoModel.ZoneAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtZoneAbout.Value.ToString()));
        if (ViewState["ZoneAboutBrief"] != null)
        {
            model.MerchantInfoModel.ZoneAboutBrief = ViewState["ZoneAboutBrief"].ToString();
        }

        ViewState["ZoneAboutBrief"] = model.MerchantInfoModel.ZoneAboutBrief;

        model.MerchantInfoModel.CooperationDemandType = "";


        #endregion
        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtMerchantTopic.Text.Trim()))
            model.MainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtMerchantTopic.Text.Trim());
        model.MainInfoModel.publishT = Convert.ToDateTime(this.ViewState["PublishT"]);

        model.MainInfoModel.LoginName = ViewState["UserName"].ToString();//用户名称
        if (chkIsPoint.Checked == true)
        {
         
          model.MainInfoModel.FixPriceID = "2";
          model.MainInfoModel.MainPointCount = Convert.ToInt32(txtPointCount.Text.Trim());
        }
        else
        {
            model.MainInfoModel.MainPointCount = 0;
            model.MainInfoModel.FixPriceID = "1";
        }
      
        string keyword = "";

        byte AuditingOrigin = Convert.ToByte(ViewState["AuditingStatus"]);
        byte AuditingStatus = 0;
        if (rdAudit.Checked == true)
        {
            AuditingStatus = 0;

            model.MainInfoModel.HtmlFile = "";
        }
        if (rdPass.Checked == true)
        {
            AuditingStatus = 1;

            model.MainInfoModel.HtmlFile = "Merchant/" + DateTime.Now.ToString("yyyyMM") + "/Merchant" + DateTime.Now.ToString("yyyyMMdd") + "_" + _infoID + ".shtml";

        }
        if (rdNopass.Checked == true)
        {

            AuditingStatus = 2;

            model.MainInfoModel.HtmlFile = "";

        }
        model.MainInfoModel.AuditingStatus = AuditingStatus;
        //招商重大投资商机设置
        Tz888.BLL.MerchantOppor objOppor = new Tz888.BLL.MerchantOppor();
        if (chkIsVip.Checked)
        {
            objOppor.IsVip(_infoID, 1, txtIsVipAbout.Text.Trim());
        }
        else
        {
            objOppor.IsVip(_infoID, 0, "");
        }
        model.MainInfoModel.Hit = Convert.ToInt32(tbHits.Text.ToString().Trim());
        string KeyWord = this.txtKeord.Text.ToString().Trim();  //关键字
        string DisplayTitle = this.txtWtitle.Text.Trim();     //网页标题
        string Descript = this.txtDescript.Text.ToString().Trim();  //网页描述
        model.MainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(KeyWord);
        model.MainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(DisplayTitle);
        model.MainInfoModel.Descript = txtDescript.Text.ToString().Trim();

        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now;

        //项目有效期限
        model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.rdlValiditeTerm.SelectedValue.Trim());
        model.MainInfoModel.InfoTypeID = "Merchant";
        model.MainInfoModel.TemplateID = "001";


        model.ShortInfoModel.ShortInfoControlID = "";// Convert.ToString(ViewState["ShortInfoControlID"]);
        //if (ViewState["ShortTitle"] != null)
        //{
        //    model.ShortInfoModel.ShortTitle = ViewState["ShortTitle"].ToString();
        //}
        //if (ViewState["ShortContent"] != null)
        //{
        model.ShortInfoModel.ShortContent = ""; //ViewState["ShortContent"].ToString();
        //}


        model.InfoContactModel.Address = txtAddress.Text.ToString().Trim();
        model.InfoContactModel.Email = txtEmail.Text.ToString().Trim();
        model.InfoContactModel.Mobile = txtMobile.Text.ToString().Trim();
        model.InfoContactModel.OrganizationName = txtCompanyName.Text.ToString().Trim();
        model.InfoContactModel.Name = txtName.Text.ToString().Trim();
        model.InfoContactModel.TelCountryCode = txtTelCountry.Text.ToString().Trim();
        model.InfoContactModel.TelStateCode = txtTelZoneCode.Text.ToString().Trim();
        model.InfoContactModel.TelNum = txtTelNumber.Text.ToString().Trim();


        //List<Tz888.Model.Info.InfoResourceModel> infoResourceModels;
        //infoResourceModels = FilesUploadControl1.InfoList;
        ////List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = Tz888.Common.InfoResourceManage.ImageTransfer("Image", "Merchant", Tz888.Common.ResourceType.Image, Tz888.Common.ResourceProperty.InfoImage, FilesUploadControl1.InfoList);
        //if (infoResourceModels != null)
        //    model.InfoResourceModels.AddRange(infoResourceModels);

        //修改附件
        Tz888.BLL.Info.InfoResourceBLL obj2 = new Tz888.BLL.Info.InfoResourceBLL();
        obj2.DeleteByInfoID(long.Parse(this.ViewState["InfoID"].ToString()));
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>();
        infoResourceModels = this.FilesUploadControl1.InfoList;
        if (infoResourceModels != null)
            model.InfoResourceModels.AddRange(infoResourceModels);
        if (infoResourceModels != null)
        {
            foreach (Tz888.Model.Info.InfoResourceModel ResModel in infoResourceModels)
            {
                ResModel.InfoID = long.Parse(this.ViewState["InfoID"].ToString());
                obj2.Insert(ResModel);
            }
        }
        Tz888.BLL.Info.InfoAuditMailBLL MailBll = new Tz888.BLL.Info.InfoAuditMailBLL();
        Tz888.BLL.Info.MarchantInfoBLL bll = new Tz888.BLL.Info.MarchantInfoBLL();
        if (bll.UpdateMerchantSet(model))
        {
            string AuditingRemark = "";
            Tz888.Model.Info.InfoAuditModel auditModel = new Tz888.Model.Info.InfoAuditModel();
            #region 写入信息审核记录
            auditModel = new Tz888.Model.Info.InfoAuditModel();

            auditModel.InfoID = model.MainInfoModel.InfoID;
            auditModel.InfoTypeID = theInfoType;
            auditModel.LoginName = ViewState["UserName"].ToString();
            auditModel.PostDate = System.DateTime.Now;
            auditModel.Title = model.MainInfoModel.Title;
            auditModel.AuditingDate = System.DateTime.Now;
            auditModel.AuditingBy = Page.User.Identity.Name;
            auditModel.Memo = "";
            switch (AuditingOrigin)
            {
                case 0:
                    switch (AuditingStatus)
                    {
                        case 0:
                            break;
                        case 1:
                            AuditingRemark = "未审核->审核通过";
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = AuditingStatus;
                            auditModel.AuditingRemark = AuditingRemark;

                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            break;
                        case 2:
                            AuditingRemark = "未审核->审核未通过";

                            auditModel.AuditStatus = AuditingStatus;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.FeedbackStatus = Convert.ToInt32(this.rblFeedbackStatus.SelectedValue.Trim()); //0,可修改|1,即将删除
                            auditModel.FeedBackNote = tbAuditingRemark.Text.ToString().Trim();


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
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = AuditingStatus;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.FeedbackStatus = 0;
                            break;

                        case 1:
                            AuditingRemark = "审核通过->审核通过（修改）";
                            bool c = mainBll.HasAuditing(_infoID, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                            AuditingRemark, model.MainInfoModel.HtmlFile, "", 0, 0);
                            break;
                        case 2:
                            AuditingRemark = "审核通过->审核未通过";
                            auditModel.AuditStatus = AuditingStatus;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.FeedBackNote = this.tbAuditingRemark.Text.Trim();
                            auditModel.FeedbackStatus = Convert.ToInt32(this.rblFeedbackStatus.SelectedValue.Trim());

                            break;
                        default:
                            break;

                    }
                    break;
                case 2:
                    switch (AuditingOrigin)
                    {
                        case 0:
                            AuditingRemark = "审核未通过->未审核";
                            auditModel.FeedbackStatus = 0;
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = AuditingStatus;
                            auditModel.AuditingRemark = AuditingRemark;
                            break;
                        case 1:
                            AuditingRemark = "审核未通过->审核通过";
                            auditModel.FeedbackStatus = 0;
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = AuditingStatus;
                            auditModel.AuditingRemark = AuditingRemark;
                            break;
                        case 2:
                            AuditingRemark = "审核通过->审核未通过";
                            auditModel.FeedBackNote = this.tbAuditingRemark.Text.Trim();
                            auditModel.AuditStatus = AuditingStatus;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.FeedbackStatus = Convert.ToInt32(this.rblFeedbackStatus.SelectedValue.Trim());
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            bool b = mainBll.InfoAuditNote(auditModel);
            if (b)
            {
                if (model.MainInfoModel.AuditingStatus == 1)
                {
                    int num = page.ModifyHtmlFile(Convert.ToInt32(_infoID));
                    if (num >= 0)
                    {
                        page = page.objGetMerchantInfoByInfoID(_infoID);//根ID获取信息
                        string IsVip = Mercahrstatic.SelIsVip();//查询为重大商机的信息
                        string Idstuny = page.SelectLndus(model.MerchantInfoModel.ProvinceID);//根据区域查询信息
                        int sum = page.StaticHtml(Convert.ToInt32(_infoID), page.Title, page.PublishT, page.AreaName, page.Content, page.IndustryCarveOutID, page.MerchantNameTotal, page.ValidateID, Idstuny, IsVip, KeyWord, DisplayTitle, Descript, page.Merchanreturns);

                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('生成静态页面失败！');location.href='MerchantManage.aspx'", true);
                    }
                }
                Response.Redirect("MerchantManage.aspx");


            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息失败！');location.href='MerchantManage.aspx'", true);
            }

            #endregion

        }
        else
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息失败！');location.href='MerchantManage.aspx'", true);

    } 
    #endregion

}
