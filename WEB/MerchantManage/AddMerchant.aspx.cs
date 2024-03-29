﻿using System;
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
public partial class MerchantManage_AddMerchant : System.Web.UI.Page
{
    Tz888.BLL.Static Mercahrstatic = new Tz888.BLL.Static();
    Tz888.BLL.MerchantManage.PageStatic page = new Tz888.BLL.MerchantManage.PageStatic(); //实例化创建文件类
    Tz888.BLL.MerchantManage.PageStatic merstatic = new Tz888.BLL.MerchantManage.PageStatic();
    Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();
    BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {




        //   this.ShowNavigateTitle();
        if (!Page.IsPostBack)
        {
            this.BindCurrency();
            //项目有效期限
            this.BindSetvaliDate();
            InitInfoContact();

        }

        this.FilesUploadControl1.InfoType = "Merchant";
        this.FilesUploadControl1.NoneCount = 5;
        this.FilesUploadControl1.Count = 5;
        //添加有限期限的onclick
        for (int i = 0; i < this.rdlValiditeTerm.Items.Count; i++)
        {
            //this.rdlValiditeTerm.Items[i].Attributes.Add("onclick", "checkValiditeTerm();");
        }
    }



    /// <summary>
    /// 项目有效期限
    /// </summary>
    private void BindSetvaliDate()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();

    }

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



    /// <summary>
    /// 加载用户联系信息
    /// </summary>
    public void InitInfoContact()
    {
        //string Lname = bp.LoginName;
        //this.ViewState["LoginMemberName"] = Lname;
        //DataTable dt1 = obj1.GetLoginInfoList("*", "LoginName='" + Lname + "'", "LoginName");
        ////会员信息表
        //Tz888.Model.Register.MemberInfoModel model3 = new Tz888.Model.Register.MemberInfoModel();
        //Tz888.BLL.Register.MemberInfoBLL obj3 = new Tz888.BLL.Register.MemberInfoBLL();
        //model3 = obj3.GetModel("LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'");
        //this.ZoneSelectControl1.CountryID = model3.CountryCode.ToString().Trim();//国别
        //ZoneSelectControl1.CityID = model3.CityID.ToString().Trim();//市
        //ZoneSelectControl1.ProvinceID = model3.ProvinceID.ToString().Trim();//省
        //ZoneSelectControl1.CountyID = model3.CountyID.ToString().Trim(); //县
        //Tz888.Model.Register.OrgContactModel org = new Tz888.Model.Register.OrgContactModel();
        //Tz888.BLL.Info.MarchantInfoBLL mar = new Tz888.BLL.Info.MarchantInfoBLL();
        //org = mar.SelLoginName(Lname);
        //// org = mar.SelLoginName("dishi");
        //this.txtCompanyName.Text = org.OrganizationName;
        //this.txtName.Text = org.Name;
        //this.txtMobile.Text = org.Mobile;
        //this.txtEmail.Text = org.Email;
        //this.txtAddress.Text = org.address;
        //if (dt1.Rows.Count > 0)
        //{
        //    if (dt1.Rows[0]["Tel"] != DBNull.Value && dt1.Rows[0]["Tel"].ToString() != "")
        //    {
        //        try
        //        {
        //            string[] tel = dt1.Rows[0]["Tel"].ToString().Split('-');
        //            txtTelCountry.Text = tel[0].ToString();
        //            txtTelZoneCode.Text = tel[1].ToString();
        //            txtTelNumber.Text = tel[2].ToString();

        //        }
        //        catch
        //        {
        //            txtTelCountry.Text = "+86";
        //            txtTelZoneCode.Text = "";
        //            //因以前数据格式不同原因，没有用‘-’分格
        //            txtTelNumber.Text = dt1.Rows[0]["Tel"].ToString();
        //        }
        //    }
        //}
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //结束部分
        //实体部分
        // this.imgLoding.Visible = true;
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.MerchantInfoModel merchantInfoModel = new Tz888.Model.Info.MerchantInfoModel(); //创建招商信息实体
        Tz888.Model.Info.InfoContactModel infoContactModel = new Tz888.Model.Info.InfoContactModel(); //创建信息联系方式主体
        Tz888.Model.Info.ShortInfoModel shortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        List<Tz888.Model.Info.InfoContactManModel> infoContactManModels = new List<Tz888.Model.Info.InfoContactManModel>(); //联系人实体列表
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>();//招商信息资源信息实体

        DateTime time_now = DateTime.Now;

        industryModels = this.SelectIndustryControl1.IndustryModels;
        //这里是多个联系方式的添加


        #region 招商信息实体赋值
        merchantInfoModel.MerchantTypeID = "";// rblMerchantType.SelectedValue;
        merchantInfoModel.CountryCode = ZoneSelectControl1.CountryID;
        merchantInfoModel.ProvinceID = ZoneSelectControl1.ProvinceID;
        merchantInfoModel.CityID = ZoneSelectControl1.CityID;
        merchantInfoModel.CountyID = ZoneSelectControl1.CountyID;

        //联系方式赋值
        infoContactModel.OrganizationName = this.txtCompanyName.Text;
        infoContactModel.Name = this.txtName.Text;
        infoContactModel.Position = "";// this.txtPosition.Text;
        infoContactModel.TelCountryCode = this.txtTelCountry.Text;
        infoContactModel.TelStateCode = this.txtTelZoneCode.Text;
        infoContactModel.TelNum = this.txtTelNumber.Text;
        infoContactModel.Mobile = this.txtMobile.Text;
        infoContactModel.Email = this.txtEmail.Text;
        infoContactModel.Address = this.txtAddress.Text;

        merchantInfoModel.CooperationDemandType = "";
        merchantInfoModel.CapitalCurrency = this.ddlCapitalCurrency.SelectedValue;

        if (!string.IsNullOrEmpty(this.txtCapitalTotal.Text.Trim()))
            merchantInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());

        merchantInfoModel.MerchantCurrency = "";// this.ddlMerchantCurrency.SelectedValue;
        merchantInfoModel.MerchantTotal = "";// this.ddlMerchantTotal.SelectedValue;

        if (!string.IsNullOrEmpty(this.txtZoneAbout.Value.Trim()))
            merchantInfoModel.ZoneAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtZoneAbout.Value.Trim());

        //这里是2010-06-01新加的招商信息
        //if (!string.IsNullOrEmpty(this.txtZoneAboutBrief.Value.Trim()))
        merchantInfoModel.ZoneAboutBrief = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        // if (!string.IsNullOrEmpty(this.txtBenefit.Value.Trim()))
        merchantInfoModel.Benefit = Tz888.Common.Utility.PageValidate.TxtToHtml("");

        // if (!string.IsNullOrEmpty(this.txtEconomicIndicators.Value.Trim()))
        merchantInfoModel.EconomicIndicators = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //if (!string.IsNullOrEmpty(this.txtInvestmentEnvironment.Value.Trim()))
        merchantInfoModel.InvestmentEnvironment = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //if (!string.IsNullOrEmpty(this.txtProjectStatus.Value.Trim()))
        merchantInfoModel.ProjectStatus = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //  if (!string.IsNullOrEmpty(this.txtMarket.Value.Trim()))

        merchantInfoModel.Market = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        //merchantInfoModel.Merchanreturns = Convert.ToInt32(this.txtHuiBao.Text.Trim());//回报率
        if (txtHuiBao.Text.ToString().Trim() == "")
        {
            merchantInfoModel.Merchanreturns = 0;
        }
        else
        {
            merchantInfoModel.Merchanreturns = Convert.ToInt32(this.txtHuiBao.Text.Trim());
        }
        //结束处
        foreach (Tz888.Model.Common.IndustryModel model in industryModels)
        {
            merchantInfoModel.IndustryClassList += model.IndustryBID + ",";
        }

        //2010-06-08以下是对信息完整度的统计
        merchantInfoModel.InformationIntegrity = Tz888.BLL.Info.MarchantInfoBLL.CountInfoInte(merchantInfoModel, infoContactModel);

        #endregion

        if (!string.IsNullOrEmpty(this.txtMerchantTopic.Text.Trim()))
            mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtMerchantTopic.Text.Trim());

        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Merchant", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, DateTime.Now);
        mainInfoModel.publishT = time_now;
        mainInfoModel.Hit = Convert.ToInt32(tbHits.Text.Trim());

        mainInfoModel.IsCore = true;
        //注意这里是添加主信息表与用户登陆表的通过用户名相联系
        //mainInfoModel.LoginName = "111111";
        mainInfoModel.LoginName = bp.LoginName;
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";
        if (chkIsPoint.Checked == true)
        {

            mainInfoModel.FixPriceID = "2";
            mainInfoModel.MainPointCount = Convert.ToInt32(txtPointCount.Text.Trim());
        }
        else
        {
            mainInfoModel.MainPointCount = 0;
            mainInfoModel.FixPriceID = "1";
        }
        mainInfoModel.FeeStatus = 0;
        mainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtMerchantTopic.Text.Trim());
        mainInfoModel.Descript = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtMerchantTopic.Text.Trim());
        if (!string.IsNullOrEmpty(this.txtMerchantTopic.Text.Trim()))
        mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtMerchantTopic.Text.Trim());
        mainInfoModel.FrontDisplayTime = time_now;
        mainInfoModel.ValidateStartTime = time_now;
        mainInfoModel.ValidateTerm = Convert.ToInt32(this.rdlValiditeTerm.SelectedValue.Trim());
        mainInfoModel.TemplateID = "001";
        byte AuditingStatus = 0;

        if (rdAudit.Checked == true)
        {
            AuditingStatus = 0;

        }
        if (rdPass.Checked == true)
        {
            AuditingStatus = 1;

        }
        if (rdNopass.Checked == true)
        {

            AuditingStatus = 2;

        }
        mainInfoModel.AuditingStatus = AuditingStatus;
        mainInfoModel.HtmlFile = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        shortInfoModel.ShortInfoControlID = "MerchantIndex1";
        if (!string.IsNullOrEmpty(this.txtMerchantTopic.Text.Trim()))
            shortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtMerchantTopic.Text.Trim());
        shortInfoModel.ShortContent = "";
        shortInfoModel.Remark = "";

        //将已上传的图片从临时目录迁移到正式目录
        //infoResourceModels = Tz888.Common.InfoResourceManage.ImageTransfer("Image", "Merchant", Tz888.Common.ResourceType.Image, Tz888.Common.ResourceProperty.InfoImage, FilesUploadControl1.InfoList);
        infoResourceModels = FilesUploadControl1.InfoList;

        Tz888.BLL.Info.MarchantInfoBLL marchantObj = new Tz888.BLL.Info.MarchantInfoBLL();
        //插入数据
        long infoID = marchantObj.Insert(mainInfoModel, merchantInfoModel, infoContactModel, shortInfoModel, infoResourceModels);
        if (infoID > 0)
        {

            if (rdPass.Checked == true)
            {
                Tz888.Model.Info.MerchantSetModel model = new Tz888.Model.Info.MerchantSetModel();

                string url = "Merchant/" + DateTime.Now.ToString("yyyyMM") + "/Merchant" + DateTime.Now.ToString("yyyyMMdd") + "_" + infoID + ".shtml";
                merstatic.UpdateUrl(url, infoID);

                page = page.objGetMerchantInfoByInfoID(infoID);//根ID获取信息
                string IsVip = Mercahrstatic.SelIsVip();//查询为重大商机的信息
                string Idstuny = page.SelectLndus(ZoneSelectControl1.ProvinceID);//根据区域查询信息
                int sum = page.StaticHtml(Convert.ToInt32(infoID), page.Title, page.PublishT, page.AreaName, page.Content, page.IndustryCarveOutID, page.MerchantNameTotal, page.ValidateID, Idstuny, IsVip, page.Title, page.Title, page.Title, page.Merchanreturns);

            }
            //招商重大投资商机设置
            Tz888.BLL.MerchantOppor objOppor = new Tz888.BLL.MerchantOppor();
            if (chkIsVip.Checked)
            {
                objOppor.IsVip(infoID, 1, txtIsVipAbout.Text.Trim());
            }
            else
            {
                objOppor.IsVip(infoID, 0, "");
            }
            Response.Redirect("MerchantManage.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
   
        }
    }
}
