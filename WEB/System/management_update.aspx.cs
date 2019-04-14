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

public partial class System_management_update : System.Web.UI.Page
{
    protected string t = "";
    Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        t = Request.QueryString["t"].ToString().Trim();
        ViewState["sid"] = Request.QueryString["sid"].ToString();
        ViewState["parentID"] = Request.QueryString["parentID"].ToString();
        if (!IsPostBack)
        {

            try
            {

                this.txtIndexNum.Value = Request.QueryString["index"].ToString();
                this.txtTypeName.Value = Request.QueryString["type"].ToString();
                if (t == "b")
                {
                    DataTable dt = bll.GetList("setServiesBigTab", "isShow,Remark", "ServiesBID", 1, 1, 0, 1, "ServiesBID=" + Convert.ToInt32(ViewState["sid"]));
                    if (dt.Rows.Count > 0)
                    {
                        RadioButtonList1.SelectedValue = dt.Rows[0]["isShow"].ToString();
                        txtRemark.Text = dt.Rows[0]["Remark"].ToString();

                    }
                }
                if (t == "m")
                {
                    DataTable dt = bll.GetList("setServiesSmallTab", "isShow,Remark", "ServiesMID", 1, 1, 0, 1, "ServiesMID=" + Convert.ToInt32(ViewState["sid"]));
                    if (dt.Rows.Count > 0)
                    {
                        RadioButtonList1.SelectedValue = dt.Rows[0]["isShow"].ToString();
                        txtRemark.Text = dt.Rows[0]["Remark"].ToString();

                    }
                }
            }
            catch
            {
                Response.Write("<script>alert('参数接收失败!');</script>");
            }

            if (ViewState["parentID"].ToString() == "")
            {
                ListItem li = new ListItem();
                li = new ListItem("无上级类别", "无上级类别");
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

                string bid = obj.GegBID(Convert.ToInt32(ViewState["sid"]));
                ddlType.SelectedValue = bid;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Tz888.BLL.ServiesType servobj = new Tz888.BLL.ServiesType();
        try
        {
            if (this.ddlType.SelectedValue == "无上级类别")
            {
                bool status = servobj.UpdateServiesB(
                    Convert.ToInt32(ViewState["sid"]), this.txtTypeName.Value.Trim(),
                    Convert.ToInt32(this.txtIndexNum.Value), txtRemark.Text.Trim(),
                    Convert.ToBoolean(RadioButtonList1.SelectedValue)
                    );
                if (status)
                {
                    status = servobj.UpdateServiesIndex();
                    Response.Write("<script>alert('修改成功!');location.href='management.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败:排序序号[" + this.txtIndexNum.Value.Trim() + "]已经存在!');</script>");
                }
            }
            else
            {
                //string bid = servobj.GegBID(Convert.ToInt32(ViewState["sid"]));
                bool status = servobj.UpdateServiesM(Convert.ToInt32(ViewState["sid"]),
                    Convert.ToInt32(this.ddlType.SelectedValue.Trim()), this.txtTypeName.Value.Trim(),
                    Convert.ToInt32(this.txtIndexNum.Value), txtRemark.Text,
                    Convert.ToBoolean(RadioButtonList1.SelectedValue));
                if (status)
                {
                    status = servobj.UpdateServiesIndex();
                    Response.Write("<script>alert('修改成功!');location.href='management.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败:排序序号[" + this.txtIndexNum.Value.Trim() + "]已经存在!');</script>");
                }
            }
        }
        catch
        {
        }
    }
}
