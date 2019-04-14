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
/// <summary>
/// 修改专业服务
/// </summary>
public partial class ProfessionalManage_ModefiyProService : System.Web.UI.Page
{
    ProfessionalTypeBLL bll = new ProfessionalTypeBLL();
    ProfessionalviewBLL viewbll = new ProfessionalviewBLL();
    ProfessionalinfoBLL infoBll = new ProfessionalinfoBLL();
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
    protected void databindList(int ProfessionalID)
    {
        long PageSize = 0;
        long CurrPage = 0;
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Conn();
        //clickID,Fax,chargeID,FromID,Address,validityID,auditID,CompanyName,phone,ProfessionalID,CountryCode,ProvinceID,CityID,recommendID,CountyID,UserName,description,typeID,typetID,Email,Titel,Site,Tel,keywords,stateid
        DataTable dt = dal.GetList("ProfessionalService_View_List", "ProfessionalID", " * ", " ProfessionalID=" + ProfessionalID + "", "CreateDate desc ", ref CurrPage, PageSize, ref TotalCount);
        if ((dt != null) && (dt.Rows.Count > 0))
        {
            txtClick.Text = dt.Rows[0]["clickID"].ToString();
            txtTitle.Text = dt.Rows[0]["Titel"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtCompany.Text = dt.Rows[0]["CompanyName"].ToString();
            txtPhone.Text = dt.Rows[0]["phone"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtFax.Text = dt.Rows[0]["Fax"].ToString();
            txtContent.Text = dt.Rows[0]["description"].ToString();


            string tel = dt.Rows[0]["Tel"].ToString();
            string[] telLen = tel.Split(new char[] { ',' });
            if (telLen.Length == 1)
            {
                txtTel.Text = dt.Rows[0]["Tel"].ToString();
            }
            else
            {
                txtcontactsTel.Text = telLen[0].ToString();
                txtTel.Text = telLen[1].ToString();
                txttel2.Text = telLen[2].ToString();
            }

            txtSite.Text = dt.Rows[0]["Site"].ToString();
            txtPrice.Text = dt.Rows[0]["Price"].ToString();
            txtLinkMan.Text = dt.Rows[0]["UserName"].ToString();
            txtKeyword1.Text = dt.Rows[0]["keywords"].ToString();
            txtReTime.Text = Convert.ToDateTime(dt.Rows[0]["refreshTime"]).ToString("yyyy-MM-dd");
            txtWtitle.Text = dt.Rows[0]["title"].ToString();
            txtWebDesr.Text = dt.Rows[0]["Webdescription"].ToString();
            this.ZoneSelectControl1.CountryID = dt.Rows[0]["CountryCode"].ToString();
            this.ZoneSelectControl1.ProvinceID = dt.Rows[0]["ProvinceID"].ToString();
            this.ZoneSelectControl1.CityID = dt.Rows[0]["CityID"].ToString();
            this.ZoneSelectControl1.CountyID = dt.Rows[0]["CountyID"].ToString();
            rdlValiditeTerm.SelectedValue = dt.Rows[0]["validityID"].ToString();
            ddlServiceType.SelectedValue = dt.Rows[0]["typeId"].ToString();
            tbAuditingRemark.Text = dt.Rows[0]["FeedBackNote"].ToString();
            
            //ddlFrom.SelectedValue = dt.Rows[0]["FromID"].ToString();
            //0未审核  1审核通过 2审核未通过
            switch (int.Parse(dt.Rows[0]["auditId"].ToString()))
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
            if (int.Parse(dt.Rows[0]["chargeID"].ToString()) == 0)
            {
                rdomian.Checked = true;
                spShowPoint.Attributes.Add("style", "display:none");
            }
            else
            {
                rdoShou.Checked = true;
                spShowPoint.Attributes.Add("style", "display:''");
            }
            switch (int.Parse(dt.Rows[0]["stateid"].ToString()))
            {   //0无效 1有效 2已过期
                case 0:
                    rdoNoEnable.Checked = true;
                    break;
                case 1:
                    rdoYesEnable.Checked = true;
                    break;
                case 2:
                    rdoOverTime.Checked = true;
                    break;
                default:
                    rdoNoEnable.Checked = true;
                    break;
            }
            if (int.Parse(dt.Rows[0]["recommendID"].ToString()) == 0)
            {
                rdoNoAct.Checked = true; //不推荐
            }
            else
            {
                rdoYesAct.Checked = true;
            }

        }
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
    }
    //审核
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProfessionalinfoTab MainInfo = new ProfessionalinfoTab();
        Professionalview viewInfo = new Professionalview();

        ProfessionalLink personInfo = new ProfessionalLink();
        if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
        {
            int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
            MainInfo.ProfessionalID = ProfessionalID;
            MainInfo = infoBll.GetModel(ProfessionalID);
        }
        MainInfo.Titel = txtTitle.Text.Trim();
        //0未审核  1审核通过2审核未通过
        if (rdPass.Checked) { MainInfo.auditId = 1; } else if (rdAudit.Checked) { MainInfo.auditId = 0; } else if (rdNopass.Checked) { MainInfo.auditId = 2; } else { MainInfo.auditId = 4; }
        //是否收费 0 免费 1收费
        if (rdomian.Checked) { MainInfo.chargeId = 0; } else { MainInfo.chargeId = 1; }
        //来源 1 会员中心  2 业务员
        //MainInfo.FromId = int.Parse(ddlFrom.SelectedValue.ToString());
        //类型 1 需要服务2提供专业 3专业人才

        //if (rdoService.Checked) { MainInfo.typeID = 1; } else if (rdoPress.Checked) { MainInfo.typeID = 2; } else { MainInfo.typeID = 3; }
        //状态 0无效 1有效 2已过期
        if (rdoNoEnable.Checked) { MainInfo.stateId = 0; } else if (rdoYesEnable.Checked) { MainInfo.stateId = 1; } else { MainInfo.stateId = 2; }
        //是否推荐  不推荐 0  推荐  1
        if (rdoYesAct.Checked) { MainInfo.recommendId = 1; } else { MainInfo.recommendId = 0; }
        MainInfo.price = Convert.ToDecimal(txtPrice.Text.ToString());
        MainInfo.refreshTime = Convert.ToDateTime(txtReTime.Text.Trim().ToString());
        MainInfo.FeedBackNote = tbAuditingRemark.Text.Trim();
        MainInfo.clickId = int.Parse(txtClick.Text.Trim().ToString());
        MainInfo.Titel = txtTitle.Text.Trim();
        MainInfo.htmlUrl = "dservice/" + DateTime.Now.ToString("yyyyMM") + "/dservice" + DateTime.Now.ToString("yyyyMMdd") + "_" + Request.QueryString["ProfessionalID"].ToString() + ".shtml";
        viewInfo.CountryCode = this.ZoneSelectControl1.CountryID;
        viewInfo.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        viewInfo.CityID = this.ZoneSelectControl1.CityID;
        viewInfo.CountyID = this.ZoneSelectControl1.CountyID;
        viewInfo.description = txtContent.Text.Trim();
        viewInfo.title = txtWtitle.Text.Trim();
        viewInfo.keywords = txtKeyword1.Text.Trim();
        viewInfo.Webdescription = txtWebDesr.Text.Trim();
        viewInfo.validityID = int.Parse(rdlValiditeTerm.SelectedValue.ToString());
        viewInfo.typeID = int.Parse(ddlServiceType.SelectedValue.ToString());

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
        if (viewbll.UpdateProFessionlView(MainInfo, viewInfo, personInfo))
        {
            if (rdPass.Checked)
            {
                Tz888.BLL.ProfessionalManage.PageStatic stat = new PageStatic();
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
