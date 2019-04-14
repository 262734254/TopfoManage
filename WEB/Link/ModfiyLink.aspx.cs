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

public partial class Link_ModfiyLink : System.Web.UI.Page
{
    private readonly Tz888.BLL.Link.LinkChannelType ChannelBll = new Tz888.BLL.Link.LinkChannelType();
    private readonly Tz888.BLL.Link.LinkTypeTab LinkTypeBll = new Tz888.BLL.Link.LinkTypeTab();
    private readonly Tz888.BLL.Link.LinkInfoTab LinkInfoBll = new Tz888.BLL.Link.LinkInfoTab();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitChannel();
            InitLinkType();

            if (Request.QueryString["LinkId"] != null)
            {
                string LinkId = Request.QueryString["LinkId"];
                ViewState["LinkInfoId"] = LinkId;
                if (Tz888.Common.Utility.PageValidate.IsNumber(LinkId))
                {
                    InitLinkInfo(LinkId);
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
                }
            }
        }
    }

    protected void BtnModfiy_Click(object sender, EventArgs e)
    {
        try
        {
            Tz888.Model.Link.LinkInfoTab Model = new Tz888.Model.Link.LinkInfoTab();
            Model.LinkInfoId = (ViewState["LinkInfoId"] == null) ? 0 : Convert.ToInt32(ViewState["LinkInfoId"].ToString());
            Model.LinkInfoName = txtLinkName.Value.Trim();
            Model.ChannelId = Convert.ToInt32(DropChannel.SelectedValue);
            Model.LinkId = Convert.ToInt32(DropLinkType.SelectedValue);
            Model.LinkUrl = txtLinkUrl.Value.Trim();
            Model.Sort = (txtSort.Value.Trim() == "") ? 0 : Convert.ToInt32(txtSort.Value.Trim());
            Model.Logo = (ViewState["Logo"] == null) ? "" : ViewState["Logo"].ToString();
            Model.Remarks = txtRemarks.Value.Trim();
            if (LinkInfoBll.ModfiyLink(Model))
            {
                string strs = ViewState["odlLogo"].ToString();
                if (strs.Length > 0)
                {
                    string[] str = strs.Split('/');
                    imgBiz.Service serBiz = new imgBiz.Service(); //webservice
                    serBiz.delCrmImage(str[5], str[4]);
                }
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改成功!", "LinkManage.aspx", false);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "修改失败!");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    //初始化频道
    public void InitChannel()
    {
        try
        {
            DropChannel.DataSource = ChannelBll.GetChannelList();
            DropChannel.DataValueField = "ChannelId";
            DropChannel.DataTextField = "ChannelName";
            DropChannel.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //初始化链接类别
    public void InitLinkType()
    {
        try
        {
            DropLinkType.DataSource = LinkTypeBll.GetLinkTypeList();
            DropLinkType.DataTextField = "LinkName";
            DropLinkType.DataValueField = "LinkId";
            DropLinkType.DataBind();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //加载链接信息
    public void InitLinkInfo(string LinkId)
    {
        try
        {
            DataTable dt = LinkInfoBll.GetLinkById(LinkId);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtLinkName.Value = dt.Rows[0]["LinkInfoName"].ToString();
                DropChannel.SelectedValue = dt.Rows[0]["ChannelId"].ToString();
                DropLinkType.SelectedValue = dt.Rows[0]["LinkId"].ToString();
                txtLinkUrl.Value = dt.Rows[0]["LinkUrl"].ToString();
                txtSort.Value = (dt.Rows[0]["Sort"] == DBNull.Value) ? "" : dt.Rows[0]["Sort"].ToString();
                ViewState["odlLogo"] = Logo.ImageUrl = (dt.Rows[0]["Logo"] == DBNull.Value) ? "http://www.topfo.com/dservice/image/photo.jpg" : dt.Rows[0]["Logo"].ToString();
                txtRemarks.Value = (dt.Rows[0]["Remarks"] == DBNull.Value) ? "" : dt.Rows[0]["Remarks"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //上传Logo
    protected void UploadImg_Click(object sender, EventArgs e)
    {
        try
        {
            //图片上传
            if (this.File1.HasFile)
            {
                try
                {
                    imgBiz.Service serBiz = new imgBiz.Service(); //webservice

                    string loginName = DateTime.Now.ToString("yyyy"); //bp.LoginName;
                    HttpPostedFile mFile = File1.PostedFile;
                    string imgName = string.Empty;
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
                        if (serBiz.UpCrmImage(imgName, mFileByte, loginName) > 0)
                        {
                            //http://image.topfo.com/carimg/2011/2011630134033.jpg
                            ViewState["Logo"] = "http://image.topfo.com/carimg/" + loginName + "/" + imgName;
                            Logo.ImageUrl = "http://image.topfo.com/carimg/" + loginName + "/" + imgName;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('图片类型不对');</script>"); Response.End();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('error');</script>"); Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
