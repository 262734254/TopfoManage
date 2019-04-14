using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Request.RawUrl.ToString()+"rawurl <br>");
        Response.Write(Request.Url.ToString() + "Url <br>");
        Response.Write(Request.Path.ToString() + "Path <br>");
        Response.Write(Request.CurrentExecutionFilePath.ToString() + "CurrentExecutionFilePath <br>");
        Response.Write(Request.ApplicationPath.ToString() + "ApplicationPath <br>");

        DataTable dt = new DataTable();
        

    }

}
