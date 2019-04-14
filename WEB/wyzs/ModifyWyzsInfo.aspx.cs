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
using Tz888.BLL.wyzs;
using Tz888.Model.wyzs;

public partial class wyzs_ModifyWyzsInfo : System.Web.UI.Page
{
    private readonly MainInfoBLL bll = new MainInfoBLL();
    private readonly BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(bp.LoginName))
            { 
                
            }
            if (Request.QueryString["MainId"] != null && Request.QueryString["Types"] != null)
            {
                string Types = Request.QueryString["Types"].ToString();
                string MainId = Request.QueryString["MainId"];
                if (Types == "Modify")
                {
                    BtnModify.Text = "修改";
                }
                else if (Types == "Review")
                { 
                    BtnModify.Text="审核";
                }
                InitData(MainId);
            }
        }
    }

    public void InitData(string MainId)
    {
        DataSet ds = bll.GetDetailById(MainId);
        if (ds != null && ds.Tables.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                //标题
                txtTitle.Value = row["Title"].ToString();
                //联系电话
                txtTelePhone.Value = row["TelePhone"].ToString();
                //邮箱
                txtEmail.Value = row["Email"].ToString();
                //联系人
                txtLinkMan.Value = row["LinkMan"].ToString();
                //类型(1->求租,2->购买,3->出租,4->出售)
                txtTypes.SelectedValue = row["Types"].ToString();

                //子表信息
                //来源(1->业主,2->需求)
                txtSource.SelectedValue = row["Source"].ToString();
                //用途(1->门面,2->办公,3->商住两用)
                txtPurpose.SelectedValue = row["Purpose"].ToString();
                //楼层(1->1-5楼,2->5-8楼,3->8楼以上)
                txtFloor.SelectedValue = row["Floor"].ToString();
                //租金(1->40-60元/平方米,2->60-80元/平方米,3->80元以上)
                txtHire.SelectedValue = row["Hire"].ToString();
                //面积(1->100平米以内,2->100-200平米,3->200平米以上)
                txtArea.SelectedValue = row["Area"].ToString();
                //装修(1->简装,2->无,3->豪装)
                txtFitment.SelectedValue = row["Fitment"].ToString();
                //电梯(1->有,2->无)
                txtElevator.SelectedValue = row["Elevator"].ToString();
            }
        }
    }

    protected void BtnModify_Click(object sender, EventArgs e)
    {
        //主表信息
        MainInfoTab MainInfo = new MainInfoTab();
        MainInfo.Id = Convert.ToInt32(Request.QueryString["MainId"].ToString());
        //标题
        MainInfo.Title = txtTitle.Value.Trim();
        //会员名
        MainInfo.MemberId = "会员名";
        //类别
        MainInfo.Types = Convert.ToInt32(txtTypes.SelectedValue);

        //子表信息
        DetailTab Detail = new DetailTab();
        //联系电话
        Detail.TelePhone = txtTelePhone.Value.Trim();
        //邮箱
        Detail.Email = txtEmail.Value;
        //联系人
        Detail.LinkMan = txtLinkMan.Value;
        //来源(1->业主,2->需求)
        Detail.Source = Convert.ToInt32(txtSource.SelectedValue);
        //用途(1->门面,2->办公,3->商住两用)
        Detail.Purpose = Convert.ToInt32(txtPurpose.SelectedValue);
        //楼层(1->1-5楼,2->5-8楼,3->8楼以上)
        Detail.Floor = Convert.ToInt32(txtFloor.SelectedValue);
        //租金(1->40-60元/平方米,2->60-80元/平方米,3->80元以上)
        Detail.Hire = Convert.ToInt32(txtHire.SelectedValue);
        //面积(1->100平米以内,2->100-200平米,3->200平米以上)
        Detail.Area = Convert.ToInt32(txtArea.SelectedValue);
        //装修(1->简装,2->无,3->豪装)
        Detail.Fitment = Convert.ToInt32(txtFitment.SelectedValue);
        //电梯(1->有,2->无)
        Detail.Elevator = Convert.ToInt32(txtElevator.SelectedValue);

        string Types = Request.QueryString["Types"].ToString();
        if (Types == "Modify")
        {
            if (bll.Modify(MainInfo, Detail))
            {
                Tz888.Common.MessageBox.ShowAndHref("修改成功!", "WyzsInfoManage.aspx");
            }
            else
            {
                Tz888.Common.MessageBox.ShowAndHref("修改成功!", "WyzsInfoManage.aspx");
            }
        }
        else if (Types == "Checked")
        {
            
        }
    }
}
