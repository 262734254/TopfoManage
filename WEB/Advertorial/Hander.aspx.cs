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
using System.Text;
using System.Data.SqlClient;
public partial class Advertorial_Hander : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request["MuneName"] != null && Request["classID"] != null)
            {
                if (existName(int.Parse(Request["classID"].ToString()), Request["MuneName"].ToString().Trim()))
                {
                    Response.Write("true");
                    Response.End();
                }
                else
                {
                    Response.Write("false");
                    Response.End();
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["industryID"]) && !string.IsNullOrEmpty(Request.QueryString["sid"]))
            {
                int industryID = int.Parse(Request.QueryString["industryID"].ToString());
                int sid = int.Parse(Request.QueryString["sid"].ToString());
                deleteById(industryID);
                Response.Redirect("IndustryManage1.aspx?sid=" + sid);
            }
        }
    }
    private int deleteById(int id)
    {
        string sql = "delete industryTypetab where industryId=" + id;
        return Tz888.DBUtility.DBHelper.ExecuteSql(sql);

    }
    private bool existName(int classId, string name)
    {
        string inName = "";
        string str = " where classID=" + classId;
        if (name != "")
        {
            str += " and industryName='" + name + "'";
        }
        string sql = "select industryName from industryTypetab " + str;
        SqlDataReader reader = Tz888.DBUtility.DBHelper.ExecuteReader(sql);
        if (reader.Read())
        {
            inName = reader["industryName"].ToString();
        }
        if (inName.Equals(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
