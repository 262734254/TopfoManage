using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using System.IO;

namespace Tz888.SQLServerDAL
{
    public class CaseInfoTabDAL:Tz888.IDAL.ICasesInfoTab
    {
        #region ICasesInfoTab 成员
        /// <summary>
        /// 添加案例信息
        /// </summary>
        /// <param name="mainInfoModel">主表</param>
        /// <param name="casesInfoModel">案例表</param>
        /// <param name="shortInfoModel">短信表</param>
        /// <param name="infoResourceModels">图片</param>
        /// <returns></returns>
        public long insert(Tz888.Model.Info.MainInfoModel mainInfoModel, 
            Tz888.Model.CasesInfoTab casesInfoModel, 
            Tz888.Model.Info.ShortInfoModel shortInfoModel, 
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@InfoID",SqlDbType.BigInt),
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

			    //案例明细
			    new SqlParameter("@CasesTypeID",SqlDbType.Char, 10),
			    new SqlParameter("@Content",SqlDbType.Text),
			    new SqlParameter("@Pic1",SqlDbType.VarChar,100),
			    new SqlParameter("@Pic2",SqlDbType.VarChar,100),

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
            parameters[6].Value = mainInfoModel.IndexOrderNum; 
            parameters[7].Value = mainInfoModel.IndexTopValidateDate;
            parameters[8].Value = mainInfoModel.IndexPicInfoNum; 
            parameters[9].Value = mainInfoModel.InfoTypeOrderNum; 
            parameters[10].Value = mainInfoModel.InfoTypeTopValidateDate;
            parameters[11].Value = mainInfoModel.InfoTypePicInfoNum;

            parameters[12].Value = mainInfoModel.LoginName; 
            parameters[13].Value = mainInfoModel.InfoOriginRoleName;

            parameters[14].Value = mainInfoModel.GradeID;
            parameters[15].Value = mainInfoModel.FixPriceID; 
            parameters[16].Value = mainInfoModel.FeeStatus;

            parameters[17].Value = AlterKeyWord(mainInfoModel.KeyWord);
            parameters[18].Value = mainInfoModel.Descript; 
            parameters[19].Value = mainInfoModel.DisplayTitle; 
            parameters[20].Value = mainInfoModel.FrontDisplayTime; 
            parameters[21].Value = mainInfoModel.ValidateStartTime; 
            parameters[22].Value = mainInfoModel.ValidateTerm; 
            parameters[23].Value = mainInfoModel.TemplateID;
            parameters[24].Value = mainInfoModel.HtmlFile;

            parameters[25].Value = casesInfoModel.CasesTypeID; 
            parameters[26].Value = casesInfoModel.Content; 
            parameters[27].Value = "";
            parameters[28].Value = "";


            parameters[29].Value = shortInfoModel.ShortInfoControlID;
            parameters[30].Value = shortInfoModel.ShortTitle;
            parameters[31].Value = shortInfoModel.ShortContent;
            parameters[32].Value = shortInfoModel.Remark;
            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "CasesInfoTab_Insert", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();


                    //将上传文件
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //记录上传数
                        //为投资信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, model, 1))
                                iUploadCount += 1;
                        }
                        //没有成功
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            return 0;
                        }
                    }


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
        /// 修改案例信息
        /// </summary>
        /// <param name="mainInfoModel">主表</param>
        /// <param name="casesInfoModel">案例表</param>
        /// <param name="shortInfoModel">短信表</param>
        /// <param name="infoResourceModels">图片</param>
        /// <returns></returns>
        public long update(Tz888.Model.Info.MainInfoModel mainInfoModel, 
            Tz888.Model.CasesInfoTab casesInfoModel, 
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels,int infodd)
        {
            SqlParameter[] parameters = {	
                new SqlParameter("@InfoID",SqlDbType.BigInt),
			    new SqlParameter("@Title",SqlDbType.VarChar,100),											
			    new SqlParameter("@publishT",SqlDbType.DateTime),
			    new SqlParameter("@Hit",SqlDbType.BigInt),
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


			    //案例明细
			    new SqlParameter("@CasesTypeID",SqlDbType.Char, 10),
			    new SqlParameter("@Content",SqlDbType.Text),
			    new SqlParameter("@Pic1",SqlDbType.VarChar,100),
			    new SqlParameter("@Pic2",SqlDbType.VarChar,100),

			    // 短内容信息表
			    new SqlParameter("@ShortInfoControlID",SqlDbType.Char,20),
			    new SqlParameter("@ShortTitle",SqlDbType.VarChar,100),
			    new SqlParameter("@ShortContent",SqlDbType.VarChar,100),
			    new SqlParameter("@strRemark",SqlDbType.VarChar,50)

			};
            mainInfoModel.InfoID = infodd;
            parameters[0].Value = mainInfoModel.InfoID; 
            parameters[1].Value = mainInfoModel.Title; 
            parameters[2].Value = mainInfoModel.publishT; 
            parameters[3].Value = mainInfoModel.Hit; 
            parameters[4].Value = mainInfoModel.LoginName; 

            parameters[5].Value = AlterKeyWord(mainInfoModel.KeyWord);
            parameters[6].Value = mainInfoModel.Descript;
            parameters[7].Value = mainInfoModel.DisplayTitle; 
            parameters[8].Value = mainInfoModel.FrontDisplayTime; 
            parameters[9].Value = mainInfoModel.ValidateStartTime; 
            parameters[10].Value = mainInfoModel.ValidateTerm; 
            parameters[11].Value = mainInfoModel.TemplateID; 
            parameters[12].Value = mainInfoModel.HtmlFile; 

            parameters[13].Value = casesInfoModel.CasesTypeID; 
            parameters[14].Value = casesInfoModel.Content; 
            parameters[15].Value = ""; 
            parameters[16].Value = ""; 

            parameters[17].Value = shortInfoModel.ShortInfoControlID;
            parameters[18].Value = shortInfoModel.ShortTitle;
            parameters[19].Value = shortInfoModel.ShortContent;
            parameters[20].Value = shortInfoModel.Remark;
            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "CasesInfoTab_Update", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    //将上传文件
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //记录上传数
                        //为投资信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, model, 1))
                                iUploadCount += 1;
                        }
                        //没有成功
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            return 0;
                        }
                    }
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

                sql = "delete from  CasesInfoTab where InfoID=@infoId";
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
        /// <summary>
        /// 查找案例名称
        /// </summary>
        /// <returns></returns>
        public DataView setCases()
        {
            string sql = "select CasesTypeID,CasesTypeName  from SetCasesTab";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 查主表信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public Tz888.Model.Info.MainInfoModel selMainInfo(int infoId)
        {
            Tz888.Model.Info.MainInfoModel MainInfo = new Tz888.Model.Info.MainInfoModel();
            string sql = "select Title,IsCore,Hit,AuditingStatus,KeyWord,Descript,DisplayTitle,ValidateTerm from MainInfoTab where InfoID=@infoId";
            SqlParameter[] para ={ 
                new SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = infoId;
            DataSet ds = DbHelperSQL.Query(sql, para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                MainInfo.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                MainInfo.Hit = Convert.ToInt32(ds.Tables[0].Rows[0]["Hit"].ToString());
                MainInfo.AuditingStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["AuditingStatus"].ToString());
                MainInfo.KeyWord = ds.Tables[0].Rows[0]["KeyWord"].ToString();
                MainInfo.IsCore = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsCore"].ToString());
                MainInfo.Descript = ds.Tables[0].Rows[0]["Descript"].ToString();
                MainInfo.DisplayTitle = ds.Tables[0].Rows[0]["DisplayTitle"].ToString();
                MainInfo.ValidateTerm =Convert.ToInt32(ds.Tables[0].Rows[0]["ValidateTerm"].ToString());

            }
            return MainInfo;
        }
        /// <summary>
        /// 查短信表信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ShortInfoModel selShortInfo(int infoId)
        {
            Tz888.Model.Info.ShortInfoModel shortInfo = new Tz888.Model.Info.ShortInfoModel();
            string sql = "select ShortTitle,ShortContent from ShortInfoTab where InfoID=@infoId";
            SqlParameter[] para ={ 
                new SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = infoId;
            DataSet ds = DbHelperSQL.Query(sql, para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                shortInfo.ShortTitle = ds.Tables[0].Rows[0]["ShortTitle"].ToString();
                shortInfo.ShortContent = ds.Tables[0].Rows[0]["ShortContent"].ToString();
            }
            return shortInfo;

        }
        /// <summary>
        /// 查案例信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public Tz888.Model.CasesInfoTab selcaseInfo(int infoId)
        {
            Tz888.Model.CasesInfoTab casesInfo = new Tz888.Model.CasesInfoTab();
            string sql = "select CasesTypeID,[Content] from CasesInfoTab where InfoID=@infoId";
            SqlParameter[] para ={ 
                new SqlParameter("@infoId",SqlDbType.Int,8)
            };
            para[0].Value = infoId;
            DataSet ds = DbHelperSQL.Query(sql, para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                casesInfo.CasesTypeID = ds.Tables[0].Rows[0]["CasesTypeID"].ToString();
                casesInfo.Content = ds.Tables[0].Rows[0]["Content"].ToString();
            }
            return casesInfo;
        }
        
        /// <summary>
        /// 查信息资源
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public List<Tz888.Model.Info.InfoResourceModel> selInfoResource(int infoId)
        {
            List<Tz888.Model.Info.InfoResourceModel> infoRes = new List<Tz888.Model.Info.InfoResourceModel>();
            Tz888.SQLServerDAL.Info.InfoResourceDAL obj5 = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
            infoRes = obj5.GetModelList(infoId);
            return infoRes;
        }
        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public long UpdateStatus(int infoId, string htmlFile,int status)
        {
            long auditing;
            string sql = "update MainInfoTab set AuditingStatus=@status,HtmlFile=@htmlFile where InfoID=@infoId";
            SqlParameter[] para ={ 
                new SqlParameter("@infoId",SqlDbType.Int,4),
                new SqlParameter("@htmlFile",SqlDbType.VarChar,200),
                new SqlParameter("@status",SqlDbType.Int,4)
            };
            para[0].Value = infoId;
            para[1].Value = htmlFile;
            para[2].Value = status;
            auditing = (long)DbHelperSQL.ExecuteSql(sql, para);
            return auditing;
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
    }
}
