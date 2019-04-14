using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.offer;
using Tz888.Model.offer;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.offer
{
   public class CapitalInfoManage
    {
       private readonly ICapitalInfoService dal = DataAccess.CreateInfo_CapitalInfoService();
        /// <summary>
        /// 资讯信息发布
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="News"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
       public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel, CapitalInfoModel CapitalInfoModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            return dal.Insert(mainInfoModel, CapitalInfoModel, shortInfoModel);
        }
        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="CarveOut"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
       public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel, CapitalInfoModel CapitalInfoModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            return dal.Update(mainInfoModel, CapitalInfoModel, shortInfoModel);
        }
       
        /// <summary>
        /// 获取信息
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
        /// <summary>
        /// 删除投资信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public long delete(string infoId)
        {

            return dal.delete(infoId);

        }

    }
}


