using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.COM
{
   public class PageBLL
    {
       PageStatic statedal = new PageStatic();
       public PageBLL()
       { 
       
       }
       public void CreateHtml(int NewsID,string infoID, string DisplayTitle, string MerchantType,
           string CooperationDemandType, string IndustryControl, string ZoneSelectControl, string CapitalTotal,
           string CapitalCurrency, string MerchantTotal, string MerchantCurrency, string PublishT, string ValiditeTerm, string ZoneAbout,
           string EconomicIndicators, string InvestmentEnvironment, string ProjectStatus, string Market, string Benefit, string zfzs,
           string zbzy, string qyxm, string qtzy, string xgzx,
           string CompanyName, string Undertaker, string Name, string Position, string CountryCode, string StateCode,
           string TelNum, string Email, string Address, string Infom)
       {
           statedal.CreateStaticPageHtml(NewsID,infoID,DisplayTitle,MerchantType,CooperationDemandType,IndustryControl,ZoneSelectControl,CapitalTotal,
               CapitalCurrency,MerchantTotal,MerchantCurrency,PublishT,ValiditeTerm, ZoneAbout,EconomicIndicators,InvestmentEnvironment,
               ProjectStatus,Market,Benefit,zfzs,zbzy,qyxm,qtzy,xgzx, CompanyName,Undertaker,Name,Position,CountryCode,StateCode,TelNum,Email,Address,Infom);
       }
       /// <summary>
       /// �ɹ�������̬ҳ����ʾ
       /// </summary>
       /// <param name="NewsID">���</param>
       /// <param name="title">����</param>
       /// <param name="publishT">ʱ��</param>
       /// <param name="Content">��ϸ����</param>
       public void StaticHtml(int NewsID, string title, string publishT, string Content)
       {
           statedal.StaticHtml(NewsID,title,publishT,Content);
       }
        /// <summary>
       /// ����ID��ѯ�ɹ�������Ϣ
       /// </summary>
       public PageStatic cgyl(int infoId)
       {
           return  statedal.cgyl(infoId);
       }

       public string ZFZS(int auId, string TypeId, string proId, string Industry)
       {
           string com = "";
           com = statedal.XShi(auId, TypeId, proId, Industry);
           return com;
       }

       public string huiyuan(long TypeId)
       {
           string com = "";
           com = statedal.QTZY(TypeId);
           return com;
       }

       public string ZXun(int auId, string Industry)
       {
           string com = "";
           com = statedal.XGZX(auId,Industry);
           return com;
       }

    }
}
