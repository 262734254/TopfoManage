using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.MerchantManage
{
  public  interface IMerchant
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
           Tz888.Model.MerchantManage.MerchantModel MerchantModel,
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
                    Tz888.Model.MerchantManage.MerchantModel MerchantModel,
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

      
        #region//��ѯ�Ƿ���������¼
        bool SelMerchantInfo(int infoid);
        #endregion

      #region �����ѯ
      /// <summary>
        /// ��ѯ������
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        int CountPage(int areid);

        /// <summary>
        /// �ж��ܹ��ж��ٸ�ҳ����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        int pageS(int areid);

        void SelState(int num, int areid);


      void HtmlPage(int num, string state, string page, int areid, string areList);

        string Page(int num, int areid); 
        #endregion

        #region �������ҵ��ѯ
        /// <summary>
        /// ��ѯ������
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        int InduyCountPage(int areid,string Induy);

        /// <summary>
        /// �ж��ܹ��ж��ٸ�ҳ����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
      int InduypageS(int areid, string Induy);

      void InduySelState(int num, int areid, string Induy);


      void InduyHtmlPage(int num, string state, string page, int areid, string areList, string Induy);

      string InduyPage(int num, int areid, string Induy);
        #endregion

      #region ��ҵ��ѯ
      /// <summary>
      /// ��ѯ������
      /// </summary>
      /// <param name="type"></param>
      /// <returns></returns>
      int InduyCountPageList( string Induy);

      /// <summary>
      /// �ж��ܹ��ж��ٸ�ҳ����
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
