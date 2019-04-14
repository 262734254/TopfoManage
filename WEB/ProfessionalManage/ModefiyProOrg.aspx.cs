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
using Tz888.BLL.ProfessionalManage;
using Tz888.Model.ProfessionalManage;
using Tz888.Common;
using Tz888.BLL;
public partial class ProfessionalManage_ModefiyProOrg : System.Web.UI.Page
{
    ProfessionalinfoBLL infoBll = new ProfessionalinfoBLL();
    ProfessionalLinkBLL linkBll = new ProfessionalLinkBLL();
    ProfessionalPleaseBLL plBll = new ProfessionalPleaseBLL();
    ProfessionalTypeBLL bll = new ProfessionalTypeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            databind();
            if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
            {
                int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
                databindList(ProfessionalID);
            }

        } btnSubmit.Attributes.Add("onclick", "return CheckForm();");
    }


    private void databind()
    {
        ddlServiceType.DataSource = bll.GetTypeAll();
        ddlServiceType.DataTextField = "typeName";
        ddlServiceType.DataValueField = "typeId";
        ddlServiceType.DataBind();

        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();

        //机构类别
        ProfessionalTalentsType orgBll = new ProfessionalTalentsType();
        this.DropIndustry.DataSource = orgBll.GetList("");
        this.DropIndustry.DataTextField = "TypeName";
        this.DropIndustry.DataValueField = "typeid";
        this.DropIndustry.DataBind();
    }
    protected void databindList(int ProfessionalID)
    {

        ProfessionalPlease plModel = plBll.GetModel(ProfessionalID);
        ProfessionalLink linkModel = linkBll.GetModel(ProfessionalID);
        ProfessionalinfoTab inModel = infoBll.GetModel(ProfessionalID);
        txtTitle.Text = inModel.Titel.ToString();
        txtPrice.Text = inModel.price.ToString();
        tbAuditingRemark.Text = inModel.FeedBackNote;
        this.ZoneSelectControl1.CountryID = plModel.CountryCode;
        this.ZoneSelectControl1.ProvinceID = plModel.ProvinceID;
        this.ZoneSelectControl1.CityID = plModel.CityID;
        this.ZoneSelectControl1.CountyID = plModel.CountyID;
        txtContent.Text = plModel.description;
        txtRegistYear.Text = plModel.companydate.ToString("yyyy-MM-dd");
        ddlServiceType.SelectedValue = plModel.servicetypeID.ToString();//服务类型
        DropIndustry.SelectedValue = plModel.institutionsID.ToString();//机构类别
        txtEmployeeCount.Value = plModel.Enterprisesize;//企业规模
        txtRegistMoeny.Value = plModel.funds;//注册资金
        txtTurnover.Value = plModel.turnover;//营业额
        rdlValiditeTerm.SelectedValue = plModel.validityID.ToString();//有效期
        txtAddress.Text = linkModel.Address;
        txtLinkMan.Text = linkModel.UserName;
        txtPhone.Text = linkModel.phone;
        txtCompany.Text = linkModel.CompanyName;
        txtClick.Text = inModel.clickId.ToString();
        txtEmail.Text = linkModel.Email;
        txtFax.Text = linkModel.Fax;

        string tel = linkModel.Tel;
        string[] telLen = tel.Split(new char[] { ',' });
        if (telLen.Length == 1)
        {
            txtTel.Text = linkModel.Tel;
        }
        else
        {
            txtcontactsTel.Text = telLen[0].ToString();
            txtTel.Text = telLen[1].ToString();
            txttel2.Text = telLen[2].ToString();
        }
        txtSite.Text = linkModel.Site;
        txtWtitle.Text = plModel.title;
        txtKeyword1.Text = plModel.keywords;
        txtWebDesr.Text = plModel.webdescription;
        txtReTime.Text = inModel.refreshTime.ToString("yyyy-MM-dd");
        //0未审核  1审核通过2审核未通过
        switch (int.Parse(inModel.auditId.ToString()))
        {
            case 0:
                rdAudit.Checked = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(0);", true);
                break;
            case 1:
                rdPass.Checked = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(1);", true);
                break;
            case 2:
                rdNopass.Checked = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(2);", true);
                break;
            case 4:
                rdDelete.Checked = true;
                rdPass.Enabled = false;
                rdAudit.Enabled = false;
                rdNopass.Enabled = false;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(0);", true);
                break;
            default:
                rdAudit.Checked = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit(0);", true);
                break;
        }
        if (inModel.chargeId == 0)
        {
            rdomian.Checked = true;
            spShowPoint.Attributes.Add("style", "display:none");
        }
        else
        {
            rdoShou.Checked = true;
            spShowPoint.Attributes.Add("style", "display:''");
        }
    }
    //审核
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProfessionalinfoTab MainInfo = new ProfessionalinfoTab();
        ProfessionalPlease viewInfo = new ProfessionalPlease();

        ProfessionalLink personInfo = new ProfessionalLink();
        if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
        {
            int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
            MainInfo.ProfessionalID = ProfessionalID;
        }
        MainInfo.Titel = txtTitle.Text.Trim();
        //0未审核  1审核通过2审核未通过
        if (rdPass.Checked) { MainInfo.auditId = 1; } else if (rdAudit.Checked) { MainInfo.auditId = 0; } else if (rdNopass.Checked) { MainInfo.auditId = 2; } else { MainInfo.auditId = 4; }
        //是否收费 0 免费 1收费
        // if (rdomian.Checked) { MainInfo.chargeId = 0; } else { MainInfo.chargeId = 1; }
        //来源 1 会员中心  2 业务员
        //MainInfo.FromId = int.Parse(ddlFrom.SelectedValue.ToString());
        //类型 1 需要服务2提供专业 3专业人才
        //if (rdoService.Checked) { MainInfo.typeID = 1; } else if (rdoPress.Checked) { MainInfo.typeID = 2; } else { MainInfo.typeID = 3; }
        //状态 0无效 1有效 2已过期
        //if (rdoNoEnable.Checked) { MainInfo.stateId = 0; } else if (rdoYesEnable.Checked) { MainInfo.stateId = 1; } else { MainInfo.stateId = 2; }
        //是否推荐  不推荐 0  推荐  1
        //if (rdoYesAct.Checked) { MainInfo.recommendId = 1; } else { MainInfo.recommendId = 0; }
        MainInfo.price = Convert.ToDecimal(txtPrice.Text.ToString());
        MainInfo.refreshTime = Convert.ToDateTime(txtReTime.Text.Trim().ToString());
        MainInfo.clickId = int.Parse(txtClick.Text.Trim().ToString());
        MainInfo.Titel = txtTitle.Text.Trim();
        MainInfo.FeedBackNote = tbAuditingRemark.Text.Trim();
        MainInfo.typeID = 2;
       
        MainInfo.htmlUrl = "dservice/" + DateTime.Now.ToString("yyyyMM") + "/dservice" + DateTime.Now.ToString("yyyyMMdd") + "_" + Request.QueryString["ProfessionalID"].ToString() + ".shtml";
        viewInfo.CountryCode = this.ZoneSelectControl1.CountryID;
        viewInfo.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        viewInfo.CityID = this.ZoneSelectControl1.CityID;
        viewInfo.CountyID = this.ZoneSelectControl1.CountyID;
        viewInfo.description = txtContent.Text.Trim();
        viewInfo.companydate = Convert.ToDateTime(txtRegistYear.Text.Trim().ToString());
        viewInfo.servicetypeID = int.Parse(ddlServiceType.SelectedValue.ToString());//服务类型
        viewInfo.institutionsID = int.Parse(DropIndustry.SelectedValue.ToString());//机构类别
        viewInfo.Enterprisesize = txtEmployeeCount.Value.Trim();//企业规模
        viewInfo.funds = txtRegistMoeny.Value.Trim();//注册资金
        viewInfo.turnover = txtTurnover.Value.Trim();//营业额
        viewInfo.title = txtWtitle.Text.Trim();
        viewInfo.keywords = txtKeyword1.Text.Trim();
        viewInfo.webdescription = txtWebDesr.Text.Trim();
        viewInfo.validityID = int.Parse(rdlValiditeTerm.SelectedValue.ToString());//有效期
        personInfo.Address = txtAddress.Text.Trim();
        personInfo.CompanyName = txtCompany.Text.Trim();
        personInfo.Email = txtEmail.Text.Trim();
        personInfo.Fax = txtFax.Text.Trim();
        personInfo.phone = txtPhone.Text.Trim();

        string tel = string.Empty;
        if (!string.IsNullOrEmpty(txtcontactsTel.Text.Trim()))
        {
            tel = txtcontactsTel.Text.Trim() + ",";
        }
        else
        {
            tel = ",";
        }
        if (!string.IsNullOrEmpty(txtTel.Text.Trim()))
        {
            tel += txtTel.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        if (!string.IsNullOrEmpty(txttel2.Text.Trim()))
        {
            tel += txttel2.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        personInfo.Tel = tel;

        personInfo.UserName = txtLinkMan.Text.Trim();
        personInfo.Site = txtSite.Text.Trim();
        if (plBll.UpdateProFessionlView(MainInfo, viewInfo, personInfo))
        {
            if (rdPass.Checked)
            {
                PageStaticOrg stat = new PageStaticOrg();
                int result = stat.StaticHtml(int.Parse(Request.QueryString["ProfessionalID"].ToString()));
                if (result <= 0)
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
                }
            }
            Response.Write("<script>alert('审核成功！');document.location='ProfessionalManage.aspx'</script>");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "审核失败！");
        }
    }
}
