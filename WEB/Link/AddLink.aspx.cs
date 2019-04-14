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

public partial class Link_AddLink : System.Web.UI.Page
{
    private readonly Tz888.BLL.Link.LinkChannelType ChannelBll = new Tz888.BLL.Link.LinkChannelType();
    private readonly Tz888.BLL.Link.LinkInfoTab LinkInfoBll = new Tz888.BLL.Link.LinkInfoTab();
    private readonly Tz888.BLL.Link.LinkTypeTab LinkTypeBll = new Tz888.BLL.Link.LinkTypeTab();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetChannel();
            SetLinkType();
        }
    }

    //添加链接
    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        try
        {
            Tz888.Model.Link.LinkInfoTab Model = new Tz888.Model.Link.LinkInfoTab();
            Model.LinkInfoName = Tz888.Common.Utility.PageValidate.HtmlEncode(txtLinkName.Value.Trim());
            Model.ChannelId = Convert.ToInt32(DropChannel.SelectedValue);
            Model.LinkId = Convert.ToInt32(DropLinkType.SelectedValue);
            Model.LinkUrl = Tz888.Common.Utility.PageValidate.HtmlEncode(txtLinkUrl.Value.Trim());
            Model.Logo = (ViewState["Log"] == null) ? "" : ViewState["Log"].ToString();
            Model.Remarks = Tz888.Common.Utility.PageValidate.HtmlEncode(txtRemarks.Value.Trim());
            Model.Sort = (txtSort.Value.Trim() == "") ? 0 : Convert.ToInt32(txtSort.Value.Trim());

            if (LinkInfoBll.AddLink(Model))
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功!", "LinkManage.aspx", false);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "添加失败!");
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
                        ViewState["Log"] = "http://image.topfo.com/carimg/" + loginName + "/" + imgName;
                        this.Message.Text = "上传图片成功";
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

    //频道
    public void SetChannel()
    {
        try
        {
            DropChannel.DataSource = ChannelBll.GetChannelList();
            DropChannel.DataValueField = "ChannelId";
            DropChannel.DataTextField = "ChannelName";
            DropChannel.DataBind();

            ListItem item = new ListItem();
            item.Text = "请选择频道";
            item.Value = "0";
            DropChannel.Items.Insert(0, item);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //链接类别
    public void SetLinkType()
    {
        try
        {
            DropLinkType.DataSource = LinkTypeBll.GetLinkTypeList();
            DropLinkType.DataValueField = "LinkId";
            DropLinkType.DataTextField = "LinkName";
            DropLinkType.DataBind();

            ListItem item = new ListItem();
            item.Text = "请选择类别";
            item.Value = "0";
            DropLinkType.Items.Insert(0, item);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
