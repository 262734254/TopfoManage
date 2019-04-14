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
using Tz888.BLL.Company;
using Tz888.Model.Company;
using Tz888.BLL.Common;

public partial class Company_CompanyAdd : System.Web.UI.Page
{
    CompanyBLL combll = new CompanyBLL();
    CompanyModel model = new CompanyModel();
    ZoneSelectBLL zone = new ZoneSelectBLL();
    int comId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetProvice();
            comId = Convert.ToInt32(Request["CompanyId"]);
            ViewState["ComId"] = comId;
            Company(comId);
        }
    }

    protected void onChang_Provice(object sender, EventArgs e)
    {
        string ProviceID = this.DropProvice.SelectedItem.Value.ToString().Trim();
        SetCity(ProviceID);
    }

    public void SetProvice()
    {
        this.DropProvice.DataSource = zone.GetProvice();
        this.DropProvice.DataTextField = "ProvinceName";
        this.DropProvice.DataValueField = "ProvinceID";
        this.DropProvice.DataBind();
      
    }

    public void SetCity(string ProviceID)
    {
        if (zone.GetCity(ProviceID) != null)
        {
            this.DropCity.DataSource = zone.GetCity(ProviceID);
            this.DropCity.DataTextField = "CityName";
            this.DropCity.DataValueField = "CityID";
            this.DropCity.DataBind();
        }
    }

    #region 根据编号查找所对应的信息


    public void Company(int id)
    {
        model = combll.SelCompany(id);

        if (model.Sheng != 0)
        {

            DropProvice.SelectedValue = model.Sheng.ToString() + "      ";
        }
        if (model.City != 0)
        {
            SetCity(model.Sheng.ToString());
            DropCity.SelectedValue = model.City.ToString() + "      ";
        }

        ViewState["CompanyId"] = model.CompanyID.ToString();
        ViewState["FromId"] = model.FromId.ToString();
        txtCompanyName.Value = model.CompanyName.ToString().Trim();//企业名称
        ddlRangeID.SelectedValue = model.RangeID.ToString().Trim();//所属区域
        ddlIndustryID.SelectedValue = model.IndustryID.ToString().Trim();//所属行业
        txtEmployees.Value = model.Employees.ToString().Trim();//员工人数
        rblNatureID.SelectedValue = model.NatureID.ToString().Trim();//企业性质
        txtEstablishMent.Value = model.EstablishMent.ToString().Trim();//成立年限
        txtCapital.Value = model.Capital.ToString().Trim();//注册资金

         this.txtTitle.Value=model.Title.ToString().Trim();
         this.txtDescription.Value = model.Description.ToString().Trim();
         this.txtKeywords.Value= model.Keywords.ToString().Trim();
        //图片
        if (model.Logo == "")
        {
            Image1.ImageUrl = "http://www.topfo.com/dservice/image/photo.jpg";
            
        }
        else
        {
            Image1.ImageUrl = model.Logo;
        }
        ViewState["LoginName"] = model.LoginName.ToString().Trim();
        ViewState["image"] = model.Logo;
        txtServiceProce.Value = model.ServiceProce.ToString().Trim();//主营介绍
        txtIntroduction.Value = model.Introduction.ToString().Trim();//企业介绍
        txtLinkName.Value = model.LinkName.ToString().Trim();//联系人
        //电话号码
        if (model.Telphone != "")
        {
            string[] phone = model.Telphone.Split('-');
            txtTelCountry.Value = phone[0];
            txtTelZoneCode.Value = phone[1];
            txtTelNumber.Value = phone[2];
        }
        else
        {
            txtTelCountry.Value ="+86";
            txtTelZoneCode.Value = "";
            txtTelNumber.Value ="";
        }
        txtMoblie.Value = model.Mobile.ToString().Trim();//手机号码
        txtEmail.Value = model.Email.ToString().Trim();//电子邮箱
        txtAddress.Value = model.Address.ToString().Trim();//地址
        txtURL.Value = model.URL.ToString().Trim();//单位网址
        rblAuditing.SelectedValue = model.Auditingstatus.ToString().Trim();
        if (model.Auditingstatus == 1)
        {
            spanmake.Style["display"] = "block";
        }
        else
        {
            spanmake.Style["display"] = "none";
        }
        ViewState["CreateDate"] = model.CreateDate.ToString().Trim();
        ViewState["Hit"] = model.Hit.ToString().Trim();
        ViewState["Integrity"] = model.Integrity.ToString().Trim();
        rblIsmake.SelectedValue = model.Ismake.ToString().Trim();
    }
    #endregion

    #region  审核
    protected void btnStatus_Click(object sender, EventArgs e)
    {
        CompanyStateManage comState = new CompanyStateManage();
        #region 企业详细信息
        string FromID=ViewState["FromId"].ToString();
        model.LoginName = ViewState["LoginName"].ToString();//用户帐号
        model.CompanyName = this.txtCompanyName.Value.Trim();//企业名称
        model.RangeID =Convert.ToInt32(this.ddlRangeID.SelectedValue.Trim());//区域编号
        model.RangeName = this.ddlRangeID.SelectedItem.Text.Trim();//区域名称
        model.IndustryID = Convert.ToInt32(this.ddlIndustryID.SelectedValue.Trim());//行业编号
        model.IndustryName = this.ddlIndustryID.SelectedItem.Text.Trim();//行业名称
        model.Employees =Convert.ToInt64(this.txtEmployees.Value);//员工人数
        model.NatureID =Convert.ToInt32(this.rblNatureID.SelectedValue.Trim());//企业性质编号
        model.NatureName = this.rblNatureID.SelectedItem.Text.Trim();//企业性质名称
        model.EstablishMent = this.txtEstablishMent.Value.Trim();//成立日期
        model.Capital =Convert.ToInt64(this.txtCapital.Value.Trim());//注册资金
        model.Sheng = Convert.ToInt32(this.DropProvice.SelectedItem.Value);
        model.City = Convert.ToInt32(this.DropCity.SelectedItem.Value);

        if (Convert.ToString(ViewState["strSavePath"]) == "")
        {
            if (Convert.ToString(ViewState["image"]) == "")
            {
                model.Logo = "http://www.topfo.com/dservice/image/photo.jpg";
            }
            else
            {
                model.Logo = Convert.ToString(ViewState["image"]);//图片
            }
        }
        else
        {
            model.Logo =Convert.ToString(ViewState["strSavePath"]);//图片
        }
        model.ServiceProce = this.txtServiceProce.Value.Trim();//经营范围
        model.Introduction = this.txtIntroduction.Value.Trim();//公司简介

        model.CreateDate = Convert.ToDateTime(ViewState["CreateDate"]);//创建日期
        model.Hit = Convert.ToInt32(ViewState["Hit"]);//点击率
        model.Integrity =Convert.ToInt32(ViewState["Integrity"]);//诚信指度
        model.Title = this.txtTitle.Value.Trim();//网页标题
        model.Keywords = this.txtKeywords.Value.Trim();//网页关键字
        model.Description =this.txtDescription.Value.Trim();//网页短标题
        model.Auditingstatus =Convert.ToInt32(this.rblAuditing.SelectedValue.Trim());//审核 0：未审核，1：审核通过，2：审核未通过，3：已过期
        if (model.Auditingstatus == 1)
        {
            if (FromID == "1")
            {
                model.Htmlfile = "card/company/" + FromID + ".html";//静态模版页面
            }
            else
            {
                model.Htmlfile = "card/" + ViewState["LoginName"] + "/index.html";//静态模版页面
            }
        }
        else
        {
            model.Htmlfile = "";
        }
        model.Ismake = Convert.ToInt32(this.rblIsmake.SelectedValue.Trim());//推荐
        model.IsDelete = 0;//不删除
        #endregion

        #region 联系人信息
        model.LinkName = this.txtLinkName.Value.Trim();//联系人名称
        model.Telphone = this.txtTelCountry.Value.Trim() +"-"+ this.txtTelZoneCode.Value.Trim() +"-"+ this.txtTelNumber.Value.Trim();//电话号码
        model.Mobile = this.txtMoblie.Value.Trim();//手机号码
        model.Email = this.txtEmail.Value.Trim();//电子邮箱
        model.Address = this.txtAddress.Value.Trim();//详细地址
        model.URL = this.txtURL.Value.Trim();//单位网址
        #endregion

        if (model.Auditingstatus == 1)
        {
            spanmake.Style["display"] = "block";
        }
        else
        {
            spanmake.Style["display"] = "none";
        }

        int num = combll.Company_Update(model, Convert.ToInt32(ViewState["ComId"]));
        if (num >= 0)
        {
            comState.ComPanyHtml(Convert.ToString(ViewState["ComId"]), ViewState["LoginName"].ToString(), model.CompanyName,
                model.IndustryName, model.RangeName, model.NatureName, model.Htmlfile, model.EstablishMent,Convert.ToString(model.Employees),Convert.ToString(model.Capital),
                model.Introduction, model.ServiceProce, model.Title, model.Keywords, model.Description, model.Logo, FromID);
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "审核成功！","SelCompany.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "审核失败！");
        }
    }
    #endregion

    //图片上传
    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath + "upload\\card\\";
            picTitle = UploadFile(uploadPic, path, 500, "default");
            switch (picTitle)
            {
                case "1": Response.Write("<script>alert('图片类型不对');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                case "2": Response.Write("<script>alert('图片大小超出500K');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                case "3": Response.Write("<script>alert('请选择上传图片');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                default:
                    ViewState["strSavePath"] = "http://crm.topfo.com/upload/card/" + picTitle;
                    this.LblMessage.Text = "上传图片成功";
                    Image1.ImageUrl =Convert.ToString(ViewState["strSavePath"]);
                   // Image1.ImageUrl = @"F:\12111.gif";
                    break;
            }
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "请上传图片！");
        }
    }
    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="postedFile">上传文件控件</param>
    /// <param name="path">存入的物理路径,留空则为根目录下 UploadFile 目录</param>
    /// <param name="size">文件大小,0为不限制</param>
    /// <param name="filetype">可上传的文件类型，格式：".gif|.jpg|.png",留空为不限制,"default"即默认".gif|.jpg|.bmp"类型</param>
    /// <returns>上传后文件的名称 返回1:文件类型不对 返回2:大小超出限制</returns>
    public string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, string path, int size, string filetype)
    {
        try
        {
            // string strSaveName = string.Empty;
            //   string strtype = System.IO.Path.GetFileName(postedFile.PostedFile.FileName);//扩展名
            string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名

            string strSaveName = System.DateTime.Now.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + strtype;//上传后的文件名称
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string strSavePath = path + strSaveName;//为文件获取保存路径
            //  ViewState["strSavePath"] = strSaveName;
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
