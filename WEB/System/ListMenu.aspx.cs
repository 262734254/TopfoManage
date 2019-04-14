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
using System.Collections.Generic;
using System.Text;
public partial class System_ListMenu : BasePage
{
    public string array = "";
    public int MenuCount = 0;
    Tz888.BLL.Sys.SysMenuTab bll = new Tz888.BLL.Sys.SysMenuTab();
    Tz888.Model.Sys.SysMenuTab model = new Tz888.Model.Sys.SysMenuTab();
    Tz888.BLL.Sys.SysPermissionTab sysBll = new Tz888.BLL.Sys.SysPermissionTab();
    Tz888.Model.Sys.SysPermissionTab modelpER = new Tz888.Model.Sys.SysPermissionTab();
    Tz888.Model.Sys.SysRoleTab roleModel = new Tz888.Model.Sys.SysRoleTab();
    DataSet ds = null;
    Tz888.BLL.Sys.SysRoleTab roleBll = new Tz888.BLL.Sys.SysRoleTab();
    int roleID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["SRoleID"] != "" && Request.QueryString["SRoleID"] != null)
            {
              
                roleID = Convert.ToInt32(Request.QueryString["SRoleID"].ToString());
                roleModel = roleBll.GetModel(roleID);
                lblUserPriv.Text = roleModel.SRName.ToString();
                DataSet ds1 = new DataSet();
                ds1 = GetDataList();
                MenuCount = ds1.Tables[0].Rows.Count;
                //int SParentCode = 0;
                //MenuCount = bll.GetList().Count;
                DataRow[] dr1 = ds1.Tables[0].Select("SParentCode=0");
                DataSet ds2 = new DataSet();
                ds2 = ds1.Clone();
                ds2.Merge(dr1);
                //rptMain.DataSource = bll.GetList(SParentCode, "desc");//第一级菜单
                rptMain.DataSource = ds2;
                rptMain.DataBind();
                ds2.Dispose();
                ds2 = null;
                ds1.Dispose();
                ds1 = null;
            }
            else
            {
                Response.Redirect("Role.aspx");
            }
        }
        else
        {
            string funstr = lblFuncIdStr.Value;
            string fun = "";
            if (funstr.EndsWith(","))
            {
                fun = funstr.Substring(0, funstr.Length - 1);
            }
            else
            {
                fun = funstr;
            }
            modelpER = sysBll.GetModel1(int.Parse(Request.QueryString["SRoleID"].ToString()));
            if (modelpER != null)
            {
                modelpER.SPCode = fun;
                if (sysBll.Update(modelpER))
                {
                    Response.Write("<script>alert('权限编辑成功');location.href='Role.aspx';</script>");
                }
            }
            else
            {
                Tz888.Model.Sys.SysPermissionTab modelpER1 = new Tz888.Model.Sys.SysPermissionTab();
                int roleid = int.Parse(Request.QueryString["SRoleID"].ToString());
                modelpER1.RoleID = roleid;
                modelpER1.SPCode = fun;
                modelpER1.SPDate = DateTime.Now;
                if (sysBll.Add(modelpER1) > 0)
                {
                    Response.Write("<script>alert('权限编辑成功');location.href='Role.aspx';</script>");
                }
            }
        }
    }
    protected DataSet GetDataList()
    {
        if (AppCache.IsExist("SysMenuList"))
        {
            ds = (DataSet)AppCache.Get("SysMenuList");
        }
        else
        {
            ds = bll.GetList("");
            AppCache.AddCache("SysMenuList", ds);
        }
        return ds;
    }
    protected void rptMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //项绑定后激发
        //model = e.Item.DataItem as Tz888.Model.Sys.SysMenuTab;
        string sid = "";
        if (ListItemType.Item == e.Item.ItemType || ListItemType.AlternatingItem == e.Item.ItemType)
        {
            // 读当前行数据 
            DataRowView dr = (DataRowView)e.Item.DataItem;

            sid = dr["sid"].ToString();
        }
        Repeater childRep = e.Item.FindControl("rptChild") as Repeater;

        //childRep.DataSource = bll.GetList(model.sid, "desc");
        DataSet ds1 = new DataSet();
        ds1 = GetDataList();
        DataRow[] dr1 = ds1.Tables[0].Select("SParentCode=" + sid);
        DataSet ds2 = new DataSet();
        ds2 = ds1.Clone();
        ds2.Merge(dr1);
        childRep.DataSource = ds2;
        childRep.DataBind();
        ds2.Dispose();
        ds2 = null;
        ds1.Dispose();
        ds1 = null;
    }
    protected string GetMenuId(object obj)
    {
        string menu = obj.ToString();
        return menu.ToString();
    }
    #region  换行暂时没用
    protected string GetBr(object obj)
    {
        StringBuilder str = new StringBuilder();
        string[] a = new string[] { };
        if (obj != null)
        {
            ViewState["sid"] += obj + ",";
        }
        if (ViewState["sid"] != null)
        {
            string[] func = ViewState["sid"].ToString().Split(new char[] { ',' });
            if (func.Length > 6)
            {
                func = new string[] { };
                str.Append("<tr>");
                str.Append("<td>");
                str.Append("<input type=\"checkbox\" name='");
                str.Append(GetMenuId(Eval("Sparentsid")) + "' ");
                str.Append("value='");
                str.Append(Eval("scode") + "' ");
                str.Append(GetIFCheck(Convert.ToString(Eval("Scode"))));
                str.Append(">");
                str.Append(Eval("SName"));
                str.Append(" </td>");
                if (func.Length == 10)
                {
                    str.Append("</tr><br />");
                }
                //str.Append("<br />");
            }
            else
            {
                str.Append("<input type=\"checkbox\" name='");
                str.Append(GetMenuId(Eval("Sparentsid")) + "' ");
                str.Append("value='");
                str.Append(Eval("scode") + "' ");
                str.Append(GetIFCheck(Convert.ToString(Eval("Scode"))));
                str.Append(">");
                str.Append(Eval("SName"));
                str.Append(" </td>");
                if (func.Length == 5)
                {
                    str.Append("</tr><br />");
                }
                //str.Append("<br />");
            }
        }
        return str.ToString();
    }
    protected string GetBr1(int item)
    {
        string Msg = "";
        StringBuilder str = new StringBuilder();
        if (item + 1 >= 6)
        {
            // str.Append("<tr>");
            str.Append("<td>");
            str.Append("<input type=\"checkbox\" name='");
            str.Append(GetMenuId(Eval("Sparentsid")) + "' ");
            str.Append("value='");
            str.Append(Eval("scode") + "' ");
            str.Append(GetIFCheck(Convert.ToString(Eval("Scode"))));
            str.Append(">");
            str.Append(Eval("SName"));
            str.Append(" </td>");
            if (item + 1 >= 10)
            {
                str.Append("</tr><br />");
            }
        }
        else
        {
            //str.Append("<tr>");
            str.Append("<td>");
            str.Append("<input type=\"checkbox\" name='");
            str.Append(GetMenuId(Eval("Sparentsid")) + "' ");
            str.Append("value='");
            str.Append(Eval("scode") + "' ");
            str.Append(GetIFCheck(Convert.ToString(Eval("Scode"))));
            str.Append(">");
            str.Append(Eval("SName"));
            str.Append(" </td>");
            if (item + 1 == 5)
            {
                str.Append("</tr><br />");

            }
        }
        Msg = str.ToString();
        str.Remove(0, str.Length);
        return Msg;
    }
    #endregion
    /// <summary>
    /// 根据父级ID创建对应子级菜单
    /// </summary>
    /// <param name="menuId"></param>   
    protected void rptSecond_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //model = e.Item.DataItem as Tz888.Model.Sys.SysMenuTab;
        string sid = "";
        if (ListItemType.Item == e.Item.ItemType || ListItemType.AlternatingItem == e.Item.ItemType)
        {
            // 读当前行数据 
            DataRowView dr = (DataRowView)e.Item.DataItem;

            sid = dr["sid"].ToString();
        }
        Repeater childRep = e.Item.FindControl("rptThird") as Repeater;
        //childRep.DataSource = bll.GetList(model.sid, "desc");
        DataSet ds1 = new DataSet();
        ds1 = GetDataList();
        DataRow[] dr1 = ds1.Tables[0].Select("SParentCode=" + sid);
        DataSet ds2 = new DataSet();
        ds2 = ds1.Clone();
        ds2.Merge(dr1);
        childRep.DataSource = ds2;
        childRep.DataBind();
        ds2.Dispose();
        ds2 = null;
        ds1.Dispose();
        ds1 = null;
    }
    protected void createArray()
    {
        IList<Tz888.Model.Sys.SysMenuTab> menu = bll.GetList();
        for (int i = 0; i < menu.Count; i++)
        {
            array += "MENU_ID_ARRAY[" + i.ToString() + "]='" + menu[i].sid.ToString() + "';";
        }
    
    }
    protected string GetIFCheck(object SId)
    {
        string check = "";
        modelpER = sysBll.GetModel1(int.Parse(Request.QueryString["SRoleID"].ToString()));//获取角色的权限ID
        if (modelpER != null)
        {
            string funcstr = modelpER.SPCode.ToString();
            string[] fun = funcstr.Split(',');
            for (int i = 0; i < fun.Length; i++)
            {
                if (SId.ToString().Equals(fun[i]))
                {
                    check = "checked='checked'";
                    break;
                }
            }
        }
        return check;
    }
}
