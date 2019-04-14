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

public partial class dptopfo_PictureManage : System.Web.UI.Page
{
    private static Tz888.BLL.Compage com = new Tz888.BLL.Compage();

    Tz888.BLL.MyHome.HomeLinkManager manager = new Tz888.BLL.MyHome.HomeLinkManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        bool flag = false;
        if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]) && !string.IsNullOrEmpty(Request.QueryString["typeId"]))
        {
            int id = int.Parse(Request.QueryString["ProfessionalID"].ToString());
            //string name = infoBll.PaperExeists(id);
            //if (name != "")
            //{
            //    string[] html = name.Split('/');//Professional/201103/Professional20110321_7.shtml
            //    string[] cc = html[2].Split('.');
            //    com.DeleteFile(@PsStatic + html[1].ToString() + @"\" + html[2].ToString());
            //}
            //if (typeId == 1)//服务
            //{
            //    flag = infoBll.DelInfoById(id);
            //}

            //if (flag)
            //{
            //    Response.Write("<script>alert('删除成功');location.href='ProfessionalManage.aspx'</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('删除失败');location.href='ProfessionalManage.aspx'</script>");
            //}
        }
        this.AspNetPager.PageSize = Tz888.Common.Text.FormatData(ddlPageSize.SelectedValue.Trim());
        if (!IsPostBack)
        {
            ViewState["Criteria"] = "";  //全部资讯
            this.AspNetPager.CurrentPageIndex = 1;
            GetInfoNews();
        }
    }
    #region 页面加载方法
    private void GetInfoNews()
    {
        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        long TotalCount = 0;
        long PageCount = 1;
        DataTable ds = manager.GetListTS("ImageTab", "imageid", "*", strCriteria, "createdatetime desc", ref CurrentPage, PageNum, ref TotalCount);
        //DataSet ds = bll.GetProViewInfoAll("professionalid,chargeID,titel,typetID,Htmlurl,LoginName,UserName,createdate,auditID", strCriteria, "createdate desc", CurrentPage, PageNum, out TotalCount);
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        this.NewsList.DataSource = ds.DefaultView;

        this.NewsList.DataBind();
        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;

    }
    #endregion


    protected string StrLength(object title)
    {
        string name = "";
        name = title.ToString();
        if (name.Length > 9)
        {
            name = name.Substring(0, 8) + "...";
        }
        return name;
    }
    #region 页面控件事件
    #region NewsList_ItemDataBound
    protected void NewsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //ListItemType objItemType = e.Item.ItemType;

        //if (objItemType == ListItemType.Item || objItemType == ListItemType.AlternatingItem)
        //{
        //    DataRowView drvData = (DataRowView)e.Item.DataItem;
        //    HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
        //    hlTitle.Text = "<a href='http://www.topfo.com/" + drvData["Htmlurl"].ToString() + "' target=\"_blank\">" + Tz888.Common.Utility.PageValidate.FixLenth(drvData["Titel"].ToString(), 37, "...") + "</a>";
        //    hlTitle.ToolTip = drvData["Titel"].ToString();
        //}
    }
    #endregion
    #region 每页显示多少条 ddlPageSize_SelectedIndexChanged
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    #endregion
    #region AspNetPager_PageChanged 分页控件
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    #endregion
    #region btnSearch_Click 查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string LoginName = this.txtLoginName.Value.Trim();
        ViewState["Criteria"] = "";
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();

        if (strCriteria.ToString() == "")
        {
            if (this.txtNuber.Value.Trim() != "")   //根据ID
                strCriteria.Append(" imageid like  '%" + this.txtNuber.Value.Trim() + "%'");
        }

        if (strCriteria.ToString() == "")
        {
            if (this.txtLoginName.Value.ToString().Trim() != "")
            {
                strCriteria.Append("loginName='" + LoginName + "'");
            }
            else
            {
                if (txtLoginName.Value.ToString().Trim() != "")
                {
                    strCriteria.Append("loginName='" + LoginName + "'");
                }

            }
        }

        ViewState["Criteria"] = strCriteria.ToString();
        GetInfoNews();
    }
    #endregion
    #region 删除按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool flag = false;
        string[] values = Request.Form.GetValues("cbxSelect");
        //if (values == null || values.Length < 1)
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的资源!");
        //    return;
        //}
        //else
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (string str in values)
        //    {
        //        int typeId = infoBll.GetModel(int.Parse(str.ToString().Trim())).typeID;
        //        string name = infoBll.PaperExeists(Convert.ToInt32(str.ToString().Trim()));
        //        if (name != "")
        //        {
        //            string[] html = name.Split('/');
        //            string[] cc = html[2].Split('.');
        //            com.DeleteFile(@PsStatic + html[1].ToString() + @"\" + html[2].ToString());
        //        }
        //        else
        //        {
        //            sb.Append("编号:" + str.ToString().Trim() + ",删除失败\\n");
        //        }
        //        if (typeId == 1)//服务
        //        {

        //            flag = infoBll.DelInfoById(int.Parse(str.ToString().Trim()));
        //        }
        //    }
        //    if (flag)
        //    {
        //        Tz888.Common.MessageBox.Show(this.Page, "删除成功");
        //    }
        //    else
        //    {
        //        Tz888.Common.MessageBox.Show(this.Page, sb.ToString());
        //    }
        //    this.GetInfoNews();
        //}
    }
    #endregion
    #endregion


}
