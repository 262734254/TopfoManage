using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;
using GZS.BLL;

public partial class _Default : System.Web.UI.Page
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
    private string loaginnames
    {
        get
        {
            return ViewState["loaginnames"].ToString();
        }
        set
        {
            ViewState["loaginnames"] = value;
        }
    }
    private string cratemodeldatetime
    {
        get
        {
            return ViewState["cratemodeldatetime"].ToString();
        }
        set
        {
            ViewState["cratemodeldatetime"] = value;
        }
    }
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
    GZS.BLL.AreaTabBLL areatabbll = new GZS.BLL.AreaTabBLL();
    GZS.BLL.AreaimgBLL areaimgbll = new GZS.BLL.AreaimgBLL();
    BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ImageUrls = "";
            ViewState["strSavePath"] = "";
            str = "";
            strddd = "";
            cratemodeldatetime = "";
            if (!string.IsNullOrEmpty(Request.QueryString["LoginName"].ToString()))
            {
                loaginnames = Request.QueryString["LoginName"].ToString();
                GZS.Model.AreaTab model = areatabbll.GetModelCountByLogName(loaginnames);
                if (model != null)
                {
                    cratemodeldatetime = model.createdates.Trim();
                }
                id = 0;
                if (model != null)//判断是否是修改
                {
                    id = model.areaid;
                    txtzhongwen.Text = model.Chineseintroduced.Trim();
                    txtengilsh.Text = model.Englishintroduction.Trim();
                    List<GZS.Model.Areaimg> list = areaimgbll.GetAllModelByareId(id);
                    for (int i = 0; i < list.Count; i++)
                    {
                        str += list[i].ImageUrl.ToString().Trim() + "$";

                    }
                    BindShow(str);
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AreaIndexBLL areaindexbll = new AreaIndexBLL();
        if (txtzhongwen.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入中文描述！');</script>");
            txtzhongwen.Focus();
            return;
        }
        if (id == 0)//添加
        {
            GZS.Model.AreaTab areatab = new GZS.Model.AreaTab();
            areatab.loginName = loaginnames;
            areatab.Chineseintroduced = txtzhongwen.Text.Trim();
            areatab.Englishintroduction = txtengilsh.Text.Trim();
            areatab.createdates = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
            areatab.Updatetimes = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
            areatab.Htmlurl = "";
            GZS.Model.Areaimg areaing = new GZS.Model.Areaimg();
            areaing.ImageName = "";
            areaing.imgageexplain = "";
            areaing.ImageUrl = str;
            int result = areatabbll.InsertAreaTab(areatab, areaing);
            if (result > 0)
            {
                GZS.Model.AreaTab areatabs = areatabbll.GetModel(result);
                string urladdress = areatabs.Htmlurl.Trim();
                GZS.Model.AreaTab areatabss = new GZS.Model.AreaTab();
                areatabss.Chineseintroduced = areatabs.Chineseintroduced;
                areatabss.areaid = areatabs.areaid;
                areatabss.Englishintroduction = areatabs.Englishintroduction;
                areatabss.createdates = areatabs.createdates;
                areatabss.Updatetimes = areatabs.Updatetimes;
                areatabss.loginName = areatabs.loginName;
                if (urladdress == "NULL" || urladdress == "")
                {
                    areatabss.Htmlurl = "Regionaloverview.htm";

                }
                else
                {
                    areatabss.Htmlurl = urladdress;
                }
                int sd = areatabbll.UpdateAreatab(areatabss);
                if (sd > 0)
                {
                    //区域概况
                    int sdsas = areatabbll.StaticHtml(result, loaginnames);
                    //IF
                    areatabbll.StaticHtmls(loaginnames);

                    Response.Write("<script>alert('录入成功！');window.location.href ='AreaInsert.aspx'</script>");

                }
                else
                {

                    Response.Write("<script>alert('录入失败！');</script>");

                }
            }
            else
            {

                Response.Write("<script>alert('录入失败！');</script>");

            }
        }
        else //修改
        {
            GZS.Model.AreaTab areatab = new GZS.Model.AreaTab();
            areatab.loginName = loaginnames;
            areatab.Chineseintroduced = txtzhongwen.Text.Trim();
            areatab.Englishintroduction = txtengilsh.Text.Trim();
            areatab.createdates = cratemodeldatetime;
            areatab.Updatetimes = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
            areatab.areaid = id;
            GZS.Model.AreaTab areatabs = areatabbll.GetModel(id);
            string urladdress = areatabs.Htmlurl.Trim();
            if (urladdress == "NULL" || urladdress == "")
            {
                areatab.Htmlurl = "Regionaloverview.htm";

            }
            else
            {
                areatab.Htmlurl = urladdress;
            }
            int res = areatabbll.UpdateAreatab(areatab);
            if (res > 0)
            {

                areaimgbll.Delete(id);

                GZS.Model.Areaimg areaing = new GZS.Model.Areaimg();
                areaing.ImageName = "";
                areaing.imgageexplain = "";
                areaing.ImageUrl = str;
                areaing.areaid = id;
                int result = areaimgbll.Inserts(areaing);
                if (result > 0)
                {
                    int sds = areatabbll.StaticHtml(id, loaginnames);
                    if (sds > 0)
                    {
                        areatabbll.StaticHtmls(loaginnames);
                        Response.Write("<script>alert('修改成功！');location.href='AreaManage.aspx';</script>");
                    }
                    else { Response.Write("<script>alert('修改成功！生成静态页面失败！');</script>"); }
                }
                else
                {

                    Response.Write("<script>alert('修改失败！');</script>");

                }
            }
            else
            {

                Response.Write("<script>alert('修改失败！');</script>");

            }

        }
    }
    public string GetType(string descs)
    {
        string par = "";

        par = "http://dp.topfo.com/img/" + loaginnames + "/" + descs;


        return par;
    }

    protected void btnUpdatefile_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            string path = ConfigurationManager.AppSettings["Upimagecn001"].ToString() + loaginnames + "/";
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
                    }

                    strddd = ConfigurationManager.AppSettings["Upimagecn001"].ToString() + loaginnames + "/";

                    BindShow(str);
                    break;



            }
        }
        else
        {
            Response.Write("<script>alert('请选择上传的图片！');</script>");
        }
    }

    private void BindShow(string str)
    {

        if (str != "")
        {

            List<GZS.Model.ImageModel> list = new List<GZS.Model.ImageModel>();
            string[] num = str.Split('$');
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i].Trim() != "")
                {
                    GZS.Model.ImageModel imagemodel = new GZS.Model.ImageModel();
                    imagemodel.Descript = num[i].ToString().Trim();//图片URL
                    list.Add(imagemodel);
                }
            }

            this.DataList1.DataSource = list;
            this.DataList1.DataBind();
            if (list.Count > 0)
            {
                ed.Attributes.Add("style", "display:block");
            }
            else { ed.Attributes.Add("style", "display:none"); }
        }
        else
        {
            ed.Attributes.Add("style", "display:none");
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
        string sdf = "";
        string[] num = str.Split('$');
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i].Trim() != "")
            {
                foreach (DataListItem item in DataList1.Items)
                {
                    CheckBox ck = (CheckBox)item.FindControl("chckimage");
                    HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
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
                        }
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

            }
        }
        string b = "";

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

        BindShow(str);
    }
}
