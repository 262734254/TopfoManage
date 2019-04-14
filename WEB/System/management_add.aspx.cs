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

public partial class System_management_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sid = "";
            try
            {
                sid = Request.QueryString["sid"].ToString();
            }
            catch
            {
                Response.Write("<script>alert('参数接收失败。'); window.close();();</script>");
            }
            ViewState["sid"] = sid;

            if (sid == "00")
            {
                ListItem li = new ListItem();
                li = new ListItem("无上级类别", "");
                ddlType.Items.Add(li);
            }
            else
            {
                Tz888.BLL.ServiesType obj = new Tz888.BLL.ServiesType();
                this.ddlType.DataSource = obj.GetServiesList(false);
                this.ddlType.DataTextField = "ServiesBName";
                this.ddlType.DataValueField = "ServiesBID";
                this.ddlType.DataBind();
                ListItem li = new ListItem();
                li = new ListItem("请选择类别", "");
                ddlType.Items.Add(li);

                ddlType.SelectedValue = sid;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Tz888.BLL.ServiesType objServ = new Tz888.BLL.ServiesType();
        bool status = false;

        if (ViewState["sid"].ToString() == "00" && this.txtTypeName.Value.Trim() != "")
        {
            status = objServ.AddServiesB(this.txtTypeName.Value.Trim(), Convert.ToInt32(this.txtIndexNum.Value.Trim())
                , txtRemark.Text.Trim());
            if (status)
            {
                status = objServ.UpdateServiesIndex();
                Response.Write("<script>alert('成功添加类别'); location.href='management.aspx';</script>");
            }
            else
            {

                Response.Write("<script>alert('添加类别失败:分类排序序号[" + this.txtIndexNum.Value.Trim() + "]已存在!');</script>");
            }
        }

        if (ViewState["sid"].ToString() != "00" && this.ddlType.SelectedValue != "请选择类别" && this.txtTypeName.Value.Trim() != "")
        {
            status = objServ.AddServiesM(Convert.ToInt32(Request.QueryString["sid"]),
                this.txtTypeName.Value.Trim(),
                Convert.ToInt32(this.txtIndexNum.Value.Trim()), txtRemark.Text.Trim());
            if (status)
            {
                status = objServ.UpdateServiesIndex();
                Response.Write("<script>alert('成功添加类别'); location.href='management.aspx';</script>");
            }
            else
            {

                Response.Write("<script>alert('添加类别失败:分类排序序号[" + this.txtIndexNum.Value.Trim() + "]已存在!');</script>");
            }
        }
    }
}
