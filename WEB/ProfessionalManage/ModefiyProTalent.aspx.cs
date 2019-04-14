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
using System.IO;
using Tz888.BLL.ProfessionalManage;
using Tz888.Model.ProfessionalManage;
using Tz888.Common;
using Tz888.BLL;
public partial class ProfessionalManage_ModefiyProTalent : System.Web.UI.Page
{
    ProfessionalTypeBLL bll = new ProfessionalTypeBLL();
    ProfessionaltalentsBLL plBll = new ProfessionaltalentsBLL();
    ProfessionalinfoBLL infoBll = new ProfessionalinfoBLL();
    ProfessionalLinkBLL linkBll = new ProfessionalLinkBLL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            databind();
            ViewState["strSavePath"] = "";
            ViewState["flag"] = "";
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

        //人才类别

        ProfessionalTalentsType orgBll = new ProfessionalTalentsType();
        this.DropIndustry.DataSource = orgBll.GetList("");
        this.DropIndustry.DataTextField = "TypeName";
        this.DropIndustry.DataValueField = "typeID";
        this.DropIndustry.DataBind();
    }
    protected void databindList(int ProfessionalID)
    {

        Professionaltalents plModel = plBll.GetModel(ProfessionalID);
        ProfessionalLink linkModel = linkBll.GetModel(ProfessionalID);
        ProfessionalinfoTab inModel = infoBll.GetModel(ProfessionalID);
        txtTitle.Text = inModel.Titel.ToString();
        txtPrice.Text = inModel.price.ToString();
        if (!string.IsNullOrEmpty(plModel.Images))
        {
            if (plModel.Images.Equals("/dservice/image/photo.jpg"))
            {
                ViewState["flag"] = "true"; //默认图片
            }
            else
            {
                ViewState["strSavePath"] = plModel.Images;
            }
            Image1.ImageUrl = "http://www.topfo.com" + plModel.Images;

            //Image1.ImageUrl = "F:/Topfo" + plModel.Images;////本地
            imageDis.Attributes.Add("style", "display:''");
        }
        else
        {
            //DateTime Now = DateTime.Now;
            ViewState["strSavePath"] = "/dservice/image/photo.jpg";
            //ViewState["strSavePath"] = "/dservice/image/" + Now.Year.ToString() + "/" + Now.Year.ToString() + Now.Month.ToString() + Now.Day.ToString() +
            //   Now.Hour.ToString() + Now.Minute.ToString() + Now.Second.ToString() + ".jpg";
            imageDis.Attributes.Add("style", "display:none");
        }

        this.ZoneSelectControl1.CountryID = plModel.CountryCode;
        this.ZoneSelectControl1.ProvinceID = plModel.ProvinceID;
        this.ZoneSelectControl1.CityID = plModel.CityID;
        this.ZoneSelectControl1.CountyID = plModel.CountyID;
        txtRegistYear.Text = plModel.companydate.ToString("yyyy-MM-dd");
        txtPosition.Value = plModel.position;//职务
        DropIndustry.SelectedValue = plModel.talentsTypeID.ToString(); //人才类别
        txtRegistYear.Text = plModel.companydate.ToString("yyyy-MM-dd");
        txtresume.Text = plModel.resume;//个人简历
        txtspecialty.Text = plModel.specialty;//个人特长
        txtSuccess.Text = plModel.ScuccCase;//成功案例
        ddlServiceType.SelectedValue = plModel.servicetypeID.ToString();//服务类型
        rdlValiditeTerm.SelectedValue = plModel.validityID.ToString();//有效期
        txtAddress.Text = linkModel.Address;
        txtLinkMan.Text = linkModel.UserName;
        txtPhone.Text = linkModel.phone;
        txtCompany.Text = linkModel.CompanyName;
        txtClick.Text = inModel.clickId.ToString();
        txtEmail.Text = linkModel.Email;
        txtFax.Text = linkModel.Fax;
        tbAuditingRemark.Text = inModel.FeedBackNote;
        string tel = linkModel.Tel;
        string[] telLen = tel.Split(new char[] { ',' });
        if (telLen.Length==1)
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
        txtWebDesr.Text = plModel.Webdescription;
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
        Professionaltalents viewInfo = new Professionaltalents();

        ProfessionalLink personInfo = new ProfessionalLink();
        if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
        {
            int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
            MainInfo.ProfessionalID = ProfessionalID;
            viewInfo = plBll.GetModel(ProfessionalID);
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

        if (!string.IsNullOrEmpty(viewInfo.Images))
        {
            if (!string.IsNullOrEmpty(ViewState["strSavePath"].ToString()))
            {
                viewInfo.Images = ViewState["strSavePath"].ToString();
            }
        }
        else
        {
            viewInfo.Images = ViewState["strSavePath"].ToString();
        }
        MainInfo.typeID = 3;
        MainInfo.FeedBackNote = tbAuditingRemark.Text.Trim();
        MainInfo.htmlUrl = "dservice/" + DateTime.Now.ToString("yyyyMM") + "/dservice" + DateTime.Now.ToString("yyyyMMdd") + "_" + Request.QueryString["ProfessionalID"].ToString() + ".shtml";
        viewInfo.CountryCode = this.ZoneSelectControl1.CountryID;
        viewInfo.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        viewInfo.CityID = this.ZoneSelectControl1.CityID;
        viewInfo.CountyID = this.ZoneSelectControl1.CountyID;
        viewInfo.companydate = Convert.ToDateTime(txtRegistYear.Text.Trim().ToString());

        viewInfo.position = txtPosition.Value.Trim();
        viewInfo.servicetypeID = int.Parse(ddlServiceType.SelectedValue.ToString());//服务类型
        viewInfo.talentsTypeID = int.Parse(DropIndustry.SelectedValue.ToString()); //人才类别
        viewInfo.resume = txtresume.Text;//个人简历
        viewInfo.specialty = txtspecialty.Text;//个人特长
        viewInfo.ScuccCase = txtSuccess.Text;//成功案例

        viewInfo.title = txtWtitle.Text.Trim();
        viewInfo.keywords = txtKeyword1.Text.Trim();
        viewInfo.Webdescription = txtWebDesr.Text.Trim();
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
                PageStaticTalents stat = new PageStaticTalents();
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
    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            bool flag = false;
            DateTime Now = DateTime.Now;
            //string path = "F:/Topfo/dservice/image/" + Now.Year.ToString() + "/";
            string path = "J:/topfo/tzWeb/dservice/image/" + Now.Year.ToString() + "/";
            if (ViewState["flag"].Equals("true"))
            {
                flag = check(uploadPic, 500, "default");
            }
            picTitle = UploadFile(uploadPic, path, 500, "default", flag);
            switch (picTitle)
            {
                case "1":
                    Tz888.Common.MessageBox.Show(this.Page, "图片类型不对！");
                    break;
                case "2":
                    Tz888.Common.MessageBox.Show(this.Page, "图片大小超出500K！");
                    break;
                default:
                    imageDis.Attributes.Add("style", "display:''");
                    string[] strImage = ViewState["strSavePath"].ToString().Split(new char[] { '/' });
                    //Image1.ImageUrl = path + strImage[strImage.Length - 1];

                    Image1.ImageUrl = "http://www.topfo.com" + ViewState["strSavePath"].ToString();

                    this.LblMessage2.Text = "上传图片成功！未能显示请刷新页面"; break;
            }
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择上传的图片！");
        }
    }
    protected bool check(System.Web.UI.WebControls.FileUpload postedFile, int size, string filetype)
    {
        bool a = false;
        int fileSize = postedFile.PostedFile.ContentLength / 1024;
        string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名
        //是否限制文件类型
        if (filetype.Length > 0)
        {
            if (filetype.ToLower().Equals("default"))
            {
                if (strtype.ToLower() != ".jpg" && strtype.ToLower() != ".bmp" && strtype.ToLower() != ".gif")
                {
                    a = false;
                }
                else
                {
                    a = true;
                }
            }
        }
        //是否限制大小
        if (size > 0)
        {
            if (fileSize <= size)
            {
                a = true;
            }
        }
        return a;
    }
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="postedFile">上传文件控件</param>
    /// <param name="path">存入的物理路径,留空则为根目录下 UploadFile 目录</param>
    /// <param name="size">文件大小,0为不限制</param>
    /// <param name="filetype">可上传的文件类型，格式：".gif|.jpg|.png",留空为不限制,"default"即默认".gif|.jpg|.bmp"类型</param>
    /// <returns>上传后文件的名称 返回1:文件类型不对 返回2:大小超出限制</returns>
    public string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, string path, int size, string filetype, bool isNo)
    {
        try
        {
            string strSaveName = string.Empty;
            string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名
            DateTime Now = DateTime.Now;
            if (isNo)//默认图片
            {
                strSaveName = "/dservice/image/" + Now.Year.ToString() + "/" + Now.Year.ToString() + Now.Month.ToString() + Now.Day.ToString() +
                Now.Hour.ToString() + Now.Minute.ToString() + Now.Second.ToString() + strtype;
            }
            else
            {
                strSaveName = ViewState["strSavePath"].ToString();
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string[] strImage = strSaveName.Split(new char[] { '/' });
            string strSavePath = path + strImage[strImage.Length - 1];//为文件获取保存路径
            ViewState["strSavePath"] = strSaveName;
            int fileSize = postedFile.PostedFile.ContentLength / 1024;
            //是否限制文件类型
            if (filetype.Length > 0)
            {
                if (filetype.ToLower().Equals("default"))
                {
                    if (strtype.ToLower() != ".jpg" && strtype.ToLower() != ".bmp" && strtype.ToLower() != ".gif")
                        return "1";
                }
            }
            //是否限制大小
            if (size > 0)
            {
                if (fileSize <= size)
                {
                    postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
                    return strSaveName;
                }
                else
                {
                    //上传的文件大小超出
                    return "2";
                }
            }
            else
            {
                postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
                return strSaveName;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}
