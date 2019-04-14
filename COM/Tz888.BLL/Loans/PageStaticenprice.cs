using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using Tz888.Model.Info;
using Tz888.DALFactory;
using Tz888.IDAL.Info;
using System.Reflection;

namespace Tz888.BLL.Loans
{
   public  class PageStaticenprice
    {
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["DKAppPath"].ToString(); //成功案例生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["DKMerchantTems"].ToString(); //其他成功案例模版存放位置
        #region 创建招商静态页面
        /// <summary>
        ///创建贷款静态页面
        /// </summary>
        public int StaticHtml(int loansInfoID)
        {
            Tz888.BLL.loansInfoTab loansinfotabbll = new loansInfoTab();
            Tz888.BLL.LoansInfo loansinfobll = new LoansInfo();
            Tz888.BLL.loanscontactsTab loanscontactstabbll = new loanscontactsTab();

            Tz888.Model.LoansInfoTab loansinfotab = loansinfotabbll.GetLoansInfoTabByLoansInfoId(loansInfoID);
            Tz888.Model.LoansInfo loansinfo = loansinfobll.GetLoansInfoByLoansInfoId(loansInfoID);
            Tz888.Model.LoanscontactsTab loanscontactstab = loanscontactstabbll.GetLoanscontactsTabByLoansInfoId(loansInfoID);
            try
            {
                string proviceID = loansinfo.ProvinceID.ToString().Trim();
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                #region 替换模版
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$title$", loansinfotab.LoansTitle.ToString().Trim());
                string ProvinceID = loansinfo.ProvinceID.ToString().Trim();
                string provincename = loansinfobll.GetProvinceNameByProvinceId(ProvinceID).Trim();
                if (provincename.Trim() == "")
                {
                    provincename = "中国";
                }
                string deadlineriqi = "";
                if (loansinfo.Deadline == 3)
                {
                    deadlineriqi = "3个月";
                }
                if (loansinfo.Deadline == 6)
                {
                    deadlineriqi = "半年";

                }
                if (loansinfo.Deadline == 12)
                {
                    deadlineriqi = "1年";
                }
                if (loansinfo.Deadline == 24)
                {
                    deadlineriqi = "2年";
                }
                if (loansinfo.Deadline == 36)
                {
                    deadlineriqi = "3年";
                }
                if (loansinfo.Deadline == 60)
                {
                    deadlineriqi = "5年";
                }
                string systime = "";
                if (loansinfo.ValidityID == 3)
                {
                    systime = "3个月";
                }
                if (loansinfo.ValidityID == 6)
                {
                    systime = "半年";

                }
                if (loansinfo.ValidityID == 12)
                {
                    systime = "1年";
                }
                if (loansinfo.ValidityID == 24)
                {
                    systime = "2年";
                }
                if (loansinfo.ValidityID == 36)
                {
                    systime = "3年";
                }
                if (loansinfo.ValidityID == 60)
                {
                    systime = "5年";
                }
                string danbao = "";
                if (loansinfo.Guarantee == 0)
                {
                    danbao = "担保";
                }
                if (loansinfo.Guarantee == 1)
                {
                    danbao = "抵押";
                }
                if (loansinfo.Guarantee == 2)
                {
                    danbao = "信用";
                }
                string titlesystemname = sethtml();
                string xiangxi = sethtmls(loansinfo.ProvinceID.ToString().Trim());
                TempSoure = TempSoure.Replace("$infoID$", loansInfoID.ToString().Trim());
                TempSoure = TempSoure.Replace("$loansTitle$", loansinfotab.LoansTitle.ToString().Trim());
                TempSoure = TempSoure.Replace("$Are$", provincename);
                TempSoure = TempSoure.Replace("$money$", loansinfo.Amount.ToString().Trim());
                TempSoure = TempSoure.Replace("$borrowmoneyqixian$", deadlineriqi.ToString().Trim());
                TempSoure = TempSoure.Replace("$danbaotype$", danbao.ToString().Trim());
                TempSoure = TempSoure.Replace("$publishdate$", loansinfotab.Loansdate.ToString().Trim().Substring(0, 9));
                TempSoure = TempSoure.Replace("$systime$", systime.ToString().Trim());
                TempSoure = TempSoure.Replace("$Content$", loansinfo.BorrowingUse.ToString().Trim());
                TempSoure = TempSoure.Replace("$Titlesytem$", titlesystemname.ToString().Trim());
                TempSoure = TempSoure.Replace("$DisplayTitle$", loansinfo.Title.ToString().Trim());
                TempSoure = TempSoure.Replace("$KeyWord$", loansinfo.Keywords.ToString().Trim());
                TempSoure = TempSoure.Replace("$description$", loansinfo.Description.ToString().Trim());
                TempSoure = TempSoure.Replace("$XianXi$", xiangxi);


                #endregion
                #region

                string inPathTo = "/loans";

                string htmlFile = loansinfotab.Url.ToString().Trim();
                string[] html = htmlFile.Split('/');
                string[] nn = html[2].Split('_');
                string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + html[1].Replace("loans", "");
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);
                }

                string htmlpaths = wenjian + inPathTo + cc + "_" + loansInfoID + ".shtml";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }

            catch (Exception e)
            {
                return 0;
            }
                #endregion
        }

        #endregion

        public string sethtml()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 6 LoansTitle,url from loansinfotab where auditID=1 order by updatetime desc";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string Title = ds.Tables[0].Rows[i]["LoansTitle"].ToString();
                    sb.Append("<li>·<a href='http://www.topfo.com/" + row["url"].ToString() + "' target=\"_blank\">" + StrLength(Title.ToString().Trim(), 16) + "</a></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        public string sethtmls(string proviceID)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 3 loansInfoID,ProvinceID,amount,guarantee from loansInfo where ProvinceID=@proviceid and loansInfoID in(select loansInfoID from loansinfotab where auditID=1) order by loanID desc";

            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, new SqlParameter("proviceid", proviceID));
            sb.Append(" <table width=" + "100%" + " border=" + "0" + " cellspacing=" + "0" + " cellpadding=" + "0" + " class=" + "tab1" + "><tr><td class=" + "xiangguanxinxi" + ">贷款标题</td><td class=" + "xiangguanxinxi" + ">贷款金额</td><td class=" + "xiangguanxinxi" + ">所在地域</td><td class=" + "xiangguanxinxi" + ">担保方式</td><td class=" + "xiangguanxinxi" + ">发布日期</td></tr>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    DataRow row = ds.Tables[0].Rows[i];
                    int loansInfoID = Convert.ToInt32(ds.Tables[0].Rows[i]["loansInfoID"]);
                    string money = ds.Tables[0].Rows[i]["amount"].ToString().Trim();
                    int danbao = Convert.ToInt32(ds.Tables[0].Rows[i]["guarantee"]);
                    string danbaos = "";
                    if (danbao == 0)
                    {
                        danbaos = "担保";
                    }
                    else if (danbao == 1) { danbaos = "抵押"; }
                    else
                    {
                        danbaos = "信用";
                    }
                    Tz888.BLL.LoansInfo loansinfobll = new Tz888.BLL.LoansInfo();
                    string provincename = loansinfobll.GetProvinceNameByProvinceId(proviceID).Trim();
                    if (provincename.Trim() == "")
                    {
                        provincename = "中国";
                    }
                    Tz888.BLL.loansInfoTab loansinfotabbll = new loansInfoTab();
                    Tz888.Model.LoansInfoTab loansinfotab = loansinfotabbll.GetLoansInfoTabByLoansInfoId(loansInfoID);
                    string loanstitle = loansinfotab.Url.ToString().Trim();
                    string loanstime = loansinfotab.Loansdate.ToString().Trim().Substring(0, 9).Trim();

                    sb.Append("<td><a href='http://www.topfo.com/" + loanstitle + "' target=\"_blank\">" + StrLength(loansinfotab.LoansTitle.ToString().Trim(), 16) + "</a></td><td>" + money + "</td><td>" + provincename + "</td><td>" + danbaos + "</td><td>" + loanstime + "</td>");
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        protected string StrLength(object title, int count)
        {
            string name = "";
            name = title.ToString();
            if (name.Length > count)
            {
                name = name.Substring(0, count) + "...";
            }
            return name;
        }
    }
}
