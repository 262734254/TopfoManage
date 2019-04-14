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


public partial class Default4 : System.Web.UI.Page
{
    Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
    public string strName = "4gfdogkdfjkgdfj";
    DataTable dt = null;
    BasePage bp = new BasePage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ValidateRightByRole())
            Response.Write("true");
        else
            Response.Write("False");
        
        
        //Response.Write(Request.Path.ToString().Trim());
    }

    ///// <summary>
    ///// 验证当前角色对当前路径是否有访问权限
    ///// </summary>
    public bool ValidateRightByRole()
    {
        bool flg = false;
        string[] arr = null;
        string[] arrMenu = null;
        try
        {
            DataRow[] drSystem = GetSystem().Select("employeeid='" + strName + "'");  //获取当前用户的角色组
            for (int i = 0; i < drSystem.Length; i++)
            {
                arr = Tz888.Common.Text.FormatDh(drSystem[i]["tem"].ToString().Trim(), ",").Split(',');
                for (int k = 0; k < arr.Length; k++)
                {
                    System.Data.DataRow[] myrow = GetSyspermission().Select("roleid=" + arr[k].ToString().Trim());  //获取权限菜单码
                    for (int v = 0; v < myrow.Length; v++)
                    {
                        arrMenu = Tz888.Common.Text.FormatDh(myrow[v]["spcode"].ToString().Trim(), ",").Split(',');
                        for (int m = 0; m < arrMenu.Length; m++)
                        {
                            DataRow[] drs = GetSysmenu().Select("scode='" + arrMenu[m].ToString().Trim() + "'");
                            for (int n = 0; n < drs.Length; n++)
                            {
                                if (drs[n]["surl"].ToString().Trim().ToUpper() == ("/Web/default41.aspx").Trim().ToUpper())
                                {
                                    flg = true;
                                    return flg;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch
        {
        }
        return flg;
    }

    #region [获取权验证数据]
    /// <summary>
    /// 获取用户组
    /// </summary>
    /// <returns></returns>
    public DataTable GetSystem()
    {
        try
        {
            dt = bll.GetList("system", "employeeid,tem", "employeeid", 1000, 1, 0, 0, "");
        }
        catch
        {
            dt = null;
        }
        return dt;
    }

    /// <summary>
    /// 获取权限表
    /// </summary>
    /// <returns></returns>
    public DataTable GetSyspermission()
    {
        try
        {
            dt = bll.GetList("syspermissiontab", " roleid,spcode ", "roleid", 1000, 1, 0, 0, "");
        }
        catch
        {
            dt = null;
        }
        return dt;
    }

    /// <summary>
    /// 获取菜单个
    /// </summary>
    /// <returns></returns>
    public DataTable GetSysmenu()
    {
        try
        {
            dt = bll.GetList("sysmenutab", " scode,surl ", "scode", 1000, 1, 0, 0, "");
        }
        catch
        {
            dt = null;
        }
        return dt;
    }
    #endregion
}

