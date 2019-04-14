using System;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.ProfessionalManage;
using Tz888.DBUtility;//请先添加引用
using Tz888.Model.ProfessionalManage;
using System.Text;
namespace Tz888.SQLServerDAL.ProfessionalManage
{
    public class ProfessionalviewDAL : ProfessionalviewIDAL
    {

        #region ProfessionalviewIDAL 成员

        /// <summary>
        /// 用视图查询专业服务信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序</param>
        /// <param name="Page">每页显示多少条</param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount">总数</param>
        /// <returns></returns>
        public DataSet GetProViewInfoAll(string SelectStr, string Criteria, string Sort, long Page, long CurrentPageRow, ref long TotalCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            // return (mCF.dsGetListNewsTopNums("ProfessionalServiceList", SelectStr, Criteria, Sort, Page, CurrentPageRow, ref TotalCount));
            return (mCF.dsGetListNewsTopNums("ProfessionalinfoTab", SelectStr, Criteria, Sort, Page, CurrentPageRow, ref TotalCount));
        }
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link)
        {
            int result = 0;
            SqlParameter[] parameters = {
                 new SqlParameter("@Title",SqlDbType.VarChar,200),
                 new SqlParameter("@LoginName",SqlDbType.VarChar,50),
                 new SqlParameter("@typeID",SqlDbType.Int,4),
                 new SqlParameter("@htmlUrl",SqlDbType.VarChar,200),
                 new SqlParameter("@formID",SqlDbType.Int,4),
                 new SqlParameter("@recommendID",SqlDbType.Int,4), //6
                

                 new SqlParameter("@CountryCode",SqlDbType.VarChar,10),
                 new SqlParameter("@ProvinceID",SqlDbType.VarChar,10),
                 new SqlParameter("@CityID",SqlDbType.VarChar,10),
                 new SqlParameter("@CountyID",SqlDbType.VarChar,10),
                 new SqlParameter("@typeID1",SqlDbType.Int,4),
                 new SqlParameter("@validityID",SqlDbType.Int,4),
                 new SqlParameter("@description",SqlDbType.NVarChar,2000),
                 new SqlParameter("@Webtitle",SqlDbType.VarChar,50),
                 new SqlParameter("@keywords",SqlDbType.VarChar,50),
                 new SqlParameter("@Webdescription",SqlDbType.VarChar,50), //10

                 new SqlParameter("@UserName",SqlDbType.VarChar,100),
                 new SqlParameter("@CompanyName",SqlDbType.VarChar,100),
                 new SqlParameter("@Address",SqlDbType.VarChar,100),
                 new SqlParameter("@Tel",SqlDbType.VarChar,50),
                 new SqlParameter("@phone",SqlDbType.VarChar,50),
                 new SqlParameter("@Fax",SqlDbType.VarChar,50),
                 new SqlParameter("@Email",SqlDbType.VarChar,50),
                 new SqlParameter("@Site",SqlDbType.VarChar,50),  
                 new SqlParameter("@price",SqlDbType.Decimal,18), //9

                
                 //new SqlParameter("@typeID",SqlDbType.Int,4),
                 new SqlParameter("@auditID",SqlDbType.Int,4),
                 new SqlParameter("@chargeID",SqlDbType.Int,4),
                 new SqlParameter("@stateId",SqlDbType.Int,4),
                 new SqlParameter("@clickId",SqlDbType.Int,4),
                 //new SqlParameter("@recommendID",SqlDbType.Int,4), 
                // new SqlParameter("@price",SqlDbType.Decimal,18), 
                 new SqlParameter("@refurbishtime",SqlDbType.DateTime), //5
                 new SqlParameter("@FeedBackNote",SqlDbType.NVarChar,1000), 

                 new SqlParameter("@flag",SqlDbType.VarChar,20), 
                 new SqlParameter("@ProfessionalID",SqlDbType.Int,4) //2   16+9+7=32
             };
            parameters[0].Value = mainInfo.Titel;
            parameters[1].Value = mainInfo.LoginName;
            parameters[2].Value = mainInfo.typeID;
            parameters[3].Value = mainInfo.htmlUrl;
            parameters[4].Value = mainInfo.FromId;
            parameters[5].Value = mainInfo.recommendId;
            parameters[6].Value = viewInfo.CountryCode;
            parameters[7].Value = viewInfo.ProvinceID;
            parameters[8].Value = viewInfo.CityID;
            parameters[9].Value = viewInfo.CountyID;
            parameters[10].Value = viewInfo.typeID;
            parameters[11].Value = viewInfo.validityID;
            parameters[12].Value = viewInfo.description;
            parameters[13].Value = viewInfo.title;
            parameters[14].Value = viewInfo.keywords;
            parameters[15].Value = viewInfo.Webdescription;
            parameters[16].Value = link.UserName;
            parameters[17].Value = link.CompanyName;
            parameters[18].Value = link.Address;
            parameters[19].Value = link.Tel;
            parameters[20].Value = link.phone;
            parameters[21].Value = link.Fax;
            parameters[22].Value = link.Email;
            parameters[23].Value = link.Site;
            parameters[24].Value = mainInfo.price;

            //parameters[25].Value = mainInfo.typeID;
            parameters[25].Value = mainInfo.auditId;
            parameters[26].Value = mainInfo.chargeId;
            parameters[27].Value = mainInfo.stateId;
            parameters[28].Value = mainInfo.clickId;
            //parameters[29].Value = mainInfo.recommendId;
            parameters[29].Value = mainInfo.refreshTime;
            parameters[30].Value = mainInfo.FeedBackNote;
            parameters[31].Value = "UpdateManage";
            parameters[32].Value = mainInfo.ProfessionalID;
            return DbHelperSQL.RunProcLob("Professionalviewtab_insert", parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Professionalview GetModel(int pvid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 pvid,ProfessionalID,CountryCode,ProvinceID,CityID,CountyID,typeID,validityID,description,title,keywords,Webdescription from Professionalview ");
            strSql.Append(" where ProfessionalID=@pvid");
            SqlParameter[] parameters = {
					new SqlParameter("@pvid", SqlDbType.Int,4)
};
            parameters[0].Value = pvid;

            Professionalview model = new Professionalview();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["pvid"].ToString() != "")
                {
                    model.pvid = int.Parse(ds.Tables[0].Rows[0]["pvid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProfessionalID"].ToString() != "")
                {
                    model.ProfessionalID = int.Parse(ds.Tables[0].Rows[0]["ProfessionalID"].ToString());
                }
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                if (ds.Tables[0].Rows[0]["typeID"].ToString() != "")
                {
                    model.typeID = int.Parse(ds.Tables[0].Rows[0]["typeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["validityID"].ToString() != "")
                {
                    model.validityID = int.Parse(ds.Tables[0].Rows[0]["validityID"].ToString());
                }
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.keywords = ds.Tables[0].Rows[0]["keywords"].ToString();
                model.Webdescription = ds.Tables[0].Rows[0]["Webdescription"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        public DataTable GetTop3ModelByProvinceID(int count, string strWhe)
        {
            string sql = "select top " + count + " ProfessionalID,Titel,htmlurl,CreateDate,typeid,provinceId,validityId from ProfessionalService_View_List ";
            if (!string.IsNullOrEmpty(strWhe))
            {
                sql += "where " + strWhe;
            }
            return DbHelperSQL.Querys(sql).Tables[0];
        }
        #endregion
    }
}

