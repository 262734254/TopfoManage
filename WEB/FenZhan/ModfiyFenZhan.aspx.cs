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
using Tz888.Common;
using Tz888.BLL.FenZhan;
using Tz888.Model.FenZhan;

public partial class fenzhan_ModfiyFenZhan : System.Web.UI.Page
{
    private readonly FenZhanBLL bll = new FenZhanBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ModfiyId"] != null)
            {
                string ModfiyId = Request.QueryString["ModfiyId"];
                if (!Text.IsInt(ModfiyId))
                {
                    MessageBox.ShowAndRedirect(this.Page, "参数错误!", "FenZhanList.aspx");
                }
                else
                {
                    InitProvince();
                    InitFenZhan(ModfiyId);
                }
            }
        }
    }

    public void InitProvince()
    {
        DropProvince1.DataSource = new Tz888.BLL.Common.ZoneSelectBLL().GetProvice();
        DropProvince1.DataTextField = "ProvinceName";
        DropProvince1.DataValueField = "ProvinceID";
        DropProvince1.DataBind();
        
        ListItem item = new ListItem();
        item.Text = "请选择";
        item.Value = "0";
        DropProvince1.Items.Insert(0, item);
    }

    public void InitFenZhan(string ModfiyId)
    {
        DataTable dt = bll.GetFenZhanById(ModfiyId);
        if (dt != null && dt.Rows.Count > 0)
        {
            txtName.Value = dt.Rows[0]["FenZhanName"].ToString();
            txtAddress.Value = dt.Rows[0]["Address"].ToString();
            DropProvince1.SelectedValue = dt.Rows[0]["ProvinceID"].ToString() + "      ";
        }
    }

    protected void BtnModfiy_Click(object sender, EventArgs e)
    {
        FenZhanModel Model = new FenZhanModel();
        string ModfiyId = Request.QueryString["ModfiyId"];
        Model.Id = Convert.ToInt32(ModfiyId);
        Model.FenZhanName = txtName.Value.Trim();
        Model.Address = txtAddress.Value.Trim();
        Model.ProvinceID = Convert.ToInt32(DropProvince1.SelectedValue);

        if (bll.Modfiy(Model))
        {
            MessageBox.ShowAndRedirect(this.Page, "修改成功!", "FenZhanManage.aspx");
        }
        else
        {
            MessageBox.ShowAndRedirect(this.Page, "修改失败!", "FenZhanManage.aspx");
        }
    }
}
