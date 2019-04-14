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
using Tz888.BLL.FenZhan;

public partial class Recommend_ModfiyRecommend : System.Web.UI.Page
{
    private readonly Tz888.BLL.Recommend.RecommendBLL bll = new Tz888.BLL.Recommend.RecommendBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
                {
                    InitFenZhan();
                    InitRecommend(Id);
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
                }
            }
        }
    }

    public void InitFenZhan()
    {
        FenZhanBLL bll = new FenZhanBLL();
        DataTable dt = bll.GetFenZhanList();
        if (dt != null && dt.Rows.Count > 0)
        {
            FenZhanList.DataSource = dt;
            FenZhanList.DataValueField = "ProvinceID";
            FenZhanList.DataTextField = "FenZhanName";
            FenZhanList.DataBind();
        }

        ListItem item = new ListItem();
        item.Value = "0";
        item.Text = "所有分站";
        FenZhanList.Items.Insert(0, item);
    }

    public void InitRecommend(string Id)
    {
        DataTable dt = bll.GetRecommendDetail(Id);
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            txtTitle.Value = row["Title"].ToString();
            txtAddress.Value = row["Address"].ToString();
            txtSort.Value = row["Sort"].ToString();
            DropIdentity.SelectedValue = row["Identity"].ToString();
            txtRemarks.Value = (row["Remarks"].ToString() == "") ? "" : row["Remarks"].ToString();
            RadioRecommend.SelectedValue = row["IsRecommend"].ToString();
            FenZhanList.SelectedValue = row["ProvinceID"].ToString().Trim();
        }
    }

    protected void BtnModfiy_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] != null)
        {
            string Id = Request.QueryString["Id"];
            if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
            {
                Tz888.Model.Recommend.RecommendModel model = new Tz888.Model.Recommend.RecommendModel();
                model.Id = Convert.ToInt32(Id);
                model.Title = txtTitle.Value.Trim();
                model.Address = txtAddress.Value.Trim();
                model.Sort = txtSort.Value.Trim() == "" ? 0 : Convert.ToInt32(txtSort.Value.Trim());
                model.Identity = Convert.ToInt32(DropIdentity.SelectedValue.Trim());
                model.ProvinceID = FenZhanList.SelectedValue;
                model.IsRecommend = Convert.ToInt32(RadioRecommend.SelectedValue);
                model.Remarks = txtRemarks.Value.Trim();
                if (bll.ModfiyRecommend(model))
                    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改成功!", "RecommendManage.aspx", false);
                else
                    Tz888.Common.MessageBox.Show(this.Page, "修改失败!");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "修改错误!");
            }
        }
    }
}
