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

public partial class CarveNews_UpdateCarveOut : System.Web.UI.Page
{
    private static Tz888.BLL.CarveOut.PageStatic page = new Tz888.BLL.CarveOut.PageStatic(); //实例化创建文件类
    CarveOut.CarveOutService service = new CarveOut.CarveOutService(); //调用WebService
    CarveOut.StaticService compage = new CarveOut.StaticService();////调用WebService
    
    protected void Page_Load(object sender, EventArgs e)
    {

      
            //ViewState["LoginName"] = "";
            if (!IsPostBack)
            {
                this.rdbtXM.SelectedValue = "3";
                ViewState["strSavePath"] = "";
                BindXinYe();//行页绑定
                SetValid();//有效期
                BindCurrency();//货币种类
                BindSetCapital();//金额绑定
                SetGradeTabList();//评分信息绑定
                CarveDataBind();//加载详细信息数据绑定
            }
   
        
    }
    #region 数据绑定
    private void CarveDataBind()
    {

        try
        {
            Tz888.SQLServerDAL.Info.MainInfoDAL objtp = new Tz888.SQLServerDAL.Info.MainInfoDAL();
            string infoid = Request["infoID"].ToString();   //获取ID
            //string infoid = Request.QueryString["infoID"].ToString();
            DataSet ds = objtp.GetOneList(infoid);//根据ID查询方法
            this.txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();//标题
            this.txtKeyWord.Text = ds.Tables[0].Rows[0]["KeyWord"].ToString();//关键字
            this.txtDescript.Text = ds.Tables[0].Rows[0]["Descript"].ToString();//网页描述
            this.txtDisplayTitle.Text = ds.Tables[0].Rows[0]["DisplayTitle"].ToString();//网页标题
            this.txtShortTitle.Text = ds.Tables[0].Rows[0]["ShortTitle"].ToString();//短标题
            this.txtShortContent.Text = ds.Tables[0].Rows[0]["ShortContent"].ToString();//短内容
            this.txtAdTitle.Text = ds.Tables[0].Rows[0]["AdTitle"].ToString();//广告语
            ZoneSelectControl2.CountryID = ds.Tables[0].Rows[0]["CountryCode"].ToString().Trim();//国
            ZoneSelectControl2.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString().Trim();//省
            ZoneSelectControl2.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString().Trim();//市
            ZoneSelectControl2.CityID = ds.Tables[0].Rows[0]["CityID"].ToString().Trim();//县
            //ddlIndustry.SelectedValue = ds.Tables[0].Rows[0]["IndustryCarveOutID"].ToString().Trim();//行页
            string dusty = ds.Tables[0].Rows[0]["IndustryCarveOutID"].ToString().Trim();
            ddlIndustry.SelectedIndex = Convert.ToInt32(dusty.ToString()) - 1;
            ddlMerchantTotal.SelectedValue = ds.Tables[0].Rows[0]["CapitalID"].ToString();  //所需资金
            int cc = Convert.ToInt32(ds.Tables[0].Rows[0]["InvestObject"].ToString());   //合作对象
            rblInvestObject.SelectedIndex = cc;
            txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString(); //备注
            txtContent.Text = ds.Tables[0].Rows[0]["Content"].ToString();  //内容
            txtInvestReturn.Text = ds.Tables[0].Rows[0]["InvestReturn"].ToString(); //回报形式
            ddlTemplate.Text = ds.Tables[0].Rows[0]["TemplateID"].ToString();  //模版号
            txtComName.Text = ds.Tables[0].Rows[0]["ComName"].ToString();  //公司名称
            txtLinkMan.Text = ds.Tables[0].Rows[0]["LinkMan"].ToString();  //联系人
            string country = ds.Tables[0].Rows[0]["Tel"].ToString();   //电话
            //string a = country.Replace("+","");
            string[] b = country.Split('－');
            country.Length.ToString();
            country.Substring(1, 4);
            //  txtTelCountry.Text = country.ToString().Trim();
            txtTelZoneCode.Text = b[1];
            txtTelCountry.Text = b[0];
            txtTelNumber.Text = b[2];
            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();  //手机号码
            txtWebSite.Text = ds.Tables[0].Rows[0]["WebSite"].ToString(); //网站
            txtPostCode.Text = ds.Tables[0].Rows[0]["PostCode"].ToString(); //邮编
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            int XM = Convert.ToInt32(ds.Tables[0].Rows[0]["ValidateID"].ToString()); //有效期
            this.rdbtXM.SelectedValue = XM.ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();  //邮箱
            rblAuditing.SelectedValue = ds.Tables[0].Rows[0]["AuditingStatus"].ToString().Trim();//审核状态
            ddlSetGrade.SelectedValue = ds.Tables[0].Rows[0]["GradeID"].ToString();//评分
            txtHit.Text = ds.Tables[0].Rows[0]["Hit"].ToString();//人气
            txtLoginName.Text = ds.Tables[0].Rows[0]["LoginName"].ToString();//登录名
            rdoType.SelectedValue = ds.Tables[0].Rows[0]["CarveOutInfoType"].ToString().Trim();//1代表资金找项目，0代表项目找资金
            ViewState["pic1"] = ds.Tables[0].Rows[0]["pic1"].ToString().Trim();
            if (ViewState["pic1"] == null || ViewState["pic1"].ToString() == "")
            {
                this.LbLook.Visible = false;
                this.lblMessage.Text = "用户没有上传图片";
            }
            

        }
        catch (Exception ex)
        {

            Response.Write("<script>alert('请重新选择要修改的数据!');window.close();</script>");
        }

    } 
    #endregion
    protected void IbtnSubmit_Click(object sender, EventArgs e)
    {
        string infoid = Request["infoID"].ToString();   //获取ID
        //List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        string Indus = this.ddlIndustry.SelectedValue.ToString().Trim();
        Tz888.Model.Info.MainInfoModel main = new Tz888.Model.Info.MainInfoModel();//主表
        Tz888.Model.Carveout.CarveOutInfoTabModel CarveModel = new Tz888.Model.Carveout.CarveOutInfoTabModel();//创业信息表
        Tz888.Model.Info.ShortInfoModel shortInfoRule = new Tz888.Model.Info.ShortInfoModel();//短消息表
        #region 主表
        main.InfoID = Convert.ToInt32(infoid);
        main.Title = txtTitle.Text.Trim();
        main.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Carve", Indus, this.ZoneSelectControl2.CountryID, DateTime.Now);
        //main.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Carve", industryModels[0].IndustryBID, this.ZoneSelectControl2.CountryID, DateTime.Now);
        main.publishT = Convert.ToDateTime(DateTime.Now);
        main.Hit = Convert.ToInt32(txtHit.Text.ToString().Trim());
        main.LoginName = txtLoginName.Text.ToString().Trim();
        //main.LoginName = Page.User.Identity.Name;
        main.InfoOriginRoleName = "0";

        main.KeyWord = txtKeyWord.Text.Trim();
        main.Descript = txtDescript.Text.Trim();
        main.DisplayTitle = txtDisplayTitle.Text.Trim();
        main.FrontDisplayTime = Convert.ToDateTime(DateTime.Now);
        main.ValidateStartTime = Convert.ToDateTime(DateTime.Now);
        main.ValidateTerm = Convert.ToInt32(this.rdbtXM.SelectedValue.Trim());
        int GradeID = Int32.Parse(ddlSetGrade.SelectedValue.ToString().Trim());
        main.GradeID = GradeID.ToString().Trim();
          
        main.TemplateID = "001";
        
        int Auditting = 0;
        Auditting = Convert.ToByte(this.rblAuditing.SelectedValue.Trim());//审核状态
        main.AuditingStatus = Auditting;

        if (Auditting == 1)
        {
            main.HtmlFile = "CarveOut/" + DateTime.Now.ToString("yyyyMM") + "/CarveOut" + DateTime.Now.ToString("yyyyMMdd") + "_" + infoid + ".shtml";
        }
        else
        {
            main.HtmlFile = "";
        }
        #endregion


        #region 创业信息表
        CarveModel.AdTitle = txtAdTitle.Text.Trim();
        CarveModel.CarveOutInfoType = Convert.ToString(this.rdoType.SelectedValue.Trim()); //1代表是资金找项目
        CarveModel.CountryCode = ZoneSelectControl2.CountryID.ToString().Trim();
        CarveModel.ProvinceID = ZoneSelectControl2.ProvinceID.ToString().Trim();
        CarveModel.CountyID = ZoneSelectControl2.CountyID.ToString().Trim();
        CarveModel.CityID = ZoneSelectControl2.CityID.ToString().Trim();
        CarveModel.CapitalID = ddlMerchantTotal.SelectedValue.ToString().Trim();//投资金额
        CarveModel.IndustryCarveOutID = ddlIndustry.SelectedValue.ToString().Trim();//行页

        CarveModel.ValidateID = this.rdbtXM.SelectedValue.Trim(); //有效期
        //CarveModel.ValidateID = this.rdbtXM.SelectedValue.Trim(); //有效期
        CarveModel.InvestObject = rblInvestObject.SelectedIndex.ToString().Trim();//合作对象
        CarveModel.Pic1 = Convert.ToString(ViewState["strSavePath"]);// FilesUploadControl2.UploadImageURL;

        // pOpportunity.Pic1 = "";                   //图片
        CarveModel.Content = txtContent.Text;          //创业内容
        CarveModel.InvestReturn = txtInvestReturn.Text.Trim();
        CarveModel.Remark = txtRemark.Text;           //备注

        CarveModel.ComName = txtComName.Text.Trim();   //公司名称
        CarveModel.LinkMan = txtLinkMan.Text.Trim();   //联系人
        CarveModel.Tel = txtTelCountry.Text.Trim() + "－" + txtTelZoneCode.Text.Trim() + "－" + txtTelNumber.Text.Trim();  //电话
        CarveModel.Fax = "";
        CarveModel.Mobile = txtMobile.Text.Trim();  //手机    
        CarveModel.Address = txtAddress.Text.Trim();//地址
        CarveModel.PostCode = txtPostCode.Text.Trim();//邮编
        CarveModel.Email = txtEmail.Text.Trim();//邮箱
        CarveModel.WebSite = txtWebSite.Text.Trim();//网站
        #endregion

        #region  短内容信息表

        shortInfoRule.ShortInfoControlID = "CarveOutIndex1";
        shortInfoRule.ShortTitle = txtShortTitle.Text.Trim();
        shortInfoRule.ShortContent = txtShortContent.Text.Trim();
        shortInfoRule.Remark = "";
        #endregion
        //插入数据
        Tz888.BLL.CarveOut.CarveOutInfoManager bll = new Tz888.BLL.CarveOut.CarveOutInfoManager();
        long InfoID = bll.Update(main, CarveModel, shortInfoRule);

        if (InfoID >= 0)
        {
            int num = service.ModifyHtmlFile(Convert.ToInt32(InfoID));
            if (num >= 0)
            {
              page= page.NewsIdAll(Convert.ToInt32(InfoID));
                service.CreateHtml(Convert.ToInt32(InfoID), page.Title, page.PublishT.ToString(), page.Content, page.Hit, page.Address, page.CapitalID, page.ComName, page.Email, page.IndustryCarveOutID, page.InvestObject, page.InvestReturn, page.LinkMan, page.PostCode, page.ProvinceID, page.Tel, page.ValidateID, page.WebSite, page.KeyWord, page.CarveOutInfoType, "tz888Admin", "mtvc2909");
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
    protected void btnUpload2_Click(object sender, EventArgs e)
    {

    }
    #region 绑定金额
    /// <summary>
    /// 绑定金额
    /// </summary>
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        this.ddlMerchantTotal.DataSource = bll.GetList();
        this.ddlMerchantTotal.DataTextField = "CapitalName";
        this.ddlMerchantTotal.DataValueField = "CapitalID";
        this.ddlMerchantTotal.DataBind();
    } 
    #endregion
    #region 价值评分查询
    /// <summary>
    /// 价值评分查询
    /// </summary>
    private void SetGradeTabList()
    {
        Tz888.BLL.Common.IndustryBLL bllIn = new Tz888.BLL.Common.IndustryBLL();
        this.ddlSetGrade.DataSource = bllIn.SetGradeTab();
        this.ddlSetGrade.DataTextField = "GradeName";
        this.ddlSetGrade.DataValueField = "GradeID";
        this.ddlSetGrade.DataBind();
    } 
    #endregion

    #region 有效期
    /// <summary>
    /// 有效期  
    /// </summary>
    private void SetValid()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdbtXM.DataTextField = "cdictname";
        this.rdbtXM.DataValueField = "idictvalue";
        this.rdbtXM.DataSource = dt;
        this.rdbtXM.DataBind();
    } 
    #endregion


   

    #region 绑定行页信息
    /// <summary>
    /// 绑定行页信息
    /// </summary>
    private void BindXinYe()
    {
        Tz888.SQLServerDAL.Info.MainInfoDAL objtp = new Tz888.SQLServerDAL.Info.MainInfoDAL();
        DataSet dv = objtp.IndustryList();

        this.ddlIndustry.DataSource = dv;
        this.ddlIndustry.DataTextField = "IndustryCarveOutNasme";
        this.ddlIndustry.DataValueField = "IndustryCarveOutID";
        this.ddlIndustry.DataBind();
    } 
    #endregion
    #region 绑定货币种类
    /// <summary>
    /// 绑定货币种类
    /// </summary>
    private void BindCurrency()
    {
        Tz888.BLL.Common.SetCurrencyBLL bll = new Tz888.BLL.Common.SetCurrencyBLL();
        DataView dv = bll.GetList();
        //this.ddlCapitalCurrency.DataSource = dv;
        //this.ddlCapitalCurrency.DataTextField = "CurrencyName";
        //this.ddlCapitalCurrency.DataValueField = "CurrencyID";
        //this.ddlCapitalCurrency.DataBind();

        this.ddlMerchantCurrency.DataSource = dv;
        this.ddlMerchantCurrency.DataTextField = "CurrencyName";
        this.ddlMerchantCurrency.DataValueField = "CurrencyID";
        this.ddlMerchantCurrency.DataBind();
    } 
    #endregion
    protected void LbLook_Click(object sender, EventArgs e)
    {
        string ImageDomain = (string)ConfigurationManager.AppSettings["ImageDomain"];
        ImageDomain += ViewState["pic1"].ToString();
        RegisterStartupScript("openwindow", "<script>　window.open ('" + ImageDomain + "', 'newwindow', 'height=600, width=600, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=n o, status=no') </script>");
    }
}
