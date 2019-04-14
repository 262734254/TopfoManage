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

 

        #region 资源有效期即将到期通知---------------
        public void InfoVali()
        {

        }
        #endregion

    

        #region 推广发送---------------------
   
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
            string strNull="&nbsp;&nbsp;&nbsp;&nbsp;详细介绍请登录<a target='_blank' href='http://www.topfo.com'>http://www.topfo.com</a>查看";
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
                return "招商";
            }
            else if (Vali.ToString() == "1")
            {
                return "投资";
            }
            else if (Vali.ToString() == "2")
            {
                return "融资";
            }
            else if (Vali.ToString() == "3")
            {
                return "创业";
            }
            else if (Vali.ToString() == "4")
            {
                return "商机";
            }
            else if (Vali.ToString() == "5")
            {
                return "资讯";
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
        /// 时间差
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
                return "投资资源";
            if (str.ToString().Trim() == "Project")
                return "融资资源";
            if (str.ToString().Trim() == "Merchant")
                return "招商资源";
            else
                return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="tool">接收工具 1 是否站内短信 2 是否邮件 3是否手机 </param>
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
        /// 多方发送邮件的方法
        /// </summary>
        /// <param name="Email">收件人邮件地址</param>
        /// <param name="Title">邮件标题</param>
        /// <param name="body">邮件内容</param>
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
                   wt(Email + "：发送成功" + DateTime.Now.ToString());
                }
               

               
                
 
            }
            catch(Exception ex)
            {
                wt(Email + "：发送失败.原因：" + ex.Message.ToString() + ","+DateTime.Now.ToString());
            }



        }
       
        /// <summary>
        /// 发送邮件的方法
        /// </summary>
        /// <param name="Email">收件人邮件地址</param>
        /// <param name="Title">邮件标题</param>
        /// <param name="body">邮件内容</param>
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

               
                
                wt(Email + "：发送成功"+DateTime.Now.ToString());
            }
            catch(Exception ex)
            {
                wt(Email + "：发送失败.原因：" + ex.Message.ToString() + ","+DateTime.Now.ToString());
            }

        }


        #region 获取网页内容
        /// <summary>
        /// 获取网页内容
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="Encod">页面编码</param>
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
