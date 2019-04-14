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
using System.Text.RegularExpressions;
using System.Data;

public partial class Link_ChannelExamine : System.Web.UI.Page
{
    private readonly Tz888.BLL.Link.LinkChannelType Channel = new Tz888.BLL.Link.LinkChannelType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ChannelId"] != null)
            {
                string ChannelId = Request.QueryString["ChannelId"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(ChannelId))
                {
                    ViewState["ChannelId"] = ChannelId;
                    LoadChannel(ChannelId);
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
                }
            }
        }
    }

    //频道审核
    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        try
        {
            Tz888.Model.Link.LinkChannelType model = new Tz888.Model.Link.LinkChannelType();
            model.ChannelId = Convert.ToInt32(ViewState["ChannelId"].ToString());
            model.ChannelName = Tz888.Common.Utility.PageValidate.HtmlEncode(txtChannelName.Value.Trim());
            model.CheckId = Convert.ToInt32(rblAuditing.SelectedValue);
            model.Remarks = Tz888.Common.Utility.PageValidate.HtmlEncode(txtRemarks.Value.Trim());

            if (Channel.UpdateChannelById(model))
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "审核成功!", "ChannelManage.aspx", false);
            }
            else
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "审核失败!", "ChannelManage.aspx", false);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //加载频道
    public void LoadChannel(string ChannelId)
    {
        try
        {
            DataTable dt = Channel.GetChannelById(ChannelId);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtChannelName.Value = dt.Rows[0]["ChannelName"].ToString();
                rblAuditing.SelectedValue = dt.Rows[0]["CheckId"].ToString();
                txtRemarks.Value = (dt.Rows[0]["Remarks"] == DBNull.Value) ? "" : dt.Rows[0]["Remarks"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
