using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.ProfessionalManage;
using Tz888.Model.ProfessionalManage;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.ProfessionalManage
{
    public class ProfessionaltalentsDAL : ProfessionaltalentsIDAL
    {
        /// <summary>
        /// 修改一条专业人才数据
        /// </summary>
        /// <returns></returns>
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link)
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
	  
                new SqlParameter("@position",SqlDbType.VarChar,20),
                new SqlParameter("@servicetypeID",SqlDbType.Int,4),
                new SqlParameter("@talentsTypeID",SqlDbType.Int,4),
                new SqlParameter("@resume",SqlDbType.NVarChar,2000),
                new SqlParameter("@specialty",SqlDbType.NVarChar,2000),
                new SqlParameter("@ScuccCase",SqlDbType.NVarChar,2000),
                new SqlParameter("@companydate",SqlDbType.DateTime),

                 new SqlParameter("@validityID",SqlDbType.Int,4),
                 new SqlParameter("@Webtitle",SqlDbType.VarChar,50),
                 new SqlParameter("@keywords",SqlDbType.VarChar,50),
                 new SqlParameter("@Webdescription",SqlDbType.VarChar,50), //21

                 new SqlParameter("@UserName",SqlDbType.VarChar,100),
                 new SqlParameter("@CompanyName",SqlDbType.VarChar,100),
                 new SqlParameter("@Address",SqlDbType.VarChar,100),
                 new SqlParameter("@Tel",SqlDbType.VarChar,50),
                 new SqlParameter("@phone",SqlDbType.VarChar,50),
                 new SqlParameter("@Fax",SqlDbType.VarChar,50),
                 new SqlParameter("@Email",SqlDbType.VarChar,50),
                 new SqlParameter("@Site",SqlDbType.VarChar,50),  
                 new SqlParameter("@price",SqlDbType.Decimal,18), //9

                 new SqlParameter("@auditID",SqlDbType.Int,4),
                 new SqlParameter("@chargeID",SqlDbType.Int,4),
                 new SqlParameter("@stateId",SqlDbType.Int,4),
                 new SqlParameter("@clickId",SqlDbType.Int,4),
                 new SqlParameter("@refurbishtime",SqlDbType.DateTime), //5
                 new SqlParameter("@images",SqlDbType.VarChar,100), //9
                 new SqlParameter("@FeedBackNote",SqlDbType.NVarChar,1000), 
                 new SqlParameter("@flag",SqlDbType.VarChar,20), 
                 new SqlParameter("@ProfessionalID",SqlDbType.Int,4) //2
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
            parameters[10].Value = viewInfo.position;
            parameters[11].Value = viewInfo.servicetypeID;
            parameters[12].Value = viewInfo.talentsTypeID;
            parameters[13].Value = viewInfo.resume;
            parameters[14].Value = viewInfo.specialty;
            parameters[15].Value = viewInfo.ScuccCase;
            parameters[16].Value = viewInfo.companydate;

            parameters[17].Value = viewInfo.validityID;
            parameters[18].Value = viewInfo.title;
            parameters[19].Value = viewInfo.keywords;
            parameters[20].Value = viewInfo.Webdescription;
            parameters[21].Value = link.UserName;
            parameters[22].Value = link.CompanyName;
            parameters[23].Value = link.Address;
            parameters[24].Value = link.Tel;
            parameters[25].Value = link.phone;
            parameters[26].Value = link.Fax;
            parameters[27].Value = link.Email;
            parameters[28].Value = link.Site;
            parameters[29].Value = mainInfo.price;

            parameters[30].Value = mainInfo.auditId;
            parameters[31].Value = mainInfo.chargeId;
            parameters[32].Value = mainInfo.stateId;
            parameters[33].Value = mainInfo.clickId;
            parameters[34].Value = mainInfo.refreshTime;
            parameters[35].Value = viewInfo.Images;
            parameters[36].Value = mainInfo.FeedBackNote;
            parameters[37].Value = "UpdateManage";
            parameters[38].Value = mainInfo.ProfessionalID;
            return DbHelperSQL.RunProcLob("Professionaltalentstab_insert", parameters);
        }
        public DataTable GetTop3ModelByProvinceID(int count, string strWhe)
        {
            //string sql = "SELECT top " + count + " info.titel as titel, Please.institutionsID,Please.ProvinceID as ProvinceID,info.createdate as createdate,info.htmlurl as htmlurl,Please.funds as funds from ProfessionalinfoTab info inner join ProfessionalPlease Please on info.ProfessionalID = Please.ProfessionalID ";
            string sql = "SELECT top " + count + " info.titel as titel, talent.talentsTypeID as talentsTypeID,talent.ProvinceID as ProvinceID,info.createdate as createdate,info.htmlurl as htmlurl,talent.companydate as companydate,talent.position as position from ProfessionalinfoTab info inner join Professionaltalents talent on info.ProfessionalID = talent.ProfessionalID";
            if (!string.IsNullOrEmpty(strWhe))
            {
                sql += " where " + strWhe;
            }
            return DbHelperSQL.Querys(sql).Tables[0];
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Professionaltalents GetModel(int ProfessionalID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 talentsID,ProfessionalID,images,CountryCode,ProvinceID,CityID,CountyID,position,servicetypeID,talentsTypeID,resume,specialty,ScuccCase,companydate,validityID,title,keywords,Webdescription from Professionaltalents ");
            strSql.Append(" where ProfessionalID=@talentsID");
            SqlParameter[] parameters = {
					new SqlParameter("@talentsID", SqlDbType.Int,4)
};
            parameters[0].Value = ProfessionalID;

            Professionaltalents model = new Professionaltalents();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["talentsID"].ToString() != "")
                {
                    model.talentsID = int.Parse(ds.Tables[0].Rows[0]["talentsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProfessionalID"].ToString() != "")
                {
                    model.ProfessionalID = int.Parse(ds.Tables[0].Rows[0]["ProfessionalID"].ToString());
                }
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                model.position = ds.Tables[0].Rows[0]["position"].ToString();
                if (ds.Tables[0].Rows[0]["servicetypeID"].ToString() != "")
                {
                    model.servicetypeID = int.Parse(ds.Tables[0].Rows[0]["servicetypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["talentsTypeID"].ToString() != "")
                {
                    model.talentsTypeID = int.Parse(ds.Tables[0].Rows[0]["talentsTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["images"].ToString() != "")
                {
                    model.Images = ds.Tables[0].Rows[0]["images"].ToString();
                }
                model.resume = ds.Tables[0].Rows[0]["resume"].ToString();
                model.specialty = ds.Tables[0].Rows[0]["specialty"].ToString();
                model.ScuccCase = ds.Tables[0].Rows[0]["ScuccCase"].ToString();
                if (ds.Tables[0].Rows[0]["companydate"].ToString() != "")
                {
                    model.companydate = DateTime.Parse(ds.Tables[0].Rows[0]["companydate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["validityID"].ToString() != "")
                {
                    model.validityID = int.Parse(ds.Tables[0].Rows[0]["validityID"].ToString());
                }
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
                sql = "delete from Professionaltalents where ProfessionalID=@ProfessionalID";
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
    }
}
