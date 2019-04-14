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

public partial class offer_CapitalModify : System.Web.UI.Page
{
    private long _infoID;
    private string theInfoType = "Capital";
    BasePage bp = new BasePage();
    Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
    private static Tz888.BLL.offer.PageStatic page = new Tz888.BLL.offer.PageStatic(); //实例化创建文件类
    Tz888.BLL.Static Mercahrstatic = new Tz888.BLL.Static();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!this.Page.IsPostBack)
        {
       
            if (this.Page.Request.QueryString["infoID"] != null)
            {
                try
                {
                    this._infoID = Convert.ToInt64(this.Page.Request.QueryString["infoID"]);
                }
                catch
                {
                    this._infoID = 0;
                }
            }
            //this._infoID = 2396899;
            this.ViewState["InfoID"] = this._infoID;
            if (this._infoID == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "参数错误！");
                return;
            }
            this.BindSetCapital();//融资金额          
            this.BindCooperationDemandType();//绑定项目合作类型      
            BindDateEnd();//绑定项目有效期         
            this.LoadInfo(this._infoID);//信息加载绑定方法
            this.FilesUploadControl1.InfoType = "Capital";
            this.FilesUploadControl1.NoneCount = 5;
            this.FilesUploadControl1.Count = 5;            

            #region 以下是做判断的的方法
            
            for (int i = 0; i < this.chkLstCooperationDemand.Items.Count; i++)
            {
                this.chkLstCooperationDemand.Items[i].Attributes.Add("onclick", "checkCooperationDemand();");
            }
           
            //意向有效期限
            for (int i = 0; i < this.rdlValiditeTerm.Items.Count; i++)
            {
                this.rdlValiditeTerm.Items[i].Attributes.Add("onclick", "checkValiditeTerm();");
            }
          
            #endregion
        }
    }
 
    #region 设置融资金额
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
    #endregion

    #region 绑定项目合作类型
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
    #endregion
    #region  项目有效期限
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
    #region 加载信息绑定
    private void LoadInfo(long InfoID)
    {
        Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();
        Tz888.Model.Info.V124.CapitalSetModel model = new Tz888.Model.Info.V124.CapitalSetModel();
        model = bll.GetIntegrityModel(InfoID);



        this.txtCapitalName.Text = model.MainInfoModel.Title;
        if (model.CapitalInfoModel != null)
        {

            string CooperationDemandType = model.CapitalInfoModel.CooperationDemandType;
         

            //string CooperationDemandTypeItems;
            //for (int i = 0; i < chkLstCooperationDemand.Items.Count; i++)
            //{
            //    CooperationDemandTypeItems = chkLstCooperationDemand.Items[i].Value;

            //    if (CooperationDemandType.IndexOf(CooperationDemandTypeItems) != -1)
            //        chkLstCooperationDemand.Items[i].Selected = true;
            //}
            string[] str = model.CapitalInfoModel.CooperationDemandType.Split(new char[] { ',' });//1:123|2:123|3:123|4:123|
            
                string[] strchild = str;
                for (int j = 0; j < strchild.Length - 1; j++)
                {
                    if (!string.IsNullOrEmpty(strchild[j].ToString()))
                    {
                        switch (strchild[j].ToString())
                        {
                            case "1":
                                chkLstCooperationDemand.Items[0].Selected = true;
                                break;
                            case "11":
                                chkLstCooperationDemand.Items[1].Selected = true;
                                break;
                            case "2":
                                chkLstCooperationDemand.Items[2].Selected = true;
                                break;

                            default:
                                break;
                        }
                    }
                
               }
            

            this.ZoneMoreSelectControl1.CapitalInfoAreaModels = model.CapitalInfoAreaModels;
            if (!string.IsNullOrEmpty(model.CapitalInfoModel.IndustryBID.ToString()))
            {
                this.SelectIndustryControl1.IndustryString = model.CapitalInfoModel.IndustryBID;
            }

            this.rblCurreny.SelectedValue = model.CapitalInfoModel.CapitalID;




            this.txtCapitalIntent.Value = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(model.CapitalInfoModel.ComAbout));

            ViewState["ComBreif"] = model.CapitalInfoModel.ComBreif;
        }

        this.rdlValiditeTerm.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();


        txtHBao.Text = model.CapitalInfoModel.RegisteredCapital.ToString().Trim();
        //这里是换为投资机构名称
        txtGovName.Text = model.InfoContactModel.OrganizationName;

        txtLinkMan.Text = model.InfoContactModel.Name;
        txtTelCountry.Text = model.InfoContactModel.TelCountryCode;
        txtTelZoneCode.Text = model.InfoContactModel.TelStateCode;
        txtTelNumber.Text = model.InfoContactModel.TelNum;



        txtMobile.Text = model.InfoContactModel.Mobile;
        txtAddress.Text = model.InfoContactModel.Address;

        txtEmail.Text = model.InfoContactModel.Email;

        txtWebSite.Text = model.InfoContactModel.WebSite;
        
        txtKeord.Text = model.MainInfoModel.KeyWord;//网页关键字
        txtWtitle.Text = model.MainInfoModel.DisplayTitle;//网页标题
        this.txtDescript.Text = model.MainInfoModel.Descript;//网页描述

        if (Request.UrlReferrer != null)
            ViewState["strPrePage"] = Request.UrlReferrer.ToString();
        else
            ViewState["strPrePage"] = "";
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["PublishT"] = model.MainInfoModel.publishT;
        ViewState["LoginName"] = model.MainInfoModel.LoginName;
        ViewState["AuditingStatus"] = model.MainInfoModel.AuditingStatus;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;


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


        if (model.CapitalInfoModel.isVIP.ToString() != "")
        {
            this.ddlIsVip.SelectedValue = model.CapitalInfoModel.isVIP.ToString();
        }
        this.tbHits.Text = model.MainInfoModel.Hit.ToString();
        if (model.MainInfoModel.AuditingStatus == 0)
        {
           
            this.rdAudit.Checked = true;

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(0);", true);
           
        }
        if (model.MainInfoModel.AuditingStatus == 1)
        {
            this.rdPass.Checked = true;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(1);", true);

        }
        if (model.MainInfoModel.AuditingStatus == 2)
        {
            this.rdNopass.Checked = true;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(2);", true);
          
        }
        this.txtPointCount.Text = model.MainInfoModel.MainPointCount.ToString();
    
        this.FilesUploadControl1.InfoList = model.InfoResourceModels;
    } 
    #endregion



  
    #region 更新信息
    protected void btnUpdate_Click(object sender, EventArgs e)
    {


        long _infoID = Convert.ToInt32(Request["infoID"].ToString());

        Tz888.Model.Info.V124.CapitalSetModel model = new Tz888.Model.Info.V124.CapitalSetModel();
       model.CapitalInfoAreaModels = ZoneMoreSelectControl1.CapitalInfoAreaModels;

  
        #region 投资信息实体赋值

       model.CapitalInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalIntent.Value.ToString()));
      
        if (!string.IsNullOrEmpty(this.rblCurreny.SelectedValue.ToString()))
        {
            model.CapitalInfoModel.CapitalID = this.rblCurreny.SelectedValue;
        }
        model.CapitalInfoModel.CooperationDemandType = "";
        model.CapitalInfoModel.IndustryBID = this.SelectIndustryControl1.IndustryString;
        
        for (int i = 0; chkLstCooperationDemand.Items.Count > i; i++)
        {
            if (chkLstCooperationDemand.Items[i].Selected)
            {
                model.CapitalInfoModel.CooperationDemandType += chkLstCooperationDemand.Items[i].Value + ",";
            }
        }
        //以下是需要添加的参数
        //注册资金
        model.CapitalInfoModel.RegisteredCapital =this.txtHBao.Text.ToString().Trim();// this.rblRegisterdollar.SelectedValue;
        model.CapitalInfoModel.ComBreif = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(""));
        //团队规模  
        model.CapitalInfoModel.TeamScale = "";//;this.rblTeam.SelectedValue;
        //机构年平均投资事件数
        model.CapitalInfoModel.AverageInvestment = ""; //this.rblPinJ.SelectedValue;
        //机构成功投资事件总数
        model.CapitalInfoModel.SuccessfulInvestment = ""; //this.rblSucess.SelectedValue;
        //投资需求摘要
        model.CapitalInfoModel.InvestmentDemand = "";// this.txtDemand.Value;
        //添加所属区域

        
        #endregion
        //2010-08-04

        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtCapitalName.Text.Trim()))
            model.MainInfoModel.Title =Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCapitalName.Text.Trim());
        model.MainInfoModel.publishT = Convert.ToDateTime(this.ViewState["PublishT"]);

        model.MainInfoModel.LoginName = ViewState["LoginName"].ToString(); //用户名称

        //这里是换为投资机构名称
        model.InfoContactModel.OrganizationName = this.txtGovName.Text;
        model.InfoContactModel.OrgIntro = Tz888.Common.Utility.PageValidate.TxtToHtml("");
        model.InfoContactModel.Name = this.txtLinkMan.Text;
        model.InfoContactModel.TelCountryCode = this.txtTelCountry.Text;
        model.InfoContactModel.TelStateCode = this.txtTelZoneCode.Text;
        model.InfoContactModel.TelNum = this.txtTelNumber.Text;
        model.MainInfoModel.MainPointCount = Convert.ToInt32(this.txtPointCount.Text.ToString().Trim());


        model.InfoContactModel.Mobile = this.txtMobile.Text;
        model.InfoContactModel.Address = this.txtAddress.Text;
    
        model.InfoContactModel.Email = this.txtEmail.Text;
        string KeyWord = this.txtKeord.Text.ToString().Trim();  //关键字
        string DisplayTitle = this.txtWtitle.Text.Trim();     //网页标题
        string Descript = this.txtDescript.Text.ToString().Trim();  //网页描述
        model.InfoContactModel.WebSite = this.txtWebSite.Text;
        string keyword = "";
        model.MainInfoModel.KeyWord = KeyWord;
       model.MainInfoModel.Descript = Descript;
       model.MainInfoModel.DisplayTitle = DisplayTitle;
        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now;
       
        //意向有效期限
        model.MainInfoModel.ValidateTerm = int.Parse(this.rdlValiditeTerm.SelectedValue.Trim());
        model.MainInfoModel.TemplateID = "001";
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

            model.MainInfoModel.HtmlFile = "Capital/" + DateTime.Now.ToString("yyyyMM") + "/Capital" + DateTime.Now.ToString("yyyyMMdd") + "_" + _infoID + ".shtml";

        }
        if (rdNopass.Checked == true)
        {

          AuditingStatus = 2;
          
       
            model.MainInfoModel.HtmlFile = "";

        }
        model.MainInfoModel.AuditingStatus = AuditingStatus;
        //重点资源设置
        model.CapitalInfoModel.isVIP = Convert.ToInt32(this.ddlIsVip.SelectedValue.ToString());

      

        model.MainInfoModel.Hit = Convert.ToInt32(tbHits.Text.Trim());

        model.ShortInfoModel.ShortInfoControlID ="";
        model.ShortInfoModel.ShortTitle = "";
        model.ShortInfoModel.ShortContent = "";
        model.ShortInfoModel.Remark = "";

    
        int FixPriceID = Convert.ToInt32(this.ViewState["FixPriceID"]);


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

        Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();



        bool b = bll.Update(model);

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
     if (b)
        {
            #region 定价
            string price = "";
        
          
            #endregion
            int MainPointCount;

            if (chkIsPoint.Checked == true)
            {
                MainPointCount = Convert.ToInt32(txtPointCount.Text.Trim());
                price ="2";
            }
            else
            {
                MainPointCount = 0;
                price ="1";
            }



            bool pric = mainBll.HasFixPrice(_infoID, price, bp.LoginName.ToString().Trim());

            string AuditingRemark = "";
            Tz888.Model.Info.InfoAuditModel auditModel = new Tz888.Model.Info.InfoAuditModel();
            #region 写入信息审核记录
            auditModel = new Tz888.Model.Info.InfoAuditModel();

            auditModel.InfoID = model.MainInfoModel.InfoID;
            auditModel.InfoTypeID = theInfoType;
            auditModel.LoginName = ViewState["LoginName"].ToString();
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
                            b = mainBll.HasAuditing(_infoID, AuditingStatus, true, Convert.ToInt32(this.tbHits.Text.Trim()), model.MainInfoModel.LoginName,
                           AuditingRemark, model.MainInfoModel.HtmlFile, "", 0, MainPointCount);
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
            b = mainBll.InfoAuditNote(auditModel);
            if (b)
            {
              
                if (model.MainInfoModel.AuditingStatus==1)
                {
                    page = page.objGetMerchantInfoByInfoID(_infoID);//根ID获取信息
                    string IsVip = Mercahrstatic.SelCapitalInfoVip();//查询为重点推荐资源
                    string Idstuny = page.SelectLndus(model.CapitalInfoModel.IndustryBID);//根据区域查询信息
                    int sum = page.StaticHtml(Convert.ToInt32(_infoID), page.Title, page.PublishT, page.AreaName, page.Content,page.IndustryCarveOutID,page.CooperationTypeName,page.Money,page.ValidateID,page.MerchantNameTotal,  Idstuny,page.Pic,IsVip, KeyWord,  DisplayTitle,  Descript,page.Register);
                    if (sum == 0)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息失败！');location.href='CapitalManage.aspx'", true);
                    }
                    

                }
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息成功！');location.href='CapitalManage.aspx'", true);
              
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息失败！');location.href='CapitalManage.aspx'", true);
            }

            #endregion
           

           
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核信息失败！');location.href='CapitalManage.aspx'", true);
        }
    } 
    #endregion

          

}