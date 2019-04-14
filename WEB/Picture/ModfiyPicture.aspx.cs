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

public partial class Picture_ModfiyPicture : System.Web.UI.Page
{
    private readonly PictureBLL bll = new PictureBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string PictureId = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(PictureId))
                {
                    InitFenZhan();
                    InitPictureInfo(PictureId);
                }
                else
                {
                    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "参数错误!", "VideoList.aspx", false);
                }
            }
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

    public void InitPictureInfo(string PictureId)
    {
        try
        {
            DataTable dt = bll.GetPictureDetail(PictureId);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtTitle.Value = row["Title"].ToString();
                txtImgUrl.Value = row["ImgUrl"].ToString();
                DropSource.SelectedValue = row["SourceId"].ToString();
                DropShowPosition.SelectedValue = row["ShowId"].ToString();
                RadioRecommend.SelectedValue = row["IsRecommend"].ToString();
                DropDownListType.SelectedValue = row["TypeId"].ToString();
                txtTarget.Value = row["Target"].ToString();
                txtRemarks.Value = (row["Remarks"].ToString() == "") ? "" : row["Remarks"].ToString();

                DropShowPosition.SelectedValue = row["ShowId"].ToString();
            }
        }
        catch (Exception ex)
        {
            Tz888.Common.MessageBox.Show(this.Page, ex.Message);
        }
    }

    protected void BtnModfiy_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                string PictureId = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(PictureId))
                {
                    PictureInfo Picture = new PictureInfo();
                    Picture.Id = Convert.ToInt32(PictureId);
                    Picture.Title = Tz888.Common.Utility.PageValidate.HtmlEncode(txtTitle.Value.Trim());
                    Picture.ImgUrl = Tz888.Common.Utility.PageValidate.HtmlEncode(txtImgUrl.Value.Trim());
                    Picture.Target = Tz888.Common.Utility.PageValidate.HtmlEncode(txtTarget.Value.Trim());
                    Picture.SourceId = Convert.ToInt32(DropSource.SelectedValue);
                    Picture.IsRecommend = Convert.ToInt32(RadioRecommend.SelectedValue.Trim());
                    Picture.TypeId = Convert.ToInt32(DropDownListType.SelectedValue.Trim());
                    Picture.ShowId = Convert.ToInt32(DropShowPosition.SelectedValue.Trim());
                    Picture.Remarks = Tz888.Common.Utility.PageValidate.HtmlEncode(txtRemarks.Value.Trim());

                    if (bll.ModfiyPicture(Picture))
                    {
                        Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改成功!", "PictureList.aspx", false);
                    }
                    else
                    {
                        Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改失败!", "PictureList.aspx", false);
                    }
                }
                else
                {
                    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "参数错误!", "PictureList.aspx", false);
                }
            }
        }
        catch (Exception ex)
        {
            Tz888.Common.MessageBox.Show(this.Page, ex.Message);
        }
    }
}
