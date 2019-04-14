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
using System.Data;
using Tz888.BLL.Video;
using Tz888.Model.Video;
using Tz888.BLL.FenZhan;     

public partial class Video_ModfiyVideo : System.Web.UI.Page
{
    private readonly VideoBLL bll = new VideoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            { 
                string VideoId = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(VideoId))
                {
                    InitFenZhan();
                    InitVideoInfo(VideoId);
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

    public void InitVideoInfo(string VideoId)
    {
        try
        {
            DataTable dt = bll.GetVideoDetailById(VideoId);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtTitle.Value = row["Title"].ToString();
                txtImgUrl.Value = row["ImgUrl"].ToString();
                txtVideoUrl.Value = row["VideoUrl"].ToString();
                DropVideoType.SelectedValue = row["VideoType"].ToString();
                DropShowPosition.SelectedValue = row["ShowId"].ToString();
                Dropzhuanti.SelectedValue = row["Type"].ToString();
                txtSort.Value = row["SortId"].ToString();
                RadioRecommend.SelectedValue = row["IsRecommend"].ToString();
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
                string VideoId = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(VideoId))
                {
                    VideoInfo Video = new VideoInfo();
                    Video.Id = Convert.ToInt32(VideoId);
                    Video.Title = Tz888.Common.Utility.PageValidate.HtmlEncode(txtTitle.Value.Trim());
                    Video.ImgUrl = Tz888.Common.Utility.PageValidate.HtmlEncode(txtImgUrl.Value.Trim());
                    Video.VodeoUrl = Tz888.Common.Utility.PageValidate.HtmlEncode(txtVideoUrl.Value.Trim());
                    Video.VideoType = Convert.ToInt32(DropVideoType.SelectedValue.Trim());
                    Video.IsRecommend = Convert.ToInt32(RadioRecommend.SelectedValue.Trim());
                    Video.ShowId = Convert.ToInt32(DropShowPosition.SelectedValue.Trim());
                    Video.SortId = (txtSort.Value.Trim() == "") ? 0 : Convert.ToInt32(txtSort.Value.Trim());
                    Video.Remarks = Tz888.Common.Utility.PageValidate.HtmlEncode(txtRemarks.Value.Trim());
                    Video.Type = Convert.ToInt32(Dropzhuanti.SelectedValue);
                    if (bll.ModfiyVideo(Video))
                    {
                        Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改成功!", "VideoList.aspx", false);
                    }
                    else
                    {
                        Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改失败!", "VideoList.aspx", false);
                    }
                }
                else
                {
                    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "参数错误!", "VideoList.aspx", false);
                }
            }
        }
        catch (Exception ex)
        {
            Tz888.Common.MessageBox.Show(this.Page, ex.Message);
        }
    }
}
