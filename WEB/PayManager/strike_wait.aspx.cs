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

public partial class PayManager_strike_wait : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        if (!Page.IsPostBack)
        {
            ViewState["pagesize"] = 20;
            ViewState["CurrPage"] = 1;
            ViewState["strWhere"] = "Status=0 and Status<>10";
            bind();
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PayManager_strike_wait));
    }
    [AjaxPro.AjaxMethod]
    public bool DeleteOrder(string orderlist)
    {
        Tz888.BLL.OrderManage dal = new Tz888.BLL.OrderManage();
        string[] a = orderlist.Split(',');
        bool b = true;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].Trim() != "")
            {
                b = dal.deleStrikeOrder(a[i].Trim(), 1);
            }
        }
        return b;
    }
    public void bind()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = ViewState["strWhere"].ToString();
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        long PageSize = Convert.ToInt64(ViewState["pagesize"]);

        DataTable dt = dal.GetList("StrikeOrderTab", "OID", "*", strWhere, "OID desc", ref CurrPage, PageSize, ref TotalCount);

        DataTable dtPoint = dal.GetList("StrikeOrderTab", "sum(TransMoney) as p", "p", 1, 1, 0, 1, strWhere);
        lblPoint.Text = dtPoint.Rows[0].ItemArray[0].ToString();

        lblCount.Text = TotalCount.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(PageSize)).ToString();
        lblCurrPage.Text = CurrPage.ToString();
        txtPage.Value = CurrPage.ToString();
        lblCount.Text = TotalCount.ToString();
        Pager();

        myList.DataSource = dt;
        myList.DataBind();
    }

    private void MakeCriteria(ref System.Text.StringBuilder Criteria)
    {
        Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "Status=", "0", false, false);
        Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "Status<>", "10", false, false);
        if (sType.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "PayType", sType.Value.Trim(), true, true);
        }
        if (!string.IsNullOrEmpty(this.txtBeginTime.Value.ToString().Trim()) && !string.IsNullOrEmpty(this.txtEndTime.Value.Trim()))
        {
            Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "PayTime", Convert.ToDateTime(this.txtBeginTime.Value.ToString().Trim()).ToShortDateString(), Convert.ToDateTime(this.txtEndTime.Value.Trim()).AddDays(1).ToShortDateString());
        }
        if (txtStrikeLoginName.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "StrikeLoginName=", txtStrikeLoginName.Value.Trim(), true, false);
        }
        if (txtLoginName.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "LoginName=", txtLoginName.Value.Trim(), true, false);
        }

    }

    #region 翻页
    public void Pager()
    {
        if (ViewState["CurrPage"].ToString() == lblPageCount.Text)
        {
            NextPage.Enabled = false;
            LastPage.Enabled = false;
            if (lblPageCount.Text != "1")
            {
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (Convert.ToInt32(ViewState["CurrPage"]) < Convert.ToInt32(lblPageCount.Text))
        {

            if (lblPageCount.Text != "1")
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (ViewState["CurrPage"].ToString() == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            if (Convert.ToInt32(lblPageCount.Text) > 1)
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
            }
        }
        if (lblCount.Text == "0" || lblCount.Text == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            NextPage.Enabled = false;
            LastPage.Enabled = false;
        }
    }
    protected void button_ServerClick(object sender, EventArgs e)
    {
        bind();
    }
    protected void FirstPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = 1;
        bind();
    }
    protected void PerPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) - 1;
        bind();
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) + 1;
        bind();
    }
    protected void LastPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = lblPageCount.Text;
        bind();
    }
    protected void btnGo_ServerClick(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = txtPage.Value.Trim();
        bind();
    }

    #endregion
    public string GetPayType(object str)
    {
        return Tz888.Common.Common.GetPayType(str.ToString());
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        MakeCriteria(ref sb);
        ViewState["strWhere"] = sb.ToString();
        bind();
    }
}
