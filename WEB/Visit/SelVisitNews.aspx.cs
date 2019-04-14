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
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using System.IO;
using System.Collections.Generic;
using Tz888.DBUtility;
using System.Data.SqlClient;

public partial class Visit_SelVisitNews : Tz888.Common.Pager.BasePage
{
   
    private int _myPageSize = 20;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            ManageType();
            ViewState["Criteria"] = "";
            SetPagerParameters();
        }
    }

    /// <summary>
    /// 绑定分页
    /// </summary>
    private void SetPagerParameters()
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        string str = "";
        if (ViewState["MyPageSize"] != null)
            this._myPageSize = Convert.ToInt32(ViewState["MyPageSize"]);
        else
            ViewState["MyPageSize"] = this._myPageSize;
        string time = "2011-1-1";
        str = " " + ViewState["Criteria"].ToString().Trim();
        this.Pager1.PageSize = this._myPageSize;
        this.Pager1.StrWhere = str;
        this.Pager1.TableViewName = "MemberLoginInfoView";
        this.Pager1.KeyColumn = "MemberID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "RegisterTime";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    }

    public string GetType(string TypeID)
    {
        string TypeName = "&nbsp;";
        TypeID = TypeID.Trim();
        switch (TypeID)
        {
            case "1001":
                TypeName = "个人";
                break;
            case "1002":
                TypeName = "个体经营";
                break;
            case "1003":
                TypeName = "企业单位";
                break;
            case "1004":
                TypeName = "政府机构";
                break;
            case "2001":
                TypeName = "政府招商";
                break;
            case "2002":
                TypeName = "投资单位";
                break;
            case "2003":
                TypeName = "融资单位";
                break;
            case "2004":
                TypeName = "中介机构";
                break;
            case "2005":
                TypeName = "资源联盟";
                break;
            case "2006":
                TypeName = "专业人才";
                break;
            case "2007":
                TypeName = "服务机构";
                break;
            case "2008":
                TypeName = "东莞台商会员";
                break;
        }
        return TypeName;
    }


    /// <summary>
    /// 翻译类型
    /// </summary>
    private void ManageType()
    {
        Tz888.BLL.Visit.VisitInfoBLL visit = new Tz888.BLL.Visit.VisitInfoBLL();
        this.ddlTypeID.DataSource = visit.SelManageTypeName();
        this.ddlTypeID.DataTextField = "ManageTypeName";
        this.ddlTypeID.DataValueField = "ManageTypeID";
        this.ddlTypeID.DataBind();
        ddlTypeID.Items.Insert(0, new ListItem("请选择 ", ""));

    }

    /// <summary>
    /// 按条件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSel_Click(object sender, EventArgs e)
    {
        RetureWhere();
        SetPagerParameters();
    }


    public void RetureWhere()
    {
        ViewState["Criteria"] = "";
        string name = "";

        if (this.txtLoginName.Text != "")
        {
            name += " LoginName='" + this.txtLoginName.Text.Trim() + "' and ";
        }
        if (this.txtNickName.Text != "")
        {
            name += " NickName='" + this.txtNickName.Text.Trim() + "' and ";
        }
        //if (this.ZoneSelectControl1.CountryID != "")
        //{
        //    name += " CountryCode='" + this.ZoneSelectControl1.CountryID.Trim() + "' and ";
        //}
        if (this.ZoneSelectControl1.ProvinceID != "")
        {
            name += " ProvinceID='" + this.ZoneSelectControl1.ProvinceID + "' and ";
        }
        if (this.ZoneSelectControl1.CountyID != "")
        {
            name += " CountyID='" + this.ZoneSelectControl1.CountyID + "' and ";
        }
        if (this.ddlTypeID.SelectedValue != "")
        {
            name += " ManageTypeID='" + this.ddlTypeID.SelectedValue.Trim() + "' and ";
        }

        if (txtTime.Value.Trim() != "" && txtTime1.Value.Trim() != "")
        {
            name += " RegisterTime>='" + this.txtTime.Value.Trim() + "' and ";
            name += " RegisterTime<='" + this.txtTime1.Value.Trim() + "' and ";
        }
        else
        {
            if (this.txtTime.Value != "")
            {
                name += " replace(Convert(varchar(10),RegisterTime,111),'/','-')='" + this.txtTime.Value.Trim() + "' and ";
            }

            if (this.txtTime1.Value != "")
            {
                name += " replace(Convert(varchar(10),RegisterTime,111),'/','-')='" + this.txtTime1.Value.Trim() + "' and ";
            }
        }

        ViewState["Criteria"] = name + " 1=1";
    }


    protected string Province(int a, string name)
    {
        Tz888.BLL.Visit.VisitInfoBLL visit = new Tz888.BLL.Visit.VisitInfoBLL();
        string com = "";
        int num = visit.SelValidNew(a, name);
        if (a == 1)
        {
            switch (num)
            {
                //case 0:
                //    com = "无效";
                //    break;
                //case 1:
                //    com = "有效";
                //    break;
                case 0:
                    com = "有效";
                    break;
                case 1:
                    com = "无效";
                    break;
            }
        }
        else if (a == 2)
        {
            switch (num)
            {
                case 0:
                    com = "未回访";
                    break;
                case 1:
                    com = "已回访";
                    break;
            }
        }
        return com;
    }

    protected void btnDC_Click(object sender, EventArgs e)
    {
        //单位名称    联系人         手机     电话     邮箱     会员类型 
        //contacname  membername     mobile        tel      Email    managetypeid
        RetureWhere();
        Tz888.BLL.Visit.VisitInfoBLL visit = new Tz888.BLL.Visit.VisitInfoBLL();
        DataTable dt=visit.SelDataTable(ViewState["Criteria"].ToString());
        Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();
        HSSFWorkbook hssfworkbook = new HSSFWorkbook();
        DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
        dsi.Company = "深圳拓富投资有限公司";
        SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
        si.Subject = "会员管理";
        si.Author = "颜品庄";
    
        
        si.CreateDateTime = DateTime.Now;
        hssfworkbook.DocumentSummaryInformation = dsi;
        hssfworkbook.SummaryInformation = si;

        HSSFSheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
        //sheet1.DefaultColumnWidth=10;设置列宽
        HSSFRow row = sheet1.CreateRow(0);

  
        row.CreateCell(0).SetCellValue("单位名称");
        row.CreateCell(1).SetCellValue("联系人");
        row.CreateCell(2).SetCellValue("手机");
        row.CreateCell(3).SetCellValue("电话");
        row.CreateCell(4).SetCellValue("邮件");
        row.CreateCell(5).SetCellValue("会员类型");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            HSSFRow row0 = sheet1.CreateRow(i + 1);

            DataTable dt1 = obj1.GetLoginInfoList("*", " LoginID=" + dt.Rows[i]["LoginID"].ToString() + " ", "LoginName");
            row0.CreateCell(0).SetCellValue(dt1.Rows[0]["contactname"].ToString());
            row0.CreateCell(1).SetCellValue(dt.Rows[i]["membername"].ToString());
            row0.CreateCell(2).SetCellValue(dt.Rows[i]["mobile"].ToString());
            row0.CreateCell(3).SetCellValue(dt.Rows[i]["tel"].ToString());
            row0.CreateCell(4).SetCellValue(dt.Rows[i]["Email"].ToString());
            row0.CreateCell(5).SetCellValue(visit.SelManageType(dt.Rows[i]["managetypeid"].ToString()));
           

        }
        string t1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();

        string filename = "attachment;filename=" + System.Web.HttpUtility.UrlEncode("会员表" + t1, System.Text.Encoding.UTF8) + ".xls";
        Response.ContentType = "application/vnd.ms-excel";
        Response.AppendHeader("Content-Disposition", filename);
        Response.Clear();

        MemoryStream filestream = new MemoryStream();
        hssfworkbook.Write(filestream);

        Response.BinaryWrite(filestream.GetBuffer());
        Response.End();

     #region
       
        //RetureWhere();
        //DataTable d = new DataTable();
        //DataTable dt = new DataTable();
        //dt.Columns.Add("编号", typeof(String));
        //dt.Columns.Add("用户名", typeof(String));
        //dt.Columns.Add("邮箱", typeof(String));
        //dt.Columns.Add("座机", typeof(String));
        //dt.Columns.Add("手机", typeof(String));
        //dt.Columns.Add("会员类型", typeof(String));

        //string sql = "select * from MemberLoginInfoView" + (string.IsNullOrEmpty(ViewState["Criteria"].ToString()) ? "" : " where " + ViewState["Criteria"].ToString());
        //this.Page.RegisterStartupScript("K", "<script>alert('" + sql + "')</script>");
        //string connStr = ConfigurationManager.ConnectionStrings["SQLConnString1"].ToString();
        //using (SqlConnection con = new SqlConnection(connStr))
        //{
        //    SqlCommand com = new SqlCommand();
        //    com.CommandText = sql;
        //    com.Connection = con;
        //    con.Open();
        //    SqlDataAdapter dp = new SqlDataAdapter();
        //    dp.SelectCommand = com;
        //    dp.Fill(d);
        //};

        //foreach (DataRow r in d.Rows)
        //{
        //    DataRow dr = dt.NewRow();
        //    dr["编号"] = r["MemberID"].ToString();
        //    dr["用户名"] = r["LoginName"].ToString();
        //    dr["邮箱"] = r["Email"].ToString();
        //    dr["座机"] = r["Tel"].ToString();
        //    dr["手机"] = r["Mobile"].ToString();
        //    dr["会员类型"] = GetType(r["ManageTypeID"].ToString());
        //    dt.Rows.Add(dr);
        //}

        //HSSFWorkbook hssfworkbook = new HSSFWorkbook();
        //DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
        //dsi.Company = "深圳拓富投资有限公司";
        //SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
        //si.Subject = "会员管理";
        //si.Author = "颜品庄";

        //si.CreateDateTime = DateTime.Now;
        //hssfworkbook.DocumentSummaryInformation = dsi;
        //hssfworkbook.SummaryInformation = si;

        //HSSFSheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
        //HSSFRow row = sheet1.CreateRow(0);
        //row.CreateCell(0).SetCellValue("编号");
        //row.CreateCell(1).SetCellValue("用户名");
        //row.CreateCell(2).SetCellValue("邮箱");
        //row.CreateCell(3).SetCellValue("座机");
        //row.CreateCell(4).SetCellValue("手机");
        //row.CreateCell(5).SetCellValue("会员类型");

        ////单位名称    联系人         手机     电话     邮箱     会员类型 
        ////contacname  membername     mobile        tel      Email    managetypeid
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    HSSFRow row0 = sheet1.CreateRow(i + 1);
        //    row0.CreateCell(0).SetCellValue(dt.Rows[i]["编号"].ToString());
        //    row0.CreateCell(1).SetCellValue(dt.Rows[i]["用户名"].ToString());
        //    row0.CreateCell(2).SetCellValue(dt.Rows[i]["邮箱"].ToString());
        //    row0.CreateCell(3).SetCellValue(dt.Rows[i]["座机"].ToString());
        //    row0.CreateCell(4).SetCellValue(dt.Rows[i]["手机"].ToString());
        //    row0.CreateCell(5).SetCellValue(dt.Rows[i]["会员类型"].ToString());
        //}
        //string t1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();

        //string filename = "attachment;filename=" + System.Web.HttpUtility.UrlEncode("会员表" + t1, System.Text.Encoding.UTF8) + ".xls";
        //Response.ContentType = "application/vnd.ms-excel";
        //Response.AppendHeader("Content-Disposition", filename);
        //Response.Clear();

        //MemoryStream filestream = new MemoryStream();
        //hssfworkbook.Write(filestream);

        //Response.BinaryWrite(filestream.GetBuffer());
        //Response.End();

        #endregion


       

      
    }
}
