<%@ WebHandler Language="C#" Class="Merchar" %>

using System;
using System.Web;

public class Merchar : IHttpHandler {


    Tz888.SQLServerDAL.Info.IndexSelect dal = new Tz888.SQLServerDAL.Info.IndexSelect();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string LoginName =Convert.ToString(context.Request["Login"]);
        string balk = context.Request["jsoncallback"];
        string num = "123"; //dal.MerchantNewList(LoginName);

        context.Response.Write("asssssssssssssssssss");
        
        

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

 
}