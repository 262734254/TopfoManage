using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Carveout;
using Tz888.IDAL.CarveOut;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace Tz888.SQLServerDAL.CarveOut
{
    public class CarveOutInformationDAL:ICarveOutService
    {

        #region  添加创业信息
        /// <summary>
        /// 添加创业信息
        /// </summary>
        /// <param name="mainInfoModel">主信息表</param>
        /// <param name="Carve">创业表</param>
        /// <param name="shortInfoModel">短信息表</param>
        /// <returns></returns>
        public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel, CarveOutInfoTabModel CarveModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
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

											//创业明细											
                                              new SqlParameter("@CarveOutInfoType", SqlDbType.Char,10),
                                            //new SqlParameter("@InfoID", SqlDbType.BigInt,8),
	                                        new SqlParameter("@AdTitle", SqlDbType.VarChar,80),
	                                        new SqlParameter("@CountryCode", SqlDbType.Char,10),
	                                        new SqlParameter("@ProvinceID", SqlDbType.Char,10),
	                                        new SqlParameter("@CountyID", SqlDbType.Char,10),
	                                        new SqlParameter("@IndustryCarveOutID", SqlDbType.Char,10),
	                                        new SqlParameter("@CapitalID", SqlDbType.Char,10),
	                                        new SqlParameter("@InvestObject", SqlDbType.Char,10),
	                                        new SqlParameter("@ValidateID", SqlDbType.Char,10),
	                                        new SqlParameter("@Content", SqlDbType.Text),
	                                        new SqlParameter("@InvestReturn", SqlDbType.Text),
	                                        new SqlParameter("@Pic1", SqlDbType.VarChar,100),
	                                        new SqlParameter("@Remark", SqlDbType.Text),
	                                        new SqlParameter("@ComName", SqlDbType.VarChar,40),
	                                        new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
	                                        new SqlParameter("@Tel", SqlDbType.VarChar,30),
	                                        new SqlParameter("@Fax", SqlDbType.VarChar,30),
	                                        new SqlParameter("@Mobile", SqlDbType.VarChar,20),
	                                        new SqlParameter("@Address", SqlDbType.VarChar,50),
	                                        new SqlParameter("@PostCode", SqlDbType.VarChar,6),
	                                        new SqlParameter("@Email", SqlDbType.VarChar,40),
	                                        new SqlParameter("@WebSite", SqlDbType.VarChar,40),
                                            new SqlParameter("@CityID", SqlDbType.Char,10),
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
            //创业新学年表
            parameters[25].Value = CarveModel.CarveOutInfoType;
            parameters[26].Value = CarveModel.AdTitle;
            parameters[27].Value = CarveModel.CountryCode;

            if (CarveModel.ProvinceID == "")
                parameters[28].Value = System.DBNull.Value;
            else
                parameters[28].Value = CarveModel.ProvinceID;

            if (CarveModel.CountyID == "")
                parameters[29].Value = System.DBNull.Value;
            else
                parameters[29].Value = CarveModel.CountyID;
            parameters[30].Value = CarveModel.IndustryCarveOutID;
            parameters[31].Value = CarveModel.CapitalID;
            parameters[32].Value = CarveModel.InvestObject;
            parameters[33].Value = CarveModel.ValidateID;
            parameters[34].Value = CarveModel.Content;
            parameters[35].Value = CarveModel.InvestReturn;
            parameters[36].Value = CarveModel.Pic1;
            parameters[37].Value = CarveModel.Remark;
            parameters[38].Value = CarveModel.ComName;
            parameters[39].Value = CarveModel.LinkMan;
            parameters[40].Value = CarveModel.Tel;
            parameters[41].Value = CarveModel.Fax;
            parameters[42].Value = CarveModel.Mobile;
            parameters[43].Value = CarveModel.Address;
            parameters[44].Value = CarveModel.PostCode;
            parameters[45].Value = CarveModel.Email;
            parameters[46].Value = CarveModel.WebSite;
            parameters[47].Value = CarveModel.CityID;


            parameters[48].Value = shortInfoModel.ShortInfoControlID;
            parameters[49].Value = shortInfoModel.ShortTitle;
            parameters[50].Value = shortInfoModel.ShortContent;
            parameters[51].Value = shortInfoModel.Remark;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {

                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "CarveOutInfoTab_Insert", parameters, out rowsAffected);
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
        #endregion
        #region 查询创业信息
        /// <summary>
        /// 查询创业信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetNewsList(string SelectStr, string Criteria, string Sort, long Page, long CurrentPageRow, ref long TotalCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.dsGetListNewsTopNums(
                                            "CarveOutViewList",
                                            SelectStr,
                                            Criteria,
                                            Sort,
                                            Page,
                                            CurrentPageRow,
                                            ref TotalCount));
        } 
        #endregion
        #region 修改创业信息
        /// <summary>
        /// 修改创业信息
        /// </summary>
        /// <param name="mainInfoModel">主信息表</param>
        /// <param name="Carve">创业表</param>
        /// <param name="shortInfoModel">短信息表</param>
        /// <returns></returns>
        public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel, CarveOutInfoTabModel CarveModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
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

											//创业明细											
                                              new SqlParameter("@CarveOutInfoType", SqlDbType.Char,10),
                                            //new SqlParameter("@InfoID", SqlDbType.BigInt,8),
	                                        new SqlParameter("@AdTitle", SqlDbType.VarChar,80),
	                                        new SqlParameter("@CountryCode", SqlDbType.Char,10),
	                                        new SqlParameter("@ProvinceID", SqlDbType.Char,10),
	                                        new SqlParameter("@CountyID", SqlDbType.Char,10),
	                                        new SqlParameter("@IndustryCarveOutID", SqlDbType.Char,10),
	                                        new SqlParameter("@CapitalID", SqlDbType.Char,10),
	                                        new SqlParameter("@InvestObject", SqlDbType.Char,10),
	                                        new SqlParameter("@ValidateID", SqlDbType.Char,10),
	                                        new SqlParameter("@Content", SqlDbType.Text),
	                                        new SqlParameter("@InvestReturn", SqlDbType.Text),
	                                        new SqlParameter("@Pic1", SqlDbType.VarChar,100),
	                                        new SqlParameter("@Remark", SqlDbType.Text),
	                                        new SqlParameter("@ComName", SqlDbType.VarChar,40),
	                                        new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
	                                        new SqlParameter("@Tel", SqlDbType.VarChar,30),
	                                        new SqlParameter("@Fax", SqlDbType.VarChar,30),
	                                        new SqlParameter("@Mobile", SqlDbType.VarChar,20),
	                                        new SqlParameter("@Address", SqlDbType.VarChar,50),
	                                        new SqlParameter("@PostCode", SqlDbType.VarChar,6),
	                                        new SqlParameter("@Email", SqlDbType.VarChar,40),
	                                        new SqlParameter("@WebSite", SqlDbType.VarChar,40),
                                            new SqlParameter("@CityID", SqlDbType.Char,10),
											// 短内容信息表
											new SqlParameter("@ShortInfoControlID",SqlDbType.Char,20),
											new SqlParameter("@ShortTitle",SqlDbType.VarChar,100),
											new SqlParameter("@ShortContent",SqlDbType.VarChar,100),
											new SqlParameter("@strRemark",SqlDbType.VarChar,50),
	                                        new SqlParameter("@AuditingStatus",SqlDbType.TinyInt),
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

            parameters[14].Value = mainInfoModel.GradeID;
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
            //创业新学年表
            parameters[25].Value = CarveModel.CarveOutInfoType;
            parameters[26].Value = CarveModel.AdTitle;
            parameters[27].Value = CarveModel.CountryCode;

            if (CarveModel.ProvinceID == "")
                parameters[28].Value = System.DBNull.Value;
            else
                parameters[28].Value = CarveModel.ProvinceID;

            if (CarveModel.CountyID == "")
                parameters[29].Value = System.DBNull.Value;
            else
                parameters[29].Value = CarveModel.CountyID;
            parameters[30].Value = CarveModel.IndustryCarveOutID;
            parameters[31].Value = CarveModel.CapitalID;
            parameters[32].Value = CarveModel.InvestObject;
            parameters[33].Value = CarveModel.ValidateID;
            parameters[34].Value = CarveModel.Content;
            parameters[35].Value = CarveModel.InvestReturn;
            parameters[36].Value = CarveModel.Pic1;
            parameters[37].Value = CarveModel.Remark;
            parameters[38].Value = CarveModel.ComName;
            parameters[39].Value = CarveModel.LinkMan;
            parameters[40].Value = CarveModel.Tel;
            parameters[41].Value = CarveModel.Fax;
            parameters[42].Value = CarveModel.Mobile;
            parameters[43].Value = CarveModel.Address;
            parameters[44].Value = CarveModel.PostCode;
            parameters[45].Value = CarveModel.Email;
            parameters[46].Value = CarveModel.WebSite;
            parameters[47].Value = CarveModel.CityID;


            parameters[48].Value = shortInfoModel.ShortInfoControlID;
            parameters[49].Value = shortInfoModel.ShortTitle;
            parameters[50].Value = shortInfoModel.ShortContent;
            parameters[51].Value = shortInfoModel.Remark;
            parameters[52].Value = mainInfoModel.AuditingStatus;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {

                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "CarveOutShenH_Update", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    infoID = -1;
                    //throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return infoID;
        } 
        #endregion
        #region 删除创业信息
        /// <summary>
        /// 删除创业信息
        /// </summary>
        /// <param name="infoId">Id</param>
        /// <returns></returns>
        public long delete(string infoId)
        {
            long DelInfo;
            long DelCases;
            long DelMain = 0;
            string sql = "";
            sql = "delete from  ShortInfoTab where InfoID = @infoId";
            SqlParameter[] para ={ 
               new SqlParameter("@infoId",SqlDbType.VarChar,10)
            };
            para[0].Value = infoId;
            DelInfo = (long)DbHelperSQL.ExecuteSql(sql, para);
            if (DelInfo > 0)
            {

                sql = "delete from  CarveOutInfoTab where InfoID = @infoId";
                SqlParameter[] para1 ={ 
                new SqlParameter("@infoId",SqlDbType.VarChar,10)
                };
                para1[0].Value = infoId;
                DelCases = (long)DbHelperSQL.ExecuteSql(sql, para1);
                if (DelCases > 0)
                {

                    sql = "delete from  MainInfoTab where  InfoID = @infoId";
                    SqlParameter[] para2 ={ 
                    new SqlParameter("@infoId",SqlDbType.VarChar,10)
                    };
                    para2[0].Value = infoId;
                    DelMain = (long)DbHelperSQL.ExecuteSql(sql, para2);
                }
            }

            return DelMain;

        } 
        #endregion
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
            string sql = "select * from SetIndustryCraveOutTab";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }


      
    }
}
