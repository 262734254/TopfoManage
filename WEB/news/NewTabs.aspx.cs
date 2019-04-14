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
using System.IO;

public partial class news_NewTabs : System.Web.UI.Page
{
    Tz888.BLL.news.NewsTabBLL newstabbll = new Tz888.BLL.news.NewsTabBLL();
    Tz888.BLL.news.NewsTypeTabBLL newstypetabbll = new Tz888.BLL.news.NewsTypeTabBLL();
    private readonly BasePage bp = new BasePage();
    private string upperson
    {
        get
        {
            return ViewState["upperson"].ToString();
        }
        set
        {
            ViewState["upperson"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(bp.LoginName))
            Response.Redirect("~/login.aspx");

        if (!IsPostBack)
        {
            BindShow();
            upperson = "";
        }
    }

    private void BindShow()
    {
        this.ddrtype.DataSource = newstypetabbll.GetAllNewsType();
        this.ddrtype.DataValueField = "TypeID";
        this.ddrtype.DataTextField = "TypeName";
        this.ddrtype .DataBind ();
    } 
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.Model.NewsTab newstab = new NewsTab();
        Tz888.Model.NewsTypeTab newstypetab = new NewsTypeTab();
        Tz888.Model.NewsViewTab newsviewtab = new NewsViewTab();
        if (txtnewsTitle.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入标题');", true);
            return;
        }
        if (txtzhaiyao.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入摘要');", true);
            return;
        }
        if (txttitle.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入页面标题');", true);
            return;
        }
        if (txtkeywords.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入关键字');", true);
            return;
        }
        if (txtdescript.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入描述');", true);
            return;
        }
        if (FreeTextBox1.Value.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入内容');", true);
            return;
        }
        if (txtform.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入来源');", true);
            return;
        }
        BasePage bp = new BasePage();

        newstab.UserName = bp.LoginName;
        newstab.TypeID = Convert.ToInt32(this.ddrtype.SelectedValue);
        newstab.NTitle = txtnewsTitle.Text.Trim();
        newstab.Audit = Convert.ToInt32(radiocaozuo.SelectedValue.Trim());
        newstab.RecommendID = Convert.ToInt32(this.radiotuijian.SelectedValue.Trim());
        newstab.Urlhtml = "";
        newstab.Imagesurls = upperson;
        newstab.Createdate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
        newstab.FromID = 1;
        newsviewtab.Title = txttitle.Text.Trim();
        newsviewtab.Keywords = txtkeywords.Text.Trim();
        newsviewtab.Description = txtdescript.Text.Trim();
        newsviewtab.NewView = FreeTextBox1.Value.Trim();
        newsviewtab.Formid = txtform.Text.Trim();
        newsviewtab.Author=txtauthor .Text .Trim ();
        newsviewtab .Zhaiyao =txtzhaiyao .Text .Trim ();

        int result = newstabbll.InsertNewsTab(newstab, newstypetab, newsviewtab);
        string maxid = newstabbll.GetMaxNewsId();
        int row = 0;
        if (result > 0)
        {
            if (Convert.ToInt32(this.radiocaozuo.SelectedValue) == 1)
            {
                string url = "news/" + DateTime.Now.ToString("yyyyMM") + "/news" + DateTime.Now.ToString("yyyyMMdd") + "_" + maxid + ".shtml";
                int newsid = Convert.ToInt32(maxid);
                int rusult3 = newstabbll.UpdateNewsTabUrl(url, newsid);
                Tz888.BLL.news.PageStatic stat = new Tz888.BLL.news.PageStatic();
                row = stat.StaticHtml(newsid);
                if (row > 0)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='NewsTabManage.aspx';", true);
                }
                else { this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('录入失败,没有生成静态文件');location.href='NewsTabManage.aspx';", true); }

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='NewsTabManage.aspx';", true);
            }

        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('录入失败');", true);
        }
    }
    protected void btnUpfile_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            string path = ConfigurationManager.AppSettings["UpimageNews"].ToString();   
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
                    int nu1 = 0;
                    if (upperson != "")
                    {
                        string[] num1 = upperson.Split('$');
                        for (int i = 0; i < num1.Length; i++)
                        {
                            if (picTitle == num1[i])
                            {
                                nu1 = 1;
                            }
                        }
                    }
                    if (nu1 == 0)
                    {
                        upperson += picTitle + "$";
                    }
                    this.LblMessage2.Text = "上传图片成功！";
                    this.showidUpdatePerson.Value = upperson;
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
