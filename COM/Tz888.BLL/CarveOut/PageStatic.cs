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
        string MerchantTmpPathTo = ConfigurationManager.AppSettings["NewsAppPath"].ToString(); //�ɹ���������ҳ����λ��
        string CasesTem = ConfigurationManager.AppSettings["NewsTem"].ToString(); //�ɹ�����ģ����λ��
        #region ����ID��ѯ������Ѷ��Ϣ
        /// <summary>
        /// ����ID��ѯ������Ѷ��Ϣ
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
        #region �������Ͳ鿴��Ϣ
        /// <summary>
        /// �������Ͳ鿴��Ϣ
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
        #region ������̬ҳ���Ѿ�������
        /// <summary>
        ///���ž�̬ҳ����ʾ
        /// </summary>
        /// <param name="NewsID">���</param>
        /// <param name="title">����</param>
        /// <param name="publishT">ʱ��</param>
        /// <param name="Content">��ϸ����</param>
        public void StaticHtml(int NewsID, string title, string publishT, string Content)
        {
            try
            {
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //��ȡģ������
                #region �滻ģ��
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
        #region ���Է�װ
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
        private string validateID;//��Ч��

        public string ValidateID
        {
            get { return validateID; }
            set { validateID = value; }
        }
        private string investObject;//��������

        public string InvestObject
        {
            get { return investObject; }
            set { investObject = value; }
        }
        private string capitalID;//Ͷ�ʽ��

        public string CapitalID
        {
            get { return capitalID; }
            set { capitalID = value; }
        }
        private string industryCarveOutID; //��ҵ��ҵ���

        public string IndustryCarveOutID
        {
            get { return industryCarveOutID; }
            set { industryCarveOutID = value; }
        }
        private string provinceID;  //ʡ

        public string ProvinceID
        {
            get { return provinceID; }
            set { provinceID = value; }
        }
        private string investReturn;//�ر���ʽ

        public string InvestReturn
        {
            get { return investReturn; }
            set { investReturn = value; }
        }
        private string comName;//��λ����

        public string ComName
        {
            get { return comName; }
            set { comName = value; }
        }
        private string linkMan;//��ϵ��

        public string LinkMan
        {
            get { return linkMan; }
            set { linkMan = value; }
        }
        private string tel;//�绰

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string address;//��ַ

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string postCode;//�ʱ�

        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }
        private string email;//����

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string webSite;//��վ

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

        #region ȥ��HTML���
        public string ThrowHtml(string sStr)
        {
            //ʹ��������ʽ�滻
            //Regex x = new Regex("<(.[^>]*)>");
            sStr = Regex.Replace(sStr, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            sStr = Regex.Replace(sStr, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            return sStr;
        }
        #endregion
        #region ��ȡʡ����
        /// <summary>
        /// ����ID��ȡʡ����
        /// </summary>
        /// <returns></returns>
        public string ProvinceSelect(string ProvinceID)
        {
            string Name = "";
            if (ProvinceID == "")
            {
                Name = "ȫ��";
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

        #region ��������ת��
        protected string InfoType(string  com)
        {
            string Nnamn = "";
            switch (com)
            {
                case "0":
                    Nnamn = "��Ŀ���ʽ�";
                    break;
                case "1":
                    Nnamn = "�ʽ�����Ŀ";
                    break;



            }
            return Nnamn;
        }
        #endregion
        #region ��ȡ��ҵ��ҳ
        /// <summary>
        /// ����ID��ȡ��ҳ
        /// </summary>
        /// <returns></returns>
        public string IndustryClassListSelect(string IndustryCarveOutID)
        {
            string[] a = IndustryCarveOutID.Split(',');
            string Name = "";
            if (a[0] == "")
            {
                Name = "������ҵ";
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
        #region ���������
        protected string HezuoType(string com)
        {
            string Nnamn = "";
            switch (com)
            {
                case "0":
                    Nnamn = "������";
                    break;
                case "1":
                    Nnamn = "����";
                    break;
                case "2":
                    Nnamn = "��˾";
                    break;



            }
            return Nnamn;
        }
          #endregion
        #region ��ȡ��Ч��
        /// <summary>
        /// ����ID��ȡ�ʽ�����
        /// </summary>
        /// <returns></returns>
        public string Xmyxq(string IndustryCarveOutID)
        {
            //string[] a = IndustryCarveOutID.Split(',');
            string Name = "";
            if (IndustryCarveOutID == "")
            {
                Name = "����";
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
        #region ��ȡ�ʽ�����
        /// <summary>
        /// ����ID��ȡ�ʽ�����
        /// </summary>
        /// <returns></returns>
        public string Capital(string IndustryCarveOutID)
        {
            //string[] a = IndustryCarveOutID.Split(',');
            string Name = "";
            if (IndustryCarveOutID == "")
            {
                Name = "����";
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
        #region ��ȡ���±��ⳤ��
        /// <summary>
        /// ��ȡ���±��ⳤ��
        /// </summary>
        /// <param name="title">����</param>
        /// <param name="n">��С</param>
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
