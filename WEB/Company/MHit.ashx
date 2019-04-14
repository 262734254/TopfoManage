<%@ WebHandler Language="C#" Class="MHit" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
public class MHit : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        int InfoID = Convert.ToInt32(context.Request["CompanyID"]);
        string balk = context.Request["jsoncallback"];
        int num = ModfiyHit(InfoID);
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
    /// <summary>
    /// 访问率
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int ModfiyHit(int infoid)
    {


        int num = 0;
        string sql = "select Hit from MainInfoTab where InfoID=@infoid";
        SqlParameter[] para ={ 
               new SqlParameter("@infoid",SqlDbType.BigInt,8)
            };
        para[0].Value = infoid;
        num = Convert.ToInt32(Tz888.DBUtility.DbHelperSQL.GetSingle(sql, para).ToString());
        int count = num + 1;

        string sqll = "update MainInfoTab set Hit=@count where InfoID=@infoid";
        SqlParameter[] sqlpara ={ 
                 new SqlParameter("@count",SqlDbType.Int,8),
                new SqlParameter("@infoid",SqlDbType.Int,8)
            };
        sqlpara[0].Value = count;
        sqlpara[1].Value = infoid;
        int com = Convert.ToInt32(Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqll, sqlpara));
        return count;


    }

}