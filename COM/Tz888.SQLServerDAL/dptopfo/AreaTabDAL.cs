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
    public class AreaTabDAL
    {
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["DKNewsSuccsePath"].ToString(); //生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["DKAreatabTest"].ToString(); //其他成功案例模版存放位置
        string CasesTems = ConfigurationManager.AppSettings["DKAreashouye"].ToString(); //其他首页显示成功案例模版存放位置
        string merchantimage = ConfigurationManager.AppSettings["Upimagecn001"].ToString();
        /// <summary>
        ///创建区域静态页面
        /// </summary>
        public int StaticHtml(int id, string loaginnames)
        {

            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                GZS.Model.AreaTab areatabm = null;
                List<GZS.Model.Areaimg> list = null;
                string TempSoure = Tem;
                if (id==0)
                {
                    areatabm = GetModelCountByLogName(loaginnames);
                }
                else
                {
                   areatabm = GetModel(id);
                }
                
                StringBuilder imageurls = new StringBuilder();
                GZS .DAL .AreaimgDAL areaimgdal=new AreaimgDAL ();
                if (id==0)
                {
                  list = areaimgdal.GetAllModelByareId(areatabm.areaid);
                }
                else
                {
                   list = areaimgdal.GetAllModelByareId(id);
                }
                
                string iamgedefaults = "";
                string iamgedefault = "";
                if (list.Count > 0)
                {
                    if (list[0].ImageUrl.Trim() != "")
                    {
                        iamgedefaults = "<img src=\" http://dp.topfo.com/img/" + loaginnames + "/" + list[0].ImageUrl.Trim() + "\"   />";
                        iamgedefault = "<img src=\" http://dp.topfo.com/img/" +loaginnames+"/"+ list[0].ImageUrl.Trim() + "\"  id=\"placeholder\"  />";
                        for (int i = 0; i < list.Count; i++)
                        {
                            imageurls.Append(" <div  class=\"pic\"><a href=\"http://dp.topfo.com/img/" + loaginnames + "/" + list[i].ImageUrl.Trim() + "\" onMouseOver=\"showPic(this);return false;\" target=\"_blank\">");
                            imageurls.Append("<img id=\"dx"+i+"\" src=\"http://dp.topfo.com/img/" + loaginnames + "/" + list[i].ImageUrl.Trim() + "\" /> </a> </div>");
                        }
                    }
                    else 
                    {
                        iamgedefault = "";
                        iamgedefaults = "";
                        imageurls.Append ("<li></li>");
                    }
                }
                
                TempSoure = TempSoure.Replace("$zhongwencontex$", areatabm.Chineseintroduced.Trim());
                TempSoure = TempSoure.Replace("$EnglishContext$", areatabm.Englishintroduction.Trim());
                TempSoure = TempSoure.Replace("$DefaultImage$",iamgedefault.Trim());
                TempSoure = TempSoure.Replace("$ImageList$", imageurls.ToString());
                TempSoure = TempSoure.Replace("$loginName$", loaginnames.Trim());
                TempSoure = TempSoure.Replace("$txtup$", iamgedefaults.Trim());
                CompanyShow com = new CompanyShow();
                TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loaginnames));
                string htmlFile = areatabm.Htmlurl.ToString().Trim();

                //string[] nn = html[2].Split('_');
               // string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo+loaginnames+"/";
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);
                }
                string htmlpaths = MerchantTmpPathTo + loaginnames + "/" + htmlFile;
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        public int StaticHtmls(string loginname)
        {

            try
            {
                string TempFileName = CasesTems.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容

                string TempSoure = Tem;
                GZS.DAL.product.CommStatic dal = new GZS.DAL.product.CommStatic();
                string sds=dal.GetAreaList(loginname).Trim ();
                TempSoure = TempSoure.Replace("$cntex$", sds);
                //string[] html = htmlFile.Split('/');


                //string[] nn = html[2].Split('_');
                //string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + loginname + "/";

                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);


                }
                string htmlpaths = MerchantTmpPathTo + loginname + "/Regionaloverviews.htm";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }

        }
        public int InsertAreaTab(GZS.Model.AreaTab model,GZS .Model.Areaimg areaing)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into areaTab(");
            strSql.Append("loginName,Chineseintroduced,Englishintroduction,createdates,Updatetimes,htmlurl)");
            strSql.Append(" values (");
            strSql.Append("@loginName,@Chineseintroduced,@Englishintroduction,@createdates,@Updatetimes,@htmlurl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.NVarChar,200),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
					new SqlParameter("@createdates", SqlDbType.DateTime),
					new SqlParameter("@Updatetimes", SqlDbType.DateTime),
                    new SqlParameter ("@htmlurl",SqlDbType.NVarChar ,200)
            };
            parameters[0].Value = model.loginName;
            parameters[1].Value = model.Chineseintroduced;
            parameters[2].Value = model.Englishintroduction;
            parameters[3].Value = model.createdates;
            parameters[4].Value = model.Updatetimes;
            parameters [5].Value=model.Htmlurl;

            object obj = DBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                int res = 0;
                if (areaing.ImageUrl.Trim() != "")
                {
                    string[] strImageurl = areaing.ImageUrl.TrimEnd('$').Split('$');
                    for (int i = 0; i < strImageurl.Length; i++)
                    {
                        GZS.Model.Areaimg ares = new GZS.Model.Areaimg();
                        ares.areaid = Convert.ToInt32(obj);
                        ares.ImageName = areaing.ImageName;
                        ares.ImageUrl = strImageurl[i].ToString().Trim();
                        ares.imgageexplain = areaing.imgageexplain;
                        res = AreaimgDAL.Insert(ares);

                    }
                    res = 1;
                }
                else { res = 1; }
                return Convert .ToInt32(obj);
            }
        }
        public GZS.Model.AreaTab GetModelCountByLogName(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 areaid,loginName,Chineseintroduced,Englishintroduction,createdates,Updatetimes,htmlurl from areaTab ");
            strSql.Append(" where loginName=@loginName ");
            SqlParameter[] parameters = {
					new SqlParameter("@loginName", SqlDbType.NVarChar ,200)};
            parameters[0].Value = name;

            GZS .Model .AreaTab  model = new GZS.Model.AreaTab();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["areaid"].ToString() != "")
                {
                    model.areaid = int.Parse(ds.Tables[0].Rows[0]["areaid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                model.Htmlurl = ds.Tables[0].Rows[0]["htmlurl"].ToString();
                if (ds.Tables[0].Rows[0]["createdates"].ToString() != "")
                {
                    model.createdates = ds.Tables[0].Rows[0]["createdates"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Updatetimes"].ToString() != "")
                {
                    model.Updatetimes =ds.Tables[0].Rows[0]["Updatetimes"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public GZS.Model.AreaTab GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 areaid,loginName,Chineseintroduced,Englishintroduction,createdates,Updatetimes,htmlurl from areaTab ");
            strSql.Append(" where areaid=@areaid ");
            SqlParameter[] parameters = {
					new SqlParameter("@areaid", SqlDbType.Int ,4)};
            parameters[0].Value = id;

            GZS.Model.AreaTab model = new GZS.Model.AreaTab();
            DataSet ds = DBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["areaid"].ToString() != "")
                {
                    model.areaid = int.Parse(ds.Tables[0].Rows[0]["areaid"].ToString());
                }
                model.loginName = ds.Tables[0].Rows[0]["loginName"].ToString();
                model.Chineseintroduced = ds.Tables[0].Rows[0]["Chineseintroduced"].ToString();
                model.Englishintroduction = ds.Tables[0].Rows[0]["Englishintroduction"].ToString();
                model.Htmlurl = ds.Tables[0].Rows[0]["htmlurl"].ToString();
                if (ds.Tables[0].Rows[0]["createdates"].ToString() != "")
                {
                    model.createdates = ds.Tables[0].Rows[0]["createdates"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Updatetimes"].ToString() != "")
                {
                    model.Updatetimes = ds.Tables[0].Rows[0]["Updatetimes"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public int UpdateAreatab(GZS.Model.AreaTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update areaTab set ");
            strSql.Append("loginName=@loginName,");
            strSql.Append("Chineseintroduced=@Chineseintroduced,");
            strSql.Append("Englishintroduction=@Englishintroduction,");
            strSql.Append("createdates=@createdates,");
            strSql.Append("Updatetimes=@Updatetimes,");
            strSql.Append("htmlurl=@htmlurl");
            strSql.Append(" where areaid=@areaid ");
            SqlParameter[] parameters = {
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@loginName", SqlDbType.NVarChar,200),
					new SqlParameter("@Chineseintroduced", SqlDbType.Text),
					new SqlParameter("@Englishintroduction", SqlDbType.Text),
					new SqlParameter("@createdates", SqlDbType.DateTime),
					new SqlParameter("@Updatetimes", SqlDbType.DateTime),
                new SqlParameter("@htmlurl", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = model.areaid;
            parameters[1].Value = model.loginName;
            parameters[2].Value = model.Chineseintroduced;
            parameters[3].Value = model.Englishintroduction;
            parameters[4].Value = model.createdates;
            parameters[5].Value = model.Updatetimes;
            parameters[6].Value = model.Htmlurl;

            return DBHelper.ExecuteCommand(strSql.ToString(), parameters);
        }
    }
}
