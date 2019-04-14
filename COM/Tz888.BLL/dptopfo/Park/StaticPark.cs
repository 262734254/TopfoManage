using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Park;
using GZS.DAL.Park;
using System.Data;
using System.Configuration;
using System.IO;
using GZS.DAL.Menu;
namespace GZS.BLL.Park
{
    public class StaticPark
    {
        ParkInfoDAL parkBLL = new ParkInfoDAL();
        ParkInfoM parkM = new ParkInfoM();
        ParkTypeDal typeBLL = new ParkTypeDal();
        ParkImgDAL imgBLL = new ParkImgDAL();
        string path = ConfigurationManager.AppSettings["UpParkImage"].ToString();
        string ParkPath = ConfigurationManager.AppSettings["ParkSuccse"].ToString(); //成功案例生成页面存放位置
        string ParkTem = ConfigurationManager.AppSettings["ParkTemplate"].ToString(); //其他成功案例模版存放位置
        public int StaticHtml(int id, string loginName)
        {
            try
            {
                string TempFileName = ParkTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                string TempSoure = Tem;
                if (id==0)
                {
                    parkM = parkBLL.GetParkByLoginName(loginName);
                }
                else
                {
                    parkM = parkBLL.GetModel(id);   
                }
                
                TempSoure = TempSoure.Replace("$ParkID$", parkM.parkid.ToString().Trim());
                string ids = "";
                int scriptId = 0;
                TempSoure = TempSoure.Replace("$typeName$", type(ref ids, ref scriptId, loginName));
                TempSoure = TempSoure.Replace("$style$", types(ids));
                TempSoure = TempSoure.Replace("$ChinaName$", content(ids, loginName));
                TempSoure = TempSoure.Replace("$loginName$", loginName);
                CompanyShow com = new CompanyShow();
                TempSoure = TempSoure.Replace("$CompanyName$", com.GetCompanyNameByLoginName(loginName));
                //TempSoure = TempSoure.Replace("$ProductScript$", script(scriptId));
                TempSoure = TempSoure.Replace("$ParkScript$", scriptId.ToString());
                if (string.IsNullOrEmpty(parkM.htmlurl))
                {
                    parkM.htmlurl = "Park.htm";
                }
                string htmlFile = "Park.htm";//parkM.htmlurl;

                string wenjian = ParkPath + loginName;
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
        private string types(string id)
        {
            StringBuilder str = new StringBuilder();
            string[] strId = id.Split(',');
            str.Append("<style type=\"text/css\">");
            for (int j = 0; j < strId.Length - 1; j++)
            {
                str.Append("#cy_con_" + strId[j] + " p");
                str.Append("{text-align:left;}");
            }
            str.Append("</style>");
            return str.ToString();
        }
        private string script(int id)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<script language=\"javascript\" type=\"text/javascript\">");
            str.Append("SetBtn('cy'," + id + ")");
            str.Append("</script>");
            return str.ToString();
        }
        private string content(string id, string loginName)
        {
            StringBuilder str = new StringBuilder();
            string[] strId = id.Split(',');
            for (int j = 0; j < strId.Length - 1; j++)
            {
                parkM = parkBLL.GetModel(int.Parse(strId[j]));
                if (parkM != null)
                {
                    str.Append("<div id=\"cy_con_" + strId[j] + "\">");
                    str.Append("<div class=\"envuroment-right1\">");
                    str.Append(parkM.Chineseintroduced.ToString() + "</div>");
                    str.Append("<div class=\"envuroment-right1\">");
                    str.Append(parkM.Englishintroduction.ToString() + "</div>");
                    str.Append("<div class=\"envuroment-right2\">");
                    ParkImgDAL imbll = new ParkImgDAL();
                    ParkImgM imM = new ParkImgM();
                    if (parkM.parkid > 0)
                    {
                        DataSet ds = imbll.GetList(" parkid=" + parkM.parkid);
                        if ((ds != null) && ds.Tables[0].Rows.Count > 0)
                        {
                            int count = 0;
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                count++;
                                DataRow dr = ds.Tables[0].Rows[i];
                                if (i == 0)
                                {
                                    str.Append("<ul>");
                                    str.Append("<li class='l'> <img src=\"http://dp.topfo.com/img/" + loginName + "/" + dr["imgName"].ToString() + "\">");
                                    if (!string.IsNullOrEmpty(dr["imgexplain"].ToString()) && dr["imgexplain"].ToString().Length > 1)
                                    {
                                        str.Append("<p style=\"text-align:center\">" + dr["imgexplain"].ToString().Substring(1, dr["imgexplain"].ToString().Length - 1) + "</p>");
                                        //str.Append("<p><br/></p>");
                                        str.Append("</li>");
                                    }
                                    else
                                    {
                                        str.Append("<p><br/></p>");
                                    }
                                    if (ds.Tables[0].Rows.Count <= 1)
                                    {
                                        str.Append("</ul></div>");
                                    }
                                }
                                else if (i == 1)
                                {
                                    str.Append("<li class='r'> <img src=\"http://dp.topfo.com/img/" + loginName + "/" + dr["imgName"].ToString() + "\">");
                                    if (!string.IsNullOrEmpty(dr["imgexplain"].ToString()) && dr["imgexplain"].ToString().Length > 1)
                                    {
                                        str.Append("<p style=\"text-align:center\">" + dr["imgexplain"].ToString().Substring(1, dr["imgexplain"].ToString().Length - 1) + "</p>");
                                        //str.Append("<p><br/></p>");
                                        str.Append("</li>");
                                    }
                                    else
                                    {
                                        str.Append("<p><br/></p>");
                                    }
                                    str.Append("</li></ul></div>");
                                    break;
                                }
                            }
                            if (count > 1)
                            {
                                for (int k = count; k < ds.Tables[0].Rows.Count; k++)
                                {
                                    DataRow dr = ds.Tables[0].Rows[k];
                                    str.Append("<div class=\"envuroment-right" + k + "\"> <img src=\"http://dp.topfo.com/img/" + loginName + "/" + dr["imgName"].ToString() + "\">");
                                    if (!string.IsNullOrEmpty(dr["imgexplain"].ToString()) && dr["imgexplain"].ToString().Length > 1)
                                    {
                                        str.Append("<p style=\"text-align:center\">" + dr["imgexplain"].ToString().Substring(1, dr["imgexplain"].ToString().Length - 1) + "</p>");
                                        //str.Append("<p><br/></p>");
                                        str.Append("</li>");
                                    }
                                    else
                                    {
                                        str.Append("<p><br/></p>");
                                    }
                                    str.Append("</div>");
                                }
                            }
                        }
                        else
                        {
                            str.Append("</div>");
                        }
                    }
                    str.Append("</div>");
                }
                else
                {
                    str.Append("<div id=\"cy_con_" + strId[j] + "\">");
                    str.Append("暂无数据");
                    str.Append("</div>");
                }
            }
            return str.ToString();
        }
        private string type(ref string id, ref int scriptId, string loginname)
        {
            DataSet ds = parkBLL.GetList("loginname='" + loginname + "'");
            StringBuilder str = new StringBuilder();
            if ((ds != null) && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    if (i == 0)
                    {
                        scriptId = int.Parse(dr["Parkid"].ToString());
                    }
                    id += int.Parse(dr["Parkid"].ToString()) + ",";
                    int ids = int.Parse(dr["Parkid"].ToString());
                    if (i == 0)
                    {
                        str.Append("<li class=\"btn_on\" id=\"cy_btn_" + ids + "\" onclick=\"SetBtn('cy'," + ids + ")\";>");
                        str.Append(dr["ParkName"].ToString());
                        str.Append("</li>");
                    }
                    else
                    {
                        str.Append("<li id=\"cy_btn_" + ids + "\" onclick=\"SetBtn('cy'," + ids + ")\";>");
                        str.Append(dr["ParkName"].ToString());
                        str.Append("</li>");
                    }
                }
            }
            return str.ToString();
        }
    }
}
