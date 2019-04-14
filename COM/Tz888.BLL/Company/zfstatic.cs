using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using GZS.BLL.XHIndex;
using GZS.Model.Person;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.BLL.Company
{
    public class zfstatic
    {

        //投资拓富首页
        string PersonTem = ConfigurationManager.AppSettings["zfPersonTem"].ToString();
        string PersonSuccess = ConfigurationManager.AppSettings["rzPersonSuccess"].ToString();
        string aboutus = ConfigurationManager.AppSettings["aboutus"].ToString();
        string tzxm = ConfigurationManager.AppSettings["tzxm"].ToString();
        string news = ConfigurationManager.AppSettings["news"].ToString();
        string zyfw = ConfigurationManager.AppSettings["zyfw"].ToString();
        string ywjs = ConfigurationManager.AppSettings["ywjs"].ToString();
        string lxwm = ConfigurationManager.AppSettings["lxwm"].ToString();
        
        


        /// <summary>
        /// 投资生成静态页面
        /// </summary>
        /// <param name="LoginName"></param>
        public void StaticHtml(string LoginName, string Title, string KeyWord, string Descript)
        {

            string PersonTems = PersonTem.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("$UserName$", LoginName.ToString().Trim());

            TempSoure = TempSoure.Replace("$Title$", Title.ToString().Trim());
            TempSoure = TempSoure.Replace("$Description$", KeyWord.ToString().Trim());
            TempSoure = TempSoure.Replace("$KeyWords$", Descript.ToString().Trim());

            string htmlpaths = PersonSuccess + "zf" + LoginName + "\\index.htm";
            if (!Directory.Exists(PersonSuccess + "zf" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "zf" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);
            Company(LoginName);
            fwStaticHtml(LoginName);
            zxhdStaticHtml(LoginName);
            ywjsList(LoginName);
            lxwmList(LoginName);
        }




        /// <summary>
        /// 联系我们
        /// </summary>
        /// <param name="LoginName"></param>
        public void lxwmList(string LoginName)
        {

            string PersonTems = lxwm.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("$UserName$", LoginName.ToString().Trim());
            string htmlpaths = PersonSuccess + "zf" + LoginName + "\\content.htm";
            if (!Directory.Exists(PersonSuccess + "zf" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "zf" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);

        }

        #region 业务介绍
        public int ywjsList(string longinName)
        {



            try
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();
                DataTable dt = GetJobList(longinName);
                if (dt != null && dt.Rows.Count > 0)
                {
                    int Count = dt.Rows.Count;
                    if (dt != null && Count > 0)
                    {
                        sb.Append("<ul>");
                        for (int i = 0; i < Count; i++)
                        {
                            if (i == 0)
                            {
                                sb.Append("<li onclick=\"onClik(this)\" id=\"" + i.ToString() + "\"><a href=\"javascript:void(0)\" class=\"fdsd\">·" + dt.Rows[i]["YwType"].ToString() + "</a></li>");
                                sb1.Append("<div style=\"display:block\" id=\"item" + i.ToString() + "\">" + dt.Rows[i]["Content"].ToString() + "</div>");
                            }
                            else
                            {
                                sb.Append("<li onclick=\"onClik(this)\" id=\"" + i.ToString() + "\"><a href=\"javascript:void(0)\">·" + dt.Rows[i]["YwType"].ToString() + "</a></li>");
                                sb1.Append("<div style=\"display:none\" id=\"item" + i.ToString() + "\">" + dt.Rows[i]["Content"].ToString() + "</div>");
                            }
                        }
                        sb.Append("</ul>");
                    }

                }

                string TempFileName = ywjs.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;

                TempSoure = TempSoure.Replace("$YwJs$", sb.ToString().Trim());
                TempSoure = TempSoure.Replace("$context$", sb1.ToString().Trim());



                string wenjian = PersonSuccess + "zf" + longinName + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = PersonSuccess + "zf" + longinName + "/ywjs.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception)
            {

                throw;
            }




        }



        public DataTable GetJobList(string LogName)
        {
            DataTable dt = null;
            string sql = "select Id,YwType,Content,PublishTime,LoginName FROM Business where LoginName=@LogName";
            SqlParameter[] Paras = new SqlParameter[]
                {
                   new SqlParameter("@LogName",SqlDbType.VarChar,50)
                };
            Paras[0].Value = LogName;
            DataSet ds = GZS.DAL.DBHelper.Query(sql, Paras);
            if (ds != null && ds.Tables.Count > 0)
                dt = ds.Tables[0];
            return dt;
        }
        #endregion

        /// <summary>
        /// 专业服务
        /// </summary>
        /// <param name="LoginName"></param>
        public void fwStaticHtml(string LoginName)
        {

            string PersonTems = zyfw.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("$UserName$", LoginName.ToString().Trim());



            string htmlpaths = PersonSuccess + "zf" + LoginName + "\\zyfw.htm";
            if (!Directory.Exists(PersonSuccess + "zf" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "zf" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);
         

        }



        /// <summary>
        /// 资讯活动
        /// </summary>
        /// <param name="LoginName"></param>
        public void zxhdStaticHtml(string LoginName)
        {

            string PersonTems = news.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("$UserName$", LoginName.ToString().Trim());



            string htmlpaths = PersonSuccess + "zf" + LoginName + "\\news.htm";
            if (!Directory.Exists(PersonSuccess + "zf" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "zf" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);
            TzxmStaticHtml(LoginName);

        }


        /// <summary>
        /// 投资项目
        /// </summary>
        /// <param name="LoginName"></param>
        public void TzxmStaticHtml(string LoginName)
        {

            string PersonTems = tzxm.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("$UserName$", LoginName.ToString().Trim());



            string htmlpaths = PersonSuccess + "zf" + LoginName + "\\tzxm.htm";
            if (!Directory.Exists(PersonSuccess + "zf" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "zf" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);


        }

        #region 企业介绍静态页面

        //企业介绍静态页面
        public void Company(string LoginName)
        {

            string sql = "select * from Company where CompanyToUser=@CompanyToUser";
            string ConnStr = ConfigurationManager.ConnectionStrings["CompanyShow"].ToString();
            SqlConnection con = new SqlConnection(ConnStr);
            SqlCommand com = new SqlCommand(sql, con);
            SqlParameter[] Paras = new SqlParameter[] { 
               new SqlParameter("@CompanyToUser",SqlDbType.VarChar,50)
           };
            Paras[0].Value = LoginName;
            com.Parameters.AddRange(Paras);
            SqlDataAdapter dp = new SqlDataAdapter();
            dp.SelectCommand = com;
            DataTable dt = new DataTable();
            dp.Fill(dt);
            bool IsError = false;
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                Encoding code = Encoding.GetEncoding("gb2312");
                string SavePath = ConfigurationManager.AppSettings["rzPersonSuccess"].ToString() + "zf" + LoginName;
                sr = new StreamReader(@"G:\dp\Template\zl\aboutus.html", code);
                string TempData = sr.ReadToEnd();
                if (dt != null && dt.Rows.Count > 0)
                {
                    TempData = TempData.Replace("$Company$", dt.Rows[0]["Description"].ToString());
                    TempData = TempData.Replace("$UserName$", LoginName.ToString().Trim());

                }
                else
                {
                    TempData = TempData.Replace("$Company$", "暂无数据");
                }
                sw = new StreamWriter(SavePath + "\\qyjj.htm", false, code);
                sw.Write(TempData);
            }
            catch
            {
                IsError = true;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
                if (sw != null)
                    sw.Close();
            }
        }


        #endregion

    }
}
