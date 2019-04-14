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
using System.Text.RegularExpressions;

public partial class Link_LinkManage : System.Web.UI.Page
{
    private readonly Tz888.BLL.Link.LinkInfoTab bll = new Tz888.BLL.Link.LinkInfoTab();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadChannel();
            LoadLinkType();
            dataBind("");
        }
        if (Request.QueryString["LinkId"] != null)
        {
            string LinkId = Request.QueryString["LinkId"];
            if (Tz888.Common.Utility.PageValidate.IsNumber(LinkId))

                Del(LinkId);
            else
                Tz888.Common.MessageBox.Show(this.Page, "参数错误!");
        }
    }

    public void Del(string LinkId)
    {
        string Logo = "";

        try
        {
            if (bll.GetLinkById(LinkId) != null)
            {
                Logo = (bll.GetLinkById(LinkId).Rows[0]["Logo"] == DBNull.Value) ? "" : bll.GetLinkById(LinkId).Rows[0]["Logo"].ToString();
            }
            if (bll.DelLinkById(LinkId))
            {
                if (Logo.Length > 0)
                {
                    string[] str = Logo.Split('/');
                    imgBiz.Service serBiz = new imgBiz.Service(); //webservice
                    serBiz.delCrmImage(str[5], str[4]);
                }
                Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "删除成功!", "LinkManage.aspx", false);
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除失败!");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind("");
    }

    protected void dataBind(string where)
    {
        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 20;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        try
        {
            DataTable dt = bll.GetListT("V_LinkInfo", "LinkInfoId", "*", where, "LinkInfoId desc", ref CurrentPage, PageNum, ref TotalCount);
            if (dt != null)
            {
                this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
                this.Repeater1.DataSource = dt.DefaultView;

                this.Repeater1.DataBind();

                if (TotalCount % PageNum > 0)
                    PageCount = TotalCount / PageNum + 1;
                else
                    PageCount = TotalCount / PageNum;

                this.pinfo.InnerText = Convert.ToString(TotalCount);//总条数
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 过滤SQL语句,防止注入
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns>fasle - 没有注入, true - 有注入 </returns>
    public bool filterSql(string sSql)
    {
        int srcLen, decLen = 0;
        sSql = sSql.ToLower();
        sSql = sSql.ToLower().Trim();
        srcLen = sSql.Length;
        sSql = sSql.Replace("exec", "");
        sSql = sSql.Replace("delete", "");
        sSql = sSql.Replace("master", "");
        sSql = sSql.Replace("truncate", "");
        sSql = sSql.Replace("declare", "");
        sSql = sSql.Replace("create", "");
        sSql = sSql.Replace("xp_", "no");
        sSql = sSql.Replace("and", "");
        decLen = sSql.Length;
        if (srcLen == decLen)
            return false;
        else
            return true;
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        try
        {
            string where = "";
            string LinkName = txtLinkName.Value.Trim();
            if (!string.IsNullOrEmpty(LinkName))
            {
                LinkName = Tz888.Common.Utility.PageValidate.HtmlEncode(LinkName);
                if (filterSql(LinkName))
                    LinkName = "";
            }


            if (!string.IsNullOrEmpty(LinkName))
            {
                where = "LinkInfoName='" + LinkName + "' and ";
            }
            if (DropChannel.SelectedValue != "-1")
            {
                where = where + "ChannelId=" + DropChannel.SelectedValue + " and ";
            }
            if (DropLinkType.SelectedValue != "-1")
            {
                where = where + "LinkId=" + DropLinkType.SelectedValue + " and ";
            }

            if (where.Length > 0)
            {
                where = where.Substring(0, where.LastIndexOf("and")).Trim();
            }

            dataBind(where);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void LoadChannel()
    {
        try
        {
            Tz888.BLL.Link.LinkChannelType Channel = new Tz888.BLL.Link.LinkChannelType();
            DropChannel.DataSource = Channel.GetChannelList();
            DropChannel.DataTextField = "ChannelName";
            DropChannel.DataValueField = "ChannelId";
            DropChannel.DataBind();

            ListItem item = new ListItem();
            item.Text = "-请选择-";
            item.Value = "-1";
            DropChannel.Items.Insert(0, item);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void LoadLinkType()
    {
        try
        {
            Tz888.BLL.Link.LinkTypeTab LinkType = new Tz888.BLL.Link.LinkTypeTab();
            DropLinkType.DataSource = LinkType.GetLinkTypeList();
            DropLinkType.DataTextField = "LinkName";
            DropLinkType.DataValueField = "LinkId";
            DropLinkType.DataBind();

            ListItem item = new ListItem();
            item.Text = "-请选择-";
            item.Value = "-1";
            DropLinkType.Items.Insert(0, item);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
