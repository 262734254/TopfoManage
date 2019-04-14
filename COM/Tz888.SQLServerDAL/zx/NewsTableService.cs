using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.zx;
using Tz888.IDAL.zx;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace Tz888.SQLServerDAL.zx
{
    public class NewsTableService : INewsTableService
    {
        #region 添加资讯信息

        public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel, NewsTabModel News, Tz888.Model.Info.ShortInfoModel shortInfoModel)
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
                                             //新闻明细
                                            //new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                        new SqlParameter("@NewsTypeID", SqlDbType.Char,10),
					                        new SqlParameter("@subTitle", SqlDbType.VarChar,100),
					                        new SqlParameter("@NewsLblStatus", SqlDbType.Char,10),
					                        new SqlParameter("@AreaID", SqlDbType.Char,10),
					                        new SqlParameter("@NewsIndustryID", SqlDbType.Char,10),
					                        new SqlParameter("@Origin", SqlDbType.VarChar,100),
					                        new SqlParameter("@Author", SqlDbType.VarChar,20),
                                            //new SqlParameter("@Keyword", SqlDbType.VarChar,50),
					                        new SqlParameter("@RedirectUrl", SqlDbType.VarChar,100),
					                        new SqlParameter("@IsRedirect", SqlDbType.Bit,1),
					                        new SqlParameter("@Summary", SqlDbType.Text),
					                        new SqlParameter("@Content", SqlDbType.Text),
					                        new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					                        new SqlParameter("@PicAbout", SqlDbType.VarChar,60),
					                        new SqlParameter("@PageStatus", SqlDbType.Int,4),
					                        new SqlParameter("@PageCharCount", SqlDbType.BigInt,8),
                                            new SqlParameter("@ResearchSpot", SqlDbType.Char,10),
                                            //new SqlParameter("@ProvinceID", SqlDbType.Char,10),
                                            //new SqlParameter("@CityID", SqlDbType.Char,10),
                                            //new SqlParameter("@CountyID", SqlDbType.Char,10),
                                            //new SqlParameter("@activeAdress", SqlDbType.VarChar,100),
                                            //new SqlParameter("@activeDateFrom", SqlDbType.VarChar,30),
                                            //new SqlParameter("@activeDateTo", SqlDbType.VarChar,30),
                                            //new SqlParameter("@mainUnit", SqlDbType.VarChar,100),
                                            //new SqlParameter("@secondUnit", SqlDbType.VarChar,100),
                                            //new SqlParameter("@AuditingRemark", SqlDbType.VarChar,100),

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
            //新闻信息
            parameters[25].Value = News.NewsTypeID;
            parameters[26].Value = News.subTitle;
            parameters[27].Value = News.NewsLblStatus;
            parameters[28].Value = News.AreaID;
            parameters[29].Value = News.NewsIndustryID;
            parameters[30].Value = News.Origin;
            parameters[31].Value = News.Author;
            //parameters[32].Value = AlterKeyWord(mainInfoModel.KeyWord);
            parameters[33].Value = News.RedirectUrl;
            parameters[33].Value = News.IsRedirect;
            parameters[34].Value = News.Summary;
            parameters[35].Value = News.Content;
            parameters[36].Value = News.Pic1;
            parameters[37].Value = News.PicAbout;
            parameters[38].Value = News.PageStatus;
            parameters[39].Value = News.PageCharCount;
            parameters[40].Value = News.ResearchSpot;
            //parameters[42].Value = News.ProvinceID;
            //parameters[43].Value = News.CityID;
            //parameters[44].Value = News.CountyID;
            //parameters[45].Value = News.activeAdress;
            //parameters[46].Value = News.activeDateFrom;
            //parameters[47].Value = News.activeDateTo;
            //parameters[48].Value = News.mainUnit;
            //parameters[49].Value = News.secondUnit;
            //parameters[50].Value = News.AuditingRemark;


            parameters[41].Value = shortInfoModel.ShortInfoControlID;
            parameters[42].Value = shortInfoModel.ShortTitle;
            parameters[43].Value = shortInfoModel.ShortContent;
            parameters[44].Value = shortInfoModel.Remark;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {

                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "NewsTab_Insert", parameters, out rowsAffected);
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



        #region 查询资讯信息


        public DataSet dsGetNewsList(string SelectStr, string Criteria, string Sort, long Page, long CurrentPageRow, ref long TotalCount)
        {

            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.dsGetListNewsTopNums(
                                            "NewsTabViewList",
                                            SelectStr,
                                            Criteria,
                                            Sort,
                                            Page,
                                            CurrentPageRow,
                                            ref TotalCount));
        }


        #endregion

        #region 删除SQL语句


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

                sql = "delete from  newstab where InfoID = @infoId";
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

        #region 修改资讯信息


        public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel, NewsTabModel News, Tz888.Model.Info.ShortInfoModel shortInfoModel)
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
                                             //新闻明细
                                            //new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                        new SqlParameter("@NewsTypeID", SqlDbType.Char,10),
					                        new SqlParameter("@subTitle", SqlDbType.VarChar,100),
					                        new SqlParameter("@NewsLblStatus", SqlDbType.Char,10),
					                        new SqlParameter("@AreaID", SqlDbType.Char,10),
					                        new SqlParameter("@NewsIndustryID", SqlDbType.Char,10),
					                        new SqlParameter("@Origin", SqlDbType.VarChar,100),
					                        new SqlParameter("@Author", SqlDbType.VarChar,20),
                                            //new SqlParameter("@Keyword", SqlDbType.VarChar,50),
					                        new SqlParameter("@RedirectUrl", SqlDbType.VarChar,100),
					                        new SqlParameter("@IsRedirect", SqlDbType.Bit,1),
					                        new SqlParameter("@Summary", SqlDbType.Text),
					                        new SqlParameter("@Content", SqlDbType.Text),
					                        new SqlParameter("@Pic1", SqlDbType.VarChar,100),
					                        new SqlParameter("@PicAbout", SqlDbType.VarChar,60),
					                        new SqlParameter("@PageStatus", SqlDbType.Int,4),
					                        new SqlParameter("@PageCharCount", SqlDbType.BigInt,8),
                                            new SqlParameter("@ResearchSpot", SqlDbType.Char,10),
                                            //new SqlParameter("@ProvinceID", SqlDbType.Char,10),
                                            //new SqlParameter("@CityID", SqlDbType.Char,10),
                                            //new SqlParameter("@CountyID", SqlDbType.Char,10),
                                            //new SqlParameter("@activeAdress", SqlDbType.VarChar,100),
                                            //new SqlParameter("@activeDateFrom", SqlDbType.VarChar,30),
                                            //new SqlParameter("@activeDateTo", SqlDbType.VarChar,30),
                                            //new SqlParameter("@mainUnit", SqlDbType.VarChar,100),
                                            //new SqlParameter("@secondUnit", SqlDbType.VarChar,100),
                                            //new SqlParameter("@AuditingRemark", SqlDbType.VarChar,100),

											// 短内容信息表
											new SqlParameter("@ShortInfoControlID",SqlDbType.Char,20),
											new SqlParameter("@ShortTitle",SqlDbType.VarChar,100),
											new SqlParameter("@ShortContent",SqlDbType.VarChar,100),
											new SqlParameter("@strRemark",SqlDbType.VarChar,50),
	                                         new SqlParameter("@AuditingStatus",SqlDbType.VarChar,50),	
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
            //parameters[15].Value = "1";
            //parameters[16].Value = 2; //付费 0付费,1未付费,2无需付费
            parameters[15].Value =mainInfoModel.GradeID;
            parameters[16].Value = mainInfoModel.FixPriceID; //付费 0付费,1未付费,2无需付费

            parameters[17].Value = AlterKeyWord(mainInfoModel.KeyWord);
            parameters[18].Value = mainInfoModel.Descript;
            parameters[19].Value = mainInfoModel.DisplayTitle;
            parameters[20].Value = mainInfoModel.FrontDisplayTime;
            parameters[21].Value = mainInfoModel.ValidateStartTime;
            parameters[22].Value = mainInfoModel.ValidateTerm;
            parameters[23].Value = mainInfoModel.TemplateID;
            parameters[24].Value = mainInfoModel.HtmlFile;
            //新闻信息
            parameters[25].Value = News.NewsTypeID;
            parameters[26].Value = News.subTitle;
            parameters[27].Value = News.NewsLblStatus;
            parameters[28].Value = News.AreaID;
            parameters[29].Value = News.NewsIndustryID;
            parameters[30].Value = News.Origin;
            parameters[31].Value = News.Author;
            //parameters[32].Value = AlterKeyWord(mainInfoModel.KeyWord);
            parameters[33].Value = News.RedirectUrl;
            parameters[33].Value = News.IsRedirect;
            parameters[34].Value = News.Summary;
            parameters[35].Value = News.Content;
            parameters[36].Value = News.Pic1;
            parameters[37].Value = News.PicAbout;
            parameters[38].Value = News.PageStatus;
            parameters[39].Value = News.PageCharCount;
            parameters[40].Value = News.ResearchSpot;
            //parameters[42].Value = News.ProvinceID;
            //parameters[43].Value = News.CityID;
            //parameters[44].Value = News.CountyID;
            //parameters[45].Value = News.activeAdress;
            //parameters[46].Value = News.activeDateFrom;
            //parameters[47].Value = News.activeDateTo;
            //parameters[48].Value = News.mainUnit;
            //parameters[49].Value = News.secondUnit;
            //parameters[50].Value = News.AuditingRemark;


            parameters[41].Value = shortInfoModel.ShortInfoControlID;
            parameters[42].Value = shortInfoModel.ShortTitle;
            parameters[43].Value = shortInfoModel.ShortContent;
            parameters[44].Value = shortInfoModel.Remark;
            parameters[45].Value = mainInfoModel.AuditingStatus;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {

                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "NewsTab_Update", parameters, out rowsAffected);
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
    }
   
}
