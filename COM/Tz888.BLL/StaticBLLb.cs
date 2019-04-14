using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.BLL
{
    public class StaticBLL
    {
        string FieldPath = ConfigurationManager.AppSettings["FieldAppPath"].ToString(); //生成页面存放位置
        string FieldTem = ConfigurationManager.AppSettings["FieldTem"].ToString(); //模版存放位置

        #region 成功案例静态页面生成
        /// <summary>
        /// 成功案例静态页面生成
        /// </summary>
        /// <param name="NewsID">编号</param>
        /// <param name="title">标题</param>
        /// <param name="publishT">时间</param>
        /// <param name="Content">详细内容</param>
        public void StaticHtml(string Field,string num)
        {
            string Tem = Compage.Reader(FieldTem.ToString()); //读取模板内容
            #region 替换模版
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$Field$", Field);
            #endregion


            string wenjian = MerchantTmpPathTo ;
            if (Directory.Exists(wenjian) == false)
            {
                Directory.CreateDirectory(wenjian);
            }
            string htmlpaths = "";
            if (num == "1")//招商
            {
                htmlpaths = wenjian  + "Merchant.shtml";
            }
            else if (num == "2")//融资
            {
                htmlpaths = wenjian + "Project.shtml";
            }
            else if (num == "3")//投资
            {
                htmlpaths = wenjian + "Capital.shtml";
            }
            Compage.Writer(htmlpaths, TempSoure);
        }
        /// <summary>
        /// 最新招商项目
        /// </summary>
        /// <returns></returns>
        public string SelMerchant()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 7 a.Title,a.HtmlFile,b.IndustryClassList from MainInfoTab as a inner join MerchantInfoTab"
                +" as b on a.InfoID=b.InfoID where a.AuditingStatus=1 and a.InfoTypeID='Merchant' order by a.publishT desc ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<div class=\"con1_col\"><div class=\"l f_14 strong\">最新招商项目</div>");
            sb.Append("<div class=\"r\"><a href=\"http://zs.topfo.com/\">&gt;&gt;更多</a></div><div class=\"clear\"></div></div>");
            sb.Append("<div class=\"con1_sub\"><ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                { 
                   DataRow row=ds.Tables[0].Rows[i];
                   string[] industy = row["IndustryClassList"].ToString().Split(',');
                   sb.Append("<li>·<a href='#' target=\"_blank\">[" + SelIndusty(industy[0].ToString().Trim()) + "]</a><a href='http://zs.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + row["Title"].ToString() + "</a></li>");
                }
            }
            sb.Append("</ul></div><div class=\"con_mar\"></div>");
            return sb.ToString();
        }

        /// <summary>
        /// 最新融资项目
        /// </summary>
        /// <returns></returns>
        public string SelProject()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 7 a.Title,a.HtmlFile,b.IndustryBID from MainInfoTab as a inner join ProjectInfoTab as b"
                +" on a.InfoID=b.InfoID where a.AuditingStatus=1 and a.InfoTypeID='Project' order by a.publishT desc ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<div class=\"con1_col\"><div class=\"l f_14 strong\">最新融资项目</div>");
            sb.Append("<div class=\"r\"><a href=\"http://rz.topfo.com/\">&gt;&gt;更多</a></div><div class=\"clear\"></div></div>");
            sb.Append("<div class=\"con1_sub\"><ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string[] industy = row["IndustryBID"].ToString().Split(',');
                    sb.Append("<li>·<a href='#' target=\"_blank\">[" + SelIndusty(industy[0].ToString().Trim()) + "]</a><a href='http://rz.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + row["Title"].ToString() + "</a></li>");
                }
            }
            sb.Append("</ul></div><div class=\"con_mar\"></div>");
            return sb.ToString();
        }
        /// <summary>
        /// 最新投资项目
        /// </summary>
        /// <returns></returns>
        public string SelCapital()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 7 a.Title,a.HtmlFile,b.IndustryBID from MainInfoTab as a inner join CapitalInfoTab as b "
                +" on a.InfoID=b.InfoID where a.AuditingStatus=1 and a.InfoTypeID='Capital' order by a.publishT desc ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<div class=\"con1_col\"><div class=\"l f_14 strong\">最新投资项目</div>");
            sb.Append("<div class=\"r\"><a href=\"http://tz.topfo.com/\">&gt;&gt;更多</a></div><div class=\"clear\"></div></div>");
            sb.Append("<div class=\"con1_sub\"><ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string[] industy = row["IndustryBID"].ToString().Split(',');
                    sb.Append("<li>·<a href='#' target=\"_blank\">[" + SelIndusty(industy[0].ToString().Trim()) + "]</a><a href='http://tz.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + row["Title"].ToString() + "</a></li>");
                }
            }
            sb.Append("</ul></div><div class=\"con_mar\"></div>");
            return sb.ToString();
        }
        /// <summary>
        /// 专业服务机构
        /// </summary>
        /// <returns></returns>
        public string SelField()
        {
            StringBuilder sb = new StringBuilder();
        }
        /// <summary>
        /// 服务要求
        /// </summary>
        /// <returns></returns>
        public string SelService()
        {
            StringBuilder sb = new StringBuilder();
        }
        #region 获取所属行业
        /// <summary>
        /// 获取所属行业
        /// </summary>
        /// <returns></returns>
        private static string SelIndusty(string IndustryBID)
        {
            string name = "";
            string sql = "select IndustryBName from SetIndustryBTab where IndustryBID=@IndustryBID";
            SqlParameter[] para ={ 
               new SqlParameter("@IndustryBID",SqlDbType.VarChar,20)
            };
            para[0].Value = IndustryBID;
            DataSet ds =Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0]["IndustryBName"].ToString();
            }
            return name;
        }
        #endregion
    }
}
