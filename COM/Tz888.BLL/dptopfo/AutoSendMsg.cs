using System;
using System.Data;

using Tz888.Model;
using Tz888.IDAL;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Tz888.BLL
{
    public class AutoSendMsg
    {
        Tz888.SQLServerDAL.AutoSendMsg dal = new Tz888.SQLServerDAL.AutoSendMsg();
        Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();

        Tz888.BLL.SubscribeSet dalSend = new Tz888.BLL.SubscribeSet();

 

        #region ��Դ��Ч�ڼ�������֪ͨ---------------
        public void InfoVali()
        {

        }
        #endregion

    

        #region �ƹ㷢��---------------------
   
        public void wt(string str)
        {
            if (System.IO.File.Exists(@"E:\log.txt"))
            {
                try
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(@"E:\log.txt", true, System.Text.Encoding.GetEncoding("gb2312"));
                    sw.WriteLine(str);
                    sw.Flush();
                    sw.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }
        public string GetAbout(string InfoID, string TypeID)
        {
            DataTable dt = new DataTable();
            string strNull="&nbsp;&nbsp;&nbsp;&nbsp;��ϸ�������¼<a target='_blank' href='http://www.topfo.com'>http://www.topfo.com</a>�鿴";
            if (TypeID == "Capital")
            {
                dt = obj.GetList("CapitalInfoTab", "ComAbout", "Infoid", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));
                if(dt.Rows.Count>0)
                    return "&nbsp;&nbsp;&nbsp;&nbsp;" + GetStr(dt.Rows[0]["ComAbout"].ToString());
                else 
                    return strNull;

            }
            if (TypeID == "Project")
            {
                dt = obj.GetList("ProjectInfoTab", "ComAbout", "Infoid", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));
               if(dt.Rows.Count>0)
                    return "&nbsp;&nbsp;&nbsp;&nbsp;" + GetStr(dt.Rows[0]["ComAbout"].ToString());
                else 
                    return strNull;
            }
            if (TypeID == "Merchant")
            {
                dt = obj.GetList("MerchantInfoTab", "ZoneAbout", "Infoid", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));
                if(dt.Rows.Count>0)
                     return "&nbsp;&nbsp;&nbsp;&nbsp;" + GetStr(dt.Rows[0]["ZoneAbout"].ToString());
                else 
                    return strNull;
            }
            else
            {
                return strNull;
            }
        }
        public string GetCustomType(object Vali)
        {
            if (Vali.ToString() == "0")
            {
                return "����";
            }
            else if (Vali.ToString() == "1")
            {
                return "Ͷ��";
            }
            else if (Vali.ToString() == "2")
            {
                return "����";
            }
            else if (Vali.ToString() == "3")
            {
                return "��ҵ";
            }
            else if (Vali.ToString() == "4")
            {
                return "�̻�";
            }
            else if (Vali.ToString() == "5")
            {
                return "��Ѷ";
            }
            else
            {
                return "";
            }
        }
        public string GetStr(string str)
        {
            if (str.Length > 200)
            {
                return str.Substring(0, 200).Trim();
            }
            else
            {
                return str.Trim();
            }
        }
        public string GetNickName(string loginname)
        {
            DataTable dt = obj.GetList("LoginInfoTab", "NickName", "LoginID", 1, 1, 0, 1, "LoginName='" + loginname + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["NickName"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// ʱ���
        /// </summary>
        /// <param name="adddate"></param>
        /// <returns></returns>
        public string GetDiff(string adddate)
        {
            DateTime date1 = new DateTime(Convert.ToDateTime(adddate).Year, Convert.ToDateTime(adddate).Month, Convert.ToDateTime(adddate).Day);
            DateTime date2 = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
            System.TimeSpan diff = date1 - date2;
            return diff.ToString();
        }
        public string GetInfoTypeName(string str)
        {
            if (str.ToString().Trim() == "Capital")
                return "Ͷ����Դ";
            if (str.ToString().Trim() == "Project")
                return "������Դ";
            if (str.ToString().Trim() == "Merchant")
                return "������Դ";
            else
                return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tool">���չ��� 1 �Ƿ�վ�ڶ��� 2 �Ƿ��ʼ� 3�Ƿ��ֻ� </param>
        /// <returns></returns>
        public bool getType(string type, string tool)
        {
            if (type != "")
            {
                bool b = type.Contains(tool);
                return b;
            }
            else
                return false;
        }
        #endregion
    

    

        /// <summary>
        /// �෽�����ʼ��ķ���
        /// </summary>
        /// <param name="Email">�ռ����ʼ���ַ</param>
        /// <param name="Title">�ʼ�����</param>
        /// <param name="body">�ʼ�����</param>
        public void SendEmailAll(string Email, string Title, string body)
        {
           
            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer2"];
            string senderName =System.Configuration.ConfigurationManager.AppSettings["SenderEmailName2"];
            string senderMail =System.Configuration.ConfigurationManager.AppSettings["SenderEmail2"];
            string senderPWD = System.Configuration.ConfigurationManager.AppSettings["EmailPassword2"];
            if (Email == "")
                return;
            ////////////////////////////////////////////////////////////////////////
            try
            {
                 string[] receiveLST = Email.Split(';');
                MailMessage mailMSG = new MailMessage();
                mailMSG.From = new MailAddress(senderMail, senderName, System.Text.Encoding.Default);
                for (int i = 0; i < receiveLST.Length; i++)
               {
                   mailMSG.To.Add(receiveLST[i].ToString());
                   mailMSG.SubjectEncoding = System.Text.Encoding.Default;
                   mailMSG.Subject = Title;
                   mailMSG.BodyEncoding = System.Text.Encoding.Default;
                   mailMSG.Body = body;
                   mailMSG.IsBodyHtml = true;
                   mailMSG.Priority = MailPriority.High;
                   mailMSG.Bcc.Add(receiveLST[i]);
                   SmtpClient smtp = new SmtpClient(smtpServer);
                   string mailname2 = senderMail;// senderMail.Substring(0, senderMail.IndexOf("@")).Trim();
                   smtp.UseDefaultCredentials = false;
                    
                   smtp.Credentials = new NetworkCredential(mailname2, senderPWD);
                   smtp.Port = 25;
                   
                   smtp.Send(mailMSG);
                   wt(Email + "�����ͳɹ�" + DateTime.Now.ToString());
                }
               

               
                
 
            }
            catch(Exception ex)
            {
                wt(Email + "������ʧ��.ԭ��" + ex.Message.ToString() + ","+DateTime.Now.ToString());
            }



        }
       
        /// <summary>
        /// �����ʼ��ķ���
        /// </summary>
        /// <param name="Email">�ռ����ʼ���ַ</param>
        /// <param name="Title">�ʼ�����</param>
        /// <param name="body">�ʼ�����</param>
        public void SendEmail(string Email, string Title, string body)
        {
            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer2"];
            string senderName =System.Configuration.ConfigurationManager.AppSettings["SenderEmailName2"];
            string senderMail =System.Configuration.ConfigurationManager.AppSettings["SenderEmail2"];
            string senderPWD = System.Configuration.ConfigurationManager.AppSettings["EmailPassword2"];
            if (Email == "")
                return;
            ////////////////////////////////////////////////////////////////////////
            try
            {
                MailMessage mailMSG = new MailMessage();
                mailMSG.From = new MailAddress(senderMail, senderName, System.Text.Encoding.Default);
                mailMSG.To.Add(Email);

                mailMSG.SubjectEncoding = System.Text.Encoding.Default;
                mailMSG.Subject = Title;
                mailMSG.BodyEncoding = System.Text.Encoding.Default;
                mailMSG.Body = body;
                mailMSG.IsBodyHtml = true;
                mailMSG.Priority = MailPriority.High;

                SmtpClient smtp = new SmtpClient(smtpServer);
                string mailname2 = senderMail;// senderMail.Substring(0, senderMail.IndexOf("@")).Trim();
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(mailname2, senderPWD);
                smtp.Port = 25;
                smtp.Send(mailMSG);

               
                
                wt(Email + "�����ͳɹ�"+DateTime.Now.ToString());
            }
            catch(Exception ex)
            {
                wt(Email + "������ʧ��.ԭ��" + ex.Message.ToString() + ","+DateTime.Now.ToString());
            }

        }


        #region ��ȡ��ҳ����
        /// <summary>
        /// ��ȡ��ҳ����
        /// </summary>
        /// <param name="url">��ַ</param>
        /// <param name="Encod">ҳ�����</param>
        /// <returns></returns>
        public string DownUrl(string url, string Encod)
        {
            WebClient wc = new WebClient();

            byte[] by = wc.DownloadData(url);

            return Encoding.GetEncoding(Encod).GetString(by);

        }
        #endregion

    }
}
