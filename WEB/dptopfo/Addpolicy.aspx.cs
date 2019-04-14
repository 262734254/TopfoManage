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
using GZS.Model.policy;
using GZS.BLL.policy;
using GZS.BLL;
public partial class admin_Addpolicy : System.Web.UI.Page
{
    PolicyBll bll = new PolicyBll();
    PolicyModel policy = new PolicyModel();
    public string titles = "";
    private string loginName = "";
    BasePage db = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["loginName"].ToString()))
            {
                loginName = Request.QueryString["loginName"].ToString();
                ViewState["loginName"] = loginName.ToString();
                if (bll.ExistsName(loginName))
                {
                    //titles = "修改优惠政策";
                    btnUpdate.Visible = true;
                    Button1.Visible = false;
                    bindModel(loginName);
                }
                else
                {
                    //titles = "添加优惠政策";
                    Button1.Visible = true;
                }
            }
        }
    }
    private void bindModel(string loginname)
    {
        policy = bll.GetPolicyByName(loginname);
        policyId.Value = policy.policyId.ToString();
        txtClick.Text = policy.Clicks.ToString();
        txtChina.Text = policy.Chineseintroduced;
        txtEnglish.Text = policy.Englishintroduction;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        loginName = ViewState["loginName"].ToString();
        policy.loginName = loginName;
        policy.Chineseintroduced = txtChina.Text.Trim();
        policy.Englishintroduction = txtEnglish.Text.Trim();
        policy.htmlUrl = "Preferentialpolicies.htm";
        int num = bll.Add(policy);
        if (num > 0)
        {
            policyId.Value = num.ToString();
            PolicyStatic sta = new PolicyStatic();
            if (sta.StaticHtml(num, loginName) <= 0)
            {
                Response.Write("<script>alert('添加失败！');</script>");
            }
            else
            {
                //Response.Redirect("Addpolicy.aspx");
                //AreaIndexBLL areaBll = new AreaIndexBLL();
                //areaBll.AreaHtml(loginName,8);
                sta.StaticHtml(loginName);
                btnUpdate.Visible = true;
                Button1.Visible = false;
                Response.Write("<script>alert('添加成功！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('添加失败！');</script>");

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        loginName = ViewState["loginName"].ToString();
        policy = bll.GetModel(int.Parse(policyId.Value.ToString()));
        policy.Chineseintroduced = txtChina.Text.Trim();
        policy.Englishintroduction = txtEnglish.Text.Trim();
        if (string.IsNullOrEmpty(policy.htmlUrl))
        {
            policy.htmlUrl = "Preferentialpolicies.htm";
        }
        if (bll.Update(policy))
        {
            PolicyStatic sta = new PolicyStatic();
            if (sta.StaticHtml(int.Parse(policyId.Value.ToString()), loginName) <= 0)
            {
                Response.Write("<script>alert('修改失败！');</script>");
                //Response.Write("<script>alert('修改失败！');document.location='Addpolicy.aspx'</script>");
            }
            else
            {
                //AreaIndexBLL areaBll = new AreaIndexBLL();
                //areaBll.AreaHtml(loginName, 8);
                sta.StaticHtml(loginName);
                Response.Write("<script>alert('修改成功！');location.href='PolicyManage.aspx';</script>");

            }
        }
        else
        {
            Response.Write("<script>alert('修改失败！');</script>");

        }

    }
}
