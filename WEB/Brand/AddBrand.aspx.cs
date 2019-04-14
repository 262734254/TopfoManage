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

public partial class Brand_AddBrand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //添加品牌
    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        try
        {
            BrandBLL bll = new BrandBLL();
            BrandModel model = new BrandModel();

            model.Title = PageValidate.HtmlEncode(txtTitle.Value.Trim());
            model.ImgPath = PageValidate.HtmlEncode(txtImgPath.Value.Trim());
            model.Url = PageValidate.HtmlEncode(txtUrl.Value.Trim());
            model.ShowPosition = ShowPosition.SelectedValue;
            model.Sort = (txtSort.Value.Trim() == "") ? 0 : Convert.ToInt32(txtSort.Value.Trim());
            model.Remarks = txtRemarks.Value.Trim();

            if (bll.AddBrand(model))
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "添加成功!", "BrandManage.aspx", false);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "添加失败!");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
