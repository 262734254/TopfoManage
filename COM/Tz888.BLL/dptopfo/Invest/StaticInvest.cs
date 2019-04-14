using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Invest;
using GZS.DAL.Invest;
using System.Data;
using System.Configuration;
using System.IO;
using GZS.DAL.Menu;
namespace GZS.BLL.Invest
{
    public class StaticInvest
    {
        string InvestPath = ConfigurationManager.AppSettings["InvestSuccse"].ToString(); //成功案例生成页面存放位置
        string InvestTem = ConfigurationManager.AppSettings["InvestTemplate"].ToString(); //其他成功案例模版存放位置

        TzbigTypeDAL bll = new TzbigTypeDAL();
        TzchildTypDAL childBll = new TzchildTypDAL();
        TzbigTypeM doma = null;
        TzchildTypeM typeM = null;
        DataRow dr = null;
        public int StaticHtml(int id, string loginName)
        {
            try
            {
                //string TempFileName = InvestTem.ToString();
                //string Tem = Compage.Reader(TempFileName); //读取模板内容
                //string TempSoure = Tem;
                //string boolS = boolStr(loginName);


                //TempSoure = TempSoure.Replace("$InvestID$", id.ToString());
                //TempSoure = TempSoure.Replace("$Content$", content(loginName, boolS));
                //TempSoure = TempSoure.Replace("$loginName$", loginName);
                //CompanyShow com = new CompanyShow();
                //TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loginName));
                //string htmlFile = "cost.htm";
                //string wenjian = InvestPath + loginName;
                //if (!Directory.Exists(wenjian))
                //{
                //    Directory.CreateDirectory(wenjian);
                //}
                //string htmlpaths = wenjian + "/" + htmlFile;
                //Compage.Writer(htmlpaths, TempSoure);
                //return 1;


                string TempFileName = InvestTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                string TempSoure = Tem;
                InvestCostM costm = new InvestCostM();
                InvestCostDAL costb = new InvestCostDAL();
                if (id == 0)
                {
                    costm = costb.GetModels(loginName);
                }
                else
                {
                    costm = costb.GetModel(id);
                }
                TempSoure = TempSoure.Replace("$zhongwencontex$", costm.Chineseintroduced.ToString());
                TempSoure = TempSoure.Replace("$EnglishContext$", costm.Englishintroduction.ToString());
                TempSoure = TempSoure.Replace("$loginName$", loginName);
                CompanyShow com = new CompanyShow();
                TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loginName));
                string htmlFile = "cost.htm";
                string wenjian = InvestPath + loginName;
                if (!Directory.Exists(wenjian))
                {
                    Directory.CreateDirectory(wenjian);
                }
                string htmlpaths = wenjian + "/" + htmlFile;
                Compage.Writer(htmlpaths, TempSoure);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        private string boolStr(string loginName)
        {
            StringBuilder str = new StringBuilder();
            DataSet ds = bll.GetList("tzparId=0");
            string ids = "";

            if ((ds != null) && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//大类
                {
                    bool flag = false;
                    dr = ds.Tables[0].Rows[i];
                    ids = dr["tztypeId"].ToString() + ",";
                    string[] strId = ids.Split(',');
                    string strIDs = "";
                    for (int b = 0; b < strId.Length - 1; b++)
                    {
                        DataSet ds1 = bll.GetList(" tzparId =" + int.Parse(strId[b]));

                        if ((ds1 != null) && ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                            {
                                dr = ds1.Tables[0].Rows[j];
                                strIDs += dr["tztypeId"].ToString() + ",";
                            }
                            string[] strChild = strIDs.Split(',');

                            DataSet ds2 = childBll.GetList(" tztypeid in(" + strIDs.Substring(0, strIDs.Length - 1) + ")" + " and loginname='" + loginName + "'");
                            if ((ds2 != null) && ds2.Tables[0].Rows.Count > 0)
                            {
                                for (int c = 0; c < ds2.Tables[0].Rows.Count; c++)
                                {
                                    dr = ds2.Tables[0].Rows[c];
                                    if (!string.IsNullOrEmpty(dr["typeprice"].ToString()) && dr["typeprice"].ToString() != "0" && dr["typeprice"].ToString() != "0.00" && Convert.ToInt32(dr["typeprice"]) != 0)
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    str.Append(flag + ",");
                }
            }
            return str.ToString();
        }
        private string content(string loginName, string boolStr)
        {
            StringBuilder str = new StringBuilder();
            DataSet ds = bll.GetList("tzparId=0");
            string ids = "";

            if ((ds != null) && ds.Tables[0].Rows.Count > 0)
            {
                str.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead> <tr><td width=\"33%\">项目 Items </td><td width=\"50%\">类别 Categories</td> <td width=\"17%\"> 价格 Price</td></tr></thead>");
                str.Append("<tbody>");
                string[] boChild = boolStr.Split(',');
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)//大类
                {
                    if (boChild[i].Equals("True"))
                    {
                        str.Append("<tr>");
                    }
                    else
                    {
                        str.Append("<tr style=\"display:none;\">");
                    }

                    dr = ds.Tables[0].Rows[i];
                    ids = dr["tztypeId"].ToString() + ",";
                    string str1 = "";
                    if (dr["tztypeName"].ToString().Length > 4)
                    {
                        str1 = dr["tztypeName"].ToString().Substring(0, 9) + "<br />" + dr["tztypeName"].ToString().Substring(9);
                    }
                    else
                    {
                        str1 = dr["tztypeName"].ToString();
                    }
                    str.Append("<td class=\"bold\">" + str1 + "</td>");

                    string[] strId = ids.Split(',');
                    string strIDs = "";
                    for (int b = 0; b < strId.Length - 1; b++)
                    {
                        DataSet ds1 = bll.GetList(" tzparId =" + int.Parse(strId[b]));

                        if ((ds1 != null) && ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                            {
                                dr = ds1.Tables[0].Rows[j];
                                strIDs += dr["tztypeId"].ToString() + ",";
                            }
                            string[] strChild = strIDs.Split(',');

                            DataSet ds2 = childBll.GetList(" tztypeid in(" + strIDs.Substring(0, strIDs.Length - 1) + ")" + " and loginname='" + loginName + "'");
                            if ((ds2 != null) && ds2.Tables[0].Rows.Count > 0)
                            {
                                str.Append("<td><ul>");
                                for (int c = 0; c < ds2.Tables[0].Rows.Count; c++)//大类
                                {
                                    dr = ds2.Tables[0].Rows[c];
                                    if (!string.IsNullOrEmpty(dr["typeprice"].ToString()) && dr["typeprice"].ToString() != "0" && dr["typeprice"].ToString() != "0.00" && Convert.ToInt32(dr["typeprice"]) != 0)
                                    {
                                        str.Append(" <li>" + dr["tzchildName"] + "</li>");
                                    }
                                }
                                str.Append("</ul></td>");
                            }
                            else
                            {
                                str.Append("<td><ul>");
                                //str.Append("<li>暂无数据</li>");
                                str.Append("<li></li>");
                                str.Append("</ul></td>");
                            }
                            if ((ds2 != null) && ds2.Tables[0].Rows.Count > 0)
                            {
                                str.Append("<td><ul>");
                                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)//大类
                                {
                                    dr = ds2.Tables[0].Rows[j];
                                    if (!string.IsNullOrEmpty(dr["typeprice"].ToString()) && dr["typeprice"].ToString() != "0" && dr["typeprice"].ToString() != "0.00" && Convert.ToInt32(dr["typeprice"]) != 0)
                                    {
                                        str.Append(" <li>" + dr["typeprice"] + "</li>");
                                    }
                                }
                                str.Append("</ul></td>");
                            }
                        }
                        else
                        {
                            str.Append("<td><ul>");
                            //str.Append("<li>暂无数据</li>");
                            str.Append("<li></li>");
                            str.Append("</ul></td>");
                            str.Append("<td><ul>");
                            //str.Append("<li>暂无数据</li>");
                            str.Append("<li></li>");
                            str.Append("</ul></td>");
                        }
                    }
                    str.Append("</tr>");
                }
                str.Append("</tbody></table>");
            }
            return str.ToString();
        }
    }
}
