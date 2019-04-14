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
        string enlAppPath = ConfigurationManager.AppSettings["enlAppPath"].ToString(); //生成页面存放位置
        string enFieldTem = ConfigurationManager.AppSettings["enFieldTem"].ToString(); //模版存放位置

        string capitalAppPath = ConfigurationManager.AppSettings["capitalAppPath"].ToString();//投资
        string capitalFieldTem = ConfigurationManager.AppSettings["capitalFieldTem"].ToString();

        string govelAppPath = ConfigurationManager.AppSettings["govelAppPath"].ToString();//招商
       string goveFieldTem = ConfigurationManager.AppSettings["goveFieldTem"].ToString(); 


        #region 静态页面生成
        /// <summary>
        /// 静态页面生成
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int StaticHtml(string Field, string num)
        {
            try
            {
                string Tem = "";
                if (num == "1")//招商
                {
                    Tem = Compage.Reader(goveFieldTem.ToString()); //读取模板内容
                }
                else if (num == "2")//融资
                {
                    Tem = Compage.Reader(enFieldTem.ToString()); //读取模板内容
                }
                else if (num == "3")//投资
                {
                    Tem = Compage.Reader(capitalFieldTem.ToString()); //读取模板内容
                }
              
                #region 替换模版
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$List$", Field);
                #endregion
                string wenjian = "";
                if (num == "1")//招商
                {
                     wenjian = govelAppPath;
                }
                else if (num == "2")//融资
                {
                     wenjian = enlAppPath;
                }
                else if (num == "3")//投资
                {
                     wenjian = capitalAppPath;
                }
                
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);
                }
                string htmlpaths = "";
                if (num == "1")//招商
                {
                    htmlpaths = wenjian + "government.shtml";
                }
                else if (num == "2")//融资
                {
                    htmlpaths = wenjian + "enterprise.shtml";
                }
                else if (num == "3")//投资
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
        #region 最新融资项目
        /// <summary>
        /// 最新融资项目
        /// </summary>
        /// <returns></returns>
        public string SelProject()
        {
            return stat.SelProject();
        }
        #endregion

        #region 最新投资项目
        /// <summary>
        /// 最新融资项目
        /// </summary>
        /// <returns></returns>
        public string SelCapital()
        {
            return stat.SelCapital();
        }
        #endregion

        #region 最新招商项目
        /// <summary>
        /// 最新融资项目
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
