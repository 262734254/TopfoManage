using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data.SqlClient;
using Tz888.IDAL.report;
using Tz888.Model.report;
using System.Data;
namespace Tz888.SQLServerDAL.report
{
    public class reportTabDAL : IreportTab
    {

        public int DeletereportTab(int Id)
        {
            string sql = "delete reportTab where reportID=@Id  ";
            int result = DBHelper.ExecuteSql(sql, new SqlParameter("Id", Id));
            return result;
        }
        /// <summary>
        /// ∑√Œ ¬ 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyHit(int id)
        {
            int num = 0;
            string sql = "select clickId from reportTab where reportID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            num = Convert.ToInt32(DBHelper.GetSingle(sql, para).ToString());
            int Hit = num + 1;
            string sqll = "update reportTab set clickId=@clickId where reportID=@id";
            SqlParameter[] sqlpara ={ 
                 new SqlParameter("@clickId",SqlDbType.Int,8),
                new SqlParameter("@id",SqlDbType.Int,8)
            };
            sqlpara[0].Value = Hit;
            sqlpara[1].Value = id;
            int com = Convert.ToInt32(DBHelper.GetSingle(sqll, sqlpara));
            return Hit;
        }

        public ReportTab GetModel(int reportID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 reportID,reportname,bigtypeid,smalltypeid,price,explain,OverTime,effectivedata,invaliddata,charges,clickId,createdate,FormID,html,auditid,recommendID from reportTab ");
            strSql.Append(" where reportID=@reportID");
            SqlParameter[] parameters = {
					new SqlParameter("@reportID", SqlDbType.Int,4)
};
            parameters[0].Value = reportID;

            ReportTab model = new ReportTab();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["reportID"].ToString() != "")
                {
                    model.ReportID = int.Parse(ds.Tables[0].Rows[0]["reportID"].ToString());
                }
                model.Reportname = ds.Tables[0].Rows[0]["reportname"].ToString();
                if (ds.Tables[0].Rows[0]["bigtypeid"].ToString() != "")
                {
                    model.Bigtypeid = int.Parse(ds.Tables[0].Rows[0]["bigtypeid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["smalltypeid"].ToString() != "")
                {
                    model.Smalltypeid = int.Parse(ds.Tables[0].Rows[0]["smalltypeid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OverTime"].ToString() != "")
                {
                    model.OverTime = ds.Tables[0].Rows[0]["OverTime"].ToString();
                }
                else
                {
                    model.OverTime = "";
                }
                model.Price = ds.Tables[0].Rows[0]["price"].ToString();
                model.Explain = ds.Tables[0].Rows[0]["explain"].ToString();
                model.Effectivedata = ds.Tables[0].Rows[0]["effectivedata"].ToString();
                model.Invaliddata = ds.Tables[0].Rows[0]["invaliddata"].ToString();
                if (ds.Tables[0].Rows[0]["charges"].ToString() != "")
                {
                    model.Charges = int.Parse(ds.Tables[0].Rows[0]["charges"].ToString());
                }
                if (ds.Tables[0].Rows[0]["createdate"].ToString() != "")
                {
                    model.Createdate = ds.Tables[0].Rows[0]["createdate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FormID"].ToString() != "")
                {
                    model.FormID = int.Parse(ds.Tables[0].Rows[0]["FormID"].ToString());
                }
                model.Html = ds.Tables[0].Rows[0]["html"].ToString();
                if (ds.Tables[0].Rows[0]["auditid"].ToString() != "")
                {
                    model.Auditid = int.Parse(ds.Tables[0].Rows[0]["auditid"].ToString());

                }
                if (ds.Tables[0].Rows[0]["clickId"].ToString() != "")
                {
                    model.ClickId = int.Parse(ds.Tables[0].Rows[0]["clickId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["recommendID"].ToString() != "")
                {
                    model.RecommendID = int.Parse(ds.Tables[0].Rows[0]["recommendID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}
