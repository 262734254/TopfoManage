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
using Tz888.BLL.Company;
using Tz888.Model.Company;
using Tz888.BLL.Common;
using System.Text;

public partial class Company_CompanyInsert : System.Web.UI.Page
{
    CompanyBLL combll = new CompanyBLL();
    CompanyModel model = new CompanyModel();
    ZoneSelectBLL zone = new ZoneSelectBLL();
    BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Type"] != null)
        {
            string Type = Request["Type"];
            if (Type == "Province")
            {
                LoadProvince();
            }
            else if (Type == "City" && Request["ProvinceID"] != null)
            {
                string ProvinceID = Request["ProvinceID"];
                GetCity(ProvinceID);
            }
        }
    }

    /// <summary>
    /// 省份列表
    /// </summary>
    /// <returns></returns>
    public void LoadProvince()
    {
        StringBuilder sb = new StringBuilder();
        DataTable dt = zone.GetProvice();
        if (dt.Rows.Count > 0)
        {
            sb.Append("{\"province\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("{");
                sb.Append("\"ProvinceID\":");
                sb.Append("\"" + dt.Rows[i]["ProvinceID"] + "\",");
                sb.Append("\"ProvinceName\":");
                sb.Append("\"" + dt.Rows[i]["ProvinceName"] + "\"");
                sb.Append("},");
            }
            sb.Remove(sb.ToString().Length - 1, 1);
            sb.Append("]}");
        }
        Response.Write(sb.ToString());
        Response.End();
    }

    /// <summary>
    /// 根据省份ID获取市区
    /// </summary>
    /// <param name="ProvinceId">省份ID</param>
    /// <returns></returns>
    public void GetCity(string ProvinceId)
    {
        StringBuilder sb = new StringBuilder();
        DataTable dt = zone.GetCity(ProvinceId);
        if (dt.Rows.Count > 0)
        {
            sb.Append("{\"city\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("{");
                sb.Append("\"CityID\":");
                sb.Append("\"" + dt.Rows[i]["CityID"] + "\",");
                sb.Append("\"CityName\":");
                sb.Append("\"" + dt.Rows[i]["CityName"] + "\"");
                sb.Append("},");
            }
            sb.Remove(sb.ToString().Length - 1, 1);
            sb.Append("]}");
        }
        Response.Write(sb.ToString());
        Response.End();
    }

    //图片上传
    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        if (this.uploadPic.HasFile)
        {
            try
            {
                imgBiz.Service serBiz = new imgBiz.Service(); //webservice

                string loginName = DateTime.Now.ToString("yyyy"); //bp.LoginName;
                HttpPostedFile mFile = uploadPic.PostedFile;
                string imgName = string.Empty;
                int fileSize = mFile.ContentLength;
                byte[] mFileByte = new Byte[fileSize];
                mFile.InputStream.Read(mFileByte, 0, fileSize);
                //检测控制图片类型   
                string fileExt = (System.IO.Path.GetExtension(mFile.FileName)).ToString().ToLower();
                DateTime Now = DateTime.Now;
                string fileMain = Now.Year.ToString() + Now.Month.ToString() + Now.Day.ToString() +
                    Now.Hour.ToString() + Now.Minute.ToString() + Now.Second.ToString();
                if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png" || fileExt == ".bmp")
                {
                    imgName = fileMain + fileExt;
                    if (serBiz.UpCrmImage(imgName, mFileByte, loginName) > 0)
                    {
                        //http://image.topfo.com/carimg/2011/2011630134033.jpg
                        ViewState["Log"] = "http://image.topfo.com/carimg/" + loginName + "/" + imgName;
                        this.LblMessage.Text = "上传图片成功";
                    }
                }
                else
                {
                    Response.Write("<script>alert('图片类型不对');</script>"); Response.End();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('error');</script>"); Response.End();
            }
        }
    }

    //添加企业名片
    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        model.LoginName = bp.LoginName;
        model.CompanyName = txtCompanyName.Value.Trim();//企业名称
        model.RangeID = Convert.ToInt32(Range.SelectedValue.Trim());//区域
        model.RangeName = Range.SelectedItem.Text.Trim();
        model.IndustryID = Convert.ToInt32(Industry.SelectedValue.Trim());//行业
        model.IndustryName = Industry.SelectedItem.Text.Trim();
        model.Employees = long.Parse(txtEmployees.Value.Trim());//员工人数
        model.NatureID = int.Parse(Nature.SelectedValue.Trim());//企业性质
        model.NatureName = Nature.SelectedItem.Text.Trim();
        model.EstablishMent = txtEstablishMent.Value.Trim();//成立时间
        model.Capital = Convert.ToInt32(txtCapital.Value.Trim());//注册资金
        model.ServiceProce = txtServiceProce.Value.Trim();//主营介绍
        model.Introduction = txtIntroduction.Value.Trim();//企业介绍
        model.LinkName = txtLinkName.Value.Trim();//联系人
        model.Telphone = txtTelCountry.Value.Trim() + "-" + txtTelZoneCode.Value.Trim() + "-" + txtTelNumber.Value.Trim();//联系电话
        model.Mobile = txtMoblie.Value.Trim();//手机号码
        model.Email = txtEmail.Value.Trim();//邮箱
        model.Address = txtAddress.Value.Trim();//详细地址 
        model.CreateDate = DateTime.Now;//创建时间
        model.Auditingstatus = 0;//是否审核    
        model.Htmlfile = "";//静态文件路径
        model.Ismake = 0;//是否推广
        model.IsDelete = 0;//是否删除
        model.Keywords = "";//关键字
        model.Title = "";//网页标题
        model.Hit = 0;//点击率
        model.Integrity = 0;//诚信制度
        model.Description = "";//网页短标题
        model.Sheng = (string.IsNullOrEmpty(txtProvince.Value)) ? 0 : Convert.ToInt32(txtProvince.Value);
        model.FromId = 1;//来源
        model.URL = txtURL.Value.Trim();//网站地址
        model.City = (string.IsNullOrEmpty(txtCity.Value)) ? 0 : Convert.ToInt32(txtCity.Value);
        model.Logo = (ViewState["Log"] == null) ? "" : ViewState["Log"].ToString();//图片
        int row = combll.InsertCompany(model);
        if (row > 0)
        {
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功!", "SelCompany.aspx", false);
        }
    }
}
