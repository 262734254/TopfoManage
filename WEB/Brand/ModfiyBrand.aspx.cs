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
using Tz888.BLL.Brand;
using Tz888.Model.Brand;
using Tz888.Common.Utility;

public partial class Brand_ModfiyBrand : System.Web.UI.Page
{
    private readonly BrandBLL bll = new BrandBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["BrandId"] != null)
            {
                string BrandId = Request.QueryString["BrandId"].ToString();
                if (Tz888.Common.Utility.PageValidate.IsNumber(BrandId))
                    InitBrandIinfo(BrandId);
                else
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
            }
        }
    }

    public void InitBrandIinfo(string BrandId)
    {
        try
        {
            DataTable dt = bll.GetBrandByBrandId(BrandId);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTitle.Value = dt.Rows[0]["Title"].ToString();
                txtImgPath.Value = dt.Rows[0]["ImgPath"].ToString();
                txtUrl.Value = dt.Rows[0]["Url"].ToString();
                ShowPosition.SelectedValue = dt.Rows[0]["ShowPosition"].ToString();
                txtSort.Value = dt.Rows[0]["Sort"].ToString();
                txtRemarks.Value = (dt.Rows[0]["Remarks"] == DBNull.Value) ? "&nbsp;" : dt.Rows[0]["Remarks"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void BtnModfiy_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["BrandId"] != null)
            {
                int BrandId = Convert.ToInt32(Request.QueryString["BrandId"].ToString());
                BrandModel model = new BrandModel();
                model.BrandId = BrandId;
                model.Title = PageValidate.HtmlEncode(txtTitle.Value.Trim());
                model.ImgPath = PageValidate.HtmlEncode(txtImgPath.Value.Trim());
                model.Url = PageValidate.HtmlEncode(txtUrl.Value.Trim());
                model.ShowPosition = ShowPosition.SelectedValue;
                model.Sort = (txtSort.Value.Trim() == "") ? 0 : Convert.ToInt32(txtSort.Value.Trim());
                model.Remarks = PageValidate.HtmlEncode(txtRemarks.Value.Trim());

                if (bll.ModfiyBrand(model))
                {
                    Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "修改成功!", "BrandManage.aspx", false);
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "修改失败!");
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
