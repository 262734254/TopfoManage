<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string LoginName = Convert.ToString(context.Request["Login"]);
        string balk = context.Request["jsoncallback"];
        string num = "123213";// dal.MerchantNew(LoginName);
        string com = num.ToString();
        context.Response.Write(balk + "({name:" + com + "})");

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}