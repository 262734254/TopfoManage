<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Text;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string names = context.Request["userName"].ToString();
        string cc = context.Request["jsoncallback"];
        if (names.EndsWith(","))
        {

            string[] str = names.Split(',');
            for (int i = 0; i < str.Length - 1; i++)
            {
                string a = str[i].ToString();
            }
        }
        else
        {
            int a = names.Length;//cn001,liulixing,
            string name = names.Substring(1, a - 2);
        }


        context.Response.Write(cc + "({name:" + names + "})");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}