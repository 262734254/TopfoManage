using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL.zx
{
    public interface INewsTableService
    {
        #region ��Ѷ��Ϣ����
        /// <summary>
        /// ��Ѷ��Ϣ����
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="News"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.zx.NewsTabModel News,
           Tz888.Model.Info.ShortInfoModel shortInfoModel); 
        #endregion
        #region ��Ѷ��Ϣ
        /// <summary>
        /// ��Ѷ��Ϣ
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
        #region ��Ϣ�޸�
        /// <summary>
        /// ��Ϣ�޸�
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="News"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        long Update(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.zx.NewsTabModel News,
           Tz888.Model.Info.ShortInfoModel shortInfoModel); 
        #endregion

        #region ɾ����Ϣ
        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        long delete(string infoId); 
        #endregion
    }
}
