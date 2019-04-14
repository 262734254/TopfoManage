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

public partial class Mail_MailInfoManage: Tz888.Common.Pager.BasePage
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
            return Convert .ToInt32(ViewState["count"]);
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
           
            if (Request.QueryString["id"] != null)
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
            }
        
            count = 0;
            par = " ";
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
        {
            Response.Write("<script>alert('删除成功！')</script>");
        }
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
                par = " 1=1   and logiName='"+bp.LoginName+"' ";
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
        string par="";
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
    public string Getdiyu(int priovid,int cityid)
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
        string  privory= "";
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
        if (Convert.ToInt32(ddrstatue .SelectedValue) == -1)
        {
            statue = "";
        }
        else 
        {
            if (Convert.ToInt32(ddrleixing.SelectedValue) == -1 && Convert.ToInt32(ddrzu.SelectedValue) == -1 && txtUserName.Text.Trim() == "" && Convert.ToInt32(ddrprovice.SelectedValue) == -1 && this.ddrcity.Visible == false&&Convert.ToInt32(ddrxingye.SelectedValue) == -1)
            {
                statue = " Audit=" + Convert.ToInt32(ddrstatue.SelectedValue) + "";
            }
            else 
            {
                statue = " and Audit=" + Convert.ToInt32(ddrstatue.SelectedValue) + "";
            }
        }
        if (type.Trim() == "" && zu.Trim() == "" && mingche.Trim() == "" && privory.Trim() == "" && city.Trim() == "" && xingye.Trim() == ""&&statue .Trim ()=="")
        {
            par = " 1=1 ";
        }
        else
        {
            par = "" + type + zu + mingche + privory + city + xingye+statue+" ";
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

    #region 导出数据
    protected void btnDaoChu_Click(object sender, EventArgs e)
    {
        List<Tz888.Model.Mail.MailInfo> list = mailinfobll.GetModelList(par);
        dt.Rows.Clear();
        foreach (Tz888.Model.Mail.MailInfo model in list)
        {
            DataRow dr = dt.NewRow();
            //单位名称  联系人 手机  电话  邮箱  类型 职位
           // dr["编号"] = model .UserID;
            //dr["账号"] = model.LoginName;
            dr["名称"] = model .UserName;
            dr["公司名称"] = model.PanyName;
            Tz888.Model.Mail.Position modelpo = positionbll.GetModel(Convert .ToInt32(model .PositionId));
            if (modelpo != null)
            {
                dr["职位"] = modelpo.Name;
                //dr["地址"] = model.Address;
                //dr["网址"] = model.LinkUrl;
                Tz888.Model.Mail.MailType modeltype = mailtypebll.GetModel(Convert.ToInt32(model.typeID));
                string type = modeltype.TypeName.Trim();
                dr["类型"] = type;
                string diyu = "";
                Tz888.Model.Mail.Province modelp = provincebll.GetModel(Convert.ToInt32(model.ProvinceId));
                Tz888.Model.Mail.City modelc = citybll.GetModel(Convert.ToInt32(model.CityId));
                if (modelc != null)
                {
                    diyu = modelp.Name + ": " + modelc.Name;
                }
                else { diyu = modelp.Name; }
               // dr["地域"] = diyu;
                if (Convert.ToInt32(model.industry) != -1)
                {
                    Tz888.Model.Mail.Industry modelIndustry = industrybll.GetModel(Convert.ToInt32(model.industry));
                    string xingye = modelIndustry.Name.Trim();
                  //  dr["行业"] = xingye;
                }
                else { //dr["行业"] = "所有行业";
                }
               // string statue = "";
               // if (model.audit == 0)
                //{
                  //  statue = "未审核";
                //}
                //else { statue = "已审核"; }
                //dr["状态"] = statue;
                dr["邮件"] = model.Mial;
                dr["手机"] = model.Mobile;
                Tz888.Model.Mail.Mialgroup modelpr = mialgroupbll.GetModel(Convert.ToInt32(model.groupID));
               // dr["组"] = modelpr.groupname;
               // dr["备注"] = model.remark;
                //dr["时间"] = model.Mdatetime;
                //dr["操作"] = "";

                dt.Rows.Add(dr);
            }
        }
      
        HSSFWorkbook hssfworkbook = new HSSFWorkbook();
        DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
        dsi.Company = "深圳拓富投资有限公司";
        SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
        si.Subject = "邮件用户管理";
        si.Author = "颜品庄";

        si.CreateDateTime = DateTime.Now;
        hssfworkbook.DocumentSummaryInformation = dsi;
        hssfworkbook.SummaryInformation = si;

        HSSFSheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
        //sheet1.DefaultColumnWidth=10;设置列宽
        HSSFRow row = sheet1.CreateRow(0);
       // row.CreateCell(0).SetCellValue("编号");
       // row.CreateCell(1).SetCellValue("账号");
        row.CreateCell(0).SetCellValue("名称");
        row.CreateCell(1).SetCellValue("公司名称");
        row.CreateCell(2).SetCellValue("职位");
       // row.CreateCell(5).SetCellValue("地址");
      //  row.CreateCell(6).SetCellValue("网址");
        row.CreateCell(3).SetCellValue("类型");
       // row.CreateCell(8).SetCellValue("地域");
       // row.CreateCell(9).SetCellValue("行业");
       // row.CreateCell(10).SetCellValue("状态");
        row.CreateCell(4).SetCellValue("邮件");
        row.CreateCell(5).SetCellValue("手机");
       // row.CreateCell(13).SetCellValue("组");
      //  row.CreateCell(14).SetCellValue("备注");
        //row.CreateCell(6).SetCellValue("时间");
       // row.CreateCell(16).SetCellValue("操作");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            HSSFRow row0 = sheet1.CreateRow(i + 1);
           // row0.CreateCell(0).SetCellValue(dt.Rows[i]["编号"].ToString());
           // row0.CreateCell(1).SetCellValue(dt.Rows[i]["账号"].ToString());
            row0.CreateCell(0).SetCellValue(dt.Rows[i]["名称"].ToString());
            row0.CreateCell(1).SetCellValue(dt.Rows[i]["公司名称"].ToString());
            row0.CreateCell(2).SetCellValue(dt.Rows[i]["职位"].ToString());
           //row0.CreateCell(5).SetCellValue(dt.Rows[i]["地址"].ToString());
            //row0.CreateCell(6).SetCellValue(dt.Rows[i]["网址"].ToString());
            row0.CreateCell(3).SetCellValue(dt.Rows[i]["类型"].ToString());
            //row0.CreateCell(8).SetCellValue(dt.Rows[i]["地域"].ToString());
            //row0.CreateCell(9).SetCellValue(dt.Rows[i]["行业"].ToString());
            //row0.CreateCell(10).SetCellValue(dt.Rows[i]["状态"].ToString());
            row0.CreateCell(4).SetCellValue(dt.Rows[i]["邮件"].ToString());
            row0.CreateCell(5).SetCellValue(dt.Rows[i]["手机"].ToString());
            //row0.CreateCell(13).SetCellValue(dt.Rows[i]["组"].ToString());
            //row0.CreateCell(14).SetCellValue(dt.Rows[i]["备注"].ToString());
            //row0.CreateCell(15).SetCellValue(dt.Rows[i]["时间"].ToString());
           // row0.CreateCell(6).SetCellValue(dt.Rows[i]["操作"].ToString());
           
         }
        string t1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();

        string filename = "attachment;filename=" + System.Web.HttpUtility.UrlEncode("邮件用户表" + t1, System.Text.Encoding.UTF8) + ".xls";
        Response.ContentType = "application/vnd.ms-excel";
        //Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
        Response.AppendHeader("Content-Disposition", filename);
        Response.Clear();

        //Write the stream data of workbook to the root directory
        MemoryStream filestream = new MemoryStream();
        hssfworkbook.Write(filestream);

        Response.BinaryWrite(filestream.GetBuffer());
        Response.End();
    }
    #endregion

    #region 导入数据
    protected void btndaoru_Click(object sender, EventArgs e)
    {
        saveBPath = ConfigurationManager.AppSettings["upexcle"].ToString() + "MailInfo.xls";

        if (count == 1)
        {
            DataTable BdtExcel = ExcelToDataTable(saveBPath, "Sheet1");
            if (BdtExcel != null)
            {
                foreach (DataRow row in BdtExcel.Rows)
                {

                    string zhanghao = row["账号"].ToString();
                    string UserNames = row["名称"].ToString();
                    string panyname = row["公司名称"].ToString();
                    string dizhi = row["地址"].ToString();
                    string wangzhi = row["网址"].ToString();
                    string zhiwei = row["职位"].ToString();
                    string type = row["类型"].ToString();
                    string diyu = row["地域"].ToString();
                    string xingye = row["行业"].ToString();
                    string statu = row["状态"].ToString();
                    string Mail = row["邮件"].ToString();
                    string shouji = row["手机"].ToString();
                    string zu = row["组"].ToString();
                    string beizhu = row["备注"].ToString();

                    string sd = row["时间"].ToString();

                    string sdasd = row["操作"].ToString();

                    Tz888.Model.Mail.Industry modelI = industrybll.GetModelByName(xingye);
                    Tz888.Model.Mail.MailInfo model = new Tz888.Model.Mail.MailInfo();

                    string[] diyulist = diyu.Split(':');
                    if (diyulist.Length > 1)
                    {
                        Tz888.Model.Mail.Province modelp = provincebll.GetModelByName(diyulist[0].ToString().Trim());
                        Tz888.Model.Mail.City modelc = citybll.GetModelByName(diyulist[1].ToString().Trim());
                        model.ProvinceId = Convert.ToInt32(modelp.Id);
                        model.CityId = Convert.ToInt32(modelc.Id);
                    }
                    else
                    {
                        Tz888.Model.Mail.Province modelps = provincebll.GetModelByName(diyu.Trim());
                        model.ProvinceId = Convert.ToInt32(modelps.Id);
                        model.CityId = 0;
                    }

                    model.LoginName = zhanghao;
                    model.UserName = UserNames.Trim();
                    Tz888.Model.Mail.MailType modeltype = mailtypebll.GetModelByTypeName(type);
                    model.PanyName = panyname.Trim();
                    model.PositionId = Convert.ToInt32(positionbll.GetModelByName(zhiwei.Trim()).Id);
                    model.Address = dizhi.Trim();
                    model.LinkUrl = wangzhi.Trim();

                    if (statu.Trim() == "未审核")
                    {
                        model.audit = 0;
                    }
                    else { model.audit = 1; }
                    if (xingye.Trim() != "所有行业")
                    {
                        model.industry = Convert.ToInt32(industrybll.GetModelByName(xingye.Trim()).Id);
                    }
                    else { model.industry = -1; }
                    model.Mial = Mail.Trim();
                    model.Mobile = shouji.Trim();
                    model.typeID = Convert.ToInt32(modeltype.typeID);
                    model.groupID = Convert.ToInt32(mialgroupbll.GetModelByName(zu.Trim()).groupID);
                    model.remark = beizhu.Trim();
                    model.Mdatetime = sd;
                    int result = mailinfobll.Add(model);
                }
            }
            else { Response.Write("<script>alert('请上传的Excel表格！');</script>"); }
        }
        else { Response.Write("<script>alert('请上传的Excel表格！');</script>"); }
        BindShow();
    }
    #endregion

    public static bool checkFileType(string type)
    {

        bool FileType = false;

        string[] type_ = new string[4];

        type = type.ToLower();

        type_[0] = ".xls";

        type_[1] = ".XLS";

        type_[2] = ".xls";

        type_[3] = ".Xls";

        //可在此添加上传文件的后缀名

        for (int i = 0; i < type_.Length; i++)
        {

            if (type.Contains(type_[i].ToString()))
            {

                FileType = true;

            }

        }

        return FileType;

    }

    #region 上传文件
    protected void btnup_Click(object sender, EventArgs e)
    {
        string savePath = ConfigurationManager.AppSettings["upexcle"].ToString();
        try
        {
            if (fulExcel.HasFile)
            {
                string fileExt = System.IO.Path.GetExtension(fulExcel.FileName);
                string[] names = fulExcel.FileName.ToString().Split('.');

                for (int i = 0; i < names.Length; i++)
                {
                    string namess = names[0].ToString();
                }
                if (fileExt == ".xls")
                {
                    try
                    {
                        savePath += "MailInfo.xls";
                        fulExcel.SaveAs(savePath);

                        Response.Write("<script>alert('上传成功！');</script>");
                        count = 1;
                       
                    }
                    catch
                    {
                        Response.Write("<script>alert('上传失败！请检查上传的文件！');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('只允许上传*.xls文件！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('没有上传的文件！');</script>");
            }
        }
        catch (Exception exx)
        {

        }
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
