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
using System.Text;
using GZS.BLL.Link;
using GZS.Model.Link;
public partial class admin_AddLink : System.Web.UI.Page
{
    TZLinkM tzLink = new TZLinkM();
    TZLinkBLL tzbll = new TZLinkBLL();
    private string loginName = "";
    string path = ConfigurationManager.AppSettings["UpProductImage"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            ViewState["strSavePath"] = "";
            if (!string.IsNullOrEmpty(Request.QueryString["loginName"].ToString()))
            {
                loginName = Request.QueryString["loginName"].ToString();
                if (tzbll.ExistsName(loginName))
                {
                    btnUpdate.Visible = true;
                    Button1.Visible = false;
                    bindModel(loginName);
                    ViewState["loginName"] = loginName;
                }
                else
                {
                    Button1.Visible = true;
                }
            }
        }
    }
    private void bindModel(string loginName)
    {
        tzLink = tzbll.GetModelByLoginName(loginName);
        policyId.Value = tzLink.linkId.ToString();
        txtAddress.Text = tzLink.Address;
        txtLinkMan.Text = tzLink.Name;
        txtEmail.Text = tzLink.Email;
        txtOther.Text = tzLink.OtherMode;
        txtPhone.Text = tzLink.Phone;
        string tel = tzLink.Tel;
        if (!string.IsNullOrEmpty(tzLink.ImageMap))
        {
            Image1.ImageUrl = "http://dp.topfo.com/img/" + loginName + "/" + tzLink.ImageMap;
            //Image1.ImageUrl = path + loginName + "/" + tzLink.ImageMap;////本地
            ViewState["strSavePath"] = tzLink.ImageMap;
            imageDis.Attributes.Add("style", "display:''");
        }
        string[] telLen = tel.Split(new char[] { ',' });
        if (telLen.Length == 1)
        {
            txtTel.Text = tzLink.Tel;
        }
        else
        {
            txtcontactsTel.Text = telLen[0].ToString();
            txtTel.Text = telLen[1].ToString();
            txttel2.Text = telLen[2].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        tzLink.Address = txtAddress.Text.Trim();
        tzLink.Name = txtLinkMan.Text.Trim();
        tzLink.Email = txtEmail.Text.Trim();
        tzLink.OtherMode = txtOther.Text.Trim();
        tzLink.Phone = txtPhone.Text.Trim();
        tzLink.LoginName = loginName;
        string tel = string.Empty;
        if (!string.IsNullOrEmpty(tzLink.ImageMap))
        {
            if (!string.IsNullOrEmpty(ViewState["strSavePath"].ToString()))
            {
                tzLink.ImageMap = ViewState["strSavePath"].ToString();
            }
        }
        else
        {
            tzLink.ImageMap = ViewState["strSavePath"].ToString();
        }
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
        tzLink.Tel = tel;
        int num = tzbll.Add(tzLink);
        if (num > 0)
        {
            policyId.Value = num.ToString();
            Button1.Visible = false;
            btnUpdate.Visible = true;
            ContactStatic sta = new ContactStatic();
            if (sta.StaticHtml(loginName) > 0)
            {

            }
            Response.Write("<script>alert('添加成功');</script>");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        tzLink.linkId = int.Parse(policyId.Value.ToString());
        tzLink.Address = txtAddress.Text.Trim();
        tzLink.Name = txtLinkMan.Text.Trim();
        tzLink.Email = txtEmail.Text.Trim();
        tzLink.OtherMode = txtOther.Text.Trim();
        tzLink.Phone = txtPhone.Text.Trim();
        string tel = string.Empty;
        if (!string.IsNullOrEmpty(tzLink.ImageMap))
        {
            if (!string.IsNullOrEmpty(ViewState["strSavePath"].ToString()))
            {
                tzLink.ImageMap = ViewState["strSavePath"].ToString();
            }
        }
        else
        {
            tzLink.ImageMap = ViewState["strSavePath"].ToString();
        }
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
        tzLink.Tel = tel;
        if (tzbll.Update(tzLink))
        {
            Button1.Visible = false;
            btnUpdate.Visible = true;
            ContactStatic sta = new ContactStatic();
            if (sta.StaticHtml(ViewState["loginName"].ToString()) > 0)
            {

            }
            Response.Write("<script>alert('修改成功');location.href='LinkManage.aspx'</script>");
        }
    }
    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            picTitle = UploadFile(uploadPic, 500, "default");
            switch (picTitle)
            {
                case "1":
                    Response.Write("<script>alert('图片类型不对！');</script>");
                    break;
                case "2":
                    Response.Write("<script>alert('图片大小超出500K！');</script>");
                    break;
                default:
                    imageDis.Attributes.Add("style", "display:''");
                    //Image1.ImageUrl = path + loginName + "/" + ViewState["strSavePath"].ToString();

                    Image1.ImageUrl = "http://dp.topfo.com/img/" + loginName + "/" + ViewState["strSavePath"].ToString();

                    this.LblMessage2.Text = "上传图片成功！未能显示请刷新页面"; break;
            }
        }
        else
        {
            Response.Write("<script>alert('请选择上传的图片！');</script>");
        }
    }
    public string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, int size, string filetype)
    {
        try
        {
            string strSaveName = string.Empty;
            string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名
            DateTime Now = DateTime.Now;
            if (string.IsNullOrEmpty(ViewState["strSavePath"].ToString()))
            {
                strSaveName = Now.Year.ToString() + Now.Month.ToString() + Now.Day.ToString() +
                Now.Hour.ToString() + Now.Minute.ToString() + Now.Second.ToString() + strtype;
            }
            else
            {
                strSaveName = ViewState["strSavePath"].ToString();
            }
            if (!Directory.Exists(path + "//" + loginName))
            {
                Directory.CreateDirectory(path + "//" + loginName);
            }
            string strSavePath = path + loginName + "/" + strSaveName;//为文件获取保存路径
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
