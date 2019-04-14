using System;
using Tz888.IDAL.ProfessionalManage;
using Tz888.Model.ProfessionalManage;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Text;
namespace Tz888.SQLServerDAL.ProfessionalManage
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfessionalinfoDAL : ProfessionalinfoIDAL
    {
        /// <summary>
        /// 删除跟主表相关的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelInfoById(int id)
        {
            string sql = string.Empty;
            bool flag = false;
            sql = "delete from ProfessionalLink where ProfessionalID=@ProfessionalID";
            SqlParameter[] para ={ new SqlParameter("@ProfessionalID", SqlDbType.VarChar, 10) };
            para[0].Value = id;
            if (DbHelperSQL.ExecuteSql(sql, para) > 0)
            {
                sql = "delete from Professionalview where ProfessionalID=@ProfessionalID";
                SqlParameter[] para1 ={ new SqlParameter("@ProfessionalID", SqlDbType.VarChar, 10) };
                para1[0].Value = id;
                if (DbHelperSQL.ExecuteSql(sql, para1) > 0)
                {
                    sql = "delete from ProfessionalinfoTab where ProfessionalID=@ProfessionalID";
                    SqlParameter[] para2 ={ new SqlParameter("@ProfessionalID", SqlDbType.VarChar, 10) };
                    para2[0].Value = id;
                    if (DbHelperSQL.ExecuteSql(sql, para2) > 0)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }
        /// <summary>
        /// 访问率
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ModfiyHit(int id)
        {
            int num = 0;
            string sql = "select clickId from ProfessionalinfoTab where ProfessionalID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para).ToString());
            int Hit = num + 1;
            string sqll = "update ProfessionalinfoTab set clickId=@clickId where ProfessionalID=@id";
            SqlParameter[] sqlpara ={ 
                 new SqlParameter("@clickId",SqlDbType.Int,8),
                new SqlParameter("@id",SqlDbType.Int,8)
            };
            sqlpara[0].Value = Hit;
            sqlpara[1].Value = id;
            int com = Convert.ToInt32(DbHelperSQL.GetSingle(sqll, sqlpara));
            return Hit;
        }
        public ProfessionalinfoTab GetModel(int ProfessionalID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProfessionalID,Titel,FeedBackNote,LoginName,typeTID,auditId,stateId,chargeId,htmlUrl,createDate,FromId,clickId,recommendId,price,refreshTime from ProfessionalinfoTab ");
            strSql.Append(" where ProfessionalID=@ProfessionalID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProfessionalID", SqlDbType.Int,4)
            };
            parameters[0].Value = ProfessionalID;

            ProfessionalinfoTab model = new ProfessionalinfoTab();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProfessionalID"].ToString() != "")
                {
                    model.ProfessionalID = int.Parse(ds.Tables[0].Rows[0]["ProfessionalID"].ToString());
                }
                model.Titel = ds.Tables[0].Rows[0]["Titel"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                if (ds.Tables[0].Rows[0]["typeTID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeTID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["auditId"].ToString() != "")
                {
                    model.auditId = int.Parse(ds.Tables[0].Rows[0]["auditId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["stateId"].ToString() != "")
                {
                    model.stateId = int.Parse(ds.Tables[0].Rows[0]["stateId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["chargeId"].ToString() != "")
                {
                    model.chargeId = int.Parse(ds.Tables[0].Rows[0]["chargeId"].ToString());
                }
                model.htmlUrl = ds.Tables[0].Rows[0]["htmlUrl"].ToString();
                if (ds.Tables[0].Rows[0]["createDate"].ToString() != "")
                {
                    model.creatgeDate = DateTime.Parse(ds.Tables[0].Rows[0]["createDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FromId"].ToString() != "")
                {
                    model.FromId = int.Parse(ds.Tables[0].Rows[0]["FromId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["clickId"].ToString() != "")
                {
                    model.clickId = int.Parse(ds.Tables[0].Rows[0]["clickId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["recommendId"].ToString() != "")
                {
                    model.recommendId = int.Parse(ds.Tables[0].Rows[0]["recommendId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["price"].ToString() != "")
                {
                    model.price = decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["refreshTime"].ToString() != "")
                {
                    model.refreshTime = DateTime.Parse(ds.Tables[0].Rows[0]["refreshTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FeedBackNote"].ToString()!="")
                {
                    model.FeedBackNote = ds.Tables[0].Rows[0]["FeedBackNote"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 判断静态页面是否存在
        /// </summary>
        /// <param name="infoId"></param>
        public string PaperExeists(int ProfessionalID)
        {
            string name = "";
            string sql = "select HtmlUrl from ProfessionalinfoTab where ProfessionalID=@ProfessionalID";
            SqlParameter[] para ={ 
                new  SqlParameter("@ProfessionalID",SqlDbType.Int,8)
            };
            para[0].Value = ProfessionalID;
            name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            return name;

        }
    }
}

