using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Tz888.BLL.Company
{

    public class CompanyState
    {
        string ComPath = ConfigurationManager.AppSettings["ComPanyPath"].ToString(); //企业名片静态页面存放路径
        string ComTerm = ConfigurationManager.AppSettings["ComPanyTem"].ToString(); //企业名片模版存放位置



        Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();

        #region 企业名片静态页面生成
        public void ComPanyHtml(string CompanyID, string LoginName, string CompanyName, string IndustryName, string RangeName, string NatureName,
            string HtmlFile, string EstablishMent, string Employees, string Capital, string Introduction, string ServiceProce,
            string Title, string Keywords, string Description, string logo,string FronID)
        {
            CompanyBLL comBll = new CompanyBLL();
            string TempFileName = ComTerm.ToString();
            string seeLinkName = comBll.SelLinkName(Convert.ToInt32(CompanyID));
            string Tem = Compage.Reader(TempFileName); //读取模板内容
            #region 替换模版
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$CompanyId$", CompanyID);
            TempSoure = TempSoure.Replace("$CompanyName$", CompanyName);
            TempSoure = TempSoure.Replace("$IndustryName$", IndustryName);

            TempSoure = TempSoure.Replace("$RangeName$", RangeName);
            TempSoure = TempSoure.Replace("$NatureName$", NatureName);
            TempSoure = TempSoure.Replace("$HtmlFile$", HtmlFile);
            TempSoure = TempSoure.Replace("$EstablishMent$", EstablishMent);
            TempSoure = TempSoure.Replace("$Employees$", Employees);
            TempSoure = TempSoure.Replace("$Capital$", Capital);
            TempSoure = TempSoure.Replace("$Introduction$", Introduction);
            TempSoure = TempSoure.Replace("$ServiceProce$", ServiceProce);
            TempSoure = TempSoure.Replace("$Title$", Title);
            TempSoure = TempSoure.Replace("$Keywords$", Keywords);
            TempSoure = TempSoure.Replace("$Description$", Description);

            TempSoure = TempSoure.Replace("$SeeLinkName$", seeLinkName);
            TempSoure = TempSoure.Replace("$Logo$", logo);
            #endregion
            string wenjian="",htmlpaths="";
            if (FronID == "1")
            {
                wenjian = ComPath + "company/";
                htmlpaths = wenjian + "\\" + CompanyID + ".html";
            }
            else
            {
                wenjian = ComPath + LoginName;
                htmlpaths = wenjian + "\\" + "index.html";
            }
            if (Directory.Exists(wenjian) == false)
            {
                Directory.CreateDirectory(wenjian);
            }
           // string htmlpaths = wenjian+"c" + "\\" + "index.html";
            Compage.Writer(htmlpaths, TempSoure);
        }
        #endregion

        #region 企业名片右侧栏
        string ComHit = ConfigurationManager.AppSettings["ComPanyHit"].ToString();
        string ComTime = ConfigurationManager.AppSettings["ComPanyTime"].ToString();
        /// <summary>
        /// 企业名片会员排行
        /// </summary>
        /// <param name="name"></param>
        public void ComPanyHit()
        {
            string TempFileName = ComHit.ToString();
            string PanyHit = SelCompanyHit();
            string Tem = Compage.Reader(TempFileName); //读取模板内容
            #region 替换模版
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$CompanyHit$", PanyHit);
            #endregion

            string htmlpaths = ComPath + "CompanyCard.html";
            Compage.Writer(htmlpaths, TempSoure);
        }
        /// <summary>
        /// 企业名片最新加入企业
        /// </summary>
        /// <param name="name"></param>
        public void ComPanyTime()
        {
            string TempFileName = ComTime.ToString();
            string PanyTime = SelCompanyTime();
            string Tem = Compage.Reader(TempFileName); //读取模板内容
            #region 替换模版
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$CompanyTime$", PanyTime);
            #endregion

            string htmlpaths = ComPath + "NewsCompany.html";
            Compage.Writer(htmlpaths, TempSoure);
        }
        #endregion

        #region 查询内容
        /// <summary>
        /// 企业名片会员排行
        /// </summary>
        /// <returns></returns>
        private string SelCompanyHit()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 8 CompanyName,HtmlFile from CompanyTab where AuditingStatus=1 order by Hit desc";
            DataSet ds = crm.ExecuteQuery(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 8 ? 8 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string[] file = row["HtmlFile"].ToString().Trim().Split('/');
                    sb.Append("<li><img src='http://img2.topfo.com/Company/img_mp/tubiao" + (i + 1) + ".gif' class=\"tubiao\"/>");
                    sb.Append("<a href=\"http://card.topfo.com/" + file[1] + "/" + file[2] + "\" title='" + row["CompanyName"] + "' target=\"_blank\">" + Sub(Convert.ToString(row["CompanyName"]), 16) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
        /// <summary>
        /// 企业名片最新加入企业
        /// </summary>
        /// <returns></returns>
        private string SelCompanyTime()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 8 CompanyName,HtmlFile from CompanyTab where AuditingStatus=1 order by CreateDate desc";
            DataSet ds = crm.ExecuteQuery(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 8 ? 8 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string[] file = row["HtmlFile"].ToString().Trim().Split('/');
                    sb.Append("<li><img src='http://img2.topfo.com/Company/img_mp/fin_icon2.gif' class=\"tubiao\"/>");
                    sb.Append("<a href=\"http://card.topfo.com/" + file[1] + "/" + file[2] + "\" title='" + row["CompanyName"] + "' target=\"_blank\">" + Sub(Convert.ToString(row["CompanyName"]), 16) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        public string Sub(string num, int n)
        {
            string name = "";
            if (num.Length > n)
            {
                name = num.ToString().Trim().Substring(0, n) + "...";
            }
            else
            {
                name = num.ToString().Trim().ToString();
            }
            return name;
        }
        #endregion

        #region 查询出所有ID，在全部生成静态页面时用到
        /// <summary>
        /// 查询出所有ID，在全部生成静态页面时用到
        /// </summary>
        /// <returns></returns>
        public string AllCompany()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select CompanyID from CompanyTab";
            DataSet ds = crm.ExecuteQuery(sql);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.Append("" + ds.Tables[0].Rows[i]["CompanyID"].ToString() + "|");
                }
            }
            return sb.ToString();
        }
        #endregion

        #region 企业展厅
        string ComShowPath = ConfigurationManager.AppSettings["CompanyShowPath"].ToString();//企业展厅静态页面存放路径

        string CScost = ConfigurationManager.AppSettings["CScost"].ToString(); //企业展厅模版存放位置
        string CSindex = ConfigurationManager.AppSettings["CSindex"].ToString(); //企业展厅模版存放位置
        string CSindustry = ConfigurationManager.AppSettings["CSindustry"].ToString(); //企业展厅模版存放位置
        string CSinfor = ConfigurationManager.AppSettings["CSinfor"].ToString(); //企业展厅模版存放位置
        string CSInvestmentenvironment = ConfigurationManager.AppSettings["CSInvestmentenvironment"].ToString(); //企业展厅模版存放位置
        string CSPark = ConfigurationManager.AppSettings["CSPark"].ToString(); //企业展厅模版存放位置
        string CSPhotogallery2 = ConfigurationManager.AppSettings["CSPhotogallery2"].ToString(); //企业展厅模版存放位置
        string CSPhotogallery = ConfigurationManager.AppSettings["CSPhotogallery"].ToString(); //企业展厅模版存放位置
        string CSPreferentialpolicies = ConfigurationManager.AppSettings["CSPreferentialpolicies"].ToString(); //企业展厅模版存放位置
        string CSproject = ConfigurationManager.AppSettings["CSproject"].ToString(); //企业展厅模版存放位置
        string CSRegionaloverview = ConfigurationManager.AppSettings["CSRegionaloverview"].ToString(); //企业展厅模版存放位置
        string CSvideo = ConfigurationManager.AppSettings["CSvideo"].ToString(); //企业展厅模版存放位置
        string MerchntList = ConfigurationManager.AppSettings["ProjectList"].ToString(); //模版存放位置
        string Contact = ConfigurationManager.AppSettings["Contact"].ToString(); //联系我们
        string InvestNeed = ConfigurationManager.AppSettings["InvestNeed"].ToString(); //投资需求
        string RZProject = ConfigurationManager.AppSettings["RZProject"].ToString(); //融资项目
        string InvestCost = ConfigurationManager.AppSettings["InvestCost"].ToString(); //投资IF
        #endregion

        #region 企业展厅logo
        string lgpic = ConfigurationManager.AppSettings["lgpic"].ToString();//企业展厅logo存放路径

        string lgpolice = ConfigurationManager.AppSettings["lgpolice"].ToString();//企业展厅左logo模版存放路径
        string lgIndex = ConfigurationManager.AppSettings["lgIndex"].ToString();//企业展厅右logo模版存放路径
        #endregion

        #region 企业展厅相关图片存放路径
        string UpProductImage = ConfigurationManager.AppSettings["UpProductImage"].ToString();//企业展厅logo存放路径
        #endregion

        #region 企业展厅
        public void CompanyShowHtml(string LoginName,string Title,string KeyWord,string Descript)
        {
            Tz888.SQLServerDAL.Info.IndexSelect dal = new Tz888.SQLServerDAL.Info.IndexSelect();
            Tz888.SQLServerDAL.Company.CompanyShowDAL com = new Tz888.SQLServerDAL.Company.CompanyShowDAL();
            
            string ProjectList = dal.MerchantNew(LoginName);
            string lgleft = lgpic + LoginName;//判断文件夹是否存在
            if (Directory.Exists(lgleft) == false)
            {
                Directory.CreateDirectory(lgleft);
            }
            string lgLeftPath = lgleft + "\\" + LoginName + "pic.jpg";
            string lgRightPath = lgleft + "\\" + LoginName + "index.jpg";
            if (System.IO.File.Exists(lgLeftPath))
            {
                //File.Delete(lgLeftPath);
            }
            else
            {
                File.Copy(lgpolice, lgLeftPath);

            }
            if (System.IO.File.Exists(lgRightPath))
            {
                //File.Delete(lgRightPath);
            }

            else
            {
                File.Copy(lgIndex, lgRightPath);
            }

            string wenjian = ComShowPath + LoginName;
            string imgS = ComShowPath + LoginName + "\\" + "img";

            if (Directory.Exists(imgS) == false)
            {
                Directory.CreateDirectory(imgS);
            }
            if (Directory.Exists(wenjian) == false)
            {
                Directory.CreateDirectory(wenjian);
            }
            #region 页面1
            string TempFileName1 = CScost.ToString();
            string TempSoure1 = Compage.Reader(TempFileName1);
            TempSoure1 = TempSoure1.Replace("$loginName$", LoginName);
            TempSoure1 = TempSoure1.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths1 = wenjian + "\\" + "cost.htm";
            Compage.Writer(htmlpaths1, TempSoure1);
            #endregion

            #region 页面2
            string TempFileName2 = CSindex.ToString();
            string TempSoure2 = Compage.Reader(TempFileName2);
            TempSoure2 = TempSoure2.Replace("$loginName$", LoginName);
            TempSoure2 = TempSoure2.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            TempSoure2 = TempSoure2.Replace("$Title$", Title.ToString().Trim());
            TempSoure2 = TempSoure2.Replace("$Description$", KeyWord.ToString().Trim());
            TempSoure2 = TempSoure2.Replace("$KeyWords$", Descript.ToString().Trim());
            string htmlpaths2 = wenjian + "\\" + "index.htm";
            Compage.Writer(htmlpaths2, TempSoure2);
            #endregion

            #region 页面3
            string TempFileName3 = CSindustry.ToString();
            string TempSoure3 = Compage.Reader(TempFileName3);
            TempSoure3 = TempSoure3.Replace("$loginName$", LoginName);
            TempSoure3 = TempSoure3.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths3 = wenjian + "\\" + "industry.htm";
            Compage.Writer(htmlpaths3, TempSoure3);
            #endregion

            #region 页面4
            string TempFileName4 = CSinfor.ToString();
            string TempSoure4 = Compage.Reader(TempFileName4);
            TempSoure4 = TempSoure4.Replace("$loginName$", LoginName);
            TempSoure4 = TempSoure4.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths4 = wenjian + "\\" + "infor.htm";
            Compage.Writer(htmlpaths4, TempSoure4);
            #endregion

            #region 页面5
            string TempFileName5 = CSInvestmentenvironment.ToString();
            string TempSoure5 = Compage.Reader(TempFileName5);
            TempSoure5 = TempSoure5.Replace("$loginName$", LoginName);
            TempSoure5 = TempSoure5.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths5 = wenjian + "\\" + "Investmentenvironment.htm";
            Compage.Writer(htmlpaths5, TempSoure5);
            #endregion

            #region 页面6
            string TempFileName6 = CSPark.ToString();
            string TempSoure6 = Compage.Reader(TempFileName6);
            TempSoure6 = TempSoure6.Replace("$loginName$", LoginName);
            TempSoure6 = TempSoure6.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths6 = wenjian + "\\" + "Park.htm";
            Compage.Writer(htmlpaths6, TempSoure6);
            #endregion

            #region 页面7
            string TempFileName7 = CSPhotogallery2.ToString();
            string TempSoure7 = Compage.Reader(TempFileName7);
            TempSoure7 = TempSoure7.Replace("$loginName$", LoginName);
            string htmlpaths7 = wenjian + "\\" + "Photogallery2.htm";
            Compage.Writer(htmlpaths7, TempSoure7);
            #endregion

            #region 页面8
            string TempFileName8 = CSPhotogallery.ToString();
            string TempSoure8 = Compage.Reader(TempFileName8);
            TempSoure8 = TempSoure8.Replace("$loginName$", LoginName);
            TempSoure8 = TempSoure8.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths8 = wenjian + "\\" + "Photogallery.htm";
            Compage.Writer(htmlpaths8, TempSoure8);
            #endregion

            #region 页面9
            string TempFileName9 = CSPreferentialpolicies.ToString();
            string TempSoure9 = Compage.Reader(TempFileName9);
            TempSoure9 = TempSoure9.Replace("$loginName$", LoginName);
            TempSoure9 = TempSoure9.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths9 = wenjian + "\\" + "Preferentialpolicies.htm";
            Compage.Writer(htmlpaths9, TempSoure9);
            #endregion

            #region 页面10
            string TempFileName10 = CSproject.ToString();
            string TempSoure10 = Compage.Reader(TempFileName10);
            TempSoure10 = TempSoure10.Replace("$loginName$", LoginName);
            TempSoure10 = TempSoure10.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths10 = wenjian + "\\" + "project.htm";
            Compage.Writer(htmlpaths10, TempSoure10);
            #endregion

            #region 页面11
            string TempFileName11 = CSRegionaloverview.ToString();
            string TempSoure11 = Compage.Reader(TempFileName11);
            TempSoure11 = TempSoure11.Replace("$loginName$", LoginName);
            TempSoure11 = TempSoure11.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths11 = wenjian + "\\" + "Regionaloverview.htm";
            Compage.Writer(htmlpaths11, TempSoure11);
            #endregion

            #region 页面12
            string TempFileName12 = CSvideo.ToString();
            string TempSoure12 = Compage.Reader(TempFileName12);
            TempSoure12 = TempSoure12.Replace("$loginName$", LoginName);
            TempSoure12 = TempSoure12.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths12 = wenjian + "\\" + "video.htm";
            Compage.Writer(htmlpaths12, TempSoure12);
            #endregion


            #region 空白模版
            string htmlpaths14 = wenjian + "\\" + "PolicyRight.htm";
            Compage.Writer(htmlpaths14, "");

            string htmlpaths15 = wenjian + "\\" + "ProductIF.htm";
            Compage.Writer(htmlpaths15, "");

            string htmlpaths16 = wenjian + "\\" + "FriendLink.htm";
            Compage.Writer(htmlpaths16, "");

            string htmlpaths17 = wenjian + "\\" + "Investmentenvironments.htm";
            Compage.Writer(htmlpaths17, "");

            string htmlpaths18 = wenjian + "\\" + "newss.htm";
            Compage.Writer(htmlpaths18, "");

            string htmlpaths19 = wenjian + "\\" + "Photogallery3.htm";
            Compage.Writer(htmlpaths19, "");

            string htmlpaths20 = wenjian + "\\" + "Regionaloverviews.htm";
            Compage.Writer(htmlpaths20, "");

            #region 页面21
            string TempFileName21 = Contact.ToString();
            string TempSoure21 = Compage.Reader(TempFileName21);
            TempSoure21 = TempSoure21.Replace("$loginName$", LoginName);
            TempSoure21 = TempSoure21.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths21 = wenjian + "\\" + "Contact.htm";

            Compage.Writer(htmlpaths21, TempSoure21);
            #endregion

            #region ifrom招商信息
            //string TempFileName13 = MerchntList.ToString();
            //string TempSoure13 = Compage.Reader(TempFileName13);
            //TempSoure13 = TempSoure13.Replace("$ProjectList$", ProjectList);
            //string htmlpaths13 = wenjian + "\\" + "MearcharList.htm";
            //Compage.Writer(htmlpaths13, TempSoure13);
            #endregion

            #region 页面22 投资需求
            string TempFileName22 = InvestNeed.ToString();
            string TempSoure22 = Compage.Reader(TempFileName22);
            TempSoure22 = TempSoure22.Replace("$loginName$", LoginName);
            TempSoure22 = TempSoure22.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths22 = wenjian + "\\" + "InvestNeed.htm";
            Compage.Writer(htmlpaths22, TempSoure22);
            #endregion
            #region 页面23 融资项目
            string TempFileName23 = RZProject.ToString();
            string TempSoure23 = Compage.Reader(TempFileName23);
            TempSoure23 = TempSoure23.Replace("$loginName$", LoginName);
            TempSoure23 = TempSoure23.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths23 = wenjian + "\\" + "RZProject.htm";
            Compage.Writer(htmlpaths23, TempSoure23);
            #endregion
            #region 页面24 融资项目
            string TempFileName24 = InvestCost.ToString();
            string TempSoure24 = Compage.Reader(TempFileName24);
            TempSoure24 = TempSoure24.Replace("$loginName$", LoginName);
            TempSoure24 = TempSoure24.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths24 = wenjian + "\\" + "InvestCost.htm";
            Compage.Writer(htmlpaths24, TempSoure24);

            #endregion
            MerchantStatic(LoginName);
        }
            #endregion


        /// <summary>
        /// 生成招商投资融资模板页
        /// </summary>
        /// <param name="LoginName"></param>
        public int PmcStatic(string LoginName)
        {
            string wenjian = ComShowPath + LoginName;


            string TempFileName10 = CSproject.ToString();
            string TempSoure10 = Compage.Reader(TempFileName10);
            TempSoure10 = TempSoure10.Replace("$loginName$", LoginName);
            Tz888.SQLServerDAL.Company.CompanyShowDAL com = new Tz888.SQLServerDAL.Company.CompanyShowDAL();
            TempSoure10 = TempSoure10.Replace("$CompanyName$", com.GetCompanyNameByLoginName(LoginName));
            string htmlpaths10 = wenjian + "\\" + "project.htm";
            Compage.Writer(htmlpaths10, TempSoure10);
            return 1;

        }
        /// <summary>
        /// 生成招商项目Ifrom
        /// </summary>
        /// <param name="LoginName"></param>
        public int MerchantStatic(string LoginName)
        {
            Tz888.SQLServerDAL.Info.IndexSelect dal = new Tz888.SQLServerDAL.Info.IndexSelect();
            string wenjian = ComShowPath + LoginName;
            try
            {
                string ProjectList = "";
                string temp = "";

                for (int i = 0; i < 3; i++)
                {
                    string title = "";

                    if (i == 0)//招商信息
                    {
                        ProjectList = dal.MerchantNew(LoginName);
                        temp = "MearcharList.htm";
                        title = "招商项目";
                    }
                    else if (i == 1)//投资信息
                    {
                        ProjectList = dal.CapitalNew(LoginName);
                        temp = "InvestNeedList.htm";
                        title = "投资项目";
                    }
                    else if (i == 2)//融资信息
                    {
                        ProjectList = dal.ProjectlNew(LoginName);
                        temp = "RZProjectList.htm";
                        title = "融资项目";
                    }
                    string TempFileName13 = MerchntList.ToString();
                    string TempSoure13 = Compage.Reader(TempFileName13);
                    TempSoure13 = TempSoure13.Replace("$ProjectList$", ProjectList);
                    TempSoure13 = TempSoure13.Replace("$ProjectTitle$", title);
                    string htmlpaths13 = wenjian + "\\" + temp;
                    Compage.Writer(htmlpaths13, TempSoure13);
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #region 删除指定文件夹及相关图片
        public void DelFile(string name)
        {
            if (Directory.Exists(ComShowPath) == true)
            {
                string[] num = Directory.GetFileSystemEntries(ComShowPath);
                foreach (string file in num)
                {
                    string[] ComShow = file.Split('\\');
                    string compath = ComShow[ComShow.Length - 1];
                    if (name == compath)
                    {
                        string[] d = Directory.GetFileSystemEntries(file);

                        foreach (string aa in d)
                        {
                            string[] sb = aa.Split('\\');
                            string sbCom = sb[sb.Length - 1];
                            if (sbCom == "img")
                            {
                                Directory.Delete(aa);
                            }
                            else
                            {
                                File.Delete(aa);
                            }
                        }
                        Directory.Delete(file);
                    }
                }
            }
            lgpicIndex(name);
            updateImage(name);
        }
        private void lgpicIndex(string name)
        {
            if (Directory.Exists(lgpic) == true)
            {
                string[] num = Directory.GetFileSystemEntries(lgpic);
                foreach (string file in num)
                {
                    string[] b = file.Split('\\');
                    string c = b[b.Length - 1];
                    if (name == c)
                    {
                        string[] d = Directory.GetFileSystemEntries(file);
                        foreach (string aa1 in d)
                        {
                            File.Delete(aa1);
                        }
                        Directory.Delete(file);
                    }
                }
            }
        }

        private void updateImage(string name)
        {
            if (Directory.Exists(UpProductImage) == true)
            {
                string[] num = Directory.GetFileSystemEntries(UpProductImage);
                foreach (string file in num)
                {
                    string[] b = file.Split('\\');
                    string c = b[b.Length - 1];
                    if (name == c)
                    {
                        string[] d = Directory.GetFileSystemEntries(file);
                        foreach (string aa in d)
                        {
                            File.Delete(aa);
                        }
                        Directory.Delete(file);
                    }
                }
            }
        }


        #endregion
        #endregion
    }

}
