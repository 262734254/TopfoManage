using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Tz888.BLL
{
    public class Static
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
        public int StaticHtml(string Field,string num)
        {
            try
            {

                string Tem = Compage.Reader(FieldTem.ToString()); //读取模板内容
                #region 替换模版
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$Field$", Field);
                #endregion


                string wenjian = FieldPath;
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);
                }
                string htmlpaths = "";
                if (num == "1")//招商
                {
                    htmlpaths = wenjian + "Merchant.shtml";
                }
                else if (num == "2")//融资
                {
                    htmlpaths = wenjian + "Project.shtml";
                }
                else if (num == "3")//投资
                {
                    htmlpaths = wenjian + "Capital.shtml";
                }
                else if (num == "4")//投资
                {
                    htmlpaths = wenjian + "union.shtml";
                }

                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }
        #endregion
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
            sb.Append("<div class=\"r\"><a href=\"http://zs.topfo.com/\" target=\"_blank\" >&gt;&gt;更多</a></div><div class=\"clear\"></div></div>");
            sb.Append("<div class=\"con1_sub\"><ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                { 
                   DataRow row=ds.Tables[0].Rows[i];
                   string[] industy = row["IndustryClassList"].ToString().Split(',');
                   sb.Append("<li>·<a href='http://search.topfo.com/MerchantResource.aspx?InduyByName=" +industy[0].ToString() + "' target=\"_blank\">[" + SelIndusty(industy[0].ToString().Trim()) + "]</a><a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + row["Title"].ToString() + "</a></li>");
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
            sb.Append("<div class=\"r\"><a href=\"http://rz.topfo.com/\" target=\"_blank\">&gt;&gt;更多</a></div><div class=\"clear\"></div></div>");
            sb.Append("<div class=\"con1_sub\"><ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string[] industy = row["IndustryBID"].ToString().Split(',');
                    sb.Append("<li>·<a href='http://search.topfo.com/ProjectResource.aspx?InduyByName=" + industy[0].ToString() + "' target=\"_blank\">[" + SelIndusty(industy[0].ToString().Trim()) + "]</a><a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + row["Title"].ToString() + "</a></li>");
                }
            }
            sb.Append("</ul></div><div class=\"con_mar\"></div>");
            return sb.ToString();
        }
        #region 专业服务类型转换
        /// <summary>
        /// 专业服务类型转换
        /// </summary>
        /// <returns></returns>
        public string Istype(int typeId)
        {
            string chargeStr = string.Empty;
            switch (typeId)
            {
                case 1:
                    chargeStr = "专业服务";//  1A9E0B
                    break;
                case 2:
                    chargeStr = "专业机构";
                    break;
                case 3:
                    chargeStr = "专业人才";
                    break;
            }
            return chargeStr;
        }
        #endregion
        #region 获取省名称
        /// <summary>
        /// 根据ID获取省名称
        /// </summary>
        /// <returns></returns>
        public string ProvinceSelect(string ProvinceID)
        {
            string Name = "";
            if (ProvinceID == "")
            {
                Name = "全国";
                return Name;
            }
            string sql = "SELECT *FROM SetProvinceTab where ProvinceID =@ProvinceID";
            SqlParameter[] para ={
            new SqlParameter("@ProvinceID",SqlDbType.Int,20)};
            para[0].Value = ProvinceID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Name = ds.Tables[0].Rows[0]["ProvinceName"].ToString();
                return Name;
            }

            else
            {
                return null;
            }


        }
        #endregion
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
            sb.Append("<div class=\"r\"><a href=\"http://tz.topfo.com/\" target=\"_blank\">&gt;&gt;更多</a></div><div class=\"clear\"></div></div>");
            sb.Append("<div class=\"con1_sub\"><ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string[] industy = row["IndustryBID"].ToString().Split(',');
                    sb.Append("<li>·<a href='http://search.topfo.com/CatialResource.aspx?InduyByName=" + industy[0].ToString() + "' target=\"_blank\">[" + SelIndusty(industy[0].ToString().Trim()) + "]</a><a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + row["Title"].ToString() + "</a></li>");
                }
            }
            sb.Append("</ul></div><div class=\"con_mar\"></div>");
            return sb.ToString();
        }
        /// <summary>
        /// 专业服务需求
        /// </summary>
        /// <returns></returns>
        public string SelField()
        {
            StringBuilder sb = new StringBuilder();

            string sql = "select top 7 Titel,typeTID,htmlUrl from ProfessionalinfoTab where auditId=1 order by createDate desc ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<div class=\"con1_col\"><div class=\"l f_14 strong\">专业服务</div>");
            sb.Append("<div class=\"r\"><a href=\"http://union.topfo.com/\" target=\"_blank\">&gt;&gt;更多</a></div><div class=\"clear\"></div></div>");
            sb.Append("<div class=\"con1_sub\"><ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    int IstypeID = Convert.ToInt32(row["typeTID"].ToString());
                    sb.Append("<li>·<a href='#' target=\"_blank\">[" + Istype(IstypeID) + "]</a><a href='http://www.topfo.com/" + row["htmlUrl"].ToString() + "' target=\"_blank\">" + row["Titel"].ToString() + "</a></li>");
                }
            }
            sb.Append("</ul></div><div class=\"con_mar\"></div>");
            return sb.ToString();
        }
     
        /// <summary>
        /// 服务要求
        /// </summary>
        /// <returns></returns>
        public string SelService()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
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
        #region 设置了为重大的招商项目
        /// <summary>
        /// 设置了为重大的招商项目
        /// </summary>
        /// <returns></returns>
        public string SelIsVip()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 6 Title,HtmlFile from MainInfoTab where InfoTypeID='Merchant' and AuditingStatus=1 and isVIP='1' order by publishT desc";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    sb.Append("<li>·<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + StrLength(Title.ToString().Trim(), 18) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        } 
        #endregion
        #region 设置了为重大的投资项目
        /// <summary>
        /// 设置了为重大的投资项目
        /// </summary>
        /// <returns></returns>
        public string SelCapitalInfoVip()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "SELECT top 6  MainInfoTab.Title, dbo.MainInfoTab.HtmlFile FROM MainInfoTab INNER JOIN CapitalInfoTab ON MainInfoTab.InfoID = CapitalInfoTab.InfoID where CapitalInfoTab.isVip='1' and MainInfoTab.AuditingStatus=1 order by MainInfoTab.publishT desc";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    sb.Append("<li>·<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + StrLength(Title.ToString().Trim(), 18) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
        #endregion
        #region 截取字符串的个数
        protected string StrLength(object title,int number)
        {
            string name = "";
            name = title.ToString();
            if (name.Length > number)
            {
                name = name.Substring(0, number) + "...";
            }
            return name;
        }
        #endregion


    }
}
