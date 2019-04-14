using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL.zx
{
    public interface INewsTableService
    {
        #region 资讯信息发布
        /// <summary>
        /// 资讯信息发布
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="News"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.zx.NewsTabModel News,
           Tz888.Model.Info.ShortInfoModel shortInfoModel); 
        #endregion
        #region 资讯信息
        /// <summary>
        /// 资讯信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        DataSet dsGetNewsList(
                                 string SelectStr,
                                  string Criteria,
                                  string Sort,
                                  long Page,
                                  long CurrentPageRow,
                                  ref long TotalCount

                                 ); 
        #endregion
        #region 信息修改
        /// <summary>
        /// 信息修改
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="News"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        long Update(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.zx.NewsTabModel News,
           Tz888.Model.Info.ShortInfoModel shortInfoModel); 
        #endregion

        #region 删除信息
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        long delete(string infoId); 
        #endregion
    }
}
