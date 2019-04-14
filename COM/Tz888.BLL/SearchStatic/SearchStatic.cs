using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Tz888.BLL.SearchStatic
{

   public class SearchStatic
    {
       Tz888.SQLServerDAL.SearchStatic.SearchStatic stat = new Tz888.SQLServerDAL.SearchStatic.SearchStatic();
        string enlAppPath = ConfigurationManager.AppSettings["enlAppPath"].ToString(); //����ҳ����λ��
        string enFieldTem = ConfigurationManager.AppSettings["enFieldTem"].ToString(); //ģ����λ��

        string capitalAppPath = ConfigurationManager.AppSettings["capitalAppPath"].ToString();//Ͷ��
        string capitalFieldTem = ConfigurationManager.AppSettings["capitalFieldTem"].ToString();

        string govelAppPath = ConfigurationManager.AppSettings["govelAppPath"].ToString();//����
       string goveFieldTem = ConfigurationManager.AppSettings["goveFieldTem"].ToString(); 


        #region ��̬ҳ������
        /// <summary>
        /// ��̬ҳ������
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int StaticHtml(string Field, string num)
        {
            try
            {
                string Tem = "";
                if (num == "1")//����
                {
                    Tem = Compage.Reader(goveFieldTem.ToString()); //��ȡģ������
                }
                else if (num == "2")//����
                {
                    Tem = Compage.Reader(enFieldTem.ToString()); //��ȡģ������
                }
                else if (num == "3")//Ͷ��
                {
                    Tem = Compage.Reader(capitalFieldTem.ToString()); //��ȡģ������
                }
              
                #region �滻ģ��
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$List$", Field);
                #endregion
                string wenjian = "";
                if (num == "1")//����
                {
                     wenjian = govelAppPath;
                }
                else if (num == "2")//����
                {
                     wenjian = enlAppPath;
                }
                else if (num == "3")//Ͷ��
                {
                     wenjian = capitalAppPath;
                }
                
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);
                }
                string htmlpaths = "";
                if (num == "1")//����
                {
                    htmlpaths = wenjian + "government.shtml";
                }
                else if (num == "2")//����
                {
                    htmlpaths = wenjian + "enterprise.shtml";
                }
                else if (num == "3")//Ͷ��
                {
                    htmlpaths = wenjian + "apital.shtml";
                }


                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }
        #region ����������Ŀ
        /// <summary>
        /// ����������Ŀ
        /// </summary>
        /// <returns></returns>
        public string SelProject()
        {
            return stat.SelProject();
        }
        #endregion

        #region ����Ͷ����Ŀ
        /// <summary>
        /// ����������Ŀ
        /// </summary>
        /// <returns></returns>
        public string SelCapital()
        {
            return stat.SelCapital();
        }
        #endregion

        #region ����������Ŀ
        /// <summary>
        /// ����������Ŀ
        /// </summary>
        /// <returns></returns>
        public string SelMerchant()
        {
            return stat.SelMerchant();
        }
        #endregion
        #endregion
 
    }
}
