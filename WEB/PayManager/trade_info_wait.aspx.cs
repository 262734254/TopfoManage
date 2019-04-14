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
public partial class PayManager_trade_info_wait : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!Page.IsPostBack)
        {
            ViewState["pagesize"] = 20;
            ViewState["CurrPage"] = 1;
            StringBuilder strB = new StringBuilder();
            MakeCriteria(ref strB);
            ViewState["strWhere"] = strB.ToString();
            bind();
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PayManager_trade_info_wait));

    }
    [AjaxPro.AjaxMethod]
    public bool DeleteShopCar(string shopcar)
    {
        Tz888.BLL.Pay dal = new Tz888.BLL.Pay();
        bool b = true;
        string[] a = shopcar.Split(',');
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].Trim() != "")
            {
                b = dal.ShopCar_Delete(Convert.ToInt64(a[i].Trim()));
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


        DataTable dt = dal.GetList("ShopCarVIW", "ShopCarID", "*", strWhere, "ShopCarID desc", ref CurrPage, PageSize, ref TotalCount);


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
        System.Text.StringBuilder titleCrireria = new System.Text.StringBuilder();
        Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "InfoID=", txtInfoID.Value.Trim(), false, false);
        Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "OrderNo=", txtOrderNo.Value.Trim(), false, false);
        Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "orderNo>", "0", true, false);

     
        if (!string.IsNullOrEmpty(this.txtBeginTime.Value.ToString().Trim()) && !string.IsNullOrEmpty(this.txtEndTime.Value.Trim()))
        {
            Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "PackDate", Convert.ToDateTime(this.txtBeginTime.Value.ToString().Trim()).ToShortDateString(), Convert.ToDateTime(this.txtEndTime.Value.Trim()).AddDays(1).ToShortDateString());
        }
        if (ddltype.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "InfoTypeID", ddltype.Value.Trim(), true, true);
        }
        if (ddluserType.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "ManageTypeID", ddluserType.Value.Trim(), true, true);
        }
        if (txtLoginName.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "LoginName", txtLoginName.Value.Trim(), true, true);
        }
        if (txtTitle.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "SourceType", txtTitle.Value.Trim(), true, true);
        }
        if (sType.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "PayTypeCode", sType.Value.Trim(), true, true);
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
    protected void PageSize10_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 10;
        PageSize10.ForeColor = System.Drawing.Color.Red;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        bind();
    }
    protected void PageSize20_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 20;
        PageSize20.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        bind();
    }
    protected void PageSize30_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 30;
        PageSize30.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        bind();
    }
    #endregion
    public string GetPoint(object p1, object p2)
    {
        if (p2.ToString() == "")
        {
            return p1.ToString();
        }
        else
        {
            return p2.ToString();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        MakeCriteria(ref sb);
        ViewState["strWhere"] = sb.ToString();
        bind();
    }
    public string GetPayType(object code)
    {
        return Tz888.Common.Common.GetPayType(code.ToString());
    }
    public string GetIco(object MemberGradeID)
    {
        if (MemberGradeID.ToString().Trim() == "1002")
        {
            return "<img src='http://www.topfo.com/Web13/images/home/tfzs.gif' border='0' alt='拓富通会员'></img>";
        }
        else
        {
            return "";
        }
    }
}
