using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using GZS.Model;
using System.Configuration;
using GZS.DAL.Menu;

namespace GZS.DAL
{
    public class EnvironmentTabDAL
    {
        GZS.DAL.VideoSysDAL videosysdal = new VideoSysDAL();
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["DKNewsSuccsePath"].ToString(); //成功案例生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["DKEnvironmentTest"].ToString(); //其他成功案例模版存放位置
        string CasesTems = ConfigurationManager.AppSettings["DKEnvironmentshouye"].ToString(); //其他成功案例模版存放位置
        string merchantimage = ConfigurationManager.AppSettings["Upimagecn001"].ToString();
        /// <summary>
        ///创建投资环境静态页面
        /// </summary>
        public int StaticHtml(string loginname)
        {

            try
            {
                string ids = "";
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                string TempSoure = Tem;
                GZS.DAL.EnvironmentTypeDAL typedal = new EnvironmentTypeDAL();
                GZS.DAL.EnvironmentImgDAL Imgdal = new EnvironmentImgDAL();
                List<GZS.Model.EnvironmentTypeM> list = typedal.GetAllType();
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < list.Count; i++)
                {
                    GZS.Model.EnvironmentTabM envtab = EnvironmentlistByLoginNameandTypeid(loginname, list[i].EnvironmentTypeID);
                    string zhongwen = "";
                    string english = "";
                    string txt1 = "";
                    string txt2 = "";
                    string txt3 = "";
                    string txt4 = "";
                    string txts1 = "";
                    string txts2 = "";
                    string txts3 = "";
                    string txts4 = "";
                    if (envtab != null)
                    {
                        zhongwen = envtab.Chineseintroduced.Trim();
                        english = envtab.Englishintroduction.Trim();
                        List<GZS.Model.EnvironmentImgM> lists = Imgdal.GetAllByEnvironmentTabId(envtab.Environmentid);
                        for (int t = 0; t < lists.Count; t++)
                        {
                            if (t == 0)
                            {
                                txt1 = lists[t].imgpath;
                                txts1 = lists[t].imgexplain;
                            }
                            if (t == 1)
                            {
                                txt2 = lists[t].imgpath;
                                txts2 = lists[t].imgexplain;
                            }
                            if (t == 2)
                            {
                                txt3 = lists[t].imgpath;
                                txts3 = lists[t].imgexplain;
                            }
                            if (t == 3)
                            {
                                txt4 = lists[t].imgpath;
                                txts4 = lists[t].imgexplain;
                            }
                        }
                    }
                    if (i == 0)
                    {
                        str.Append("<div  id=\"gk_con_" + (10 + i) + "\" style =\"display:block\">");
                        ids += 10 + i + ",";
                    }
                    else { ids += 10 + i + ","; str.Append("<div  id=\"gk_con_" + (10 + i) + "\" style =\"display:none\">"); }
                    str.Append("<div class=\"envuroment-right1\">" + zhongwen + "</div>");
                    str.Append("<div class=\"envuroment-right1\">" + english + "</div>");
                    str.Append("<div class=\"envuroment-right2\">");
                    str.Append("<div class=\"industry-img-left001\"><ul>");
                    if (txt1.Trim() != "")
                    {
                        str.Append("<li class=\"l\">");
                        str.Append("<a href=\"http://dp.topfo.com/img/" + loginname + "/" + txt1 + "\" alt='点击查看大图' target=\"_blank\">");
                        str.Append("<img alt='点击查看大图' src=\"http://dp.topfo.com/img/" + loginname + "/" + txt1 + "\" />");
                        str.Append("<p style=\"text-align:center;\">" + txts1 + "</p>");
                        str.Append("</li>");
                    }
                    else
                    {
                        //str.Append("<li class=\"l\">");
                    }

                    if (txt2.Trim() != "")
                    {
                        str.Append("<li class=\"r\">");
                        str.Append("<a href=\"http://dp.topfo.com/img/" + loginname + "/" + txt2 + "\" alt='点击查看大图' target=\"_blank\">");
                        str.Append("<img src=\"http://dp.topfo.com/img/" + loginname + "/" + txt2 + "\" alt='点击查看大图'/>");
                        str.Append("<p style=\"text-align:center;\">" + txts2 + "</p>");
                        str.Append("</li>");
                    }
                    else
                    {
                        // str.Append("<li class=\"r\">");
                    }
                    str.Append("</ul>");
                    str.Append("</div></div>");
                    if (txt3.Trim() != "")
                    {
                        str.Append("<div class=\"envuroment-right3\"><div class=\"industry-img-left001\">");
                        str.Append("<a href=\"http://dp.topfo.com/img/" + loginname + "/" + txt3 + "\" alt='点击查看大图' target=\"_blank\">");
                        str.Append("<img src=\"http://dp.topfo.com/img/" + loginname + "/" + txt3 + "\" alt='点击查看大图'/>");
                        str.Append("<p style=\"text-align:center;\">" + txts3 + "</p>");
                        str.Append("</div>");

                    }
                    else
                    {
                        //str.Append("<div class=\"envuroment-right3\">");
                    }

                    if (txt4.Trim() != "")
                    {
                        str.Append("<div class=\"envuroment-right4\"><div class=\"industry-img-left001\">");
                        str.Append("<a href=\"http://dp.topfo.com/img/" + loginname + "/" + txt4 + "\" alt='点击查看大图' target=\"_blank\">");
                        str.Append("<img src=\"http://dp.topfo.com/img/" + loginname + "/" + txt4 + "\" />");
                        str.Append("<p style=\"text-align:center;\">" + txts4 + "</p>");
                        str.Append("</div>");
                    }
                    else
                    { //str.Append("<div class=\"envuroment-right4\">");
                    }

                    //str.Append("</div></div>");
                    str.Append("</div>");

                }

                TempSoure = TempSoure.Replace("$contex$", str.ToString());
                TempSoure = TempSoure.Replace("$loginName$", loginname.Trim());
                TempSoure = TempSoure.Replace("$styles$", types(ids));
                CompanyShow com = new CompanyShow();
                TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loginname));
                string wenjian = MerchantTmpPathTo + loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);

                }
                string htmlpaths = MerchantTmpPathTo + loginname + "/" + "Investmentenvironment.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        //创建投资环境首页显示静态页
        public int StaticHtmls(string loginname)
        {

            try
            {
                string TempFileName = CasesTems.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.DAL.product.CommStatic dal = new GZS.DAL.product.CommStatic();
                TempSoure = TempSoure.Replace("$cntex$", dal.GetEnvironmenttab(loginname));
                //string[] html = htmlFile.Split('/');


                //string[] nn = html[2].Split('_');
                //string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = MerchantTmpPathTo + loginname + "/Investmentenvironments.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        private string types(string id)
        {
            StringBuilder str = new StringBuilder();
            string[] strId = id.Split(',');
            str.Append("<style type=\"text/css\">");
            for (int j = 0; j < strId.Length - 1; j++)
            {
                str.Append("#gk_con_" + strId[j] + " p");
                str.Append("{text-align:left;}");
            }
            str.Append("</style>");
            return str.ToString();
        }
        public int Insert(GZS.Model.EnvironmentTabM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EnvironmentTab(");
            strSql.Append("loginName,EnvironmentTypeid,Chineseintroduced,Englishintroduction,createtime,updatetime)");
            strSql.Append(" values (");
            strSql.Append("@loginName,@EnvironmentTypeid,@Chineseintroduced,@Englishintroduction,@createtime,@updatetime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.NVarChar,200),
					new SqlParameter("@EnvironmentTypeid", SqlDbType.Int,4),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
            parameters[0].Value = model.loginName;
            parameters[1].Value = model.EnvironmentTypeid;
            parameters[2].Value = model.Chineseintroduced;
            parameters[3].Value = model.Englishintroduction;
            parameters[4].Value = model.Createtime;
            parameters[5].Value = model.Updatetime;

            object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public int CountByLoginNameandTypeid(string loginname, int environmentid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Count(*) from EnvironmentTab ");
            strSql.Append(" where EnvironmentTypeid=@EnvironmentTypeid and loginName=@loginName ");
            SqlParameter[] parameters = {
					new SqlParameter("@EnvironmentTypeid", SqlDbType.Int,4),
                new SqlParameter("@loginName", SqlDbType.NVarChar ,200)
            };
            parameters[0].Value = environmentid;
            parameters[1].Value = loginname;

            return DBHelper.GetScalar(strSql.ToString(), parameters);

        }
        public EnvironmentTabM EnvironmentlistByLoginNameandTypeid(string loginname, int environmentid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Environmentid,loginName,EnvironmentTypeid,Chineseintroduced,Englishintroduction,createtime,updatetime from EnvironmentTab ");
            strSql.Append(" where EnvironmentTypeid=@EnvironmentTypeid and loginName=@loginName ");
            SqlParameter[] parameters = {
					new SqlParameter("@EnvironmentTypeid", SqlDbType.Int,4),
                new SqlParameter("@loginName", SqlDbType.NVarChar ,200)
            };
            parameters[0].Value = environmentid;
            parameters[1].Value = loginname;

            EnvironmentTabM model = new EnvironmentTabM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Environmentid"].ToString() != "")
                {
                    model.Environmentid = int.Parse(ds.Tables[0].Rows[0]["Environmentid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                if (ds.Tables[0].Rows[0]["EnvironmentTypeid"].ToString() != "")
                {
                    model.EnvironmentTypeid = int.Parse(ds.Tables[0].Rows[0]["EnvironmentTypeid"].ToString());
                }
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["createtime"].ToString() != "")
                {
                    model.Createtime = ds.Tables[0].Rows[0]["createtime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["updatetime"].ToString() != "")
                {
                    model.Updatetime = ds.Tables[0].Rows[0]["updatetime"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }

        }

        public GZS.Model.EnvironmentTabM GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Environmentid,loginName,EnvironmentTypeid,Chineseintroduced,Englishintroduction,createtime,updatetime from EnvironmentTab ");
            strSql.Append(" where Environmentid=@Environmentid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Environmentid", SqlDbType.Int,4)};
            parameters[0].Value = id;

            EnvironmentTabM model = new EnvironmentTabM();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Environmentid"].ToString() != "")
                {
                    model.Environmentid = int.Parse(ds.Tables[0].Rows[0]["Environmentid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                if (ds.Tables[0].Rows[0]["EnvironmentTypeid"].ToString() != "")
                {
                    model.EnvironmentTypeid = int.Parse(ds.Tables[0].Rows[0]["EnvironmentTypeid"].ToString());
                }
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                if (ds.Tables[0].Rows[0]["createtime"].ToString() != "")
                {
                    model.Createtime = ds.Tables[0].Rows[0]["createtime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["updatetime"].ToString() != "")
                {
                    model.Updatetime = ds.Tables[0].Rows[0]["updatetime"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public int Update(EnvironmentTabM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EnvironmentTab set ");
            strSql.Append("loginName=@loginName,");
            strSql.Append("EnvironmentTypeid=@EnvironmentTypeid,");
            strSql.Append("Chineseintroduced=@Chineseintroduced,");
            strSql.Append("Englishintroduction=@Englishintroduction,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("updatetime=@updatetime");
            strSql.Append(" where Environmentid=@Environmentid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Environmentid", SqlDbType.Int,4),
					new SqlParameter("@loginName", SqlDbType.NVarChar,200),
					new SqlParameter("@EnvironmentTypeid", SqlDbType.Int,4),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
            parameters[0].Value = model.Environmentid;
            parameters[1].Value = model.loginName;
            parameters[2].Value = model.EnvironmentTypeid;
            parameters[3].Value = model.Chineseintroduced;
            parameters[4].Value = model.Englishintroduction;
            parameters[5].Value = model.Createtime;
            parameters[6].Value = model.Updatetime;

            return DBHelper.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}
