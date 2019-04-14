using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace Tz888.SQLServerDAL.Info
{
    public class IndexSelect
    {

        public IndexSelect()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        #region 招商信息前五条
        /// <summary>
        /// 招商信息前五条
        /// </summary>
        /// <returns></returns>
        public string MerchantNewList(string LoginName)
        {


            string sql = "SELECT top 5 dbo.MainInfoTab.Title,dbo.MainInfoTab.InfoID,dbo.MainInfoTab.InfoID, dbo.MerchantInfoTab.IndustryClassList,MerchantInfoTab.CityID,MerchantInfoTab.ProvinceID, dbo.MainInfoTab.HtmlFile FROM dbo.MainInfoTab INNER JOIN dbo.MerchantInfoTab ON dbo.MainInfoTab.InfoID= dbo.MerchantInfoTab.InfoID where MainInfoTab.LoginName=@LoginName and  MainInfoTab. AuditingStatus=1 ORDER BY MainInfoTab.publishT desc";
            StringBuilder sb = new StringBuilder();
            SqlParameter[] para ={
            new SqlParameter("@LoginName",SqlDbType.VarChar,20)};
            para[0].Value = LoginName;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            string url = "http://www.topfo.com";
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {




                sb.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                sb.Append("<thead><tr><td width=\"223\" style=\"width:223px\">项目名称</td><td width=\"128\" style=\"width:128px\">项目地域</td><td  width=\"128\" style=\"width:128px\">项目领域</td>");
                sb.Append("<td width=\"82\" style=\"width:82px\">详细</td></thead></tr>");



                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    string title = dr["Title"].ToString();
                    string urlshow = url + "/" + dr["HtmlFile"].ToString().Trim();
                    string Are = ProvinceSelect(dr["ProvinceID"].ToString().Trim());
                    string City = CitySelect(dr["CityID"].ToString().Trim());
                    string IndustryBID = IndustrySelect(dr["IndustryClassList"].ToString().Trim());



                    sb.Append("<tbody><tr>");
                    sb.Append("<td><a href=" + urlshow + "  target=\"_blank\">" + GetTitle(title, 10) + "</a></td>");
                    sb.Append("<td> " + Are + " " + City + "</td>");
                    sb.Append("<td>" + IndustryBID + " </td>");
                    sb.Append("<td><a href=" + urlshow + "  target=\"_blank\">详细</a></td>");


                    sb.Append("</tr></tbody>");
                }

                sb.Append("</table>");
                return sb.ToString();
            }
            else
            {
                return "数据出错";
            }
        }
        #endregion


        #region 招商信息
        /// <summary>
        /// 招商信息前
        /// </summary>
        /// <returns></returns>
        public string MerchantNew(string LoginName)
        {


            string sql = "SELECT top 20 dbo.MainInfoTab.Title,dbo.MainInfoTab.InfoID,dbo.MerchantInfoTab.IndustryClassList,MerchantInfoTab.CapitalTotal,MerchantInfoTab.Merchanreturns, dbo.MainInfoTab.HtmlFile FROM dbo.MainInfoTab INNER JOIN dbo.MerchantInfoTab ON dbo.MainInfoTab.InfoID= dbo.MerchantInfoTab.InfoID where MainInfoTab. AuditingStatus=1 and MainInfoTab.LoginName=@LoginName ORDER BY MainInfoTab.publishT desc";
            StringBuilder sb = new StringBuilder();
            SqlParameter[] para ={
            new SqlParameter("@LoginName",SqlDbType.VarChar,20)};
            para[0].Value = LoginName;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            string url = "http://www.topfo.com";
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {


                sb.Append("<table width=\"676\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                sb.Append("<thead><tr><td width=\"321\" style=\"width:321px\">项目名称</td><td width=\"159\" style=\"width:159px\">行业</td>");
                sb.Append("<td width=\"107\" style=\"width:107px\">金额</td><td width=\"89\" style=\"width:89px\">详情</td></tr></thead>");
                sb.Append("<tbody>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    DataRow dr = ds.Tables[0].Rows[i];
                    string title = dr["Title"].ToString();
                    string urlshow = url + "/" + dr["HtmlFile"].ToString().Trim();
                    string Money = dr["CapitalTotal"].ToString() + "万元";
                    string huibao = dr["Merchanreturns"].ToString();
                    if (huibao == "")
                    {
                        huibao = "面议";
                    }
                    string IndustryBID = IndustrySelect(dr["IndustryClassList"].ToString().Trim());

                    sb.Append("<td><a href=" + urlshow + "  target=\"_blank\">" + GetTitle(title, 10) + "</a></td>");
                    sb.Append("<td> " + GetTitle(IndustryBID, 5) + "</td>");
                    sb.Append("<td>" + Money + " </td>");
                    sb.Append("<td><a href=" + urlshow + "  target=\"_blank\">详细</a></td>");
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
                return sb.ToString();
            }
            else
            {
                return "暂无数据";
            }
        }
        #endregion
        #region 查询前20条投资信息
        /// <summary>
        ///  投资信息查询
        /// </summary>
        /// <returns></returns>
        public string CapitalNew(string LoginName)
        {


            string sql = "SELECT top 20 dbo.MainInfoTab.Title,dbo.MainInfoTab.InfoID, dbo.MainInfoTab.InfoID, dbo.CapitalInfoTab.IndustryBID,CapitalInfoTab.CapitalID, dbo.MainInfoTab.HtmlFile FROM dbo.MainInfoTab INNER JOIN  "
                        + "dbo.CapitalInfoTab ON dbo.MainInfoTab.InfoID = dbo.CapitalInfoTab.InfoID where MainInfoTab. AuditingStatus=1 and MainInfoTab.LoginName=@LoginName ORDER BY MainInfoTab.publishT desc ";

            StringBuilder sb = new StringBuilder();
            SqlParameter[] para ={
            new SqlParameter("@LoginName",SqlDbType.VarChar,20)};
            para[0].Value = LoginName;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            string url = "http://www.topfo.com";
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                sb.Append("<table width=\"676\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                sb.Append("<thead><tr><td width=\"321\" style=\"width:321px\">项目名称</td><td width=\"159\" style=\"width:159px\">项目地域</td>");
                sb.Append("<td width=\"107\" style=\"width:107px\">项目领域</td><td width=\"89\" style=\"width:89px\">投资资金</td></tr></thead>");
                sb.Append("<tbody>");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    string title = dr["Title"].ToString();
                    string urlshow = url + "/" + dr["HtmlFile"].ToString().Trim();
                    string Are = GetModelList(dr["InfoID"].ToString().Trim());
                    string IndustryBID = IndustryClassListSelect(dr["IndustryBID"].ToString().Trim());
                    string Money = MoneySelect(dr["CapitalID"].ToString().Trim());

                    sb.Append("<td><a href=" + urlshow + "  target=\"_blank\">" + GetTitle(title, 10) + "</a></td>");
                    sb.Append("<td> " + Are + "</td>");
                    sb.Append("<td>" + GetTitle(IndustryBID, 5) + " </td>");
                    sb.Append("<td>" + Money + "</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</tbody></table>");
                return sb.ToString();
            }
            else
            {
                return "暂无数据";
            }
        }
        #endregion
        #region 查询前20条融资信息
        /// <summary>
        ///  查询前20条融资信息
        /// </summary>
        /// <returns></returns>
        public string ProjectlNew(string LoginName)
        {


            string sql = "SELECT top 20 dbo.MainInfoTab.Title,dbo.MainInfoTab.InfoID,dbo.MainInfoTab.InfoID, dbo.ProjectInfoTab.IndustryBID,ProjectInfoTab.CityID,ProjectInfoTab.ProvinceID,ProjectInfoTab.CapitalID, dbo.MainInfoTab.HtmlFile FROM dbo.MainInfoTab INNER JOIN dbo.ProjectInfoTab ON dbo.MainInfoTab.InfoID= dbo.ProjectInfoTab.InfoID where MainInfoTab. AuditingStatus=1 and MainInfoTab.LoginName=@LoginName ORDER BY MainInfoTab.publishT desc";
            StringBuilder sb = new StringBuilder();
            SqlParameter[] para ={
            new SqlParameter("@LoginName",SqlDbType.VarChar,20)};
            para[0].Value = LoginName;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            string url = "http://www.topfo.com";
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                sb.Append("<table width=\"676\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                sb.Append("<thead><tr><td width=\"321\" style=\"width:321px\">项目名称</td><td width=\"159\" style=\"width:159px\">项目地域</td>");
                sb.Append("<td width=\"107\" style=\"width:107px\">项目领域</td><td width=\"89\" style=\"width:89px\">需要资金</td></tr></thead>");
                sb.Append("<tbody>");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    string title = dr["Title"].ToString();
                    string urlshow = url + "/" + dr["HtmlFile"].ToString().Trim();
                    string Are = ProvinceSelect(dr["ProvinceID"].ToString().Trim());
                    string City = CitySelect(dr["CityID"].ToString().Trim());
                    string IndustryBID = IndustryClassListSelect(dr["IndustryBID"].ToString().Trim());
                    string Money = MoneySelect(dr["CapitalID"].ToString().Trim());


                    sb.Append("<td><a href=" + urlshow + "  target=\"_blank\">" + GetTitle(title, 10) + "</a></td>");
                    sb.Append("<td> " + Are + "</td>");
                    sb.Append("<td>" + GetTitle(IndustryBID, 5) + " </td>");
                    sb.Append("<td>" + Money + "</td>");
                    sb.Append("</tr>");

                    sb.Append("</tr>");
                }

                sb.Append("</tbody></table>");
                return sb.ToString();
            }
            else
            {
                return "暂无数据";
            }
        }
        #endregion
        #region 获取投资金额
        public string MoneySelect(string Money)
        {
            string Name = "";
            if (Money == "")
            {
                Money = "暂未设置";
                return Name;

            }
            string sql = "SELECT CapitalID, CapitalName FROM SetCapitalTab Where CapitalID=@Money ";
            SqlParameter[] para ={
            new SqlParameter("@Money",SqlDbType.VarChar,20)};
            para[0].Value = Money;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {


                Name = ds.Tables[0].Rows[0]["CapitalName"].ToString();
                return Name;
            }
            else
            {
                return null;
            }

        }
        #endregion

        #region 获取行页
        /// <summary>
        /// 根据ID获取行页
        /// </summary>
        /// <returns></returns>
        public string IndustryClassListSelect(string IndustryBID)
        {
            string[] a = IndustryBID.Split(',');
            string Name = "";
            if (a[0] == "")
            {
                Name = "暂无行业";
                return Name;
            }

            //string sql = "SELECT *FROM SetIndustryBTab where IndustryBID = '" + a[0] +"'";
            string sql = "SELECT * FROM SetIndustryBTab where IndustryBID =@IndustryBID";
            SqlParameter[] para ={
            new SqlParameter("@IndustryBID",SqlDbType.VarChar,20)};
            para[0].Value = a[0];
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {


                Name = ds.Tables[0].Rows[0]["IndustryBName"].ToString();
                return Name;
            }
            else
            {
                return null;
            }


        }
        #endregion
        #region 招商获取行页
        /// <summary>
        /// 根据ID获取行页
        /// </summary>
        /// <returns></returns>
        public string IndustrySelect(string IndustryBID)
        {
            string Name = "";
            if (IndustryBID == "")
            {
                Name = "暂无行业";
                return Name;
            }
            string[] num = IndustryBID.Split(',');
            for (int i = 0; i < num.Length - 1; i++)
            {
                string sql = "SELECT * FROM SetIndustryBTab where IndustryBID =@IndustryBID";
                SqlParameter[] para ={
            new SqlParameter("@IndustryBID",SqlDbType.VarChar,20)};
                para[0].Value = num[i];
                DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
                if (ds.Tables[0].Rows.Count > 0)
                {


                    Name += ds.Tables[0].Rows[0]["IndustryBName"].ToString() + " ";

                }
                else
                {
                    return null;
                }

            }
            return Name;



        }

        #endregion


        #region 获取投资资源的投资区域信息
        /// <summary>
        /// 获取投资资源的投资区域信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public string GetModelList(string InfoID)
        {
            string CityID = "";
            string CountyID = "";
            SqlParameter[] parameters = {
                    new SqlParameter("@InfoID", SqlDbType.BigInt,8)
                };
            parameters[0].Value = InfoID;

            string CountyName = "";
            string CityName = "";
            string ProvinceName = "";
            DataSet ds = DbHelperSQL.RunProcedure("CapitalInfoAreaTab_GetListByInfoID", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return "全国";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                if (ds.Tables[0].Rows[i]["InfoAreaID"].ToString() != "")
                {
                    int InfoAreaID = Convert.ToInt32(ds.Tables[0].Rows[i]["InfoAreaID"]);
                }
                string CountryCode = ds.Tables[0].Rows[i]["CountryCode"].ToString();
                string CountryName = ds.Tables[0].Rows[i]["CountryName"].ToString();
                string ProvinceID = ds.Tables[0].Rows[i]["ProvinceID"].ToString();
                ProvinceName = ds.Tables[0].Rows[i]["ProvinceName"].ToString();
                CityID = ds.Tables[0].Rows[i]["CityID"].ToString();
                CityName = ds.Tables[0].Rows[i]["CityName"].ToString();
                CountyID = ds.Tables[0].Rows[i]["CountyID"].ToString();
                CountyName = ds.Tables[0].Rows[i]["CountyName"].ToString();
            }
            string num = ProvinceName + " " + CityName;
            if (num == " ")
            {
                return "全国";
            }
            return num;


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
        #region 获取市
        /// <summary>
        /// 根据ID获取市
        /// </summary>
        /// <returns></returns>
        public string CitySelect(string CityID)
        {
            string Name = "";
            if (CityID == "")
            {
                Name = "";
                return Name;
            }
            string sql = "select CityID,CityName from  SetCityTab where CityID=@CityID";
            SqlParameter[] para ={
            new SqlParameter("@CityID",SqlDbType.Int,20)};
            para[0].Value = CityID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Name = ds.Tables[0].Rows[0]["CityName"].ToString();
                return Name;
            }

            else
            {
                return null;
            }


        }
        #endregion
        #region 获取文章标题长度
        /// <summary>
        /// 获取文章标题长度
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="n">大小</param>
        /// <returns></returns>
        public string GetTitle(string title, int n)
        {
            string str = "";
            if (title != "")
            {
                str = title.Length > n ? title.ToString().Substring(0, n) + ".." : title;
            }
            return str;

        }
        #endregion
    }
}
