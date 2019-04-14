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
using GZS.Model.Park;
using GZS.BLL.Park;
using GZS.BLL;
public partial class admin_AddPark : System.Web.UI.Page
{
    private string loginName = "";
    public string titles = "";
    string path = ConfigurationManager.AppSettings["UpParkImage"].ToString();
    BasePage db = new BasePage();
    ParkImgBLL imgBLL = new ParkImgBLL();
    ParkImgM imgM = new ParkImgM();
    ParkInfoBLL parkBll = new ParkInfoBLL();
    ParkInfoM parkM = new ParkInfoM();
    ParkTypeBll typeBll = new ParkTypeBll();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {

            ViewState["strSavePath"] = "";
            ViewState["update"] = "";
            str = "";
            mingche = "";
            if (!string.IsNullOrEmpty(Request.QueryString["parktypeid"]) && !string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                ViewState["parkid"] = Request.QueryString["parktypeid"].ToString();
                ViewState["name"] = Request.QueryString["name"].ToString();
                bindModel(int.Parse(Request.QueryString["parktypeid"]));
            }
            else
            {
                //titles = "添加园区信息";
                Button1.Visible = true;
            } //bindInfo();
        }
    }
    protected void bindModel(int id)
    {
        parkM = parkBll.GetModel(id, ViewState["name"].ToString());
        if (parkM != null)
        {
            //titles = "修改园区信息";
            //txtProductName.Text = parkM.productName.Trim();
            //ddlName.SelectedValue = typeBll.GetList("parktypeid=" + parkM.parktypeid).Tables[0].Rows[0]["parktypeid"].ToString();
            txtChina.Text = parkM.Chineseintroduced.ToString().Trim();
            txtEnglish.Text = parkM.Englishintroduction.ToString().Trim();
            DataSet ds = imgBLL.GetList("parkid=" + parkM.parkid);
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    str += dr["imgName"].ToString() + "%";
                    mingche += dr["imgexplain"].ToString() + "%";
                }
                DataList1.DataSource = ds;
                DataList1.DataBind();
                photo.Attributes.Add("style", "display:''");
            }
            else
            {
                photo.Attributes.Add("style", "display:none");
            }
            btnUpdate.Visible = true;
            Button1.Visible = false;
        }
        else
        {
            //titles = "添加园区信息";
            Button1.Visible = true;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (parkBll.ExistsByParkTypeId(int.Parse(ddlName.SelectedValue.ToString())) <= 1)
        //{
        parkM.Chineseintroduced = txtChina.Text.Trim();
        parkM.Englishintroduction = txtEnglish.Text.Trim();
        parkM.parktypeid = int.Parse(ViewState["parkid"].ToString()); //int.Parse(ddlName.SelectedValue.ToString());
        parkM.parkName = ViewState["name"].ToString(); //ddlName.SelectedItem.Text.ToString();//txtProductName.Text.Trim();
        parkM.loginName = loginName;
        //parkM.htmlurl = parkM.loginName + "/park" + parkM.loginName + ".htm";
        parkM.htmlurl = "Park.htm";
        bool flag = false;
        int num = parkBll.Add(parkM);
        if (num > 0)
        {
            if (DataList1.Items.Count > 0)
            {
                foreach (DataListItem item in DataList1.Items)
                {
                    CheckBox ck = (CheckBox)item.FindControl("chckimage");
                    HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
                    HiddenField fid2 = (HiddenField)item.FindControl("HiddenField2");
                    //if (File.Exists(path + fid.Value.Trim()))
                    //{
                    imgM.parkId = num;
                    imgM.imgName = fid.Value.Trim();
                    imgM.imgexplain = fid2.Value.Trim();
                    if (imgBLL.Add(imgM) > 0)
                    {
                        flag = true;
                    }
                }
            }
            else
            {
                flag = true;
            }
                //}
        }
        if (flag)
        {
            StaticPark pro = new StaticPark();
            num = pro.StaticHtml(num, ViewState["name"].ToString());
            //AreaIndexBLL areaBll = new AreaIndexBLL();
            //areaBll.AreaHtml(loginName, 3);
            if (num > 0)
            { flag = true; }
        }
        if (!flag)
        {
            Response.Write("<script>alert('添加失败！');</script>");
            //Response.Write("<script>alert('修改失败！');document.location='ParkManage.aspx'</script>");
        }
        else
        {
            btnUpdate.Visible = true;
            Button1.Visible = false; 
            Response.Write("<script>alert('添加成功！');</script>");
            bindModel(int.Parse(ViewState["parkid"].ToString()));
            //Response.Redirect("ParkManage.aspx");
        }
        //}
        //else
        //{
        //    Response.Write("<script>alert('此类型己被您添加！请选择其它类型');</script>");
        //}
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //if (parkBll.ExistsByParkTypeId(int.Parse(ddlName.SelectedValue.ToString())) <= 1)
        //{
        parkM = parkBll.GetModel(int.Parse(ViewState["parkid"].ToString()), ViewState["name"].ToString());
        //parkM.productid = ;
        if (string.IsNullOrEmpty(parkM.htmlurl))
        {
            parkM.htmlurl = "Park.htm";
            //parkM.htmlurl = parkM.loginName + "/park" + parkM.loginName + ".htm";
        }
        parkM.Chineseintroduced = txtChina.Text.Trim();
        parkM.Englishintroduction = txtEnglish.Text.Trim();
        //parkM.parktypeid = int.Parse(ddlName.SelectedValue.ToString());
        parkM.parkName = ViewState["name"].ToString();// ddlName.SelectedItem.Text.ToString();
        //parkM.loginName = loginName;
        bool flag = false;
        if (parkBll.Update(parkM))
        {
            if (ViewState["update"].Equals("true"))
            {
                imgBLL.DeleteByParkId(parkM.parkid);
                if (DataList1.Items.Count > 0)
                {
                    foreach (DataListItem item in DataList1.Items)
                    {
                        CheckBox ck = (CheckBox)item.FindControl("chckimage");
                        HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
                        HiddenField fid2 = (HiddenField)item.FindControl("HiddenField2");
                        imgM.parkId = parkM.parkid;
                        imgM.imgName = fid.Value.Trim();
                        imgM.imgexplain = fid2.Value.Trim();
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
        if (flag)
        {
            StaticPark pro = new StaticPark();
            int num = pro.StaticHtml(parkM.parkid, ViewState["name"].ToString());
            //AreaIndexBLL areaBll = new AreaIndexBLL();
            //areaBll.AreaHtml(loginName, 3);
            if (num > 0)
            { flag = true; }
        }
        if (!flag)
        {
            Response.Write("<script>alert('修改失败！');</script>");
            //Response.Write("<script>alert('修改失败！');document.location='ParkManage.aspx'</script>");
        }
        else
        {
            Response.Write("<script>alert('修改成功！');location.href='ParkManage.aspx';</script>");
            //Response.Redirect("ParkManage.aspx");
        }
        //}
        //else
        //{
        //    Response.Write("<script>alert('此类型己被您添加！请选择其它类型');</script>");
        //}
    }
    protected void btnUpImage_Click(object sender, EventArgs e)
    {
        string imgName = "";
        if (uploadPic.HasFile)
        {
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
                    int count = DataList1.Items.Count;
                    count++;
                    mingche += count + txtmiao.Text.Trim() + "%";
                    BindShow(str, mingche);
                    txtmiao.Text = "";
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

        if (str != "")
        {
            List<ParkImgM> list = new List<ParkImgM>();
            string[] num = str.Split('%');
            string[] num2 = ming.Split('%');
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i].Trim() != "")
                {
                    ParkImgM imagemodel = new ParkImgM();
                    imagemodel.imgName = num[i].ToString().Trim();//图片URL
                    if (num2[i].Trim() != "")
                    {
                        imagemodel.imgexplain = num2[i].ToString().Trim();
                    }
                    else
                    {
                        imagemodel.imgexplain = ""; 
                    }
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
        //imagePath = path + descs;G:\dp\img\cn001/201155184728156.jpg   http://dp.topfo.com/img/cn001/201155184728156.jpg
        imagePath = "http://dp.topfo.com/img/" + ViewState["name"].ToString() + "/" + descs;
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
            loginName = ViewState["name"].ToString();
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
        string deleteDesc = "";
        string[] num = str.Split('%');
        for (int i = 0; i < num.Length - 1; i++)
        {
            if (num[i].Trim() != "")
            {
                foreach (DataListItem item in DataList1.Items)
                {
                    CheckBox ck = (CheckBox)item.FindControl("chckimage");
                    HiddenField fid = (HiddenField)item.FindControl("HiddenField1");
                    HiddenField fid2 = (HiddenField)item.FindControl("HiddenField2");
                    if (ck.Checked)
                    {
                        deleteStr += fid.Value.Trim() + "%";
                        deleteDesc += fid2.Value.Trim() + "%";
                        if (File.Exists(path + fid.Value.Trim()))
                        {
                            File.Delete(path + fid.Value.Trim());

                        } ViewState["update"] = "true";
                    }
                }
            }
        }
        string b = "";
        string b1 = "";
        if (deleteStr != "")
        {
            string strSplit = string.Empty;
            string[] deleteChilds = deleteStr.Split('%');
            string[] deleteDescs = deleteDesc.Split('%');
            for (int i = 0; i < deleteChilds.Length - 1; i++)
            {
                if (deleteChilds[i] != "")
                {
                    string n = deleteChilds[i].ToString() + "%";
                    b = str.Replace(n, "");
                    str = b;
                    string n1 = deleteDescs[i].ToString() + "%";
                    b1 = mingche.Replace(n1, "");
                    mingche = b1;
                }
            }
        }
        BindShow(str, mingche);

    }
}
