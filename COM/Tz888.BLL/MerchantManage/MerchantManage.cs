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
       /// ��Ѷ��Ϣ����
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
       /// ������Ϣ
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
       /// ��ѯ��Ϣ
       /// </summary>
       /// <returns></returns>
       public DataSet GetOneList(string InfoID)
       {
           string strsql = "select * from MerchantManage_View_List where InfoID=" + InfoID;
           return DBUtility.DbHelperSQL.Query(strsql);
       }
       /// <summary>
       /// ��ȡ��ҵ��Ϣ
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
       /// ɾ����ҵ��Ϣ
       /// </summary>
       /// <param name="infoId"></param>
       /// <returns></returns>
       public long delete(string infoId)
       {

           return dal.delete(infoId);

       }
       /// <summary>
       /// ��ѯ�Ƿ���������¼
       /// </summary>
       /// <param name="infoId"></param>
       /// <returns></returns>
        #region//��ѯ�Ƿ���������¼
       public bool SelMerchantInfo(int infoid)
       {
           return dal.SelMerchantInfo(infoid);
       }
        #endregion

       #region �����ѯ
       /// <summary>
       /// ��ѯ������
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public int CountPage(int areid)
       {
           return dal.CountPage(areid);
       }
       /// <summary>
       /// �ж��ܹ��ж��ٸ�ҳ����
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

       #region �������ҵ
       /// <summary>
       /// ��ѯ������
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public int InduyCountPage(int areid,string Induy)
       {
           return dal.InduyCountPage(areid,Induy);
       }
       /// <summary>
       /// �ж��ܹ��ж��ٸ�ҳ����
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

       #region ��ҵ
       /// <summary>
       /// ��ѯ������
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
       public int InduyCountPageList(string Induy)
       {
           return dal.InduyCountPageList(Induy);
       }
       /// <summary>
       /// �ж��ܹ��ж��ٸ�ҳ����
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
