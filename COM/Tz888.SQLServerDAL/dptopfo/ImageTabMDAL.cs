using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using GZS.DAL.Menu;

namespace GZS.DAL
{
    public class ImageTabMDAL
    {
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["DKNewsSuccsePath"].ToString(); //生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["DKImageInsert"].ToString(); //其他成功案例模版存放位置
        string CasesTemss = ConfigurationManager.AppSettings["DKImages"].ToString(); //首页用的其他成功案例模版存放位置
        string CasesTems = ConfigurationManager.AppSettings["DKImageManage"].ToString(); //其他成功案例模版存放位置
        string merchantimage = ConfigurationManager.AppSettings["Upimagecn001"].ToString();
        ImageUrlTabMDAL dal = new ImageUrlTabMDAL();
        /// <summary>
        ///创建相册静态页面
        /// </summary>
        public int StaticHtml(int id, string loginname)
        {

            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.Model.ImageTabM areatabm = GetModel(id);//主表
                List<GZS.Model.ImageUrlTabM> list = dal.GetAllByImageIds(id);//从表
                StringBuilder imageurls = new StringBuilder();
                StringBuilder imagedescript = new StringBuilder();
                //上一影集;
                GZS.Model.ImageTabM shangImageModel = GetYinJi(id,loginname,"<","desc");
                string shangImangeUrl = "";//链接地址
                string shangImageDefault = "";//默认图片
                if (shangImageModel != null)
                {
                    List<GZS.Model.ImageUrlTabM> listd = dal.GetAllByImageIds(shangImageModel.imageid);
                    if (listd.Count > 0)
                    {
                        shangImageDefault = listd[0].Imagepath.Trim();
                    }
                    else { shangImageDefault = ConfigurationManager.AppSettings["ImagesDefaultImgeName"].ToString();}
                    shangImangeUrl = shangImageModel.Htmlurl;
                }
                else 
                { 
                    shangImangeUrl = areatabm.Htmlurl;
                    if (list.Count > 0)
                    {
                        shangImageDefault = list[0].Imagepath.Trim();
                    }
                    else { shangImageDefault = ConfigurationManager.AppSettings["ImagesDefaultImgeName"].ToString();}
                }
                //下一影集;
                GZS.Model.ImageTabM xiaImageModel = GetYinJi(id,loginname, ">","asc");
                string xiaImangeUrl = "";//链接地址
                string xiaImageDefault = "";//默认图片
                if (xiaImageModel != null)
                {
                    xiaImangeUrl = xiaImageModel.Htmlurl;
                    List<GZS.Model.ImageUrlTabM> lists = dal.GetAllByImageIds(xiaImageModel.imageid);
                    if (lists.Count > 0)
                    {
                        xiaImageDefault = lists[0].Imagepath.Trim();
                    }
                    else { xiaImageDefault = ConfigurationManager.AppSettings["ImagesDefaultImgeName"].ToString();}

                }
                else 
                {
                    xiaImangeUrl = areatabm.Htmlurl;
                    if (list.Count > 0)
                    {
                        xiaImageDefault = list[0].Imagepath.Trim();
                    }
                    else { xiaImageDefault = ConfigurationManager.AppSettings["ImagesDefaultImgeName"].ToString();}
                }

                string iamgedefault = "";
                if (list.Count > 0)
                {
                    iamgedefault = "<img src=\"http://dp.topfo.com/img/" + loginname + "/" + list[0].Imagepath.Trim() + "\" id=\"placeholder\"  />";
                    for (int i = 0; i < list.Count; i++)
                    {
                        imageurls.Append(" <div class=\"pic\"><a href=\"http://dp.topfo.com/img/" + loginname + "/" + list[i].Imagepath.Trim() + "\" onMouseOver=\"showPic(this," + (i + 1) + "," + list.Count + ");return false;\" target=\"_blank\">");
                        imageurls.Append("<img src=\"http://dp.topfo.com/img/" + loginname + "/" + list[i].Imagepath.Trim() + "\" width=\"126\" height=\"94\" /> </a> </div>");
                        if (i == 0)
                        {
                            imagedescript.Append("<div  style=\"text-align:center; display:block\" id=\"show" + (i + 1) + "\">" + list[i].imgexplain + "</div>");
                        }
                        else
                        {
                            imagedescript.Append("<div  style=\"text-align:center; display:none\" id=\"show" + (i + 1) + "\">" + list[i].imgexplain + "</div>");
                        }
                    }
                }
                else 
                {
                    iamgedefault = "";

                    imageurls.Append("");
                    
                }
                string shanga = "";
                string xiaa = "";
                if (shangImageDefault.Trim() != ConfigurationManager.AppSettings["ImagesDefaultImgeName"].ToString().Trim())
                {
                    shanga = "<a href=\"http://" + loginname + ".topfo.com/" + shangImangeUrl + "\"><img src=\"http://dp.topfo.com/img/" + loginname + "/" + shangImageDefault + "\" /></a><p><a href=\"http://" + loginname + ".topfo.com/" + shangImangeUrl + "\">上一影集</a></p>";
                }
                else
                {
                    shanga = "<a href=\"http://" + loginname + ".topfo.com/" + shangImangeUrl + "\"><img src=\"" + ConfigurationManager.AppSettings["ImagesDefaultLuJin"].ToString() + "\" /></a><p><a href=\"http://" + loginname + ".topfo.com/" + shangImangeUrl + "\">上一影集</a></p>";
                }
                if (xiaImageDefault.Trim() != ConfigurationManager.AppSettings["ImagesDefaultImgeName"].ToString().Trim())
                {
                    xiaa = "<a href=\"http://" + loginname + ".topfo.com/" + xiaImangeUrl + "\"><img src=\"http://dp.topfo.com/img/" + loginname + "/" + xiaImageDefault + "\" /></a><p><a href=\"http://" + loginname + ".topfo.com/" + xiaImangeUrl + "\">下一影集</a></p>";
                }
                else
                {
                    xiaa = "<a href=\"http://" + loginname + ".topfo.com/" + xiaImangeUrl + "\"><img src=\"" + ConfigurationManager.AppSettings["ImagesDefaultLuJin"].ToString() + "\" /></a><p><a href=\"http://" + loginname + ".topfo.com/" + xiaImangeUrl + "\">下一影集</a></p>";
                }
               TempSoure = TempSoure.Replace("$shang$", shanga);
               TempSoure = TempSoure.Replace("$xia$", xiaa);
                TempSoure = TempSoure.Replace("$ImageTitle$", areatabm.imageName.Trim());
                TempSoure = TempSoure.Replace("$DefaultImage$", iamgedefault.Trim());
                TempSoure = TempSoure.Replace("$ImageList$", imageurls.ToString());
                TempSoure = TempSoure.Replace("$loginName$", loginname.Trim());
                TempSoure = TempSoure.Replace("$imagedescript$", imagedescript.ToString ());
                CompanyShow com = new CompanyShow();
                TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loginname));
                string htmlFile = areatabm.Htmlurl.ToString().Trim();
               // string[] html = htmlFile.Split('/');
               // string[] nn = html[1].Split('_');
                //string[] nn = html[2].Split('_');
               // string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo +loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }

                string htmlpaths = MerchantTmpPathTo + loginname + "/" + htmlFile;
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        public int StaticHtmls(int id, string loginname)
        {

            try
            {
                GZS.Model.ImageTabM model = GetModel(id);
                string TempFileName = CasesTems.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
             
                string TempSoure = Tem;
                List<GZS.Model.ImageUrlTabM> list = dal.GetAlls(loginname);
                StringBuilder ste = new StringBuilder();
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        GZS.Model.ImageTabM dsd = GetModel(Convert.ToInt32(list[i].Imageid));
                       List<GZS.Model.ImageUrlTabM>lists=dal.GetAllByImageIds(Convert .ToInt32(list[i].Imageid));
                       if (lists.Count > 0)
                       {
                           string imagetu=lists[0].Imagepath.Trim();
                           string imagemiaoshu = list[i].imgexplain;
                           ste.Append("<li><a href=\"http://" + loginname + ".topfo.com/" + dsd.Htmlurl + "\"><img alt=\"" + imagemiaoshu + "\" src=\"http://dp.topfo.com/img/" + loginname + "/" + imagetu + "\" /></a>  </li>");
                       }
                    }
                }
                TempSoure = TempSoure.Replace("$context$", ste.ToString ());
                TempSoure = TempSoure.Replace("$loginName$", loginname.ToString ().Trim ());
                CompanyShow com = new CompanyShow();
                TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loginname));
                string htmlFile = model.Htmlurllist.ToString().Trim();
               // string[] html = htmlFile.Split('/');
               // string[] nn = html[1].Split('_');
                //string[] nn = html[2].Split('_');
               // string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + loginname + "/";
         
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }

                string htmlpaths = MerchantTmpPathTo + loginname + "/" + htmlFile;
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        /// <summary>
        ///创建首页相册链接静态页面
        /// </summary>
        public int StaticHtmlshouye(string loginname)
        {

            try
            {
                string TempFileName = CasesTemss.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.DAL.product.CommStatic dal = new GZS.DAL.product.CommStatic();
                TempSoure = TempSoure.Replace("$cntex$", GetImageList(loginname)); 
                //string[] html = htmlFile.Split('/');


                //string[] nn = html[2].Split('_');
                //string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = MerchantTmpPathTo + loginname + "/Photogallery3.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        /// <summary>
        /// 作用：相册的图片展示静态生成
        /// 参数：用户名
        /// 作者：颜品庄
        /// 日期：2011-05-09
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetImageList(string loginName)
        {
            ImageTabMDAL dals = new ImageTabMDAL();
            ImageUrlTabMDAL dal = new ImageUrlTabMDAL();
            List<GZS.Model.ImageUrlTabM> list = dal.GetAlls(loginName);
            StringBuilder ste = new StringBuilder();
            ste.Append("<ul>");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    if (i < 6)
                    {
                        GZS.Model.ImageTabM dsd = dals.GetModel(Convert.ToInt32(list[i].Imageid));
                        List<GZS.Model.ImageUrlTabM> lists = dal.GetAllByImageIds(Convert.ToInt32(list[i].Imageid));
                        if (lists.Count > 0)
                        {
                            string imagetu = lists[0].Imagepath.Trim();
                            string miaoshu = list[i].imgexplain;
                            ste.Append("<li><a target=\"_blank\" href=\"http://" + loginName + ".topfo.com/" + dsd.Htmlurl + "\"><img src=\" http://dp.topfo.com/img/" + loginName + "/" + imagetu + "\" width=\"134\" alt=\"" + miaoshu + "\" height=\"92\" id=\"placeholder\"  /></a>");
                            ste.Append("<p><a target=\"_blank\" href=\"http://" + loginName + ".topfo.com/" + dsd.Htmlurl + "\">" + miaoshu + "</a></p>");
                            ste.Append("</li>");
                       }
                    }
                }
            }
            ste.Append("</ul>");
            return ste.ToString().Trim();
        }
        private GZS.Model.ImageTabM GetYinJi(int id, string loginname,string p,string descs)
        {
            string sql = "select top 1* from imagetab where LoginName='"+loginname+"'and imageid" + p + id + "order by imageid " + descs+ "";
            GZS.Model.ImageTabM model = new GZS.Model.ImageTabM();
            DataSet ds = DBHelper.Query(sql);
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
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GZS .Model.ImageTabM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ImageTab(");
            strSql.Append("LoginName,imageName,remark,createdatetime,Updatetime,Htmlurl)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@imageName,@remark,@createdatetime,@Updatetime,@Htmlurl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.NVarChar,200),
					new SqlParameter("@imageName", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@createdatetime", SqlDbType.DateTime),
					new SqlParameter("@Updatetime", SqlDbType.DateTime),
                    new SqlParameter("@Htmlurl", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.imageName;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.Createdatetime;
            parameters[4].Value = model.Updatetime1;
            parameters[5].Value = model.Htmlurl;

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
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
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
                    model.Updatetime1 =ds.Tables[0].Rows[0]["Updatetime"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public List<GZS.Model.ImageTabM> GetAll(string loginname)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select imageid,LoginName,imageName,remark,createdatetime,Updatetime,Htmlurl from ImageTab ");
            strSql.Append(" where LoginName=@loginname");
            List<GZS.Model.ImageTabM> list = new List<GZS.Model.ImageTabM>();
            DataSet ds = DBHelper.Query(strSql.ToString(), new SqlParameter("loginname", loginname));
            foreach(DataRow row in ds.Tables [0].Rows)
            {
                GZS.Model.ImageTabM model = new GZS.Model.ImageTabM();
                if (row["imageid"].ToString() != "")
                {
                    model.imageid = int.Parse(row["imageid"].ToString());
                }
                model.LoginName = row["LoginName"].ToString();
                model.imageName = row["imageName"].ToString();
                model.remark = row["remark"].ToString();
                model.Htmlurl = row["Htmlurl"].ToString();
                if (row["createdatetime"].ToString() != "")
                {
                    model.Createdatetime =row["createdatetime"].ToString();
                }
                if (row["Updatetime"].ToString() != "")
                {
                    model.Updatetime1 = row["Updatetime"].ToString();
                }
                list.Add(model);
            }
            return list;
        }

        public int UpdateImageTab(GZS.Model.ImageTabM model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ImageTab set ");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("imageName=@imageName,");
            strSql.Append("remark=@remark,");
            strSql.Append("createdatetime=@createdatetime,");
            strSql.Append("Updatetime=@Updatetime,");
            strSql.Append("Htmlurl=@Htmlurl,");
            strSql.Append("Htmlurllist=@Htmlurllist");
            strSql.Append(" where imageid=@imageid ");
            SqlParameter[] parameters = {
					new SqlParameter("@imageid", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.NVarChar,200),
					new SqlParameter("@imageName", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@createdatetime", SqlDbType.DateTime),
					new SqlParameter("@Updatetime", SqlDbType.DateTime),
					new SqlParameter("@Htmlurl", SqlDbType.NVarChar,200),
                new SqlParameter("@Htmlurllist", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = model.imageid;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.imageName;
            parameters[3].Value = model.remark;
            parameters[4].Value = model.Createdatetime;
            parameters[5].Value = model.Updatetime1;
            parameters[6].Value = model.Htmlurl;
            parameters[7].Value = model.Htmlurllist;

           return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
        }
        public int UpdateImageTabHtmlUrl(int id,string htmlurl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ImageTab set ");
            strSql.Append("Htmlurl=@Htmlurl");
            strSql.Append(" where imageid=@imageid ");
            SqlParameter[] parameters = {
					new SqlParameter("@imageid", SqlDbType.Int,4),
					new SqlParameter("@Htmlurl", SqlDbType.NVarChar,200)};
            parameters[0].Value = id;
            parameters[1].Value = htmlurl.Trim();

            return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
        }
        public void Delete(int imageid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ImageTab ");
            strSql.Append(" where imageid=@imageid ");
            SqlParameter[] parameters = {
					new SqlParameter("@imageid", SqlDbType.Int,4)};
            parameters[0].Value = imageid;

            DBHelper.ExecuteSql(strSql.ToString(), parameters);
        }

    }
}
