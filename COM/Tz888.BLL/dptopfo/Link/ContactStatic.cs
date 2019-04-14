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
        string ContactPath = ConfigurationManager.AppSettings["ContactSuccse"].ToString(); //�ɹ���������ҳ����λ��
        string ContactTem = ConfigurationManager.AppSettings["ContactTemplate"].ToString(); //�����ɹ�����ģ����λ��

        TZLinkDAL linkBll = new TZLinkDAL();
        TZLinkM linkM = new TZLinkM();
        public int StaticHtml(string loginName)
        {
            try
            {
                string TempFileName = ContactTem.ToString();
                string Tem = Compage.Reader(TempFileName); //��ȡģ������
                string TempSoure = Tem;

                linkM = linkBll.GetModelByLoginName(loginName);
                StringBuilder sb = new StringBuilder();
                string imageStr = "";
                if (!string.IsNullOrEmpty(linkM.Name))
                {
                    sb.Append("<li>��ϵ�ˣ�" + linkM.Name + "</li>");
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
                        sb.Append("<li>��ϵ�绰��" + strs + "</li>");
                    }
                }
                if (!string.IsNullOrEmpty(linkM.Phone))
                {
                    sb.Append("<li>�ֻ����룺" + linkM.Phone + "</li>");
                }
                if (!string.IsNullOrEmpty(linkM.Email))
                {
                    sb.Append("<li>�������䣺" + linkM.Email + "</li>");
                }
                if (!string.IsNullOrEmpty(linkM.Address))
                {
                    sb.Append("<li>��ϵ��ַ��" + linkM.Address + "</li>");
                }
                if (!string.IsNullOrEmpty(linkM.OtherMode))
                {
                    sb.Append("<li>������ϵ��ʽ��" + linkM.OtherMode + "</li>");
                }
                if (!string.IsNullOrEmpty(linkM.ImageMap))
                {
                    imageStr = "<img src='http://dp.topfo.com/img/" + loginName + "/" + linkM.ImageMap + "' width='302' height='209' />";
                    //imageStr = "<img src='" + ImageMappath + loginName + "/" + linkM.ImageMap + "' width='302' height='209' />";
                }
                TempSoure = TempSoure.Replace("[����ϵ��ʽ]", sb.ToString());

                TempSoure = TempSoure.Replace("[�޹�˾��ͼ]", imageStr);
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
