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
public partial class Project_AddProject_GQ : System.Web.UI.Page
{
    protected long _infoID;
    protected string cooperationDemandType;
    Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();
    Tz888.BLL.MerchantManage.PageStatic merstatic = new Tz888.BLL.MerchantManage.PageStatic();

    Tz888.BLL.PageBLL page = new Tz888.BLL.PageBLL();
    Tz888.BLL.Visit.VisitInfoBLL visit = new Tz888.BLL.Visit.VisitInfoBLL();
    Tz888.BLL.ProjectState state = new Tz888.BLL.ProjectState();
    BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            this.ViewState["LoginMemberName"] = bp.LoginName;
            //会员信息表

            InitInfoContact();
            BindSetCapital();// 绑定融资金额

            Xmyxqxx();//项目有效期限

        }



        //以下是取得上传文件信息
        this.FilesUploadControl1.InfoType = "Project";
        this.FilesUploadControl1.NoneCount = 5;
        this.FilesUploadControl1.Count = 5;
    }

    //初始化联络人信息
    private void InitInfoContact()
    {

    }

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




    protected void btnIssueOK_Click(object sender, EventArgs e)
    {
        //判断电话与手机号
        if (txtTel.Value.Trim() == "" && txtMobile.Value.Trim() == "")
        {
            //Tz888.Common.MessageBox.Show(this.Page, "固定电话或手机至少填写一项，请检查！");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('固定电话或手机至少填写一项，请检查！');", false);
            return;
        }
        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>(); //上传文件
        Tz888.BLL.Info.InfoContact dal = new Tz888.BLL.Info.InfoContact();
        Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();
        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        DateTime time_Now = DateTime.Now;

        industryModels = this.SelectIndustryControl1.IndustryModels;

        projectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID; //*国家代码
        projectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID; //*省
        projectInfoModel.CityID = this.ZoneSelectControl1.CityID; //*州或城市
        projectInfoModel.CountyID = this.ZoneSelectControl1.CountyID; //*县

        //*项目名称
        projectInfoModel.ProjectName = this.txtProjectName.Value.Trim();

        projectInfoModel.RecTime = DateTime.Now;
        projectInfoModel.CapitalCurrency = "CNY"; //*资本金币种
        projectInfoModel.ProjectCurrency = "CNY"; //*资本金币种

        //*项目投资总额
        if (!string.IsNullOrEmpty(txtCapitalTotal.Text.Trim()))
            projectInfoModel.CapitalTotal = Convert.ToDecimal(txtCapitalTotal.Text.Trim());

        //*融资金额
        projectInfoModel.CapitalID = this.rbtnCapital.SelectedValue.Trim();

        //项目说明        
        projectInfoModel.ComBrief = Tz888.Common.Utility.PageValidate.TxtToHtml(txtProIntro.Value.Trim());

        //行业
        foreach (Tz888.Model.Common.IndustryModel models in industryModels)
        {
            projectInfoModel.IndustryBID += models.IndustryBID + ",";
        }

        //股权融资
        projectInfoModel.CooperationDemandType = "10";

        //*融资对像

        projectInfoModel.financingID = "";

        //*融资额占股份比重
        projectInfoModel.SellStockShare = 1;


        //##20100603新加入字段
        //*项目立项情况 checkboxlist
        projectInfoModel.sXmlxqk = "";

        projectInfoModel.sXmgjz = "融资";
        //*退出方式
        projectInfoModel.ReturnModeID = "";
        //*企业发展阶段
        projectInfoModel.sQyfzjd = "";
        //*要求资金到位情况
        projectInfoModel.iYqzjdwqk = 1;
        //*市场占有率(份额)
        projectInfoModel.iSczylfy = 1;
        //*行业市场增长率
        projectInfoModel.iHysczzl = 1;
        //*资产负债率
        projectInfoModel.iZcfzl = 1;
        //*项目投资回报周期
        projectInfoModel.iXmtzfbzq = 1;
        //*项目详细描术
        projectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtXmqxms.Value.Trim());


        //##项目详细资料
        //*单位年营业收入
        projectInfoModel.nDwlyysy = 1;
        //*单位年净利润
        projectInfoModel.nDwljly = 1;
        //*单位总资产
        projectInfoModel.nDwzzc = 1;
        //*单位总负债
        projectInfoModel.nDwzfz = 1;

        //产品概述
        projectInfoModel.ProjectAbout = "";
        //市场前景
        projectInfoModel.marketAbout = "";
        //竞争分析
        projectInfoModel.competitioAbout = "";
        //商业模式
        projectInfoModel.BussinessModeAbout = "";
        //管理团队
        projectInfoModel.ManageTeamAbout = txtManageTeamAbout.Value.Trim();


        //-----------------------------------主表信息-------------
        //项目标题
        if (!string.IsNullOrEmpty(this.txtProjectName.Value))
            mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value);

        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Project", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.publishT = time_Now;
        mainInfoModel.Hit = 0;

        mainInfoModel.IsCore = true;
        mainInfoModel.LoginName = bp.LoginName;
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";
        mainInfoModel.FixPriceID = this.rblFixPrice.SelectedValue.ToString().Trim();
        mainInfoModel.MainPointCount = Convert.ToDecimal(txtPointCount.Text.ToString().Trim());
        mainInfoModel.AuditingStatus = Convert.ToByte(this.rblAuditing.SelectedValue.ToString());
        mainInfoModel.FeeStatus = 0;
        mainInfoModel.Descript = this.txtProjectName.Value.ToString().Trim();

        //项目标题
        if (!string.IsNullOrEmpty(this.txtProjectName.Value.Trim()))
            mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        mainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());

        mainInfoModel.FrontDisplayTime = time_Now;
        mainInfoModel.ValidateStartTime = time_Now;
        mainInfoModel.ValidateTerm = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim()); //*项目有效期限
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";
        //上传文件
        infoResourceModels = FilesUploadControl1.InfoList;


        model.OrganizationName = txtCompanyName.Value.Trim();
        model.Name = txtLinkMan.Value.Trim();
        model.Career = txtCareer.Value.Trim();
        model.TelCountryCode = telArea1.Value.Trim(); //新加的国际号
        model.TelStateCode = txtTelStateCode.Value.Trim(); //区号

        if (telFg.Value.Trim() != "") //如果分机号不为空
            model.TelNum = txtTel.Value.Trim() + "-" + telFg.Value.Trim();
        else
            model.TelNum = txtTel.Value.Trim(); //电话号加分机号

        model.Mobile = txtMobile.Value.Trim();
        model.Address = txtAddress.Value.Trim();
        model.WebSite = txtWebSite.Value.Trim();
        model.Email = txtEmail.Value.Trim();

        long num = projectObj.InsertNew(mainInfoModel, projectInfoModel, model, infoResourceModels);
        {
            if (num > 0)
            {
                string auditing = this.rblAuditing.SelectedValue.ToString();
                if (auditing == "1")
                {
                    string url = "Project/" + DateTime.Now.ToString("yyyyMM") + "/Project" + DateTime.Now.ToString("yyyyMMdd") + "_" + num + ".shtml";
                    merstatic.UpdateUrl(url, num);
                    #region 生成静态页面
                    state = page.SelProjectM(Convert.ToString(num));
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
                    #endregion
                }
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('发布成功！');location.href='ProjectManage.aspx'", true);

            }
            else
            {

                Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
            }
        }

    }

}
