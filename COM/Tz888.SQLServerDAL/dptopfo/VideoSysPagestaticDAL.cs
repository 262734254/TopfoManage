using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using GZS.DAL.Menu;

namespace GZS.DAL
{
    public class VideoSysPagestaticDAL
    {
        GZS.DAL.VideoSysDAL videosysdal = new VideoSysDAL();
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["DKNewsSuccsePath"].ToString(); //成功案例生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["DKNewsTestTem"].ToString(); //其他成功案例模版存放位置
        string merchantimage = ConfigurationManager.AppSettings["Upimagecn001"].ToString();
        /// <summary>
        ///创建视频静态页面
        /// </summary>
        public int StaticHtml(int id, string loginname)
        {
            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.Model.VideoSysM model = videosysdal.GetModel(id);
                StringBuilder imageurls = new StringBuilder();
                // string inPathTo = "/video";
                List<GZS.Model.VideoSysM> list = videosysdal.GetTopModel(loginname);
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        string urlhtml = list[i].htmlurl.Trim();//连接地址
                        if (list[i].ImageName.Trim() != ConfigurationManager.AppSettings["VideoDefaultImgeName"].ToString().Trim())
                        {
                            imageurls.Append("<li><a href=\"http://"+loginname+".topfo.com/" + urlhtml + "\"><img alt=\""+list[i].videotitle+"\" src=\"http://dp.topfo.com/img/" + loginname + "/");
                            imageurls.Append(list[i].ImageName + "\"");
                            imageurls.Append(" width=\"110\" height=\"83\" /></a></li>");
                        }
                        else
                        {
                            imageurls.Append("<li><a href=\"http://" + loginname + ".topfo.com/" + urlhtml + "\"><img alt=\"" + list[i].videotitle + "\" src=\"http://dp.topfo.com/UpImage/" + ConfigurationManager.AppSettings["VideoDefaultImgeNames"].ToString().Trim() + "\"");
                            imageurls.Append(" width=\"110\" height=\"83\" /></a></li>");
                        }
                    }
                }
                TempSoure = TempSoure.Replace("$VoidioTitle$", model.videotitle.ToString().Trim());
                TempSoure = TempSoure.Replace("$context$", model.introduction.ToString().Trim());
                TempSoure = TempSoure.Replace("$name$", model.VidoiName.Trim());
                TempSoure = TempSoure.Replace("$imageurl$", imageurls.ToString());
                TempSoure = TempSoure.Replace("$loginName$", loginname.Trim());
                CompanyShow com = new CompanyShow();
                TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loginname));
                string htmlFile = model.htmlurl.ToString().Trim();
                //string[] html = htmlFile.Split('/');


                //string[] nn = html[2].Split('_');
                //string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + loginname + "/";
  
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = MerchantTmpPathTo + loginname + "/"+htmlFile;
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }



        //public string sethtml()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string sql = "select top 6 NTitle,urlhtml from NewsTab where audit=1 order by createdate desc";
        //    DataSet ds = Tz888.DBUtility.DBHelper.Query(sql);
        //    sb.Append("<ul>");
        //    if (ds != null & ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            DataRow row = ds.Tables[0].Rows[i];
        //            string Title = ds.Tables[0].Rows[i]["NTitle"].ToString();
        //            sb.Append("<li>·<a href='http://news.topfo.com/" + row["urlhtml"].ToString() + "' target=\"_blank\">" + StrLength(Title.ToString().Trim(), 16) + "</a></li>");
        //        }
        //    }
        //    sb.Append("</ul>");
        //    return sb.ToString();
        //}

        //public string sethtmls()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string sql = "select top 6 NTitle,urlhtml,createdate from NewsTab where audit=1 order by createdate desc";
        //    DataSet ds = Tz888.DBUtility.DBHelper.Query(sql);
        //    sb.Append("<ul>");
        //    if (ds != null & ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            DataRow row = ds.Tables[0].Rows[i];
        //            string Title = ds.Tables[0].Rows[i]["NTitle"].ToString();
        //            sb.Append("<li><a href='http://news.topfo.com/" + row["urlhtml"].ToString() + "' target=\"_blank\">" + "<span>" + StrLength(Title.ToString().Trim(), 16) + "</span>" + "<h12>" + ds.Tables[0].Rows[i]["createdate"].ToString().Substring(0, 9) + "</h12></a></li>");
        //        }
        //    }
        //    sb.Append("</ul>");
        //    return sb.ToString();
        //}

        //protected string StrLength(object title, int count)
        //{
        //    string name = "";
        //    name = title.ToString();
        //    if (name.Length > count)
        //    {
        //        name = name.Substring(0, count) + "...";
        //    }
        //    return name;
        //}
    }
}
