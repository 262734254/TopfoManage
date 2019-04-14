using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using GZS.BLL.Product;
using System.Collections.Generic;
using GZS.Model.Product;
using GZS.BLL.Invest;
public partial class admin_AddProduct : System.Web.UI.Page
{
    ProductDominBLL dominBll = new ProductDominBLL();
    ProductDominM dominM = new ProductDominM();
    ProductImgBLL imgBLL = new ProductImgBLL();
    ProductImgM imgM = new ProductImgM();
    ProductTypeBLL typeBll = new ProductTypeBLL();
    ProductTypeM typeM = new ProductTypeM();
    StaticProduct pro = new StaticProduct();
    BasePage db = new BasePage();
   
    public string titles = "";
    private string loginName = "";
    string path = ConfigurationManager.AppSettings["UpProductImage"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
       
       
        if (!IsPostBack)
        {
            ViewState["strSavePath"] = "";
            ViewState["update"] = "";
            str = "";
            if (!string.IsNullOrEmpty(Request.QueryString["productid"]))
            {
                ViewState["productid"] = Request.QueryString["productid"].ToString();
                ViewState["productTypeId"] = "";
                //titles = "修改产品信息";
                btnUpdate.Visible = true;
                Button1.Visible = false;
                bindModel(int.Parse(Request.QueryString["productid"]));
            }
            else
            {
                //titles = "添加产品信息";
                Button1.Visible = true;
            } bindInfo();
        }
    }
    protected void bindModel(int id)
    {
        dominM = dominBll.GetModel(id);
        ViewState["loginName"] = dominM.loginName.ToString();
        //txtProductName.Text = dominM.productName.Trim();
        ViewState["productTypeId"] = dominM.productTypeId.ToString();
        ddlName.SelectedValue = typeBll.GetList("productTypeId=" + dominM.productTypeId).Tables[0].Rows[0]["productTypeId"].ToString();
        txtChina.Text = dominM.Chineseintroduced.ToString().Trim();
        txtEnglish.Text = dominM.Englishintroduction.ToString().Trim();
        DataSet ds = imgBLL.GetList("productId=" + id);
        if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                str += dr["imgName"].ToString() + "%";
            }
            DataList1.DataSource = ds;
            DataList1.DataBind();
            photo.Attributes.Add("style", "display:''");
        }
        else
        {
            photo.Attributes.Add("style", "display:none");
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
    private void bindInfo()
    {
        ddlName.DataSource = null;
        ddlName.DataSource = typeBll.GetList("");
        ddlName.DataTextField = "productName";
        ddlName.DataValueField = "productTypeid";
        ddlName.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        loginName = ViewState["loginName"].ToString();
        if (dominBll.ExistsByProductTypeId(int.Parse(ddlName.SelectedValue.ToString()), loginName) > 0)
        {

            lblMessage.Text = "(不能有重复的类型录入！请重新选择)";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit();", true);

        }
        else
        {
            dominM.Chineseintroduced = txtChina.Text.Trim();
            dominM.Englishintroduction = txtEnglish.Text.Trim();
            dominM.productTypeId = int.Parse(ddlName.SelectedValue.ToString());
            dominM.productName = ddlName.SelectedItem.Text.ToString();//txtProductName.Text.Trim();
            dominM.loginName = loginName;
            dominM.htmlurl = dominM.loginName + "/product" + dominM.loginName + ".htm";
            bool flag = false;
            int num = dominBll.Add(dominM);
            if (num > 0)
            {

               dominBll.Update(dominM);
                if (DataList1.Items.Count > 0)
                {
                    foreach (DataListItem item in DataList1.Items)
                    {
                        CheckBox ck = (CheckBox)item.FindControl("chckimage");
                        HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
                        //if (File.Exists(path + fid.Value.Trim()))
                        //{
                            imgM.productid = num;
                            imgM.imgName = fid.Value.Trim();
                            imgM.imgexplain = "图片描述暂无";
                            if (imgBLL.Add(imgM) > 0) { flag = true; }
                        //}
                    }
                }
                else
                {
                    flag = true;
                }
            }
            if (flag)
            {
                num = pro.StaticHtml(num, loginName);
                StaticIF sta = new StaticIF();
                sta.StaticHtml(loginName, 3);
                if (num > 0)
                { flag = true; }
            }
            if (!flag)
            {
                Response.Write("<script>alert('添加失败！');document.location='ProductManage.aspx'</script>");
            }
            else
            {
                Response.Redirect("ProductManage.aspx");
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        loginName = ViewState["loginName"].ToString();
        bool flag = false;
       
        if (ViewState["productTypeId"].Equals(ddlName.SelectedValue.ToString()))//用户没有更改下拉框的值
        {
            flag = NewMethod(flag);
        }
        else
        {
            int number = dominBll.ExistsByProductTypeId(int.Parse(ddlName.SelectedValue.ToString()), loginName);
            if (number > 0)
            {
                lblMessage.Text = "(您已经录入了此类型！请重新选择)";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", " ConAudit();", true);
                return;
            }
            else
            {
                flag = NewMethod(flag);
            }
        }
        if (flag)
        {
            int num = pro.StaticHtml(dominM.productid, loginName);
            StaticIF sta = new StaticIF();
            sta.StaticHtml(loginName, 3);
            if (num > 0)
            { flag = true; }
        }
        if (!flag)
        {
            Response.Write("<script>alert('修改失败！');document.location='ProductManage.aspx'</script>");
        }
        else
        {
            Response.Redirect("ProductManage.aspx");
        }
    }

    private bool NewMethod(bool flag)
    {
        dominM = dominBll.GetModel(int.Parse(ViewState["productid"].ToString()));
        //dominM.productid = ;
        if (string.IsNullOrEmpty(dominM.htmlurl))
        {
            dominM.htmlurl = dominM.loginName + "/product" + dominM.loginName + ".htm";
            //dominM.htmlurl = dominM.loginName + "/" + DateTime.Now.ToString("yyyyMMdd") + "_" + dominM.productid + ".shtml";
        }
        dominM.Chineseintroduced = txtChina.Text.Trim();
        dominM.Englishintroduction = txtEnglish.Text.Trim();
        dominM.productTypeId = int.Parse(ddlName.SelectedValue.ToString());
        dominM.productName = ddlName.SelectedItem.Text.ToString();
        //dominM.loginName = loginName;

        if (dominBll.Update(dominM))
        {
            if (ViewState["update"].Equals("true"))
            {
                imgBLL.DeleteByProductId(dominM.productid);
                if (DataList1.Items.Count > 0)
                {
                    foreach (DataListItem item in DataList1.Items)
                    {
                        CheckBox ck = (CheckBox)item.FindControl("chckimage");
                        HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
                        imgM.productid = dominM.productid;
                        imgM.imgName = fid.Value.Trim();
                        imgM.imgexplain = "图片描述暂无";
                        if (imgBLL.Add(imgM) > 0) { flag = true; }
                    }
                }
                else
                {
                    flag = true;
                }
            }
            else
            {
                flag = true;
            }
        }
        return flag;
    }
    protected void btnUpImage_Click(object sender, EventArgs e)
    {
       
        string imgName = "";
       
        if (uploadPic.HasFile)
        {
            
            //imagesDispaly.Attributes.Add("style", "display:''");
            imgName = UploadFile(uploadPic, path, 500, "default");
            switch (imgName)
            {
                case "1":
                    Response.Write("<script>alert('图片类型不对！');</script>");
                    break;
                case "2":
                    Response.Write("<script>alert('图片大小超出500K！');</script>");
                    break;
                default:
                    //显示图片
                    ViewState["update"] = "true";
                    str += imgName + "%";
                    BindShow(str);
                    break;
            }
            //imagesDispaly.Attributes.Add("style", "display:none");
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
            List<ProductImgM> list = new List<ProductImgM>();
            string[] num = str.Split('%');
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i].Trim() != "")
                {
                    ProductImgM imagemodel = new ProductImgM();
                    imagemodel.imgName = num[i].ToString().Trim();//图片URL
                    list.Add(imagemodel);
                }
            }
            photo.Attributes.Add("style", "display:''");
            this.DataList1.DataSource = list;
            this.DataList1.DataBind();
        }
        else
        {
            photo.Attributes.Add("style", "display:none");
            this.DataList1.DataSource = null;
            this.DataList1.DataBind();
        }
    }
    public string GetType(string descs)
    {
        string imagePath = "";
        imagePath = "http://dp.topfo.com/img/" + ViewState["loginName"].ToString() + "/" + descs;
        return imagePath;
    }
    /// <summary>
    /// 上传图片
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
            loginName = ViewState["loginName"].ToString();
            string strSaveName = string.Empty;
            string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名
            DateTime date = DateTime.Now;
            strSaveName = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + date.Millisecond.ToString() + strtype;
            if (!Directory.Exists(path + loginName))
            {
                Directory.CreateDirectory(path + loginName);
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
                    //Response.Write(strSavePath);
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
                //Response.Write(strSavePath);
                return strSaveName;
            }
        }
        catch (Exception ex)
        {
            throw;
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string deleteStr = "";
        string[] num = str.Split('%');
        for (int i = 0; i < num.Length - 1; i++)
        {
            if (num[i].Trim() != "")
            {
                foreach (DataListItem item in DataList1.Items)
                {
                    CheckBox ck = (CheckBox)item.FindControl("chckimage");
                    HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
                    if (ck.Checked)
                    {
                        deleteStr += fid.Value.Trim() + "%";
                        if (File.Exists(path + fid.Value.Trim()))
                        {
                            File.Delete(path + fid.Value.Trim());

                        } ViewState["update"] = "true";
                    }
                }
            }
        }
        string b = "";
        if (deleteStr != "")
        {
            string strSplit = string.Empty;
            string[] deleteChilds = deleteStr.Split('%');
            for (int i = 0; i < deleteChilds.Length - 1; i++)
            {
                if (deleteChilds[i] != "")
                {
                    string n = deleteChilds[i].ToString() + "%";
                    b = str.Replace(n, "");
                    str = b;
                }
            }
        }
        BindShow(str);

    }
}
