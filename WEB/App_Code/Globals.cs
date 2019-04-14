using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Globals 的摘要说明
/// </summary>
public class Globals
{
    /// <summary>
    /// 获取服务器主机地址（包括访问协议方案、主机地址和端口号）。
    /// </summary>
    /// <value>服务器主机地址。</value>
    public static string HostUrl
    {
        get
        {
            Uri uri = HttpContext.Current.Request.Url;
            return String.Concat(uri.Scheme, "://", uri.Authority);
        }
    }

    /// <summary>
    /// 获取服务器应用程序虚拟路径。
    /// </summary>
    /// <value>服务器应用程序虚拟路径。</value>
    public static string ApplicationPath
    {
        get
        {
            string root = HttpContext.Current.Request.ApplicationPath;
            if (root != "/") root += "/";
            return root;
        }
    }

}
