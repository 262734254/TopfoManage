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
using Tz888.BLL.Picture;
using Tz888.BLL.FenZhan;
using Tz888.Common;

public partial class Picture_PictureList : System.Web.UI.Page
{
    private readonly PictureBLL bll = new PictureBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string Id = Request.QueryString["Id"];
                if (Tz888.Common.Utility.PageValidate.IsNumber(Id))
                    DelPictureById(Id);
                else
                    Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
            }
            InitFenZhan();
            dataBind("");
        }
    }

    public void InitFenZhan()
    {
        FenZhanBLL bll = new FenZhanBLL();
        DataTable dt = bll.GetFenZhanList();
        if (dt != null && dt.Rows.Count > 0)
        {
            ShowPosition.DataSource = dt;
            ShowPosition.DataValueField = "Id";
            ShowPosition.DataTextField = "FenZhanName";
            ShowPosition.DataBind();
        }

        ListItem item = new ListItem();
        item.Value = "0";
        item.Text = "所有分站";
        ShowPosition.Items.Insert(0, item);
    }

    public string GetFenZhanName(string Id)
    {
        if (Id == "0")
            return "所有分站";
        string FenZhanName = "";
        FenZhanBLL bll = new FenZhanBLL();
        DataTable dt = bll.GetFenZhanById(Id);
        if (dt != null && dt.Rows.Count > 0)
        {
            FenZhanName = dt.Rows[0]["FenZhanName"].ToString();
        }
        return FenZhanName;
    }

    public void DelPictureById(string Id)
    {
        if (bll.DelPictureById(Id))
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "删除成功!", "PictureList.aspx", false);
        else
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "删除失败!", "PictureList.aspx", false);
    }

    //搜索
    protected void Search_Click(object sender, EventArgs e)
    {
        string where = "";
        string Title = txtTitle.Value.Trim();
        string Position = ShowPosition.SelectedValue;
        string IsRecommend = DropRecommend.SelectedValue;

        if (!string.IsNullOrEmpty(Title))
        {
            where = "Title='" + Title + "' and ";
        }

        if (IsRecommend != "-1")
        {
            where = where + "IsRecommend='" + IsRecommend + "' and ";
        }

        if (Position != "-1")
        {
            where = where + "ShowId='" + Position + "' and ";
        }

        if (where.Length > 0)
        {
            where = where.Substring(0, where.LastIndexOf("and")).Trim();
        }
        dataBind(where);
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind("");
    }

    protected void dataBind(string where)
    {
        try
        {
            int PageCurrent = Convert.ToInt32(this.AspNetPager1.CurrentPageIndex);
            int PageNum = 20;
            int TotalCount = 1;
            int PageCount = 1;
            AspNetPager1.PageSize = PageNum;
            DataTable dt = bll.GetPictureList("PictureInfo", "Id", "*", "", where, ref PageCurrent, PageNum, ref TotalCount);
            if (dt != null)
            {
                this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
                this.RepPicture.DataSource = dt.DefaultView;
                this.RepPicture.DataBind();

                if (TotalCount % PageNum > 0)
                    PageCount = TotalCount / PageNum + 1;
                else
                    PageCount = TotalCount / PageNum;
                this.pinfo.InnerText = Convert.ToString(TotalCount);//总条数
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void Del_Click(object sender, EventArgs e)
    {
        string Id = "";
        if (RepPicture.Items.Count > 0)
        {
            for (int i = 0; i < RepPicture.Items.Count; i++)
            {
                CheckBox Cbox = RepPicture.Items[i].FindControl("Cbox") as CheckBox;
                if (Cbox.Checked)
                {
                    Id = Id + Cbox.ToolTip + ",";
                }
            }
            if (Id.Length > 0)
            {
                Id = Id.Remove(Id.Length - 1, 1);
                if (bll.DelPictureByIds(Id))
                {
                    MessageBox.Show(this.Page, "删除成功!");
                }
                else
                {
                    MessageBox.Show(this.Page, "删除失败!");
                }
            }
        }
        dataBind("");
    }
}
