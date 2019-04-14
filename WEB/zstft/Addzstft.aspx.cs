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
using Tz888.Model.zstft;
using System.Text;
using System.IO;

public partial class zstft_Addzstft : System.Web.UI.Page
{
    private readonly Tz888.BLL.Common.ZoneSelectBLL common = new Tz888.BLL.Common.ZoneSelectBLL();
    private readonly Tz888.BLL.zstft.zstftBLL bll = new Tz888.BLL.zstft.zstftBLL();
    private readonly BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadProvince();
        }
    }

    public void LoadProvince()
    {
        Province.DataSource = common.GetProvice();
        Province.DataTextField = "ProvinceName";
        Province.DataValueField = "ProvinceName";
        Province.DataBind();

        ListItem Item = new ListItem();
        Item.Text = "请选择";
        Item.Value = "-1";
        Province.Items.Insert(0, Item);
    }

    protected void BtnSvae_Click(object sender, EventArgs e)
    {
        string ErrorMsg = "";
        string strFileName = "";
        zstftModel M = new zstftModel();
        M.Title = txtTitle.Value.Trim();
        M.Address = txtAddress.Value.Trim();
        M.Category = txtCategory.SelectedValue;
        M.ProvinceName = Province.SelectedValue;
        M.LogName = bp.LoginName;
        M.Sort = (String.IsNullOrEmpty(txtSort.Value.Trim())) ? 0 : Convert.ToInt32(txtSort.Value.Trim());
        M.PublishTime = DateTime.Now;
        M.Remark = txtRemark.Value.Trim();
        HttpPostedFile Files = HttpContext.Current.Request.Files[0];
        if (Files.FileName != "")
        {
            strFileName = Tz888.BLL.zstft.UpFile.SaveFile(Files, GetImgPath(M.Category), ref ErrorMsg, 500, "jpg|gif|png", 0, "", 155, 116);
        }
        if (strFileName != "" && ErrorMsg != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, ErrorMsg);
        }
        else
        {
            M.Picture = strFileName;
            if (bll.Add(M))
            {
                Tz888.Common.MessageBox.ShowAndHref("添加成功!", "Managezstft.aspx");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "添加失败!");
            }
        }
    }

    public string GetImgPath(string CategoryValue)
    {
        string ImgPath = "";
        if (CategoryValue == "招商")
        {
            ImgPath = @"J:\topfo\zs\zsimge\";
        }
        else if (CategoryValue == "融资")
        {
            ImgPath = @"J:\topfo\rz\rzimge\";
        }
        else if (CategoryValue == "投资")
        {
            ImgPath = @"J:\topfo\tz\tzimge\";
        }

        if (!Directory.Exists(ImgPath))
            Directory.CreateDirectory(ImgPath);

        return ImgPath;
    }
}

