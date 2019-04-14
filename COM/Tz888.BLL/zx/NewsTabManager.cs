using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.zx;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.zx
{
   public class NewsTabManager
    {
       private readonly INewsTableService dal = DataAccess.CreateInfo_NewsTableService();
        /// <summary>
        /// ��Ѷ��Ϣ����
        /// </summary>
        /// <param name="mainInfoModel"></param>
       /// <param name="News"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
       public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel, Tz888.Model.zx.NewsTabModel News, Tz888.Model.Info.ShortInfoModel shortInfoModel)

        {
            return dal.Insert(mainInfoModel, News, shortInfoModel);
        }
       public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel,Tz888.Model.zx.NewsTabModel News, Tz888.Model.Info.ShortInfoModel shortInfoModel)
       {
           return dal.Update(mainInfoModel, News, shortInfoModel);
       }
        /// <summary>
        /// ��ѯ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet GetOneList(string InfoID)
        {
            string strsql = "select * from NewsTableListView where InfoID=" + InfoID;
            return DBUtility.DbHelperSQL.Query(strsql);
        }
        /// <summary>
        /// ��ȡ��Ѷ��Ϣ
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetNewsList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     out long TotalCount
                                      )
        {
            long lgTotalCount = 0;

            DataSet ds;

            ds = dal.dsGetNewsList(
                               SelectStr,
                               Criteria,
                               Sort,
                               Page,
                               CurrentPageRow,
                               ref lgTotalCount
                               );

            TotalCount = lgTotalCount;
            return (ds);
        }
       public long delete(string infoId)
       {
           
           return dal.delete(infoId);

       }

    }
}
