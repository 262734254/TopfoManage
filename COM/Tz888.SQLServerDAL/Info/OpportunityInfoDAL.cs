using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.Model.Info;

namespace Tz888.SQLServerDAL.Info
{
    public class OpportunityInfoDAL:Tz888.IDAL.Info.IOpportunityInfo
    {
        /// <summary>
        /// 根据行业ID查找行业名称
        /// </summary>
        public string IndustryOpportunityName(int IndustryOpportunityId)
        {
            string name = "";
            string sql = "select  IndustryOpportunityName from SetIndustryOpportunityTab where IndustryOpportunityID=@IndustryOpportunityId";
            SqlParameter[] para ={ 
                new SqlParameter("@IndustryOpportunityId",SqlDbType.Int,8)
            };
            para[0].Value = IndustryOpportunityId;
            name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            return name;
        }
        /// <summary>
        /// 添加商机
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="opportunity"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.OpportunityInfoModel opportunity,
           Tz888.Model.Info.ShortInfoModel shortInfoModel
           )
        {
            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@Title",SqlDbType.VarChar,100),
											new SqlParameter("@InfoCode",SqlDbType.Char,30),
											new SqlParameter("@publishT",SqlDbType.DateTime),
											new SqlParameter("@Hit",SqlDbType.BigInt),

											new SqlParameter("@IsCore",SqlDbType.Bit),
											new SqlParameter("@IndexOrderNum",SqlDbType.BigInt),
											new SqlParameter("@IndexTopValidateDate",SqlDbType.Int),
											new SqlParameter("@IndexPicInfoNum",SqlDbType.BigInt),
											new SqlParameter("@InfoTypeOrderNum",SqlDbType.BigInt),
											new SqlParameter("@InfoTypeTopValidateDate",SqlDbType.Int),
											new SqlParameter("@InfoTypePicInfoNum",SqlDbType.BigInt),

											new SqlParameter("@LoginName",SqlDbType.Char,16),
											new SqlParameter("@InfoOriginRoleName",SqlDbType.Char,10),

											new SqlParameter("@GradeID",SqlDbType.Char,10),
											new SqlParameter("@FixPriceID",SqlDbType.Char,10),
											new SqlParameter("@FeeStatus",SqlDbType.TinyInt),

											//2005/12/12  add
											new SqlParameter("@KeyWord",SqlDbType.VarChar,50),
											new SqlParameter("@Descript",SqlDbType.VarChar,100),
											new SqlParameter("@DisplayTitle",SqlDbType.VarChar,50),
											new SqlParameter("@FrontDisplayTime",SqlDbType.SmallDateTime),
											new SqlParameter("@ValidateStartTime",SqlDbType.SmallDateTime),
											new SqlParameter("@ValidateTerm",SqlDbType.Int),
											new SqlParameter("@TemplateID",SqlDbType.Char,10),
											new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),//该字段不需要更新，只有在审核时才更新

											//商机信息
											new SqlParameter("@AdTitle",SqlDbType.VarChar,50),
											new SqlParameter("@OpportunityType",SqlDbType.Char,10),
											new SqlParameter("@CountryCode",SqlDbType.Char,10),
											new SqlParameter("@ProvinceID",SqlDbType.Char,10),
											new SqlParameter("@CountyID",SqlDbType.Char,10),
											
											new SqlParameter("@IndustryOpportunityID",SqlDbType.Char,10),
											new SqlParameter("@ValidateID",SqlDbType.Char,10),

											new SqlParameter("@Pic1",SqlDbType.VarChar,100),											
											new SqlParameter("@Content",SqlDbType.Text),
											new SqlParameter("@Analysis",SqlDbType.Text),
											new SqlParameter("@Request",SqlDbType.Text),
											new SqlParameter("@Flow",SqlDbType.Text),
											new SqlParameter("@Remark",SqlDbType.Text),											

											new SqlParameter("@ComName",SqlDbType.VarChar, 40),
											new SqlParameter("@LinkMan",SqlDbType.VarChar,20),
											new SqlParameter("@Tel",SqlDbType.VarChar,30),
											new SqlParameter("@Fax",SqlDbType.VarChar,30),
											new SqlParameter("@Mobile",SqlDbType.VarChar,20),
											new SqlParameter("@Address",SqlDbType.VarChar,50),
											new SqlParameter("@PostCode",SqlDbType.VarChar,6),
											new SqlParameter("@Email",SqlDbType.VarChar,40),
											new SqlParameter("@WebSite",SqlDbType.VarChar,40),
	
											// 短内容信息表
											new SqlParameter("@ShortInfoControlID",SqlDbType.Char,20),
											new SqlParameter("@ShortTitle",SqlDbType.VarChar,100),
											new SqlParameter("@ShortContent",SqlDbType.VarChar,100),
											new SqlParameter("@strRemark",SqlDbType.VarChar,50)	
										};

            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[0].Value = mainInfoModel.InfoID;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.publishT;
            parameters[4].Value = mainInfoModel.Hit;

            parameters[5].Value = mainInfoModel.IsCore;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = 0;
            parameters[9].Value = 0;
            parameters[10].Value = 0;
            parameters[11].Value = 0;

            parameters[12].Value = mainInfoModel.LoginName;
            parameters[13].Value = mainInfoModel.InfoOriginRoleName;

            parameters[14].Value = "0";
            parameters[15].Value = "1";
            parameters[16].Value = 2; //付费 0付费,1未付费,2无需付费

            parameters[17].Value = AlterKeyWord(mainInfoModel.KeyWord);
            parameters[18].Value = mainInfoModel.Descript;
            parameters[19].Value = mainInfoModel.DisplayTitle;
            parameters[20].Value = mainInfoModel.FrontDisplayTime;
            parameters[21].Value = mainInfoModel.ValidateStartTime;
            parameters[22].Value = mainInfoModel.ValidateTerm;
            parameters[23].Value = mainInfoModel.TemplateID;
            parameters[24].Value = mainInfoModel.HtmlFile;

            //商机信息
            parameters[25].Value = opportunity.AdTitle;
            parameters[26].Value = opportunity.OpportunityType;

            parameters[27].Value = opportunity.CountryCode;

            if (opportunity.ProvinceID == "")
                parameters[28].Value = System.DBNull.Value;
            else
                parameters[28].Value = opportunity.ProvinceID;

            if (opportunity.CountyID == "")
                parameters[29].Value = System.DBNull.Value;
            else
                parameters[29].Value = opportunity.CountyID;

            parameters[30].Value = opportunity.IndustryOpportunityID;
            parameters[31].Value = opportunity.ValidateID;

            parameters[32].Value = opportunity.Pic1;
            parameters[33].Value = opportunity.Content;
            parameters[34].Value = opportunity.Analysis;
            parameters[35].Value = opportunity.Request;
            parameters[36].Value = opportunity.Flow;
            parameters[37].Value = opportunity.Remark;

            parameters[38].Value = opportunity.ComName;
            parameters[39].Value = opportunity.LinkMan;
            parameters[40].Value = opportunity.Tel;
            parameters[41].Value = opportunity.Fax;
            parameters[42].Value = opportunity.Mobile;
            parameters[43].Value = opportunity.Address;
            parameters[44].Value = opportunity.PostCode;
            parameters[45].Value = opportunity.Email;
            parameters[46].Value = opportunity.WebSite;


            parameters[47].Value = shortInfoModel.ShortInfoControlID;
            parameters[48].Value = shortInfoModel.ShortTitle;
            parameters[49].Value = shortInfoModel.ShortContent;
            parameters[50].Value = shortInfoModel.Remark;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "OpportunityInfoTab_Insert", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    infoID = -1;
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return infoID;
        }

        public static string AlterKeyWord(string KeyWord)
        {
            string[] strKeyword = KeyWord.Trim().Split(' ');
            string strtmpKeyword = "";
            for (int i = 0; i < strKeyword.Length; i++)
            {
                if (strKeyword[i].ToString() != "")
                {
                    strtmpKeyword = strtmpKeyword + strKeyword[i].ToString() + ",";
                }
            }
            if (strtmpKeyword.Trim() != "")
            {
                strtmpKeyword = strtmpKeyword.Substring(0, strtmpKeyword.Length - 1);
            }

            return (strtmpKeyword.Replace(" ", ","));
        }

        /// <summary>
        /// 所属行业
        /// </summary>
        public DataView GetIndustry()
        {
            string sql = "select IndustryOpportunityID,IndustryOpportunityName from SetIndustryOpportunityTab";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 商机类别
        /// </summary>
        public DataView GetOpportun()
        {
            string sql = "select OpportunityTypeID,OpportunityTypeName from SetOpportunityTypeTab";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 信息评定
        /// </summary>
        public DataView GetFixPrice()
        {
            string sql = "select  FixWorthPointID ,FixWorthPointName from SetFixWorthPointTab";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 信息评分
        /// </summary>
        public DataView GetGrade()
        {
            string sql = "select  GradeID,GradeName from SetGradeTab";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }

        #region 修改信息 HasModify
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public long HasModify(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.OpportunityInfoModel opportunity,
           Tz888.Model.Info.ShortInfoModel shortInfoModel,int infodd)
        {
            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@Title",SqlDbType.VarChar,100),											
											new SqlParameter("@publishT",SqlDbType.DateTime),											
											new SqlParameter("@LoginName",SqlDbType.Char,16),

											//2005/12/12  add
											new SqlParameter("@KeyWord",SqlDbType.VarChar,50),
											new SqlParameter("@Descript",SqlDbType.VarChar,100),
											new SqlParameter("@DisplayTitle",SqlDbType.VarChar,50),
											new SqlParameter("@FrontDisplayTime",SqlDbType.DateTime),
											new SqlParameter("@ValidateStartTime",SqlDbType.DateTime),
											new SqlParameter("@ValidateTerm",SqlDbType.Int),
											new SqlParameter("@TemplateID",SqlDbType.Char,10),
											new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),//该字段不需要更新，只有在审核时才更新

											//商机信息
											new SqlParameter("@AdTitle",SqlDbType.VarChar,50),
											new SqlParameter("@OpportunityType",SqlDbType.Char,10),
											new SqlParameter("@CountryCode",SqlDbType.Char,10),
											new SqlParameter("@ProvinceID",SqlDbType.Char,10),
											new SqlParameter("@CountyID",SqlDbType.Char,10),
											
											new SqlParameter("@IndustryOpportunityID",SqlDbType.Char,10),
											new SqlParameter("@ValidateID",SqlDbType.Char,10),

											new SqlParameter("@Pic1",SqlDbType.VarChar,100),											
											new SqlParameter("@Content",SqlDbType.Text),
											new SqlParameter("@Analysis",SqlDbType.Text),
											new SqlParameter("@Request",SqlDbType.Text),
											new SqlParameter("@Flow",SqlDbType.Text),
											new SqlParameter("@Remark",SqlDbType.Text),	

											new SqlParameter("@ComName",SqlDbType.VarChar, 40),
											new SqlParameter("@LinkMan",SqlDbType.VarChar,20),
											new SqlParameter("@Tel",SqlDbType.VarChar,30),
											new SqlParameter("@Fax",SqlDbType.VarChar,30),
											new SqlParameter("@Mobile",SqlDbType.VarChar,20),
											new SqlParameter("@Address",SqlDbType.VarChar,50),
											new SqlParameter("@PostCode",SqlDbType.VarChar,6),
											new SqlParameter("@Email",SqlDbType.VarChar,40),
											new SqlParameter("@WebSite",SqlDbType.VarChar,40),

											// 短内容信息表
											new SqlParameter("@ShortInfoControlID",SqlDbType.Char,20),
											new SqlParameter("@ShortTitle",SqlDbType.VarChar,100),
											new SqlParameter("@ShortContent",SqlDbType.VarChar,100),
											new SqlParameter("@strRemark",SqlDbType.VarChar,50),
										};
            mainInfoModel.InfoID = infodd;
            parameters[0].Value = mainInfoModel.InfoID;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.publishT;
            parameters[3].Value = mainInfoModel.LoginName;

            parameters[4].Value = AlterKeyWord(mainInfoModel.KeyWord);
            parameters[5].Value = mainInfoModel.Descript;
            parameters[6].Value = mainInfoModel.DisplayTitle;
            parameters[7].Value = mainInfoModel.FrontDisplayTime;
            parameters[8].Value = mainInfoModel.ValidateStartTime;
            parameters[9].Value = mainInfoModel.ValidateTerm;
            parameters[10].Value = mainInfoModel.TemplateID;
            parameters[11].Value =  mainInfoModel.HtmlFile;

            //商机信息
            parameters[12].Value = opportunity.AdTitle;
            parameters[13].Value = opportunity.OpportunityType;

            parameters[14].Value = opportunity.CountryCode;

            if (opportunity.ProvinceID == "")
                parameters[15].Value = System.DBNull.Value;
            else
                parameters[15].Value = opportunity.ProvinceID;

            if (opportunity.CountyID== "")
                parameters[16].Value = System.DBNull.Value;
            else
                parameters[16].Value = opportunity.CountyID;

            parameters[17].Value = opportunity.IndustryOpportunityID;
            parameters[18].Value = opportunity.ValidateID;

            parameters[19].Value = opportunity.Pic1;
            parameters[20].Value = opportunity.Content;
            parameters[21].Value = opportunity.Analysis;
            parameters[22].Value = opportunity.Request;
            parameters[23].Value = opportunity.Flow;
            parameters[24].Value = opportunity.Remark;

            parameters[25].Value = opportunity.ComName;
            parameters[26].Value = opportunity.LinkMan;
            parameters[27].Value = opportunity.Tel;
            parameters[28].Value = opportunity.Fax;
            parameters[29].Value = opportunity.Mobile;
            parameters[30].Value = opportunity.Address;
            parameters[31].Value = opportunity.PostCode;
            parameters[32].Value = opportunity.Email;
            parameters[33].Value = opportunity.WebSite;

            parameters[34].Value = shortInfoModel.ShortInfoControlID;
            parameters[35].Value = shortInfoModel.ShortTitle;
            parameters[36].Value = shortInfoModel.ShortContent;
            parameters[37].Value = shortInfoModel.Remark;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "OpportunityInfoTab_Update", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    infoID = -1;
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return infoID;
        }
        /// <summary>
        /// 修改信息评定和评分
        /// </summary>
        public long GradeFixModify(string GradeID, string FixPriceID, int infoId)
        {
            long fix;
            string sql = "update MainInfoTab set GradeID=@GradeID,FixPriceID=@FixPriceID where InfoID=@infoId";
            SqlParameter[] para ={ 
                new SqlParameter("@GradeID",SqlDbType.VarChar,10),
                new SqlParameter("@FixPriceID",SqlDbType.VarChar,10),
                new SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = GradeID;
            para[1].Value = FixPriceID;
            para[2].Value = infoId;
            fix = (long)DbHelperSQL.ExecuteSql(sql, para);
            return fix;
        }
        /// <summary>
        /// 修改状态和模版路径
        /// </summary>
        public long UpdateState(string HtmlFile, int status, int infoId)
        {
            long html;
            string sql = "update MainInfoTab set HtmlFile=@HtmlFile,AuditingStatus=@Status where InfoId=@infoId";
            SqlParameter[] para ={ 
                new SqlParameter("@HtmlFile",SqlDbType.VarChar,200),
                new SqlParameter("@status",SqlDbType.Int,8),
                new SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = HtmlFile;
            para[1].Value = status;
            para[2].Value = infoId;
            html = (long)DbHelperSQL.ExecuteSql(sql, para);
            return html;
        }    
        #endregion
        /// <summary>
        /// 查找主信息表
        /// </summary>
        public MainInfoModel SetMainInfo(int infoId)
        {
            MainInfoModel mainInfo = new MainInfoModel();
            string sql = "select Title,GradeID,FixPriceID ,AuditingStatus,KeyWord,"
                +"Descript,ValidateTerm,DisplayTitle from MainInfoTab where InfoId=@infoId";
            SqlParameter[] para ={ 
               new SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = infoId;
            DataSet ds = DbHelperSQL.Query(sql,para);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    mainInfo.Title = row["Title"].ToString();
                    mainInfo.GradeID = row["GradeID"].ToString();
                    mainInfo.FixPriceID = row["FixPriceID"].ToString();
                    mainInfo.AuditingStatus = Convert.ToInt32(row["AuditingStatus"].ToString());
                    mainInfo.KeyWord = row["KeyWord"].ToString();
                    mainInfo.Descript = row["Descript"].ToString();
                    mainInfo.ValidateTerm = Convert.ToInt32(row["ValidateTerm"].ToString());
                    mainInfo.DisplayTitle = row["DisplayTitle"].ToString();
                }
            }
            return mainInfo;


        }
        /// <summary>
        /// 查找商机信息表
        /// </summary>
        public OpportunityInfoModel SetOpportunity(int infoId)
        {
            OpportunityInfoModel oppor = new OpportunityInfoModel();
            string sql = "select AdTitle,OpportunityType,CountryCode,ProvinceID,CountyID,IndustryOpportunityID,"
                +"ValidateID,[Content],Analysis,Request,Flow,Remark,ComName,LinkMan,Tel,Mobile,Address,PostCode,"
                +"Email,WebSite from OpportunityInfoTab where InfoID=@infoId";
            SqlParameter[] para ={ 
               new SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = infoId;
            DataSet ds = DbHelperSQL.Query(sql, para);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    oppor.AdTitle = row["AdTitle"].ToString();
                    oppor.Address = row["Address"].ToString();
                    oppor.OpportunityType = row["OpportunityType"].ToString();
                    oppor.CountryCode = row["CountryCode"].ToString();
                    oppor.ProvinceID = row["ProvinceID"].ToString();
                    oppor.CountyID = row["CountyID"].ToString();
                    oppor.IndustryOpportunityID = row["IndustryOpportunityID"].ToString();
                    oppor.ValidateID = row["ValidateID"].ToString();
                    oppor.Content = row["Content"].ToString();
                    oppor.Analysis = row["Analysis"].ToString();
                    oppor.Request = row["Request"].ToString();
                    oppor.Flow = row["Flow"].ToString();
                    oppor.Remark = row["Remark"].ToString();
                    oppor.ComName = row["ComName"].ToString();
                    oppor.LinkMan = row["LinkMan"].ToString();
                    oppor.Tel = row["Tel"].ToString();
                    oppor.Mobile = row["Mobile"].ToString();
                    oppor.Address = row["Address"].ToString();
                    oppor.PostCode = row["PostCode"].ToString();
                    oppor.Email = row["Email"].ToString();
                    oppor.WebSite = row["WebSite"].ToString();
                }
            }
            return oppor;
        }
        /// <summary>
        /// 查找短信信息表
        /// </summary>
        public ShortInfoModel SetShortInfo(int infoId)
        {
            ShortInfoModel shortInfo = new ShortInfoModel();
            string sql = "select ShortTitle,ShortContent from ShortInfoTab where InfoID=@infoId";
            SqlParameter[] para ={ 
                new SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = infoId;
            DataSet ds = DbHelperSQL.Query(sql,para);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    shortInfo.ShortContent = row["ShortContent"].ToString();
                    shortInfo.ShortTitle = row["ShortTitle"].ToString();
                }
            }
            return shortInfo;
        }
         /// <summary>
        /// 判断静态页面是否存在
        /// </summary>
        /// <param name="infoId"></param>
        public string PaperExeists(int infoId)
        {
            string name = "";
            string sql = "select HtmlFile from MainInfoTab where InfoID=@infoId";
            SqlParameter[] para ={ 
                new  SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = infoId;
            name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            return name;
        }
        /// <summary>
        /// 删除案例信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public long delete(int infoId)
        {
            long DelInfo;
            long DelCases;
            long DelMain = 0;
            string sql = "";
            sql = "delete from  ShortInfoTab where InfoID=@infoId";
            SqlParameter[] para ={ 
               new SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = infoId;
            DelInfo = (long)DbHelperSQL.ExecuteSql(sql, para);
            if (DelInfo > 0)
            {

                sql = "delete from  OpportunityInfoTab where InfoID=@infoId";
                SqlParameter[] para1 ={ 
                new SqlParameter("@infoId",SqlDbType.Int,8)
                };
                para1[0].Value = infoId;
                DelCases = (long)DbHelperSQL.ExecuteSql(sql, para1);
                if (DelCases > 0)
                {

                    sql = "delete from  MainInfoTab where InfoID=@infoId";
                    SqlParameter[] para2 ={ 
                    new SqlParameter("@infoId",SqlDbType.Int,8)
                    };
                    para2[0].Value = infoId;
                    DelMain = (long)DbHelperSQL.ExecuteSql(sql, para2);
                }
            }
            return DelMain;
        }

    }
}
