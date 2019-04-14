using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using Tz888.Model.Express;
using Tz888.BLL.Express;
namespace Tz888.BLL.Express
{
    public class ExpressStatic
    {

        string FieldPath = ConfigurationManager.AppSettings["KXAppPath"].ToString(); //生成页面存放位置
        string FieldTem = ConfigurationManager.AppSettings["KXTem"].ToString(); //模版存放位置
        public int StaticHtml()
        {
            ExpressBLL bll = new ExpressBLL();
            try
            {

                DataSet ds = bll.GetList(20, " 1=1", " Expressdata desc");
                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DateTime dt = Convert.ToDateTime(dr["Expressdata"].ToString());
                    string ordertime = dt.ToString("yyyy-MM-dd");
                    str.Append("<div class=\"let_c\"><div class=\"let_c_m\"><div class=\"let_c_m_middle\">");
                    str.Append(dr["express"].ToString());
                    str.Append("</div><div class=\"let_c_m_bottom\"><div class=\"let_c_m_bottom_b\">");
                    str.Append("<span class=\"liebiao\">日期：</span><span class=\"lienei\">");
                    str.Append(ordertime);
                    str.Append("</span></div> </div> </div> </div>");
                }
                string TempFileName = FieldTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$express$", str.ToString());
                //string folder = FieldPath + DateTime.Now.ToString("yyyyMM");
                //if (!Directory.Exists(folder))
                //{
                //    Directory.CreateDirectory(folder);
                //}
                //string htmlpaths = folder + "/" + DateTime.Now.ToString("yyyyMMdd") + ".html";
                string htmlpaths = FieldPath + "index.html";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
    }
}
