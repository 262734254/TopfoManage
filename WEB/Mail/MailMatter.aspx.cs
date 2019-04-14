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

public partial class Mail_MailMatter : Tz888.Common.Pager.BasePage
{
    Tz888.SQLServerDAL.Common.Induy dl = new Tz888.SQLServerDAL.Common.Induy();
    Tz888.BLL.Mail.MailInfoBLL email = new Tz888.BLL.Mail.MailInfoBLL();
    Tz888.BLL.Mail.ProvinceBLL provincebll = new Tz888.BLL.Mail.ProvinceBLL();
    Tz888.BLL.Mail.CityBLL citybll = new Tz888.BLL.Mail.CityBLL();
    Tz888.BLL.Mail.IndustryBLL industrybll = new Tz888.BLL.Mail.IndustryBLL();
    Tz888.BLL.Mail.MailInfoBLL mailinfobll = new Tz888.BLL.Mail.MailInfoBLL();
    Tz888.BLL.Mail.MailTypeBLL mailtypebll = new Tz888.BLL.Mail.MailTypeBLL();
    Tz888.BLL.Mail.MialgroupBLL mialgroupbll = new Tz888.BLL.Mail.MialgroupBLL();
    Tz888.BLL.Mail.PositionBLL positionbll = new Tz888.BLL.Mail.PositionBLL();
    static DataSet ds;
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
            par = " ";

            if (Request.QueryString["id"] != null)
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
            }

            this.ddrcity.Visible = false;
            this.ddrprovice.DataSource = dl.dvGetAllAre();
            this.ddrprovice.DataValueField = "ProvinceID";
            this.ddrprovice.DataTextField = "ProvinceName";
            this.ddrprovice.DataBind();

            //ListItem item = new ListItem();
           // item.Value = "-1";
            //item.Text = "--请选择--";
           // ddrprovice.Items.Add(item);

            this.ddrprovice.Items.FindByText("------").Selected=true;
    
            this.ddrxingye.DataSource = dl.dvGetVocation();
            this.ddrxingye.DataValueField = "industryBID";
            this.ddrxingye.DataTextField = "industryBName";
            this.ddrxingye.DataBind();


            ListItem items = new ListItem();
            items.Value = "-1";
            items.Text = "所有行业";
            ddrxingye.Items.Add(items);
            this.ddrxingye.Items.FindByValue("-1").Selected = true;

            DataView dv = dl.dvGetCity(this.ddrprovice.SelectedValue.ToString().Trim());

            if (dv.Count > 0 && this.ddrprovice.SelectedValue.ToString().Trim() != "0000")
            {
                this.ddrcity.Visible = true;
                this.ddrcity.DataSource = dv;
                this.ddrcity.DataValueField = "CityID";
                this.ddrcity.DataTextField = "CityName";
                this.ddrcity.DataBind();
                ListItem item = new ListItem();
                item.Value = "-1";
                item.Text = "--请选择--";
                this.ddrcity.Items.Add(item);
                this.ddrcity.Items.FindByValue("-1").Selected = true;

            }
            else { this.ddrcity.Visible = false; this.ddrcity.Items.Clear(); }
            if (Convert.ToInt32(Request["str"]) != 0)
            {
                int Id = Convert.ToInt32(Request["str"].ToString());
                Delete(Id);
            }

            ds = email.SelDataSet();
            BindShow();
        }
        
    }

    #region 条件查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        string ProvinceID = "";
        string Title = "";
        string industryClassList = "";
        string cityID = "";
    
        if (ddrprovice.SelectedValue.Trim() =="0000"||this.ddrprovice.SelectedIndex==0)
        {
            ProvinceID = "";
        }
        else
        {
            ProvinceID = " ProvinceID=" + Convert.ToInt32(ddrprovice.SelectedValue) + "";
        }
        if (ddrcity.SelectedValue.Trim() == "-1" || ddrcity.SelectedValue.Trim()=="")
        {
            cityID = "";
        }
        else
        {
          
                if (this.ddrprovice.SelectedValue.Trim() =="0000")
                {
                    cityID = " cityID=" + ddrcity.SelectedValue + "";
                }
                else
                {
                    cityID = " and cityID=" + ddrcity.SelectedValue + "";
                }
           
        }
        if (txtUserName.Text.Trim() != "")
        {
            if (ddrprovice.SelectedValue.ToString().Trim() =="0000" && ddrcity.SelectedValue == "")
            {
                Title = "  Title like '%" + txtUserName.Text.Trim() + "%'";
            }
            else
            {
                Title = " and Title like '%" + txtUserName.Text.Trim() + "%'";
            }
        }
        else { Title = ""; }

        if (ddrxingye.SelectedValue == "-1")
        {
            industryClassList = "";
        }
        else
        {
            if (ddrprovice.SelectedValue.ToString().Trim() =="0000" && ddrcity.SelectedValue =="" && txtUserName.Text.Trim() == "")
            {
                industryClassList = " industryClassList like '%" + ddrxingye.SelectedValue.ToString().Trim() + "%'";
            }
            else
            {
                industryClassList = " and industryClassList like '%" + ddrxingye.SelectedValue.ToString().Trim() + "%'";
            }
        }

        par = ProvinceID+cityID+ Title + industryClassList;
        if (par != "")
        {
            par = " infoid in(select infoid from [Search].[dbo].[MerchantInfoTab] where " + par + ") ";
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
            result1 =email.DelEmail(Convert.ToInt32(values[i].Trim()));

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
    #region 绑定
    private void BindShow()
    {

        
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        if (par == "")
        {
            par = " ";
        }
        this.Pager1.PageSize = 20;
        this.Pager1.StrWhere = par;
        this.Pager1.TableViewName = " EmailType,@,#";
        this.Pager1.KeyColumn = "id";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "time";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();

        
    }
    #endregion
    #region 获取字段值
    public string GetValues(string info, string Name)
    {
        string Values = string.Empty;
        switch(Name)
        {
            case "Title":
                foreach (DataRow rs in ds.Tables[0].Rows)
                {
                    if (rs["infoid"].ToString().Equals(info))
                    {
                        Values = rs["Title"].ToString();
                        break;
                    }
                }
                break;
            case "HtmlFile":
                break;
            case "Audit":
                foreach (DataRow rs in ds.Tables[0].Rows)
                {
                    if (rs["infoid"].ToString().Equals(info))
                    {
                        Values = rs["AuditingStatus"].ToString();
                        if (Values == "0")
                        {
                            Values = "未审核";
                        }
                        else if (Values == "1")
                        {
                            Values = "已审核";
                        }
                        else
                        {
                            Values = "审核未通过";
                        }
                        break;
                    }
                }
                break;
            default: return "";
        }
        return Values;
    }
    #endregion
    #region 根据省份查找所对应的城市
    protected void ddrprovice_SelectedIndexChanged(object sender, EventArgs e)
    {
        
           DataView  dv =dl.dvGetCity(this.ddrprovice.SelectedValue.ToString().Trim());

         if (dv.Count > 0 && this.ddrprovice.SelectedValue.ToString().Trim()!="0000")
        {
            this.ddrcity.Visible = true;
            this.ddrcity.DataSource = dv;
            this.ddrcity.DataValueField = "CityID";
            this.ddrcity.DataTextField = "CityName";
            this.ddrcity.DataBind();
            ListItem item = new ListItem();
            item.Value = "-1";
            item.Text= "--请选择--";
            this.ddrcity.Items.Add(item);
            this.ddrcity.Items.FindByValue("-1").Selected = true;
            
        }
        else { this.ddrcity.Visible = false; this.ddrcity.Items.Clear(); }
    }
      #endregion
    #region 删除
    private void Delete(int p)
    {
        int rs = email.DelEmail(p);
        if (rs > 0)
        {
            Response.Write("<script>alert('删除成功！')</script>");
        }
        else { Response.Write("<script>alert('删除失败！')</script>"); }
    }
    #endregion

}
