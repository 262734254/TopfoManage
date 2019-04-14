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

namespace Tz888.BLL.CarveOut
{
    public class PageStatic
    {
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["NewsAppPath"].ToString(); //成功案例生成页面存放位置
        string CasesTem = ConfigurationManager.AppSettings["NewsTem"].ToString(); //成功案例模版存放位置
        #region 根据ID查询新闻资讯信息
        /// <summary>
        /// 根据ID查询新闻资讯信息
        /// </summary>
        public PageStatic NewsIdAll(int infoId)
        {
            PageStatic page = new PageStatic();
            string sql = " select * from MenberInfo_ViewCar where InfoID=@infoId";
            //string sql = "select a.title,a.publishT,a.AuditingStatus, a.Hit,b.[Content] from MainInfoTab as a inner join CarveOutInfoTab as b on a.InfoID=b.InfoID where a.InfoID=@infoId";
            SqlParameter[] para ={
            new SqlParameter("@infoId",SqlDbType.Int,8)
           };
            para[0].Value = infoId;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                page.Title =GetTitle(ds.Tables[0].Rows[0]["title"].ToString(),18);
                page.PublishT = Convert.ToDateTime(ds.Tables[0].Rows[0]["publishT"].ToString());
                page.Content =GetTitle(ThrowHtml((ds.Tables[0].Rows[0]["Content"].ToString().Trim())),150);
                page._auditingStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["AuditingStatus"].ToString());
                page.Hit = Convert.ToString(ds.Tables[0].Rows[0]["Hit"].ToString());
                page.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                page.CapitalID=Capital(ds.Tables[0].Rows[0]["CapitalID"].ToString().Trim());
                page.ComName = ds.Tables[0].Rows[0]["ComName"].ToString();
                page.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                page.IndustryCarveOutID = IndustryClassListSelect(Convert.ToString(ds.Tables[0].Rows[0]["IndustryCarveOutID"].ToString().Trim()));
                page.InvestObject =HezuoType(Convert.ToString(ds.Tables[0].Rows[0]["InvestObject"].ToString()));
                page.InvestReturn = GetTitle(ds.Tables[0].Rows[0]["InvestReturn"].ToString(),150);
                page.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                page.PostCode = Convert.ToString(ds.Tables[0].Rows[0]["PostCode"].ToString());
                page.ProvinceID = ProvinceSelect(Convert.ToString(ds.Tables[0].Rows[0]["ProvinceID"].ToString().Trim()));
                page.Tel = Convert.ToString(ds.Tables[0].Rows[0]["Tel"].ToString());
                page.ValidateID = Xmyxq(Convert.ToString(ds.Tables[0].Rows[0]["ValidateID"].ToString().Trim()));
                page.WebSite = Convert.ToString(ds.Tables[0].Rows[0]["WebSite"].ToString());
                page.KeyWord = Convert.ToString(ds.Tables[0].Rows[0]["KeyWord"].ToString());
                page.CarveOutInfoType =InfoType(Convert.ToString(ds.Tables[0].Rows[0]["CarveOutInfoType"].ToString().Trim()));
               


            }
            return page;
        } 
        #endregion
        #region 根据类型查看信息
        /// <summary>
        /// 根据类型查看信息
        /// </summary>
        public string SetType(string type)
        {
            StringBuilder builder = new StringBuilder();
            string sql = "select a.InfoID from MainInfoTab as a inner join dbo.CarveOutInfoTab as b on a.InfoID=b.InfoID where b.CarveOutInfoType=@type and a.AuditingStatus=1 and a.HtmlFile!='' order by a.publishT desc";
            SqlParameter[] para ={
            new SqlParameter("@type",SqlDbType.Int,8)
           };
            para[0].Value = type;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    builder.Append("" + row["InfoID"].ToString() + ",");
                }

            }
            return builder.ToString();
        } 
        #endregion
        #region 创建静态页面已经不用了
        /// <summary>
        ///新闻静态页面显示
        /// </summary>
        /// <param name="NewsID">编号</param>
        /// <param name="title">标题</param>
        /// <param name="publishT">时间</param>
        /// <param name="Content">详细内容</param>
        public void StaticHtml(int NewsID, string title, string publishT, string Content)
        {
            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                #region 替换模版
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$title$", title);
                TempSoure = TempSoure.Replace("$publishT$", publishT);
                TempSoure = TempSoure.Replace("$Content$", Content);

                #endregion
                #region
                string inPathTo = "/News";

                string sql1 = "select a.HtmlFile from MainInfoTab as a inner join NewsTab as b on a.InfoID=b.InfoID where a.InfoID=" + NewsID + "";
                string htmlFile = Tz888.DBUtility.DbHelperSQL.GetSingle(sql1).ToString();
                string[] html = htmlFile.Split('/');
                string[] nn = html[2].Split('_');
                string cc = nn[0].Substring(nn[0].Length - 8);

                string wenjian = MerchantTmpPathTo + html[1].Replace("News", "");
                if (Directory.Exists(wenjian) == false)
                {
                    Directory.CreateDirectory(wenjian);
                }

                string htmlpaths = wenjian + inPathTo + cc + "_" + NewsID + ".shtml";
                Compage.Writer(htmlpaths, TempSoure);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
                #endregion
        }

        public void ModifyHtmlFile(int infoId)
        {

            try
            {
                string inPathTo = "/News";
                string sql1 = "select a.HtmlFile from MainInfoTab as a inner join NewsTab as b on a.InfoID=b.InfoID where a.InfoID=" + infoId + "";
                string htmlFile = Tz888.DBUtility.DbHelperSQL.GetSingle(sql1).ToString();
                if (htmlFile != "")
                {
                    string[] html = htmlFile.Split('/');
                    string htmlcc = html[1].Replace("News", "");
                    string[] nn = html[2].Split('_');
                    string cc = nn[0].Substring(nn[0].Length - 8);
                    //string arry = "F:/Topfo/tzWeb/News/" + htmlcc + inPathTo + cc + "_" + infoId + ".shtml";
                    //string arrylist = arry.Replace("F:/Topfo/tzWeb/", "");

                    string arry = "J:/Topfo/tzWeb/News/" + htmlcc + inPathTo + cc + "_" + infoId + ".shtml";
                    string arrylist = arry.Replace("J:/Topfo/tzWeb/", "");
                    string sql = "update MainInfoTab set HtmlFile='" + arrylist + "' where InfoID=" + infoId + "";
                    Tz888.DBUtility.DbHelperSQL.ExecuteSql(sql);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        } 
        #endregion
        #region 属性封装
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private DateTime _publishT;

        public DateTime PublishT
        {
            get { return _publishT; }
            set { _publishT = value; }
        }
        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private int _auditingStatus;

        public int AuditingStatus
        {
            get { return _auditingStatus; }
            set { _auditingStatus = value; }
        }
        private string hit;

        public string Hit
        {
            get { return hit; }
            set { hit = value; }
        }
        private string validateID;//有效期

        public string ValidateID
        {
            get { return validateID; }
            set { validateID = value; }
        }
        private string investObject;//合作对象

        public string InvestObject
        {
            get { return investObject; }
            set { investObject = value; }
        }
        private string capitalID;//投资金额

        public string CapitalID
        {
            get { return capitalID; }
            set { capitalID = value; }
        }
        private string industryCarveOutID; //创业行业类别

        public string IndustryCarveOutID
        {
            get { return industryCarveOutID; }
            set { industryCarveOutID = value; }
        }
        private string provinceID;  //省

        public string ProvinceID
        {
            get { return provinceID; }
            set { provinceID = value; }
        }
        private string investReturn;//回报形式

        public string InvestReturn
        {
            get { return investReturn; }
            set { investReturn = value; }
        }
        private string comName;//单位名称

        public string ComName
        {
            get { return comName; }
            set { comName = value; }
        }
        private string linkMan;//联系人

        public string LinkMan
        {
            get { return linkMan; }
            set { linkMan = value; }
        }
        private string tel;//电话

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string address;//地址

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string postCode;//邮编

        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }
        private string email;//邮箱

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string webSite;//网站

        public string WebSite
        {
            get { return webSite; }
            set { webSite = value; }
        }
        private string keyWord;

        public string KeyWord
        {
            get { return keyWord; }
            set { keyWord = value; }
        }
        private string carveOutInfoType;

        public string CarveOutInfoType
        {
            get { return carveOutInfoType; }
            set { carveOutInfoType = value; }
        }
        #endregion

        #region 去除HTML标记
        public string ThrowHtml(string sStr)
        {
            //使用正则表达式替换
            //Regex x = new Regex("<(.[^>]*)>");
            sStr = Regex.Replace(sStr, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            sStr = Regex.Replace(sStr, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            return sStr;
        }
        #endregion
        #region 获取省名称
        /// <summary>
        /// 根据ID获取省名称
        /// </summary>
        /// <returns></returns>
        public string ProvinceSelect(string ProvinceID)
        {
            string Name = "";
            if (ProvinceID == "")
            {
                Name = "全国";
                return Name;
            }
            string sql = "SELECT *FROM SetProvinceTab where ProvinceID =@ProvinceID";
            SqlParameter[] para ={
            new SqlParameter("@ProvinceID",SqlDbType.Int,20)};
            para[0].Value = ProvinceID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Name = ds.Tables[0].Rows[0]["ProvinceName"].ToString();
                return Name;
            }

            else
            {
                return null;
            }


        }
        #endregion

        #region 类型中文转换
        protected string InfoType(string  com)
        {
            string Nnamn = "";
            switch (com)
            {
                case "0":
                    Nnamn = "项目找资金";
                    break;
                case "1":
                    Nnamn = "资金找项目";
                    break;



            }
            return Nnamn;
        }
        #endregion
        #region 获取创业行页
        /// <summary>
        /// 根据ID获取行页
        /// </summary>
        /// <returns></returns>
        public string IndustryClassListSelect(string IndustryCarveOutID)
        {
            string[] a = IndustryCarveOutID.Split(',');
            string Name = "";
            if (a[0] == "")
            {
                Name = "暂无行业";
                return Name;
            }
            //string sql = "SELECT *FROM SetIndustryBTab where IndustryBID = '" + a[0] +"'";
            string sql = "select * from SetIndustryCraveOutTab where IndustryCarveOutID=@IndustryCarveOutID";
            SqlParameter[] para ={
            new SqlParameter("@IndustryCarveOutID",SqlDbType.VarChar,20)};
            para[0].Value = a[0];
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {


                Name = ds.Tables[0].Rows[0]["IndustryCarveOutName"].ToString();
                return Name;
            }
            else
            {
                return null;
            }


        }
        #endregion
        #region 合作对象绑定
        protected string HezuoType(string com)
        {
            string Nnamn = "";
            switch (com)
            {
                case "0":
                    Nnamn = "不限制";
                    break;
                case "1":
                    Nnamn = "个人";
                    break;
                case "2":
                    Nnamn = "公司";
                    break;



            }
            return Nnamn;
        }
          #endregion
        #region 获取有效期
        /// <summary>
        /// 根据ID获取资金名称
        /// </summary>
        /// <returns></returns>
        public string Xmyxq(string IndustryCarveOutID)
        {
            //string[] a = IndustryCarveOutID.Split(',');
            string Name = "";
            if (IndustryCarveOutID == "")
            {
                Name = "暂无";
                return Name;
            }
            //string sql = "SELECT *FROM SetIndustryBTab where IndustryBID = '" + a[0] +"'";
            string sql = "select * from dicttab where cDictType='xmyxqxx' and iDictValue=@IndustryCarveOutID";
            SqlParameter[] para ={
            new SqlParameter("@IndustryCarveOutID",SqlDbType.VarChar,20)};
            para[0].Value = IndustryCarveOutID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {


                Name = ds.Tables[0].Rows[0]["cDictName"].ToString();
                return Name;
            }
            else
            {
                return null;
            }


        }
        #endregion
        #region 获取资金名称
        /// <summary>
        /// 根据ID获取资金名称
        /// </summary>
        /// <returns></returns>
        public string Capital(string IndustryCarveOutID)
        {
            //string[] a = IndustryCarveOutID.Split(',');
            string Name = "";
            if (IndustryCarveOutID == "")
            {
                Name = "暂无";
                return Name;
            }
            //string sql = "SELECT *FROM SetIndustryBTab where IndustryBID = '" + a[0] +"'";
            string sql = "SELECT CapitalID, CapitalName FROM SetCapitalTab where CapitalID =@IndustryCarveOutID";
            SqlParameter[] para ={
            new SqlParameter("@IndustryCarveOutID",SqlDbType.VarChar,20)};
            para[0].Value = IndustryCarveOutID;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {


                Name = ds.Tables[0].Rows[0]["CapitalName"].ToString();
                return Name;
            }
            else
            {
                return null;
            }


        }
        #endregion
        #region 获取文章标题长度
        /// <summary>
        /// 获取文章标题长度
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="n">大小</param>
        /// <returns></returns>
        public string GetTitle(string title, int n)
        {
            string str = "";
            if (title != "")
            {
                str = title.Length > n ? title.ToString().Substring(0, n) + ".." : title;
            }
            return str;

        } 
        #endregion


    }
}
