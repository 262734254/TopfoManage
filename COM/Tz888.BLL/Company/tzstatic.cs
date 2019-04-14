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
    public class tzstatic
    {
        //投资拓富首页
        string PersonTem = ConfigurationManager.AppSettings["tzPersonTem"].ToString();
        string PersonSuccess = ConfigurationManager.AppSettings["rzPersonSuccess"].ToString();

                string tz_aboutus = ConfigurationManager.AppSettings["tz_aboutus"].ToString();

                string tz_contrctus = ConfigurationManager.AppSettings["tz_contrctus"].ToString();

                string tz_news = ConfigurationManager.AppSettings["tz_news"].ToString();

                string tz_sm = ConfigurationManager.AppSettings["tz_sm"].ToString();

                string tz_team = ConfigurationManager.AppSettings["tz_team"].ToString();

                string tzywjs = ConfigurationManager.AppSettings["tzywjs"].ToString();

        




        /// <summary>
        /// 投资生成静态页面
        /// </summary>
        /// <param name="LoginName"></param>
        public void StaticHtml(string LoginName,string Title,string KeyWord,string Descript)
        {

            string PersonTems = PersonTem.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("$UserNmae$", LoginName.ToString().Trim());

            TempSoure = TempSoure.Replace("$Title$", Title.ToString().Trim());
            TempSoure = TempSoure.Replace("$Description$", KeyWord.ToString().Trim());
            TempSoure = TempSoure.Replace("$KeyWords$", Descript.ToString().Trim());

            string htmlpaths = PersonSuccess + "tz" + LoginName + "\\index.htm";
            if (!Directory.Exists(PersonSuccess + "tz" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "tz" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);
            Company(LoginName);
            TzStaticPage(LoginName);
            tzsm(LoginName);

        }



        /// <summary>
        /// 投资项目生成静态页面
        /// </summary>
        /// <param name="LoginName"></param>
        public void tzsm(string LoginName)
        {

            string PersonTems = tz_sm.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("$UserName$", LoginName.ToString().Trim());
            string htmlpaths = PersonSuccess + "tz" + LoginName + "\\tzsm.htm";
            if (!Directory.Exists(PersonSuccess + "tz" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "tz" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);
            ywjs(LoginName);
            tzdt(LoginName);
            lxwm(LoginName);

        }

        /// <summary>
        /// 投资动态
        /// </summary>
        /// <param name="LoginName"></param>
        public void tzdt(string LoginName)
        {

            string PersonTems = tz_news.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("$UserName$", LoginName.ToString().Trim());
            string htmlpaths = PersonSuccess + "tz" + LoginName + "\\news.htm";
            if (!Directory.Exists(PersonSuccess + "tz" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "tz" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);

        }


        /// <summary>
        /// 联系我们
        /// </summary>
        /// <param name="LoginName"></param>
        public void lxwm(string LoginName)
        {

            string PersonTems = tz_contrctus.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("$UserName$", LoginName.ToString().Trim());
            string htmlpaths = PersonSuccess + "tz" + LoginName + "\\contrctus.htm";
            if (!Directory.Exists(PersonSuccess + "tz" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "tz" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);

        }



        #region 业务介绍
        public int ywjs(string longinName)
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

                string TempFileName = tzywjs.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;

                TempSoure = TempSoure.Replace("$YwJs$", sb.ToString().Trim());
                TempSoure = TempSoure.Replace("$context$", sb1.ToString().Trim());



                string wenjian = PersonSuccess + "tz" + longinName + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = PersonSuccess + "tz" + longinName + "/ywjs.htm";
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
                string SavePath = ConfigurationManager.AppSettings["rzPersonSuccess"].ToString() + "tz" + LoginName;
                sr = new StreamReader(@"G:\dp\Template\tz\tz_aboutus.html", code);
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




        #region 团队管理
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,UserName,ImgPic,PublishTime,Description ,Position");
            strSql.Append(" FROM ManagementTeam ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + "order by  Id desc");
            }
            return GZS.DAL.DBHelper.Query(strSql.ToString());
        }
        public int TzStaticPage(string LongName)
        {
            try
            {


                string where = "LoginName='" + LongName + "'";
                StringBuilder sb = new StringBuilder();
                DataSet ds = GetList(where);
                if (ds != null & ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        string Imagepath = row["ImgPic"].ToString().Trim();
                        if (Imagepath == "")
                        {
                            Imagepath = "noneimg.gif";
                        }
                        string Title = row["UserName"].ToString().Trim();
                        string Position = row["Position"].ToString().Trim();

                        string context = row["Description"].ToString().Trim();
                        sb.Append("<div class=\"tz_box_zybox_zjlr_bottom_right_bigk\">");
                        sb.Append("<div class=\"bigk_top\">");
                        sb.Append("<span><strong>" + Position + "  " + Title + "</strong></span>");
                        sb.Append("</div>");
                        sb.Append("<div class=\"bigk_bottom\">");
                        sb.Append("<div class=\"bigk_bottom_left\">");
                        sb.Append("" + context + "");
                        sb.Append("</div>");
                        sb.Append("<div class=\"bigk_bottom_right\"><img src=\"http://dp.topfo.com/tztdglimgs/" + Imagepath + "\" width=\"118\" height=\"132\" /></div>");
                        sb.Append("<div style=\"clear:both\"></div>");
                        sb.Append("</div></div>");
                    }
                }



                string TempFileName = tz_team.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;

                TempSoure = TempSoure.Replace("$UserName$", LongName.ToString().Trim());
                TempSoure = TempSoure.Replace("$context$", sb.ToString().Trim());



                string wenjian = PersonSuccess + "tz" + LongName + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = PersonSuccess + "tz" + LongName + "/gltd.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;

            }
            catch (Exception)
            {
                return 0;

                throw;
            }

        } 
        #endregion

    

    }
}
