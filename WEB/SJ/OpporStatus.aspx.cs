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

public partial class SJ_OpporStatus : System.Web.UI.Page
{
    private static Tz888.BLL.Info.OpportunityInfoBLL opp = new Tz888.BLL.Info.OpportunityInfoBLL();
    private static Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
    private static Tz888.Model.Info.MainInfoModel main = new Tz888.Model.Info.MainInfoModel();//主表
    private static Tz888.Model.Info.OpportunityInfoModel pOpportunity = new Tz888.Model.Info.OpportunityInfoModel();//商机信息表
    private static Tz888.Model.Info.ShortInfoModel shortInfoRule = new Tz888.Model.Info.ShortInfoModel();//短消息表
    private static Tz888.Model.Info.InfoAuditModel auditModel = new Tz888.Model.Info.InfoAuditModel();
    private static string url = "";
    private static string theInfoType = "Oppor";
    private static long _infoid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetOpportun();
            GetIndustry();
            SetValid();
            url = Request["fid"].ToString();
            ViewState["url"] = url.ToString();
            if (url == "insert")
            {
                this.divStatu1.Visible = true;
                this.divStatu2.Visible = false;
            }
            else if (url == "status")
            {
                _infoid = Convert.ToInt64(Request["infoID"].ToString());
                ViewState["infoID"] = _infoid;
                this.divStatu1.Visible = false;
                this.divStatu2.Visible = true;
                GetFixPrice();
                GetGrade();
                
                MainOppor(Convert.ToInt32(_infoid));
            }
            
        }
    }
    /// <summary>
    /// 商机类别
    /// </summary>
    private void SetOpportun()
    {
        this.ddlOpportunityType.DataSource = opp.GetOpportun();
        this.ddlOpportunityType.DataValueField = "OpportunityTypeID";
        this.ddlOpportunityType.DataTextField = "OpportunityTypeName";
        this.ddlOpportunityType.DataBind();
    }
    /// <summary>
    /// 所属行业
    /// </summary>
    private void GetIndustry()
    {
        this.ddlIndustry.DataSource = opp.GetIndustry();
        this.ddlIndustry.DataValueField = "IndustryOpportunityID";
        this.ddlIndustry.DataTextField = "IndustryOpportunityName";
        this.ddlIndustry.DataBind();
    }
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
    /// <summary>
    /// 信息评定
    /// </summary>
    private void GetFixPrice()
    {
        this.ddlFixPrice.DataSource = opp.GetFixPrice();
        this.ddlFixPrice.DataValueField = "FixWorthPointID";
        this.ddlFixPrice.DataTextField = "FixWorthPointName";
        this.ddlFixPrice.DataBind();
    }
    /// <summary>
    /// 信息评分
    /// </summary>
    private void GetGrade()
    {
        this.ddlGrade.DataSource = opp.GetGrade();
        this.ddlGrade.DataValueField = "GradeID";
        this.ddlGrade.DataTextField = "GradeName";
        this.ddlGrade.DataBind();
    }

    private void MainOppor(int num)
    {
        main = opp.SetMainInfo(num);
        this.txtTitle.Text = main.Title.ToString().Trim();
        this.ddlGrade.SelectedValue = main.GradeID;
        this.ddlFixPrice.SelectedValue = main.FixPriceID;
        this.rblAuditing.SelectedValue = main.AuditingStatus.ToString().Trim();
        this.txtKeyWord.Text = main.KeyWord.ToString().Trim();
        this.txtDescript.Text = main.Descript.ToString().Trim();
        this.rdbtXM.SelectedValue = main.ValidateTerm.ToString().Trim();
        this.txtDisplayTitle.Text = main.DisplayTitle.ToString().Trim();
        if (this.rblAuditing.SelectedValue == "1")
        {
            divAuditing.Style["display"] = "block";
            
        }

        pOpportunity = opp.SetOpportunity(num);
        this.txtAdTitle.Text = pOpportunity.AdTitle.ToString().Trim();
        this.ddlOpportunityType.SelectedValue = pOpportunity.OpportunityType;
        this.ZoneSelectControl2.CountryID = pOpportunity.CountryCode.ToString().Trim();
        this.ZoneSelectControl2.ProvinceID = pOpportunity.ProvinceID.ToString().Trim();
        this.ZoneSelectControl2.CountyID = pOpportunity.CountyID.ToString().Trim();
        this.ddlIndustry.SelectedValue = pOpportunity.IndustryOpportunityID;
       // this.txtContent.Text =HtmlToTxt(pOpportunity.Content.ToString().Trim());
        this.txtContent.Text = pOpportunity.Content.ToString().Trim();
        this.txtAnalysis.Text = pOpportunity.Analysis.ToString().Trim();
        this.txtRequest.Text = pOpportunity.Request.ToString().Trim();
        this.txtFlow.Text = pOpportunity.Flow.ToString().Trim();
        this.txtRemark.Text = pOpportunity.Remark.ToString().Trim();
        this.txtComName.Text = pOpportunity.ComName.ToString().Trim();
        this.txtLinkMan.Text = pOpportunity.LinkMan.ToString().Trim();
        string[] tel = pOpportunity.Tel.ToString().Trim().Split('－');
        this.txtTelCountry.Text = tel[0].ToString();
        this.txtTelZoneCode.Text = tel[1].ToString();
        this.txtTelNumber.Text = tel[2].ToString();
        this.txtMobile.Text = pOpportunity.Mobile.ToString().Trim();
        this.txtAddress.Text = pOpportunity.Address.ToString().Trim();
        this.txtPostCode.Text = pOpportunity.PostCode.ToString().Trim();
        this.txtEmail.Text = pOpportunity.Email.ToString().Trim();
        this.txtWebSite.Text = pOpportunity.WebSite.ToString().Trim();

        shortInfoRule = opp.SetShortInfo(num);
        this.txtShortContent.Text = shortInfoRule.ShortContent.ToString().Trim();
        this.txtShortTitle.Text = shortInfoRule.ShortTitle.ToString().Trim();
    }

    protected void btnPublish_Click(object sender, EventArgs e)
    {
        #region 主表

        main.Title = txtTitle.Text.Trim();
        ViewState["Title"] = main.Title;
        main.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Oppor", ddlIndustry.SelectedValue.ToString().Trim(), this.ZoneSelectControl2.CountryID, DateTime.Now);
        main.publishT = Convert.ToDateTime(DateTime.Now);
        main.Hit = 1;
        //main.LoginName = Page.User.Identity.Name;
        main.LoginName ="tz888admin";
        main.InfoOriginRoleName = "0";

        main.KeyWord = txtKeyWord.Text.Trim();
        main.Descript = txtDescript.Text.Trim();
        main.DisplayTitle = txtDisplayTitle.Text.Trim();
        main.FrontDisplayTime = Convert.ToDateTime(DateTime.Now);
        main.ValidateStartTime = Convert.ToDateTime(DateTime.Now);
        main.ValidateTerm = Convert.ToInt32(this.rdbtXM.SelectedValue.Trim()); ;
        main.TemplateID = "001";
        
        #endregion

        #region 商机信息表
        pOpportunity.AdTitle = txtAdTitle.Text.Trim();
        pOpportunity.OpportunityType = ddlOpportunityType.SelectedValue.ToString().Trim();
        pOpportunity.CountryCode = ZoneSelectControl2.CountryID;
        pOpportunity.ProvinceID = ZoneSelectControl2.ProvinceID;
        pOpportunity.CountyID = ZoneSelectControl2.CountyID;

        pOpportunity.IndustryOpportunityID = ddlIndustry.SelectedValue.ToString().Trim();
        pOpportunity.ValidateID = "1";

        pOpportunity.Pic1 ="";                //图片

        pOpportunity.Content = HtmlToTxt(txtContent.Text);          //商机内容
        pOpportunity.Analysis = txtAnalysis.Text;          //商机分析
        pOpportunity.Request = txtRequest.Text;          //商机需求
        pOpportunity.Flow = txtFlow.Text;            //商机流程
        pOpportunity.Remark = txtRemark.Text;           //备注

        pOpportunity.ComName = txtComName.Text.Trim();   //公司名称
        pOpportunity.LinkMan = txtLinkMan.Text.Trim();   //联系人
        pOpportunity.Tel = txtTelCountry.Text.Trim() + "－" + txtTelZoneCode.Text.Trim() + "－" + txtTelNumber.Text.Trim();  //电话
        pOpportunity.Fax = "";
        pOpportunity.Mobile = txtMobile.Text.Trim();  //手机    
        pOpportunity.Address = txtAddress.Text.Trim();//地址
        pOpportunity.PostCode = txtPostCode.Text.Trim();//
        pOpportunity.Email = txtEmail.Text.Trim();//邮箱
        pOpportunity.WebSite = txtWebSite.Text.Trim();//
        #endregion

        #region  短内容信息表

        shortInfoRule.ShortInfoControlID = "OpporIndex1";
        shortInfoRule.ShortTitle = txtShortTitle.Text.Trim();
        shortInfoRule.ShortContent = txtShortContent.Text.Trim();
        shortInfoRule.Remark = "";
        #endregion
        if (ViewState["url"].ToString() == "insert")
        {
            //插入数据
            long InfoID = opp.Insert(main, pOpportunity, shortInfoRule);
       
            if (InfoID > 0)
            {
                if (cbAuditing.Checked)
                {
                    main.HtmlFile = "Oppor/" + DateTime.Now.ToString("yyyyMM") +"/"+ main.InfoCode+"_"+InfoID+".shtml";
                    main.AuditingStatus = 1;
                }
                else
                {
                    main.HtmlFile = "";
                    main.AuditingStatus = 0;
                }
                long status = opp.UpdateState(main.HtmlFile, main.AuditingStatus, Convert.ToInt32(InfoID));
                Response.Write("<script>alert('添加成功')</script>");
            }
            else
            {
                Response.Write("<script language=\"javascript\">alert('添加失败')</script>");
            }
        }
        else if (ViewState["url"].ToString() == "status")
        {
            int adstatus = 0;
            adstatus = main.AuditingStatus;

            byte auditing = 0;
            auditing = Convert.ToByte(this.rblAuditing.SelectedValue.Trim());

            string AuditingRemark = "";
            bool HasDone;
            string strHtmlFile = "";
            int MainPointCount = 0;
            if (this.rblAuditing.SelectedValue == "1")
            {
                long stat = opp.GradeFixModify(this.ddlGrade.SelectedValue.Trim(), this.ddlFixPrice.SelectedValue.Trim(),Convert.ToInt32(ViewState["infoID"]));
            }

            long InfoAas = opp.HasModify(main, pOpportunity, shortInfoRule, Convert.ToInt32(ViewState["infoID"]));
            #region 添加审核记录

            switch (adstatus)
            {
                case 0:
                    switch (auditing)
                    {
                        case 0:
                            break;
                        case 1:
                            AuditingRemark = "未审核->审核通过";

                            strHtmlFile = "Oppor/" + DateTime.Now.ToString("yyyyMM") + "/" + main.InfoCode + "_" + Convert.ToInt32(ViewState["infoID"]) + ".shtml";
                            long statu = opp.UpdateState(strHtmlFile, Convert.ToInt32(auditing), Convert.ToInt32(InfoAas));
                            //更改审核状态，同时记录操作
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, 1, main.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }

                            #region 写入信息审核记录
                            auditModel = new Tz888.Model.Info.InfoAuditModel();
                            auditModel.InfoID = Convert.ToInt32(ViewState["infoID"]);
                            auditModel.InfoTypeID = theInfoType;
                            auditModel.LoginName = main.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = main.LoginName;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.Memo = "";
                            HasDone = mainBll.InfoAuditNote(auditModel);
                            #endregion

                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }

                            break;
                        case 2:
                            AuditingRemark = "未审核->审核未通过";

                            #region 写入操作记录
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, 1, main.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }
                            #endregion

                            #region 写入信息审核记录
                            auditModel = new Tz888.Model.Info.InfoAuditModel();
                            auditModel.InfoID = Convert.ToInt32(ViewState["infoID"]);
                            auditModel.InfoTypeID = theInfoType;
                            auditModel.LoginName = main.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = main.LoginName;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.Memo = "";
                            HasDone = mainBll.InfoAuditNote(auditModel);
                            #endregion

                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }
                            break;
                    }
                    break;
                case 1:
                    switch (auditing)
                    {
                        case 0:
                            AuditingRemark = "审核通过->未审核";

                            #region 写入操作记录
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true,1, main.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }
                            #endregion

                            #region 写入信息审核记录
                            auditModel = new Tz888.Model.Info.InfoAuditModel();
                            auditModel.InfoID = Convert.ToInt32(ViewState["infoID"]);
                            auditModel.InfoTypeID = theInfoType;
                            auditModel.LoginName = main.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = main.LoginName;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.Memo = "";
                            #endregion
                            HasDone = mainBll.InfoAuditNote(auditModel);

                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }
                            break;
                        case 1:
                            break;
                        case 2:
                            AuditingRemark = "审核通过->审核未通过";

                            #region 写入操作记录
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, 1, main.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }
                            #endregion

                            #region 写入信息审核记录
                            auditModel = new Tz888.Model.Info.InfoAuditModel();
                            auditModel.InfoID = Convert.ToInt32(ViewState["infoID"]);
                            auditModel.InfoTypeID = theInfoType;
                            auditModel.LoginName = main.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = main.LoginName;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.Memo = "";
                            HasDone = mainBll.InfoAuditNote(auditModel);
                            #endregion

                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (auditing)
                    {
                        case 0:
                            AuditingRemark = "审核未通过->未审核";

                            #region 写入操作记录
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, 1, main.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }
                            #endregion

                            #region 写入信息审核记录
                            auditModel = new Tz888.Model.Info.InfoAuditModel();
                            auditModel.InfoID = Convert.ToInt32(ViewState["infoID"]);
                            auditModel.InfoTypeID = theInfoType;
                            auditModel.LoginName = main.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = main.LoginName;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.Memo = "";
                            HasDone = mainBll.InfoAuditNote(auditModel);
                            #endregion

                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }
                            break;
                            case 1:
                            AuditingRemark = "审核未通过->审核通过";

                            strHtmlFile = "Oppor/" + DateTime.Now.ToString("yyyyMM") + "/" + main.InfoCode + "_" + Convert.ToInt32(ViewState["infoID"]) + ".shtml";
                            long statu = opp.UpdateState(strHtmlFile, Convert.ToInt32(auditing), Convert.ToInt32(InfoAas));
                            //更改审核状态，同时记录操作
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, 1, main.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }

                            #region 写入信息审核记录
                            auditModel = new Tz888.Model.Info.InfoAuditModel();
                            auditModel.InfoID = Convert.ToInt32(ViewState["infoID"]);
                            auditModel.InfoTypeID = theInfoType;
                            auditModel.LoginName = main.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = main.LoginName;
                            auditModel.AuditingRemark = AuditingRemark;
                            auditModel.Memo = "";
                            HasDone = mainBll.InfoAuditNote(auditModel);
                            #endregion

                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }
                            break;
                        case 2:
                            break;
                    }
                    break;
            }
            #endregion
            if (InfoAas > 0)
            {

                Response.Write("<script>alert('修改成功！');window.location.href='OpporView.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
            }

        }
    }
    #region 将输入的文本字符串转换成HTML代码
    /// <summary>
    /// 将输入的文本字符串转换成HTML代码，转换以下字符
    /// </summary>
    public static string TxtToHtml(string strTxt)
    {
        string strTmp = strTxt;
        strTmp = strTmp.Replace("<", "&lt;");
        strTmp = strTmp.Replace(">", " &gt;");
        strTmp = strTmp.Replace(" ", "&nbsp;");
        strTmp = strTmp.Replace("\r\n", "<br>");
        return strTmp;
    }

    public static string HtmlToTxt(string strHtml)
    {
        string strTmp = strHtml;
        strTmp = strTmp.Replace("&lt;", "<");
        strTmp = strTmp.Replace("&gt;", ">");
        strTmp = strTmp.Replace("&nbsp;", " ");
        strTmp = strTmp.Replace("<br>", "\r\n");
        return strTmp;
    }
    #endregion
}
