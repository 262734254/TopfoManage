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
using Tz888.Model.FenZhan;
using Tz888.BLL.FenZhan;
using Tz888.Common;

public partial class fenzhan_AddFenZhan : System.Web.UI.Page
{
    private readonly FenZhanBLL bll = new FenZhanBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitProvince();
        }
    }

    public void InitProvince()
    {
        DropProvince.DataSource = new Tz888.BLL.Common.ZoneSelectBLL().GetProvice();
        DropProvince.DataTextField = "ProvinceName";
        DropProvince.DataValueField = "ProvinceID";
        DropProvince.DataBind();

        ListItem item = new ListItem();
        item.Text = "请选择";
        item.Value = "0";
        DropProvince.Items.Insert(0, item);
    }

    //发布分站
    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        FenZhanModel Model = new FenZhanModel();
        Model.FenZhanName = txtName.Value.Trim();
        Model.Address = txtAddress.Value.Trim();
        Model.CreateTime = DateTime.Now;
        Model.ProvinceID = Convert.ToInt32(DropProvince.SelectedValue);
        if (bll.Add(Model))
        {
            MessageBox.ShowAndRedirect(this.Page, "添加成功!", "FenZhanManage.aspx");
        }
        else
        {
            MessageBox.ShowAndRedirect(this.Page, "添加失败!", "FenZhanManage.aspx");
        }
    }
}
