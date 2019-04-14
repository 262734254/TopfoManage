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
using Tz888.BLL.Picture;
using Tz888.Model.Picture;
using Tz888.BLL.FenZhan;

public partial class Picture_AddPicture : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitFenZhan();
        }
    }

    public void InitFenZhan()
    {
        FenZhanBLL bll = new FenZhanBLL();
        DataTable dt = bll.GetFenZhanList();
        if (dt != null && dt.Rows.Count > 0)
        {
            DropShowPosition.DataSource = dt;
            DropShowPosition.DataValueField = "ProvinceID";
            DropShowPosition.DataTextField = "FenZhanName";
            DropShowPosition.DataBind();
        }

        ListItem item = new ListItem();
        item.Value = "0";
        item.Text = "所有分站";
        DropShowPosition.Items.Insert(0, item);
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        PictureBLL bll = new PictureBLL();
        PictureInfo Picture = new PictureInfo();
        Picture.Title = Tz888.Common.Utility.PageValidate.HtmlEncode(txtTitle.Value.Trim());
        Picture.ImgUrl = Tz888.Common.Utility.PageValidate.HtmlEncode(txtImgUrl.Value.Trim());
        Picture.Target = Tz888.Common.Utility.PageValidate.HtmlEncode(txtTarget.Value.Trim());
        Picture.SourceId = Convert.ToInt32(DropSource.SelectedValue.Trim());
        Picture.IsRecommend = Convert.ToInt32(RadioRecommend.SelectedValue.Trim());
        Picture.TypeId = Convert.ToInt32(DropDownListType.SelectedValue.Trim());
        Picture.ShowId = Convert.ToInt32(DropShowPosition.SelectedValue.Trim());
        Picture.Remarks = Tz888.Common.Utility.PageValidate.HtmlEncode(txtRemarks.Value.Trim());

        if (bll.AddPicture(Picture))
        {
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功!", "PictureList.aspx", false);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "添加失败!");
        }
    }
}

