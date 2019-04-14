<%@ WebHandler Language="C#" Class="Hit" %>

using System;
using System.Web;

public class Hit : IHttpHandler
{
    Tz888.BLL.ProfessionalManage.ProfessionalinfoBLL bll = new Tz888.BLL.ProfessionalManage.ProfessionalinfoBLL();

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int InfoID = Convert.ToInt32(context.Request["CompanyID"]);
        string balk = context.Request["jsoncallback"];
        int num = bll.ModfiyHit(InfoID);
        string com = num.ToString();
        context.Response.Write(balk + "({name:" + com + "})");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}