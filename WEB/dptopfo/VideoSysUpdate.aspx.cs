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

public partial class admin_VideoSysUpdate : System.Web.UI.Page
{
    private int id
    {
        get
        {
            return Convert.ToInt32(ViewState["id"]);
        }
        set
        {
            ViewState["id"] = value;
        }
    }
    private string picTitle
    {
        get
        {
            return ViewState["picTitle"].ToString();
        }
        set
        {
            ViewState["picTitle"] = value;
        }
    }
    private string defualImageName
    {
        get
        {
            return ViewState["defualImageName"].ToString();
        }
        set
        {
            ViewState["defualImageName"] = value;
        }
    }
    private string state
    {
        get
        {
            return ViewState["state"].ToString();
        }
        set
        {
            ViewState["state"] = value;
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

    private string path
    {
        get
        {
            return ViewState["path"].ToString();
        }
        set
        {
            ViewState["path"] = value;
        }
    }
    GZS.BLL.VideoSysBLL videosysbll = new GZS.BLL.VideoSysBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            picTitle = "";
            loginname = Request.QueryString["LoginName"].ToString();
            defualImageName = "";
            state = "";
            path = ConfigurationManager.AppSettings["Upimagecn001"].ToString() + loginname + "/";
            id = Convert.ToInt32(Request.QueryString["VideoID"].Trim());
            BindShow();
        }
    }

    private void BindShow()
    {
        GZS.Model.VideoSysM model = videosysbll.GetModel(id);
        if (model != null)
        {
            this.txttitle.Text = model.videotitle.Trim();
            this.txtVidoiName.Text = model.VidoiName.Trim();
            this.txtJieShao.Text = model.introduction.Trim();
            this.txtLaiYuan.Text = model.form.Trim();
            if (model.ImageName.Trim ()!=ConfigurationManager.AppSettings["VideoDefaultImgeName"].ToString().Trim())
            {
                Image1.ImageUrl = "http://dp.topfo.com/img/" + loginname + "/" + model.ImageName;
            }
            else { Image1.ImageUrl =ConfigurationManager.AppSettings["VideoDefaultLuJin"].ToString();}
            defualImageName = model.ImageName;

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        GZS.Model.VideoSysM model = new GZS.Model.VideoSysM();
        if (this.txttitle.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入视频标题！');</script>");
            return;
        }
        if (this.txtVidoiName.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入视频地址！');</script>");
            return;
        }
        if (this.txtLaiYuan.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入视频来源！');</script>");
            return;
        }
        model.videotitle=this.txttitle.Text.Trim ();
        model.VidoiName = this.txtVidoiName.Text.Trim();
        model.introduction=this.txtJieShao.Text.Trim();
        model.form=this.txtLaiYuan.Text.Trim ();
        model.videoid = id;
        if (picTitle.Trim() == "")
        {
            model.ImageName = defualImageName;
        }
        else { model.ImageName = picTitle.Trim(); }
        string urladdress = videosysbll.GetModel(id).htmlurl.Trim();
        if (urladdress == "NULL" || urladdress == "")
        {
            List<GZS.Model.VideoSysM> list = videosysbll.GetAllModel(loginname);
            int dsa = Convert.ToInt32(list.Count) - 1;
            string htmlurld = "";
            if (dsa == 0)
            {
                htmlurld = "video.htm";
            }
            else
            {
                htmlurld = "video" + dsa.ToString().Trim() + ".htm";
            }
            model.htmlurl = htmlurld;

        }
        else
        {
            model.htmlurl = urladdress;
        }
        int result = videosysbll.Update(model);
        if (result > 0)
        {
            GZS.BLL.VideoSysPagestaticBLL staticbll = new GZS.BLL.VideoSysPagestaticBLL();
            List<GZS.Model.VideoSysM> list = videosysbll.GetAllModel(loginname);
            for (int i = 0; i < list.Count; i++)
            {
                int re = staticbll.StaticHtml(list[i].videoid, loginname);

            }
            Response.Redirect("VideoManage.aspx");
          
        }
    }
    protected void btnUpdatefile_Click(object sender, EventArgs e)
    {

            if (this.uploadPic.HasFile)
            {
                if (state != "")
                {
                    string destinationFile = path + state.Trim();

                    if (File.Exists(destinationFile))
                    {

                        FileInfo fi = new FileInfo(destinationFile);

                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)

                            fi.Attributes = FileAttributes.Normal;

                        File.Delete(destinationFile);

                    }
                }
                picTitle = UploadFile(uploadPic, path, 500, "default");
                state = picTitle;
                switch (picTitle)
                {
                    case "1":
                        Response.Write("<script>alert('图片类型不对！');</script>");
                        break;
                    case "2":
                        Response.Write("<script>alert('图片大小超出500K！');</script>");
                        break;
                    default:

                        Image1.ImageUrl = "http://dp.topfo.com/img/" + loginname + "/"+ picTitle;
                        //Image1.Style["display"] = "none";
                        // BindShow(picTitle);
                        break;



                }
            }
            else
            {
                Response.Write("<script>alert('请选择上传的图片！');</script>");
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
}
