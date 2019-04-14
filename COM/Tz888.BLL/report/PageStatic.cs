using System;
using System.Collections.Generic;
using System.Text;
using Tz888.BLL.Advertorial;
using Tz888.Model.report;
using Tz888.BLL.report;
using System.IO;
using System.Data;
using System.Configuration;
namespace Tz888.BLL.report
{

    public class PageStatic
    {
        IndustryType bll = new IndustryType();
        ReportTab maModel = new ReportTab();
        ReportView viewModel = new ReportView();
        reportTabBLL maBll = new reportTabBLL();
        reportViewBLL viewBll = new reportViewBLL();
        string ReportPath = ConfigurationManager.AppSettings["INAppPath"].ToString(); //�ɹ���������ҳ����λ��
        string CasesTem = ConfigurationManager.AppSettings["INTem"].ToString(); //��ɹ�����ģ����λ��

        /// <summary>
        ///�������̬ҳ��
        /// </summary>
        public int StaticHtml(int id)
        {

            try
            {
                maModel = maBll.GetModel(id);
                viewModel = viewBll.GetModel(id);
                string TempFileName = CasesTem.ToString();
                string Tem = Compage.Reader(TempFileName); //��ȡģ������
                string TempSoure = Tem;
                bool flags = false;
                string price = string.Empty;
                if (maModel.Charges == 1)//�շ�
                {
                    if (!string.IsNullOrEmpty(maModel.Price.ToString()) || maModel.Price.ToString().Equals("0"))
                    {
                        string[] str = maModel.Price.Split(new char[] { '|' });
                        for (int i = 0; i < str.Length - 1; i++)
                        {
                            string[] strchild = str[i].ToString().Split(new char[] { ':' });
                            for (int j = 0; j < strchild.Length - 1; j++)
                            {
                                if ((!string.IsNullOrEmpty(strchild[j].ToString())) && (!string.IsNullOrEmpty(strchild[j + 1].ToString())))
                                {
                                    switch (strchild[j].ToString())
                                    {
                                        case "1":
                                            price = "���Ӱ�:<font color='red' size='2'>��" + strchild[j + 1].ToString() + "</font>;&nbsp;";
                                            flags = true;
                                            break;

                                        case "2":
                                            price += "ӡˢ��:<font color='red' size='2'>��" + strchild[j + 1].ToString() + "</font>;&nbsp;";
                                            flags = true;
                                            break;
                                        case "3":
                                            price += "����+ӡˢ��:<font color='red' size='2'>��" + strchild[j + 1].ToString() + "</font>;&nbsp;";
                                            flags = true;
                                            break;
                                        case "4":
                                            price += "ӡˢ+���/���Ӱ�:<font color='red' size='2'>��" + strchild[j + 1].ToString() + "</font>;&nbsp;";
                                            flags = true;
                                            break;
                                        default:
                                            break;
                                    }
                                }

                            }
                        }
                    }
                }
                if (!flags)
                {
                    TempSoure = TempSoure.Replace("$goumais$", "");
                    price = "���";
                }
                else
                {
                    TempSoure = TempSoure.Replace("$goumais$", "<li class=\"goumai\"><a href='http://sr.topfo.com/Order/Buy.aspx?reportId=" + maModel.ReportID.ToString() + "'><img src='http://sr.topfo.com/Report/img_hy/zxgm.jpg' /></a></li>");
                }
                string strName = GetSmallByName(maModel.Smalltypeid);
                TempSoure = TempSoure.Replace("$ProfessionalID$", maModel.ReportID.ToString().Trim());
                TempSoure = TempSoure.Replace("$reportname$", maModel.Reportname.ToString());
                if (string.IsNullOrEmpty(maModel.Explain.ToString()))
                {
                    TempSoure = TempSoure.Replace("$explain$", "");
                }
                else
                {
                    TempSoure = TempSoure.Replace("$explain$", "<br /><div class=\"zhuyao\">" + maModel.Explain.ToString() + "</div>");
                }
                TempSoure = TempSoure.Replace("$price$", price);
                TempSoure = TempSoure.Replace("$InType$", TypeByid(int.Parse(maModel.Bigtypeid.ToString())));
                if (string.IsNullOrEmpty(viewModel.Paytype.ToString()))
                {
                    TempSoure = TempSoure.Replace("$payType$", "");
                }
                else
                {
                    TempSoure = TempSoure.Replace("$payType$", "<li><strong>��������ʽ��:</strong><span>" + viewModel.Paytype.ToString() + "</span></li>");
                }
                TempSoure = TempSoure.Replace("$Reportmessage$", strName);
                if (string.IsNullOrEmpty(viewModel.Pagecount.ToString()) || viewModel.Pagecount == 0)
                {

                    TempSoure = TempSoure.Replace("$pagecount$", "");
                }
                else
                {
                    TempSoure = TempSoure.Replace("$pagecount$", "<li><strong>������ҳ�롿:</strong><span>" + viewModel.Pagecount.ToString().Trim() + "</span></li>");
                }
                if (string.IsNullOrEmpty(viewModel.Chartcount.ToString()) || viewModel.Chartcount == 0)
                {

                    TempSoure = TempSoure.Replace("$chartCount$", "");
                }
                else
                {
                    TempSoure = TempSoure.Replace("$chartCount$", "<li><strong>��ͼ��������:</strong><span>" + viewModel.Chartcount.ToString().Trim() + "</span></li>");
                }

                if (string.IsNullOrEmpty(maModel.Effectivedata.ToString().Trim()))
                {
                    TempSoure = TempSoure.Replace("$beginEnd$", "");
                }
                else
                {
                    TempSoure = TempSoure.Replace("$beginEnd$", "<li><strong>����Ч�ڡ�:</strong><span>" + maModel.Effectivedata.ToString().Trim() + "�ꡪ" + maModel.Invaliddata.ToString() + "��</span></li>");
                }
                if (string.IsNullOrEmpty(viewModel.Publishingdate.ToString()))
                {
                    TempSoure = TempSoure.Replace("$publishTime$", "");//����ʱ��
                }
                else
                {
                    TempSoure = TempSoure.Replace("$publishTime$", "����ʱ�䣺" + viewModel.Publishingdate.ToString());//����ʱ��
                }

                TempSoure = TempSoure.Replace("$KeyWord$", viewModel.Keywords.ToString().Trim());
                TempSoure = TempSoure.Replace("$DisplayTitle$", viewModel.Description.ToString().Trim());
                if (string.IsNullOrEmpty(maModel.OverTime.ToString()))
                {
                    TempSoure = TempSoure.Replace("$OverTime$", "");
                }
                else
                {
                    TempSoure = TempSoure.Replace("$OverTime$", "<li><strong>������ʱ�䡿:</strong><span>" + maModel.OverTime.ToString().Trim() + "</span></li>");
                }
                TempSoure = TempSoure.Replace("$message$", viewModel.Message.ToString().Trim());

                //string inPathTo = "/report";
                if (string.IsNullOrEmpty(maModel.Html))
                {
                    maModel.Html = "htmlLink/" + DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("yyyyMMdd") + id + ".shtml";
                }
                string htmlFile = maModel.Html.ToString().Trim();//report/201104/201104087.shtml
                string[] html = htmlFile.Split('/');

                string folder = ReportPath + html[1].Replace("report", "");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string htmlpaths = folder + "/" + html[2];
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        private string GetSmallByName(int smallId)
        {
            StringBuilder strs = new StringBuilder();
            string sql = "select top 6 html,reportname from dbo.reportTab where smalltypeid=" + smallId + "order by createdate desc";
            DataSet ds = Tz888.DBUtility.DBHelper.Query(sql);
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    strs.Append("<li>��<a href='http://sr.topfo.com/" + row["html"].ToString() + "' target=\"_blank\">" + row["reportname"].ToString() + "</a></li>");
                }
            }
            return strs.ToString();

        }
        private string TypeByid(int bigTypeId)
        {
            IndustryType type = new IndustryType();
            return type.GetModel(bigTypeId).industryName;
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
