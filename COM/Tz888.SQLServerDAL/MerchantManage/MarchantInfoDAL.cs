using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.MerchantManage;
using Tz888.IDAL.MerchantManage;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using GZS.DAL;

namespace Tz888.SQLServerDAL.MerchantManage
{
  
    public class MarchantInfoDAL : Tz888.IDAL.MerchantManage.IMerchant
    {
        string NewSumPath = ConfigurationManager.AppSettings["SearchSumAppPath"].ToString(); //搜索详细页面生成页面存放地方
        string NewSumTem = ConfigurationManager.AppSettings["SearchSumTem"].ToString(); //搜索详细页面模版存放位置
        string NewSumTemInduy = ConfigurationManager.AppSettings["SearchSumTemInduy"].ToString(); //搜索详细页面模版存放位置
        Common.Induy dal = new Tz888.SQLServerDAL.Common.Induy();
        #region IMerchant 成员
        /// <summary>
        /// 插入招商信息
        /// </summary>
        /// <param name="mainInfoModel">主信息表实体类</param>
        /// <param name="MerchantModel">招商信息表实体类</param>
        /// <param name="shortInfoModel">短信息表实体类</param>
        /// <returns></returns>
        public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel, MerchantModel MerchantModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 用视图查询招商信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序</param>
        /// <param name="Page">每页显示多少条</param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount">总数</param>
        /// <returns></returns>
        public DataSet dsGetNewsList(string SelectStr, string Criteria, string Sort, long Page, long CurrentPageRow, ref long TotalCount)
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.dsGetListNewsTopNums(
                                            "MerchantManageList",
                                            SelectStr,
                                            Criteria,
                                            Sort,
                                            Page,
                                            CurrentPageRow,
                                            ref TotalCount));
        }
        /// <summary>
        /// 更新招商信息
        /// </summary>
        /// <param name="mainInfoModel">主信息表实体类</param>
        /// <param name="MerchantModel">招商信息表实体类</param>
        /// <param name="shortInfoModel">短信息表实体类</param>
        /// <returns></returns>
        public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel, MerchantModel MerchantModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 根据ID删除招商信息
        /// </summary>
        /// <param name="infoId">ID</param>
        /// <returns></returns>
        public long delete(string infoId)
        {
            long DelInfo;
            long DelCases;
            long DelMain = 0;
            long delCon;
            long Audit;
            string sql = "";
            sql = "delete from  ShortInfoTab where InfoID = @infoId";
            SqlParameter[] para ={ 
               new SqlParameter("@infoId",SqlDbType.VarChar,10)
            };
            para[0].Value = infoId;
            DelInfo = (long)DbHelperSQL.ExecuteSql(sql, para);
            if (DelInfo > 0)
            {

                long InfoResou;
                sql = "delete from  InfoContactTab where InfoID= @infoId";
                SqlParameter[] para4 ={ 
                    new SqlParameter("@infoId",SqlDbType.VarChar,10)
                    };
                para4[0].Value = infoId;
                delCon = (long)DbHelperSQL.ExecuteSql(sql, para4);

                if (delCon > 0 || DelInfo > 0)
                {
                    sql = "delete from  InfoAuditTab where InfoID = @infoId";
                    SqlParameter[] para3 ={ 
                        new SqlParameter("@infoId",SqlDbType.VarChar,10)
                        };
                    para3[0].Value = infoId;
                    Audit = (long)DbHelperSQL.ExecuteSql(sql, para3);
                }
                if (delCon > 0 || DelInfo > 0)
                {
                    sql = "delete from  InfoResourceTab where InfoID = @infoId";
                    SqlParameter[] para5 ={ 
                            new SqlParameter("@infoId",SqlDbType.VarChar,10)
                            };
                    para5[0].Value = infoId;
                    InfoResou = (long)DbHelperSQL.ExecuteSql(sql, para5);
                }
                if (DelInfo > 0 || delCon > 0)
                {
                    sql = "delete from  MerchantInfotab where InfoID = @infoId";
                    SqlParameter[] para1 ={ 
                            new SqlParameter("@infoId",SqlDbType.VarChar,10)
                            };
                    para1[0].Value = infoId;
                    DelCases = (long)DbHelperSQL.ExecuteSql(sql, para1);
                }

                if (delCon > 0 || DelInfo > 0)
                {

                    sql = "delete from  MainInfoTab where  InfoID = @infoId";
                    SqlParameter[] para2 ={ 
                    new SqlParameter("@infoId",SqlDbType.VarChar,10)
                    };
                    para2[0].Value = infoId;
                    DelMain = (long)DbHelperSQL.ExecuteSql(sql, para2);
                }
            }

            return DelMain;
        }

        #endregion

      

        #region 区域静态生成 

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int CountPage(int areid)
        {

            string num = "";
            string sql = "select count(InfoID)  from MerchantInfoTab where ProvinceID=@areid";
            SqlParameter[] para ={ 
                new SqlParameter("@areid",SqlDbType.Int,8)
            };
            para[0].Value = areid;
            num = Convert.ToString(SearchDBHelper.GetSingle(sql, para));
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 判断总共有多少个页面数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int pageS(int areid)
        {
            int pagecc = 0;//总共多少个页面
            int countpage = CountPage(areid);//总共多少条
          //pagecc = countpage >= 40 ? (countpage % 40 == 0 ? countpage / 40 : countpage / 40 + 1) : 1;
            pagecc = countpage >= 10 ? (countpage % 10 == 0 ? countpage / 10 : countpage / 10 + 1) : 1;
            return pagecc;
        }



        public void SelState(int num, int areid)
        {
            StringBuilder sbl = new StringBuilder();

            Common.Text common = new Common.Text();
            string arelist = dal.dvGetProveName( Convert.ToString(areid));
            #region 属性封装
            string InfoID = "";
            string Title;
            string publishT = "";
            string Hit;
            string LoginName;
            string FixPriceID;
            string HtmlFile;
            string ProvinceID;
            string CountyID;
            string IndustryClassList;
            string CityID;
            string CapitalTotal = "";
            string ValidateTerm = "";
            string ZoneAbout;
            string isVIP = "";
            string CapitalCurrency;
            string AuditingStatus = "";
            string CountryCode;
            #endregion
            StringBuilder sb = new StringBuilder();
            string sql = "SELECT top 10 [InfoID] ,[Title],[publishT],[Hit],[FixPriceID],[HtmlFile],[ProvinceID],[CountyID],[IndustryClassList],[CityID],"
             + "[CapitalTotal],[ValidateTerm],[ZoneAbout] ,[CapitalCurrency],[AuditingStatus],[CountryCode]FROM [Search].[dbo].[MerchantInfoTab] where ProvinceID=" + areid + "  and infoID not in  (select top " + 10 * (num - 1) + " infoID from [Search].[dbo].[MerchantInfoTab] where ProvinceID='" + areid + "' order by  publishT desc   )  order by  publishT desc";

            DataSet ds = SearchDBHelper.Query(sql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    if (ds.Tables[0].Rows[i]["InfoID"].ToString() != "")
                    {
                        InfoID = ds.Tables[0].Rows[i]["InfoID"].ToString();
                    }
                    Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    if (ds.Tables[0].Rows[i]["publishT"].ToString() != "")
                    {
                        publishT = ds.Tables[0].Rows[i]["publishT"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["Hit"].ToString() != "")
                    {
                        Hit = ds.Tables[0].Rows[i]["Hit"].ToString();
           
                    }
                    FixPriceID = ds.Tables[0].Rows[i]["FixPriceID"].ToString();
                    HtmlFile = ds.Tables[0].Rows[i]["HtmlFile"].ToString();
                    ProvinceID = ds.Tables[0].Rows[i]["ProvinceID"].ToString();
                    CountyID = ds.Tables[0].Rows[i]["CountyID"].ToString();
                    IndustryClassList = ds.Tables[0].Rows[i]["IndustryClassList"].ToString();
                    CityID = ds.Tables[0].Rows[i]["CityID"].ToString();
                    if (ds.Tables[0].Rows[i]["CapitalTotal"].ToString() != "")
                    {
                        CapitalTotal = ds.Tables[0].Rows[i]["CapitalTotal"].ToString() + "万元";

                    }
                    else
                    {
                        CapitalTotal = "暂未填写";
                    }
                    if (ds.Tables[0].Rows[i]["ValidateTerm"].ToString() != "")
                    {
                        ValidateTerm = ds.Tables[0].Rows[i]["ValidateTerm"].ToString();
                    }
                    ZoneAbout = ds.Tables[0].Rows[i]["ZoneAbout"].ToString();

                    CapitalCurrency = ds.Tables[0].Rows[i]["CapitalCurrency"].ToString();
                    if (ds.Tables[0].Rows[i]["AuditingStatus"].ToString() != "")
                    {
                        AuditingStatus = ds.Tables[0].Rows[i]["AuditingStatus"].ToString();
                    }
                    CountryCode = ds.Tables[0].Rows[i]["CountryCode"].ToString();

                    sb.Append("<ul>");
                    sb.Append("<li>");
                    sb.Append("<div class=\"ziyuan-list-1\">");
                    sb.Append("<input type=\"checkbox\" name=\"checkboxRecord\" value=" + InfoID + " />");
                    sb.Append("</div>");
                    sb.Append("<div class=\"ziyuan-list-2\"><img src=\"http://search.topfo.com/images/search_34.jpg\" /></div>");
                    sb.Append("<div class=\"ziyuan-list-3\">");
                    sb.Append("<h3><a href=\"http://www.topfo.com/" + HtmlFile + "\" class=\"f_lan-bd\" target=\"_blank\"> " + Title.ToString().Trim() + "</a></h3>");
                    sb.Append("<div style=\" color:#666; margin-bottom:6px\">" + dal.FixLenth(common.ThrowHtml(ZoneAbout), 110, "....") + "</div>");
                    sb.Append("<div> <span class=\"ziyuan-list-3-a1\">状态：<span class=\"f_org\">[已审核]</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">总金额：<span class=\"f_org\">" + CapitalTotal + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">地区：<span class=\"f_org\">" + arelist + "  " + dal.dvGetCa(CityID) + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-b1\">行业：<span class=\"f_org\">" + dal.IndustrySelect(IndustryClassList) + "</span></span> </div>");
                    sb.Append("<div  class=\"f_gray \" style=\"clear:both\">发布时间:  " + publishT.Substring(0, 9).Trim() + "  有效时间：" + SelectValidate(ValidateTerm) + "</div>");
                    sb.Append("</div>");
                    sb.Append("<div  class=\"ziyuan-list-4\">");
                    sb.Append("<a href=\"http://www.topfo.com/" + HtmlFile + "\" target=\"_blank\"><img src=\"http://search.topfo.com/images/search_38.jpg\" /></a>");
                    sb.Append(" </div>");
                    sb.Append(" </li>");
                    sb.Append("</ul>");

                }
                string pageIndex = Page(num, areid);
                HtmlPage(num, sb.ToString(), pageIndex, areid, arelist);

            }
            else
            {
                HtmlPage(num, sb.ToString(), "暂未搜索到该资源", areid, arelist);
            }

         
        }

        public void HtmlPage(int num, string state, string page, int areid, string areList)
        {
            string KeyWord = "" + areList + "招商项目, " + areList + "招商项目新资讯";
            string Descript = "有关" + areList + "招商项目信息汇总，招商项目频道，全国最新" + areList + "招商项目信息发布，让投资者更快找到" + areList + "招商项目相关的投资项目和项目信息，展示哪些企业的招商项目；同时也为企业提供全国优秀" + areList + "招商项目资讯，让企业更快找到" + areList + "招商项目相关信息。";
            string DisplayTitle = "" + areList + "招商项目|" + areList + "招商项目信息汇总|招商项目 " + areList + "项目分类 - 中国招商投资网";
            string TempFileName = NewSumTem.ToString();
            string Tem = Compage.Reader(TempFileName); //读取模板内容
            #region 替换模版
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$KeyWord$", KeyWord);//网页关键字
            TempSoure = TempSoure.Replace("$Descript$", Descript);//网页描述
            TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);//网页标题

            TempSoure = TempSoure.Replace("$State$", state);
            TempSoure = TempSoure.Replace("$Page$", page);

            TempSoure = TempSoure.Replace("$QuYuAre$", areList);
            TempSoure = TempSoure.Replace("$QAreList$",Convert.ToString(areid));
            #endregion

            string wenjian = NewSumPath;
            if (Directory.Exists(wenjian) == false)
            {
                Directory.CreateDirectory(wenjian);
            }

            string htmlpaths = wenjian + "\\zs" + areid + "_" + num + ".shtml";
            GZS.DAL.Compage.Writer(htmlpaths, TempSoure);
        }
        /// <summary>
        /// 翻译所属类型
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public string Type(int typeID)
        {
            string num = "";
            string sql = "select TypeName from NewsTypeTab where TypeID=@typeID";
            SqlParameter[] para ={ 
                new SqlParameter("@typeID",SqlDbType.Int,8)
            };
            para[0].Value = typeID;
            num = Convert.ToString(SearchDBHelper.GetSingle(sql, para));
            return num;
        }
        #region 有效期转换
        /// <summary>
        /// 有效期转换
        /// </summary>
        /// <param name="ValidateTerm"></param>
        /// <returns></returns>
        public string SelectValidate(string ValidateTerm)
        {
            switch (ValidateTerm.ToString().Trim())
            {
                case "3": ValidateTerm = "3个月"; break;
                case "6": ValidateTerm = "6个月"; break;
                case "36": ValidateTerm = "3年"; break;
                case "60": ValidateTerm = "5年"; break;
                case "12": ValidateTerm = "1年"; break;
                case "24": ValidateTerm = "2年"; break;
            }
            return ValidateTerm;
        }

        #endregion
        public string Page(int num, int areid)
        {
            StringBuilder sb = new StringBuilder();
            int pagecc = pageS(areid);
            sb.Append("<div class=\"Points_Page_sub\">");
            string urlbegin = "zs" + areid + "_" + 1 + ".shtml";//首页
            string urlendgin = "zs" + areid + "_" + pagecc + ".shtml";//尾页
            sb.Append("<a href='" + urlbegin + "' target=\"_parent\">首页</a>");
            if (pagecc == 1)
            {
                sb.Append("<span>1</span>");
            }
            else
            {
                string urlon = "zs" + areid + "_" + (num - 1) + ".shtml";//上一页
                string urldown = "zs"+ areid + "_" + (num + 1) + ".shtml";//下一页
                if (num != 1)
                {
                    sb.Append("<a href='" + urlon + "' target=\"_parent\">&lt;</a>");
                }
                for (int j = (num / 9 * 8) + 1; j <= (pagecc >= ((num / 9 * 8) + 9) ? ((num / 9 * 8) + 9) : pagecc); j++)
                {
                    string urlZ = "zs" + areid + "_" + j + ".shtml";
                    if (j == num)
                    {
                        sb.Append("<a href='" + urlZ + "' class=\"anpager\" target=\"_parent\">" + j + "</a>");
                    }
                    else
                    {
                        sb.Append("<a href='" + urlZ + "' target=\"_parent\">" + j + "</a>");
                    }

                }
                if (num != pagecc)
                {
                    sb.Append("<a href='" + urldown + "'  target=\"_parent\">&gt;</a>");
                }
            }
            sb.Append("<a href='" + urlendgin + "' target=\"_parent\">尾页</a></div>");
            //sb.Append("<div class=\"Points_Page_data\">每页<span class=\"f_red strong\">40</span>个 第<span class=\"f_red strong\">" + num + "</span>页/共<span class=\"f_red strong\">" + pagecc + "</span>页</div>");
            sb.Append("<div class=\"clear\"></div>");

            return sb.ToString();
        }

        #endregion

        #region 区域加行业静态生成

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int InduyCountPage(int areid,string Induy)
        {

            string num = "";
            string sql = "select count(InfoID)  from MerchantInfoTab where ProvinceID=@areid and  IndustryClassList like '%" + Induy + "%' ";
            SqlParameter[] para ={ 
                new SqlParameter("@areid",SqlDbType.Int,8)
            };
            para[0].Value = areid;
            num = Convert.ToString(SearchDBHelper.GetSingle(sql, para));
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 判断总共有多少个页面数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int InduypageS(int areid,string Induy)
        {
            int pagecc = 0;//总共多少个页面
            int countpage = InduyCountPage(areid,Induy);//总共多少条
            //pagecc = countpage >= 40 ? (countpage % 40 == 0 ? countpage / 40 : countpage / 40 + 1) : 1;
            pagecc = countpage >= 10 ? (countpage % 10 == 0 ? countpage / 10 : countpage / 10 + 1) : 1;
            return pagecc;
        }



        public void InduySelState(int num, int areid,string Induy)
        {
            StringBuilder sbl = new StringBuilder();

            Common.Text common = new Common.Text();
            string arelist = dal.dvGetProveName(Convert.ToString(areid));
            #region 属性封装
            string InfoID = "";
            string Title;
            string publishT = "";
            string Hit;
            string LoginName;
            string FixPriceID;
            string HtmlFile;
            string ProvinceID;
            string CountyID;
            string IndustryClassList;
            string CityID;
            string CapitalTotal = "";
            string ValidateTerm = "";
            string ZoneAbout;
            string isVIP = "";
            string CapitalCurrency;
            string AuditingStatus = "";
            string CountryCode;
            #endregion
            StringBuilder sb = new StringBuilder();
            string sql = "SELECT top 10 [InfoID] ,[Title],[publishT],[Hit],[FixPriceID],[HtmlFile],[ProvinceID],[CountyID],[IndustryClassList],[CityID],"
             + "[CapitalTotal],[ValidateTerm],[ZoneAbout] ,[CapitalCurrency],[AuditingStatus],[CountryCode]FROM [Search].[dbo].[MerchantInfoTab] where ProvinceID=" + areid + " and  IndustryClassList like '%" + Induy + "%'  and infoID not in  (select top " + 10 * (num - 1) + " infoID from [Search].[dbo].[MerchantInfoTab] where ProvinceID='" + areid + "' and  IndustryClassList like '%" + Induy + "%' order by  publishT desc   )  order by  publishT desc";

            DataSet ds = SearchDBHelper.Query(sql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    if (ds.Tables[0].Rows[i]["InfoID"].ToString() != "")
                    {
                        InfoID = ds.Tables[0].Rows[i]["InfoID"].ToString();
                    }
                    Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    if (ds.Tables[0].Rows[i]["publishT"].ToString() != "")
                    {
                        publishT = ds.Tables[0].Rows[i]["publishT"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["Hit"].ToString() != "")
                    {
                        Hit = ds.Tables[0].Rows[i]["Hit"].ToString();
                    }
                    FixPriceID = ds.Tables[0].Rows[i]["FixPriceID"].ToString();
                    HtmlFile = ds.Tables[0].Rows[i]["HtmlFile"].ToString();
                    ProvinceID = ds.Tables[0].Rows[i]["ProvinceID"].ToString();
                    CountyID = ds.Tables[0].Rows[i]["CountyID"].ToString();
                    IndustryClassList = ds.Tables[0].Rows[i]["IndustryClassList"].ToString();
                    CityID = ds.Tables[0].Rows[i]["CityID"].ToString();
                    if (ds.Tables[0].Rows[i]["CapitalTotal"].ToString() != "")
                    {
                        CapitalTotal = ds.Tables[0].Rows[i]["CapitalTotal"].ToString() + "万元";

                    }
                    else
                    {
                        CapitalTotal = "暂未填写";
                    }
                    if (ds.Tables[0].Rows[i]["ValidateTerm"].ToString() != "")
                    {
                        ValidateTerm = ds.Tables[0].Rows[i]["ValidateTerm"].ToString();
                    }
                    ZoneAbout = ds.Tables[0].Rows[i]["ZoneAbout"].ToString();

                    CapitalCurrency = ds.Tables[0].Rows[i]["CapitalCurrency"].ToString();
                    if (ds.Tables[0].Rows[i]["AuditingStatus"].ToString() != "")
                    {
                        AuditingStatus = ds.Tables[0].Rows[i]["AuditingStatus"].ToString();
                    }
                    CountryCode = ds.Tables[0].Rows[i]["CountryCode"].ToString();

                    sb.Append("<ul>");
                    sb.Append("<li>");
                    sb.Append("<div class=\"ziyuan-list-1\">");
                    sb.Append("<input type=\"checkbox\" name=\"checkboxRecord\" value=" + InfoID + " />");
                    sb.Append("</div>");
                    sb.Append("<div class=\"ziyuan-list-2\"><img src=\"http://search.topfo.com/images/search_34.jpg\" /></div>");
                    sb.Append("<div class=\"ziyuan-list-3\">");
                    sb.Append("<h3><a href=\"http://www.topfo.com/" + HtmlFile + "\" class=\"f_lan-bd\" target=\"_blank\"> " + Title.ToString().Trim() + "</a></h3>");
                    sb.Append("<div style=\" color:#666; margin-bottom:6px\">" + dal.FixLenth(common.ThrowHtml(ZoneAbout), 110, "....") + "</div>");
                    sb.Append("<div> <span class=\"ziyuan-list-3-a1\">状态：<span class=\"f_org\">[已审核]</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">总金额：<span class=\"f_org\">" + CapitalTotal + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">地区：<span class=\"f_org\">" + arelist + "  " + dal.dvGetCa(CityID) + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-b1\">行业：<span class=\"f_org\">" + dal.IndustrySelect(IndustryClassList) + "</span></span> </div>");
                    sb.Append("<div  class=\"f_gray \" style=\"clear:both\">发布时间:  " + publishT.Substring(0, 9).Trim() + "  有效时间：" + SelectValidate(ValidateTerm) + "</div>");
                    sb.Append("</div>");
                    sb.Append("<div  class=\"ziyuan-list-4\">");
                    sb.Append("<a href=\"http://www.topfo.com/" + HtmlFile + "\" target=\"_blank\"><img src=\"http://search.topfo.com/images/search_38.jpg\" /></a>");
                    sb.Append(" </div>");
                    sb.Append(" </li>");
                    sb.Append("</ul>");

                }
                string pageIndex = InduyPage(num, areid, Induy);
                InduyHtmlPage(num, sb.ToString(), pageIndex, areid, arelist, Induy);

            }
            else
            {
                InduyHtmlPage(num, sb.ToString(), "暂未搜索到该资源", areid, arelist, Induy);
            }


        }

        public void InduyHtmlPage(int num, string state, string page, int areid, string areList,string Induy)
        {


         
            string InduyLists = "";
            string InduyListss = "";
            string InduyList = "";
            if (Induy.ToString().Trim() != null)
            {


                #region MyRegion
                switch (Induy)
                {
                    case "#": InduyListss = "批发零售"; InduyLists = "0"; InduyList = "0"; break;
                    case "$": InduyListss = "房地产业"; InduyLists = "1"; InduyList = "1"; break;
                    case "*": InduyListss = "其他行业"; InduyLists = "2"; InduyList = "2"; break;
                    case "A": InduyListss = "农林牧渔"; InduyLists = "3"; InduyList = "3"; break;
                    case "B": InduyListss = "食品饮料"; InduyLists = "4"; InduyList = "4"; break;
                    case "C": InduyListss = "冶金矿产"; InduyLists = "5"; InduyList = "5"; break;
                    case "D": InduyListss = "机械制造"; InduyLists = "6"; InduyList = "6"; break;
                    case "E": InduyListss = "汽车汽配"; InduyLists = "7"; InduyList = "7"; break;
                    case "F": InduyListss = "能源动力"; InduyLists = "8"; InduyList = "8"; break;
                    case "G": InduyListss = "石油化工"; InduyLists = "9"; InduyList = "9"; break;
                    case "H": InduyListss = "纺织服装"; InduyLists = "10"; InduyList = "10"; break;
                    case "I": InduyListss = "环境保护"; InduyLists = "11"; InduyList = "11"; break;
                    case "J": InduyListss = "医疗保健"; InduyLists = "12"; InduyList = "12"; break;
                    case "K": InduyListss = "生物科技"; InduyLists = "13"; InduyList = "13"; break;
                    case "L": InduyListss = "教育培训"; InduyLists = "14"; InduyList = "14"; break;
                    case "M": InduyListss = "印刷出版"; InduyLists = "15"; InduyList = "15"; break;
                    case "N": InduyListss = "广告传媒"; InduyLists = "16"; InduyList = "16"; break;
                    case "O": InduyListss = "影视娱乐"; InduyLists = "17"; InduyList = "17"; break;
                    case "P": InduyListss = "电子通讯"; InduyLists = "18"; InduyList = "18"; break;
                    case "Q": InduyListss = "建筑建材"; InduyLists = "19"; InduyList = "19"; break;
                    case "R": InduyListss = "信息产业"; InduyLists = "20"; InduyList = "20"; break;
                    case "S": InduyListss = "高新技术"; InduyLists = "21"; InduyList = "21"; break;
                    case "T": InduyListss = "基础设施"; InduyLists = "22"; InduyList = "22"; break;
                    case "U": InduyListss = "交通运输"; InduyLists = "23"; InduyList = "23"; break;
                    case "V": InduyListss = "物流仓储"; InduyLists = "24"; InduyList = "24"; break;
                    case "W": InduyListss = "金融投资"; InduyLists = "25"; InduyList = "25"; break;
                    case "X": InduyListss = "旅游休闲"; InduyLists = "26"; InduyList = "26"; break;
                    case "Y": InduyListss = "社会服务"; InduyLists = "27"; InduyList = "27"; break;
                    case "Z": InduyListss = "酒店餐饮"; InduyLists = "28"; InduyList = "28"; break;
                }
                #endregion

            }
          
      
          
          
            string KeyWord = "" + areList + "" + InduyListss + "招商项目," + areList + "" + InduyListss + " 招商项目新资讯";
            string Descript = "有关" + areList + "" + InduyListss + " 招商项目信息汇总，招商项目频道，全国最新" + areList + "" + InduyListss + "招商项目信息发布，让投资者更快找到" + areList + " " + InduyListss + "招商项目相关的投资项目和项目信息，展示哪些企业的招商项目；同时也为企业提供全国优秀" + areList + "招商项目资讯，让企业更快找到" + areList + "招商项目相关信息。";
            string DisplayTitle = "" + areList + "" + InduyListss + "招商项目|" + areList + "" + InduyListss + "招商项目信息汇总|招商项目 " + areList + "" + InduyListss + "项目分类 - 中国招商投资网";
            string TempFileName = NewSumTem.ToString();
            string Tem = Compage.Reader(TempFileName); //读取模板内容
            #region 替换模版
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$KeyWord$", KeyWord);//网页关键字
            TempSoure = TempSoure.Replace("$Descript$", Descript);//网页描述
            TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);//网页标题
           
            TempSoure = TempSoure.Replace("$State$", state);
            TempSoure = TempSoure.Replace("$Page$", page);
            TempSoure = TempSoure.Replace("$QuYuAre$", areList);
            TempSoure = TempSoure.Replace("$QAreList$",Convert.ToString(areid));

            
            

            #endregion

            string wenjian = NewSumPath;
            if (Directory.Exists(wenjian) == false)
            {
                Directory.CreateDirectory(wenjian);
            }

            string htmlpaths = wenjian + "\\zs" + areid + "_" + InduyList + "_" + num + ".shtml";
            Compage.Writer(htmlpaths, TempSoure);
        }


        public string InduyPage(int num, int areid,string Induy)
        {
            string InduyList = "";
            if (Induy.ToString().Trim() != null)
            {

               
                switch (Induy)
                {
                   case"#": InduyList = "0"; break;        
                   case"$": InduyList = "1"; break;                 
                   case"*": InduyList = "2"; break;                 
                   case"A": InduyList = "3"; break;                 
                   case "B": InduyList = "4"; break;                 
                   case "C":  InduyList = "5"; break;                 
                   case "D": InduyList = "6"; break;                 
                   case "E": InduyList = "7"; break;                
                   case "F": InduyList = "8"; break;                 
                   case "G": InduyList = "9"; break;                 
                   case "H": InduyList = "10"; break;                 
                   case "I": InduyList = "11"; break;        
                   case "J": InduyList = "12"; break;        
                   case "K": InduyList = "13"; break;        
                   case "L": InduyList = "14"; break;        
                   case "M": InduyList = "15"; break;        
                   case "N": InduyList = "16"; break;      
                   case "O": InduyList = "17"; break;               
                   case "P": InduyList = "18"; break;               
                   case "Q": InduyList = "19"; break;               
                   case "R": InduyList = "20"; break;        
                   case "S": InduyList = "21"; break;
                   case "T": InduyList = "22"; break;        
                   case "U": InduyList = "23"; break;        
                   case "V": InduyList = "24"; break;        
                   case "W": InduyList = "25"; break;        
                  case  "X": InduyList = "26"; break;        
                  case  "Y": InduyList = "27"; break;        
                  case  "Z": InduyList = "28"; break;        
                }
             
            }

            StringBuilder sb = new StringBuilder();
            int pagecc = InduypageS(areid,Induy);
            sb.Append("<div class=\"Points_Page_sub\">");
            string urlbegin = "zs" + areid + "_" +Convert.ToInt32(InduyList )+ "_" + 1 + ".shtml";//首页
            string urlendgin = "zs" + areid + "_" + Convert.ToInt32(InduyList) +"_" + pagecc + ".shtml";//尾页
            sb.Append("<a href='" + urlbegin + "' target=\"_parent\">首页</a>");
            if (pagecc == 1)
            {
                sb.Append("<span>1</span>");
            }
            else
            {
                string urlon = "zs" + areid + "_" + Convert.ToInt32(InduyList) + "_" + (num - 1) + ".shtml";//上一页
                string urldown = "zs" + areid + "_" + Convert.ToInt32(InduyList) + "_" + (num + 1) + ".shtml";//下一页
                if (num != 1)
                {
                    sb.Append("<a href='" + urlon + "' target=\"_parent\">&lt;</a>");
                }
                for (int j = (num / 9 * 8) + 1; j <= (pagecc >= ((num / 9 * 8) + 9) ? ((num / 9 * 8) + 9) : pagecc); j++)
                {
                    string urlZ = "zs" + areid + "_" + Convert.ToInt32(InduyList) +"_" + j + ".shtml";
                    if (j == num)
                    {
                        sb.Append("<a href='" + urlZ + "' class=\"anpager\" target=\"_parent\">" + j + "</a>");
                    }
                    else
                    {
                        sb.Append("<a href='" + urlZ + "' target=\"_parent\">" + j + "</a>");
                    }

                }
                if (num != pagecc)
                {
                    sb.Append("<a href='" + urldown + "'  target=\"_parent\">&gt;</a>");
                }
            }
            sb.Append("<a href='" + urlendgin + "' target=\"_parent\">尾页</a></div>");
            //sb.Append("<div class=\"Points_Page_data\">每页<span class=\"f_red strong\">40</span>个 第<span class=\"f_red strong\">" + num + "</span>页/共<span class=\"f_red strong\">" + pagecc + "</span>页</div>");
            sb.Append("<div class=\"clear\"></div>");

            return sb.ToString();
   
        }

        #endregion


        #region 行业静态生成

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int InduyCountPageList(string Induy)
        {

            string num = "";
            string sql = "select count(InfoID)  from MerchantInfoTab where   IndustryClassList like '%" + Induy + "%' ";
           
            num = Convert.ToString(SearchDBHelper.GetSingle(sql));
            return Convert.ToInt32(num);
        }
        /// <summary>
        /// 判断总共有多少个页面数
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int InduypageSList( string Induy)
        {
            int pagecc = 0;//总共多少个页面
            int countpage = InduyCountPageList( Induy);//总共多少条
            //pagecc = countpage >= 40 ? (countpage % 40 == 0 ? countpage / 40 : countpage / 40 + 1) : 1;
            pagecc = countpage >= 10 ? (countpage % 10 == 0 ? countpage / 10 : countpage / 10 + 1) : 1;
            return pagecc;
        }



        public void InduySelStateList(int num,  string Induy)
        {
            StringBuilder sbl = new StringBuilder();

            Common.Text common = new Common.Text();
            #region 属性封装
            string InfoID = "";
            string Title;
            string publishT = "";
            string Hit;
            string LoginName;
            string FixPriceID;
            string HtmlFile;
            string ProvinceID;
            string CountyID;
            string IndustryClassList;
            string CityID;
            string CapitalTotal = "";
            string ValidateTerm = "";
            string ZoneAbout;
            string isVIP = "";
            string CapitalCurrency;
            string AuditingStatus = "";
            string CountryCode;
            #endregion
            StringBuilder sb = new StringBuilder();
            string sql = "SELECT top 10 [InfoID] ,[Title],[publishT],[Hit],[FixPriceID],[HtmlFile],[ProvinceID],[CountyID],[IndustryClassList],[CityID],"
             + "[CapitalTotal],[ValidateTerm],[ZoneAbout] ,[CapitalCurrency],[AuditingStatus],[CountryCode]FROM [Search].[dbo].[MerchantInfoTab] where   IndustryClassList like '%" + Induy + "%'  and infoID not in  (select top " + 10 * (num - 1) + " infoID from [Search].[dbo].[MerchantInfoTab] where   IndustryClassList like '%" + Induy + "%' order by  publishT desc   )  order by  publishT desc";

            DataSet ds = SearchDBHelper.Query(sql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    if (ds.Tables[0].Rows[i]["InfoID"].ToString() != "")
                    {
                        InfoID = ds.Tables[0].Rows[i]["InfoID"].ToString();
                    }
                    Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    if (ds.Tables[0].Rows[i]["publishT"].ToString() != "")
                    {
                        publishT = ds.Tables[0].Rows[i]["publishT"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["Hit"].ToString() != "")
                    {
                        Hit = ds.Tables[0].Rows[i]["Hit"].ToString();
                    }
                    FixPriceID = ds.Tables[0].Rows[i]["FixPriceID"].ToString();
                    HtmlFile = ds.Tables[0].Rows[i]["HtmlFile"].ToString();
                    ProvinceID = ds.Tables[0].Rows[i]["ProvinceID"].ToString();
                    CountyID = ds.Tables[0].Rows[i]["CountyID"].ToString();
                    IndustryClassList = ds.Tables[0].Rows[i]["IndustryClassList"].ToString();
                    CityID = ds.Tables[0].Rows[i]["CityID"].ToString();
                    if (ds.Tables[0].Rows[i]["CapitalTotal"].ToString() != "")
                    {
                        CapitalTotal = ds.Tables[0].Rows[i]["CapitalTotal"].ToString() + "万元";

                    }
                    else
                    {
                        CapitalTotal = "暂未填写";
                    }
                    if (ds.Tables[0].Rows[i]["ValidateTerm"].ToString() != "")
                    {
                        ValidateTerm = ds.Tables[0].Rows[i]["ValidateTerm"].ToString();
                    }
                    ZoneAbout = ds.Tables[0].Rows[i]["ZoneAbout"].ToString();

                    CapitalCurrency = ds.Tables[0].Rows[i]["CapitalCurrency"].ToString();
                    if (ds.Tables[0].Rows[i]["AuditingStatus"].ToString() != "")
                    {
                        AuditingStatus = ds.Tables[0].Rows[i]["AuditingStatus"].ToString();
                    }
                    CountryCode = ds.Tables[0].Rows[i]["CountryCode"].ToString();

                    sb.Append("<ul>");
                    sb.Append("<li>");
                    sb.Append("<div class=\"ziyuan-list-1\">");
                    sb.Append("<input type=\"checkbox\" name=\"checkboxRecord\" value=" + InfoID + " />");
                    sb.Append("</div>");
                    sb.Append("<div class=\"ziyuan-list-2\"><img src=\"http://search.topfo.com/images/search_34.jpg\" /></div>");
                    sb.Append("<div class=\"ziyuan-list-3\">");
                    sb.Append("<h3><a href=\"http://www.topfo.com/" + HtmlFile + "\" class=\"f_lan-bd\" target=\"_blank\"> " + Title.ToString().Trim() + "</a></h3>");
                    sb.Append("<div style=\" color:#666; margin-bottom:6px\">" + dal.FixLenth(common.ThrowHtml(ZoneAbout), 110, "....") + "</div>");
                    sb.Append("<div> <span class=\"ziyuan-list-3-a1\">状态：<span class=\"f_org\">[已审核]</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">总金额：<span class=\"f_org\">" + CapitalTotal + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">地区：<span class=\"f_org\">" + dal.dvGetProveName(ProvinceID) + "   " + dal.dvGetCa(CityID) + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-b1\">行业：<span class=\"f_org\">" + dal.IndustrySelect(IndustryClassList) + "</span></span> </div>");
                    sb.Append("<div  class=\"f_gray \" style=\"clear:both\">发布时间:  " + publishT.Substring(0, 9).Trim() + "  有效时间：" + SelectValidate(ValidateTerm) + "</div>");
                    sb.Append("</div>");
                    sb.Append("<div  class=\"ziyuan-list-4\">");
                    sb.Append("<a href=\"http://www.topfo.com/" + HtmlFile + "\" target=\"_blank\"><img src=\"http://search.topfo.com/images/search_38.jpg\" /></a>");
                    sb.Append(" </div>");
                    sb.Append(" </li>");
                    sb.Append("</ul>");

                }
                string pageIndex = InduyPageList(num,  Induy);
                InduyHtmlPageList(num, sb.ToString(), pageIndex,   Induy);

            }
            else
            {
                InduyHtmlPageList(num, sb.ToString(), "暂未搜索到该资源", Induy);
            }


        }

        public void InduyHtmlPageList(int num, string state, string page,   string Induy)
        {
            #region MyRegion
            string InduyList = "";
            if (Induy.ToString().Trim() != null)
            {


                #region MyRegion
                switch (Induy)
                {
                    case "#": InduyList = "批发零售"; break;
                    case "$": InduyList = "房地产业"; break;
                    case "*": InduyList = "其他行业"; break;
                    case "A": InduyList = "农林牧渔"; break;
                    case "B": InduyList = "食品饮料"; break;
                    case "C": InduyList = "冶金矿产"; break;
                    case "D": InduyList = "机械制造"; break;
                    case "E": InduyList = "汽车汽配"; break;
                    case "F": InduyList = "能源动力"; break;
                    case "G": InduyList = "石油化工"; break;
                    case "H": InduyList = "纺织服装"; break;
                    case "I": InduyList = "环境保护"; break;
                    case "J": InduyList = "医疗保健"; break;
                    case "K": InduyList = "生物科技"; break;
                    case "L": InduyList = "教育培训"; break;
                    case "M": InduyList = "印刷出版"; break;
                    case "N": InduyList = "广告传媒"; break;
                    case "O": InduyList = "影视娱乐"; break;
                    case "P": InduyList = "电子通讯"; break;
                    case "Q": InduyList = "建筑建材"; break;
                    case "R": InduyList = "信息产业"; break;
                    case "S": InduyList = "高新技术"; break;
                    case "T": InduyList = "基础设施"; break;
                    case "U": InduyList = "交通运输"; break;
                    case "V": InduyList = "物流仓储"; break;
                    case "W": InduyList = "金融投资"; break;
                    case "X": InduyList = "旅游休闲"; break;
                    case "Y": InduyList = "社会服务"; break;
                    case "Z": InduyList = "酒店餐饮"; break;
                }
                #endregion

            }
            string InduyLists = "";
            if (Induy.ToString().Trim() != null)
            {


                switch (Induy)
                {
                    case "#": InduyLists = "0"; break;
                    case "$": InduyLists = "1"; break;
                    case "*": InduyLists = "2"; break;
                    case "A": InduyLists = "3"; break;
                    case "B": InduyLists = "4"; break;
                    case "C": InduyLists = "5"; break;
                    case "D": InduyLists = "6"; break;
                    case "E": InduyLists = "7"; break;
                    case "F": InduyLists = "8"; break;
                    case "G": InduyLists = "9"; break;
                    case "H": InduyLists = "10"; break;
                    case "I": InduyLists = "11"; break;
                    case "J": InduyLists = "12"; break;
                    case "K": InduyLists = "13"; break;
                    case "L": InduyLists = "14"; break;
                    case "M": InduyLists = "15"; break;
                    case "N": InduyLists = "16"; break;
                    case "O": InduyLists = "17"; break;
                    case "P": InduyLists = "18"; break;
                    case "Q": InduyLists = "19"; break;
                    case "R": InduyLists = "20"; break;
                    case "S": InduyLists = "21"; break;
                    case "T": InduyLists = "22"; break;
                    case "U": InduyLists = "23"; break;
                    case "V": InduyLists = "24"; break;
                    case "W": InduyLists = "25"; break;
                    case "X": InduyLists = "26"; break;
                    case "Y": InduyLists = "27"; break;
                    case "Z": InduyLists = "28"; break;
                }

            } 
            #endregion

            string KeyWord = "" + InduyList + "招商项目, " + InduyList + "招商项目新资讯";
            string Descript = "有关" + InduyList + "招商项目信息汇总，招商项目频道，全国最新" + InduyList + "招商项目信息发布，让投资者更快找到" + InduyList + "招商项目相关的投资项目和项目信息，展示哪些企业的招商项目；同时也为企业提供全国优秀" + InduyList + "招商项目资讯，让企业更快找到" + InduyList + "招商项目相关信息。";
            string DisplayTitle = "" + InduyList + "招商项目|" + InduyList + "招商项目信息汇总|招商项目 " + InduyList + "项目分类 - 中国招商投资网";
            string TempFileName = NewSumTemInduy.ToString();
            string Tem = GZS.DAL.Compage.Reader(TempFileName); //读取模板内容
            #region 替换模版
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$KeyWord$", KeyWord);//网页关键字
            TempSoure = TempSoure.Replace("$Descript$", Descript);//网页描述
            TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);//网页标题

            TempSoure = TempSoure.Replace("$State$", state);
            TempSoure = TempSoure.Replace("$Page$", page);





            #endregion

            string wenjian = NewSumPath;
            if (Directory.Exists(wenjian) == false)
            {
                Directory.CreateDirectory(wenjian);
            }

            string htmlpaths = wenjian + "\\zsInduy_" + InduyLists + "_" + num + ".shtml";
            GZS.DAL.Compage.Writer(htmlpaths, TempSoure);
        }


        public string InduyPageList(int num,  string Induy)
        {
            #region MyRegion
            string InduyList = "";
            if (Induy.ToString().Trim() != null)
            {


                switch (Induy)
                {
                    case "#": InduyList = "0"; break;
                    case "$": InduyList = "1"; break;
                    case "*": InduyList = "2"; break;
                    case "A": InduyList = "3"; break;
                    case "B": InduyList = "4"; break;
                    case "C": InduyList = "5"; break;
                    case "D": InduyList = "6"; break;
                    case "E": InduyList = "7"; break;
                    case "F": InduyList = "8"; break;
                    case "G": InduyList = "9"; break;
                    case "H": InduyList = "10"; break;
                    case "I": InduyList = "11"; break;
                    case "J": InduyList = "12"; break;
                    case "K": InduyList = "13"; break;
                    case "L": InduyList = "14"; break;
                    case "M": InduyList = "15"; break;
                    case "N": InduyList = "16"; break;
                    case "O": InduyList = "17"; break;
                    case "P": InduyList = "18"; break;
                    case "Q": InduyList = "19"; break;
                    case "R": InduyList = "20"; break;
                    case "S": InduyList = "21"; break;
                    case "T": InduyList = "22"; break;
                    case "U": InduyList = "23"; break;
                    case "V": InduyList = "24"; break;
                    case "W": InduyList = "25"; break;
                    case "X": InduyList = "26"; break;
                    case "Y": InduyList = "27"; break;
                    case "Z": InduyList = "28"; break;
                }

            } 
            #endregion

            StringBuilder sb = new StringBuilder();
            int pagecc = InduypageSList(Induy);
            sb.Append("<div class=\"Points_Page_sub\">");
            string urlbegin = "zsInduy_" + Convert.ToInt32(InduyList) + "_" + 1 + ".shtml";//首页
            string urlendgin = "zsInduy_" + Convert.ToInt32(InduyList) + "_" + pagecc + ".shtml";//尾页
            sb.Append("<a href='" + urlbegin + "' target=\"_parent\">首页</a>");
            if (pagecc == 1)
            {
                sb.Append("<span>1</span>");
            }
            else
            {
                string urlon = "zsInduy_" + Convert.ToInt32(InduyList) + "_" + (num - 1) + ".shtml";//上一页
                string urldown = "zsInduy_" + Convert.ToInt32(InduyList) + "_" + (num + 1) + ".shtml";//下一页
                if (num != 1)
                {
                    sb.Append("<a href='" + urlon + "' target=\"_parent\">&lt;</a>");
                }
                for (int j = (num / 9 * 8) + 1; j <= (pagecc >= ((num / 9 * 8) + 9) ? ((num / 9 * 8) + 9) : pagecc); j++)
                {
                    string urlZ = "zsInduy_" + Convert.ToInt32(InduyList) + "_" + j + ".shtml";
                    if (j == num)
                    {
                        sb.Append("<a href='" + urlZ + "' class=\"anpager\" target=\"_parent\">" + j + "</a>");
                    }
                    else
                    {
                        sb.Append("<a href='" + urlZ + "' target=\"_parent\">" + j + "</a>");
                    }

                }
                if (num != pagecc)
                {
                    sb.Append("<a href='" + urldown + "'  target=\"_parent\">&gt;</a>");
                }
            }
            sb.Append("<a href='" + urlendgin + "' target=\"_parent\">尾页</a></div>");
            //sb.Append("<div class=\"Points_Page_data\">每页<span class=\"f_red strong\">40</span>个 第<span class=\"f_red strong\">" + num + "</span>页/共<span class=\"f_red strong\">" + pagecc + "</span>页</div>");
            sb.Append("<div class=\"clear\"></div>");

            return sb.ToString();

        }

        #endregion

        #region//查询是否有这条记录
        public bool SelMerchantInfo(int infoid)
        {
            string sql = "select count(*) from [Search].[dbo].[MerchantInfoTab] where infoid=@infoid";
            SqlParameter[] para ={ 
                new SqlParameter("@infoid",SqlDbType.Int,8)
            };
            para[0].Value = infoid;
           bool b=  SearchDBHelper.Exists(sql.ToString(),para);
          return b;
        }
        #endregion

    }
}
