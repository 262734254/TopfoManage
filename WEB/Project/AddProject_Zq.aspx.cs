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
public partial class Project_AddProject_Zq : System.Web.UI.Page
{
    protected long _infoID;
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
            InitInfoContact();
            Xmyxqxx();// 项目有效期限
        }
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
    //初始化联络人信息
    private void InitInfoContact()
    {
      
    }



    protected void btnIssueOK_Click(object sender, EventArgs e)
    {






        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体

        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>(); //上传文件

        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        DateTime time_Now = DateTime.Now;

        industryModels = this.SelectIndustryControl1.IndustryModels;

        projectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        projectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        projectInfoModel.CityID = this.ZoneSelectControl1.CityID;
        projectInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        projectInfoModel.ProjectName = this.txtProjectName.Value.Trim();
        projectInfoModel.RecTime = DateTime.Now;
        projectInfoModel.CapitalCurrency = "CNY";
        projectInfoModel.ProjectCurrency = "CNY";


        //投资总额
        //if (!string.IsNullOrEmpty(txtCapitalTotal.Value.Trim()))
        //    projectInfoModel.CapitalTotal = 20;


        projectInfoModel.CapitalTotal = Convert.ToDecimal(txtCapitalTotal.Value.Trim());
        //借钱金额
        projectInfoModel.CapitalID = "0";
        //项目详细描述
        projectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtZoneAbout.Value.Trim());
        //行业
        foreach (Tz888.Model.Common.IndustryModel model in industryModels)
        {
            projectInfoModel.IndustryBID += model.IndustryBID + ",";
        }
        projectInfoModel.CooperationDemandType = "9";//债券融资

        //融资对象
        projectInfoModel.financingID = "01,";
        //融资计划及还款能力
        projectInfoModel.warrant = "";

        //-----------------201006资源超市第二次改版，----------------------//
        //项目立项情况
        projectInfoModel.cZqXmlxqkb = "1,";
        //企业发展阶段
        projectInfoModel.cZqQyfzjd = "1";
        //要求资金到位情况
        projectInfoModel.iZqYqjjdwqk = Tz888.Common.Text.FormatData(rblYqzjdwqk.SelectedValue.Trim());
        //产品市场增长率
        projectInfoModel.iZqCpsczzl = 1;
        //产品市场容量
        projectInfoModel.iZqCpscYl = 1;
        //资产负债率
        projectInfoModel.iZqZcfzl = 1;
        //流动比率
        projectInfoModel.iZqYdbl = 1;
        //投资收益率
        projectInfoModel.iZqTzsl = 1;
        //销售利润率
        projectInfoModel.iZqXslyl = 1;
        //投资回报期
        projectInfoModel.iZqTzfbq = 1;
        //项目有效期限
        projectInfoModel.iZqXmyxqs = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim());
        //项目摘要
        projectInfoModel.ComBrief = "";
        //项目关键字 textbox
        string strXmgjz = "";
        projectInfoModel.cZqXmgjz = strXmgjz;


        //##项目详细资料
        //*借款单位年营业收入
        projectInfoModel.nDwlyysy = 1;
        //*借款单位年净利润
        projectInfoModel.nDwljly = 1;
        //*借款单位总资产
        projectInfoModel.nDwzzc = 1;
        //*借款单位总负债
        projectInfoModel.nDwzfz = 1;


        //产品概述
        projectInfoModel.cZqCpks = "";
        //市场前景
        projectInfoModel.marketAbout = "";
        //竞争分析
        projectInfoModel.cZqJzfx = "";
        //商业模式
        projectInfoModel.cZqSyms = "";
        //管理团队
        projectInfoModel.cZqGltd = "";

        //信息完整度
        projectInfoModel.InformationIntegrity = GetInformationIntegrity();
        //-----------------END--------------------------------------------




        //-----------------------------------主表信息-------------
        if (!string.IsNullOrEmpty(this.txtProjectName.Value))
            mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value);

        string str = industryModels[0].IndustryBID;
        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Project", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.publishT = time_Now;
        mainInfoModel.Hit = 0;

        mainInfoModel.IsCore = true;
        //  mainInfoModel.LoginName = "topfo001";
        mainInfoModel.LoginName = bp.LoginName;
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";
        mainInfoModel.FixPriceID = this.rblFixPrice.SelectedValue.ToString().Trim();
        mainInfoModel.FeeStatus = 0;
        mainInfoModel.ValidateTerm = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim()); //*项目有效期限

        mainInfoModel.MainPointCount = Convert.ToDecimal(txtPointCount.Text.ToString().Trim());
        mainInfoModel.AuditingStatus = Convert.ToByte(this.rblAuditing.SelectedValue.ToString());



        if (!string.IsNullOrEmpty(this.txtProjectName.Value.Trim()))
            mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        mainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        mainInfoModel.Descript = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        mainInfoModel.FrontDisplayTime = time_Now;
        mainInfoModel.ValidateStartTime = time_Now;
        mainInfoModel.ValidateTerm = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim()); //*项目有效期限
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";

        //------------------------
        sortInfoModel.ShortInfoControlID = "ProjectIndex1";
        sortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        sortInfoModel.ShortContent = "";
        sortInfoModel.Remark = "";

        string theURL = Request.CurrentExecutionFilePath;


        //包括上传文件
        long infoID = projectObj.PublishProjectZQ1(mainInfoModel, projectInfoModel, sortInfoModel, infoResourceModels);
        _infoID = infoID;


        if (infoID > 0)
        {

            ConfirmContact();
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }

    }

    //第二步，确认联络方式
    private void ConfirmContact()
    {
        Tz888.BLL.Info.InfoContact dal = new Tz888.BLL.Info.InfoContact();
        Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();

        model.InfoID = _infoID;
        model.OrganizationName = txtCompanyName.Value.Trim();
        model.Name = txtLinkMan.Value.Trim();
        model.Career = "";// txtCareer.Value.Trim();
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
        bool b = dal.Add(model);
        if (b)
        {

            string auditing = this.rblAuditing.SelectedValue.ToString();
            if (auditing == "1")
            {
                string PointCount = txtPointCount.Text.ToString().Trim();
                string url = "Project/" + DateTime.Now.ToString("yyyyMM") + "/Project" + DateTime.Now.ToString("yyyyMMdd") + "_" + _infoID + ".shtml";
                merstatic.UpdateUrlPrice(url, _infoID, PointCount);
                #region 生成静态页面
                state = page.SelProjectM(Convert.ToString(_infoID));
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
            Tz888.Common.MessageBox.Show(this.Page, "联系信息添加失败，请检查！");
        }
    }


    /// <summary>
    /// //获取信息完整度
    /// </summary>
    /// <returns></returns>
    private int GetInformationIntegrity()
    {
        int iScore = 80;//把必填字段填完，可得80分 ////如果上传文件2，3，4，5都不为空，则各新加2分

        //if (!Tz888.Common.Text.IsNullRadioButtonList(rblXmtzfbzq)) //项目投资回报期
        //    iScore += 2;
        //if (tbLdbl.Value.Trim() != "") //流动比率
        //    iScore += 2;
        //if (tbXmgjz1.Value.Trim() != "" || tbXmgjz2.Value.Trim() != "" || tbXmgjz3.Value.Trim() != "") //关键字
        //    iScore += 1;
        //if (tbJkdwlyysy.Value.Trim() != "") //借款单位年营业收入
        //    iScore += 3;
        //if (tbJkdwljly.Value.Trim() != "") //借款单位年净利润
        //    iScore += 3;
        //if (tbJkdwzzc.Value.Trim() != "") //借款单位总资产
        //    iScore += 3;
        //if (tbJkdwzfz.Value.Trim() != "") //借款单位总负债
        //    iScore += 3;    
        //if (txtCareer.Value.Trim() != "") //职位
        //    iScore += 1;
        //if (txtAddress.Value.Trim() != "")//单位地址
        //    iScore += 1;
        //if (txtWebSite.Value.Trim() != "") //单位网址
        //    iScore += 1;

        //if (iScore > 100)
        iScore = 100;

        return iScore;
    }

}
