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
using GZS.Model.Invest;
using GZS.BLL.Invest;
public partial class admin_AddNewInvest : System.Web.UI.Page
{
    InvestCostBLL costBll = new InvestCostBLL();
    InvestCostM costM = new InvestCostM();
    StaticInvest sta = new StaticInvest();
    BasePage db = new BasePage();

    public string titles = "";
    private string loginName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ViewState["id"] = "";
            if (!string.IsNullOrEmpty(Request.QueryString["LoginName"].ToString()))
            {
                loginName = Request.QueryString["LoginName"].ToString();
                ViewState["LoginName"] = loginName.ToString();
                if (costBll.ExistsName(loginName))
                {
                    //titles = "修改";
                    btnUpdate.Visible = true;
                    Button1.Visible = false;
                    bindModel(loginName);
                }
                else
                {
                    //titles = "添加";
                    Button1.Visible = true;
                }
            }
        }
    }
    protected void bindModel(string loginName)
    {
        costM = costBll.GetModels(loginName);
        //ViewState["id"] = costM.Costid.ToString();
        txtChina.Text = costM.Chineseintroduced.ToString();
        txtEnglish.Text = costM.Englishintroduction.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        loginName = ViewState["LoginName"].ToString();
        costM.Chineseintroduced = txtChina.Text.ToString();
        costM.Englishintroduction = txtEnglish.Text.ToString();
        costM.loginName = loginName;
        costM.hits = 0;
        int num = costBll.Add(costM);
        if (num > 0)
        {

            sta.StaticHtml(num, loginName);
            btnUpdate.Visible = true;
            Button1.Visible = false;
            Response.Write("<script>alert('添加成功！');</script>");
        }
        else
        {
            Response.Write("<script>alert('添加失败！');</script>");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        loginName = ViewState["LoginName"].ToString();
        //costM.Costid = int.Parse(ViewState["id"].ToString());
        costM = costBll.GetModels(loginName);
        costM.Chineseintroduced = txtChina.Text.ToString();
        costM.Englishintroduction = txtEnglish.Text.ToString();
        costM.loginName = loginName;
        costM.hits = 0;
        if (costBll.Update(costM))
        {
            sta.StaticHtml(0, loginName);
            Response.Write("<script>alert('修改成功！');location.href='InvestManage.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('修改失败！');</script>");
        }
    }

}

