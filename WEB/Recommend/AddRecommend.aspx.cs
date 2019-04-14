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

public partial class Recommend_AddRecommend : System.Web.UI.Page
{
    private readonly Tz888.BLL.Recommend.RecommendBLL bll = new Tz888.BLL.Recommend.RecommendBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitFenZhan();
        }
    }

    /// <summary>
    /// 加载所有分站
    /// </summary>
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

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Tz888.Model.Recommend.RecommendModel model = new Tz888.Model.Recommend.RecommendModel();
        model.Title = txtTitle.Value.Trim();
        model.Address = txtAddress.Value.Trim();
        model.Sort = txtSort.Value.Trim() == "" ? 0 : Convert.ToInt32(txtSort.Value.Trim());
        model.Identity = Convert.ToInt32(DropIdentity.SelectedValue.Trim());
        model.IsRecommend = Convert.ToInt32(RadioRecommend.SelectedValue);
        model.ProvinceID = FenZhanList.SelectedValue;
        
        model.Remarks = txtRemarks.Value.Trim();
        if (bll.AddRecommend(model))
        {
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功!", "RecommendManage.aspx", false);
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "添加失败!");
        }
    }
}
