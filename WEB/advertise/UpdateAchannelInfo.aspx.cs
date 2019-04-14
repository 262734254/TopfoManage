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
using System.Data.SqlClient;
using Tz888.BLL.advertise;
using Tz888.Model.advertise;
public partial class advertise_UpdateAchannelInfo : System.Web.UI.Page
{
    ADchannelInfo model = new ADchannelInfo();
    ADchannelInfoManager manager = new ADchannelInfoManager();
    public static int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["infoID"] == null)
            {
                Response.Redirect("channelInfoList.aspx");
                int id = Convert.ToInt32(Request.QueryString["infoID"]);
              
            }
       
            Bind();

        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {

        model.BName = txtName.Text.ToString();
        model.BDoc = txtDoc.Value.ToString();
        model.BID = int.Parse(Request.Params["infoID"].ToString());
        int num = manager.UpdatechannelInfo(model);
        if (num > 0)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.href='channelInfoList.aspx';</script>");


        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败！');", true);
        }
    }
    #region 加载绑定显示
    /// <summary>
    /// 显示信息绑定
    /// </summary>
    protected void Bind()
    {

        int id = Convert.ToInt32(Request.QueryString["infoID"]);
        model = manager.GetAllchannelInfoById(id);
        txtName.Text = model.BName.ToString();
        txtDoc.Value = model.BDoc.ToString();

    }
    #endregion
}
