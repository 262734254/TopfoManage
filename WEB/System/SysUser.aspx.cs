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
using System.Data.SqlClient;

public partial class System_SysUser :BasePage  
{
    Tz888.BLL.Login.LoginInfoBLL loginbll = new Tz888.BLL.Login.LoginInfoBLL();
    Tz888.BLL.Sys.EmployeeInfoTab empBll = new Tz888.BLL.Sys.EmployeeInfoTab();
    DataTable dt=null;
    public int iPageSize = 15;
    public int pageindex = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //邦定部门
            BindDept();
            //邦定角色
            BindRole();
            //邦定岗位
            BindWorkType();

            ViewState["sort"] = " order by username desc ";
            BindData();
            ibtName_n.Visible = false;
            ibtDept_n.Visible = false;
            ibtWork_n.Visible = false;
            ibtStatus_n.Visible = false;
        }
    }

    //邦定数据
    private void BindData()
    {
        AspNetPager1.PageSize = iPageSize;
        pageindex = AspNetPager1.CurrentPageIndex;

        Tz888.Model.Sys.EmployeeInfoTab empMode = new Tz888.Model.Sys.EmployeeInfoTab();
        empMode.EmployeeName = tbLoginName.Value.Trim(); //账号
        empMode.DeptID = ddlDept.SelectedValue; //部门
        empMode.sRole = ddlRole.SelectedValue; //角色
        empMode.WorkType = ddlWorkType.SelectedValue; //岗位
        empMode.sStatus = ddlStatus.SelectedValue; //状态
        
        dt = loginbll.GetEmployeeList("page",  ViewState["sort"].ToString(), 1, 1, 1,empMode);
        if (dt != null && dt.Rows.Count > 0)
        {
            AspNetPager1.RecordCount = Tz888.Common.Text.FormatData(dt.Rows[0]["RecordCount"].ToString().Trim());
        }
        dt = null;
        dt = loginbll.GetEmployeeList("page", ViewState["sort"].ToString(), iPageSize, pageindex, 0,empMode);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptEmployeeList.DataSource = dt;
            rptEmployeeList.DataBind();
        }
        dt.Dispose();
        dt = null;
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        //BindData(e.NewPageIndex);
        //AspNetPager1.CurrentPageIndex =e.

        iPageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());
        BindData();
    }
    //去编辑
    public  string GotoEdit(string strID)
    {
        string str = "";
        if (strID != "")
        {
            str = "<a href=EmployeeModify.aspx?UserLoginName=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(strID) + " >";    
        }
        return str;
    }
    public string GetRoleName(string strRoleIDs)
    {
        string str = "无";
        string st = "";
        if (strRoleIDs.Trim() == "")
        {
            return str;
        }
        else
        {
            strRoleIDs = Tz888.Common.Text.FormatDh(strRoleIDs, ",");
            dt = loginbll.GetRoleName(strRoleIDs);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    st += dt.Rows[i]["SRName"].ToString().Trim() + ",";
                }
                str = Tz888.Common.Text.FormatDh(st, ",");
            }
        }
        return  Tz888.Common.Text.GetLenghtStr(str,32).Trim();
    }
    /// <summary>
    /// 将地null转成""字符
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string ConvertStr(string str)
    {
        if (str == null || str == "")
            return "无";
        else
            return str;
    }
    //邦定搜索条件
    /// <summary>
    /// 邦定部门
    /// </summary>
    private void BindDept()
    {
        string SqlTxt="select deptid,deptname  from setdeptinfotab ";
        dt = empBll.GetData("nopage", SqlTxt, "  order by deptid desc  ",1,1,0);
        if (dt != null & dt.Rows.Count > 0)
        {
            ddlDept.DataTextField = "deptname";
            ddlDept.DataValueField = "deptid";
            ddlDept.DataSource = dt;
            ddlDept.DataBind();

            ListItem liTemp = new ListItem();
            liTemp.Text = "==所有部门==";
            liTemp.Value = "";
            ddlDept.Items.Insert(0, liTemp);
        }
    }
    /// <summary>
    /// 邦定角色
    /// </summary>
    private void BindRole()
    {
        string SqlTxt = "select sroleid,srname from sysroletab  ";
        dt = empBll.GetData("nopage", SqlTxt, "  order by sroleid desc  ", 1, 1, 0);
        if (dt != null & dt.Rows.Count > 0)
        {
            ddlRole.DataTextField= "srname";
            ddlRole.DataValueField= "sroleid";
            ddlRole.DataSource = dt;
            ddlRole.DataBind();

            ListItem liTemp = new ListItem();
            liTemp.Text = "==所有角色==";
            liTemp.Value = "";
            ddlRole.Items.Insert(0, liTemp);
        }
    }
    /// <summary>
    /// 邦定岗位
    /// </summary>
    private void BindWorkType()
    {
        string SqlTxt = "select Worktype,WorktypeName from setworktypetab  ";
        dt = empBll.GetData("nopage", SqlTxt, " order by Worktype desc    ", 1, 1, 0);
        if (dt != null & dt.Rows.Count > 0)
        {
            ddlWorkType.DataTextField = "WorktypeName";
            ddlWorkType.DataValueField = "Worktype";
            ddlWorkType.DataSource = dt;
            ddlWorkType.DataBind();

            ListItem liTemp = new ListItem();
            liTemp.Text = "==所有岗位==";
            liTemp.Value = "";
            ddlWorkType.Items.Insert(0, liTemp);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        iPageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());
        AspNetPager1.CurrentPageIndex = 1;
        BindData();
    }
    protected void ibtName_p_Click(object sender, ImageClickEventArgs e)
    {
        ibtName_p.Visible = false;
        ibtName_n.Visible = true;
        ViewState["sort"] = " order by username desc ";
        BindData();
    }
    protected void ibtName_n_Click(object sender, ImageClickEventArgs e)
    {
        ibtName_n.Visible = false;
        ibtName_p.Visible = true;
        ViewState["sort"] = " order by username asc ";
        BindData();
    }
    protected void ibtDept_p_Click(object sender, ImageClickEventArgs e)
    {
        ibtDept_p.Visible = false;
        ibtDept_n.Visible = true;
        ViewState["sort"] = " order by deptid desc ";
        BindData();
    }
    protected void ibtDept_n_Click(object sender, ImageClickEventArgs e)
    {
        ibtDept_n.Visible = false;
        ibtDept_p.Visible = true;
        ViewState["sort"] = " order by deptid asc ";
        BindData();
    }
    protected void ibtWork_p_Click(object sender, ImageClickEventArgs e)
    {
        ibtWork_p.Visible = false;
        ibtWork_n.Visible = true;
        ViewState["sort"] = " order by worktype desc ";
        BindData();
    }
    protected void ibtWork_n_Click(object sender, ImageClickEventArgs e)
    {
        ibtWork_n.Visible = false;
        ibtWork_p.Visible = true;
        ViewState["sort"] = " order by worktype asc ";
        BindData();
    }
    protected void ibtStauts_p_Click(object sender, ImageClickEventArgs e)
    {
        ibtStauts_p.Visible = false;
        ibtStatus_n.Visible = true;
        ViewState["sort"] = " order by enable desc ";
        BindData();
    }
    protected void ibtStatus_n_Click(object sender, ImageClickEventArgs e)
    {
        ibtStatus_n.Visible = false;
        ibtStauts_p.Visible = true;
        ViewState["sort"] = " order by enable asc ";
        BindData();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        iPageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());
        BindData();
    }
}
