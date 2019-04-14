using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.MerchantManage
{
  public  interface IMerchant
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
           Tz888.Model.MerchantManage.MerchantModel MerchantModel,
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
                    Tz888.Model.MerchantManage.MerchantModel MerchantModel,
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

      
        #region//查询是否有这条记录
        bool SelMerchantInfo(int infoid);
        #endregion

      #region 区域查询
      /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        int CountPage(int areid);

        /// <summary>
        /// 判断总共有多少个页面数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        int pageS(int areid);

        void SelState(int num, int areid);


      void HtmlPage(int num, string state, string page, int areid, string areList);

        string Page(int num, int areid); 
        #endregion

        #region 区域加行业查询
        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        int InduyCountPage(int areid,string Induy);

        /// <summary>
        /// 判断总共有多少个页面数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
      int InduypageS(int areid, string Induy);

      void InduySelState(int num, int areid, string Induy);


      void InduyHtmlPage(int num, string state, string page, int areid, string areList, string Induy);

      string InduyPage(int num, int areid, string Induy);
        #endregion

      #region 行业查询
      /// <summary>
      /// 查询总条数
      /// </summary>
      /// <param name="type"></param>
      /// <returns></returns>
      int InduyCountPageList( string Induy);

      /// <summary>
      /// 判断总共有多少个页面数
      /// </summary>
      /// <param name="type"></param>
      /// <returns></returns>
      int InduypageSList( string Induy);

      void InduySelStateList(int num,  string Induy);


      void InduyHtmlPageList(int num, string state, string page, string Induy);

      string InduyPageList(int num,  string Induy);
      #endregion
    }
}
