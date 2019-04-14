using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.offer;
using Tz888.IDAL.offer;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace Tz888.SQLServerDAL.offer
{
  public  class CapitalInfoService:ICapitalInfoService
  {

      #region ICapitalInfoService 投资信息数据访问类
      /// <summary>
        /// 插入投资信息
        /// </summary>
        /// <param name="mainInfoModel">主信息表实体类</param>
      /// <param name="MerchantModel">投资信息表实体类</param>
        /// <param name="shortInfoModel">短信息表实体类</param>
        /// <returns></returns>
      public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel, CapitalInfoModel CapitalInfoModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 用视图查询投资信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序</param>
        /// <param name="Page">每页显示多少条</param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount">总数</param>
        /// <returns></returns>
        public DataSet dsGetNewsList(string SelectStr, string Criteria, string Sort, long Page, long CurrentPageRow, ref long TotalCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.dsGetListNewsTopNums(
                                            "CapitalInfoManageList",
                                            SelectStr,
                                            Criteria,
                                            Sort,
                                            Page,
                                            CurrentPageRow,
                                            ref TotalCount));
        }
        /// <summary>
        /// 更新投资信息
        /// </summary>
        /// <param name="mainInfoModel">主信息表实体类</param>
        /// <param name="MerchantModel">投资信息表实体类</param>
        /// <param name="shortInfoModel">短信息表实体类</param>
        /// <returns></returns>
      public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel, CapitalInfoModel CapitalInfoModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 根据ID删除投资信息
        /// </summary>
        /// <param name="infoId">ID</param>
        /// <returns></returns>
        public long delete(string infoId)
        {
            long DelInfo;
            long DelCases;
            long DelMain = 0;
            long delCon;
            long Audit;
            string sql = "";
            sql = "delete from  ShortInfoTab where InfoID = @infoId";
            SqlParameter[] para ={ 
               new SqlParameter("@infoId",SqlDbType.VarChar,10)
            };
            para[0].Value = infoId;
            DelInfo = (long)DbHelperSQL.ExecuteSql(sql, para);
            if (DelInfo >=0)
            {

                long InfoResou;
                sql = "delete from  InfoContactTab where InfoID= @infoId";
                SqlParameter[] para4 ={ 
                    new SqlParameter("@infoId",SqlDbType.VarChar,10)
                    };
                para4[0].Value = infoId;
                delCon = (long)DbHelperSQL.ExecuteSql(sql, para4);

                if (delCon >= 0 || DelInfo >= 0)
                {
                    sql = "delete from  InfoAuditTab where InfoID = @infoId";
                    SqlParameter[] para3 ={ 
                        new SqlParameter("@infoId",SqlDbType.VarChar,10)
                        };
                    para3[0].Value = infoId;
                    Audit = (long)DbHelperSQL.ExecuteSql(sql, para3);
                }
                if (delCon >= 0 || DelInfo >= 0)
                {
                    sql = "delete from  InfoResourceTab where InfoID = @infoId";
                    SqlParameter[] para5 ={ 
                            new SqlParameter("@infoId",SqlDbType.VarChar,10)
                            };
                    para5[0].Value = infoId;
                    InfoResou = (long)DbHelperSQL.ExecuteSql(sql, para5);
                }
                if (DelInfo >= 0 || delCon >= 0)
                {
                    sql = "delete from  CapitalInfoTab where InfoID = @infoId";
                    SqlParameter[] para1 ={ 
                            new SqlParameter("@infoId",SqlDbType.VarChar,10)
                            };
                    para1[0].Value = infoId;
                    DelCases = (long)DbHelperSQL.ExecuteSql(sql, para1);
                }

                if (DelInfo >= 0 || delCon >= 0)
                {
                    sql = "delete from  InfoViewCollectionTab where InfoID = @infoId";
                    SqlParameter[] para1 ={ 
                            new SqlParameter("@infoId",SqlDbType.VarChar,10)
                            };
                    para1[0].Value = infoId;
                  
                    DbHelperSQL.ExecuteSql(sql, para1);
                }

                if (delCon >= 0 || DelInfo >= 0)
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
    }
}
