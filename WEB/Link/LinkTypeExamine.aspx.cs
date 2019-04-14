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
using System.Data;
using System.Text.RegularExpressions;

public partial class Link_LinkTypeExamine : System.Web.UI.Page
{
    private readonly Tz888.BLL.Link.LinkTypeTab bll = new Tz888.BLL.Link.LinkTypeTab();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["TypeId"] != null)
            {
                string TypeId = Request.QueryString["TypeId"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(TypeId))
                {
                    ViewState["TypeId"] = TypeId;
                    LoadLinkType(TypeId);
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
                }
            }
        }
    }

    //友情链接类别审核
    protected void BtnSvae_Click(object sedner, EventArgs e)
    {
        try
        {
            Tz888.Model.Link.LinkTypeTab model = new Tz888.Model.Link.LinkTypeTab();
            model.LinkId = Convert.ToInt32(ViewState["TypeId"].ToString());
            model.LinkName = Tz888.Common.Utility.PageValidate.HtmlEncode(txtTypeName.Value.Trim());
            model.CheckId = Convert.ToInt32(rblAuditing.SelectedValue);
            model.Remarks = Tz888.Common.Utility.PageValidate.HtmlEncode(txtRemarks.Value.Trim());

            if (bll.UpdateTypeById(model))
            {
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "审核成功!", "LinkTypeManage.aspx", false);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "审核失败!");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void LoadLinkType(string id)
    {
        try
        {
            DataTable dt = bll.GetTypeById(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTypeName.Value = dt.Rows[0]["LinkName"].ToString();
                rblAuditing.SelectedValue = dt.Rows[0]["CheckId"].ToString();
                txtRemarks.Value = (dt.Rows[0]["Remarks"] == DBNull.Value) ? "" : dt.Rows[0]["Remarks"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
