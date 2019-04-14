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
using System.Text;
using System.Collections.Generic;

public partial class daikuan_test : Tz888.Common.Pager.BasePage
{
    Tz888.BLL.loansInfoTab loansinfotabbll = new Tz888.BLL.loansInfoTab();
    Tz888.BLL.LoansInfo loansinfobll = new Tz888.BLL.LoansInfo();
    Tz888.BLL.loanscontactsTab loanscontactstab = new Tz888.BLL.loanscontactsTab();
    string CasesTem = ConfigurationManager.AppSettings["DKAppPath"].ToString(); //其他成功案例模版存放位置
    private static Tz888.BLL.Compage com = new Tz888.BLL.Compage();
    private string par
    {
        get
        {
            return ViewState["par"].ToString ();
        }
        set
        {
            ViewState["par"] = value;
        }
    }
    private int size
    {
        get
        {
            return Convert .ToInt32(ViewState["size"]);
        }
        set
        {
            ViewState["size"] = value;
        }
    }
    private int index
    {
        get
        {
            return Convert.ToInt32(ViewState["index"]);
        }
        set
        {
            ViewState["index"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
         size = 20;
        
        if (!IsPostBack)
        {
            par = "";

            if (Convert.ToInt32(Request["LoansInfoID"]) != 0)
            {
                    int Id = Convert.ToInt32(Request["LoansInfoID"].ToString());
                    DeleteLoansInfoTab(Id);
                

            }
            ChangePage(par);

        }

    }


    private void DeleteLoansInfoTab(int Id)
    {
        Tz888.Model.LoansInfoTab infotab = loansinfotabbll.GetLoansInfoTabByLoansInfoId(Id);
        int result1 = loansinfobll.DeleteLoansInfo(Id);
        int result2 = loanscontactstab.DeleteloanscontactsTab(Id);
        if (result1 > 0 && result2 > 0)
        {
            int result = loansinfotabbll.DeleteLoansInfoTab(Id);

            if (infotab.Url.Trim () != "")
            {
                string[] html = infotab.Url.Split('/');
                string[] cc = html[2].Split('.');
                com.DeleteFile(@CasesTem + html[1].ToString() + @"\" + html[2].ToString());
            }
            if (result > 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除成功");
               
            }
            else { Tz888.Common.MessageBox.Show(this.Page, "删除失败"); }
        }
        else { Tz888.Common.MessageBox.Show(this.Page, "删除失败"); }
       
    }

    public string GetType(int BorrowingType)
    {
        string par = "";
        if (BorrowingType == 0)
        {
            par = "个人";
        }
        else { par = "企业"; }
        return par;
    }
    public string GetStatu(int AuditID)
    {
        string par = "";
        if (AuditID == 0)
        {
            par = "未审核";
        }
        if (AuditID == 3)
        {
            par = "审核未通过";
        }
        if(AuditID ==1) { par = "审核已通过"; }
        if (AuditID == 5) { par = "已删除"; }
        return par;
    }
    public string GetTime(string times)
    {
        return times.Substring(0,9);
    }

    public void ChangePage(string str)
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        if (str == "")
        {
            str = " 1=1";
        }
        this.Pager1.PageSize = size;
        this.Pager1.StrWhere = str;
        this.Pager1.TableViewName = "LoansInfoTabView";
        this.Pager1.KeyColumn = "LoansInfoID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "loansdate";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的项目!");
            return;
        }
        int result=0;
        for (int i = 0; i < values.Length; i++)
        {
            int result1 = loansinfobll.DeleteLoansInfo(Convert .ToInt32(values[i].Trim()));
            int result2 = loanscontactstab.DeleteloanscontactsTab(Convert.ToInt32(values[i].Trim()));
            Tz888.Model.LoansInfoTab infotab = loansinfotabbll.GetLoansInfoTabByLoansInfoId(Convert.ToInt32(values[i].Trim()));
            if (result1 > 0 && result2 > 0)
            {
                result = loansinfotabbll.DeleteLoansInfoTab(Convert.ToInt32(values[i].Trim()));
                if (infotab.Url.Trim() != "")
                {
                    string[] html = infotab.Url.Split('/');
                    string[] cc = html[2].Split('.');
                    com.DeleteFile(@CasesTem + html[1].ToString() + @"\" + html[2].ToString());
                }
            }
           
        }
        if (result > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除成功!");
        }
        else 
        {
            Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
        }

        ChangePage(par); 

       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string bianhao ="";
        string type="";
        string statu="";
        string name = "";
        if (txtNuber.Value.Trim() == "")
        {
            bianhao = "";
        }
        else { bianhao = " loansInfoID=" + txtNuber.Value.Trim() + ""; }
        if (Convert.ToInt32(ddlType.SelectedValue.Trim()) == 2)
        {
            type = "";

        }
        else 
        {
            if (txtNuber.Value.Trim() == "")
            {
                type = " BorrowingType=" + ddlType.SelectedValue.Trim();
            }
            else 
            {
                type = " and BorrowingType=" + ddlType.SelectedValue.Trim();
            }
        }
        if (Convert.ToInt32(ddlStatus.SelectedValue.Trim()) == 2)
        {
            statu = "";
        }
        else 
        {
            if (txtNuber.Value.Trim() == "" && Convert.ToInt32(ddlType.SelectedValue.Trim()) == 2)
            {
                statu = " auditID=" + ddlStatus.SelectedValue.Trim();
            }
            else { statu = " and auditID=" + ddlStatus.SelectedValue.Trim(); }
        }

        if (txtName.Text.Trim() == "")
        {
            name = "";
        }
        else 
        {
            if (txtNuber.Value.Trim() == "" && Convert.ToInt32(ddlType.SelectedValue.Trim()) == 2 && Convert.ToInt32(ddlStatus.SelectedValue.Trim()) == 2)
            {
                name = " LoginName='" + txtName.Text.Trim()+"'";
            }
            else 
            {
                name = " and LoginName='" + txtName.Text.Trim()+"'";
            }
        }
        if (bianhao == "" && type == "" && statu == "" && name == "")
        {
            par = "";
        }
        else
        {
            par =""+ bianhao + type + statu + name;
        }
        ChangePage(par);
    }
    public string FormatNull(string strFile, int iLong)
    {
        if (strFile.GetType().ToString() == "System.DBNull")
            return "";
        else
        {
            if (iLong == 0)
                return strFile;
            else if (strFile.Length > iLong)
                return strFile.Substring(0, iLong) + "...";
            else
                return strFile;
        }
    }
    protected void btnpublic_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要静态化的资源!");
            return;
        }
        int result = 0;
        int results = 0;
        for (int i = 0; i < values.Length; i++)
        {
            Tz888.Model.LoansInfoTab infotab = loansinfotabbll.GetLoansInfoTabByLoansInfoId(Convert.ToInt32(values[i].Trim()));
            if (infotab.AuditID == 1 && infotab.BorrowingType == 0)
            {
                Tz888.BLL.Loans.PageStatic stat = new Tz888.BLL.Loans.PageStatic();
                result = stat.StaticHtml(Convert.ToInt32(values[i].Trim()));
     
            }
            if (infotab.AuditID == 1 && infotab.BorrowingType == 1)
            {
                Tz888.BLL.Loans.PageStaticenprice stats = new Tz888.BLL.Loans.PageStaticenprice();

                results = stats.StaticHtml(Convert.ToInt32(values[i].Trim()));
             
            }
        }
        Tz888.Common.MessageBox.Show(this.Page, "生成成功");
        ChangePage(par);
       
       
    }
}