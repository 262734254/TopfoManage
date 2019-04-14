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

public partial class Controls_EmployeeMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(Page.User.Identity.Name))
        //{
        //    Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        //    return;
        //}
        string xml = System.Web.HttpRuntime.AppDomainAppPath + "Controls/EmployeeMenu.xml";
        DataSet ds = new DataSet();
        ds.ReadXml(xml);

        //Tz888.BLL.Login.Common.KeepSession(this.Page);
        //Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        //long CurrPage = 0;
        //long TotalCount = 0;
        //string workType = this.Session["WorkType"].ToString().Trim();
        //string workType = "ChfEditor";
        
        //string strWhere = "workType='"+workType+"' AND IsMenu<>0 AND Value<>0 AND Active<>0";
        //DataTable dt = dal.GetList("MenuPermissionVIw", "workType",
        //    "*", strWhere, "Sequence ASC,MenuType ASC ", ref CurrPage, 0, ref TotalCount);
        dlMainMenu.DataSource = ds.Tables["Employee"];
        dlMainMenu.DataBind();
    }

    protected void dlMainMenu_ItemDataBound(object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
    {
        ListItemType objItemType = e.Item.ItemType;

        if (objItemType == ListItemType.Item ||
            objItemType == ListItemType.AlternatingItem)
        {
            //标题的修改
            DataRowView drvData = (DataRowView)e.Item.DataItem;
            HyperLink hlControl = (HyperLink)e.Item.FindControl("hlItem");
            hlControl.Text = drvData["MenuTypeName"].ToString().Trim();
            hlControl.NavigateUrl = drvData["URL"].ToString().Trim();

            switch (hlControl.Text)
            {
                case "资源推送":
                    hlControl.ForeColor = System.Drawing.Color.Red;
                    break;
                case "资源推送管理":
                    hlControl.ForeColor = System.Drawing.Color.Red;
                    break;
                case "站内互告收入查看":
                    hlControl.ForeColor = System.Drawing.Color.Red;
                    break;
                case "站内互告收入分配":
                    hlControl.ForeColor = System.Drawing.Color.Red;
                    break;
                case "站内互告点击记录查询":
                    hlControl.ForeColor = System.Drawing.Color.Red;
                    break;
            }

        }
    }
}
