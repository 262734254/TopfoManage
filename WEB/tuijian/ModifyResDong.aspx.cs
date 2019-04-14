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

public partial class tuijian_ModifyResDong : BasePage
{
    public int ResID;
    protected void Page_Load(object sender, EventArgs e)
    {
         ResID =Convert.ToInt16(Request.QueryString["SGID"].ToString());

        if (!IsPostBack)
        {
            Bind(ResID);
        }
    }

    private void Bind(int ResID)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("RecommendedResources", "*", "ResourceID", 100, 1, 0, 1, "ResourceID=" +ResID);
        this.txtName.Text = dt.Rows[0]["ResourceName"].ToString();
        this.TextList.Text = dt.Rows[0]["TuijianID"].ToString();
        this.TextBei.Value = dt.Rows[0]["FromSource"].ToString();
       
    }

    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string name = this.txtName.Text.ToString();
        int check = Convert.ToInt16(this.RadioButtonList1.SelectedValue.ToString());
        string Bei = this.TextBei.Value.ToString();
        string textlist = this.TextList.Text.ToString();
     
        string sqlstring = "update RecommendedResources set ResourceName='" + name + "', StateID=" + check + ", FromSource='" + Bei + "',TuijianID='" + textlist + "' where ResourceID=" +ResID;
        if (Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlstring) > 0)
        {
           // this.ClientScript.RegisterStartupScript(this.GetType(), "message", "<script language='javascript' defer>alert('成功');</script>");
           // Response.Redirect("ResDongList.aspx");
            Response.Write("<script>alert('修改成功！');document.location='ResDongList.aspx'</script>");
        }
        else
        {
        }
    }
}
