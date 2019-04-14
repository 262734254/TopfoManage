<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using Tz888.BLL.advertise;

public class Handler : IHttpHandler {
    ADlaunchInfoManager launch = new ADlaunchInfoManager();
    AdvisitInfoManager advisit = new AdvisitInfoManager();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        int adv = Convert.ToInt32(context.Request["adv"]);
        string name =context.Request["name"].ToString();
        string time = context.Request["time"].ToString();
        int adla = launch.ModifCount(adv);
        int advi = advisit.Add(adv,name,time);
        if (adla > 0 && advi > 0)
        {
            context.Response.Write("1");
        }
        else
        {
            context.Response.Write("0");
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
 
    

}