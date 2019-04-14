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

public partial class UserControl_Left : System.Web.UI.UserControl
{
    //拼接菜单码查询条件
    string strspCode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBind("0");
            if (Request.QueryString["sid"] != null)
            {
                dataBind(Request.QueryString["sid"].ToString());
            }
        }
    }
    protected string getEmployeeID()
    {
        BasePage bp = new BasePage();

        string LoginName = bp.LoginName;
        //Tz888.BLL.Sys.EmployeeInfoTab EmployeeBll = new Tz888.BLL.Sys.EmployeeInfoTab();
        //DataSet ds = EmployeeBll.GetList(" LoginName='" + LoginName + "'");
        //string EmployeeID = "0";
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    EmployeeID = ds.Tables[0].Rows[0]["EmployeeID"].ToString();
        //}

        // Response.Cookies["loginedUser"].Value; //从cookie中获取登录成功后的用户名

        return bp.LoginName;
    }
    #region 获取用户权限码
    protected string getTem()
    {

        string tem = "";
        Tz888.BLL.Sys.System sysBLL = new Tz888.BLL.Sys.System();
        DataSet ds = sysBLL.GetList(" EmployeeID='" + getEmployeeID() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            tem = ds.Tables[0].Rows[0]["Tem"].ToString();
        }
        return tem;
    }
    #endregion

    #region 获取并解析菜单码
    protected DataSet getRoleID(string tem, string SParentCode)
    {
        if (tem != "")
        {
            string[] tems = tem.Split(',');
            string strWhere = " RoleID in (";    //拼接查询条件
            for (int i = 0; i < tems.Length; i++)
            {
                if (i < tems.Length - 1)
                {
                    //排除末尾是,的情况
                    if (tems[i].Trim().Length > 0)
                    {
                        strWhere = strWhere + tems[i] + ",";
                    }
                }
                else
                {
                    if (tems[i].Trim().Length > 0)
                    {
                        strWhere = strWhere + tems[i];
                    }
                }
            }
            if (strWhere.EndsWith(","))
            {
                strWhere = strWhere.Substring(0, strWhere.Length - 1);
            }
            strWhere += ")";
            Tz888.BLL.Sys.SysPermissionTab sysPerm = new Tz888.BLL.Sys.SysPermissionTab();
            DataSet ds = sysPerm.GetList(strWhere);
            string spCode = "";    //获取所有的菜单码
            if (ds.Tables[0] != null)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (spCode == "")
                    {
                        spCode = spCode + ds.Tables[0].Rows[j]["SPCode"].ToString();
                    }
                    else 
                    {
                        spCode = spCode +","+ ds.Tables[0].Rows[j]["SPCode"].ToString();
                    }
                }
            }
            //拼接菜单码查询条件
            strspCode = " scode in (";
            string[] strspCodes = spCode.Split(',');
            for (int f = 0; f < strspCodes.Length; f++)
            {
                if (strspCode.IndexOf(strspCodes[f].Trim()) <0)
                {
                    strspCode = strspCode + "'" + strspCodes[f] + "',";
                    //strspCode = strspCode + "'" + strspCodes[f] + "',";
                }
            }
            strspCode = strspCode.Substring(0, strspCode.Length - 1) + ") and sparentcode = '" + SParentCode + "'";
            try
            {
                Tz888.BLL.Sys.SysMenuTab sysMenu = new Tz888.BLL.Sys.SysMenuTab();

                return sysMenu.GetList(strspCode);
            }
            catch
            {
                return null;
            }
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
        string strHtml2 = "";//二级菜单
        string strHtml3 = "";//三级菜单
        if (sparentcode == "0")
        {
            DataSet ds = getRoleID(getTem(), sparentcode);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //一级菜单
                    strHtml1 = strHtml1 + "<h5 class='title_h5' onclick='h5_Click(this)' name='title'><a  href='#'>" + ds.Tables[0].Rows[i]["SName"] + "</a></h5>";
                    //"<a href='?sid=" + ds.Tables[0].Rows[i]["sid"] + "'>" + ds.Tables[0].Rows[i]["SName"] + "</a></li>";  
                    //二级菜单
                    DataSet ds2 = getRoleID(getTem(), ds.Tables[0].Rows[i]["sid"].ToString());
                    if (ds2 != null)
                    {
                        if (ds2.Tables[0].Rows.Count >= 1)
                        {
                            strHtml1 = strHtml1 + "<div class='left_list' style='display:none;'><ul class='left_bar_list'>";
                        }
                        for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                        {
                            strHtml1 = strHtml1 + "<li><a href='" + ds2.Tables[0].Rows[j]["Surl"].ToString() + "' target='ManagerMain'>" + ds2.Tables[0].Rows[j]["SName"].ToString() + "</a></li>";
                        }
                        if (ds2.Tables[0].Rows.Count >= 1)
                        {
                            strHtml1 = strHtml1 + "</ul></div>";
                        }
                    }
                }
            }
            left_bar1.InnerHtml = "<ul><li>" + strHtml1 + "</ul>";
        }
    }
    #endregion
}