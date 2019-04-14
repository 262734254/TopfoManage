using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Invest;
using GZS.DAL.Invest;
using System.Data;
using System.Configuration;
using System.IO;
using GZS.DAL.product;
namespace GZS.BLL.Invest
{
   public class StaticIF
    {
        string InvestPath = ConfigurationManager.AppSettings["InvestCenSuccse"].ToString(); //�ɹ���������ҳ����λ��
        string InvestTem = ConfigurationManager.AppSettings["InvestCen"].ToString(); //�����ɹ�����ģ����λ��
       /// <summary>
       /// 1,Ͷ�ʳɱ�
       /// 2��԰����ɫ
       /// 3����ҵ����
       /// </summary>
       /// <param name="loginName"></param>
       /// <param name="num"></param>
       /// <returns></returns>
       public int StaticHtml(string loginName,int num)
       {
           try
           {
               string TempFileName = InvestTem.ToString();
               string Tem = Compage.Reader(TempFileName); //��ȡģ������
               string TempSoure = Tem;
               CommStatic comm = new CommStatic();
               string str = "";
               string htmlFile = "";
               if (num==1)
               {
                   str = comm.GetInvestListUIByLoginName(loginName);
                   htmlFile = "InvestIF.htm";
               }
               else if (num==2)
               {
                   str = comm.GetParkListUIByLoginName(loginName);
                   htmlFile = "ParkIF.htm";
               }
               else if (num==3)
               {
                   str = comm.GetListUIByloginName(loginName);
                   htmlFile = "ProductIF.htm";
               }
               TempSoure = TempSoure.Replace("$content$", str);
             
               string wenjian = InvestPath + loginName;
               if (!Directory.Exists(wenjian))
               {
                   Directory.CreateDirectory(wenjian);
               }
               string htmlpaths = wenjian + "/" + htmlFile;
               Compage.Writer(htmlpaths, TempSoure);
               return 1;
           }

           catch (Exception e)
           {
               return 0;
           }

       }
    }
}
