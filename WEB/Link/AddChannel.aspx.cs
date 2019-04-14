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

public partial class Link_AddChannel : System.Web.UI.Page
{
    private readonly Tz888.BLL.Link.LinkChannelType bll = new Tz888.BLL.Link.LinkChannelType();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        try
        {
            Tz888.Model.Link.LinkChannelType Channel = new Tz888.Model.Link.LinkChannelType();
            Channel.ChannelName = Tz888.Common.Utility.PageValidate.HtmlEncode(txtChannelName.Value.Trim());
            Channel.CheckId = 0;
            Channel.Remarks = Tz888.Common.Utility.PageValidate.HtmlEncode(txtRemarks.Value.Trim());
            if (bll.AddChannel(Channel))
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功!", "ChannelManage.aspx", false);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "添加失败");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
