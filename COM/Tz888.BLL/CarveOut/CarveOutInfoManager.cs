using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.CarveOut;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.CarveOut
{
   public class CarveOutInfoManager
    {
       private readonly ICarveOutService dal = DataAccess.CreateInfo_CarveOutInformation();
       /// <summary>
       /// 资讯信息发布
       /// </summary>
       /// <param name="mainInfoModel"></param>
       /// <param name="News"></param>
       /// <param name="shortInfoModel"></param>
       /// <returns></returns>
       public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel, Tz888.Model.Carveout.CarveOutInfoTabModel CarveOut, Tz888.Model.Info.ShortInfoModel shortInfoModel)
       {
           return dal.Insert(mainInfoModel, CarveOut, shortInfoModel);
       }
       /// <summary>
       /// 更新信息
       /// </summary>
       /// <param name="mainInfoModel"></param>
       /// <param name="CarveOut"></param>
       /// <param name="shortInfoModel"></param>
       /// <returns></returns>
       public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel, Tz888.Model.Carveout.CarveOutInfoTabModel CarveOut, Tz888.Model.Info.ShortInfoModel shortInfoModel)
       {
           return dal.Update(mainInfoModel, CarveOut, shortInfoModel);
       }
       /// <summary>
       /// 查询信息
       /// </summary>
       /// <returns></returns>
       public DataSet GetOneList(string InfoID)
       {
           string strsql = "select * from MenberInfo_ViewCar where InfoID=" + InfoID;
           return DBUtility.DbHelperSQL.Query(strsql);
       }
       /// <summary>
       /// 获取创业信息
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
       /// 删除创业信息
       /// </summary>
       /// <param name="infoId"></param>
       /// <returns></returns>
       public long delete(string infoId)
       {

           return dal.delete(infoId);

       }

    }
}
