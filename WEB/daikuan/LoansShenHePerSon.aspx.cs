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
using Tz888.Model;

public partial class Publish_LoansShenHe : System.Web.UI.Page
{
    private int loansInfoID
    {
        get
        {
            return (int)ViewState["loansInfoID"];
        }
        set
        {
            ViewState["loansInfoID"] = value;
        }
    }
    Tz888.BLL.loansInfoTab loansInfoTabbll = new Tz888.BLL.loansInfoTab();
    Tz888.BLL.LoansInfo loansinfobll = new Tz888.BLL.LoansInfo();
    Tz888.BLL.loanscontactsTab loanscontacttabbll = new Tz888.BLL.loanscontactsTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loansInfoID = Convert.ToInt32(Request.QueryString["str"].ToString());
   
            BindShow();
        }
    }

    private void BindShow()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.SelectedIndex = 0;
        this.rdlValiditeTerm.DataBind();
        this.rdlValiditeSystem.DataTextField = "cdictname";
        this.rdlValiditeSystem.DataValueField = "idictvalue";
        this.rdlValiditeSystem.DataSource = dt;
        this.rdlValiditeSystem.SelectedIndex = 0;
        this.rdlValiditeSystem.DataBind();




        Tz888.Model.LoansInfoTab loansInfotab = (Tz888.Model.LoansInfoTab)loansInfoTabbll.GetLoansInfoTabByLoansInfoId(loansInfoID);
        Tz888.Model.LoansInfo loansinfo = (Tz888.Model.LoansInfo)loansinfobll.GetLoansInfoByLoansInfoId(loansInfoID);
        Tz888.Model.LoanscontactsTab loanscontactstab = (Tz888.Model.LoanscontactsTab)loanscontacttabbll.GetLoanscontactsTabByLoansInfoId(loansInfoID);
        radiotuijian.Items.FindByValue(loansInfotab.RecommendID.ToString ().Trim ()).Selected = true;
        int shentype = Convert.ToInt32 (loansInfotab.AuditID.ToString().Trim());
        if (shentype == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "提示f：", "changgereson(" + shentype + ");", true);
            shen.Checked = true;
            
        }
        if (shentype == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "提示f：", "changgereson(" + shentype + ");", true);
            shens.Checked = true;
        }
        if (shentype == 3)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "提示f：", "changgereson(" + shentype + ");", true);
            shensss.Checked = true;
        }
        if (shentype == 5)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "提示f：", "changgereson(" + shentype + ");", true);
            shenssss.Checked = true;
            shen.Disabled =true;
            shens.Disabled = true;
            shensss.Disabled = true;
            shenssss.Disabled = true;
        }
        txtCapitalTitle.Text = loansInfotab.LoansTitle.ToString();
        txtCapitalMoney.Text = loansinfo.Amount.ToString();
        radiohaiMoney.Items.FindByValue(loansinfo.Reimbursement.ToString().Trim()).Selected = true;
        radiodanbao.Items.FindByValue(loansinfo.Guarantee.ToString().Trim()).Selected = true;
        txtCapitalIntent.Value = loansinfo.BorrowingUse.ToString();
        txttitle.Text = loansinfo.Title.ToString ();
        txtkeywords.Text = loansinfo.Keywords.ToString();
        txtdescript.Text = loansinfo.Description.ToString();
        txtreson.Text = loansinfo.Reason.ToString();
        txtcontactsName.Text = loanscontactstab.ContactsName.ToString();
        txtcontactsphone.Text = loanscontactstab.Moblie.ToString();
        string[] num = loanscontactstab.Telephone.ToString().Trim().Split('-');
        if (num.Length == 1)
        {
            txttel1.Text = num[0];
        }
        else if (num.Length == 2)
        {
            txttel1.Text = num[0];
        }
        else if (num.Length == 3)
        {
            txtcontactsTel.Text = num[0];
            txttel1.Text = num[1];
            txttel2.Text = num[2];
        }
            
        txtcontactsemail.Text = loanscontactstab.Mail.ToString();
        txtcontactsaddress.Text = loanscontactstab.Address.ToString();
        this.ZoneSelectControl1.CountryID = loansinfo.CountryID.ToString().Trim();
        this.ZoneSelectControl1.ProvinceID = loansinfo.ProvinceID.ToString().Trim();
        this.ZoneSelectControl1.CityID = loansinfo.CityID.ToString().Trim();
        this.ZoneSelectControl1.CountyID = loansinfo.CountyID.ToString().Trim();
        this.rdlValiditeTerm.Items.FindByValue(loansinfo.Deadline.ToString().Trim()).Selected = true;
        this.rdlValiditeSystem.Items.FindByValue(loansinfo.ValidityID.ToString().Trim()).Selected = true;


    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.LoansInfoTab loansInfotab = new LoansInfoTab();
        Tz888.Model.LoansInfo loansinfo = new LoansInfo();
        Tz888.Model.LoanscontactsTab loanscontactstab = new LoanscontactsTab();
        //贷款主表的修改
        loansInfotab.LoansInfoID = loansInfoID;
        loansInfotab.LoansTitle = txtCapitalTitle.Text.Trim();
        loansInfotab.Updatetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
        if (shen.Checked == true)
        {
            loansInfotab.AuditID = 0;
            loansInfotab.Url = "";
        }
        if (shens.Checked == true)
        {
            loansInfotab.AuditID = 1;
            loansInfotab.AuditID = 1;
            string urladdress = loansInfoTabbll.GetLoansInfoTabByLoansInfoId(loansInfoID).Url.Trim();
            if (urladdress == "")
            {
                loansInfotab.Url = "loans/" + DateTime.Now.ToString("yyyyMM") + "/loans" + DateTime.Now.ToString("yyyyMMdd") + "_" + loansInfoID + ".shtml";

            }
            else
            {
                loansInfotab.Url = urladdress;
            }
        }
        if (shensss.Checked == true)
        {
            loansInfotab.AuditID = 3;
            loansInfotab.Url = "";
        }
        if (shenssss.Checked == true)
        {
            loansInfotab.AuditID = 5;
            loansInfotab.Url = "";
        }
        loansInfotab.RecommendID = Convert.ToInt32(radiotuijian.SelectedValue.ToString().Trim());
        int reulstrow1 = loansInfoTabbll.ShenHeLoansInfoTab(loansInfotab);

        //贷款详细表的修改
        loansinfo.CountryID = this.ZoneSelectControl1.CountryID;
        loansinfo.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        loansinfo.CityID = this.ZoneSelectControl1.CityID;
        loansinfo.CountyID = this.ZoneSelectControl1.CountyID;
        if (txtCapitalMoney.Text.Trim() == "" || txtCapitalMoney.Text.Trim() == null)
        {
            loansinfo.Amount = 0;
        }
        else
        {
            loansinfo.Amount = Convert.ToInt32(txtCapitalMoney.Text.Trim());
        }
        loansinfo.Deadline = Convert.ToInt32(rdlValiditeTerm.SelectedValue.Trim());
        loansinfo.Reimbursement = Convert.ToInt32(this.radiohaiMoney.SelectedValue.Trim());
        loansinfo.Guarantee = Convert.ToInt32(this.radiodanbao.SelectedValue.Trim());
        loansinfo.BorrowingUse = txtCapitalIntent.Value.Trim();
        loansinfo.ValidityID = Convert.ToInt32(rdlValiditeSystem.SelectedValue.Trim());
        loansinfo.Title = txttitle.Text.Trim();
        loansinfo.Keywords = txtkeywords.Text.Trim();
        loansinfo.Description = txtdescript.Text.Trim();
        loansinfo.Reason = txtreson.Text.Trim();
        int resultrow2 = loansinfobll.ShenHeloansInfo(loansinfo, loansInfoID);
        loanscontactstab.EnterpriseName = "";
        loanscontactstab.ContactsName = txtcontactsName.Text.Trim();
        loanscontactstab.Telephone = txtcontactsTel.Text.Trim() + "-" + txttel1.Text.Trim() + "-" + txttel2.Text.Trim(); 
        loanscontactstab.Moblie = txtcontactsphone.Text.Trim();
        loanscontactstab.Mail = txtcontactsemail.Text.Trim();
        loanscontactstab.Address = this.txtcontactsaddress.Text.Trim();
        int resultrow3 = loanscontacttabbll.UpdateloanscontactsTab(loanscontactstab, loansInfoID);
        if (resultrow3 != 0 && reulstrow1!=0&&resultrow2!=0)
        {
            if (loansInfotab.AuditID == 1)
            {
                Tz888.BLL.Loans.PageStatic stat = new Tz888.BLL.Loans.PageStatic();
                stat.StaticHtml(loansInfoID);
                BindShow();
               
            }
 
        }
        else { this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核失败！');", true);}
        this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核成功！');location.href='LoansInfoCRM.aspx'", true);

    }

}
