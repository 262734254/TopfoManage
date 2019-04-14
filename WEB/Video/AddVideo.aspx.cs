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
using Tz888.BLL.Video;
using Tz888.Model.Video;
using Tz888.BLL.FenZhan;

public partial class Video_AddVideo : System.Web.UI.Page
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


    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        VideoBLL bll=new VideoBLL();
        VideoInfo Video = new VideoInfo();
        Video.Title = Tz888.Common.Utility.PageValidate.HtmlEncode(txtTitle.Value.Trim());
        Video.ImgUrl = Tz888.Common.Utility.PageValidate.HtmlEncode(txtImgUrl.Value.Trim());
        Video.VodeoUrl = Tz888.Common.Utility.PageValidate.HtmlEncode(txtVideoUrl.Value.Trim());
        Video.VideoType = Convert.ToInt32(DropVideoType.SelectedValue.Trim());
        Video.Type = Convert.ToInt32(Dropzhuanti.SelectedValue);
        Video.IsRecommend = Convert.ToInt32(RadioRecommend.SelectedValue.Trim());
        Video.ShowId = Convert.ToInt32(DropShowPosition.SelectedValue.Trim());
        Video.SortId = (txtSort.Value.Trim() == "") ? 0 : Convert.ToInt32(txtSort.Value.Trim());
        Video.Remarks = Tz888.Common.Utility.PageValidate.HtmlEncode(txtRemarks.Value.Trim());

        if (bll.AddVideo(Video))
        {
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功!", "VideoList.aspx", false);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "添加失败!");
        }
    }
}
