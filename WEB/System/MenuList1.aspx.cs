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

public partial class System_MenuList1 : BasePage
{
    Tz888.BLL.Sys.SysMenuTab bll = new Tz888.BLL.Sys.SysMenuTab();
    Tz888.Model.Sys.SysMenuTab model = new Tz888.Model.Sys.SysMenuTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["order"] = "desc";
            //AspNetPager1.RecordCount = bll.GetList(0, ViewState["order"].ToString()).Count;
            databind(ViewState["order"].ToString());
        }
    }

    private void databind(string sort)
    {
        int SParentCode = 0;
        PagedDataSource pd = new PagedDataSource();
        pd.DataSource = bll.GetList(SParentCode, sort);//第一级菜单
        //pd.AllowPaging = true;
        pd.PageSize = 25;
        //pd.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //if (pd.Count>0)
        //{
        //    this.lblCurrentPage.Text = "共" + AspNetPager1.RecordCount + "条记录,当前第" + (pd.CurrentPageIndex + 1).ToString() + "页,共" + pd.PageCount.ToString() + "页,每页" + pd.PageSize + "条纪录";
        //}
        foreach (Tz888.Model.Sys.SysMenuTab mo in bll.GetList(SParentCode, sort))
        {
            ViewState["parentCode"] = mo.SParentCode;
            break;
        }
        GridView1.DataSource = pd;
        GridView1.DataBind();
        
    }
    public string GetStatu(object obj)
    {
        int statu = (int)obj;
        if (statu == 0)
        {
            return "<font size='1' color='red'>无效</font>";
        }
        else
        {
            return "有效";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#f5f5f5'";  //#b1bfee
            e.Row.Attributes["onmouseout"] = "this.style.backgroundColor=''";
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int sid = int.Parse(e.CommandArgument.ToString());
        int check = 0;
        switch (e.CommandName) //壮态

        {
            case "check":
                model = bll.GetModel(sid);
                if (model.SCheck == 0)
                {
                    check = 1;
                }
                else
                {
                    check = 0;
                }
                model.SCheck = check;
                bll.Update(model);
                databind(ViewState["order"].ToString());
                break;
            case "xiaji"://添加一下级菜单
                Response.Redirect("MenuList2.aspx?sid=" + sid);
                break;
            case "modefiy": //修改
                Response.Redirect("ModefiyMenu.aspx?sid=" + sid + "&ji=1");
                break;
            case "Del"://删除
                bll.Delete(sid);
                databind(ViewState["order"].ToString());
                break;
            default:
                break;

        }
    }
    //添加
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMenu.aspx?parentCode=" + Convert.ToInt32(ViewState["parentCode"].ToString()) + "&ji=1");
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string input = "";
        try
        {
            //获取文本框的值
            input = (GridView1.Rows[e.RowIndex].FindControl("txtUPdate") as TextBox).Text.ToString();
            HiddenField hf = GridView1.Rows[e.RowIndex].FindControl("HiddenField1") as HiddenField;
            model = bll.GetModel(int.Parse(hf.Value));
            model.Sorder = int.Parse(input);
            if (bll.Update(model))
            {
                GridView1.EditIndex = -1;
                databind(ViewState["order"].ToString());
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    //排序
    protected void btnSort_Click(object sender, EventArgs e)
    {
        if (ViewState["order"].Equals("desc"))
        {
            ViewState["order"] = "asc";
        }
        else
        {
            ViewState["order"] = "desc";
        }
        databind(ViewState["order"].ToString());
    }
    //protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
    //{
    //    AspNetPager1.CurrentPageIndex = e.NewPageIndex;
    //    databind(ViewState["order"].ToString());
    //}
}
