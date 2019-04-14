using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.MerchantManage;
using Tz888.Model.MerchantManage;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.MerchantManage
{
   public class MerchantManage
   {
       private readonly IMerchant dal = DataAccess.CreateInfo_MarchanInfo();
       /// <summary>
       /// 资讯信息发布
       /// </summary>
       /// <param name="mainInfoModel"></param>
       /// <param name="News"></param>
       /// <param name="shortInfoModel"></param>
       /// <returns></returns>
       public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel, MerchantModel MerchantModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
       {
           return dal.Insert(mainInfoModel, MerchantModel, shortInfoModel);
       }
       /// <summary>
       /// 更新信息
       /// </summary>
       /// <param name="mainInfoModel"></param>
       /// <param name="CarveOut"></param>
       /// <param name="shortInfoModel"></param>
       /// <returns></returns>
       public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel, MerchantModel MerchantModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
       {
           return dal.Update(mainInfoModel, MerchantModel, shortInfoModel);
       }
       /// <summary>
       /// 查询信息
       /// </summary>
       /// <returns></returns>
       public DataSet GetOneList(string InfoID)
       {
           string strsql = "select * from MerchantManage_View_List where InfoID=" + InfoID;
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
       /// <summary>
       /// 查询是否有这条记录
       /// </summary>
       /// <param name="infoId"></param>
       /// <returns></returns>
        #region//查询是否有这条记录
       public bool SelMerchantInfo(int infoid)
       {
           return dal.SelMerchantInfo(infoid);
       }
        #endregion

       #region 区域查询
       /// <summary>
       /// 查询总条数
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public int CountPage(int areid)
       {
           return dal.CountPage(areid);
       }
       /// <summary>
       /// 判断总共有多少个页面数
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public int pageS(int areid)
       {
           return dal.pageS(areid);
       }
       public void SelState(int num, int areid)
       {
           dal.SelState(num, areid);
       }
       
       #endregion

       #region 区域加行业
       /// <summary>
       /// 查询总条数
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public int InduyCountPage(int areid,string Induy)
       {
           return dal.InduyCountPage(areid,Induy);
       }
       /// <summary>
       /// 判断总共有多少个页面数
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public int InduypageS(int areid,string Induy)
       {
           return dal.InduypageS(areid,Induy);
       }
       public void InduySelState(int num, int areid,string Induy)
       {
           dal.InduySelState(num, areid,Induy);
       } 
       #endregion

       #region 行业
       /// <summary>
       /// 查询总条数
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public int InduyCountPageList(string Induy)
       {
           return dal.InduyCountPageList(Induy);
       }
       /// <summary>
       /// 判断总共有多少个页面数
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public int InduypageSList( string Induy)
       {
           return dal.InduypageSList( Induy);
       }
       public void InduySelStateList(int num, string Induy)
       {
           dal.InduySelStateList(num, Induy);
       }
       #endregion

    }
}
