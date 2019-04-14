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
using System.Collections.Generic;
using GZS.BLL;

public partial class admin_ImageUpdate : System.Web.UI.Page
{
    private string str
    {
        get
        {
            return ViewState["str"].ToString();
        }
        set
        {
            ViewState["str"] = value;
        }
    }
    private int sid
    {
        get
        {
            return Convert.ToInt32(ViewState["sid"]);
        }
        set
        {
            ViewState["sid"] = value;
        }
    }
    private string strddd
    {
        get
        {
            return ViewState["strddd"].ToString();
        }
        set
        {
            ViewState["strddd"] = value;
        }
    }
    private string loginname
    {
        get
        {
            return ViewState["loginname"].ToString();
        }
        set
        {
            ViewState["loginname"] = value;
        }
    }
    GZS.BLL.ImageUrlTabMBLL urlbll = new GZS.BLL.ImageUrlTabMBLL();
    GZS.BLL.ImageTabMBLL imagebll = new GZS.BLL.ImageTabMBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            loginname = Request.QueryString["LoginName"].ToString();
            sid = Convert.ToInt32(Request.QueryString["ImageID"].Trim());

            ViewState["strSavePath"] = "";
            str = "";
            strddd = ConfigurationManager.AppSettings["Upimagecn001"].ToString() + loginname + "/";
            BindShow();
        }
    }
    public string GetType(string descs)
    {
        string par = "";

        par = "http://dp.topfo.com/img/" + loginname + "/" + descs;


        return par;
    }

    protected void btnUpdatefile_Click(object sender, EventArgs e)
    {

        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            string path = ConfigurationManager.AppSettings["Upimagecn001"].ToString() + loginname + "/";
            picTitle = UploadFile(uploadPic, path, 500, "default");
            switch (picTitle)
            {
                case "1":
                    Response.Write("<script>alert('图片类型不对！');</script>");
                    break;
                case "2":
                    Response.Write("<script>alert('图片大小超出500K！');</script>");
                    break;
                default:
                    string urladdress = imagebll.GetModel(sid).Htmlurl.Trim();
                    string htmlurl = "";
                    if (urladdress == "NULL" || urladdress == "")
                    {
                        htmlurl = DateTime.Now.ToString("yyyyMMdd") + "" + sid + "htm";

                    }
                    else
                    {
                        htmlurl = urladdress;
                    }
                    GZS.Model.ImageTabM imagemodel = imagebll.GetModel(sid);
                    GZS.Model.ImageTabM imagemodels = new GZS.Model.ImageTabM();
                    imagemodels.imageid = imagemodel.imageid;
                    imagemodels.LoginName = imagemodel.LoginName;
                    imagemodels.imageName = imagemodel.imageName;
                    imagemodels.remark = imagemodel.remark;
                    imagemodels.Createdatetime = imagemodel.Createdatetime;
                    imagemodels.Updatetime1 = imagemodel.Updatetime1;
                    imagemodels.Htmlurl = htmlurl;
                    imagemodels.Htmlurllist = imagemodel.Htmlurllist;
                    int resd = imagebll.UpdateImageTab(imagemodels);

                    GZS.Model.ImageUrlTabM imageurlmodel = new GZS.Model.ImageUrlTabM();
                    imageurlmodel.Imageid = sid;
                    imageurlmodel.Imagepath = picTitle.Trim();
                    imageurlmodel.imgexplain = txtShuoming.Text.Trim();
                    int result = urlbll.Add(imageurlmodel);
                    txtShuoming.Text = "";

                    BindShow();
                    break;



            }
        }
        else
        {
            Response.Write("<script>alert('请选择上传的图片！');</script>");
        }
    }
    private void BindShow()
    {
        List<GZS.Model.ImageUrlTabM> list = urlbll.GetAllByImageId(sid);
        this.DataList1.DataSource = list;
        this.DataList1.DataBind();
        if (list.Count > 0)
        {
            ed.Attributes.Add("style", "display:block");
        }
        else { ed.Attributes.Add("style", "display:none"); }
        GZS.Model.ImageTabM d = imagebll.GetModel(sid);
        this.txtImageName.Text = d.imageName.Trim();
        this.txtImageShuo.Text = d.remark.Trim();
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
            string strSaveName = string.Empty;
            string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名
            strSaveName = System.DateTime.Now.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + strtype;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string strSavePath = path + strSaveName;//为文件获取保存路径
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
    //删除图片
    protected void btnsave_Click(object sender, EventArgs e)
    {

        foreach (DataListItem item in DataList1.Items)
        {
            CheckBox ck = (CheckBox)item.FindControl("chckimage");
            HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
            HiddenField fidid = (HiddenField)item.FindControl("HiddenField2");
            if (ck.Checked == true)
            {
                int resut = urlbll.Delete(Convert.ToInt32(fidid.Value));
                string destinationFile = strddd + fid.Value.Trim();

                if (File.Exists(destinationFile))
                {

                    FileInfo fi = new FileInfo(destinationFile);

                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)

                        fi.Attributes = FileAttributes.Normal;

                    File.Delete(destinationFile);

                }
            }

        }
        BindShow();
    }
    protected void btnsa_Click(object sender, EventArgs e)
    {
        string urladdress = imagebll.GetModel(sid).Htmlurl.Trim();
        string htmlurl = "";
        string htmlurllist = "";
        string html = imagebll.GetModel(sid).Htmlurllist.Trim();
        if (html == "NULL" || html == "")
        {
            htmlurllist = loginname + System.DateTime.Now.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + ".htm";
        }
        //else { htmlurllist = imagebll.GetModel(sid).Htmlurllist.Trim(); }
        else { htmlurllist = html; }
        if (urladdress == "NULL" || urladdress == "")
        {
            htmlurl = System.DateTime.Now.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + ".htm";

        }
        else
        {
            htmlurl = urladdress;
        }
        //GZS.Model.ImageTabM imagemodel = imagebll.GetModel(sid);
        //GZS.Model.ImageTabM imagemodels = new GZS.Model.ImageTabM();
        GZS.Model.ImageTabM imagemodels =  imagebll.GetModel(sid);
        imagemodels.imageid = sid;
        imagemodels.LoginName = loginname;
        imagemodels.imageName = txtImageName.Text.Trim();
        imagemodels.remark = txtImageShuo.Text.Trim();

        //imagemodels.Createdatetime = imagemodel.Createdatetime;
       // imagemodels.Updatetime1 = imagemodel.Updatetime1;
        imagemodels.Htmlurl = htmlurl;
        imagemodels.Htmlurllist = htmlurllist;
        int resd = imagebll.UpdateImageTab(imagemodels);
        int ses = urlbll.DeleteByImageid(sid);

        foreach (DataListItem item in DataList1.Items)
        {
            HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
            HiddenField fidid = (HiddenField)item.FindControl("HiddenField3");
            GZS.Model.ImageUrlTabM md = new GZS.Model.ImageUrlTabM();
            md.Imageid = sid;
            md.Imagepath = fid.Value.Trim();
            md.imgexplain = fidid.Value.Trim();
            int es = urlbll.Add(md);

        }
        List<GZS.Model.ImageTabM> list = imagebll.GetAll(loginname);
        for (int i = 0; i < list.Count; i++)
        {
            imagebll.StaticHtmls(list[i].imageid, loginname);
            imagebll.StaticHtml(list[i].imageid, loginname);
        }
        imagebll.StaticHtmlshouye(loginname);
        Response.Redirect("PictureManage.aspx");
        BindShow();
    }


}
