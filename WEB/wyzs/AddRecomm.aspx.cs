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
using Tz888.Model.wyzs;
using Tz888.BLL.wyzs;
using System.IO;
public partial class wyzs_AddRecomm : System.Web.UI.Page
{
    WyzsModel model = new WyzsModel();
    WyzsTabBLL bll = new WyzsTabBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["flag"] = "";
            ViewState["strSaveName"] = "";
            if (Request.QueryString["alt"] == "1")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))//修改
                {
                    bindModel(int.Parse(Request.QueryString["id"].ToString()));
                    btnSubmit.Visible = false;
                    btnAudit.Visible = true;
                }
            }
            else
            {
                btnSubmit.Visible = true;
                btnAudit.Visible = false;
            }
           
        }
        bindDrop();
    }
    private void bindModel(int id)
    {
        model = bll.GetModel(id);
        txtSite.Text = model.htmlurl.ToString();
        txtorder.Text = model.orderid.ToString();
        txtTitle.Text = model.title.Trim();
        ddlTypeName.SelectedValue = model.typeid.ToString();
        if (!string.IsNullOrEmpty(model.imgPath))
        {
            if (model.imgPath.Equals("http://www.topfo.com/dservice/image/photo.jpg"))
            {
                ViewState["flag"] = "true"; //默认图片
            }
            else
            {
                ViewState["strSaveName"] = model.imgPath;
            }
            Image1.ImageUrl = "http://wyzs.topfo.com/img/img" + model.imgPath;
            imageDis.Attributes.Add("style", "display:''");
        }
        else
        {
            ViewState["strSaveName"] = "http://www.topfo.com/dservice/image/photo.jpg";
            imageDis.Attributes.Add("style", "display:none");
        }
    }
    private void bindDrop()
    {
        WyzsTypeBLL blls = new WyzsTypeBLL();
        ddlTypeName.DataSource = blls.GetList("");
        ddlTypeName.DataValueField = "ID";
        ddlTypeName.DataTextField = "typeName";
        ddlTypeName.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        model.htmlurl = txtSite.Text.Trim();
        model.orderid = Convert.ToInt32(txtorder.Text.ToString());
        model.title = txtTitle.Text.Trim();
        model.typeid = Convert.ToInt32(ddlTypeName.SelectedValue.ToString());
        model.status = "资源推荐";
        model.imgPath = ViewState["strSaveName"].ToString();
        if (bll.Add(model) <= 0)
        {
            Response.Write("<script>alert('添加失败！');document.location='OtherManage.aspx'</script>");
        }
        else
        {
            Response.Redirect("RecommManage.aspx");
        }
    }
    protected void btnUpload2_Click(object sender, EventArgs e)
    {
       
        string imgName = "";

        if (uploadPic.HasFile)
        {
            try
            {
                com.topfo.wyzs.GenerateStatic gen = new com.topfo.wyzs.GenerateStatic();
                HttpPostedFile mFile = uploadPic.PostedFile;
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
                    ViewState["strSaveName"] = imgName;
                    if (gen.UpCommerceImages(imgName, mFileByte) > 0)
                    {
                        //显示图片
                        Image1.ImageUrl = "http://wyzs.topfo.com/img/img/" + ViewState["strSaveName"].ToString();
                        imageDis.Attributes.Add("style", "display:''");
                    }
                }
                else
                {
                    //LblMessage2.Text = "该文件类型不允许上传！";
                }
            }
            catch (Exception ex)
            {
                // LblMessage2.Text = "文件上传失败，请重试！<br/>详细错误信息：" + ex.ToString();
            }
        }
        else
        {
            Response.Write("<script>alert('请选择上传的图片！');</script>");

        }


    }
 protected void btnAudit_Click(object sender, EventArgs e)
    {
        model = bll.GetModel(int.Parse(Request.QueryString["id"].ToString()));
        model.htmlurl = txtSite.Text.Trim();
        model.orderid = Convert.ToInt32(txtorder.Text.ToString());
        model.title = txtTitle.Text.Trim();
        model.typeid = Convert.ToInt32(ddlTypeName.SelectedValue.ToString());
        model.imgPath = ViewState["strSaveName"].ToString();
        if (!bll.Update(model))
        {
            Response.Write("<script>alert('修改失败！');document.location='RecommManage.aspx'</script>");

        }
        else
        {
            Response.Redirect("RecommManage.aspx");
        }
    }
}
