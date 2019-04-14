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

public partial class news_NewsTabShenHe : System.Web.UI.Page
{
    Tz888.BLL.news.NewsTabBLL newstabbll = new Tz888.BLL.news.NewsTabBLL();
    Tz888.BLL.news.NewsTypeTabBLL newstypetabbll = new Tz888.BLL.news.NewsTypeTabBLL();
    Tz888.BLL.news.NewsViewTabBLL newsviewtabbll = new Tz888.BLL.news.NewsViewTabBLL();
    private int NewsId
    {
        get
        {
            return (int)ViewState["NewsId"];
        }
        set
        {
            ViewState["NewsId"] = value;
        }
    }
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
        if (!IsPostBack)
        {
            NewsId = Convert.ToInt32(Request.QueryString["str"].Trim());

            this.ddrtype.DataSource = newstypetabbll.GetAllNewsType();
            this.ddrtype.DataValueField = "TypeID";
            this.ddrtype.DataTextField = "TypeName";
            this.ddrtype.DataBind();
            upperson = "";
            BindShow();
        }
        sdfsid.Value = NewsId.ToString();
    }

    private void BindShow()
    {
        Tz888.Model.NewsTab newstab = newstabbll.GetNewsTabByNewId(NewsId);
        Tz888.Model.NewsViewTab newsviewtab = newsviewtabbll.GetNewsViewByNewId(NewsId);
        txtson.Text = newstab.Reason.ToString().Trim();
        txtnewsTitle.Text = newstab.NTitle.ToString();
        txtzhaiyao.Text = newsviewtab.Zhaiyao.ToString();
        txttitle.Text =newsviewtab.Title.ToString ();
        txtkeywords.Text = newsviewtab.Keywords.ToString();
        txtdescript.Text = newsviewtab.Description.ToString();
        this.radiotuijian.Items.FindByValue(newstab.RecommendID.ToString().Trim()).Selected = true;
        this.ddrtype.Items.FindByValue(newstab.TypeID.ToString().Trim ()).Selected = true;
        this.FreeTextBox1.Value = newsviewtab.NewView;
        txtauthor.Text = newsviewtab.Author.ToString();
        txtform.Text = newsviewtab.Formid.ToString();
        int shentype=Convert .ToInt32(newstab .Audit .ToString().Trim ());
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
            shen.Disabled = true;
            shens.Disabled = true;
            shensss.Disabled = true;
            shenssss.Disabled = true;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
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

        Tz888.Model.NewsTab newstab = new Tz888.Model.NewsTab();
        Tz888.Model.NewsViewTab newsviewtab = new Tz888.Model.NewsViewTab();
        newstab.NTitle = txtnewsTitle.Text.Trim ();
        newstab.RecommendID = Convert .ToInt32(this.radiotuijian.SelectedValue.Trim());
        newstab.Reason = txtson.Text.Trim();
        newsviewtab.Zhaiyao=txtzhaiyao.Text.Trim () ;
        newsviewtab.Title = txttitle.Text.Trim ();
        newsviewtab.Keywords=txtkeywords.Text.Trim();
        newsviewtab.Description =txtdescript.Text.Trim ();
        newstab .TypeID =Convert .ToInt32 (this.ddrtype .SelectedValue.Trim ());
        newsviewtab.NewView = this.FreeTextBox1.Value.Trim ();
        newsviewtab.Author= txtauthor.Text.Trim ();
        newsviewtab.Formid = txtform.Text.Trim ();
        if (shen.Checked == true)
        {
             newstab.Audit = 0;
             newstab.Urlhtml = "";
        }
        if (shens.Checked == true)
        {
            newstab.Audit = 1;
            string urladdress = newstabbll.GetNewsTabByNewId(NewsId).Urlhtml.Trim();
            if (urladdress == "")
            {
                newstab.Urlhtml = "news/" + DateTime.Now.ToString("yyyyMM") + "/news" + DateTime.Now.ToString("yyyyMMdd") + "_" + NewsId + ".shtml";

            }
            else
            {
                newstab.Urlhtml = urladdress;
            }
        }
        if (shensss.Checked == true)
        {
            newstab.Audit = 3;
            newstab.Urlhtml = "";
        }
        if (shenssss.Checked == true)
        {
            newstab.Audit = 5;
            newstab.Urlhtml = "";
        }
      
        //修改主表
        int result1 = newstabbll.UpdateNewsTab(newstab, NewsId);

        //修改详细表
        int result2 = newsviewtabbll.UpdateNewsViewTab(newsviewtab,NewsId);
        if (result1 > 0 && result2 > 0)
        {

            if (shens.Checked == true)
            {
                Tz888.BLL.news.PageStatic stat = new Tz888.BLL.news.PageStatic();
                int row = stat.StaticHtml(NewsId);
                if (row > 0)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='NewsTabManage.aspx';", true);
                }
                else { this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核失败,没有生成静态文件');location.href='NewsTabManage.aspx';", true); }

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核成功');location.href='NewsTabManage.aspx';", true);
            }
        }
        else 
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核失败！');", true);
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
                        Tz888.Model.NewsTab tab = newstabbll.GetNewsTabByNewId(NewsId);
                        if (tab.Imagesurls != "NULL")
                        {
                            upperson = tab.Imagesurls + picTitle + "$";
                        }
                        else { upperson =picTitle + "$"; }
                        int rusultss = newstabbll.UpdateNewsTabImageUrl(upperson.Trim(), NewsId);
                    }
                    this.LblMessage2.Text = "上传图片成功！";

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
