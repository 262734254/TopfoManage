using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data.SqlClient;
using Tz888.IDAL.report;
using System.Data;
using Tz888.Model.report;
namespace Tz888.SQLServerDAL.report
{
    public class reportViewDAL : IreportView
    {
        //Tz888.SQLServerDAL.report.reportTabDAL reporttabdal = new reportTabDAL();
        /// <summary>
        /// 向两个表中插入数据
        /// </summary>
        /// <param name="report"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public int InsertReport(ReportTab report, ReportView view)
        {
            int identity = 0;
            SqlParameter[] para =
            {
                 new SqlParameter("@reportname",SqlDbType.VarChar,200),
                 new SqlParameter("@bigtypeid",SqlDbType.Int,4),
                 new SqlParameter("@smalltypeid",SqlDbType.Int,4),
                 new SqlParameter("@price",SqlDbType.VarChar,200),
                 new SqlParameter("@explain",SqlDbType.NVarChar,1000),
                 new SqlParameter("@effectivedata",SqlDbType.VarChar,50),
                 new SqlParameter("@invaliddata",SqlDbType.VarChar,50),
                 new SqlParameter("@charges",SqlDbType.Int,4),
                 new SqlParameter("@createdate",SqlDbType.DateTime),
                 new SqlParameter("@FormID",SqlDbType.Int,4),
                 new SqlParameter("@Html",SqlDbType.VarChar,200),
                 new SqlParameter("@auditid",SqlDbType.Int,4),
                 new SqlParameter("@recommendID",SqlDbType.Int,4),
                 new SqlParameter("@paytype",SqlDbType.VarChar,200),
                 new SqlParameter("@Chartcount",SqlDbType.Int,4),
                 new SqlParameter("@pagecount",SqlDbType.Int,4),
                 new SqlParameter("@writing",SqlDbType.VarChar,200),
                 new SqlParameter("@Publishingdate",SqlDbType.VarChar,50),
                 new SqlParameter("@message",SqlDbType.NText),
                 new SqlParameter("@Title",SqlDbType.VarChar,100),
                 new SqlParameter("@keywords",SqlDbType.VarChar,100),
                 new SqlParameter("@description",SqlDbType.VarChar,200),
                 new SqlParameter("@OverTime",SqlDbType.NVarChar,150),
                 new SqlParameter("@entityId",SqlDbType.Int,4)
            };
            para[0].Value = report.Reportname;
            para[1].Value = report.Bigtypeid;
            para[2].Value = report.Smalltypeid;
            para[3].Value = report.Price;
            para[4].Value = report.Explain;
            para[5].Value = report.Effectivedata;
            para[6].Value = report.Invaliddata;
            para[7].Value = report.Charges;
            para[8].Value = report.Createdate;
            para[9].Value = report.FormID;
            para[10].Value = report.Html;
            para[11].Value = report.Auditid;
            para[12].Value = report.RecommendID;
            para[13].Value = view.Paytype;
            para[14].Value = view.Chartcount;
            para[15].Value = view.Pagecount;
            para[16].Value = view.Writing;
            para[17].Value = view.Publishingdate;
            para[18].Value = view.Message;
            para[19].Value = view.Title;
            para[20].Value = view.Keywords;
            para[21].Value = view.Description;
            para[22].Value = report.OverTime;
            para[23].Direction = ParameterDirection.Output;
            if (DBHelper.RunProcLob("ReportTab_insert", para))
            {
                if ( para[23].Value != null)
                {
                    identity = Convert.ToInt32(para[23].Value);
                }
                else
                {
                    identity = 0;
                }
            }
            return identity;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="report"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public bool UpdateReport(ReportTab report, ReportView view)
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@reportname",SqlDbType.VarChar,200),
                 new SqlParameter("@bigtypeid",SqlDbType.Int,4),
                 new SqlParameter("@smalltypeid",SqlDbType.Int,4),
                 new SqlParameter("@price",SqlDbType.VarChar,200),
                 new SqlParameter("@explain",SqlDbType.NVarChar,1000),
                 new SqlParameter("@effectivedata",SqlDbType.VarChar,50),
                 new SqlParameter("@invaliddata",SqlDbType.VarChar,50),
                 new SqlParameter("@charges",SqlDbType.Int,4),
                 new SqlParameter("@createdate",SqlDbType.DateTime),
                 new SqlParameter("@FormID",SqlDbType.Int,4),
                 new SqlParameter("@Html",SqlDbType.VarChar,200),
                 new SqlParameter("@auditid",SqlDbType.Int,4),
                 new SqlParameter("@recommendID",SqlDbType.Int,4),
                 new SqlParameter("@paytype",SqlDbType.VarChar,200),
                 new SqlParameter("@Chartcount",SqlDbType.Int,4),
                 new SqlParameter("@pagecount",SqlDbType.Int,4),
                 new SqlParameter("@writing",SqlDbType.VarChar,200),
                 new SqlParameter("@Publishingdate",SqlDbType.VarChar,50),
                 new SqlParameter("@message",SqlDbType.NText),
                 new SqlParameter("@Title",SqlDbType.VarChar,100),
                 new SqlParameter("@keywords",SqlDbType.VarChar,100),
                 new SqlParameter("@description",SqlDbType.VarChar,200),
                 new SqlParameter("@OverTime",SqlDbType.NVarChar,150),
                 new SqlParameter("@clickId",SqlDbType.Int,4),
                 new SqlParameter("@flag",SqlDbType.VarChar,50),
                 new SqlParameter("@IdEntity",SqlDbType.Int,4)
           
            };
            para[0].Value = report.Reportname;
            para[1].Value = report.Bigtypeid;
            para[2].Value = report.Smalltypeid;
            para[3].Value = report.Price;
            para[4].Value = report.Explain;
            para[5].Value = report.Effectivedata;
            para[6].Value = report.Invaliddata;
            para[7].Value = report.Charges;
            para[8].Value = report.Createdate;
            para[9].Value = report.FormID;
            para[10].Value = report.Html;
            para[11].Value = report.Auditid;
            para[12].Value = report.RecommendID;
            para[13].Value = view.Paytype;
            para[14].Value = view.Chartcount;
            para[15].Value = view.Pagecount;
            para[16].Value = view.Writing;
            para[17].Value = view.Publishingdate;
            para[18].Value = view.Message;
            para[19].Value = view.Title;
            para[20].Value = view.Keywords;
            para[21].Value = view.Description;
            para[22].Value = report.OverTime;
            para[23].Value = report.ClickId;
            para[24].Value = "UpdateManage";
            para[25].Value = report.ReportID;
            return DBHelper.RunProcLob("ReportTab_insert", para);
        }
        public int DeletereportView(int Id)
        {
            string sql = "delete reportView where reportid=@Id  ";
            int result = DBHelper.ExecuteSql(sql, new SqlParameter("@Id", Id));
            return result;
        }
        public ReportView GetModel(int Reportviewid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Reportviewid,reportID,paytype,Chartcount,pagecount,writing,Publishingdate,message,Title,keywords,description from reportView ");
            strSql.Append(" where reportID=@Reportviewid");
            SqlParameter[] parameters = {
					new SqlParameter("@Reportviewid", SqlDbType.Int,4)
};
            parameters[0].Value = Reportviewid;

            ReportView model = new ReportView();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Reportviewid"].ToString() != "")
                {
                    model.Reportviewid = int.Parse(ds.Tables[0].Rows[0]["Reportviewid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["reportID"].ToString() != "")
                {
                    model.ReportID = int.Parse(ds.Tables[0].Rows[0]["reportID"].ToString());
                }
                model.Paytype = ds.Tables[0].Rows[0]["paytype"].ToString();
                if (ds.Tables[0].Rows[0]["Chartcount"].ToString() != "")
                {
                    model.Chartcount = int.Parse(ds.Tables[0].Rows[0]["Chartcount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pagecount"].ToString() != "")
                {
                    model.Pagecount = int.Parse(ds.Tables[0].Rows[0]["pagecount"].ToString());
                }
                model.Writing = ds.Tables[0].Rows[0]["writing"].ToString();
                model.Publishingdate = ds.Tables[0].Rows[0]["Publishingdate"].ToString();
                model.Message = ds.Tables[0].Rows[0]["message"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Keywords = ds.Tables[0].Rows[0]["keywords"].ToString();
                model.Description = ds.Tables[0].Rows[0]["description"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
   
    }
}