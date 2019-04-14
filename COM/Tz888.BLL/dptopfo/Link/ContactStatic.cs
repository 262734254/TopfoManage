using System;
using System.Collections.Generic;
using System.Text;
using GZS.Model.Park;
using GZS.DAL.Park;
using System.Data;
using System.Configuration;
using System.IO;
using GZS.DAL.Link;
using GZS.Model.Link;

namespace GZS.BLL.Link
{

    public class ContactStatic
    {
        string ImageMappath = ConfigurationManager.AppSettings["UpProductImage"].ToString();
        string ContactPath = ConfigurationManager.AppSettings["ContactSuccse"].ToString(); //成功案例生成页面存放位置
        string ContactTem = ConfigurationManager.AppSettings["ContactTemplate"].ToString(); //其他成功案例模版存放位置

        TZLinkDAL linkBll = new TZLinkDAL();
        TZLinkM linkM = new TZLinkM();
        public int StaticHtml(string loginName)
        {
            try
            {
                string TempFileName = ContactTem.ToString();
                string Tem = Compage.Reader(TempFileName); //读取模板内容
                string TempSoure = Tem;

                linkM = linkBll.GetModelByLoginName(loginName);
                StringBuilder sb = new StringBuilder();
                string imageStr = "";
                if (!string.IsNullOrEmpty(linkM.Name))
                {
                    sb.Append("<li>联系人：" + linkM.Name + "</li>");
                }
                if (!string.IsNullOrEmpty(linkM.Tel))
                {
                    string[] str = linkM.Tel.Split(',');
                    string strs = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] != "")
                        {
                            strs += str[i] + "-";
                        }
                    }
                    if (strs.EndsWith("-"))
                    {
                        strs = strs.Substring(0, strs.Length - 1);

                    }
                    if (!string.IsNullOrEmpty(strs))
                    {
                        sb.Append("<li>联系电话：" + strs + "</li>");
                    }
                }
                if (!string.IsNullOrEmpty(linkM.Phone))
                {
                    sb.Append("<li>手机号码：" + linkM.Phone + "</li>");
                }
                if (!string.IsNullOrEmpty(linkM.Email))
                {
                    sb.Append("<li>电子邮箱：" + linkM.Email + "</li>");
                }
                if (!string.IsNullOrEmpty(linkM.Address))
                {
                    sb.Append("<li>联系地址：" + linkM.Address + "</li>");
                }
                if (!string.IsNullOrEmpty(linkM.OtherMode))
                {
                    sb.Append("<li>其它联系方式：" + linkM.OtherMode + "</li>");
                }
                if (!string.IsNullOrEmpty(linkM.ImageMap))
                {
                    imageStr = "<img src='http://dp.topfo.com/img/" + loginName + "/" + linkM.ImageMap + "' width='302' height='209' />";
                    //imageStr = "<img src='" + ImageMappath + loginName + "/" + linkM.ImageMap + "' width='302' height='209' />";
                }
                TempSoure = TempSoure.Replace("[无联系方式]", sb.ToString());

                TempSoure = TempSoure.Replace("[无公司地图]", imageStr);
                TempSoure = TempSoure.Replace("$loginName$", loginName);

                string htmlFile = "Contact.htm";//parkM.htmlurl;

                string wenjian = ContactPath + loginName;
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
    }
}
