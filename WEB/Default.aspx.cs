using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBind("0");
            //if (Request.QueryString["sid"] != null)
            //{
            //    dataBind(Request.QueryString["sid"].ToString());
            //}
        }
    }
    protected string getEmployeeID()
    {
        BasePage bp = new BasePage();

        string LoginName = bp.LoginName;
        Tz888.BLL.Sys.EmployeeInfoTab EmployeeBll = new Tz888.BLL.Sys.EmployeeInfoTab();
        DataSet ds = EmployeeBll.GetList(" LoginName='" + LoginName + "'");
        string EmployeeID = "0";
        if (ds.Tables[0].Rows.Count > 0) 
        {
            EmployeeID = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
        }
        
        // Response.Cookies["loginedUser"].Value; //从cookie中获取登录成功后的用户名

        return EmployeeID;
    }
    #region 获取用户权限码
    protected string getTem()
    {
        string tem = "";
        Tz888.BLL.Sys.System sysBLL = new Tz888.BLL.Sys.System();
        DataSet ds = sysBLL.GetList(" EmployeeID='" + getEmployeeID() + "'");
        if (ds.Tables[0].Rows.Count>0)
        {
            tem = ds.Tables[0].Rows[0]["Tem"].ToString();
        }
        return tem;
    }
    #endregion

    #region 获取并解析菜单码
    protected DataSet getRoleID(string tem, string SParentCode)
    {
        string[] tems = tem.Split(',');
        if (tem != "")
        {
            string strWhere = " RoleID in (";    //拼接查询条件
            for (int i = 0; i < tems.Length; i++)
            {
                if (i < tems.Length - 1)
                {
                    strWhere = strWhere + tems[i] + ",";
                }
                else
                {
                    strWhere = strWhere + tems[i];
                }
            }
            strWhere += ")";
            Tz888.BLL.Sys.SysPermissionTab sysPerm = new Tz888.BLL.Sys.SysPermissionTab();
            DataSet ds = sysPerm.GetList(strWhere);
            string spCode = "";    //获取所有的菜单码
            if (ds.Tables[0] != null)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    spCode = spCode + ds.Tables[0].Rows[j]["SPCode"].ToString();
                }
            }
            //拼接菜单码查询条件
            string strspCode = " scode in (";
            string[] strspCodes = spCode.Split(',');
            for (int f = 0; f < strspCodes.Length; f++)
            {
                if (strspCode.IndexOf(strspCodes[f].Trim()) < 0)
                {
                    strspCode = strspCode + "'" + strspCodes[f] + "',";
                }
            }
            strspCode = strspCode.Substring(0, strspCode.Length - 1) + ") and sparentcode = '" + SParentCode + "'";
            Tz888.BLL.Sys.SysMenuTab sysMenu = new Tz888.BLL.Sys.SysMenuTab();
            return sysMenu.GetList(strspCode);

        }
        else 
        {
            return null;
        }
    }
    #endregion

    #region 根据sparentCode绑定各级菜单
    protected void dataBind(string sparentcode)
    {
        string strHtml1 = "";//一级菜单
        
        if (sparentcode == "0")
        {
            DataSet ds = getRoleID(getTem(), sparentcode);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strHtml1 = strHtml1 + "<a href='?sid=" + ds.Tables[0].Rows[i]["sid"] + "'>" + ds.Tables[0].Rows[i]["SName"] + "</a></li>";

                }
            }            
        }
        
    }
    #endregion

    protected void lbtLoginOut_Click(object sender, EventArgs e)
    {

    }
}
