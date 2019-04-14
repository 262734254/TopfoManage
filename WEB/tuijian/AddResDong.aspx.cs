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

public partial class tuijian_AddResDong : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 添加类型
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string name = this.txtName.Text.ToString().Trim();
        int check = Convert.ToInt16(this.RadioButtonList1.SelectedValue.ToString());
        string Bei = this.TextBei.Value.ToString();
        string textlist = this.TextList.Text.ToString();
        string sqlstring = "insert into RecommendedResources(ResourceName,StateID,TuijianID,FromSource) values('" + name + "'," + check + ",'" + textlist + "','" + Bei + "')";
        if (name.Length > 0)
        {
            if (Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlstring) > 0)
            {
                //this.ClientScript.RegisterStartupScript(this.GetType(), "message", "<script language='javascript' defer>alert('成功');</script>");
                Response.Write("<script>alert('修改成功！');document.location='ResDongList.aspx'</script>");
            }
           
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "message", "<script language='javascript'>alert('名称不能为空！');</script>");
        }

    }
}
