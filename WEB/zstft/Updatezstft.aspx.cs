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
using System.Text.RegularExpressions;
using Tz888.Model.zstft;
using System.IO;

public partial class zstft_Updatezstft : System.Web.UI.Page
{

    private readonly Tz888.BLL.Common.ZoneSelectBLL common = new Tz888.BLL.Common.ZoneSelectBLL();
    private readonly Tz888.BLL.zstft.zstftBLL bll = new Tz888.BLL.zstft.zstftBLL();
    private readonly BasePage bp = new BasePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
                {
                    InitInfo(Id);
                }
                else
                {
                    Tz888.Common.MessageBox.ShowAndHref("参数错误!", "");
                }
            }
        }
    }

    public void InitInfo(string Id)
    {
        DataTable dt = bll.Getzstft(Id);
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            txtTitle.Value=row["Title"].ToString();
            ViewState["Category"] = txtCategory.SelectedValue = row["Category"].ToString();
            txtAddress.Value=row["Address"].ToString();
            txtRemark.Value=row["Remark"].ToString();
            txtSort.Value = row["Sort"].ToString();
            this.Img.ImageUrl = GetImgPath(txtCategory.SelectedValue.ToString()) + row["Picture"].ToString();  //http:\\zs.topfo.com\zsimge\   F:\zsimge\
            LoadProvince(row["ProvinceName"].ToString());
            
        }
    }

    //获取图片的路劲
    public string GetImgPath(string CategoryValue)
    {
        string ImgPath = "";
        if (CategoryValue == "招商")
        {
            ImgPath = @"http://zs.topfo.com/zsimge/";
        }
        else if (CategoryValue == "融资")
        {
            ImgPath = @"http://rz.topfo.com/rzimge/";
        }
        else if (CategoryValue == "投资")
        {
            ImgPath = @"http://tz.topfo.com/tzimge/";
        }
        return ImgPath;
    }

    public void LoadProvince(string ProvinceName)
    {
        Province.DataSource = common.GetProvice();
        Province.DataTextField = "ProvinceName";
        Province.DataValueField = "ProvinceName";
        Province.DataBind();
        Province.SelectedValue = ProvinceName;
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        string ErrorMsg = "";
        string strFileName = "";
        zstftModel M = new zstftModel();
        M.Id = Convert.ToInt32(Request.QueryString["Id"]);
        M.Title = txtTitle.Value.Trim();
        M.Address = txtAddress.Value.Trim();
        M.Category = txtCategory.SelectedValue;
        M.ProvinceName = Province.SelectedValue;
        M.Sort = (String.IsNullOrEmpty(txtSort.Value.Trim())) ? 0 : Convert.ToInt32(txtSort.Value.Trim());
        M.LogName = bp.LoginName;
        M.PublishTime = DateTime.Now;
        M.Remark = txtRemark.Value.Trim();
        HttpPostedFile Files = HttpContext.Current.Request.Files[0];

        strFileName = Regex.Match(this.Img.ImageUrl, @"[0-9]*?\.(jpg|gif|png)").Value;
        if (Files.FileName != "")
        {
            strFileName = GetSaveImgPath(ViewState["Category"].ToString()) + strFileName;
            strFileName = Tz888.BLL.zstft.UpFile.SaveFile(Files, GetSaveImgPath(M.Category), ref ErrorMsg, 500, "jpg|gif|png", 1, strFileName, 155, 116);
        }

        if (strFileName == "" && ErrorMsg != "")
        {
            Tz888.Common.MessageBox.Show(this.Page, ErrorMsg);
        }
        else
        {
            M.Picture = strFileName;
            if (bll.Update(M))
            {
                Tz888.Common.MessageBox.ShowAndHref("修改成功!", "Managezstft.aspx");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "修改失败!");
            }
        }
    }

    public string GetSaveImgPath(string CategoryValue)
    {
        string SaveImgPath = "";
        if (CategoryValue == "招商")
        {
            SaveImgPath = @"J:\topfo\zs\zsimge\";
        }
        else if (CategoryValue == "融资")
        {
            SaveImgPath = @"J:\topfo\rz\rzimge\";
        }
        else if (CategoryValue == "投资")
        {
            SaveImgPath = @"J:\topfo\tz\tzimge\";
        }
        return SaveImgPath;
    }
}
