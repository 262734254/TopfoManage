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
    public class rzstatic
    {
        //融资拓富首页
        string PersonTem = ConfigurationManager.AppSettings["rzPersonTem"].ToString();
        string PersonSuccess = ConfigurationManager.AppSettings["rzPersonSuccess"].ToString();
        string rzNewsTem = ConfigurationManager.AppSettings["rzNewsTem"].ToString();

        string rzxxzsTem = ConfigurationManager.AppSettings["rzxxzsTem"].ToString();
        string rzxmrzTem = ConfigurationManager.AppSettings["rzxmrzTem"].ToString();
        string rzlxfsTem = ConfigurationManager.AppSettings["rzlxfsTem"].ToString();




        public void StaticHtml(string LoginName, string Title, string KeyWord, string Descript)
        {

            string PersonTems = PersonTem.ToString();
            string TempSoure = Compage.Reader(PersonTems);
            TempSoure = TempSoure.Replace("##UserNmae##", LoginName.ToString().Trim());
            TempSoure = TempSoure.Replace("$Title$", Title.ToString().Trim());
            TempSoure = TempSoure.Replace("$Description$", KeyWord.ToString().Trim());
            TempSoure = TempSoure.Replace("$KeyWords$", Descript.ToString().Trim());
            string htmlpaths = PersonSuccess + "rz" + LoginName + "\\index.htm";
            if (!Directory.Exists(PersonSuccess + "rz" + LoginName))
            {
                Directory.CreateDirectory(PersonSuccess + "rz" + LoginName);
            }
            Compage.Writer(htmlpaths, TempSoure);


            Company(LoginName);
            Job(LoginName);
            StaticHtmls(LoginName);

        }


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
                string SavePath = @"J:\topfo\tzWeb\Corporation\rz" + LoginName;
                sr = new StreamReader(@"G:\dp\Template\Company.html", code);
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

        private void StaticHtmls(string loginName)
        {
            string rzNewsTem1 = rzNewsTem.ToString();
            string TempSoure = Compage.Reader(rzNewsTem1);
            TempSoure = TempSoure.Replace("##userName##", loginName);
            string htmlpaths = PersonSuccess + "rz" + loginName + "\\news.htm";
            if (!Directory.Exists(PersonSuccess + "rz" + loginName))
            {
                Directory.CreateDirectory(PersonSuccess + "rz" + loginName);
            }
            Compage.Writer(htmlpaths, TempSoure);

            StaticRZHtmlshouye(loginName);

            string rzXMRZ = rzxmrzTem.ToString();
            string TempXMRZSoure = Compage.Reader(rzXMRZ);
            TempXMRZSoure = TempXMRZSoure.Replace("##userName##", loginName);
            string htmlpaths22 = PersonSuccess + "rz" + loginName + "\\teamrz.htm";
            if (!Directory.Exists(PersonSuccess + "rz" + loginName))
            {
                Directory.CreateDirectory(PersonSuccess + "rz" + loginName);
            }
            Compage.Writer(htmlpaths22, TempXMRZSoure);



            string rzLXWM = rzlxfsTem.ToString();
            string TempLXFSoure = Compage.Reader(rzLXWM);
            TempLXFSoure = TempLXFSoure.Replace("##userName##", loginName);
            string htmlpaths33 = PersonSuccess + "rz" + loginName + "\\contentus.htm";
            if (!Directory.Exists(PersonSuccess + "rz" + loginName))
            {
                Directory.CreateDirectory(PersonSuccess + "rz" + loginName);
            }
            Compage.Writer(htmlpaths33, TempLXFSoure);

        }




        /// <summary>
        ///创建融资相册链接静态页面
        /// </summary>
        public int StaticRZHtmlshouyeList(string loginname, int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();
                string Url = "";
                string sql = "SELECT dbo.ImageTab.imageid, dbo.ImageTab.LoginName, dbo.ImageTab.imageName, dbo.ImageTab.Htmlurl,dbo.ImageUrlTab.Imagepath, dbo.ImageUrlTab.imgexplain FROM dbo.ImageTab INNER JOIN dbo.ImageUrlTab ON dbo.ImageTab.imageid = dbo.ImageUrlTab.Imageid where ImageTab.LoginName=@loginname order by imageid desc";

                SqlParameter[] para ={
                new SqlParameter("@loginname",SqlDbType.VarChar,20)};
                para[0].Value = loginname;
                DataSet ds = GZS.DAL.DBHelper.Query(sql, para);
                if (ds != null & ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        string Imagepath = row["Imagepath"].ToString().Trim();
                        Url = row["Htmlurl"].ToString().Trim();
                        string imageName = row["imageName"].ToString().Trim();
                        if (i == 0)
                        {
                            sb1.Append("<img src=\"http://dp.topfo.com/img/" + loginname + "/big" + Imagepath + "\" alt=\"" + imageName + "\" width=\"549\" height=\"285\" id=\"mainphoto\"\"http://dp.topfo.com/img/" + loginname + "/" + Imagepath + "\" name=\"#\" />");

                        }
                        sb.Append("<img src=\"http://dp.topfo.com/img/" + loginname + "/" + Imagepath + "\" alt=\"" + imageName + "\" width=\"131\" height=\"89\" rel=\"http://dp.topfo.com/img/" + loginname + "/" + Imagepath + "\" name=\"#\" />");

                    }
                }



                string TempFileName = rzxxzsTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.DAL.product.CommStatic dal = new GZS.DAL.product.CommStatic();
                TempSoure = TempSoure.Replace("$cntex$", GetRZImageList(loginname));
                TempSoure = TempSoure.Replace("##userName##", loginname.ToString().Trim());
                TempSoure = TempSoure.Replace("##imgtop1##", sb1.ToString().Trim());
                TempSoure = TempSoure.Replace("##imglist##", sb.ToString().Trim());


                string wenjian = PersonSuccess + "rz" + loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = PersonSuccess + "rz" + loginname + "/" + Url + "";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }
        }

        /// <summary>
        ///创建融资相册链接静态页面
        /// </summary>
        public int StaticRZHtmlshouye(string loginname)
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();
                string sql = "SELECT dbo.ImageTab.imageid, dbo.ImageTab.LoginName, dbo.ImageTab.imageName, dbo.ImageTab.Htmlurl,dbo.ImageUrlTab.Imagepath, dbo.ImageUrlTab.imgexplain FROM dbo.ImageTab INNER JOIN dbo.ImageUrlTab ON dbo.ImageTab.imageid = dbo.ImageUrlTab.Imageid where ImageTab.LoginName=@loginname order by imageid desc";

                SqlParameter[] para ={
                new SqlParameter("@loginname",SqlDbType.VarChar,20)};
                para[0].Value = loginname;
                DataSet ds =GZS.DAL.DBHelper.Query(sql, para);
                if (ds != null & ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        string Imagepath = row["Imagepath"].ToString().Trim();
                        string Url = row["Htmlurl"].ToString().Trim();
                        string imageName = row["imageName"].ToString().Trim();
                        if (i == 0)
                        {
                            sb1.Append("<img src=\"http://dp.topfo.com/img/" + loginname + "/big" + Imagepath + "\" alt=\"" + imageName + "\" width=\"549\" height=\"285\" id=\"mainphoto\"\"http://dp.topfo.com/img/" + loginname + "/" + Imagepath + "\" name=\"#\" />");

                        }
                        sb.Append("<img src=\"http://dp.topfo.com/img/" + loginname + "/" + Imagepath + "\" alt=\"" + imageName + "\" width=\"131\" height=\"89\" rel=\"http://dp.topfo.com/img/" + loginname + "/" + Imagepath + "\" name=\"#\" />");

                    }
                }



                string TempFileName = rzxxzsTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.DAL.product.CommStatic dal = new GZS.DAL.product.CommStatic();
                TempSoure = TempSoure.Replace("$cntex$", GetRZImageList(loginname));
                TempSoure = TempSoure.Replace("##userName##", loginname.ToString().Trim());
                TempSoure = TempSoure.Replace("##imgtop1##", sb1.ToString().Trim());
                TempSoure = TempSoure.Replace("##imglist##", sb.ToString().Trim());


                string wenjian = PersonSuccess + "rz" + loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = PersonSuccess + "rz" + loginname + "/xszs.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }

        //用于生成静态页面根据主表的用户名去查询相册从表相对应的相片集合
        public List<GZS.Model.ImageUrlTabM> GetAlls(string loginname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(ImageUrlTab.Imageid),imagename from ImageUrlTab inner join imagetab on imagetab.imageid=imageurltab.imageid where LoginName=@loginname order by ImageUrlTab.Imageid desc");

            DataSet ds = GZS.DAL.DBHelper.Query(strSql.ToString(), new SqlParameter("@loginname", loginname));
            List<GZS.Model.ImageUrlTabM> list = new List<GZS.Model.ImageUrlTabM>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                GZS.Model.ImageUrlTabM model = new GZS.Model.ImageUrlTabM();
                if (row["Imageid"].ToString() != "")
                {
                    model.Imageid = int.Parse(row["Imageid"].ToString());
                }
                if (row["imagename"].ToString().Trim() != "")
                {
                    model.imgexplain = row["imagename"].ToString();
                }
                list.Add(model);
            }
            return list;
        }


        public string GetRZImageList(string loginName)
        {

            List<GZS.Model.ImageUrlTabM> list = GetAlls(loginName);
            StringBuilder ste = new StringBuilder();
            ste.Append("<ul>");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {


                    GZS.Model.ImageTabM dsd = GetModel(Convert.ToInt32(list[i].Imageid));
                    List<GZS.Model.ImageUrlTabM> lists = GetAllByImageIds(Convert.ToInt32(list[i].Imageid));
                    if (lists.Count > 0)
                    {
                        string imagetu = lists[0].Imagepath.Trim();
                        string miaoshu = list[i].imgexplain;

                        ste.Append("<li><a  href=\"http://rz" + loginName + ".topfo.com/" + dsd.Htmlurl + "\"><img src=\" http://dp.topfo.com/img/" + loginName + "/" + imagetu + "\" alt=\"" + miaoshu + "\" width=\"77\" height=\"52\" id=\"placeholder\"  /></a>");

                        ste.Append("</li>");
                    }

                }
            }

            ste.Append(" <div style=\"clear:both\"></div></ul>");
            return ste.ToString().Trim();
        }
        //通过相册主表的ID获取从表相册的集合
        public List<GZS.Model.ImageUrlTabM> GetAllByImageIds(int imageid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select parktypeid,Imageid,Imagepath,imgexplain from ImageUrlTab ");
            strSql.Append(" where Imageid=@parktypeid order by parktypeid desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@parktypeid", SqlDbType.Int,4)};
            parameters[0].Value = imageid;


            DataSet ds = GZS.DAL.DBHelper.Query(strSql.ToString(), parameters);
            List<GZS.Model.ImageUrlTabM> list = new List<GZS.Model.ImageUrlTabM>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                GZS.Model.ImageUrlTabM model = new GZS.Model.ImageUrlTabM();
                if (row["parktypeid"].ToString() != "")
                {
                    model.parktypeid = int.Parse(row["parktypeid"].ToString());
                }
                if (row["Imageid"].ToString() != "")
                {
                    model.Imageid = int.Parse(row["Imageid"].ToString());
                }
                model.Imagepath = row["Imagepath"].ToString();
                model.imgexplain = row["imgexplain"].ToString();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GZS.Model.ImageTabM GetModel(int imageid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 imageid,LoginName,imageName,remark,createdatetime,Updatetime,Htmlurl,Htmlurllist from ImageTab ");
            strSql.Append(" where imageid=@imageid ");
            SqlParameter[] parameters = {
					new SqlParameter("@imageid", SqlDbType.Int,4)};
            parameters[0].Value = imageid;

            GZS.Model.ImageTabM model = new GZS.Model.ImageTabM();
            DataSet ds = GZS.DAL.DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["imageid"].ToString() != "")
                {
                    model.imageid = int.Parse(ds.Tables[0].Rows[0]["imageid"].ToString());
                }
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.imageName = ds.Tables[0].Rows[0]["imageName"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                model.Htmlurl = ds.Tables[0].Rows[0]["Htmlurl"].ToString();
                model.Htmlurllist = ds.Tables[0].Rows[0]["Htmlurllist"].ToString();
                if (ds.Tables[0].Rows[0]["createdatetime"].ToString() != "")
                {
                    model.Createdatetime = ds.Tables[0].Rows[0]["createdatetime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Updatetime"].ToString() != "")
                {
                    model.Updatetime1 = ds.Tables[0].Rows[0]["Updatetime"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        //职位招聘静态页面
        public void Job(string LoginName)
        {
            string sql = "select Id,JobName,Address,PersonNumber,Salary,Nature,PublishPerson,Remark,HtmlUrl,PublishTime from JobTab where PublishPerson=@PublishPerson";
            string ConnStr = ConfigurationManager.ConnectionStrings["CompanyShow"].ToString();
            SqlConnection con = new SqlConnection(ConnStr);
            SqlCommand com = new SqlCommand(sql, con);
            SqlParameter[] Paras = new SqlParameter[]
                {
                   new SqlParameter("@PublishPerson",SqlDbType.VarChar,50)
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
                string SavePath = @"J:\topfo\tzWeb\Corporation\rz" + LoginName;
                sr = new StreamReader(@"G:\dp\Template\Job.html", Encoding.GetEncoding("gb2312"));
                string TempData = sr.ReadToEnd();
                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();

                int Count = dt.Rows.Count;
                if (dt != null && Count > 0)
                {
                    sb.Append("<ul>");
                    for (int i = 0; i < Count; i++)
                    {
                        if (i == 0)
                        {
                            sb.Append("<li onclick=\"onClik(this)\" id=\"" + i.ToString() + "\"><a href=\"javascript:void(0)\" class=\"fdsd\">·" + dt.Rows[i]["JobName"].ToString() + "</a></li>");
                            sb1.Append("<div display=\"block\" id=\"item" + i.ToString() + "\">" + dt.Rows[i]["Remark"].ToString() + "</div>");
                        }
                        else
                        {
                            sb.Append("<li onclick=\"onClik(this)\" id=\"" + i.ToString() + "\"><a href=\"javascript:void(0)\">·" + dt.Rows[i]["JobName"].ToString() + "</a></li>");
                            sb1.Append("<div display=\"none\" id=\"item" + i.ToString() + "\">" + dt.Rows[i]["Remark"].ToString() + "</div>");
                        }
                    }
                    sb.Append("</ul>");
                    TempData = TempData.Replace("$JobList$", sb.ToString());
                    TempData = TempData.Replace("$Remark$", sb1.ToString());
                    TempData = TempData.Replace("$UserName$", LoginName.ToString().Trim());
                }
                else
                {
                    TempData = TempData.Replace("$JobList$", "暂无数据");
                    TempData = TempData.Replace("$Remark$", "暂无数据");
                }
                sw = new StreamWriter(SavePath + "\\rczp.htm", false, Encoding.GetEncoding("gb2312"));
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


        private string SubStr(string str, int len)
        {
            string msg = "";
            if (str.Length > len)
            {
                msg = str.Substring(0, len) + "....";
            }
            else
            {
                msg = str.ToString();
            }
            return msg;
        }
    }
}
