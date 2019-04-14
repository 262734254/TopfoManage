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

public partial class admin_EnvironmentTabInsert : System.Web.UI.Page
{
    private string ImageUrls
    {
        get
        {
            return ViewState["ImageUrls"].ToString();
        }
        set
        {
            ViewState["ImageUrls"] = value;
        }
    }
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
    private string mingche
    {
        get
        {
            return ViewState["mingche"].ToString();
        }
        set
        {
            ViewState["mingche"] = value;
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
    private int EnvironmentTypeids
    {
        get
        {
            return Convert.ToInt32(ViewState["EnvironmentTypeids"]);
        }
        set
        {
            ViewState["EnvironmentTypeids"] = value;
        }
    }
    private int counts
    {
        get
        {
            return Convert.ToInt32(ViewState["counts"]);
        }
        set
        {
            ViewState["counts"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ImageUrls = "";
            counts = 0;
            ViewState["strSavePath"] = "";
            ViewState["update"] = "";
            str = "";
            strddd = "";
            mingche = "";
            loginname = Request.QueryString["LoginName"].ToString();
            EnvironmentTypeids = Convert.ToInt32(Request.QueryString["EnvironmentTypeid"].Trim());
            GZS.BLL.EnvironmentTabBLL envtabbll = new GZS.BLL.EnvironmentTabBLL();
            GZS.BLL.EnvironmentImgBLL envimgbll = new GZS.BLL.EnvironmentImgBLL();
            GZS.Model.EnvironmentTabM envirtabm = envtabbll.EnvironmentlistByLoginNameandTypeid(loginname, EnvironmentTypeids);
            if (envirtabm != null)
            {
                counts = envirtabm.Environmentid;
                BindShow();
            }


        }
    }

    private void BindShow()
    {
        GZS.BLL.EnvironmentTabBLL envtabbll = new GZS.BLL.EnvironmentTabBLL();
        GZS.BLL.EnvironmentImgBLL envimgbll = new GZS.BLL.EnvironmentImgBLL();
        GZS.Model.EnvironmentTabM d = envtabbll.GetModel(counts);
        txtzhongwen.Text = d.Chineseintroduced.Trim();
        txtengilsh.Text = d.Englishintroduction.Trim();
        List<GZS.Model.EnvironmentImgM> list = envimgbll.GetAllByEnvironmentTabId(counts);
        for (int i = 0; i < list.Count; i++)
        {
            str += list[i].imgpath.ToString().Trim() + "$";
            mingche += list[i].imgexplain.ToString().Trim() + "$";
        }
        BindShow(str, mingche);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        GZS.BLL.EnvironmentTabBLL envtabbll = new GZS.BLL.EnvironmentTabBLL();
        GZS.BLL.EnvironmentImgBLL envimgbll = new GZS.BLL.EnvironmentImgBLL();
        if (txtzhongwen.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入中文描述！');</script>");
            txtzhongwen.Focus();
            return;
        }
        if (counts == 0)
        {
            GZS.Model.EnvironmentTabM environmentTabmodel = new GZS.Model.EnvironmentTabM();
            environmentTabmodel.loginName = loginname;
            environmentTabmodel.EnvironmentTypeid = EnvironmentTypeids;
            environmentTabmodel.Chineseintroduced = txtzhongwen.Text.Trim();
            environmentTabmodel.Englishintroduction = txtengilsh.Text.Trim();
            environmentTabmodel.Createtime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
            environmentTabmodel.Updatetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
            int re = envtabbll.CountByLoginNameandTypeid(environmentTabmodel.loginName.Trim(), EnvironmentTypeids);
            if (re > 0)
            {
                Response.Write("<script>alert('已经存在该类型的资料！');</script>");
                return;
            }
            int reslut = envtabbll.Insert(environmentTabmodel);
            if (reslut != 0)
            {
                foreach (DataListItem item in DataList1.Items)
                {

                    HiddenField fid1 = (HiddenField)item.FindControl("HiddenField1");
                    HiddenField fid2 = (HiddenField)item.FindControl("HiddenField2");
                    GZS.Model.EnvironmentImgM envimgmodel = new GZS.Model.EnvironmentImgM();
                    envimgmodel.Environmenttabid = reslut;
                    envimgmodel.imgpath = fid1.Value.Trim();
                    envimgmodel.imgexplain = fid2.Value.Trim();
                    int res = envimgbll.Insert(envimgmodel);
                }
                int resa = envtabbll.StaticHtml(loginname);
                int ax = envtabbll.StaticHtmls(loginname);
                Response.Write("<script>alert('录入成功！');</script>");

            }
            else { Response.Write("<script>alert('录入失败！');</script>"); }
        }
        else
        {
            GZS.Model.EnvironmentTabM environmentTabmodelS = envtabbll.GetModel(counts);
            GZS.Model.EnvironmentTabM environmentTabmodel = new GZS.Model.EnvironmentTabM();
            environmentTabmodel.loginName = loginname;
            environmentTabmodel.EnvironmentTypeid = EnvironmentTypeids;
            environmentTabmodel.Chineseintroduced = txtzhongwen.Text.Trim();
            environmentTabmodel.Englishintroduction = txtengilsh.Text.Trim();
            environmentTabmodel.Createtime = environmentTabmodelS.Createtime.Trim();
            environmentTabmodel.Environmentid = counts;
            environmentTabmodel.Updatetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
            int s = envtabbll.Update(environmentTabmodel);
            if (ViewState["update"].Equals("true"))
            {
                envimgbll.Delete(counts);
                foreach (DataListItem item in DataList1.Items)
                {

                    HiddenField fid1 = (HiddenField)item.FindControl("HiddenField1");
                    HiddenField fid2 = (HiddenField)item.FindControl("HiddenField2");
                    GZS.Model.EnvironmentImgM envimgmodel = new GZS.Model.EnvironmentImgM();
                    envimgmodel.Environmenttabid = counts;
                    envimgmodel.imgpath = fid1.Value.Trim();
                    envimgmodel.imgexplain = fid2.Value.Trim();
                    int res = envimgbll.Insert(envimgmodel);
                }
            }
            int resa = envtabbll.StaticHtml(loginname);
            int ax = envtabbll.StaticHtmls(loginname);
            if (resa > 0)
            {
                Response.Write("<script>alert('修改成功！');location.href='EnvironmentManage.aspx';</script>");
            }
            else { Response.Write("<script>alert('修改失败！');</script>"); }

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
                    ViewState["update"] = "true";
                    int nu1 = 0;
                    if (str != "")
                    {
                        string[] num1 = str.Split('$');
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
                        str += picTitle + "$";
                        mingche += txtmiao.Text.Trim() + "$";
                    }
                    txtmiao.Text = "";
                    strddd = ConfigurationManager.AppSettings["Upimagecn001"].ToString() + loginname + "/";

                    BindShow(str, mingche);
                    break;
            }
        }
        else
        {
            Response.Write("<script>alert('请选择上传的图片！');</script>");
        }
    }
    private void BindShow(string str, string ming)
    {
        GZS.BLL.EnvironmentTabBLL envtabbll = new GZS.BLL.EnvironmentTabBLL();
        GZS.BLL.EnvironmentImgBLL envimgbll = new GZS.BLL.EnvironmentImgBLL();
        if (str != "")
        {
            List<GZS.Model.ImageModel> list = new List<GZS.Model.ImageModel>();
            string[] num = str.Split('$');
            string[] num2 = ming.Split('$');
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i].Trim() != "")
                {
                    GZS.Model.ImageModel imagemodel = new GZS.Model.ImageModel();
                    imagemodel.Descript = num[i].ToString().Trim();//图片URL
                    if (num2[i].Trim() != "")
                    {
                        imagemodel.Shuoming = num2[i].ToString().Trim();
                    }
                    else
                    {
                        imagemodel.Shuoming = "";
                    }
                    //for (int t = 0; t < num2.Length; t++)
                    //{
                    // if (i == t)
                    //{
                    //imagemodel.Shuoming = num2[t].ToString().Trim();
                    //}
                    list.Add(imagemodel);
                }

            }
            this.DataList1.DataSource = list;
            this.DataList1.DataBind();
        }
        else
        {
            this.DataList1.DataSource = null;
            this.DataList1.DataBind();
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
    protected void btnsave_Click(object sender, EventArgs e)
    {
        GZS.BLL.EnvironmentTabBLL envtabbll = new GZS.BLL.EnvironmentTabBLL();
        GZS.BLL.EnvironmentImgBLL envimgbll = new GZS.BLL.EnvironmentImgBLL();
        string sdf = "";
        string sdss = "";
        string[] num = str.Split('$');
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i].Trim() != "")
            {
                foreach (DataListItem item in DataList1.Items)
                {
                    CheckBox ck = (CheckBox)item.FindControl("chckimage");
                    HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
                    HiddenField fidd = (HiddenField)item.FindControl("HiddenField2");
                    if (ck.Checked == true)
                    {
                        int dsa = 0;
                        if (sdf != "")
                        {
                            string[] sdd = sdf.Split('$');

                            for (int t = 0; t < sdd.Length; t++)
                            {
                                if (sdd[t] == fid.Value)
                                {
                                    dsa = 1;
                                }
                            }
                        }
                        if (dsa == 0)
                        {
                            sdf += fid.Value.Trim() + "$";
                            sdss += fidd.Value.Trim() + "$";
                        }
                        string destinationFile = strddd + fid.Value.Trim();

                        if (File.Exists(destinationFile))
                        {
                            FileInfo fi = new FileInfo(destinationFile);
                            if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)

                                fi.Attributes = FileAttributes.Normal;

                            File.Delete(destinationFile);
                        } ViewState["update"] = "true";
                    }
                }
            }
        }
        string b = "";
        string bb = "";
        if (sdf != "")
        {
            string strSplit = string.Empty;
            string[] dfs = sdf.Split('$');
            for (int i = 0; i < dfs.Length; i++)
            {
                if (dfs[i] != "")
                {
                    string n = dfs[i].ToString() + "$";
                    b = str.Replace(n, "");
                    str = b;
                }
            }
        }
        if (sdss != "")
        {
            string strSplit = string.Empty;
            string[] dfs = sdss.Split('$');
            for (int i = 0; i < dfs.Length; i++)
            {
                if (dfs[i] != "")
                {
                    string n = dfs[i].ToString() + "$";
                    bb = mingche.Replace(n, "");
                    mingche = bb;
                }
            }
        }
        BindShow(str, mingche);
    }
}
