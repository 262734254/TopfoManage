using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace Tz888.BLL.report
{
    public class InsStatic
    {
        string FieldPath = ConfigurationManager.AppSettings["INAppPath"].ToString(); //����ҳ����λ��
        string FieldTem = ConfigurationManager.AppSettings["FieldTemd"].ToString(); //ģ����λ��

        string KXPath = ConfigurationManager.AppSettings["KXPath"].ToString(); //��Ѷ����ҳ����λ��
        string KXTemd = ConfigurationManager.AppSettings["KXTemplate"].ToString(); //��Ѷģ����λ��
        /// <summary>
        /// 1,���·�������,2,�Ƽ���ҵ����,3,�����ҵ����
        /// <param name="title">��ʾ�ı���</param>
        /// <param name="where">��ѯ����</param>
        /// <param name="flag">����������</param>
        /// <returns></returns>
        /// </summary>
        public string SelReport(int typeId)
        {
            StringBuilder sb = new StringBuilder();
            string title = string.Empty;
            string strW = " where 1=1 ";
            if (typeId == 1)
            {
                strW += "order by createDate desc";
                title = "������ҵ��������";
            }
            else if (typeId == 2)
            {
                strW += " and recommendID=1 and charges=1 order by createDate desc ";
                title = "�Ƽ���ҵ��������";
            }
            else if (typeId == 3)
            {
                strW += " and charges=0 order by createDate desc";
                title = "�����ҵ��������";
            }
            string sql = "select top 6 reportname,bigtypeid,html from dbo.reportTab" + strW;
            DataSet ds = Tz888.DBUtility.DBHelper.Query(sql);
            sb.Append("<div class=\"con1_col\"><div class=\"l f_14 strong\">" + title + "</div>");
            //<div class=\"r\"><a href=\"http://rz.topfo.com/\">&gt;&gt;����</a></div>
            sb.Append("<div class=\"clear\"></div></div>");
            sb.Append("<div class=\"con1_sub\"><ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<li>��<a href='#' target=\"_blank\">[" + InName(int.Parse(row["bigtypeid"].ToString())) + "]</a><a href='http://sr.topfo.com/" + row["html"].ToString() + "' target=\"_blank\">" + row["reportname"].ToString() + "</a></li>");
                }
            }
            sb.Append("</ul></div><div class=\"con_mar\"></div>");
            return sb.ToString();
        }
        public int StaticHtml(string Field, int num)
        {
            try
            {
                string Tem = Compage.Reader(FieldTem.ToString()); //��ȡģ������
                #region �滻ģ��
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$Field$", Field);
                #endregion
                string wenjian = FieldPath;
                if (!Directory.Exists(wenjian))
                {
                    Directory.CreateDirectory(wenjian);
                }
                string htmlpaths = "";
                if (num == 1)//���·�������
                {
                    htmlpaths = wenjian + "NewReport.html";
                }
                else if (num == 2)//�Ƽ���ҵ����
                {
                    htmlpaths = wenjian + "RecomReport.html";
                }
                else if (num == 3)//�����ҵ����
                {
                    htmlpaths = wenjian + "ChargesReport.html";
                }
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }
        private string InName(int id)
        {
            Tz888.BLL.Advertorial.IndustryType bll = new Tz888.BLL.Advertorial.IndustryType();
            return bll.GetModel(id).industryName;
        }
        private string InType(int typeid)
        {
            Tz888.BLL.news.NewsTypeTabBLL bll = new Tz888.BLL.news.NewsTypeTabBLL();
            return bll.GetNewsTypeByTypeId(typeid).TypeName;
        }
        public int StaticHtml(string Field)
        {
            try
            {
                string Tem = Compage.Reader(KXTemd.ToString()); //��ȡģ������
                #region �滻ģ��
                string TempSoure = Tem;
                TempSoure = TempSoure.Replace("$Field$", Field);
                #endregion
                string wenjian = KXPath;
                if (!Directory.Exists(wenjian))
                {
                    Directory.CreateDirectory(wenjian);
                }
                string htmlpaths = wenjian + "KXNew.html";
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }
        public string strNews()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 10 typeid,urlhtml,ntitle from dbo.NewsTab where audit=1 order by createDate desc";
            DataSet ds = Tz888.DBUtility.DBHelper.Query(sql);
            sb.Append("<div class=\"con1_col\"><div class=\"l f_14 strong\">������Ѷ</div>");
             //sb.Append("<div class=\"r\"><a href=\"http://rz.topfo.com/\">&gt;&gt;����</a></div>");
            sb.Append("<div class=\"clear\"></div></div>");
            sb.Append("<div class=\"con1_sub\"><ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<li>��<a href='#' target=\"_blank\">[" + InType(int.Parse(row["typeid"].ToString())) + "]</a><a href='http://news.topfo.com/" + row["urlhtml"].ToString() + "' target=\"_blank\">" + row["ntitle"].ToString() + "</a></li>");

                }
            }
            sb.Append("</ul></div><div class=\"con_mar\"></div>");
            return sb.ToString();
        }
    }
}
