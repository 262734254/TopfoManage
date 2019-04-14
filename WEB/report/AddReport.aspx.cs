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
using Tz888.BLL.Advertorial;
using Tz888.Model.report;
using Tz888.BLL.report;
public partial class report_AddReport : System.Web.UI.Page
{
    IndustryType bll = new IndustryType();
    ReportTab maModel = new ReportTab();
    ReportView viewModel = new ReportView();
    reportTabBLL maBll = new reportTabBLL();
    reportViewBLL viewBll = new reportViewBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["alt"] == "1")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))//修改
                {
                    bindModel(int.Parse(Request.QueryString["id"].ToString()));
                    btnSubmit.Visible = false;
                    btnAudit.Visible = true;
                    //isAudit.Attributes.Add("style", "display:''");
                    //isAct.Attributes.Add("style", "display:''");
                    //isNoMian.Attributes.Add("style", "display:''");
                }
            }
            else
            {
                rdomian.Checked = true;
                rdoNoAct.Checked = true;
                rdAudit.Checked = true;
                btnSubmit.Visible = true;
                btnAudit.Visible = false;
                //isAudit.Attributes.Add("style", "display:none");
                //isAct.Attributes.Add("style", "display:none");
                //isNoMian.Attributes.Add("style", "display:none");

            }

            databind();
        }
        btnSubmit.Attributes.Add("onclick", "return CheckForm();");
        btnAudit.Attributes.Add("onclick", "return CheckForm();");
    }
    private void databind()
    {

        ddlbegin.DataSource = DataBegin(7);
        ddlbegin.DataBind();
        ddlend.DataSource = DataBegin(18);
        ddlend.DataBind();
        ddlbig.DataSource = bll.GetList("classID=0");//大类classid=0
        ddlbig.DataValueField = "industryID";
        ddlbig.DataTextField = "industryName";
        ddlbig.DataBind();
        IndustryFromBLL bl = new IndustryFromBLL();
        if ((bl.GetList("") != null) && (bl.GetList("").Tables[0].Rows.Count > 0))
        {
            ddrFrom.DataSource = bl.GetList("");
            ddrFrom.DataValueField = "industryId";
            ddrFrom.DataTextField = "industryName";
            ddrFrom.DataBind();
        }


        int id = int.Parse(ddlbig.SelectedValue.ToString());
        ddlSmall.DataSource = bll.GetList("classID=" + id);//大类classid=0
        ddlSmall.DataValueField = "industryID";
        ddlSmall.DataTextField = "industryName";
        ddlSmall.DataBind();

    }
    private void bindModel(int id)
    {
        maModel = maBll.GetModel(id);
        txtOverTime.Text = maModel.OverTime.ToString();
        viewModel = viewBll.GetModel(id);
        txtName.Text = maModel.Reportname;
        txtWtitle.Text = viewModel.Title;
        txtKeyword1.Text = viewModel.Keywords;
        if (maModel.FormID > 0)
        {
            ddrFrom.SelectedValue = maModel.FormID.ToString();
        }
        txtWebDesr.Text = viewModel.Description;
        ddlbig.SelectedValue = maModel.Bigtypeid.ToString();
        ddlSmall.SelectedValue = maModel.Smalltypeid.ToString();
        if (!string.IsNullOrEmpty(maModel.Effectivedata.ToString()))
        {
            if (int.Parse(maModel.Effectivedata.ToString()) < 2005)
            {
                ddlbegin.SelectedIndex = 0;
            }
            else
            {
                ddlbegin.SelectedValue = maModel.Effectivedata;
            }
        }
        if (!string.IsNullOrEmpty(maModel.Invaliddata.ToString()))
        {
            if (int.Parse(maModel.Invaliddata.ToString()) < 2005)
            {
                ddlend.SelectedIndex = 0;
            }
            else
            {
                ddlend.SelectedValue = maModel.Invaliddata;
            }
        }

        txtPay.Text = viewModel.Paytype;

        if (maModel.Charges == 0)
        {
            rdomian.Checked = true;//是否收费 0不收费  1 收费
            spShowPoint.Attributes.Add("style", "display:none");
        }
        else
        {
            rdoShou.Checked = true;
            spShowPoint.Attributes.Add("style", "display:''");
        }
        if (maModel.Charges == 1)
        {
            if (!string.IsNullOrEmpty(maModel.Price.ToString()))
            {
                string[] str = maModel.Price.Split(new char[] { '|' });//1:123|2:123|3:123|4:123|
                for (int i = 0; i < str.Length - 1; i++)
                {
                    string[] strchild = str[i].ToString().Split(new char[] { ':' });
                    for (int j = 0; j < strchild.Length - 1; j++)
                    {
                        if (!string.IsNullOrEmpty(strchild[j].ToString()))
                        {
                            switch (strchild[j].ToString())
                            {
                                case "1":
                                    txtDian.Text = strchild[j + 1].ToString();
                                    rdoDian.Checked = true;
                                    break;
                                case "2":
                                    txtying.Text = strchild[j + 1].ToString();
                                    rdoying.Checked = true;
                                    break;
                                case "3":
                                    txtDianying.Text = strchild[j + 1].ToString();
                                    rdoDianying.Checked = true;
                                    break;
                                case "4":
                                    txtYinguang.Text = strchild[j + 1].ToString();
                                    rdoYinguang.Checked = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        txtPhotoCount.Text = viewModel.Chartcount.ToString();
        txtYeCount.Text = viewModel.Pagecount.ToString();

        txtWriterCompany.Text = viewModel.Writing;//撰写单位
        txtPublishDate.Text = viewModel.Publishingdate;
        txtExplain.Text = maModel.Explain;//摘要
        txtMessage.Text = viewModel.Message;
        if (maModel.RecommendID == 0)//是否推荐0:不1：推荐
        {
            rdoNoAct.Checked = true;
        }
        else
        {
            rdoYesAct.Checked = true;
        }
        if (maModel.Auditid == 1)//审核状态 0未审   1已审
        {
            rdPass.Checked = true;
        }
        else
        {
            rdAudit.Checked = true;
        }
    }
    public ArrayList DataBegin(int num)
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < num; i++)
        {
            int yers = 0;
            yers = 2005 + i;
            list.Add(yers);
        }
        return list;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        maModel.Reportname = txtName.Text.Trim();
        maModel.OverTime = txtOverTime.Text.Trim();
        viewModel.Title = txtWtitle.Text.Trim();
        viewModel.Keywords = txtKeyword1.Text.Trim();
        viewModel.Description = txtWebDesr.Text.Trim();
        maModel.Bigtypeid = int.Parse(ddlbig.SelectedValue.ToString());
        maModel.Smalltypeid = int.Parse(ddlSmall.SelectedValue.ToString());
        maModel.Effectivedata = ddlbegin.SelectedValue.ToString();
        maModel.Invaliddata = ddlend.SelectedValue.Trim().ToString();
        maModel.FormID = int.Parse(ddrFrom.SelectedValue.ToString());
        string prices = string.Empty;
        if (rdomian.Checked)
        {
            maModel.Charges = 0;//是否收费 0不收费  1 收费
        }
        else
        {
            maModel.Charges = 1;
        }
        if (rdoShou.Checked)
        {
            if (rdoDian.Checked)
            {
                string dain = string.Empty;
                if (string.IsNullOrEmpty(txtDian.Text.Trim()))
                {
                    dain = "0";
                }
                else
                {
                    dain = txtDian.Text.Trim();
                }
                //prices = rdoDian.Text + ":" + dain + "|";
                prices = "1" + ":" + dain + "|";
            }
            else
            {
                prices += ":|";
            }
            if (rdoying.Checked)
            {
                string dain = string.Empty;
                if (string.IsNullOrEmpty(txtying.Text.Trim()))
                {
                    dain = "0";
                }
                else
                {
                    dain = txtying.Text.Trim();
                }
                //prices += rdoying.Text + ":" + dain + "|";
                prices += "2" + ":" + dain + "|";
            }
            else
            {
                prices += ":|";
            }
            if (rdoDianying.Checked)
            {
                string dain = string.Empty;
                if (string.IsNullOrEmpty(txtDianying.Text.Trim()))
                {
                    dain = "0";
                }
                else
                {
                    dain = txtDianying.Text.Trim();
                }
                //prices += rdoDianying.Text + ":" + dain + "|";
                prices += "3" + ":" + dain + "|";
            }
            else
            {
                prices += ":|";
            }
            if (rdoYinguang.Checked)
            {
                string dain = string.Empty;
                if (string.IsNullOrEmpty(txtYinguang.Text.Trim()))
                {
                    dain = "0";
                }
                else
                {
                    dain = txtYinguang.Text.Trim();
                }
                //prices += rdoYinguang.Text + ":" + dain + "|";
                prices += "4" + ":" + dain + "|";
            }
            else
            {
                prices += ":|";
            }
        }
        else
        {
            maModel.Price = "";
        }
        maModel.Price = prices;
        viewModel.Paytype = txtPay.Text.Trim();
        if (!string.IsNullOrEmpty(txtPhotoCount.Text.Trim()))
        {
            viewModel.Chartcount = int.Parse(txtPhotoCount.Text.Trim().ToString());
        }
        else
        {
            viewModel.Chartcount = 0;
        }
        if (!string.IsNullOrEmpty(txtYeCount.Text.Trim()))
        {
            viewModel.Pagecount = int.Parse(txtYeCount.Text.Trim().ToString());
        }
        else
        {
            viewModel.Pagecount = 0;
        }
        viewModel.Writing = txtWriterCompany.Text.Trim();//撰写单位
        viewModel.Publishingdate = txtPublishDate.Text.Trim();
        maModel.Explain = txtExplain.Text.Trim();//摘要
        viewModel.Message = txtMessage.Text.Trim();
        if (rdoNoAct.Checked)//是否推荐0:不1：推荐
        {
            maModel.RecommendID = 0;
        }
        else
        {
            maModel.RecommendID = 1;
        }
        if (rdPass.Checked)//审核状态 0未审   1已审
        {
            maModel.Auditid = 1;
        }
        else
        {
            maModel.Auditid = 0;
        }

        int num = viewBll.InsertReport(maModel, viewModel);
        maModel.Html = "htmlLink/" + DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("yyyyMMdd") + num + ".shtml";
        if (num <= 0)
        {
            Response.Write("<script>alert('发布失败！');document.location='reportList.aspx'</script>");
        }
        else
        {
            if (rdPass.Checked)
            {
                maModel.ReportID = num;
                if (viewBll.UpdateReport(maModel, viewModel))
                {
                    PageStatic stat = new PageStatic();
                    int result = stat.StaticHtml(num);
                    if (result <= 0)
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
                    }
                }
            }
            Response.Redirect("reportList.aspx");
        }
    }
    protected void ddlbig_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(ddlbig.SelectedValue.ToString());
        ddlSmall.DataSource = bll.GetList("classID=" + id);//大类classid=0
        ddlSmall.DataValueField = "industryID";
        ddlSmall.DataTextField = "industryName";
        ddlSmall.DataBind();
    }
    protected void btnAudit_Click(object sender, EventArgs e)
    {
        maModel = maBll.GetModel(int.Parse(Request.QueryString["id"].ToString()));
        maModel.Reportname = txtName.Text.Trim();
        viewModel.Title = txtWtitle.Text.Trim();
        viewModel.Keywords = txtKeyword1.Text.Trim();
        viewModel.Description = txtWebDesr.Text.Trim();
        maModel.Bigtypeid = int.Parse(ddlbig.SelectedValue.ToString());
        maModel.Smalltypeid = int.Parse(ddlSmall.SelectedValue.ToString());
        maModel.Effectivedata = ddlbegin.SelectedValue.ToString();
        maModel.Invaliddata = ddlend.SelectedValue.Trim().ToString();
        maModel.FormID = int.Parse(ddrFrom.SelectedValue.ToString());
        //if (!string.IsNullOrEmpty(Request.QueryString["id"]))//修改
        //{
        //    maModel.ReportID = int.Parse(Request.QueryString["id"].ToString());
        //}
        if (rdomian.Checked)
        {
            maModel.Charges = 0;//是否收费 0不收费  1 收费
        }
        else
        {
            maModel.Charges = 1;
        }
        string prices = string.Empty;
        if (rdoShou.Checked)
        {
            if (rdoDian.Checked)
            {
                string dain = string.Empty;
                if (string.IsNullOrEmpty(txtDian.Text.Trim()))
                {
                    dain = "0";
                }
                else
                {
                    dain = txtDian.Text.Trim();
                }
                //prices = rdoDian.Text + ":" + dain + "|";
                prices = "1" + ":" + dain + "|";
            }
            else
            {
                prices += ":|";
            }
            if (rdoying.Checked)
            {
                string dain = string.Empty;
                if (string.IsNullOrEmpty(txtying.Text.Trim()))
                {
                    dain = "0";
                }
                else
                {
                    dain = txtying.Text.Trim();
                }
                //prices += rdoying.Text + ":" + dain + "|";
                prices += "2" + ":" + dain + "|";
            }
            else
            {
                prices += ":|";
            }
            if (rdoDianying.Checked)
            {
                string dain = string.Empty;
                if (string.IsNullOrEmpty(txtDianying.Text.Trim()))
                {
                    dain = "0";
                }
                else
                {
                    dain = txtDianying.Text.Trim();
                }
                //prices += rdoDianying.Text + ":" + dain + "|";
                prices += "3" + ":" + dain + "|";
            }
            else
            {
                prices += ":|";
            }
            if (rdoYinguang.Checked)
            {
                string dain = string.Empty;
                if (string.IsNullOrEmpty(txtYinguang.Text.Trim()))
                {
                    dain = "0";
                }
                else
                {
                    dain = txtYinguang.Text.Trim();
                }
                //prices += rdoYinguang.Text + ":" + dain + "|";
                prices += "4" + ":" + dain + "|";
            }
            else
            {
                prices += ":|";
            }
        }
        else
        {
            maModel.Price = "";
        }
        maModel.Price = prices;
        maModel.OverTime = txtOverTime.Text.Trim();
        viewModel.Paytype = txtPay.Text.Trim();
        if (!string.IsNullOrEmpty(txtPhotoCount.Text.Trim()))
        {
            viewModel.Chartcount = int.Parse(txtPhotoCount.Text.Trim().ToString());
        }
        else
        {
            viewModel.Chartcount = 0;
        }
        if (!string.IsNullOrEmpty(txtYeCount.Text.Trim()))
        {
            viewModel.Pagecount = int.Parse(txtYeCount.Text.Trim().ToString());
        }
        else
        {
            viewModel.Pagecount = 0;
        }
        viewModel.Writing = txtWriterCompany.Text.Trim();//撰写单位
        viewModel.Publishingdate = txtPublishDate.Text.Trim();
        maModel.Explain = txtExplain.Text.Trim();//摘要
        if (string.IsNullOrEmpty(maModel.Html))
        {
            maModel.Html = "htmlLink/" + DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("yyyyMMdd") + int.Parse(Request.QueryString["id"].ToString()) + ".shtml";
        }
        viewModel.Message = txtMessage.Text.Trim();
        if (rdoNoAct.Checked)//是否推荐0:不1：推荐
        {
            maModel.RecommendID = 0;
        }
        else
        {
            maModel.RecommendID = 1;
        }
        if (rdPass.Checked)//审核状态 0未审   1已审
        {
            maModel.Auditid = 1;
        }
        else
        {
            maModel.Auditid = 0;
        }
        if (!viewBll.UpdateReport(maModel, viewModel))
        {
            Response.Write("<script>alert('审核失败！');document.location='reportList.aspx'</script>");
        }
        else
        {
            if (rdPass.Checked)
            {
                PageStatic stat = new PageStatic();
                int result = stat.StaticHtml(int.Parse(Request.QueryString["id"].ToString()));
                if (result <= 0)
                {
                    Tz888.Common.MessageBox.Show(this.Page, "生成静态页面失败");
                }
            }
            Response.Write("<script>alert('修改成功！');document.location='reportList.aspx'</script>");

        }
    }
}
