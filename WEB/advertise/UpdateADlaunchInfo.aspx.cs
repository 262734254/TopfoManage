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
public partial class advertise_UpdateADlaunchInfo : System.Web.UI.Page
{
    ADlaunchInfo model = new ADlaunchInfo();
    ADlaunchInfoManager manager = new ADlaunchInfoManager();
    public static int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Request.QueryString["infoID"] == null)
            {
                Response.Redirect("ADlaunchInfoList.aspx");
                int id = Convert.ToInt32(Request.QueryString["infoID"]);

            }

            Bind();

        }
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {

        model.addoc = txtDoc.Value.ToString();//备注

        model.Stardate =Convert.ToDateTime(txtStardate.Text);//开始时间
        model.advertiserID = Convert.ToInt32(Request.QueryString["infoID"]);
        model.enddate =Convert.ToDateTime(txtenddate.Text);//结束时间
        model.Givindate =Convert.ToDateTime(txtGivindate.Text);//赠送时间
        model.salesman = txtsalesman.Text.ToString();//业务员
        model.LoginName = txtLoginName.Text.ToString();//广告主
        model.countID =Convert.ToInt32(txtCount.Text.ToString());
        int num = manager.UpdatechannelInfo(model);
        if (num > 0)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.href='ADlaunchInfoList.aspx';</script>");


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
        model = manager.GetAllDlaunchInfoById(id);//根据ID查询信息
        txtDoc.Value = model.addoc.ToString();//备注
        txtenddate.Text =Convert.ToString(model.enddate);//结束日期
        txtGivindate.Text = Convert.ToString(model.Givindate);//赠送日期
        txtLoginName.Text = model.LoginName.ToString();//广告主
        txtsalesman.Text = model.salesman.ToString();//业务员
        txtStardate.Text = Convert.ToString(model.Stardate);//开始日期
        txtCount.Text =Convert.ToString( model.countID.ToString());

    }
    #endregion
}
