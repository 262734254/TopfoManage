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

public partial class wyzs_AddWyzsInfo : System.Web.UI.Page
{
    private MainInfoBLL bll = new MainInfoBLL();
    private readonly BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(bp.LoginName))
        {

        }
    }

    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        //主表信息
        MainInfoTab MainInfo = new MainInfoTab();
        //标题
        MainInfo.Title = txtTitle.Value.Trim();
        //会员名
        MainInfo.MemberId = "会员名";
        //类别
        MainInfo.Types = Convert.ToInt32(txtTypes.SelectedValue);
        //状态(1->可用,2->不可用)
        MainInfo.State = 2;
        //静态地址
        MainInfo.Htmlurl = "";
        //发布时间
        MainInfo.PublishTime = DateTime.Now;

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
        if (bll.Add(MainInfo, Detail))
        {
            Tz888.Common.MessageBox.ShowAndHref("添加成功!", "WyzsInfoManage.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.ShowAndHref("添加失败!", "WyzsInfoManage.aspx");
        }
    }
}
