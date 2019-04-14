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

public partial class advertise_AddchannelInfo : System.Web.UI.Page
{
    ADchannelInfoManager manager = new ADchannelInfoManager();  //实例化对象
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  /// <summary>
  /// 添加频道
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        ADchannelInfo model = new ADchannelInfo();
        model.BName = txtName.Text.ToString(); //名称
        model.BDoc = txtDoc.Value.ToString();//备注
        int num = manager.Add(model);//添加方法
        if (num > 0)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.href='channelInfoList.aspx';</script>");


        }
        else
        {
            Response.Write("<script>alert('添加失败！');</script>");
        }
    }
}
