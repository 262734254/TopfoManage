using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using System.IO;
using System.Data.OleDb;
using System.Text;
public partial class Mail_MailSupervise : Tz888.Common.Pager.BasePage
{
    BasePage bp = new BasePage();
    Tz888.BLL.Mail.ProvinceBLL provincebll = new Tz888.BLL.Mail.ProvinceBLL();
    Tz888.BLL.Mail.CityBLL citybll = new Tz888.BLL.Mail.CityBLL();
    Tz888.BLL.Mail.IndustryBLL industrybll = new Tz888.BLL.Mail.IndustryBLL();
    Tz888.BLL.Mail.MailInfoBLL mailinfobll = new Tz888.BLL.Mail.MailInfoBLL();
    Tz888.BLL.Mail.MailTypeBLL mailtypebll = new Tz888.BLL.Mail.MailTypeBLL();
    Tz888.BLL.Mail.MialgroupBLL mialgroupbll = new Tz888.BLL.Mail.MialgroupBLL();
    Tz888.BLL.Mail.PositionBLL positionbll = new Tz888.BLL.Mail.PositionBLL();
    static DataTable dt;
    static string saveBPath;
    private string par
    {
        get
        {
            return ViewState["par"].ToString();
        }
        set
        {
            ViewState["par"] = value;
        }
    }
    private int count
    {
        get
        {
            return Convert.ToInt32(ViewState["count"]);
        }
        set
        {
            ViewState["count"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            count = 0;
            par = " LoginName='"+bp.LoginName.Trim()+"'";
            this.ddrcity.Visible = false;
            this.ddrprovice.DataSource = provincebll.GetModelList();
            this.ddrprovice.DataValueField = "Id";
            this.ddrprovice.DataTextField = "Name";
            this.ddrprovice.DataBind();

            ListItem item = new ListItem();
            item.Value = "-1";
            item.Text = "--请选择--";
            ddrprovice.Items.Add(item);
            this.ddrprovice.Items.FindByValue("-1").Selected = true;
            this.ddrxingye.DataSource = industrybll.GetModelList();
            this.ddrxingye.DataValueField = "Id";
            this.ddrxingye.DataTextField = "Name";
            this.ddrxingye.DataBind();

            ListItem items = new ListItem();
            items.Value = "-1";
            items.Text = "所有行业";
            ddrxingye.Items.Add(items);
            this.ddrxingye.Items.FindByValue("-1").Selected = true;
            this.ddrzu.DataSource = mialgroupbll.GetModelList();
            this.ddrzu.DataValueField = "groupID";
            this.ddrzu.DataTextField = "groupname";
            this.ddrzu.DataBind();
            ddrzu.Items.Add(item);
            this.ddrzu.Items.FindByValue("-1").Selected = true;
            this.ddrleixing.DataSource = mailtypebll.GetModelList();
            this.ddrleixing.DataValueField = "typeID";
            this.ddrleixing.DataTextField = "TypeName";
            this.ddrleixing.DataBind();
            ddrleixing.Items.Add(item);
            this.ddrleixing.Items.FindByValue("-1").Selected = true;
            List<Tz888.Model.Mail.City> list = citybll.GetModelList(Convert.ToInt32(this.ddrprovice.SelectedValue));
            if (list.Count > 0)
            {
                this.ddrcity.Visible = true;
                this.ddrcity.DataSource = list;
                this.ddrcity.DataValueField = "Id";
                this.ddrcity.DataTextField = "Name";
                this.ddrcity.DataBind();
                ddrcity.Items.Add(item);
                this.ddrcity.Items.FindByValue("-1").Selected = true;
            }
            else { this.ddrcity.Visible = false; }
            if (Convert.ToInt32(Request["str"]) != 0)
            {
                int Id = Convert.ToInt32(Request["str"].ToString());
                Delete(Id);
            }
            if (dt == null)
            {
                dt = new DataTable("MailInfo");
                dt.Columns.Add(new DataColumn("编号", typeof(String)));
                dt.Columns.Add(new DataColumn("账号", typeof(String)));
                dt.Columns.Add(new DataColumn("名称", typeof(String)));
                dt.Columns.Add(new DataColumn("公司名称", typeof(String)));
                dt.Columns.Add(new DataColumn("职位", typeof(String)));
                dt.Columns.Add(new DataColumn("地址", typeof(String)));
                dt.Columns.Add(new DataColumn("网址", typeof(String)));
                dt.Columns.Add(new DataColumn("类型", typeof(String)));
                dt.Columns.Add(new DataColumn("地域", typeof(String)));
                dt.Columns.Add(new DataColumn("行业", typeof(String)));
                dt.Columns.Add(new DataColumn("状态", typeof(String)));
                dt.Columns.Add(new DataColumn("邮件", typeof(String)));
                dt.Columns.Add(new DataColumn("手机", typeof(String)));
                dt.Columns.Add(new DataColumn("组", typeof(String)));
                dt.Columns.Add(new DataColumn("备注", typeof(String)));
                dt.Columns.Add(new DataColumn("时间", typeof(String)));
                dt.Columns.Add(new DataColumn("操作", typeof(String)));
            }

            BindShow();
        }
    }

    #region 删除
    private void Delete(int p)
    {
        int rs = mailinfobll.Delete(p);
        if (rs > 0)
        { }
        else { Response.Write("<script>alert('删除失败！')</script>"); }
    }
    #endregion

    #region 绑定类型
    private void BindShow()
    {


        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        if (par == "")
        {
            par = " 1=1 ";
        }
        this.Pager1.PageSize = 20;
        this.Pager1.StrWhere = par;
        this.Pager1.TableViewName = "MailInfo,@,#";
        this.Pager1.KeyColumn = "UserID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "Mdatetime";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();

    }
    #endregion

    #region 翻译类型
    public string GetType(int typeid)
    {
        string par = "";
        Tz888.Model.Mail.MailType model = mailtypebll.GetModel(typeid);
        par = model.TypeName.Trim();
        return par;
    }
    #endregion

    #region 翻译审核状态
    public string Getstatu(int Audit)
    {
        string par = "";
        if (Audit == 0)
        {
            par = "未审核";
        }
        else { par = "已审核"; }
        return par;
    }
    #endregion

    #region 翻译行业
    public string GetXingye(int indeeryId)
    {

        string par = "";
        if (indeeryId != -1)
        {
            Tz888.Model.Mail.Industry model = industrybll.GetModel(indeeryId);
            par = model.Name.Trim();
        }
        else { par = "所有行业"; }
        return par;
    }
    #endregion

    #region 翻译地域
    public string Getdiyu(int priovid, int cityid)
    {
        string par = "";
        Tz888.Model.Mail.Province modelp = provincebll.GetModel(priovid);
        Tz888.Model.Mail.City modelc = citybll.GetModel(cityid);
        if (modelc != null)
        {
            par = modelp.Name + ": " + modelc.Name;
        }
        else { par = modelp.Name; }
        return par;
    }
    #endregion

    #region 根据省份查找所对应的城市
    protected void ddrprovice_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Tz888.Model.Mail.City> list = citybll.GetModelList(Convert.ToInt32(this.ddrprovice.SelectedValue));
        if (list.Count > 0)
        {
            this.ddrcity.Visible = true;
            this.ddrcity.DataSource = list;
            this.ddrcity.DataValueField = "Id";
            this.ddrcity.DataTextField = "Name";
            this.ddrcity.DataBind();
            ListItem item = new ListItem();
            item.Value = "-1";
            item.Text = "--请选择--";
            ddrcity.Items.Add(item);
            this.ddrcity.Items.FindByValue("-1").Selected = true;
        }
        else { this.ddrcity.Visible = false; }
    }
    #endregion

    #region 条件查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string type = "";
        string zu = "";
        string mingche = "";
        string privory = "";
        string city = "";
        string xingye = "";
        string statue = "";
        if (Convert.ToInt32(ddrleixing.SelectedValue) == -1)
        {
            type = "";
        }
        else
        {
            type = " typeID=" + Convert.ToInt32(ddrleixing.SelectedValue) + "";
        }
        if (Convert.ToInt32(ddrzu.SelectedValue) == -1)
        {
            zu = "";
        }
        else
        {
            if (Convert.ToInt32(ddrleixing.SelectedValue) == -1)
            {
                zu = " groupID=" + Convert.ToInt32(ddrzu.SelectedValue) + "";
            }
            else
            {
                zu = " and groupID=" + Convert.ToInt32(ddrzu.SelectedValue) + "";
            }
        }
        if (txtUserName.Text.Trim() != "")
        {
            if (Convert.ToInt32(ddrleixing.SelectedValue) == -1 && Convert.ToInt32(ddrzu.SelectedValue) == -1)
            {
                mingche = "  UserName like '%" + txtUserName.Text.Trim() + "%'";
            }
            else
            {
                mingche = " and UserName like '%" + txtUserName.Text.Trim() + "%'";
            }
        }
        else { mingche = ""; }
        if (Convert.ToInt32(ddrprovice.SelectedValue) == -1)
        {
            privory = "";
        }
        else
        {
            if (Convert.ToInt32(ddrleixing.SelectedValue) == -1 && Convert.ToInt32(ddrzu.SelectedValue) == -1 && txtUserName.Text.Trim() == "")
            {
                privory = " ProvinceId=" + Convert.ToInt32(ddrprovice.SelectedValue) + "";
            }
            else
            {
                privory = " and ProvinceId=" + Convert.ToInt32(ddrprovice.SelectedValue) + "";
            }
        }

        if (this.ddrcity.Visible == true)
        {
            if (Convert.ToInt32(ddrleixing.SelectedValue) == -1 && Convert.ToInt32(ddrzu.SelectedValue) == -1 && txtUserName.Text.Trim() == "" && Convert.ToInt32(ddrprovice.SelectedValue) == -1)
            {
                if (Convert.ToInt32(ddrcity.SelectedValue) != -1)
                {
                    city = "  CityId=" + Convert.ToInt32(ddrcity.SelectedValue) + "";
                }
                else { city = ""; }
            }
            else
            {
                if (Convert.ToInt32(ddrcity.SelectedValue) != -1)
                {
                    city = "  and CityId=" + Convert.ToInt32(ddrcity.SelectedValue) + "";
                }
                else { city = ""; }
            }
        }
        else { city = ""; }
        if (Convert.ToInt32(ddrxingye.SelectedValue) == -1)
        {
            xingye = "";
        }
        else
        {
            if (Convert.ToInt32(ddrleixing.SelectedValue) == -1 && Convert.ToInt32(ddrzu.SelectedValue) == -1 && txtUserName.Text.Trim() == "" && Convert.ToInt32(ddrprovice.SelectedValue) == -1 && this.ddrcity.Visible == false)
            {
                xingye = " industry=" + Convert.ToInt32(ddrxingye.SelectedValue) + "";
            }
            else
            {
                xingye = " and industry=" + Convert.ToInt32(ddrxingye.SelectedValue) + "";
            }
        }
        if (Convert.ToInt32(ddrstatue.SelectedValue) == -1)
        {
            statue = "";
        }
        else
        {
            if (Convert.ToInt32(ddrleixing.SelectedValue) == -1 && Convert.ToInt32(ddrzu.SelectedValue) == -1 && txtUserName.Text.Trim() == "" && Convert.ToInt32(ddrprovice.SelectedValue) == -1 && this.ddrcity.Visible == false && Convert.ToInt32(ddrxingye.SelectedValue) == -1)
            {
                statue = " Audit=" + Convert.ToInt32(ddrstatue.SelectedValue) + "";
            }
            else
            {
                statue = " and Audit=" + Convert.ToInt32(ddrstatue.SelectedValue) + "";
            }
        }
        if (type.Trim() == "" && zu.Trim() == "" && mingche.Trim() == "" && privory.Trim() == "" && city.Trim() == "" && xingye.Trim() == "" && statue.Trim() == "")
        {
            par = " 1=1 and LoginName='"+bp.LoginName.Trim()+"'";
        }
        else
        {
            par = "" + type + zu + mingche + privory + city + xingye + statue + " and LoginName='"+bp.LoginName.Trim()+"'";
        }
        BindShow();
    }
    #endregion

    #region 批量删除
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的项目!");
            return;
        }
        int result1 = 0;
        for (int i = 0; i < values.Length; i++)
        {
            result1 = mailinfobll.Delete(Convert.ToInt32(values[i].Trim()));

        }
        if (result1 > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
        }

        BindShow();
    }
    #endregion
    protected DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
    {
        //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" +"Extended Properties=Excel 5.0;";
        try
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strExcelFileName + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
            string strExcel = string.Format("select * from [{0}$]", strSheetName);
            DataSet ds = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                adapter.Fill(ds, strSheetName);
                conn.Close();
            }
            return ds.Tables[strSheetName];

        }
        catch (Exception)
        {

            return null;
        }

    }
 
}
