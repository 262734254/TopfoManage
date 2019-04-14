using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Tz888.SQLServerDAL.SearchStatic
{
  public  class SearchStatic
    {

      

        #region 最新融资项目
        /// <summary>
        /// 最新融资项目
        /// </summary>
        /// <returns></returns>
        public string SelProject()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 10 Title,HtmlFile from MainInfoTab where AuditingStatus=1 and InfoTypeID='Project' order by publishT desc ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<li>·<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" +StrLength(row["Title"].ToString(),14) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        } 
        #endregion

        #region 最新投资项目
        /// <summary>
        /// 最新融资项目
        /// </summary>
        /// <returns></returns>
      public string SelCapital()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 10 Title,HtmlFile from MainInfoTab where AuditingStatus=1 and InfoTypeID='Capital' order by publishT desc ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<li>·<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + StrLength(row["Title"].ToString(), 14) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
        #endregion

        #region 最新招商项目
        /// <summary>
        /// 最新融资项目
        /// </summary>
        /// <returns></returns>
      public string SelMerchant()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 10 Title,HtmlFile from MainInfoTab where AuditingStatus=1 and InfoTypeID='Merchant' order by publishT desc ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<li>·<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\">" + StrLength(row["Title"].ToString(), 14) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
        #endregion
      #region 截取字符串的个数
      protected string StrLength(object title, int number)
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
