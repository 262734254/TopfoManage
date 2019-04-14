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
        string NewSumPath = ConfigurationManager.AppSettings["SearchSumAppPath"].ToString(); //������ϸҳ������ҳ���ŵط�
        string NewSumTem = ConfigurationManager.AppSettings["SearchSumTem"].ToString(); //������ϸҳ��ģ����λ��
        string NewSumTemInduy = ConfigurationManager.AppSettings["SearchSumTemInduy"].ToString(); //������ϸҳ��ģ����λ��
        Common.Induy dal = new Tz888.SQLServerDAL.Common.Induy();
        #region IMerchant ��Ա
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="mainInfoModel">����Ϣ��ʵ����</param>
        /// <param name="MerchantModel">������Ϣ��ʵ����</param>
        /// <param name="shortInfoModel">����Ϣ��ʵ����</param>
        /// <returns></returns>
        public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel, MerchantModel MerchantModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// ����ͼ��ѯ������Ϣ
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria">����</param>
        /// <param name="Sort">����</param>
        /// <param name="Page">ÿҳ��ʾ������</param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount">����</param>
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
        /// ����������Ϣ
        /// </summary>
        /// <param name="mainInfoModel">����Ϣ��ʵ����</param>
        /// <param name="MerchantModel">������Ϣ��ʵ����</param>
        /// <param name="shortInfoModel">����Ϣ��ʵ����</param>
        /// <returns></returns>
        public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel, MerchantModel MerchantModel, Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// ����IDɾ��������Ϣ
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

      

        #region ����̬���� 

        /// <summary>
        /// ��ѯ������
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
        /// �ж��ܹ��ж��ٸ�ҳ����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int pageS(int areid)
        {
            int pagecc = 0;//�ܹ����ٸ�ҳ��
            int countpage = CountPage(areid);//�ܹ�������
          //pagecc = countpage >= 40 ? (countpage % 40 == 0 ? countpage / 40 : countpage / 40 + 1) : 1;
            pagecc = countpage >= 10 ? (countpage % 10 == 0 ? countpage / 10 : countpage / 10 + 1) : 1;
            return pagecc;
        }



        public void SelState(int num, int areid)
        {
            StringBuilder sbl = new StringBuilder();

            Common.Text common = new Common.Text();
            string arelist = dal.dvGetProveName( Convert.ToString(areid));
            #region ���Է�װ
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
                        CapitalTotal = ds.Tables[0].Rows[i]["CapitalTotal"].ToString() + "��Ԫ";

                    }
                    else
                    {
                        CapitalTotal = "��δ��д";
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
                    sb.Append("<div> <span class=\"ziyuan-list-3-a1\">״̬��<span class=\"f_org\">[�����]</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">�ܽ�<span class=\"f_org\">" + CapitalTotal + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">������<span class=\"f_org\">" + arelist + "  " + dal.dvGetCa(CityID) + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-b1\">��ҵ��<span class=\"f_org\">" + dal.IndustrySelect(IndustryClassList) + "</span></span> </div>");
                    sb.Append("<div  class=\"f_gray \" style=\"clear:both\">����ʱ��:  " + publishT.Substring(0, 9).Trim() + "  ��Чʱ�䣺" + SelectValidate(ValidateTerm) + "</div>");
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
                HtmlPage(num, sb.ToString(), "��δ����������Դ", areid, arelist);
            }

         
        }

        public void HtmlPage(int num, string state, string page, int areid, string areList)
        {
            string KeyWord = "" + areList + "������Ŀ, " + areList + "������Ŀ����Ѷ";
            string Descript = "�й�" + areList + "������Ŀ��Ϣ���ܣ�������ĿƵ����ȫ������" + areList + "������Ŀ��Ϣ��������Ͷ���߸����ҵ�" + areList + "������Ŀ��ص�Ͷ����Ŀ����Ŀ��Ϣ��չʾ��Щ��ҵ��������Ŀ��ͬʱҲΪ��ҵ�ṩȫ������" + areList + "������Ŀ��Ѷ������ҵ�����ҵ�" + areList + "������Ŀ�����Ϣ��";
            string DisplayTitle = "" + areList + "������Ŀ|" + areList + "������Ŀ��Ϣ����|������Ŀ " + areList + "��Ŀ���� - �й�����Ͷ����";
            string TempFileName = NewSumTem.ToString();
            string Tem = Compage.Reader(TempFileName); //��ȡģ������
            #region �滻ģ��
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$KeyWord$", KeyWord);//��ҳ�ؼ���
            TempSoure = TempSoure.Replace("$Descript$", Descript);//��ҳ����
            TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);//��ҳ����

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
        /// ������������
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
        #region ��Ч��ת��
        /// <summary>
        /// ��Ч��ת��
        /// </summary>
        /// <param name="ValidateTerm"></param>
        /// <returns></returns>
        public string SelectValidate(string ValidateTerm)
        {
            switch (ValidateTerm.ToString().Trim())
            {
                case "3": ValidateTerm = "3����"; break;
                case "6": ValidateTerm = "6����"; break;
                case "36": ValidateTerm = "3��"; break;
                case "60": ValidateTerm = "5��"; break;
                case "12": ValidateTerm = "1��"; break;
                case "24": ValidateTerm = "2��"; break;
            }
            return ValidateTerm;
        }

        #endregion
        public string Page(int num, int areid)
        {
            StringBuilder sb = new StringBuilder();
            int pagecc = pageS(areid);
            sb.Append("<div class=\"Points_Page_sub\">");
            string urlbegin = "zs" + areid + "_" + 1 + ".shtml";//��ҳ
            string urlendgin = "zs" + areid + "_" + pagecc + ".shtml";//βҳ
            sb.Append("<a href='" + urlbegin + "' target=\"_parent\">��ҳ</a>");
            if (pagecc == 1)
            {
                sb.Append("<span>1</span>");
            }
            else
            {
                string urlon = "zs" + areid + "_" + (num - 1) + ".shtml";//��һҳ
                string urldown = "zs"+ areid + "_" + (num + 1) + ".shtml";//��һҳ
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
            sb.Append("<a href='" + urlendgin + "' target=\"_parent\">βҳ</a></div>");
            //sb.Append("<div class=\"Points_Page_data\">ÿҳ<span class=\"f_red strong\">40</span>�� ��<span class=\"f_red strong\">" + num + "</span>ҳ/��<span class=\"f_red strong\">" + pagecc + "</span>ҳ</div>");
            sb.Append("<div class=\"clear\"></div>");

            return sb.ToString();
        }

        #endregion

        #region �������ҵ��̬����

        /// <summary>
        /// ��ѯ������
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
        /// �ж��ܹ��ж��ٸ�ҳ����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int InduypageS(int areid,string Induy)
        {
            int pagecc = 0;//�ܹ����ٸ�ҳ��
            int countpage = InduyCountPage(areid,Induy);//�ܹ�������
            //pagecc = countpage >= 40 ? (countpage % 40 == 0 ? countpage / 40 : countpage / 40 + 1) : 1;
            pagecc = countpage >= 10 ? (countpage % 10 == 0 ? countpage / 10 : countpage / 10 + 1) : 1;
            return pagecc;
        }



        public void InduySelState(int num, int areid,string Induy)
        {
            StringBuilder sbl = new StringBuilder();

            Common.Text common = new Common.Text();
            string arelist = dal.dvGetProveName(Convert.ToString(areid));
            #region ���Է�װ
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
                        CapitalTotal = ds.Tables[0].Rows[i]["CapitalTotal"].ToString() + "��Ԫ";

                    }
                    else
                    {
                        CapitalTotal = "��δ��д";
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
                    sb.Append("<div> <span class=\"ziyuan-list-3-a1\">״̬��<span class=\"f_org\">[�����]</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">�ܽ�<span class=\"f_org\">" + CapitalTotal + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">������<span class=\"f_org\">" + arelist + "  " + dal.dvGetCa(CityID) + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-b1\">��ҵ��<span class=\"f_org\">" + dal.IndustrySelect(IndustryClassList) + "</span></span> </div>");
                    sb.Append("<div  class=\"f_gray \" style=\"clear:both\">����ʱ��:  " + publishT.Substring(0, 9).Trim() + "  ��Чʱ�䣺" + SelectValidate(ValidateTerm) + "</div>");
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
                InduyHtmlPage(num, sb.ToString(), "��δ����������Դ", areid, arelist, Induy);
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
                    case "#": InduyListss = "��������"; InduyLists = "0"; InduyList = "0"; break;
                    case "$": InduyListss = "���ز�ҵ"; InduyLists = "1"; InduyList = "1"; break;
                    case "*": InduyListss = "������ҵ"; InduyLists = "2"; InduyList = "2"; break;
                    case "A": InduyListss = "ũ������"; InduyLists = "3"; InduyList = "3"; break;
                    case "B": InduyListss = "ʳƷ����"; InduyLists = "4"; InduyList = "4"; break;
                    case "C": InduyListss = "ұ����"; InduyLists = "5"; InduyList = "5"; break;
                    case "D": InduyListss = "��е����"; InduyLists = "6"; InduyList = "6"; break;
                    case "E": InduyListss = "��������"; InduyLists = "7"; InduyList = "7"; break;
                    case "F": InduyListss = "��Դ����"; InduyLists = "8"; InduyList = "8"; break;
                    case "G": InduyListss = "ʯ�ͻ���"; InduyLists = "9"; InduyList = "9"; break;
                    case "H": InduyListss = "��֯��װ"; InduyLists = "10"; InduyList = "10"; break;
                    case "I": InduyListss = "��������"; InduyLists = "11"; InduyList = "11"; break;
                    case "J": InduyListss = "ҽ�Ʊ���"; InduyLists = "12"; InduyList = "12"; break;
                    case "K": InduyListss = "����Ƽ�"; InduyLists = "13"; InduyList = "13"; break;
                    case "L": InduyListss = "������ѵ"; InduyLists = "14"; InduyList = "14"; break;
                    case "M": InduyListss = "ӡˢ����"; InduyLists = "15"; InduyList = "15"; break;
                    case "N": InduyListss = "��洫ý"; InduyLists = "16"; InduyList = "16"; break;
                    case "O": InduyListss = "Ӱ������"; InduyLists = "17"; InduyList = "17"; break;
                    case "P": InduyListss = "����ͨѶ"; InduyLists = "18"; InduyList = "18"; break;
                    case "Q": InduyListss = "��������"; InduyLists = "19"; InduyList = "19"; break;
                    case "R": InduyListss = "��Ϣ��ҵ"; InduyLists = "20"; InduyList = "20"; break;
                    case "S": InduyListss = "���¼���"; InduyLists = "21"; InduyList = "21"; break;
                    case "T": InduyListss = "������ʩ"; InduyLists = "22"; InduyList = "22"; break;
                    case "U": InduyListss = "��ͨ����"; InduyLists = "23"; InduyList = "23"; break;
                    case "V": InduyListss = "�����ִ�"; InduyLists = "24"; InduyList = "24"; break;
                    case "W": InduyListss = "����Ͷ��"; InduyLists = "25"; InduyList = "25"; break;
                    case "X": InduyListss = "��������"; InduyLists = "26"; InduyList = "26"; break;
                    case "Y": InduyListss = "������"; InduyLists = "27"; InduyList = "27"; break;
                    case "Z": InduyListss = "�Ƶ����"; InduyLists = "28"; InduyList = "28"; break;
                }
                #endregion

            }
          
      
          
          
            string KeyWord = "" + areList + "" + InduyListss + "������Ŀ," + areList + "" + InduyListss + " ������Ŀ����Ѷ";
            string Descript = "�й�" + areList + "" + InduyListss + " ������Ŀ��Ϣ���ܣ�������ĿƵ����ȫ������" + areList + "" + InduyListss + "������Ŀ��Ϣ��������Ͷ���߸����ҵ�" + areList + " " + InduyListss + "������Ŀ��ص�Ͷ����Ŀ����Ŀ��Ϣ��չʾ��Щ��ҵ��������Ŀ��ͬʱҲΪ��ҵ�ṩȫ������" + areList + "������Ŀ��Ѷ������ҵ�����ҵ�" + areList + "������Ŀ�����Ϣ��";
            string DisplayTitle = "" + areList + "" + InduyListss + "������Ŀ|" + areList + "" + InduyListss + "������Ŀ��Ϣ����|������Ŀ " + areList + "" + InduyListss + "��Ŀ���� - �й�����Ͷ����";
            string TempFileName = NewSumTem.ToString();
            string Tem = Compage.Reader(TempFileName); //��ȡģ������
            #region �滻ģ��
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$KeyWord$", KeyWord);//��ҳ�ؼ���
            TempSoure = TempSoure.Replace("$Descript$", Descript);//��ҳ����
            TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);//��ҳ����
           
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
            string urlbegin = "zs" + areid + "_" +Convert.ToInt32(InduyList )+ "_" + 1 + ".shtml";//��ҳ
            string urlendgin = "zs" + areid + "_" + Convert.ToInt32(InduyList) +"_" + pagecc + ".shtml";//βҳ
            sb.Append("<a href='" + urlbegin + "' target=\"_parent\">��ҳ</a>");
            if (pagecc == 1)
            {
                sb.Append("<span>1</span>");
            }
            else
            {
                string urlon = "zs" + areid + "_" + Convert.ToInt32(InduyList) + "_" + (num - 1) + ".shtml";//��һҳ
                string urldown = "zs" + areid + "_" + Convert.ToInt32(InduyList) + "_" + (num + 1) + ".shtml";//��һҳ
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
            sb.Append("<a href='" + urlendgin + "' target=\"_parent\">βҳ</a></div>");
            //sb.Append("<div class=\"Points_Page_data\">ÿҳ<span class=\"f_red strong\">40</span>�� ��<span class=\"f_red strong\">" + num + "</span>ҳ/��<span class=\"f_red strong\">" + pagecc + "</span>ҳ</div>");
            sb.Append("<div class=\"clear\"></div>");

            return sb.ToString();
   
        }

        #endregion


        #region ��ҵ��̬����

        /// <summary>
        /// ��ѯ������
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
        /// �ж��ܹ��ж��ٸ�ҳ����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int InduypageSList( string Induy)
        {
            int pagecc = 0;//�ܹ����ٸ�ҳ��
            int countpage = InduyCountPageList( Induy);//�ܹ�������
            //pagecc = countpage >= 40 ? (countpage % 40 == 0 ? countpage / 40 : countpage / 40 + 1) : 1;
            pagecc = countpage >= 10 ? (countpage % 10 == 0 ? countpage / 10 : countpage / 10 + 1) : 1;
            return pagecc;
        }



        public void InduySelStateList(int num,  string Induy)
        {
            StringBuilder sbl = new StringBuilder();

            Common.Text common = new Common.Text();
            #region ���Է�װ
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
                        CapitalTotal = ds.Tables[0].Rows[i]["CapitalTotal"].ToString() + "��Ԫ";

                    }
                    else
                    {
                        CapitalTotal = "��δ��д";
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
                    sb.Append("<div> <span class=\"ziyuan-list-3-a1\">״̬��<span class=\"f_org\">[�����]</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">�ܽ�<span class=\"f_org\">" + CapitalTotal + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-a1\">������<span class=\"f_org\">" + dal.dvGetProveName(ProvinceID) + "   " + dal.dvGetCa(CityID) + "</span></span>");
                    sb.Append("<span class=\"ziyuan-list-3-b1\">��ҵ��<span class=\"f_org\">" + dal.IndustrySelect(IndustryClassList) + "</span></span> </div>");
                    sb.Append("<div  class=\"f_gray \" style=\"clear:both\">����ʱ��:  " + publishT.Substring(0, 9).Trim() + "  ��Чʱ�䣺" + SelectValidate(ValidateTerm) + "</div>");
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
                InduyHtmlPageList(num, sb.ToString(), "��δ����������Դ", Induy);
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
                    case "#": InduyList = "��������"; break;
                    case "$": InduyList = "���ز�ҵ"; break;
                    case "*": InduyList = "������ҵ"; break;
                    case "A": InduyList = "ũ������"; break;
                    case "B": InduyList = "ʳƷ����"; break;
                    case "C": InduyList = "ұ����"; break;
                    case "D": InduyList = "��е����"; break;
                    case "E": InduyList = "��������"; break;
                    case "F": InduyList = "��Դ����"; break;
                    case "G": InduyList = "ʯ�ͻ���"; break;
                    case "H": InduyList = "��֯��װ"; break;
                    case "I": InduyList = "��������"; break;
                    case "J": InduyList = "ҽ�Ʊ���"; break;
                    case "K": InduyList = "����Ƽ�"; break;
                    case "L": InduyList = "������ѵ"; break;
                    case "M": InduyList = "ӡˢ����"; break;
                    case "N": InduyList = "��洫ý"; break;
                    case "O": InduyList = "Ӱ������"; break;
                    case "P": InduyList = "����ͨѶ"; break;
                    case "Q": InduyList = "��������"; break;
                    case "R": InduyList = "��Ϣ��ҵ"; break;
                    case "S": InduyList = "���¼���"; break;
                    case "T": InduyList = "������ʩ"; break;
                    case "U": InduyList = "��ͨ����"; break;
                    case "V": InduyList = "�����ִ�"; break;
                    case "W": InduyList = "����Ͷ��"; break;
                    case "X": InduyList = "��������"; break;
                    case "Y": InduyList = "������"; break;
                    case "Z": InduyList = "�Ƶ����"; break;
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

            string KeyWord = "" + InduyList + "������Ŀ, " + InduyList + "������Ŀ����Ѷ";
            string Descript = "�й�" + InduyList + "������Ŀ��Ϣ���ܣ�������ĿƵ����ȫ������" + InduyList + "������Ŀ��Ϣ��������Ͷ���߸����ҵ�" + InduyList + "������Ŀ��ص�Ͷ����Ŀ����Ŀ��Ϣ��չʾ��Щ��ҵ��������Ŀ��ͬʱҲΪ��ҵ�ṩȫ������" + InduyList + "������Ŀ��Ѷ������ҵ�����ҵ�" + InduyList + "������Ŀ�����Ϣ��";
            string DisplayTitle = "" + InduyList + "������Ŀ|" + InduyList + "������Ŀ��Ϣ����|������Ŀ " + InduyList + "��Ŀ���� - �й�����Ͷ����";
            string TempFileName = NewSumTemInduy.ToString();
            string Tem = GZS.DAL.Compage.Reader(TempFileName); //��ȡģ������
            #region �滻ģ��
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$KeyWord$", KeyWord);//��ҳ�ؼ���
            TempSoure = TempSoure.Replace("$Descript$", Descript);//��ҳ����
            TempSoure = TempSoure.Replace("$DisplayTitle$", DisplayTitle);//��ҳ����

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
            string urlbegin = "zsInduy_" + Convert.ToInt32(InduyList) + "_" + 1 + ".shtml";//��ҳ
            string urlendgin = "zsInduy_" + Convert.ToInt32(InduyList) + "_" + pagecc + ".shtml";//βҳ
            sb.Append("<a href='" + urlbegin + "' target=\"_parent\">��ҳ</a>");
            if (pagecc == 1)
            {
                sb.Append("<span>1</span>");
            }
            else
            {
                string urlon = "zsInduy_" + Convert.ToInt32(InduyList) + "_" + (num - 1) + ".shtml";//��һҳ
                string urldown = "zsInduy_" + Convert.ToInt32(InduyList) + "_" + (num + 1) + ".shtml";//��һҳ
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
            sb.Append("<a href='" + urlendgin + "' target=\"_parent\">βҳ</a></div>");
            //sb.Append("<div class=\"Points_Page_data\">ÿҳ<span class=\"f_red strong\">40</span>�� ��<span class=\"f_red strong\">" + num + "</span>ҳ/��<span class=\"f_red strong\">" + pagecc + "</span>ҳ</div>");
            sb.Append("<div class=\"clear\"></div>");

            return sb.ToString();

        }

        #endregion

        #region//��ѯ�Ƿ���������¼
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
