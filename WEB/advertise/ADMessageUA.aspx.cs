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
using System.Text;
using Tz888.BLL.advertise;
using Tz888.Model.advertise;

public partial class advertise_ADMessageUA : System.Web.UI.Page
{
    private static ADMessageInfoBLL messageBll = new ADMessageInfoBLL();
    private static ADMessageInfo MessageInfo = new ADMessageInfo();
    private string fid = "";
    private string status = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        fid = Request["fid"].ToString();//ID
        status = Request["status"].ToString();//区分是添加还是修改
        if (!IsPostBack)
        {
            if (txtgiving.Value == "")
            {
                txtgiving.Value = DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (fid != "")
            {
                seladvister(Convert.ToInt32(fid));
            }
            PBName();
        }
    }
    /// <summary>
    /// 查询频道
    /// </summary>
    private void PBName()
    {
        this.ddlBName.DataSource = messageBll.SelChange();
        this.ddlBName.DataTextField = "BName";
        this.ddlBName.DataValueField = "BID";
        this.ddlBName.DataBind();
    }
    /// <summary>
    /// 根据ID获取所对于的信息
    /// </summary>
    /// <param name="id"></param>
    private void seladvister(int id)
    {
        MessageInfo = messageBll.SelMessage(id);//查询方法
        this.txtTypeName.Text = MessageInfo.TypeName.ToString();//广告名称
        this.ddlBName.SelectedValue = MessageInfo.BID.ToString();//频道
        this.txtSerial.Text = MessageInfo.SerialID.ToString();//序号
        this.txtsize.Text = MessageInfo.size.ToString();//尺寸大小
        this.txtprice.Text = MessageInfo.price.ToString();//价格
        this.txtgiving.Value = MessageInfo.giving.ToString();//赠送日期
        this.txtnote.Text = MessageInfo.note.ToString();//备注
        this.rblcheck.SelectedValue = MessageInfo.checkid.ToString();//激活状态
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        long num;
        MessageInfo.TypeName = this.txtTypeName.Text;
        MessageInfo.BID =Convert.ToInt32(this.ddlBName.SelectedValue.ToString());
        MessageInfo.SerialID = this.txtSerial.Text;
        MessageInfo.size = this.txtsize.Text;
        MessageInfo.price = float.Parse(this.txtprice.Text.ToString());
        MessageInfo.giving = Convert.ToDateTime(this.txtgiving.Value.ToString());
        MessageInfo.note = this.txtnote.Text;
        MessageInfo.checkid = Convert.ToInt32(this.rblcheck.SelectedValue);
        if (status == "insert")
        {
            num = messageBll.AddMessage(MessageInfo);
            if (num > 0)
            {
                Response.Write("<script>alert('添加成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败！')</script>");
            }
        }
        else if (status == "status")
        {
            num = messageBll.UpdateMessage(MessageInfo,Convert.ToInt32(fid));
            if (num > 0)
            {
                Response.Write("<script>alert('修改成功！');window.location.href='ADMessageInfo.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败！');history.back(-1);</script>");
            }
        }
    }
    protected void btnsel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ADMessageInfo.aspx");
    }
}
