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
using System.IO;
using Tz888.BLL.Company;
using GZS.BLL.XHIndex;
using GZS.Model.Person;

public partial class Company_CompanyShowAdd : System.Web.UI.Page
{
    Tz888.BLL.Company.KeyWordsBll KeyBll = new Tz888.BLL.Company.KeyWordsBll();
    Tz888.Model.Company.KeyWords KeyModel = new Tz888.Model.Company.KeyWords();

    Tz888.BLL.Company.CompanyShowBLL ComShow = new Tz888.BLL.Company.CompanyShowBLL();
    Tz888.Model.Company.CompanyShow model = new Tz888.Model.Company.CompanyShow();
    Tz888.BLL.Company.CompanyStateBLL comState = new Tz888.BLL.Company.CompanyStateBLL();
    string ComShowPath = ConfigurationManager.AppSettings["CompanyShowPath"].ToString();//企业展厅静态页面存放路径
    string InvestCost = ConfigurationManager.AppSettings["InvestCost"].ToString(); //投资IFs
    string Induy = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int num = Convert.ToInt32(Request["CompanyId"]);
            ViewState["CompanyID"] = num;
            BindRole();
            SelCompanyShow(num);
        }
    }
    //邦定角色
    private void BindRole()
    {
        Tz888.BLL.dp.SysRoleTab bll = new Tz888.BLL.dp.SysRoleTab();
        DataSet ds = bll.GetList("");
        ddlRole.DataTextField = "srname";
        ddlRole.DataValueField = "sroleid";
        ddlRole.DataSource = ds;
        ddlRole.DataBind();
    }
    private void SelCompanyShow(int id)
    {
        model = ComShow.SelAllShow(id);
        //这里进行判断是因为以前都是默认为1
        if (model.RoleId == 1)
        {
            ddlRole.SelectedValue = "1";
        }
        else
        {
            ddlRole.SelectedValue = model.RoleId.ToString();
        }
        spanName.InnerHtml = model.UserName.Trim();//用户名
        spanType.InnerHtml = model.TypeName.Trim();//类型
        rbtValid.SelectedValue = Convert.ToString(model.Valid);//有效期
        string[] phone = model.TelPhone.Split('-');//电话号码
        txtTelCountry.Value = phone[0];//
        txtTelZoneCode.Value = phone[1];//
        txtTelNumber.Value = phone[2];//
        txtMobile.Value = model.Mobile.Trim();//手机号码
        txtEmail.Value = model.Email.Trim();//电子邮箱
        rblAuditing.SelectedValue = Convert.ToString(model.Audit);//审核状态

        ViewState["pwd"] = model.UserPwd;
        ViewState["time"] = model.StartTime;
        ViewState["hit"] = model.Hit;

        string CompanyName = model.CompanyName.ToString().Trim();
        if (KeyBll.Exists(model.RoleId, model.UserName.Trim()))
        {
           KeyModel= KeyBll.GetModel(model.RoleId, model.UserName.Trim());
           this.txtWtitle.Text = KeyModel.WebTitle.ToString().Trim();
           this.txtKeord.Text = KeyModel.WebKeyWord.ToString().Trim();
           this.txtDescript.Text = KeyModel.description.ToString().Trim();
           
        }
        else
        {
            Induy = model.Industry.ToString().Trim();
            string InduyList = ComShow.IndustryClassListSelect(Induy, model.RoleId);
            this.txtWtitle.Text = InduyList.ToString().Trim() + CompanyName + "-中国招商投资网";
            this.txtKeord.Text = InduyList.ToString().Trim() + CompanyName;
        }
    }
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        model = ComShow.SelAllShow(Convert.ToInt32(Request["CompanyId"]));
        model.UserName = spanName.InnerHtml;
        model.UserPwd = (byte[])ViewState["pwd"];
        model.TelPhone = txtTelCountry.Value.Trim() + "-" + txtTelZoneCode.Value.Trim() + "-" + txtTelNumber.Value.Trim();
        model.Mobile = txtMobile.Value.Trim();
        model.Email = txtEmail.Value.Trim();
        model.Audit = Convert.ToInt32(rblAuditing.SelectedValue.Trim());
        model.StartTime = Convert.ToDateTime(ViewState["time"]);
        model.Valid = Convert.ToInt32(rbtValid.SelectedValue.Trim());
        model.TypeName = spanType.InnerHtml;
        model.Hit = Convert.ToInt32(ViewState["hit"]);
        //if (model.TypeName.Equals("政府招商"))
        //{ 
        model.RoleId = Convert.ToInt32(ddlRole.SelectedValue.ToString());
        //}
        int com = ComShow.ModfiyShow(model, Convert.ToInt32(ViewState["CompanyID"]));
        if (com > 0)
        {
            KeyModel.description=this.txtDescript.Text.ToString().Trim();
            KeyModel.WebKeyWord=this.txtKeord.Text.ToString().Trim();
            KeyModel.WebTitle = this.txtWtitle.Text.ToString().Trim();
            KeyModel.UserName = model.UserName.ToString().Trim();
            KeyModel.RoseID = model.RoleId;
            if (KeyBll.Exists(model.RoleId, model.UserName.Trim()))
            {
                KeyBll.Update(KeyModel);
            }
            else
            {
                KeyBll.Add(KeyModel);
            }
            if (model.Audit == 1)
            {
                if (Convert.ToInt32(ddlRole.SelectedValue.ToString()) == 1)//招商拓富通
                {
                    comState.CompanyShowHtml(spanName.InnerHtml,txtWtitle.Text.ToString().Trim(), txtKeord.Text.ToString().Trim(), txtDescript.Text.ToString().Trim());
                    //every time look into mirror of mine  
                }
                if (Convert.ToInt32(ddlRole.SelectedValue.ToString()) == 3)//资源联盟
                {
                    //资源联盟
                    ResourceStatic sta = new ResourceStatic();
                    sta.StaticHtml(model.UserName,txtWtitle.Text.ToString().Trim(), txtKeord.Text.ToString().Trim(), txtDescript.Text.ToString().Trim());
                }
                if (Convert.ToInt32(ddlRole.SelectedValue.ToString()) == 4)
                {
                    GZS.BLL.ImageTabMBLL imagebll = new GZS.BLL.ImageTabMBLL();

                    rzstatic bll = new rzstatic();
                    bll.StaticHtml(model.UserName, txtWtitle.Text.ToString().Trim(), txtKeord.Text.ToString().Trim(), txtDescript.Text.ToString().Trim());

                    List<GZS.Model.ImageTabM> list = imagebll.GetAll(model.UserName);
                    for (int i = 0; i < list.Count; i++)
                    {

                        bll.StaticRZHtmlshouyeList(model.UserName, list[i].imageid);
                    }
                }


                if (Convert.ToInt32(ddlRole.SelectedValue.ToString()) ==5)
                {

                    tzstatic bll = new tzstatic();
                    bll.StaticHtml(model.UserName,txtWtitle.Text.ToString().Trim(),txtKeord.Text.ToString().Trim(),txtDescript.Text.ToString().Trim());

                 
                }
                //if (File.Exists(ComShowPath + spanName.InnerHtml + "/InvestCost.htm"))
                //{
                //    File.Delete(ComShowPath + spanName.InnerHtml + "/InvestCost.htm");

                //} File.Copy(InvestCost, ComShowPath + spanName.InnerHtml + "/InvestCost.htm");
                Tz888.BLL.dp.System sysb = new Tz888.BLL.dp.System();
                Tz888.Model.dp.System sysm = new Tz888.Model.dp.System();
                sysm.EmployeeID = model.UserName.Trim();
                sysm.Tem = ddlRole.SelectedValue.ToString().Trim();
                if (sysb.Exists(model.UserName.Trim()))
                {
                    //修改
                    sysb.Update(sysm);
                }
                else
                {
                    //添加
                    sysb.Add(sysm);
                }
            }
            else
            {
                comState.DelFile(spanName.InnerHtml);
                //comState.DelFile("liulixing");
            }
            Tz888.Common.MessageBox.ShowAndHref("审核成功", "SelCompanyShow.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "审核失败");
        }
    }
}
