using System;
using System.Data;
using Tz888.DALFactory;
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
        private readonly IAutoSendMsg dal = DataAccess.CreateAutoSendMsg();
        private readonly IConn obj = DataAccess.CreateIConn();
        Tz888.BLL.SubscribeSet dalSend = new Tz888.BLL.SubscribeSet();

        #region 资源定制通知---------------------------
        public void MacthingInfo()
        {
            Tz888.BLL.SendNotice notice = new SendNotice();
            DataTable dt1 = dalSend.GetMachInfoList("");//所有订阅人列表
            for(int i=0;i<dt1.Rows.Count;i++)
            {
                string loginname =dt1.Rows[i]["LoginName"].ToString().Trim();
                DataTable dtGetTool = obj.GetList("UserParametersTab", "NoticeEmail,NoticeMobile", "parID", 1, 1, 0, 1, "loginname='" + loginname + "'");
                string email = dtGetTool.Rows[0]["NoticeEmail"].ToString().Trim();
                string mobile = dtGetTool.Rows[0]["NoticeMobile"].ToString().Trim();
                DataTable dt2 = dalSend.GetMachInfoList(loginname);//订阅ID
                string TempStr = DownUrl("http://member.topfo.com/helper/sendMachinfo.aspx?ID=" + dt2.Rows[0]["ID"].ToString(), "GB2312");
                string title = GetCustomType("0");
                string siteContent = "您有新的订阅信息,请进“拓富助手-我的订阅”中查看!";
                notice.InfoMatching(loginname, siteContent, title + "信息订阅" + DateTime.Now.ToShortDateString(), siteContent, TempStr);
            }
 
        }
        #endregion

        #region 资源有效期即将到期通知---------------
        public void InfoVali()
        {

        }
        #endregion

        #region 拓富通会员即将到期通知---------------
        public void VipVali()
        {
            SubscribeSet dalSend = new SubscribeSet();
            DataTable dt=dalSend.GetMemberExpiredList();
            Tz888.BLL.SendNotice objSend = new SendNotice();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string loginname = dt.Rows[i]["LoginName"].ToString();
                    string expireddate = Convert.ToDateTime(dt.Rows[i]["VipInvalidDate"].ToString()).ToShortDateString();
                    string email = dt.Rows[i]["NoticeEmail"].ToString().Trim();
                    string mobile = dt.Rows[i]["NoticeMobile"].ToString().Trim();
                    string mobileContet = "您的拓富通会员资格即将在" + expireddate + "过期,为了保证您的特权,请及时续费!www.topfo.com[此条信息免费]";
                    objSend.Send(loginname, mobileContet,"您的拓富通即将到期",mobileContet,mobileContet,"VipExpiredNotice");
                }
            }
        }
        #endregion

        #region 推广发送---------------------
        public void SendSubscribe()
        {
            
            //推广接收人列表
            DataTable dt1 = dalSend.GetReceivedList("");
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string loginname = dt1.Rows[i]["ReceiveLoginName"].ToString().Trim();
                    //接收方式
                    DataTable dtGetType = obj.GetList("SubscribegetsetTab", "ReveiveType", "ID", 1, 1, 0, 1, "loginname='" + loginname + "'");
                    string ReveiveType = dtGetType.Rows[0]["ReveiveType"].ToString().Trim();
                    //接收手机和邮件
                    DataTable dtGetTool = obj.GetList("UserParametersTab", "NoticeEmail,NoticeMobile", "parID", 1, 1, 0, 1, "loginname='" + loginname + "'");
                    string email = dtGetTool.Rows[0]["NoticeEmail"].ToString().Trim();
                    string mobile = dtGetTool.Rows[0]["NoticeMobile"].ToString().Trim();
                    //接收内容
                    string fldName = "ID,InfoID,Title,HtmlFile,InfoTypeID,ReceiveLoginName,PublishT";
                    string strWhere = "ReceiveLoginName='" + loginname + "' and isSend<>1";
                    DataTable dt2 = obj.GetList("SubscribeRecViw", fldName, "InfoID", 2, 1, 0, 1, strWhere);
                    if (dt2.Rows.Count > 0)//信息列表
                    {
                        #region 手机和站内短信 文本中的标题 只取两条
                        string strTitle = "";
                        if (dt2.Rows.Count>1)
                        {
                            for (int k = 0; k < dt2.Rows.Count; k++)
                            {
                                strTitle += "["+dt2.Rows[k]["Title"].ToString() + "],";
                                if (k == 1)
                                    break;
                            }
                        }
                        else
                        {
                            strTitle = "["+dt2.Rows[0]["Title"].ToString() + "],";
                        }
                        #endregion

                        #region 发送站内短信
                        if (getType(ReveiveType, "1"))
                        {
                            string siteMsgStr = "尊敬的" + GetNickName(dt2.Rows[0]["ReceiveLoginName"].ToString().Trim()) + "："
                            + "今天又有" + dt2.Rows.Count.ToString() + "条资源推荐给您："
                            + strTitle
                            + "…更多内容请到拓富中心“定向推广”处查阅。";
                            bool b = SendSiteMsg(loginname, "[好消息]" + DateTime.Now.ToShortDateString() + "优秀资源推荐", siteMsgStr);
                        }
                        #endregion

                        #region 发送手机短信
                        if (getType(ReveiveType, "3"))
                        {
                            Tz888.BLL.SendNotice objSend = new SendNotice();
                            if (mobile != "")
                            {
                               bool ab = objSend.SendMobileMsg(mobile, "优秀资源推荐," + strTitle + "更多资源请登录拓富中心查询(本条信息免费)");
                            }
                        }

                        #endregion

                        #region 发送邮件
                        if (getType(ReveiveType, "2"))
                        {
                            string url = System.Configuration.ConfigurationManager.AppSettings["EmailSubscribe"];
                            string TempStr = DownUrl(url, "GB2312");
                            string tempHtml = "";
                            for (int m = 0; m < dt2.Rows.Count; m++)
                            {
                                tempHtml += "<tr align='left'>"
                                          +"<td align='left' height='22px'>" + (m+1).ToString() + "、<span class='orange2'>" + dt2.Rows[m]["Title"].ToString() + "</span></td>"
                                          + "</tr>"
                                          +"<tr>"
                                          + "<td align='left' style='font-size:12px'>" + GetAbout(dt2.Rows[m]["InfoID"].ToString().Trim(), dt2.Rows[m]["InfoTypeID"].ToString().Trim()) + "</td>"
                                          + "</tr>"
                                          +"<tr>"
                                          + "<td align='left' height='22px'>资源链接<a class='ablue01 f12' target='_blank' href='http://www.topfo.com/" + dt2.Rows[m]["HtmlFile"].ToString() + "'>http://www.topfo.com/" + dt2.Rows[m]["HtmlFile"].ToString() + "</a></td>"
                                          + "</tr>";

                            }
                            TempStr = TempStr.Replace("#InfoCount#", dt2.Rows.Count.ToString());
                            TempStr = TempStr.Replace("#SendHtml#", tempHtml);
                            TempStr = TempStr.Replace("#NickName#", GetNickName(dt2.Rows[0]["ReceiveLoginName"].ToString().Trim()));
                            SendEmail(email, "中国招商投资网为您推荐", TempStr);
                        }
                        #endregion

                        #region 修改发送状态
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            bool issend = dalSend.isSend(loginname);
                        }
                        #endregion
                    }
                }
            }
        }
        #region

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
        #endregion

        #region 发送站内短信
        /// <summary>
        /// 发送站内短信
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Title"></param>
        /// <param name="Body"></param>
        /// <returns></returns>
        public bool SendSiteMsg(string LoginName, string Title, string Body)
        {
            bool result;
            Tz888.Model.InnerInfo model = new Tz888.Model.InnerInfo();
            Tz888.BLL.InnerInfo infoBLL = new Tz888.BLL.InnerInfo();
            model.SendName = "tz888admin";
            model.Topic = Title;
            model.ReceiveName = LoginName;
            model.Context = Body;
            model.InfoTime = DateTime.Now;
            model.ChangeBy = "tz888admin";
            
            result = infoBLL.SendInfoBLL(model, false);
            return result;
        }
        #endregion

        #region  发送邮件
        //多方发送推荐注册邮件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sendLoginName">发件人LoginName</param>
        /// <param name="sender">发送人email</param>
        /// <param name="emalList">收件人列表，以“，”号隔开</param>
        /// <param name="content"></param>
        public void SendMail2MenLst(string sendLoginName, string sender, string emalList, string content)
        {
            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer2"];
            string senderName = System.Configuration.ConfigurationManager.AppSettings["SenderEmailName2"];
            string senderMail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail2"];
            string senderPWD = System.Configuration.ConfigurationManager.AppSettings["EmailPassword2"];


            string[] receiveLST = emalList.Split(',');
            ////////////////////////////////////////////////////////////////////////
            Tz888.BLL.Register.MemberInfoBLL memberBLL = new Tz888.BLL.Register.MemberInfoBLL();
            memberBLL.AddIntegral(sendLoginName, 100);
            MailMessage mailMSG = new MailMessage();
            mailMSG.From = new MailAddress(senderMail, senderName, System.Text.Encoding.Default);

            for (int i = 0; i < receiveLST.Length; i++)
            {
                mailMSG.To.Add(receiveLST[i].ToString());
            }

            mailMSG.SubjectEncoding = System.Text.Encoding.Default;
            mailMSG.Subject = "您的好友" + sender + "邀请您加入拓富大家庭";
            mailMSG.BodyEncoding = System.Text.Encoding.Default;
            mailMSG.Body = content;
            mailMSG.IsBodyHtml = false;
            mailMSG.Priority = MailPriority.High;

            SmtpClient smtp = new SmtpClient(smtpServer);
            smtp.Send(mailMSG);

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
        #endregion

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

        /// <summary>
        /// 多方发送邮件的方法
        /// </summary>
        /// <param name="DataTable">收件人邮件地址内容</param>
        /// <param name="Title">邮件标题</param>
        /// <param name="Title">邮件条数</param>
        public void SendEmailAll(DataTable ds, string Title,int count)
        {
            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer2"];
           // smtpServer = "121.14.118.37";
            string senderName = System.Configuration.ConfigurationManager.AppSettings["SenderEmailName2"];
            string senderMail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail2"];
            string senderPWD = System.Configuration.ConfigurationManager.AppSettings["EmailPassword2"];
            try
            {
              //  string[] receiveLST = Email.Split(';');
                MailMessage mailMSG = new MailMessage();
                mailMSG.From = new MailAddress(senderMail, senderName, System.Text.Encoding.Default);

               

                foreach(DataRow row in ds.Rows)
                {
                    mailMSG.To.Add(row["Mial"].ToString());
                    mailMSG.SubjectEncoding = System.Text.Encoding.Default;
                    mailMSG.Subject = Title;
                    mailMSG.BodyEncoding = System.Text.Encoding.Default;
                    mailMSG.Body = Stringder(row["UserName"].ToString(),count).ToString();//内容
                    mailMSG.IsBodyHtml = true;
                    mailMSG.Priority = MailPriority.High;
                    mailMSG.Bcc.Add(row["Mial"].ToString());//Email
                    if (row["Mial"].ToString()=="")
                        continue;
                    SmtpClient smtp = new SmtpClient(smtpServer);
                    string mailname2 = senderMail;// senderMail.Substring(0, senderMail.IndexOf("@")).Trim();
                    smtp.UseDefaultCredentials = true;

                    smtp.Credentials = new NetworkCredential(mailname2, senderPWD);
                    smtp.Port = 25;

                    smtp.Send(mailMSG);
                    wt(row["Mial"].ToString() + "：发送成功" + DateTime.Now.ToString());
                }





            }
            catch (Exception ex)
            {
                wt("：发送失败.原因：" + ex.Message.ToString() + "," + DateTime.Now.ToString());
            }
        }

        public StringBuilder Stringder(string UserName,int count)
        {

          //  <--名称     内容       连接地址   发布时间   行业               地区        资金
          // title    zoneabout  htmlfile	  publishT   IndustryClassList  provinceID     CapitalTotal
            Tz888.BLL.Mail.MailInfoBLL email = new Tz888.BLL.Mail.MailInfoBLL();
            Tz888.SQLServerDAL.Common.Induy  dl = new Tz888.SQLServerDAL.Common.Induy();
            DataSet ds = email.SelDataSet();
            Tz888.SQLServerDAL.Common.Text common =new Tz888.SQLServerDAL.Common.Text();
            StringBuilder bu = new StringBuilder();
             bu.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            bu.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            bu.Append("<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><title>邮件</title>");
            bu.Append("<style type=\"text/css\">");
            bu.Append(" a img { border:0px;}body { margin:0px; padding:0px; font-size:12px; font-family:Arial, Helvetica, sans-serif; }ul { margin:0px; padding:0px;} li { list-style-type:none;}a { text-decoration:none; }.dds { padding-top:10px;}.dds a { color:#ff6600; font-size:14px;}");
            bu.Append(".dds a:hover { color:#000;}.ddse a { color:#626262; }.ddse a:hover { color:#ff6600; } .fdd { padding:10px 0px 10px 20px;} .fdd li { float:left; display:block; width:45px; line-height:20px; } .fdd li a{color:#0060b1;} .fdd li a:hover{color:#ff6600; } .fdda { padding:10px 0px 10px 20px;}");
            bu.Append(" .fdda li { float:left; display:block; width:60px; line-height:20px; }.fdda li a{color:#0060b1;}.fdda li a:hover{color:#ff6600; } .edwd a{ font-size:14px; color:#000000;}.edwd a:hover { color:#ff6600;} </style></head>");
            bu.Append("<div style=\"overflow:hidden; width:700px; margin:0px auto;\">");
            bu.Append("<div style=\"overflow:hidden; \">");
            bu.Append("<div style=\"float:left;\"><a href=\"http://www.topfo.com/\" target=\"_blank\"><img src=\"http://crm.topfo.com/mail/images/logo.jpg\" /></a></div>");
            bu.Append(" <div style=\"float:right; text-align:right;\"> <div class=\"dds\"><a href=\"http://member.topfo.com/Login.aspx\">[登录]</a>&nbsp;&nbsp;<a href=\"http://member.topfo.com/Register/Register.aspx\">[注册]</a></div> <div style=\"clear:both\"></div>");
            bu.Append("  <div style=\"padding-top:15px;\" class=\"edwd\"><a href=\"http://www.topfo.com/\" target=\"_blank\">拓富首页</a> | <a href=\"http://rz.topfo.com/\" target=\"_blank\">融资</a>  |  <a href=\"http://rz.topfo.com/\" target=\"_blank\">投资</a>  |  <a href=\"http://zs.topfo.com/\" target=\"_blank\">政府招商</a> | <a href=\"http://zycs.topfo.com/\" target=\"_blank\">资源超市</a> | <a href=\"http://zy.topfo.com/\" target=\"_blank\">资源联盟</a> </div> </div>");
            bu.Append(" <div style=\"clear:both\"></div></div><div style=\"border-bottom:1px dashed #959595; line-height:24px; padding-top:8px; font-size:14px; text-indent:8px;\">尊敬的会员："+UserName+"，您好!</div>");
            bu.Append(" <div style=\"overflow:hidden; padding:10px 0px 30px 0px;\"><div style=\" width:466px; float:left; overflow:hidden;\"> ");

            int index = 1;
            foreach (DataRow list in ds.Tables[0].Rows)
            {

                if (index > count)//5条
                {
                    break;
                }else{
                    bu.Append("<div style=\" overflow:hidden; padding-bottom:10px;border-bottom:1px dashed #959595;margin-bottom:10px;\">");//111
                    bu.Append("  <div style=\"padding-bottom:3px;\"><img src=\"http://crm.topfo.com/mail/images/yj_" + index + ".jpg\" /></div> <div style=\"overflow:hidden;\"><div style=\"float:left; overflow:hidden;padding:1px; border:1px solid #626262;\"><a href=\"http://www.topfo.com/" + list["HtmlFile"].ToString() + "\"><img src=\"http://crm.topfo.com/mail/images/xj_" + index + ".jpg\" /></a></div>");
                    bu.Append(" <div style=\"float:right; overflow:hidden; width:333px; line-height:18px;\"><div style=\"overflow:hidden;\">");
                    bu.Append(" <div style=\" color:#0060b1; font-weight:bold;\"><a href=\"http://www.topfo.com/" + list["HtmlFile"].ToString() + "\"> " + list["title"].ToString() + "</a></div>");
                    bu.Append(" <div class=\"ddse\">" + dl.FixLenth(common.ThrowHtml(list["zoneabout"].ToString()), 110, "....") + "</a></div> </div>");
                    bu.Append(" <div style=\"overflow:hidden; \"><div style=\"overflow:hidden; color:#626262; float:left;\"> ");
                    bu.Append(" 状态：<span style=\"color:#ff6600;\">[已审核]</span><br/>");
                    bu.Append("资金：<span style=\"color:#ff6600;\">" + list["CapitalTotal"].ToString() + "万元</span><br/>");
                    bu.Append("地区：<span style=\"color:#ff6600;\">" + dl.dvGetProveName(list["ProvinceID"].ToString()) + " " + dl.dvGetCa(list["CityID"].ToString()) + "</span><br/>");
                    bu.Append(" 行业：<span style=\"color:#ff6600;\">" + dl.IndustrySelect(list["IndustryClassList"].ToString()) + "</span><br/><span style=\"color:#959595;\">");
                    bu.Append("发布时间: " + list["publishT"].ToString().Substring(0, 9).Trim() + "");
                    bu.Append(" 有效时间：" + SelectValidate(list["ValidateTerm"].ToString()) + " </span></div>");
                    bu.Append("  <div style=\"overflow:hidden; float:right; padding-top:63px;\"><a href=\"http://www.topfo.com/" + list["HtmlFile"].ToString() + "\"><img src=\"http://crm.topfo.com/mail/images/button.jpg\" width=\"87\" height=\"24\" /></a></div> </div> <div> </div></div><div style=\"clear:both;\"></div></div></div>");
                }
                index++;
            }
           

            bu.Append(" </div><div style=\" width:214px; float:right; overflow:hidden;\"><div style=\"overflow:hidden; border:1px solid #c7c7c7; zoom:1;\">");
            bu.Append(" <div style=\"border:1px solid #fff; background-color:#f9f9f9; font-size:14px; font-weight:bold;line-height:26px; text-indent:15px;\">热门城市</div>");
            bu.Append(" <div style=\"border-top:1px solid #c7c7c7;\" class=\"fdd\"><ul>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz1098_1.shtml\">北京</a></li>");
            bu.Append(" <li><a href=\"http://rz.topfo.com/search/rz3256_1.shtml\">天津</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2610_1.shtml\">上海</a></li>");
            bu.Append(" <li> <a href=\"http://rz.topfo.com/search/rz2614_1.shtml\">广州</a></li>");
            bu.Append(" <li><a href=\"http://rz.topfo.com/search/rz2177_1.shtml\">南京</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3478_1.shtml\">杭州</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3262_1.shtml\">重庆</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2973_1.shtml\">西安</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz1908_1.shtml\">武汉</a></li> ");
            bu.Append("<li> <a href=\"http://rz.topfo.com/search/rz2177_1.shtml\">苏州</a></li> ");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz1103_1.shtml\">厦门</a></li>  ");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3078_1.shtml\">成都</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3478_1.shtml\">宁波</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2847_1.shtml\">青岛</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2002_1.shtml\">湖南</a></li> ");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3371_1.shtml\">新疆</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2218_1.shtml\">吉林</a></li> ");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2610_1.shtml\">上海</a></li> ");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz1474_1.shtml\">海南</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz1102_1.shtml\">安徽</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2434_1.shtml\">宁夏</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2536_1.shtml\">青海</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2561_1.shtml\">浙江</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3478_1.shtml\">新疆</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz1816_1.shtml\">甘肃</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz1181_1.shtml\">山东</a> </li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz2847_1.shtml\">天津</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3256_1.shtml\">黑龙江</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3290_1.shtml\">云南</a> </li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3371_1.shtml\">西藏</a> </li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rz3559_1.shtml\">内蒙古</a> </li>");
            bu.Append("</ul>");
            bu.Append("<div style=\" clear:both;\"></div>");
            bu.Append("</div></div><div style=\"overflow:hidden; border:1px solid #c7c7c7; margin-top:15px; zoom:1;\">");
            bu.Append(" <div style=\"border:1px solid #fff; background-color:#f9f9f9; font-size:14px; font-weight:bold;line-height:26px; text-indent:15px;\">热门行业</div>");
            bu.Append(" <div style=\"border-top:1px solid #c7c7c7;\" class=\"fdda\">");
            bu.Append("<ul>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_0_1.shtml\">批发零售</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_1_1.shtml\">房地产业</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_3_1.shtml\">农林牧渔</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_4_1.shtml\">食品饮料</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_5_1.shtml\">冶金矿产</a> </li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_6_1.shtml\">机械制造</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_7_1.shtml\">汽车汽配</a> </li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_8_1.shtml\">能源动力</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_9_1.shtml\">石油化工</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_10_1.shtml\">纺织服装</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_11_1.shtml\">环境保护</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_12_1.shtml\">医疗保健</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_13_1.shtml\">生物科技</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_14_1.shtml\">教育培训</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_15_1.shtml\">印刷出版</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_16_1.shtml\">广告传媒</a> </li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_17_1.shtml\">影视娱乐</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_18_1.shtml\">电子通讯</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_19_1.shtml\">建筑建材</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_20_1.shtml\">信息产业</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_21_1.shtml\">高新技术</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_22_1.shtml\">基础设施</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_23_1.shtml\">交通运输</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_24_1.shtml\">物流仓储</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_25_1.shtml\">金融投资</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_26_1.shtml\">旅游休闲</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_28_1.shtml\">酒店餐饮</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_27_1.shtml\">社会服务</a></li>");
            bu.Append("<li><a href=\"http://rz.topfo.com/search/rzInduy_2_1.shtml\">其他行业</a> </li>");

            bu.Append("</ul><div style=\" clear:both;\"></div></div> </div></div>");
            bu.Append("<div style=\" clear:both;\"></div></div><div style=\"border-top:1px dashed #959595; line-height:22px; font-family:Arial, Helvetica, sans-serif; color:#404040; text-align:center; padding:10px 0px;\">拓富网络：中国招商投资网 英文站 专业服务网 贤泽投资　支持合作：联合国工业发展组织中国投资促进处唯一授权合作网站<br/>");
            bu.Append("Copyright © 1998-2011 www.topfo.com All Rights Reserved<br/>");
            bu.Append("客服热线:0755-86146728 18925252758<br/></div>");

            bu.Append("</div>");
            bu.Append("</div>");
            bu.Append("</body></html>");
            return bu;
        }

        #region 有效期转换
        /// <summary>
        /// 有效期转换
        /// </summary>
        /// <param name="ValidateTerm"></param>
        /// <returns></returns>
        public string SelectValidate(string ValidateTerm)
        {
            switch (ValidateTerm.ToString().Trim())
            {
                case "3": ValidateTerm = "3个月"; break;
                case "6": ValidateTerm = "6个月"; break;
                case "36": ValidateTerm = "3年"; break;
                case "60": ValidateTerm = "5年"; break;
                case "12": ValidateTerm = "1年"; break;
                case "24": ValidateTerm = "2年"; break;
            }
            return ValidateTerm;
        }

        #endregion
    }
}
