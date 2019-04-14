using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Tz888.BLL.zx
{
    public class ZxSumDAL
    {

        Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();

        string NewSumPath = ConfigurationManager.AppSettings["NewSumAppPath"].ToString(); //��Ѷ��ϸҳ������ҳ���ŵط�
        string NewSumTem = ConfigurationManager.AppSettings["NewSumTem"].ToString(); //��Ѷ��ϸҳ��ģ����λ��
        /// <summary>
        /// ����̬ҳ��
        /// </summary>
        /// <param name="num">��ǰҳ����</param>
        /// <param name="type">����Ӧ������</param>
        /// <param name="state">������</param>
        /// <param name="page">�󶨷�ҳ</param>
        public void HtmlPage(int num, int type, string state, string page, string title, string keyWords, string desc)
        {
            string TypeName = Type(type);
            string TempFileName = NewSumTem.ToString();
            string Tem = Compage.Reader(TempFileName); //��ȡģ������
            #region �滻ģ��
            string TempSoure = Tem;
            TempSoure = TempSoure.Replace("$TypeName$", TypeName);
            TempSoure = TempSoure.Replace("$State$", state);
            TempSoure = TempSoure.Replace("$Page$", page);
            TempSoure = TempSoure.Replace("$Title$", title);
            TempSoure = TempSoure.Replace("$keywords$", keyWords);
            TempSoure = TempSoure.Replace("$description$", desc);

            #endregion

            string wenjian = NewSumPath + Convert.ToString(type);
            if (Directory.Exists(wenjian) == false)
            {
                Directory.CreateDirectory(wenjian);
            }

            string htmlpaths = wenjian + "\\index_" + num + ".shtml";
            Compage.Writer(htmlpaths, TempSoure);
        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        public void SelState(int num, int type, string title, string keyWords, string desc)
        {
                StringBuilder sb = new StringBuilder();
                string sql = "select top 40  NTitle,TypeID,urlhtml,createdate from "
                        + " NewsTab where audit=1 and TypeID=@type and "
                        + " Newsid not in(select top " + 40 * (num - 1) + "  Newsid from NewsTab where audit=1 and TypeID=@type  order by createdate desc)order by createdate desc";
                SqlParameter[] para ={ 
                        new SqlParameter("@type",SqlDbType.Int,8)
                    };
                    para[0].Value = type;
                    DataSet ds = crm.Query(sql, para);

                    if (ds != null & ds.Tables[0].Rows.Count > 0)
                    {
                        sb.Append("<ul>");
                        for (int i = 0; i < (ds.Tables[0].Rows.Count >= 40 ? 40 : ds.Tables[0].Rows.Count); i++)
                        {
                            DataRow row = ds.Tables[0].Rows[i];
                            DateTime dt = Convert.ToDateTime(row["createdate"].ToString());
                            string time = dt.ToString("yyyy-MM-dd");
                            sb.Append("<li><a href='http://news.topfo.com/" + row["urlhtml"].ToString() + "' target=\"_blank\"><span>" + row["NTitle"].ToString() + "</span>");
                            sb.Append("<h12>[" + time + "]</h12></a></li>");
                        }
                        sb.Append("</ul>");
                        string pageIndex = Page(num, type);
                        HtmlPage(num, type, sb.ToString(), pageIndex, title, keyWords, desc);
                    }
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="num"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string Page(int num, int type)
        {
            StringBuilder sb = new StringBuilder();
            int pagecc = pageS(type);
            sb.Append("<div class=\"Points_Page_sub\">");
            string urlbegin = "index_" + 1 + ".shtml";//��ҳ
            string urlendgin = "index_" + pagecc + ".shtml";//βҳ
            sb.Append("<a href='" + urlbegin + "' target=\"_parent\">��ҳ</a>");
            if (pagecc == 1)
            {
                sb.Append("<span>1</span>");
            }
            else
            {
                string urlon = "index_" + (num - 1) + ".shtml";//��һҳ
                string urldown = "index_" + (num + 1) + ".shtml";//��һҳ
                if (num != 1)
                {
                    sb.Append("<a href='" + urlon + "' target=\"_parent\">&lt;</a>");
                }
                for (int j = (num / 9 * 8) + 1; j <= (pagecc >= ((num / 9 * 8) + 9) ? ((num / 9 * 8) + 9) : pagecc); j++)
                {
                    string urlZ = "index_" + j + ".shtml";
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
            sb.Append("<div class=\"Points_Page_data\">ÿҳ<span class=\"f_red strong\">40</span>�� ��<span class=\"f_red strong\">" + num + "</span>ҳ/��<span class=\"f_red strong\">" + pagecc + "</span>ҳ</div>");
            sb.Append("<div class=\"clear\"></div>");

            return sb.ToString();
        }
        /// <summary>
        /// ��ѯ������
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int CountPage(int type)
        {
            int num = 0;
            string sql = "select count(NTitle) from NewsTab where audit=1 and TypeID=@type";
            SqlParameter[] para ={ 
               new SqlParameter("@type",SqlDbType.Int,8)
            };
            para[0].Value = type;
            num = Convert.ToInt32(crm.GetSingle(sql, para));
            return num;
        }
        /// <summary>
        /// �ж��ܹ��ж��ٸ�ҳ����
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int pageS(int type)
        {
            int pagecc = 0;//�ܹ����ٸ�ҳ��
            int countpage = CountPage(type);//�ܹ�������
            pagecc = countpage >= 40 ? (countpage % 40 == 0 ? countpage / 40 : countpage / 40 + 1) : 1;
            return pagecc;
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
            num = Convert.ToString(crm.GetSingle(sql, para));
            return num;
        }

    }
}
