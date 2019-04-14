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
using System.Text;
using System.Collections.Generic;
using Tz888.BLL;
using Tz888.Model;


public partial class cgal_CasesViewAdd : System.Web.UI.Page
{
    private static string url = "";
    private static long _infoid;
    private static string theInfoType = "Caseshtml";
    private static CasesInfoTabBLL cases = new CasesInfoTabBLL();
    private static Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
    private static Tz888.Model.Info.MainInfoModel mainInfo = new Tz888.Model.Info.MainInfoModel();
    private static Tz888.Model.Info.ShortInfoModel shortInfo=new Tz888.Model.Info.ShortInfoModel();
    private static Tz888.Model.CasesInfoTab casesInfo=new CasesInfoTab();
    private static List<Tz888.Model.Info.InfoResourceModel> infoResource = new List<Tz888.Model.Info.InfoResourceModel>();
    private static Tz888.Model.Info.InfoAuditModel auditModel = new Tz888.Model.Info.InfoAuditModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CasesTab();
            SetValid();
            url = Request["fid"].ToString();
            ViewState["url"]=url.ToString();
            if (url == "insert")
            {
                btnPublish.Text = "添加";
                this.divStatu1.Visible = true;
                this.divStatu2.Visible = false;
            }
            else if (url == "status")
            {
                btnPublish.Text="审核";
                _infoid = Convert.ToInt64(Request["infoID"].ToString());
                ViewState["infoID"] = _infoid;
                this.divStatu1.Visible = false;
                this.divStatu2.Visible = true;
                selCase(Convert.ToInt32(_infoid));
            }
        }
    }
    /// <summary>
    /// 分类
    /// </summary>
    private void CasesTab()
    {
        this.ddlCasesTypeID.DataSource = cases.setCases();
        this.ddlCasesTypeID.DataTextField = "CasesTypeName";
        this.ddlCasesTypeID.DataValueField = "CasesTypeID";
        this.ddlCasesTypeID.DataBind();
    }
    /// <summary>
    /// 有效期
    /// </summary>
    private void SetValid()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();
    }
    /// <summary>
    /// 查询信息
    /// </summary>
    /// <param name="infoId"></param>
    private void selCase(int infoId)
    {
        mainInfo = cases.selMainInfo(infoId);//主信息表信息
        this.txtTitle.Text = mainInfo.Title;
        this.txtKeyWord.Text =HtmlToTxt(mainInfo.KeyWord);
        this.txtDescript.Text =HtmlToTxt(mainInfo.Descript);
        this.txtDisplayTitle.Text =HtmlToTxt(mainInfo.DisplayTitle);
        this.rdlValiditeTerm.SelectedValue = mainInfo.ValidateTerm.ToString().Trim();

        this.txtHit.Text = mainInfo.Hit.ToString();
        this.rblAuditing.SelectedValue = mainInfo.AuditingStatus.ToString().Trim();

        shortInfo=cases.selShortInfo(infoId);//短信息表信息
        this.txtShortContent.Text=HtmlToTxt(shortInfo.ShortContent);
        this.txtShortTitle.Text=HtmlToTxt(shortInfo.ShortTitle);

        casesInfo=cases.selcaseInfo(infoId);//案例表信息
        this.ddlCasesTypeID.SelectedValue=CasesType(casesInfo.CasesTypeID.Trim());
       // this.txtContent.Text=HtmlToTxt(casesInfo.Content);
        this.FreeTextBox1.Text = casesInfo.Content;

        infoResource = cases.selInfoResource(infoId);
        //this.FilesUploadControl1.InfoList = infoResource;

        }
    /// <summary>
    /// 将文本中的html转换成标签
    /// </summary>
    /// <returns></returns>
    public static string HtmlToTxt(string strHtml)
	{
		string strTmp = strHtml;
		strTmp = strTmp.Replace("<br>", "\r\n");
		strTmp = strTmp.Replace("&lt;", "<");
		strTmp = strTmp.Replace("&gt;", ">");
		strTmp = strTmp.Replace("&nbsp;", " ");
		strTmp = strTmp.Replace("&nbsp", " ");
		return strTmp;
	}
    /// <summary>
    /// 将分类中的数字转换成文字
    /// </summary>
    /// <returns></returns>
    private string CasesType(string  CasesTypeId)
    {
        string name = "";
        switch (CasesTypeId) { 
            case "01":
                name = "招商案例";
                 break;
            case "02":
                name = "融资案例";
                 break;
            case "03":
                name = "创业案例";
                 break;
            case "04":
                name = "产权交易案例";
                 break;
            case "05":
                name = "贤泽创富案例";
                 break;
            case "06":
                name = "其他案例";
                 break;
            case "07":
                name = "技术案例";
                 break;
            case "08":
                name = "投资案例";
                 break;
        }
        return name;
    }

    protected void btnPublish_Click(object sender, EventArgs e)
    {
        int Hit=0;
        #region
        mainInfo.Title =this.txtTitle.Text.Trim();
        ViewState["Title"] = mainInfo.Title;
        Random ran=new Random();
		mainInfo.InfoCode ="CS"+"-"+"0000"+DateTime.Now.ToString("yyyyMMdd")+ran.Next(15);
        ViewState["InfoCode"] = mainInfo.InfoCode;
		mainInfo.publishT =Convert.ToDateTime( DateTime.Now.ToString());
        BasePage tb = new BasePage();
        mainInfo.LoginName = tb.LoginName;
       // mainInfo.LoginName=Page.User.Identity.Name;
       //  mainInfo.LoginName ="tz888Admin ";
		mainInfo.InfoOriginRoleName = "2";
        mainInfo.FixPriceID="0";
        mainInfo.FeeStatus=2;//付费 0付费,1未付费,2无需付费
        mainInfo.GradeID = "0";

		mainInfo.KeyWord = this.txtKeyWord.Text;
		mainInfo.Descript = this.txtDescript.Text;
		mainInfo.DisplayTitle = this.txtDisplayTitle.Text;
        if(this.txtDisplayTitle.Text=="")
        {
            mainInfo.DisplayTitle=this.txtTitle.Text.Trim();
        }
		mainInfo.FrontDisplayTime =Convert.ToDateTime( DateTime.Now.ToString());
		mainInfo.ValidateStartTime =Convert.ToDateTime( DateTime.Now.ToString("yyyy-MM-dd"));
		mainInfo.ValidateTerm = Convert.ToInt32(this.rdlValiditeTerm.SelectedValue);
		mainInfo.TemplateID = "001";
		//mainInfo.HtmlFile = strHtmlFile;
		#endregion
        
		casesInfo.CasesTypeID = this.ddlCasesTypeID.SelectedValue.Trim();			
		//casesInfo.Content = this.txtContent.Text;
        StringBuilder builder = new StringBuilder();
        casesInfo.Content =Convert.ToString( builder.Append(this.FreeTextBox1.Text.ToString())); 
		casesInfo.Pic1 = "";
		casesInfo.Pic2 = "";

		#region  短内容信息表

		shortInfo.ShortInfoControlID ="CaseIndex1";
		shortInfo.ShortTitle = this.txtShortTitle.Text;
		shortInfo.ShortContent = this.txtShortContent.Text;
		shortInfo.Remark ="";

        //infoResource = FilesUploadControl1.InfoList;

        #endregion
        if(ViewState["url"].ToString()=="insert")
        {  
          //Random rnd = new Random();
          //Hit = rnd.Next(25) + 5;
          mainInfo.Hit =1;
           long infodd=cases.insert(mainInfo,casesInfo,shortInfo,infoResource);
           if (infodd > 0)
           {
               if (cbAuditing.Checked)
               {
                   
                   mainInfo.HtmlFile = "Caseshtml/" + DateTime.Now.ToString("yyyyMM") + "/Cases" + DateTime.Now.ToString("yyyyMMdd") + "_" + infodd + ".shtml";
                   mainInfo.AuditingStatus = 1; 
               }
               else
               {
                   mainInfo.HtmlFile = "";
                   mainInfo.AuditingStatus = 0;
               }
               long statu = cases.UpdateStatus(Convert.ToInt32(infodd), mainInfo.HtmlFile,mainInfo.AuditingStatus);
               Response.Write("<script>alert('添加成功！');window.location.href='CasesView.aspx';</script>");
           }
           else
           {
               Response.Write("<script>alert('添加失败！');history.back(-1);</script>");
           }
        }
        else if (ViewState["url"].ToString() == "status")
        {
            mainInfo.Hit =Convert.ToInt32(this.txtHit.Text);

            int adstatus = 0;
            adstatus = mainInfo.AuditingStatus;

            byte auditing = 0;
            auditing =Convert.ToByte(this.rblAuditing.SelectedValue.Trim());

            string AuditingRemark = "";
            bool HasDone;
            string strHtmlFile = "";
            int MainPointCount = 0;

            long InfoAas = cases.update(mainInfo, casesInfo, shortInfo, infoResource, Convert.ToInt32(ViewState["infoID"]));
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

                            strHtmlFile = "Cases/" + DateTime.Now.ToString("yyyyMM") + "/Cases" + DateTime.Now.ToString("yyyyMMdd") + "_" + Convert.ToInt32(ViewState["infoID"]) + ".shtml";
                            long statu = cases.UpdateStatus(Convert.ToInt32(InfoAas), strHtmlFile, Convert.ToInt32(auditing));
                            //更改审核状态，同时记录操作
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, Convert.ToInt32(this.txtHit.Text.Trim()), mainInfo.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }

                            #region 写入信息审核记录
                            auditModel = new Tz888.Model.Info.InfoAuditModel();
                            auditModel.InfoID = Convert.ToInt32(ViewState["infoID"]);
                            auditModel.InfoTypeID = theInfoType;
                            auditModel.LoginName =mainInfo.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus =Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = mainInfo.LoginName;
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
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, Convert.ToInt32(this.txtHit.Text.Trim()), mainInfo.LoginName,
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
                            auditModel.LoginName = mainInfo.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = mainInfo.LoginName;
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
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, Convert.ToInt32(this.txtHit.Text.Trim()), mainInfo.LoginName,
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
                            auditModel.LoginName = mainInfo.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = mainInfo.LoginName;
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
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, Convert.ToInt32(this.txtHit.Text.Trim()), mainInfo.LoginName,
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
                            auditModel.LoginName = mainInfo.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = mainInfo.LoginName;
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
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, Convert.ToInt32(this.txtHit.Text.Trim()), mainInfo.LoginName,
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
                            auditModel.LoginName = mainInfo.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = mainInfo.LoginName;
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

                            strHtmlFile = "Cases/" + DateTime.Now.ToString("yyyyMM") + "/Cases" + DateTime.Now.ToString("yyyyMMdd") + "_" + Convert.ToInt32(ViewState["infoID"]) + ".shtml";
                            long statu = cases.UpdateStatus(Convert.ToInt32(InfoAas), strHtmlFile, Convert.ToInt32(auditing));
                            //更改审核状态，同时记录操作
                            HasDone = mainBll.HasAuditing(_infoid, auditing, true, Convert.ToInt32(this.txtHit.Text.Trim()), mainInfo.LoginName,
                            AuditingRemark, strHtmlFile, "", 0, MainPointCount);
                            if (!HasDone)
                            {
                                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
                            }

                            #region 写入信息审核记录
                            auditModel = new Tz888.Model.Info.InfoAuditModel();
                            auditModel.InfoID = Convert.ToInt32(ViewState["infoID"]);
                            auditModel.InfoTypeID = theInfoType;
                            auditModel.LoginName = mainInfo.LoginName;
                            auditModel.PostDate = System.DateTime.Now;
                            auditModel.Title = ViewState["Title"].ToString();
                            auditModel.FeedbackStatus = 0; //0,可修改|1,即将删除
                            auditModel.FeedBackNote = "";
                            auditModel.AuditStatus = Convert.ToInt32(auditing);
                            auditModel.AuditingDate = System.DateTime.Now;
                            auditModel.AuditingBy = mainInfo.LoginName;
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

                Response.Write("<script>alert('修改成功！');window.location.href='CasesView.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
            }
            
        }
    }
}
