using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Tz888.BLL.advertise;


using System.Data;
using System.Configuration;
using System.Collections;

using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://www.topfo.com")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService
{
    ADlaunchInfoManager launch = new ADlaunchInfoManager();
    AdvisitInfoManager advisit = new AdvisitInfoManager();
    public WebService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void ADlaunch(int adv,string name,string time)
    {
       
        int adla = launch.ModifCount(adv);
        int advi = advisit.Add(adv, name, time);
        
    }

}

