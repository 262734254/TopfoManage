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
using Tz888.Common;
using System.Data.SqlClient;
using Tz888.BLL.advertise;
using Tz888.Model.advertise;

public partial class advertise_AddDlaunchInfo : System.Web.UI.Page
{
    ADMessageInfoBLL manager = new ADMessageInfoBLL();
    ADlaunchInfoManager infomanager = new ADlaunchInfoManager();//实例化对象
    ADlaunchInfo model = new ADlaunchInfo();//实例化实体类
    BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int Bid = Convert.ToInt32(Request.QueryString["Bid"]);
            int fid = Convert.ToInt32(Request.QueryString["fid"]);
            if (Bid == 0 && fid==0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('错误操作！');window.location.href='ADMessageInfo.aspx';</script>");

            }
            
        }
        txtsalesman.Text = bp.LoginName;
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        txtsalesman.Text = bp.LoginName;
        int Bid = Convert.ToInt32(Request.QueryString["Bid"]);
        int fid = Convert.ToInt32(Request.QueryString["fid"]);
        //string LoginName = bp.LoginName;
        model.Addates = Convert.ToDateTime(DateTime.Now);  //创建时间
        model.addoc = txtDoc.Value.ToString(); //备注
        model.BID = Bid;//频道ID
        model.countID = 0;//访问量
        model.enddate = Convert.ToDateTime(txtenddate.Value.ToString().Trim());//结束日期
        model.Givindate = Convert.ToDateTime(txtGivindate.Value.ToString().Trim());//赠送日期
        model.LoginName = txtLoginName.Text.ToString();//广告主帐号
        model.salesman = txtsalesman.Text.ToString();//业务员
        model.Stardate =Convert.ToDateTime(txtStardate.Value.ToString().Trim());//开始时间
        model.positionID = fid;//广告ID
        int num = infomanager.Add(model);//添加方法
        if (num>0 )
        {


            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.href='ADlaunchInfoList.aspx';</script>");


        }
        else
        {
            Response.Write("<script>alert('添加失败！');</script>");
        }
        

    }
}
