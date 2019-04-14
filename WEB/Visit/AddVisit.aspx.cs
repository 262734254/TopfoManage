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
using Tz888.Model.Visit;
using Tz888.BLL.Visit;

public partial class Visit_AddVisit : System.Web.UI.Page
{
    private static VisitInfoModel VisitMoble =new VisitInfoModel();
    private static Tz888.Model.Register.MemberInfoModel member = new Tz888.Model.Register.MemberInfoModel();
    private static VisitInfoBLL VisitBll = new VisitInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          string name = Request["LoginName"].ToString().Trim();
           
          int add = Convert.ToInt32(Request["num"].ToString().Trim());
         
           ViewState["num"] = add;
            ViewState["LoginName"] = name;
            LN(name);
            SelVisitBll(name);
        }
    }
    /// <summary>
    /// 绑定用户详细信息
    /// </summary>
    /// <param name="num"></param>
    private void LN(string num)
    {
        member = VisitBll.SelLogin(num);
        this.lblTypeName.InnerHtml=member.LoginName;
        this.lblMemberType.InnerHtml = VisitBll.SelManageType(member.ManageTypeID);
        this.lblNickName.InnerHtml= member.NickName ;
        this.lblCounty.InnerHtml= VisitBll.SelCountry(member.CountryCode.ToString().Trim()) + " " + VisitBll.SelProvince(member.ProvinceID.ToString().Trim()) + " " + VisitBll.SelCounty(member.CountyID.ToString().Trim()) ;
        this.lblMemberName.InnerHtml = member.MemberName;
        this.lblTel.InnerHtml = member.Tel;
        this.lblMobile.InnerHtml = member.Mobile;
        this.lblEmail.InnerHtml = member.Email;
        this.lblAddress.InnerHtml = member.Address;
        this.lblPostCode.InnerHtml = member.PostCode;
    }
    /// <summary>
    /// 修改时，绑定回访记录
    /// </summary>
    /// <param name="num"></param>
    private void SelVisitBll(string num)
    {
        int com=VisitBll.SelLoginName(num);
        if (com > 0)
        {
            VisitMoble = VisitBll.SelVisit(num);
            string Disp = VisitMoble.Disposition;
            string DispItems;
            for (int i = 0; i < cblDisposition.Items.Count; i++)
            {
                DispItems = cblDisposition.Items[i].Value;
                if (Disp.IndexOf(DispItems) != -1)
                    cblDisposition.Items[i].Selected = true;
            }
            this.txtTel.Text = VisitMoble.Mobile;//手机
            this.txtEmail.Text = VisitMoble.Email;//邮箱
            this.txtTime.Value = VisitMoble.VisitTime.ToString();//回访时间
            this.txtCaption.Value = VisitMoble.Caption.ToString().Trim();//需求说明
            this.txtRemark.Value = VisitMoble.Remark.ToString().Trim();//备注
            this.rblVaild.SelectedValue = VisitMoble.Valid.ToString();//是否有效
            this.rblVaildNew.SelectedValue = VisitMoble.VisitNew.ToString();//是否回访
        }
    }
    /// <summary>
    /// 添加和修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        VisitInfoModel VisitMoble =new VisitInfoModel();
        VisitInfoBLL VisitBll = new VisitInfoBLL();
        VisitMoble.LoginName =Convert.ToString(ViewState["LoginName"].ToString());//用户名
        VisitMoble.Disposition =GetCheckBoxList(cblDisposition).Trim();//需求意向
        VisitMoble.Mobile = this.txtTel.Text.Trim();//手机
        VisitMoble.Email = this.txtEmail.Text.Trim();//电子邮箱
        VisitMoble.VisitTime =Convert.ToDateTime(this.txtTime.Value.Trim());//回访时间
        VisitMoble.Caption = this.txtCaption.Value.Trim();//回访说明
        VisitMoble.Remark = this.txtRemark.Value.Trim();//回访备注
        VisitMoble.Valid =Convert.ToInt32(this.rblVaild.SelectedValue.Trim());//是否有效
        VisitMoble.VisitNew =Convert.ToInt32(this.rblVaildNew.SelectedValue.Trim());//是否回访
        int num=VisitBll.SelLoginName(Convert.ToString(ViewState["LoginName"]));//判断用户名是否存在表中
        int com = 0;
        if (num <= 0)//如果用户名不存在表中，就执行添加。否则，修改
        {
            com = VisitBll.AddVisit(VisitMoble);
            if (com >= 0)
            {
                Response.Write("<script>alert('添加成功！');</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！');</script>");
            }
        }
        else
        {
            com = VisitBll.ModfiyVisit(VisitMoble,Convert.ToString(ViewState["LoginName"]));
            if (com >= 0)
            {
                Response.Write("<script>alert('修改成功！');window.location.href='SelVisit.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！');</script>");
            }
        }
    }

    public static string GetCheckBoxList(CheckBoxList cbl)
    {
        string strValue = "";
        for (int i = 0; i <cbl.Items.Count; i++)
        {
            if (cbl.Items[i].Selected)
            {
                strValue = strValue + cbl.Items[i].Value.Trim() + ",";
            }
        }
        return strValue;
    }
    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnqu_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["num"]) == 1)
        {
            Response.Redirect("SelVisit.aspx");
        }
        else if (Convert.ToInt32(ViewState["num"]) == 2)
        {
            Response.Redirect("SelVisitLogin.aspx");
        }
    }
}
