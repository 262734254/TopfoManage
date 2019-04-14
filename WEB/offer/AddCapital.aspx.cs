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
using System.Text;
using System.Text.RegularExpressions;

public partial class offer_AddCapital : System.Web.UI.Page
{
    private static Tz888.BLL.offer.PageStatic page = new Tz888.BLL.offer.PageStatic(); //实例化创建文件类

    Tz888.BLL.Static Mercahrstatic = new Tz888.BLL.Static();
    Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();
    Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
    BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {

        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));

        if (!this.Page.IsPostBack)
        {
            this.BindSetCapital();

            LoadInfoContact();


            this.BindCooperationDemandType();
            this.BindDateEnd();


        }

        //以下是取得上传文件信息
        this.FilesUploadControl1.InfoType = "Capital";
        this.FilesUploadControl1.NoneCount = 5;
        this.FilesUploadControl1.Count = 5;

    }
    #region 初试值
    /// <summary>
    /// 设置融资金额
    /// </summary>
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        rblCurreny.DataSource = bll.GetList();
        rblCurreny.DataTextField = "CapitalName";
        rblCurreny.DataValueField = "CapitalID";
        rblCurreny.DataBind();
    }

    /// <summary>
    /// 绑定项目合作类型
    /// </summary>
    private void BindCooperationDemandType()
    {
        this.chkLstCooperationDemand.DataSource = Tz888.BLL.Info.Common.GetCooperationDemandList("Capital");
        this.chkLstCooperationDemand.DataTextField = "CooperationDemandName";
        this.chkLstCooperationDemand.DataValueField = "CooperationDemandTypeID";
        this.chkLstCooperationDemand.DataBind();
    }

    /// <summary>
    /// 项目有效期限
    /// </summary>
    private void BindDateEnd()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();
    }

    #endregion


    #region 从OrgContactModel 获取相应的数据 插入到InfoContactModel中通过insert 传到下一步中 然后下面的就update之
    private Tz888.Model.Info.InfoContactModel GetInfoContact()
    {
        //string loginName = "cn001";
        string loginName = bp.LoginName;
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();

        model = bll.getContactModel(loginName);
        Tz888.Model.Info.InfoContactModel model1 = new Tz888.Model.Info.InfoContactModel();

        if (model == null)
            return model1;
        // 这里改变投资机构名称到联系方式中
        //model1.OrganizationName = this.txtGovName.Text;

        model1.OrganizationName = " ";
        model1.OrgIntro = " ";
        model1.Name = model.Name.Trim();
        model1.Mobile = model.Mobile.Trim();
        model1.PostCode = model.PostCode.Trim();
        model1.TelCountryCode = model.TelCountryCode.Trim();
        model1.TelNum = model.TelNum.Trim();
        model1.TelStateCode = model.TelStateCode.Trim();
        model1.WebSite = model.Website.Trim();
        model1.FaxCountryCode = model.FaxCountryCode.Trim();
        model1.FaxNum = model.FaxNum.Trim();
        model1.FaxStateCode = model.FaxStateCode.Trim();
        model1.Email = model.Email.Trim();
        model1.Address = model.address.Trim();
        model1.Career = model.Career.Trim();


        return model1;
    }

    #endregion


    #region 信息初始化绑定
    private void LoadInfoContact()
    {
       
    }
    #endregion


    protected void IbtnSubmit_Click(object sender, EventArgs e)
    {




        //获取投资资源的信息
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.V124.CapitalInfoModel capitalInfoModel = new Tz888.Model.Info.V124.CapitalInfoModel(); //创建投资信息实体
        List<Tz888.Model.Info.CapitalInfoAreaModel> capitalInfoAreaModels = new List<Tz888.Model.Info.CapitalInfoAreaModel>();//投资区域信息实体列表
        Tz888.Model.Info.ShortInfoModel shortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        //以下是文件上传的实体声明
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>();

        DateTime time_now = DateTime.Now;

        //拟投向区域
        capitalInfoAreaModels = this.ZoneMoreSelectControl1.CapitalInfoAreaModels;

        //主体信息实体付值


        #region 投资信息实体赋值

        //投资意向详细说明
        capitalInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtCapitalIntent.Value.Trim());

        //单项目可投资金额

        capitalInfoModel.CapitalID = this.rblCurreny.SelectedValue;
        //投资回报率
        capitalInfoModel.RegisteredCapital = this.txtHBao.Text.ToString().Trim();
        //项目介绍提炼
        capitalInfoModel.ComBreif = "";

        capitalInfoModel.CooperationDemandType = "";

        //拟投资行业
        capitalInfoModel.IndustryBID = this.SelectIndustryControl1.IndustryString;
        //投资项目阶段
        //2010-06-23

        capitalInfoModel.stageID = Convert.ToInt32(1);//(this.rblStage.SelectedValue);
        // 是否参与项目方管理
        //2010-06-23
        capitalInfoModel.joinManageID = Convert.ToInt32(1); //(this.rdlJoinManage.SelectedValue);

        //投资方式
        for (int i = 0; chkLstCooperationDemand.Items.Count > i; i++)
        {
            if (chkLstCooperationDemand.Items[i].Selected)
            {
                capitalInfoModel.CooperationDemandType += chkLstCooperationDemand.Items[i].Value + ",";
            }
        }


        //以下是需要添加的参数
        //注册资金
        //capitalInfoModel.RegisteredCapital = "";// this.rblRegisterdollar.SelectedValue;
        //团队规模  
        capitalInfoModel.TeamScale = "";// this.rblTeam.SelectedValue;
        //机构年平均投资事件数
        capitalInfoModel.AverageInvestment = "";// this.rblPinJ.SelectedValue;
        //机构成功投资事件总数
        capitalInfoModel.SuccessfulInvestment = "";// this.rblSucess.SelectedValue;
        //投资需求摘要
        capitalInfoModel.InvestmentDemand = Tz888.Common.Utility.PageValidate.TxtToHtml("");

        //添加所属区域


        capitalInfoModel.SCountryID = "001";
        capitalInfoModel.SProvinceID = "001";
        capitalInfoModel.SCityID = "001";
        capitalInfoModel.SCountyID = "001";



        //项目承办单位
        capitalInfoModel.Prorganizers = "no";
        //文件上传的
        infoResourceModels = FilesUploadControl1.InfoList;


        #endregion


        //这里是其他的实体值
        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());

        string CountryCode;
        try
        {
            CountryCode = capitalInfoAreaModels[0].CountryCode;
        }
        catch
        {
            CountryCode = "ALL";
        }
        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Capital", capitalInfoModel.IndustryBID.Split(',')[0], CountryCode, time_now);
        mainInfoModel.publishT = time_now;
        mainInfoModel.Hit = 0;
        mainInfoModel.MainPointCount = Convert.ToDecimal(txtPointCount.Text.ToString().Trim());
        mainInfoModel.IsCore = true;
        //mainInfoModel.LoginName = "cxj";

        mainInfoModel.LoginName = bp.LoginName; //用户名称
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";

        if (chkIsPoint.Checked == true)
        {
            mainInfoModel.FixPriceID = "2";
        }
        else
        {
            mainInfoModel.FixPriceID = "1";
        }

        mainInfoModel.FeeStatus = 0;

        string keyword = "";


        mainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        mainInfoModel.Descript = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        mainInfoModel.FrontDisplayTime = time_now;
        mainInfoModel.ValidateStartTime = time_now;
        //意向有效期限
        //20100623
        mainInfoModel.ValidateTerm = Convert.ToInt32(this.rdlValiditeTerm.SelectedValue.Trim());
        capitalInfoModel.isVIP = Convert.ToInt32(this.ddlIsVip.SelectedValue.ToString());
        mainInfoModel.IsVip = Convert.ToInt32(this.ddlIsVip.SelectedValue.ToString());
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";

        shortInfoModel.ShortInfoControlID = "CapitalIndex1";
        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            shortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        shortInfoModel.ShortContent = "";
        shortInfoModel.Remark = "";

        Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();

        //这里是插入资源投资信息
        //long infoID = bll.Insert(mainInfoModel, capitalInfoModel, this.GetInfoContact(), shortInfoModel, capitalInfoAreaModels, null, infoResourceModels);
        long infoID = bll.Insert(mainInfoModel, capitalInfoModel, this.GetInfoContact(), shortInfoModel, capitalInfoAreaModels, infoResourceModels);
        //以下进行图片的插入


        if (infoID > 0)
        {
            Tz888.BLL.MerchantManage.PageStatic merstatic = new Tz888.BLL.MerchantManage.PageStatic();
            #region 定价
            string price = "";


            #endregion

            if (chkIsPoint.Checked == true)
            {
                price = "2";
            }
            else
            {
                price = "1";
            }

            bool pric = mainBll.HasFixPrice(infoID, price, bp.LoginName);
            if (rdPass.Checked == true)
            {


                string url = "Capital/" + DateTime.Now.ToString("yyyyMM") + "/Capital" + DateTime.Now.ToString("yyyyMMdd") + "_" + infoID + ".shtml";

                merstatic.UpdateUrl(url, infoID);

            }
            long _infoID = Convert.ToInt64(infoID);
            string title = Convert.ToString("投资发布");
            Tz888.Model.Info.InfoContactModel infoContactModel = new Tz888.Model.Info.InfoContactModel(); //创建信息联系方式主体

            string email = this.txtEmail.Text.Trim();
            string telCountry = this.txtTelCountry.Text.Trim();
            string telZoneCode = this.txtTelZoneCode.Text.Trim();
            string telNumber = this.txtTelNumber.Text.Trim();
            //注释掉传真
            string faxCountry = "0";
            string faxZoneCode = "0";
            string faxNumber = "0";
            string webSite = this.txtWebSite.Text.Trim();
            string name = this.txtLinkMan.Text.Trim();
            string mobile = this.txtMobile.Text.Trim();
            string address = this.txtAddress.Text.Trim();
            //注释右邮编
            string postCode = "0";

            //以下是职位
            string position = ""; //this.txtPosition.Text.Trim();
            //投资机构名称
            string organizationName = this.txtGovName.Text.Trim();


            infoContactModel.OrganizationName = organizationName;
            infoContactModel.InfoID = _infoID;
            infoContactModel.Email = email;
            infoContactModel.WebSite = webSite;
            infoContactModel.TelCountryCode = telCountry;
            infoContactModel.TelStateCode = telZoneCode;
            infoContactModel.TelNum = telNumber;
            infoContactModel.FaxCountryCode = faxCountry;
            infoContactModel.FaxStateCode = faxZoneCode;
            infoContactModel.FaxNum = faxNumber;
            infoContactModel.Name = name;
            infoContactModel.Mobile = mobile;
            infoContactModel.Address = address;
            infoContactModel.PostCode = postCode;
            //以下是职位
            infoContactModel.Position = position;

            Tz888.BLL.Info.InfoContact obj = new Tz888.BLL.Info.InfoContact();

            //这里是更新联系信息
            if (obj.Update(infoContactModel))
            {
                Tz888.Model.Info.V124.CapitalSetModel model = new Tz888.Model.Info.V124.CapitalSetModel();
                page = page.objGetMerchantInfoByInfoID(_infoID);//根ID获取信息
                string IsVip = Mercahrstatic.SelCapitalInfoVip();//查询为重点推荐资源
                string Idstuny = page.SelectLndus(page.Are);//根据区域查询信息
                int sum = page.StaticHtml(Convert.ToInt32(_infoID), page.Title, page.PublishT, page.AreaName, page.Content, page.IndustryCarveOutID, page.CooperationTypeName, page.Money, page.ValidateID, page.MerchantNameTotal, Idstuny, page.Pic, IsVip, page.Title, page.Title, page.Title, page.Register);
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加信息成功！');location.href='CapitalManage.aspx'", true);

            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "更新联系方式失败！");
            }


        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }
    }



}

